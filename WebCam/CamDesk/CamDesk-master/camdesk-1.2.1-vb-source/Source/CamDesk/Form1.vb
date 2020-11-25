Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Win32

Public Class Form1
    Inherits System.Windows.Forms.Form
    Const WM_CAP_START = &H400S
    Const WS_CHILD = &H40000000
    Const WS_VISIBLE = &H10000000
    Const WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10
    Const WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11
    Const WM_CAP_EDIT_COPY = WM_CAP_START + 30
    Const WM_CAP_SEQUENCE = WM_CAP_START + 62
    Const WM_CAP_FILE_SAVEAS = WM_CAP_START + 23
    Const WM_CAP_SET_SCALE = WM_CAP_START + 53
    Const WM_CAP_SET_PREVIEWRATE = WM_CAP_START + 52
    Const WM_CAP_SET_PREVIEW = WM_CAP_START + 50
    Const SWP_NOMOVE = &H2S
    Const SWP_NOSIZE = 1
    Const SWP_NOZORDER = &H4S
    Const HWND_BOTTOM = 1
    Const WM_CAP_GRAB_FRAME = WM_CAP_START + 60

    <DllImport("user32.dll")> Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef r As RECT) As Boolean
    End Function

    <DllImport("user32.dll")> Shared Function PrintWindow(ByVal hWnd As IntPtr, ByVal hdcBlt As IntPtr, ByVal nFlags As UInteger) As Boolean
    End Function

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Structure RECT
        Dim left As Integer
        Dim top As Integer
        Dim right As Integer
        Dim bottom As Integer
    End Structure

    '--The capGetDriverDescription function retrieves the version 
    ' description of the capture driver--
    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" _
       (ByVal wDriverIndex As Short, _
        ByVal lpszName As String, ByVal cbName As Integer, _
        ByVal lpszVer As String, _
        ByVal cbVer As Integer) As Boolean

    '--The capCreateCaptureWindow function creates a capture window--
    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
       (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
        ByVal nHeight As Short, ByVal hWnd As Integer, _
        ByVal nID As Integer) As Integer

    '--This function sends the specified message to a window or windows--
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
       (ByVal hwnd As Integer, ByVal Msg As Integer, _
        ByVal wParam As Integer, _
       <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    '--Sets the position of the window relative to the screen buffer--
    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" _
       (ByVal hwnd As Integer, _
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, _
        ByVal y As Integer, _
        ByVal cx As Integer, ByVal cy As Integer, _
        ByVal wFlags As Integer) As Integer

    '--This function destroys the specified window--
    Declare Function DestroyWindow Lib "user32" _
       (ByVal hndw As Integer) As Boolean

    '---used to identify the video source---
    Dim CamSource As Integer
    '---used as a window handle---
    Dim hWnd As Integer

    Public Sub CamResize()
        SetWindowPos(hWnd, HWND_BOTTOM, 0, 0, _
                       Width, Height, _
                       SWP_NOMOVE Or SWP_NOZORDER)
    End Sub

    Public Sub previewCamera(ByVal pbCtrl As Form)
        hWnd = capCreateCaptureWindowA(CamSource, _
            WS_VISIBLE Or WS_CHILD, 0, 0, 0, _
            0, pbCtrl.Handle.ToInt32, 0)
        If SendMessage( _
           hWnd, WM_CAP_DRIVER_CONNECT, _
           CamSource, 0) Then
            '---set the preview scale---
            SendMessage(hWnd, WM_CAP_SET_SCALE, True, 0)
            '---set the preview rate (ms)---
            SendMessage(hWnd, WM_CAP_SET_PREVIEWRATE, 30, 0)
            '---start previewing the image---
            SendMessage(hWnd, WM_CAP_SET_PREVIEW, True, 0)
            '---resize window to fit in PictureBox control---
            SetWindowPos(hWnd, HWND_BOTTOM, 0, 0, _
               pbCtrl.Width, pbCtrl.Height, _
               SWP_NOMOVE Or SWP_NOZORDER)
        Else
            '--error connecting to video source---
            DestroyWindow(hWnd)
        End If
    End Sub

    Public Sub stopPreviewCamera()
        SendMessage(hWnd, WM_CAP_DRIVER_DISCONNECT, CamSource, 0)
        DestroyWindow(hWnd)
    End Sub

    Private Const CS_DROPSHADOW As Integer = 131072
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim Shadow As CreateParams = MyBase.CreateParams
            Shadow.ClassStyle = Shadow.ClassStyle Or CS_DROPSHADOW
            Return Shadow
        End Get
    End Property

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = Image.FromFile(Application.StartupPath & "\files\splash.png")

        If Form2.SSCam.Checked Then
            Me.StartStopToolStripMenuItem.Checked = True
            Me.RecordToolStripMenuItem.Enabled = True
        Else
            stopPreviewCamera()
            Me.StartStopToolStripMenuItem.Checked = False
            Me.RecordToolStripMenuItem.Enabled = False
            Me.RecordToolStripMenuItem.Checked = False
            Me.Timer2.Stop()
        End If

        Form2.Hide()
    End Sub

    Private Sub StartStopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartStopToolStripMenuItem.Click
        If StartStopToolStripMenuItem.Checked Then
            Form2.SSCam.Checked = True
        Else
            Form2.SSCam.Checked = False
        End If
    End Sub

    Private Sub FullscreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullscreenToolStripMenuItem.Click
        If FullscreenToolStripMenuItem.Checked Then
            WindowState = FormWindowState.Maximized
            CamResize()
        Else
            WindowState = FormWindowState.Normal
            CamResize()
        End If
    End Sub

    Private Sub PictureBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
            FullscreenToolStripMenuItem.Checked = True
            CamResize()
        Else
            WindowState = FormWindowState.Normal
            FullscreenToolStripMenuItem.Checked = False
            CamResize()
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            drag = True
            mousex = Windows.Forms.Cursor.Position.X - Me.Left
            mousey = Windows.Forms.Cursor.Position.Y - Me.Top
        End If

        Timer1.Enabled = True
        Timer1.Interval = 2500
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        Timer1.Enabled = False
        drag = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Form2.Visible = False Then
            Form2.Show()
            PreferencesToolStripMenuItem.Checked = True
        Else
            Form2.Hide()
            PreferencesToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        If StartStopToolStripMenuItem.Checked Then
            stopPreviewCamera()
            RecordToolStripMenuItem.Enabled = False
            Me.Close()
            Form2.Close()
        End If

        If StartStopToolStripMenuItem.Checked = False Then
            Me.Close()
            Form2.Close()
        End If
    End Sub

    Private Sub PreferencesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreferencesToolStripMenuItem.Click
        If PreferencesToolStripMenuItem.Checked = False Then
            PreferencesToolStripMenuItem.Checked = True
            Form2.Show()
        Else
            PreferencesToolStripMenuItem.Checked = False
            Form2.Hide()
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim r As RECT = New RECT()

        GetWindowRect(hWnd, r)

        Dim cWidth As Integer = r.right - r.left
        Dim cHeight As Integer = r.bottom - r.top

        Dim bmp As Bitmap = New Bitmap(cWidth, cHeight)

        Dim gfx As Graphics = Graphics.FromImage(bmp)
        Dim gHdc As IntPtr = gfx.GetHdc()

        'refresh the image
        SendMessage(hWnd, WM_CAP_GRAB_FRAME, IntPtr.Zero, IntPtr.Zero)

        PrintWindow(hWnd, gHdc, 0)
        gfx.ReleaseHdc(gHdc)
        gfx.Dispose()

        bmp.Save("photos-taken\" & DateTime.Now.ToString("MM-dd-yyyy_HH.mm.ss") & ".bmp")

        bmp.Dispose()
    End Sub

    Private Sub RecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecordToolStripMenuItem.Click
        If RecordToolStripMenuItem.Checked = False Then
            Form2.Record.Checked = True
        Else
            Form2.Record.Checked = False
        End If
    End Sub
    
    Private Sub SnapshotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SnapshotToolStripMenuItem.Click
    	If Not Directory.Exists("photos-taken") Then
            Directory.CreateDirectory("photos-taken")
    	End If
    	
    	Dim r As RECT = New RECT()

        GetWindowRect(hWnd, r)

        Dim cWidth As Integer = r.right - r.left
        Dim cHeight As Integer = r.bottom - r.top

        Dim bmp As Bitmap = New Bitmap(cWidth, cHeight)

        Dim gfx As Graphics = Graphics.FromImage(bmp)
        Dim gHdc As IntPtr = gfx.GetHdc()

        'refresh the image
        SendMessage(hWnd, WM_CAP_GRAB_FRAME, IntPtr.Zero, IntPtr.Zero)

        PrintWindow(hWnd, gHdc, 0)
        gfx.ReleaseHdc(gHdc)
        gfx.Dispose()

        bmp.Save("photos-taken\" & DateTime.Now.ToString("MM-dd-yyyy_HH.mm.ss") & ".bmp")

        bmp.Dispose()
    End Sub
End Class