Public Class Form1
    Dim random As New Random()
    Dim J1 As Integer = 0
    Dim J2 As Integer = 0
    Dim currentPlayer As Integer = 1
    Dim A As Integer

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Dim av As Integer = random.Next(1, 7)
        J1 += av
        If J1 > 72 Then J1 = 72
        J1 = comodines(J1) ' Llama a la función comodines para actualizar la posición
        Pocision(J1, Color.Red)
        MsgBox("Avanza " & av)
        MsgBox("Termino el turno del Jugador 1")

        If J1 >= 72 And J2 >= 72 Then
            MessageBox.Show("Empate")
            PictureBox2.Enabled = False
            PictureBox1.Enabled = False
        ElseIf J1 >= 72 Then
            MessageBox.Show("¡Jugador 1 gana!")
            PictureBox2.Enabled = False
            PictureBox1.Enabled = False
        End If
        PictureBox1.Enabled = False
        PictureBox2.Enabled = True
        TextBox1.Text = "Esta en la casilla " & J1.ToString()
        'Dim av As Integer = random.Next(1, 7)
        'J1 += av
        'If J1 > 72 Then J1 = 72
        'Pocision(J1, Color.Red)
        'MsgBox("Avanza " & av)
        'MsgBox("Termino el turno del Jugador 1")

        'If J1 >= 72 And J2 >= 72 Then
        '    MessageBox.Show("Empate")
        '    PictureBox2.Enabled = False
        '    PictureBox1.Enabled = False
        'ElseIf J1 >= 72 Then
        '    MessageBox.Show("¡Jugador 1 gana!")
        '    PictureBox2.Enabled = False
        '    PictureBox1.Enabled = False
        'End If
        'PictureBox1.Enabled = False
        'PictureBox2.Enabled = True
        'TextBox1.Text = "Esta en la casilla " & J1.ToString()
    End Sub
    Sub llenar()
        TableLayoutPanel1.ColumnCount = 10
        TableLayoutPanel1.RowCount = 7
        TableLayoutPanel1.ColumnStyles.Clear()
        TableLayoutPanel1.RowStyles.Clear()
        For i As Integer = 0 To 9
            TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 10))
        Next
        For i As Integer = 0 To 6
            TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.3))
        Next

        For i As Integer = 0 To 71
            Dim tab As New Label()
            tab.BorderStyle = BorderStyle.FixedSingle
            tab.Dock = DockStyle.Fill
            tab.TextAlign = ContentAlignment.MiddleCenter
            tab.Text = (i + 1).ToString()
            TableLayoutPanel1.Controls.Add(tab)
        Next
        ' Marcar las posiciones iniciales de los jugadores
        Pocision(J2, Color.Blue)
        Pocision(J1, Color.Red)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar()
        PictureBox2.Enabled = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
    End Sub

    Function comodines(pos As Integer)

        Dim nPos As Integer = pos

        Select Case pos
            Case 59
                nPos = 70
                MsgBox("Escalera: Avanza a la casilla 70")
            Case 22
                nPos = 3
                MsgBox("Serpiente: Regresa a la casilla 3")
            Case 61
                nPos = 72
                MsgBox("Escalera: Avanza a la casilla 72")
            Case 12
                nPos = 50
                MsgBox("Escalera: Avanza a la casilla 50")
            Case 19
                nPos = 1
                MsgBox("Serpiente: Regresa a la casilla 1")
            Case 33
                nPos = 21
                MsgBox("Serpiente: Regresa a la casilla 21")
            Case 71
                nPos = 1
                MsgBox("Serpiente: Regresa a la casilla 1")
        End Select

        Return nPos
    End Function
    Private Sub Pocision(pos As Integer, color As Color)
        pos = comodines(pos)

        Dim tabIndex As Integer = pos - 1
        For Each control As Control In TableLayoutPanel1.Controls
            control.BackColor = Color.White
        Next

        If tabIndex >= 0 AndAlso tabIndex < TableLayoutPanel1.Controls.Count Then
            If color = Color.Red Then
                TableLayoutPanel1.Controls(tabIndex).BackColor = Color.Red
            ElseIf color = Color.Blue Then
                TableLayoutPanel1.Controls(tabIndex).BackColor = Color.Blue
            End If
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim av As Integer = random.Next(1, 7)
        J2 += av
        If J2 > 72 Then J2 = 72
        J2 = comodines(J2) ' Llama a la función comodines para actualizar la posición
        Pocision(J2, Color.Blue)
        MsgBox("Avanza " & av)
        MsgBox("Termino el turno del Jugador 2")

        If J1 >= 72 And J2 >= 72 Then
            MessageBox.Show("Empate")
            PictureBox2.Enabled = False
            PictureBox1.Enabled = False
        ElseIf J2 >= 72 Then
            MessageBox.Show("¡Jugador 2 gana!")
            PictureBox2.Enabled = False
            PictureBox1.Enabled = False
        End If
        PictureBox2.Enabled = False
        PictureBox1.Enabled = True
        TextBox2.Text = "Esta en la casilla " & J2.ToString()
    End Sub


End Class
