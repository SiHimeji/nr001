@echo off

cd C:\noritz\NRApp001/dl

bitsadmin /TRANSFER FILEDOWNLOAD http://172.31.3.166/dl/NRApp001.zip C:\noritz\NRApp001\dl\NRApp001.zip

C:\noritz\NRApp001\7za e NRApp001.zip

copy /Y *.xlsx C:\noritz\NRApp001\excel\
del *.xlsx
del *.zip

copy /Y *.* C:\noritz\NRApp001\
del *.exe

echo.
echo ダウンロードが完了しました。
rem pause
exit
