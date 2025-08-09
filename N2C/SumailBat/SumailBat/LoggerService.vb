Imports NLog
Imports NLog.Targets
Imports NLog.Config
Imports System.IO
'======
' Log
Public Class LoggerService

    Public Sub LoggerService()

        Dim Config As LoggingConfiguration = New LoggingConfiguration()

        If Not Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\LOG") Then
            Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "\\LOG")
        End If








    End Sub












End Class
