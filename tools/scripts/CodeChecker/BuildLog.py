import re

class BuildLog:
  def __init__(self, filePath):
    self.warnings = []
    self.errors = []
    self._file = open(filePath, 'r')
    self._parseLog()

  def _parseLog(self):
    errorPattern = re.compile('[0-9]+>(.+)\(([0-9]+),[0-9]+\): (error|warning) ([A-Z0-9]+): (.+) \[/')
    for line in self._file.readlines():
      m = errorPattern.match(line.strip())
      if m is not None:
        item = {'file': m.group(1), 'line': int(m.group(2)), 'type': m.group(3), 'code': m.group(4), 'message': m.group(5)}
        if item['type'] == 'warning':
          self.warnings.append(item)
        elif item['type'] == 'error':
          self.errors.append(item)

  def __del__(self):
    self._file.close()
