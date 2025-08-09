@echo off
cd c:\noritz\NRApp001
del /Y c:\noritz\NRApp001\list.txt

bitsadmin /TRANSFER FILEDOWNLOAD  list.txt c:\noritz\NRApp001\list.txt

pushd %~dp0
for /f %%i in (list.txt) do (
    bitsadmin /TRANSFER FILEDOWNLOAD %%i %~dp0\%%~nxi
)

copy /Y c:\noritz\NRApp001\*.xlsx c:\noritz\NRApp001\excel
del  /Y c:\noritz\NRApp001\*.xlsx

echo.
echo ダウンロードが完了しました。

exit
