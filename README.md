# quick-test
Quick test C# console app

## Dev Notes

### Creating

To create a quick console project go into an empty directory and run the command

```
C:\project>dotnet new console
```

### Building

To build and run

```
C:\project>dotnet run
```

### Debugging

If you have the .NET sdk installed for wsl2, then the C# for Visual Studio Code extension will offer to add the correct settings to your .vscode folder when it notices them missing

To install the .NET 7.0 sdk on wsl2. For Ubuntu 20.04 the following commands will install the sdk.

_**Note:** To deterine the version of Ubuntu you are using run one of the following ```lsb_release -a``` or ```cat /etc/os-release```_

```bash
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y dotnet-sdk-7.0
```

### Handling CR/LF

Run the folloing perl command to convert CR/LF to LF

```bash
perl -i.org -pe 's/\r\n/\n/g' filename.cs
```