Imports System.IO

Public Class Form2
    Inherits System.Windows.Forms.Form

    Private sizew As Integer
    Private sizey As Integer
    Private opac As Double

    Private Const CS_DROPSHADOW As Integer = 131072
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim Shadow As CreateParams = MyBase.CreateParams
            Shadow.ClassStyle = Shadow.ClassStyle Or CS_DROPSHADOW
            Return Shadow
        End Get
    End Property

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True

        StandardDef.Cursor = Cursors.Hand
        HighDef.Cursor = Cursors.Hand

        OpacInt.Text = "1.0"
        CamWidth.Text = "320"
        CamHeight.Text = "240"
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Form1.PreferencesToolStripMenuItem.Checked = False
            Me.Visible = False
            e.Cancel = True
        End If
    End Sub

    Private Sub StandardDef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandardDef.Click
        Form1.Size = New System.Drawing.Size(320, 240)
        Form1.CamResize()

        CamWidth.Text = "320"
        CamHeight.Text = "240"
    End Sub

    Private Sub HighDef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HighDef.Click
        Form1.Size = New System.Drawing.Size(427, 240)
        Form1.CamResize()

        CamWidth.Text = "427"
        CamHeight.Text = "240"
    End Sub

    Private Sub CloseApp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseApp.Click
        If Form1.StartStopToolStripMenuItem.Checked Then
            Form1.stopPreviewCamera()
            Form1.RecordToolStripMenuItem.Enabled = False
            Form1.Close()
            Me.Close()
        End If

        If Form1.StartStopToolStripMenuItem.Checked = False Then
            Form1.Close()
            Me.Close()
        End If
    End Sub

    Private Sub SSCam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSCam.CheckedChanged
        If SSCam.Checked Then
            Form1.previewCamera(Form1)
            Form1.StartStopToolStripMenuItem.Checked = True
            Form1.RecordToolStripMenuItem.Enabled = True
            Form1.SnapshotToolStripMenuItem.Enabled = True
            Record.Enabled = True
        Else
            Form1.stopPreviewCamera()
            Form1.StartStopToolStripMenuItem.Checked = False
            Form1.RecordToolStripMenuItem.Enabled = False
            Form1.RecordToolStripMenuItem.Checked = False
            Form1.SnapshotToolStripMenuItem.Enabled = False
            Form1.Timer2.Stop()
            Record.Enabled = False
        End If
    End Sub

    Private Sub Pinning_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pinning.CheckedChanged
        If Pinning.Checked = True Then
            Form1.TopMost = True
        Else
            Form1.TopMost = False
        End If
    End Sub

    Private Sub ChangeOpac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeOpac.Click
        opac = OpacInt.Text
        Form1.Opacity = opac
    End Sub

    Private Sub OpacInt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OpacInt.KeyDown
        If e.KeyCode = Keys.Enter Then
            opac = OpacInt.Text
            Form1.Opacity = opac
        End If
    End Sub

    Private Sub ChangeDim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeDim.Click
        sizew = CamWidth.Text
        sizey = CamHeight.Text
        Form1.Size = New System.Drawing.Size(sizew, sizey)
        Form1.CamResize()
    End Sub

    Private Sub CamWidth_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CamWidth.KeyDown
        If e.KeyCode = Keys.Enter Then
            sizew = CamWidth.Text
            sizey = CamHeight.Text
            Form1.Size = New System.Drawing.Size(sizew, sizey)
            Form1.CamResize()
        End If
    End Sub

    Private Sub CamHeight_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CamHeight.KeyDown
        If e.KeyCode = Keys.Enter Then
            sizew = CamWidth.Text
            sizey = CamHeight.Text
            Form1.Size = New System.Drawing.Size(sizew, sizey)
            Form1.CamResize()
        End If
    End Sub

    Private Sub Record_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Record.CheckedChanged
        If Not Directory.Exists("photos-taken") Then
            Directory.CreateDirectory("photos-taken")
        End If

        If Record.Checked Then
            Form1.RecordToolStripMenuItem.Checked = True
            Form1.SnapshotToolStripMenuItem.Enabled = False
            Form1.Timer2.Interval = Me.RecordingMS.Text
            Form1.Timer2.Start()
        Else
            Form1.RecordToolStripMenuItem.Checked = False
            Form1.RecordToolStripMenuItem.Enabled = False
            Form1.SnapshotToolStripMenuItem.Enabled = True
            Form1.Timer2.Stop()
            Form1.stopPreviewCamera()
            Form1.StartStopToolStripMenuItem.Checked = False
            SSCam.Checked = False
            Record.Enabled = False
        End If
    End Sub

    Private Sub ChromaKeyCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChromaKeyCheck.CheckedChanged
        If ChromaKeyCheck.Checked Then
            ChromaKeyColor.Enabled = True
            Form1.BackColor = ChromaKey.Color
            Form1.TransparencyKey = ChromaKey.Color
        Else
            ChromaKeyColor.Enabled = False
            Form1.BackColor = Color.Empty
            Form1.TransparencyKey = Color.Empty
        End If
    End Sub

    Private Sub ChromaKeyColor_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ChromaKeyColor.LinkClicked
        If ChromaKey.ShowDialog = Windows.Forms.DialogResult.OK Then
            ChromaKeyColor.LinkColor = ChromaKey.Color
            Form1.BackColor = ChromaKey.Color
            Form1.TransparencyKey = ChromaKey.Color
        End If
    End Sub
End Class