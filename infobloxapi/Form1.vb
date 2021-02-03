Imports RestSharp
Imports RestSharp.Authenticators

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
                    For D = 97 To 254
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
End Class
