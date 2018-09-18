import os
from github import Github

gitHubRepo = "Samsung/TizenFX"
token = os.environ['TizenAPI-Bot-Token']

class PRManager:
    def __init__(self, prNumber):
        self._gh = Github(token)
        self.pr = self._gh.get_repo(gitHubRepo).get_pull(prNumber)

        self.latestCommit = self.pr.get_commits().reversed[0]
        self.changedFiles = self.pr.get_files()

        self.lineNumberToPositionMap = {}
        self.fileDiffHunkPairs = {}

        for file in self.changedFiles:
            _patchLines = file.patch.split("\n")
            self._CreatePositionMap(file, _patchLines)
            _patchLines[:] = [line for line in _patchLines if "@@" in line]
            _diffLines = []
            for hunkline in _patchLines:
                hunkline = hunkline[2:]
                startingLine = hunkline[hunkline.find("+")+1:hunkline.find("@@")]
                startingLine = startingLine.strip()
                startingLine = startingLine.split(",")
                _diffLines.insert(0, map(int, startingLine))
            _diffLines.reverse()
            self.fileDiffHunkPairs[file] = _diffLines

    def _CreatePositionMap(self, file, patchLines):
        self.lineNumberToPositionMap[file] = {}
        for position, line in enumerate(patchLines):
            if line[0] == "@":
                line = line[line.find("+")+1:]
                lineNumber = int(line[:line.find(",")])
                continue
            elif line[0] == "-":
                continue
            self.lineNumberToPositionMap[file][lineNumber] = position
            lineNumber += 1

    def _CheckComment(self, file, position, body):
        _comments = self.pr.get_comments();
        for comment in _comments:
            if (comment.path == file and comment.position == position and comment.body == body):
                # Comment already exists
                return False
        return True

    def CreateReviewComment(self, file, lineNumber, body):
        _position = self.lineNumberToPositionMap[file][lineNumber]
        if self._CheckComment(file.filename, _position, body):
            self.pr.create_review_comment(body, self.latestCommit, file.filename, _position)

if __name__ == "__main__":
    pr = 9
    gh = PRManager(pr)
    for file in gh.changedFiles:
        print("Chaged File: " + file.filename)
    