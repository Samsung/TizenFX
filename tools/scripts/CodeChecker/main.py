import sys
from BuildLog import BuildLog
from PRManager import PRManager

logPath = "./build.log"

if __name__ == "__main__":
    if len(sys.argv) < 3:
        print("Execute with token and the PR number")
        print(" ~$ python main.py [Token] [PR Number]")
        exit(1)
    logs = BuildLog(logPath)
    pr = PRManager(sys.argv[1], int(sys.argv[2]))
    warningsInFile = []
    for file in pr.changedFiles:
        if file.patch is None:
            continue
        warningsInFile = [warning for warning in logs.warnings if file.filename.endswith(warning[logs.FILE])]

        for diffLine in pr.fileDiffHunkPairs[file]:
            for warning in warningsInFile:
                if (diffLine[0]) <= warning[BuildLog.LINE_NUMBER] and warning[BuildLog.LINE_NUMBER] < (diffLine[0] + diffLine[1]):
                    print("{}, Warning on line {}! -> ".format(file.filename, warning[BuildLog.LINE_NUMBER]) + warning[BuildLog.MESSAGE])
                    _warningMessage = warning[BuildLog.WARNING_CODE] + ":" +warning[BuildLog.MESSAGE]
                    pr.CreateReviewComment(file, warning[BuildLog.LINE_NUMBER], _warningMessage)

