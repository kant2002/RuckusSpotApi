for /f "tokens=2 delims==" %%I in ('wmic os get localdatetime /format:list') do set datetime=%%I
set datetime=%datetime:~0,8%-%datetime:~8,6%

cd %USERPROFILE%\Documents\RuckusSpotApi\src\Ruckus.Spot.Monitor
dnx run 192.168.1.18 super_admin@ruckuswireless.com 123123123 >"%USERPROFILE%\Documents\collect_%DATETIME%.txt"