import os
import re
from github import Github

gitHubRepo = "Samsung/TizenFX"
diffPattern = re.compile('^@@ \-([0-9,]+) \+([0-9,]+) @@')

class PRManager:
    def __init__(self, token, prNumber):
        self._gh = Github(token)
        self.pr = self._gh.get_repo(gitHubRepo).get_pull(prNumber)

        self.latestCommit = self.pr.get_commits().reversed[0]
        self.changedFiles = self.pr.get_files()

        self.lineNumberToPositionMap = {}
        self.fileDiffHunkPairs = {}

        for file in self.changedFiles:
            if file.patch is None:
                continue
            _patchLines = file.patch.split("\n")
            self._CreatePositionMap(file, _patchLines)
            _diffLines = []
            for hunkline in _patchLines:
                m = diffPattern.match(hunkline)
                if m is not None:
                    hunkrange = m.group(2).split(',')
                    if len(hunkrange) == 1:
                        hunkrange.append(1)
                    _diffLines.insert(0, map(int, hunkrange))
            _diffLines.reverse()
            self.fileDiffHunkPairs[file] = _diffLines

    def _CreatePositionMap(self, file, patchLines):
        self.lineNumberToPositionMap[file] = {}
        lineNumber = 0
        for position, line in enumerate(patchLines):
            m = diffPattern.match(line)
            if m is not None:
                lineNumber = int(m.group(2).split(',')[0])
                continue
            elif line[0] == '-':
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

    def CreateIssueComment(self, body):
      self.pr.create_issue_comment(body)
