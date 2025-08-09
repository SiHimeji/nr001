'Imports System.Text
'Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
'Imports System.Reflection
'Imports System.Text.RegularExpressions
'Imports System.IO

Module ModuleExcel
    '������������������������������������������������
    '������
    '�@EXCEL �o��
    '
    Public Sub excelOutDataGredV2(dgv As DataGridView)

        ' EXCEL�֘A�I�u�W�F�N�g�̒�`
        Dim objExcel As Excel.Application = New Excel.Application
        Dim objWorkBook As Excel.Workbook = objExcel.Workbooks.Add
        Dim objSheet As Excel.Worksheet = Nothing
        '���ݓ������擾
        'Dim timestanpText As String = Format(Now, "yyyyMMddHHmmss")
        '�ۑ��f�B���N�g���ƃt�@�C������ݒ�
        'Dim saveFileName As String
        'saveFileName = objExcel.GetSaveAsFilename(
        'InitialFilename:=EXCEL_SAVE_PATH & "�t�@�C����_" & timestanpText,
        'FileFilter:="Excel File (*.xlsx),*.xlsx")

        '�ۑ���f�B���N�g���̐ݒ肪�L���̏ꍇ�̓u�b�N��ۑ�
        'If saveFileName <> "False" Then
        'objWorkBook.SaveAs(Filename:=saveFileName)
        'End If

        '�V�[�g�̍ő�\���񍀖ڐ�
        Dim columnMaxNum As Integer = dgv.Columns.Count - 1
        '�V�[�g�̍ő�\���s���ڐ�
        Dim rowMaxNum As Integer = dgv.Rows.Count - 1

        '���ږ��i�[�p���X�g��錾
        Dim columnList As New List(Of String)
        '���ږ����擾
        For i = 0 To (columnMaxNum)
            columnList.Add(dgv.Columns(i).HeaderCell.Value)
        Next

        '�Z���̃f�[�^�擾�p�񎟌��z���錾
        Dim v As String(,) = New String(rowMaxNum, columnMaxNum) {}

        For row As Integer = 0 To rowMaxNum
            For col As Integer = 0 To columnMaxNum
                If dgv.Rows(row).Cells(col).Value Is Nothing = False Then
                    ' �Z���ɒl�������Ă���ꍇ�A�񎟌��z��Ɋi�[
                    v(row, col) = dgv.Rows(row).Cells(col).Value.ToString()
                End If
            Next
        Next

        ' EXCEL�ɍ��ږ���]��
        For i = 1 To dgv.Columns.Count
            ' �V�[�g�̈�s�ڂɍ��ڂ�}��
            objWorkBook.Sheets(1).Cells(1, i) = columnList(i - 1)

            ' �r����ݒ�
            objWorkBook.Sheets(1).Cells(1, i).Borders.LineStyle = True
            ' ���ڂ̕\���s�ɔw�i�F��ݒ�
            objWorkBook.Sheets(1).Cells(1, i).Interior.Color = RGB(140, 140, 140)
            ' �����̃t�H���g��ݒ�
            objWorkBook.Sheets(1).Cells(1, i).Font.Color = RGB(255, 255, 255)
            objWorkBook.Sheets(1).Cells(1, i).Font.Bold = True
        Next

        ' EXCEL�Ƀf�[�^��͈͎w��œ]��
        Dim abc1 As Integer
        Dim abc2 As Integer
        Dim coln As String

        If columnMaxNum > 26 Then
            abc1 = Int(columnMaxNum / 26) - 1
            abc2 = (columnMaxNum Mod 26)
            coln = Chr(Asc("A") + abc1) & Chr(Asc("A") + abc2)
        Else
            abc1 = (columnMaxNum Mod 26)
            coln = Chr(Asc("A") + abc1)
        End If

        ' Dim data As String = "A2:" & Chr(Asc("A") + columnMaxNum) & dgv.Rows.Count + 1 	'��A-Z�܂őΉ�
        Dim data As String = "A2:" & coln & dgv.Rows.Count + 1              '��A�E�E�܂Ŋg��
        objWorkBook.Sheets(1).Range(data) = v
        ' �f�[�^�̕\���͈͂Ɍr����ݒ�
        objWorkBook.Sheets(1).Range(data).Borders.LineStyle = True

        'Dim data1 As String = "A:" & coln
        objWorkBook.Sheets(1).Columns("A:" & coln).AutoFit
        ' �G�N�Z���\��
        objExcel.Visible = True

        ' EXCEL���
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        objWorkBook = Nothing
        objExcel = Nothing

    End Sub
    '
    ' NextB�pEXCEL�o��
    '
    Public Sub ToExcelNext(dt As DataTable)
        ' EXCEL�֘A�I�u�W�F�N�g�̒�`
        Dim objExcel As Excel.Application = New Excel.Application
        Dim objWorkBook As Excel.Workbook = objExcel.Workbooks.Add
        Dim objSheet As Excel.Worksheet = Nothing
        Dim i As Integer

        '�V�[�g�̍ő�\���񍀖ڐ�
        Dim columnMaxNum As Integer = dt.Columns.Count - 1
        '�V�[�g�̍ő�\���s���ڐ�
        Dim rowMaxNum As Integer = dt.Rows.Count - 1
        Dim heaf1() As String = {"cst_cmp_cd", "rqst_dlv_dt", "sls_typ", "xpns_cd", "assort_typ", "cst_cd", "scnd_dler_cd", "thrd_dler_cd", "cst_scst_cd", "scst_cd", "scst_nm", "zip_cd", "scst_addr1", "scst_addr2", "cst_po_no", "ord_psn_nm", "ord_psn_nm1", "rmrks", "intr_rmrks", "prod_fare_typ", "fare_typ", "fare_subno", "fax_needl_typ", "cst_itm_cd", "itm_cd", "ord_qty", "dsnt_upri", "cst_dsnt_subno", "d_rqst_dlv_dt", "ja_inst_no", "ja_upri", "zone", "urgent_cntct_tel", "urgent_cntct_nm", "chrg_dpt_cd", "ac_cd", "bf_no"}
        Dim heaf2() As String = {"���Ӑ��Ƃb�c", "������]��", "����敪", "�o��Ǘ��敪", "�o�׋敪", "���Ӑ�b�c", "�Q���X�b�c", "�R���X�b�c", "����摗���b�c", "�����b�c", "����於", "�X�֔ԍ�", "�����Z���P", "�����Z���Q", "���Ӑ攭���m�n", "���Ӑ攭����", "���Ӑ攭���ҁi�J�i�j", "���l", "���l�Q", "���i�^���敪", "�^���敪", "�^���}��", "�e�`�w�z�M�s�v�敪", "�����i�b�c", "�i�b�c", "�󒍐�", "�w��P��", "���Ӑ�w��}��", "���ד�����]��", "�_���w�}�m�n", "�_�����i", "�]�[��", "�ً}�A����s�d�k", "�ً}�A���於", "���S����b�c", "����Ȗڂb�c", "�����\�Z�m�n"}


        '�Z���̃f�[�^�擾�p�񎟌��z���錾
        Dim v As String(,) = New String(rowMaxNum, columnMaxNum) {}

        For row As Integer = 0 To rowMaxNum
            For col As Integer = 0 To columnMaxNum
                'If dt.Rows(row).Item(col).Value Is Nothing = False Then
                ' �Z���ɒl�������Ă���ꍇ�A�񎟌��z��Ɋi�[
                v(row, col) = dt.Rows(row).Item(col).ToString()
                'End If
            Next
        Next

        ' EXCEL�Ƀf�[�^��͈͎w��œ]��
        Dim abc1 As Integer
        Dim abc2 As Integer
        Dim coln As String

        If columnMaxNum > 26 Then
            abc1 = Int(columnMaxNum / 26) - 1
            abc2 = (columnMaxNum Mod 26)
            coln = Chr(Asc("A") + abc1) & Chr(Asc("A") + abc2)
        Else
            abc1 = (columnMaxNum Mod 26)
            coln = Chr(Asc("A") + abc1)
        End If

        i = 1
        For Each s In heaf1
            objWorkBook.Sheets(1).Cells(1, i) = s
            i = i + 1
        Next
        i = 1
        For Each s In heaf2
            objWorkBook.Sheets(1).Cells(2, i) = s
            i = i + 1
        Next

        Dim data As String = "A3:" & coln & dt.Rows.Count + 2              '��A�E�E�܂Ŋg��
        objWorkBook.Sheets(1).Range(data) = v


        '�f�[�^�̕\���͈͂Ɍr����ݒ�
        'objWorkBook.Sheets(1).Range(data).Borders.LineStyle = True

        'Dim data1 As String = "A:" & coln
        objWorkBook.Sheets(1).Columns("A:" & coln).AutoFit


        ' �G�N�Z���\��
        objExcel.Visible = True

        ' EXCEL���
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        objWorkBook = Nothing
        objExcel = Nothing
    End Sub



End Module
