

Public Class Form1
    Dim col As New Collection
    Dim selectCol As New Collection
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles tv.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        tv.Text = ""
        Dim item
        For Each item In col

            Controls.Remove(item)

        Next
        For Each item In selectCol

            Controls.Remove(item)

        Next
        selectNum = 0
        position = 0

        col.Clear()
        selectCol.Clear()


    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim str = tv.Text


        If String.IsNullOrEmpty(str) Then
            MsgBox("请输入数字或名称")
            Return


        End If
        Dim strs() As String
        If str.Contains(",") Then
            strs = Split(str, ",")

        ElseIf str.Contains("，") Then
            strs = Split(str, "，")
        
        End If

        

        Dim Temp As String
        Dim i As Integer
        Dim m As Integer = strs.Length
        For Each Temp In strs

            If Not String.IsNullOrEmpty(Temp) Then
                Dim newbtn As New Label()
                newbtn.Name = i.ToString
                newbtn.Text = (i + 1).ToString & "." & Temp
                newbtn.Size = New Size(150, 30)
                newbtn.Location = New Size(280, 50 + 40 * i)
                newbtn.AutoSize = True
                newbtn.Font = New Font("宋体", 18)

                newbtn.Anchor = AnchorStyles.Left Or AnchorStyles.Top

                Controls.Add(newbtn)
                col.Add(newbtn)

                i += 1


            End If



        Next



    End Sub



    Dim size As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If col.Count = 0 Then
            MsgBox("请先添加名称")
            Return
        End If
        position = 0

        size = Rnd() * 3 * col.Count + col.Count

        If selectNum = 0 And col.Count > 5 Then
            Dim some As Integer = Rnd() * 4
            If some = 0 Then
                size = 4 * col.Count
            End If
        End If

        Debug.Print("SIZE" & size.ToString)

        Timer1.Enabled = True









    End Sub
    Dim position As Integer = 0
    Dim selectNum As Integer = 0

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick









        Dim item As Label
        For Each item In col

            item.BackColor = Color.Transparent

        Next

        Dim test As Integer = position Mod col.Count

        Debug.Print(position.ToString)
        Debug.Print(test.ToString)


        item = col(test + 1)


        item.BackColor = Color.Red

        position += 1
        If position = size Then

            item.Location = New Size(500, 50 + 40 * selectNum)

            col.Remove(test + 1)
            selectCol.Add(item)



            selectNum += 1
            Timer1.Enabled = False
        End If



    End Sub





 
End Class
