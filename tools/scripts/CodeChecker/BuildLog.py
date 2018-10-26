class BuildLog:
    FILE = 0
    LINE_NUMBER = 1
    WARNING_CODE = 2
    MESSAGE = 3

    def __init__(self, filePath):
        self._file = open(filePath, 'r')
        self._parseLog()

    def _parseLog(self):
        self._lines = self._file.readlines()
        self._lines[:] = [line for line in self._lines if ": warning" in line]
        self.warnings = [[0 for i in range(4)] for y in range(len(self._lines))]

        for index, line in enumerate(self._lines):
            self._lines[index] = line.split(":")
            self._lines[index][0] = self._lines[index][0][:-1].split("(")

            self.warnings[index][self.FILE] = self._lines[index][0][0]
            self.warnings[index][self.LINE_NUMBER] = int(self._lines[index][0][1].split(",")[0])
            self.warnings[index][self.WARNING_CODE] = self._lines[index][1]
            self.warnings[index][self.MESSAGE] = self._lines[index][2].split("[/")[0]

    def __del__(self):
        self._file.close()

if __name__ == "__main__":
    logPath = "../../build.log"
    logs = BuildLog(logPath)
    print(logs.warnings)
