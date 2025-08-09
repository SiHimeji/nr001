rem ƒtƒ@ƒCƒ‹–¼‚ğ•Ï”‚ÉŠi”[‚·‚é
set file_name=test.txt

rem Œ»İ‚Ì“ú•t‹y‚ÑŒ»İ‚ğ•Ï”‚ÉŠi”[‚·‚é
set cur_datetime=%DATE:~0,4%%DATE:~5,2%%DATE:~8,2%%TIME:~0,2%%TIME:~3,2%%TIME:~6,2%

rem Œ»İ’Ç‰Á‚µ‚½ƒtƒ@ƒCƒ‹–¼‚ğ•Ï”‚ÉŠi”[‚·‚é
set new_filename=% folder%%cur_datetime%_%file_name%

ren %file_name% %new_filename%

pause
