; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "NAPS2 Scanner Button"
#define MyAppVersion "1.0"
#define MyAppPublisher "J�rn Bungartz"
#define MyAppURL "http://bungartz.pm/"
#define MyAppExeName "scan-button-responder.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{4BFD8E60-D503-4335-8ED7-231217015DF8}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DisableProgramGroupPage=yes
OutputBaseFilename=naps2-scanner-button
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "..\bin\Debug\scan-button-responder.exe"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files
Source: "..\bin\Debug\LiteDB.dll"; DestDir: "{app}"

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"

[Run]
Filename: "{app}\scan-button-responder.exe"; Parameters: "register"; WorkingDir: "{app}"; StatusMsg: "Registering application"

[UninstallRun]
Filename: "{app}\scan-button-responder.exe"; Parameters: "unregister"; WorkingDir: "{app}"; StatusMsg: "Unregistering application"