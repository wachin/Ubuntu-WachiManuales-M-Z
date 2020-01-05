<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Transparent = New System.Windows.Forms.Label()
        Me.Dimensions = New System.Windows.Forms.Label()
        Me.CloseApp = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RecordLabel = New System.Windows.Forms.Label()
        Me.milliseclabel = New System.Windows.Forms.Label()
        Me.HighDef = New System.Windows.Forms.Button()
        Me.StandardDef = New System.Windows.Forms.Button()
        Me.RecordingMS = New System.Windows.Forms.TextBox()
        Me.ChangeDim = New System.Windows.Forms.Label()
        Me.CamHeight = New System.Windows.Forms.TextBox()
        Me.CamWidth = New System.Windows.Forms.TextBox()
        Me.ChangeOpac = New System.Windows.Forms.Label()
        Me.OpacInt = New System.Windows.Forms.TextBox()
        Me.Pinning = New System.Windows.Forms.CheckBox()
        Me.Record = New System.Windows.Forms.CheckBox()
        Me.SSCam = New System.Windows.Forms.CheckBox()
        Me.ChromaKeyCheck = New System.Windows.Forms.CheckBox()
        Me.ChromaKeyColor = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ChromaKey = New System.Windows.Forms.ColorDialog()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(113, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = ","
        '
        'Transparent
        '
        Me.Transparent.AutoSize = True
        Me.Transparent.Location = New System.Drawing.Point(5, 71)
        Me.Transparent.Name = "Transparent"
        Me.Transparent.Size = New System.Drawing.Size(46, 13)
        Me.Transparent.TabIndex = 13
        Me.Transparent.Text = "Opacity:"
        '
        'Dimensions
        '
        Me.Dimensions.AutoSize = True
        Me.Dimensions.Location = New System.Drawing.Point(5, 97)
        Me.Dimensions.Name = "Dimensions"
        Me.Dimensions.Size = New System.Drawing.Size(64, 13)
        Me.Dimensions.TabIndex = 14
        Me.Dimensions.Text = "Dimensions:"
        '
        'CloseApp
        '
        Me.CloseApp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseApp.AutoSize = True
        Me.CloseApp.BackColor = System.Drawing.Color.Transparent
        Me.CloseApp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseApp.Font = New System.Drawing.Font("Webdings", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.CloseApp.ForeColor = System.Drawing.Color.Black
        Me.CloseApp.Location = New System.Drawing.Point(197, 3)
        Me.CloseApp.Name = "CloseApp"
        Me.CloseApp.Size = New System.Drawing.Size(36, 26)
        Me.CloseApp.TabIndex = 15
        Me.CloseApp.Text = "r"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(5, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(223, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "____________________________________"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(8, 44)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(99, 17)
        Me.CheckBox1.TabIndex = 19
        Me.CheckBox1.Text = "Start/Stop Cam"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(5, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(223, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "____________________________________"
        '
        'RecordLabel
        '
        Me.RecordLabel.AutoSize = True
        Me.RecordLabel.Location = New System.Drawing.Point(5, 134)
        Me.RecordLabel.Name = "RecordLabel"
        Me.RecordLabel.Size = New System.Drawing.Size(128, 13)
        Me.RecordLabel.TabIndex = 26
        Me.RecordLabel.Text = "Recording Time Intervals:"
        '
        'milliseclabel
        '
        Me.milliseclabel.AutoSize = True
        Me.milliseclabel.Location = New System.Drawing.Point(176, 134)
        Me.milliseclabel.Name = "milliseclabel"
        Me.milliseclabel.Size = New System.Drawing.Size(20, 13)
        Me.milliseclabel.TabIndex = 28
        Me.milliseclabel.Text = "ms"
        '
        'HighDef
        '
        Me.HighDef.BackColor = System.Drawing.Color.White
        Me.HighDef.FlatAppearance.BorderSize = 0
        Me.HighDef.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HighDef.Font = New System.Drawing.Font("Corbel", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HighDef.Location = New System.Drawing.Point(81, 5)
        Me.HighDef.Name = "HighDef"
        Me.HighDef.Size = New System.Drawing.Size(97, 23)
        Me.HighDef.TabIndex = 2
        Me.HighDef.Text = "High Definition"
        Me.HighDef.UseVisualStyleBackColor = False
        '
        'StandardDef
        '
        Me.StandardDef.BackColor = System.Drawing.Color.White
        Me.StandardDef.FlatAppearance.BorderSize = 0
        Me.StandardDef.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.StandardDef.Font = New System.Drawing.Font("Corbel", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StandardDef.Location = New System.Drawing.Point(7, 5)
        Me.StandardDef.Name = "StandardDef"
        Me.StandardDef.Size = New System.Drawing.Size(66, 23)
        Me.StandardDef.TabIndex = 1
        Me.StandardDef.Text = "Standard"
        Me.StandardDef.UseVisualStyleBackColor = False
        '
        'RecordingMS
        '
        Me.RecordingMS.Location = New System.Drawing.Point(134, 131)
        Me.RecordingMS.Name = "RecordingMS"
        Me.RecordingMS.Size = New System.Drawing.Size(43, 20)
        Me.RecordingMS.TabIndex = 9
        Me.RecordingMS.Text = "3000"
        '
        'ChangeDim
        '
        Me.ChangeDim.AutoSize = True
        Me.ChangeDim.BackColor = System.Drawing.Color.Transparent
        Me.ChangeDim.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChangeDim.Font = New System.Drawing.Font("Webdings", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.ChangeDim.ForeColor = System.Drawing.Color.Black
        Me.ChangeDim.Location = New System.Drawing.Point(165, 90)
        Me.ChangeDim.Name = "ChangeDim"
        Me.ChangeDim.Size = New System.Drawing.Size(36, 26)
        Me.ChangeDim.TabIndex = 10
        Me.ChangeDim.Text = "a"
        '
        'CamHeight
        '
        Me.CamHeight.Location = New System.Drawing.Point(122, 93)
        Me.CamHeight.Name = "CamHeight"
        Me.CamHeight.Size = New System.Drawing.Size(43, 20)
        Me.CamHeight.TabIndex = 8
        '
        'CamWidth
        '
        Me.CamWidth.Location = New System.Drawing.Point(70, 93)
        Me.CamWidth.Name = "CamWidth"
        Me.CamWidth.Size = New System.Drawing.Size(43, 20)
        Me.CamWidth.TabIndex = 7
        '
        'ChangeOpac
        '
        Me.ChangeOpac.AutoSize = True
        Me.ChangeOpac.BackColor = System.Drawing.Color.Transparent
        Me.ChangeOpac.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChangeOpac.Font = New System.Drawing.Font("Webdings", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.ChangeOpac.ForeColor = System.Drawing.Color.Black
        Me.ChangeOpac.Location = New System.Drawing.Point(95, 65)
        Me.ChangeOpac.Name = "ChangeOpac"
        Me.ChangeOpac.Size = New System.Drawing.Size(36, 26)
        Me.ChangeOpac.TabIndex = 12
        Me.ChangeOpac.Text = "a"
        '
        'OpacInt
        '
        Me.OpacInt.Location = New System.Drawing.Point(52, 68)
        Me.OpacInt.Name = "OpacInt"
        Me.OpacInt.Size = New System.Drawing.Size(43, 20)
        Me.OpacInt.TabIndex = 6
        '
        'Pinning
        '
        Me.Pinning.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pinning.AutoSize = True
        Me.Pinning.Checked = True
        Me.Pinning.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Pinning.Location = New System.Drawing.Point(190, 44)
        Me.Pinning.Name = "Pinning"
        Me.Pinning.Size = New System.Drawing.Size(41, 17)
        Me.Pinning.TabIndex = 5
        Me.Pinning.Text = "Pin"
        Me.Pinning.UseVisualStyleBackColor = True
        '
        'Record
        '
        Me.Record.AutoSize = True
        Me.Record.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Record.Location = New System.Drawing.Point(117, 44)
        Me.Record.Name = "Record"
        Me.Record.Size = New System.Drawing.Size(61, 17)
        Me.Record.TabIndex = 4
        Me.Record.Text = "Record"
        Me.Record.UseVisualStyleBackColor = True
        '
        'SSCam
        '
        Me.SSCam.AutoSize = True
        Me.SSCam.Checked = True
        Me.SSCam.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SSCam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSCam.Location = New System.Drawing.Point(8, 44)
        Me.SSCam.Name = "SSCam"
        Me.SSCam.Size = New System.Drawing.Size(99, 17)
        Me.SSCam.TabIndex = 3
        Me.SSCam.Text = "Start/Stop Cam"
        Me.SSCam.UseVisualStyleBackColor = True
        '
        'ChromaKeyCheck
        '
        Me.ChromaKeyCheck.AutoSize = True
        Me.ChromaKeyCheck.Location = New System.Drawing.Point(7, 168)
        Me.ChromaKeyCheck.Name = "ChromaKeyCheck"
        Me.ChromaKeyCheck.Size = New System.Drawing.Size(80, 17)
        Me.ChromaKeyCheck.TabIndex = 10
        Me.ChromaKeyCheck.Text = "ChromaKey"
        Me.ChromaKeyCheck.UseVisualStyleBackColor = True
        '
        'ChromaKeyColor
        '
        Me.ChromaKeyColor.ActiveLinkColor = System.Drawing.Color.DarkTurquoise
        Me.ChromaKeyColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChromaKeyColor.AutoSize = True
        Me.ChromaKeyColor.Enabled = False
        Me.ChromaKeyColor.LinkColor = System.Drawing.Color.Black
        Me.ChromaKeyColor.Location = New System.Drawing.Point(158, 169)
        Me.ChromaKeyColor.Name = "ChromaKeyColor"
        Me.ChromaKeyColor.Size = New System.Drawing.Size(70, 13)
        Me.ChromaKeyColor.TabIndex = 11
        Me.ChromaKeyColor.TabStop = True
        Me.ChromaKeyColor.Text = "Choose Color"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(5, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(223, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "____________________________________"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(232, 194)
        Me.Controls.Add(Me.ChromaKeyColor)
        Me.Controls.Add(Me.ChromaKeyCheck)
        Me.Controls.Add(Me.Record)
        Me.Controls.Add(Me.RecordingMS)
        Me.Controls.Add(Me.RecordLabel)
        Me.Controls.Add(Me.HighDef)
        Me.Controls.Add(Me.StandardDef)
        Me.Controls.Add(Me.Pinning)
        Me.Controls.Add(Me.SSCam)
        Me.Controls.Add(Me.CloseApp)
        Me.Controls.Add(Me.Dimensions)
        Me.Controls.Add(Me.Transparent)
        Me.Controls.Add(Me.ChangeOpac)
        Me.Controls.Add(Me.CamHeight)
        Me.Controls.Add(Me.ChangeDim)
        Me.Controls.Add(Me.CamWidth)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OpacInt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.milliseclabel)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.ShowInTaskbar = False
        Me.Text = "Preferences"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Transparent As System.Windows.Forms.Label
    Friend WithEvents Dimensions As System.Windows.Forms.Label
    Friend WithEvents CloseApp As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RecordLabel As System.Windows.Forms.Label
    Friend WithEvents milliseclabel As System.Windows.Forms.Label
    Friend WithEvents HighDef As System.Windows.Forms.Button
    Friend WithEvents StandardDef As System.Windows.Forms.Button
    Friend WithEvents RecordingMS As System.Windows.Forms.TextBox
    Friend WithEvents ChangeDim As System.Windows.Forms.Label
    Friend WithEvents CamHeight As System.Windows.Forms.TextBox
    Friend WithEvents CamWidth As System.Windows.Forms.TextBox
    Friend WithEvents ChangeOpac As System.Windows.Forms.Label
    Friend WithEvents OpacInt As System.Windows.Forms.TextBox
    Friend WithEvents Pinning As System.Windows.Forms.CheckBox
    Friend WithEvents Record As System.Windows.Forms.CheckBox
    Friend WithEvents SSCam As System.Windows.Forms.CheckBox
    Friend WithEvents ChromaKeyCheck As System.Windows.Forms.CheckBox
    Friend WithEvents ChromaKeyColor As System.Windows.Forms.LinkLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChromaKey As System.Windows.Forms.ColorDialog
End Class
