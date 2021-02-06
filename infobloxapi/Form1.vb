Imports RestSharp
Imports RestSharp.Authenticators
Imports System.IO
Imports System.Text
Public Class Form1
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Client As New RestSharp.RestClient("https://" & TextBox1.Text) With {.Authenticator = New HttpBasicAuthenticator(TextBox2.Text, TextBox3.Text)}
        Dim Request As New RestSharp.RestRequest("/wapi/v2.10.3/network", RestSharp.Method.POST)
        Request.RequestFormat = RestSharp.DataFormat.Json
        Dim IP As String
        Dim A As Integer = 10
        Try
            For B = 0 To 255
                For C = 0 To 255
                    For D = 1 To 254
                        IP = A & "." & B & "." & C & "." & D
                        Await Task.Run(Sub()
                                           Request.Parameters.Clear()
                                           Request.AddParameter("network", IP & "/32")
                                           Client.Execute(Request)
                                       End Sub)
                    Next
                Next
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim sb As New System.Text.StringBuilder()
        Dim IP As String
        Dim A As Integer = 10


        sb.Append("HEADER-NETWORK,ADDRESS*,NETMASK*" & vbCrLf)

        For B = 0 To 255
                For C = 0 To 255
                    For D = 1 To 254
                    IP = "NETWORK," & A & "." & B & "." & C & "." & D & ",255.255.255.255" & vbCrLf

                    sb.Append(IP)

                Next
                Next
            Next



        Dim sw As New System.IO.StreamWriter("C:\test1.txt", False)

        sw.Write(sb.ToString)
        sw.Close()



    End Sub
End Class
