; -- YouTubeDownloadAPP-Installer.iss \ Copyright © 2022 by @Franco28 --

#define MyAppName "YouTubeDownload"
#define MyAppName2 "YouTubeDownload_v"
#define MyInstallerSuffix "_Setup"
#define MyAppVersion "1.0.0.1"
#define MyAppPublisher "A .NET Tool to download videos and convert it to .mp3 or .wav from YouTube"
#define MyAppURL "https://github.com/Franco28/YouTubeDownloadAPP"
#define MyAppExeName "YouTubeDownload.exe"
#define MyAppDate "2022-08-01"

[Setup]
AppId={{4623B2F2-9FDD-4D61-A759-F6A12FD1141D}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppComments={#MyAppPublisher}
AppPublisher=Franco28
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
ChangesAssociations=yes
DefaultDirName={sd}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableDirPage=yes
AppReadmeFile=https://github.com/Franco28/YouTubeDownloadAPP#readme
AllowNoIcons=yes
ArchitecturesAllowed=x86 x64
OutputBaseFilename={#MyAppName2}{#MyAppVersion}{#MyInstallerSuffix}
Compression=lzma2/ultra64
InternalCompressLevel=ultra
CompressionThreads=8
WizardImageStretch=True
AppContact=Support
AppCopyright=Copyright © 2022 @Franco28
UninstallDisplayIcon={app}\icons\icon.ico
SetupIconFile=icons\icon.ico
TouchDate={#MyAppDate}
UserInfoPage=no
WizardStyle=modern
InfoBeforeFile=releases_es.txt
OutputDir=C:\Users\franc\Desktop\YouTubeDownloadAPP\SETUP
UninstallDisplayName={#MyAppName}
VersionInfoVersion={#MyAppVersion}
TimeStampsInUTC=yes 
LicenseFile=LICENSE.txt

[Languages]
Name: es; MessagesFile: "compiler:Languages\Spanish.isl"

[Messages]
es.BeveledLabel={#MyAppName} v{#MyAppVersion} - Español

[CustomMessages]
es.RemoveToolSettings=¿Quieres remover toda la configuración de YouTubeDownload?

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}";

[Files]     
Source: "YouTubeDownload.exe"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "YouTubeDownload.exe.config"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs   
Source: "MediaToolkit.Core.dll.config"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs   
Source: "MediaToolkit.dll.config"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs   
Source: "AutoUpdater.NET.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "libvideo.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "NiL.JS.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "TagLibSharp.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "NAudio.WinMM.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "NAudio.WinForms.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "NAudio.Wasapi.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "NAudio.Midi.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "NAudio.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "NAudio.Core.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "NAudio.Asio.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "MediaToolkit.Core.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs   
Source: "MediaToolkit.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs   
Source: "Microsoft.Bcl.AsyncInterfaces.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs   
Source: "Microsoft.Extensions.Logging.Abstractions.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs   
Source: "Microsoft.Extensions.Logging.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs   
Source: "Microsoft.Win32.Registry.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs   
Source: "System.Buffers.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs   
Source: "System.Diagnostics.DiagnosticSource.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs   
Source: "System.Memory.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs   
Source: "System.Numerics.Vectors.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs   
Source: "System.Runtime.CompilerServices.Unsafe.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs  
Source: "System.Security.Principal.Windows.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "System.Security.AccessControl.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "LICENSE.txt"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "release.txt"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "runtimes"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "runtimes/*"; DestDir: "{app}/runtimes/"; Flags: ignoreversion recursesubdirs createallsubdirs    
Source: "icons"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "icons/*"; DestDir: "{app}/icons/"; Flags: ignoreversion recursesubdirs createallsubdirs    

[Icons]
Name: "{group}\{cm:ProgramOnTheWeb,{#MyAppName}}"; Filename: "{#MyAppURL}";
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"; IconFilename: "{app}\icons\unins.ico";
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Comment: "{#MyAppPublisher}"; Tasks: desktopicon;

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, "&", "&&")}}"; Flags: shellexec nowait postinstall skipifsilent;

[InstallDelete]
Type: filesandordirs; Name: "{app}\runtimes";
Type: filesandordirs; Name: "{app}\icons";
Type: files; Name: "{app}\LICENSE";
Type: files; Name: "{app}\*.dll"; 
Type: files; Name: "{app}\*.txt";
Type: files; Name: "{app}\*.config"; 

[UninstallDelete]
Type: filesandordirs; Name: "{app}\runtimes";
Type: filesandordirs; Name: "{app}\icons";
Type: files; Name: "{app}\*.dll";
Type: files; Name: "{app}\*.txt";
Type: files; Name: "{app}\*.config"; 
Type: files; Name: "{userdocs}\YouTubeDownload"; 
    
[Code]
procedure CurUninstallStepChanged (CurUninstallStep: TUninstallStep);
begin
   case CurUninstallStep of                   
     usPostUninstall:
       begin
         if MsgBox(ExpandConstant('{cm:RemoveToolSettings}'), mbConfirmation, MB_YESNO) = IDYES then      
            DelTree(ExpandConstant('{app}\runtimes'), True, True, True);
            DelTree(ExpandConstant('{app}\icons'), True, True, True);
            DelTree(ExpandConstant('{app}'), True, True, True);
            DelTree(ExpandConstant('C:\YouTubeDownload'), True, True, True);
            DelTree(ExpandConstant('{userdocs}\YouTubeDownload'), True, True, True);
        end;
  end;
end;   