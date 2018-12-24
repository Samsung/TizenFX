import sys
from BuildLog import BuildLog
from PRManager import PRManager

logPath = "./build.log"

if __name__ == "__main__":

  if len(sys.argv) < 3:
    print("Execute with token and the PR number")
    print(" ~$ python main.py [Token] [PR Number]")
    exit(1)

  # Parse build.log
  logs = BuildLog(logPath)

  # Parse PullRequest
  pr = PRManager(sys.argv[1], int(sys.argv[2]))

  # Report Warnings
  for file in pr.changedFiles:
    if file.patch is None:
      continue
    warningsInFile = [warning for warning in logs.warnings if file.filename.endswith(warning['file'])]
    for diffLine in pr.fileDiffHunkPairs[file]:
      for warning in warningsInFile:
        if (diffLine[0]) <= warning['line'] and warning['line'] < (diffLine[0] + diffLine[1]):
          _warningMessage = 'warning ' + warning['code'] + ": " + warning['message']
          print("{}({}): {}".format(file.filename, warning['line'], _warningMessage))
          pr.CreateReviewComment(file, warning['line'], _warningMessage)

  # Report Errors
  if len(logs.erros) > 0:
    errBody = '### Build Error:\n'
    for err in logs.errors:
      errBody += '> {}({}): {}: {}\n'.format(err['file'], err['line'], err['code'], err['message'])
    pr.CreateIssueComment(errBody)
