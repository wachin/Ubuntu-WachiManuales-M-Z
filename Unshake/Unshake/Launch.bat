if exist "c:\jdk1.2.2\jre\bin\javaw.exe" path "c:\jdk1.2.2\jre\bin\javaw.exe"
if exist "c:\Program Files\JavaSoft\jre\1.2\bin\javaw.exe" path "c:\Program Files\JavaSoft\jre\1.2\bin"
if exist "c:\Program Files\JavaSoft\jre\1.3\bin\javaw.exe" path "c:\Program Files\JavaSoft\jre\1.3\bin"
if exist "c:\Program Files\JavaSoft\jre\1.3.1\bin\javaw.exe" path "c:\Program Files\JavaSoft\jre\1.3.1\bin"
if exist "c:\Program Files\JavaSoft\jre\1.3.2\bin\javaw.exe" path "c:\Program Files\JavaSoft\jre\1.3.2\bin"
if exist "c:\Program Files\JavaSoft\jre\1.4\bin\javaw.exe" path "c:\Program Files\JavaSoft\jre\1.4\bin"
if exist "c:\WINDOWS\javaw.exe" path "c:\WINDOWS";%PATH%
if exist "c:\WinNT\System32\javaw.exe" path "c:\WinNT\System32";%PATH%
path
java -Xmx512m -jar .\Unshake.jar source\*.*
exit
