<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    	Me.components = New System.ComponentModel.Container()
    	Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
    	Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    	Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
    	Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
    	Me.StartStopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.RecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.FullscreenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.PictureBox1 = New System.Windows.Forms.PictureBox()
    	Me.SnapshotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.ContextMenuStrip1.SuspendLayout
    	CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
    	Me.SuspendLayout
    	'
    	'ContextMenuStrip1
    	'
    	Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartStopToolStripMenuItem, Me.RecordToolStripMenuItem, Me.SnapshotToolStripMenuItem, Me.FullscreenToolStripMenuItem, Me.PreferencesToolStripMenuItem, Me.CloseToolStripMenuItem})
    	Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
    	Me.ContextMenuStrip1.Size = New System.Drawing.Size(177, 158)
    	'
    	'StartStopToolStripMenuItem
    	'
    	Me.StartStopToolStripMenuItem.Checked = true
    	Me.StartStopToolStripMenuItem.CheckOnClick = true
    	Me.StartStopToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
    	Me.StartStopToolStripMenuItem.Name = "StartStopToolStripMenuItem"
    	Me.StartStopToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
    	Me.StartStopToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
    	Me.StartStopToolStripMenuItem.Text = "Start/Stop"
    	'
    	'RecordToolStripMenuItem
    	'
    	Me.RecordToolStripMenuItem.Name = "RecordToolStripMenuItem"
    	Me.RecordToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
    	Me.RecordToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
    	Me.RecordToolStripMenuItem.Text = "Record"
    	'
    	'FullscreenToolStripMenuItem
    	'
    	Me.FullscreenToolStripMenuItem.CheckOnClick = true
    	Me.FullscreenToolStripMenuItem.Name = "FullscreenToolStripMenuItem"
    	Me.FullscreenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11
    	Me.FullscreenToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
    	Me.FullscreenToolStripMenuItem.Text = "Fullscreen"
    	'
    	'PreferencesToolStripMenuItem
    	'
    	Me.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem"
    	Me.PreferencesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P),System.Windows.Forms.Keys)
    	Me.PreferencesToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
    	Me.PreferencesToolStripMenuItem.Text = "Preferences"
    	'
    	'CloseToolStripMenuItem
    	'
    	Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
    	Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4),System.Windows.Forms.Keys)
    	Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
    	Me.CloseToolStripMenuItem.Text = "Close"
    	'
    	'PictureBox1
    	'
    	Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
    	    	    	Or System.Windows.Forms.AnchorStyles.Left)  _
    	    	    	Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
    	Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
    	Me.PictureBox1.Name = "PictureBox1"
    	Me.PictureBox1.Size = New System.Drawing.Size(320, 240)
    	Me.PictureBox1.TabIndex = 1
    	Me.PictureBox1.TabStop = false
    	'
    	'SnapshotToolStripMenuItem
    	'
    	Me.SnapshotToolStripMenuItem.Name = "SnapshotToolStripMenuItem"
    	Me.SnapshotToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
    	Me.SnapshotToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
    	Me.SnapshotToolStripMenuItem.Text = "Snapshot"
    	'
    	'Form1
    	'
    	Me.AccessibleDescription = ""
    	Me.AccessibleName = ""
    	Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    	Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    	Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    	Me.ClientSize = New System.Drawing.Size(320, 240)
    	Me.ContextMenuStrip = Me.ContextMenuStrip1
    	Me.Controls.Add(Me.PictureBox1)
    	Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    	Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
    	Me.MinimizeBox = false
    	Me.Name = "Form1"
    	Me.ShowInTaskbar = false
    	Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    	Me.Text = "CamDesk"
    	Me.TopMost = true
    	Me.ContextMenuStrip1.ResumeLayout(false)
    	CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
    	Me.ResumeLayout(false)
    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StartStopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents FullscreenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreferencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SnapshotToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
