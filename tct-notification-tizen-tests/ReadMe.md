tct-suite-tizen-tests
├── src            - Directory containing main method and test cases.
│   ├── Program.cs    - Main method of the application.
│   ├── testcase
│   │       ├── TSApplicationManager.cs  - Test case file of ApplicationManager Class.
│   │       └── ……                      - Other test case files.
│   └── support
│            └── ApplicationCommon.cs         - A Support file which supports test cases.
├── bin             - Contains executable file which is created by make file.
├── lib            - Library files which needs to be packed.
├── res            - Resource folder for any resources needed to run test.
├── share
├── Makefile         - Script which builds package.
├── TCTCert.p12        - A Certificate file for building package. (pw:test)
└── tizen-manifest.xml    - A Tizen Manifest file for declaring privilege and controls.
