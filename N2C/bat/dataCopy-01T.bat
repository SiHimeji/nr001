rem �t�@�C������ϐ��Ɋi�[����
set file_name=N2OK001T.CSV

rem ���݂̓��t�y�ь��ݎ�����ϐ��Ɋi�[����
set cur_datetime=%DATE:~0,4%%DATE:~5,2%%DATE:~8,2%%TIME:~0,2%%TIME:~3,2%%TIME:~6,2%

rem ���ݎ����ǉ������t�@�C������ϐ��Ɋi�[����
set new_filename=% folder%%cur_datetime%_%file_name%


d:
cd D:\work\Densou

D:\work\Densou\APP\TenkenKekkaT.exe D:\work\Densou\N2OK001T.CSV

ren %file_name% %new_filename%

rem pause
