Imports Microsoft.VisualBasic



Public Class Class1
   

    '定义 FormOldWidth, FormOldHeight 为全局变量，这样其他模块才能调用它  
    Public FormOldWidth, FormOldHeight

    '在调用ResizeForm前先调用本函数  
    Public Sub ResizeInit(FormName As Form)

        'Control是一个对象，表示所有 Visual Basic 内部控件的类名。  
        '可以将一个变量标为 Control 对象，象引把控件放到窗体上的一样来引用它。例如：  
        'Dim C As Control  
        'Set C = Command1  
        Dim Obj As Control
        FormOldWidth = FormName.ScaleWidth
        FormOldHeight = FormName.ScaleHeight
        On Error Resume Next

        'Each是一个关键字，作用是针对一个数组或集合中的每个元素，重复执行一组语句。  
        '语法  
        'For Each element In Group  
        For Each Obj In FormName
            'Tag返回或设置一个表达式用来存储程序中需要的额外数据。  
            Obj.Tag = Obj.Left & " " & Obj.Top & " " & Obj.Width & " " & Obj.Height & " "
        Next Obj
        On Error GoTo 0


    End Sub



    '按比例改变表单内各元件的大小，  
    '在调用ReSizeForm前先调用ReSizeInit函数  
    Public Sub ResizeForm(FormName As Form)
        Dim Pos(4) As Double
        Dim i As Long, TempPos As Long, StartPos As Long
        Dim Obj As Control
        Dim ScaleX As Double, ScaleY As Double

        '保存窗体宽度缩放比例  
        ScaleX = FormName.ScaleWidth / FormOldWidth
        '保存窗体高度缩放比例  
        ScaleY = FormName.ScaleHeight / FormOldHeight

        On Error Resume Next

        For Each Obj In FormName
            StartPos = 1

            '读取控件的原始位置与大小  
            For i = 0 To 4
                'InStr函数，返回 Variant (Long)，指定一字符串在另一字符串中最先出现的位置。语法:InStr([start, ]string1, string2[, compare])  
                TempPos = InStr(StartPos, Obj.Tag, " ", vbTextCompare)
                If TempPos > 0 Then
                    'Mid函数，返回Variant (String)，其中包含字符串中指定数量的字符。语法：Mid(string, start[, length])  
                    Pos(i) = Mid(Obj.Tag, StartPos, TempPos - StartPos)
                    StartPos = TempPos + 1
                Else
                    Pos(i) = 0
                End If

                '根据控件的原始位置及窗体改变大小的比例对控件重新定位与改变大小  
                'Move方法，用以移动 MDIForm、Form 或控件。语法:object.Move Left, Top, Width, Height  
                Obj.Move(Pos(0) * ScaleX, Pos(1) * ScaleY, Pos(2) * ScaleX, Pos(3) * ScaleY)

            Next i
        Next Obj
        On Error GoTo 0



    End Sub
End Class
