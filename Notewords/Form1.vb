Public Class Form1
    Dim newFile As Boolean

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("NoteWords by Sparksammy/Sam_Lord.")
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.Filter = "Text files (*.txt)|*.txt|Rich Text files (*.rtf)|*.rtf|HTML files (*.html)|*.html|Javascript files (*.js)|*.js|CSS files (*.css)|*.css|Batch files (*.bat)|*.bat|VBScript files (*.vbs)|*.vbs|All files (*.*)|*.*"
        OpenFileDialog1.Title = "Open"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim fileOpen As String
            fileOpen = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            TextBox1.Text = fileOpen
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog1.Filter = "Text files (*.txt)|*.txt|Rich Text files (*.rtf)|*.rtf|HTML files (*.html)|*.html|Javascript files (*.js)|*.js|CSS files (*.css)|*.css|Batch files (*.bat)|*.bat|VBScript files (*.vbs)|*.vbs|All files (*.*)|*.*"
        SaveFileDialog1.CheckPathExists = True
        SaveFileDialog1.Title = "Save"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
            newFile = False
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If newFile = False Then
            If SaveFileDialog1.FileName IsNot "" Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
            End If
        Else
            MsgBox("This is a new file! Use 'Save as' instead!")
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        newFile = True
        TextBox1.Text = ""
    End Sub

    Private Sub WordWrapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WordWrapToolStripMenuItem.Click
        If TextBox1.WordWrap = True Then
            TextBox1.WordWrap = False
        Else
            TextBox1.WordWrap = True
        End If
    End Sub


    Private Sub FontStylingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontStylingToolStripMenuItem.Click
        FontDialog1.ShowApply = False
        If FontDialog1.ShowDialog() = DialogResult.OK Then
            TextBox1.Font = FontDialog1.Font
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        newFile = True
    End Sub
End Class
