Public Class Form1

    Private driver As ASCOM.DriverAccess.Switch

    Private Sub Form1_FormOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        SetUIState()
    End Sub

    ''' <summary>
    ''' This event is where the driver is choosen. The device ID will be saved in the settings.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub buttonChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonChoose.Click
        My.Settings.DriverId = ASCOM.DriverAccess.Switch.Choose(My.Settings.DriverId)
        labelDriverId.Text = My.Settings.DriverId
        SetUIState()
    End Sub

    ''' <summary>
    ''' Connects to the device to be tested.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub buttonConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonConnect.Click
        If IsConnected Then
            If driver.MaxSwitch >= 1 Then
                LabelStatusSwitch0.BackColor = DefaultBackColor
                LabelStatusSwitch0.Text = ""
                driver.SetSwitch(0, False)
            End If
            If driver.MaxSwitch >= 2 Then
                LabelStatusSwitch1.BackColor = DefaultBackColor
                LabelStatusSwitch1.Text = ""
                driver.SetSwitch(1, False)
            End If
            If driver.MaxSwitch >= 3 Then
                LabelStatusSwitch2.BackColor = DefaultBackColor
                LabelStatusSwitch2.Text = ""
                driver.SetSwitch(2, False)
            End If
            If driver.MaxSwitch >= 4 Then
                LabelStatusSwitch3.BackColor = DefaultBackColor
                LabelStatusSwitch3.Text = ""
                driver.SetSwitch(3, False)
            End If
            If driver.MaxSwitch >= 5 Then
                LabelStatusSwitch4.BackColor = DefaultBackColor
                LabelStatusSwitch4.Text = ""
                driver.SetSwitch(4, False)
            End If
            If driver.MaxSwitch >= 6 Then
                LabelStatusSwitch5.BackColor = DefaultBackColor
                LabelStatusSwitch5.Text = ""
                driver.SetSwitch(5, False)
            End If
            If driver.MaxSwitch >= 7 Then
                LabelStatusSwitch6.BackColor = DefaultBackColor
                LabelStatusSwitch6.Text = ""
                driver.SetSwitch(6, False)
            End If
            If driver.MaxSwitch >= 8 Then
                LabelStatusSwitch7.BackColor = DefaultBackColor
                LabelStatusSwitch7.Text = ""
                driver.SetSwitch(7, False)
            End If
            driver.Connected = False
            buttonConnect.BackColor = DefaultBackColor
        Else
            driver = New ASCOM.DriverAccess.Switch(My.Settings.DriverId)
            driver.Connected = True
            If driver.MaxSwitch >= 1 Then
                LabelStatusSwitch0.BackColor = Color.Red
                LabelStatusSwitch0.Text = "OFF"
                TextBoxSwitchName0.Text = driver.GetSwitchName(0)
            Else
                LabelStatusSwitch0.BackColor = DefaultBackColor
                LabelStatusSwitch0.Text = ""
                TextBoxSwitchName0.Text = ""
            End If
            If driver.MaxSwitch >= 2 Then
                LabelStatusSwitch1.BackColor = Color.Red
                LabelStatusSwitch1.Text = "OFF"
                TextBoxSwitchName1.Text = driver.GetSwitchName(1)
            Else
                LabelStatusSwitch1.BackColor = DefaultBackColor
                LabelStatusSwitch1.Text = ""
                TextBoxSwitchName1.Text = ""
            End If
            If driver.MaxSwitch >= 3 Then
                LabelStatusSwitch2.BackColor = Color.Red
                LabelStatusSwitch2.Text = "OFF"
                TextBoxSwitchName2.Text = driver.GetSwitchName(2)
            Else
                LabelStatusSwitch2.BackColor = DefaultBackColor
                LabelStatusSwitch2.Text = ""
                TextBoxSwitchName2.Text = ""
            End If
            If driver.MaxSwitch >= 4 Then
                LabelStatusSwitch3.BackColor = Color.Red
                LabelStatusSwitch3.Text = "OFF"
                TextBoxSwitchName3.Text = driver.GetSwitchName(3)
            Else
                LabelStatusSwitch3.BackColor = DefaultBackColor
                LabelStatusSwitch3.Text = ""
                TextBoxSwitchName3.Text = ""
            End If
            If driver.MaxSwitch >= 5 Then
                LabelStatusSwitch4.BackColor = Color.Red
                LabelStatusSwitch4.Text = "OFF"
                TextBoxSwitchName4.Text = driver.GetSwitchName(4)
            Else
                LabelStatusSwitch4.BackColor = DefaultBackColor
                LabelStatusSwitch4.Text = ""
                TextBoxSwitchName4.Text = ""
            End If
            If driver.MaxSwitch >= 6 Then
                LabelStatusSwitch5.BackColor = Color.Red
                LabelStatusSwitch5.Text = "OFF"
                TextBoxSwitchName5.Text = driver.GetSwitchName(5)
            Else
                LabelStatusSwitch5.BackColor = DefaultBackColor
                LabelStatusSwitch5.Text = ""
                TextBoxSwitchName5.Text = ""
            End If
            If driver.MaxSwitch >= 7 Then
                LabelStatusSwitch6.BackColor = Color.Red
                LabelStatusSwitch6.Text = "OFF"
                TextBoxSwitchName6.Text = driver.GetSwitchName(6)
            Else
                LabelStatusSwitch6.BackColor = DefaultBackColor
                LabelStatusSwitch6.Text = ""
                TextBoxSwitchName6.Text = ""
            End If
            If driver.MaxSwitch >= 8 Then
                LabelStatusSwitch7.BackColor = Color.Red
                LabelStatusSwitch7.Text = "OFF"
                TextBoxSwitchName7.Text = driver.GetSwitchName(7)
            Else
                LabelStatusSwitch7.BackColor = DefaultBackColor
                LabelStatusSwitch7.Text = ""
                TextBoxSwitchName7.Text = ""
            End If
            buttonConnect.BackColor = Color.Lime
        End If
        SetUIState()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If IsConnected Then
            If driver.MaxSwitch >= 1 Then
                LabelStatusSwitch0.BackColor = DefaultBackColor
                LabelStatusSwitch0.Text = ""
                driver.SetSwitch(0, False)
            End If
            If driver.MaxSwitch >= 2 Then
                LabelStatusSwitch1.BackColor = DefaultBackColor
                LabelStatusSwitch1.Text = ""
                driver.SetSwitch(1, False)
            End If
            If driver.MaxSwitch >= 3 Then
                LabelStatusSwitch2.BackColor = DefaultBackColor
                LabelStatusSwitch2.Text = ""
                driver.SetSwitch(2, False)
            End If
            If driver.MaxSwitch >= 4 Then
                LabelStatusSwitch3.BackColor = DefaultBackColor
                LabelStatusSwitch3.Text = ""
                driver.SetSwitch(3, False)
            End If
            If driver.MaxSwitch >= 5 Then
                LabelStatusSwitch4.BackColor = DefaultBackColor
                LabelStatusSwitch4.Text = ""
                driver.SetSwitch(4, False)
            End If
            If driver.MaxSwitch >= 6 Then
                LabelStatusSwitch5.BackColor = DefaultBackColor
                LabelStatusSwitch5.Text = ""
                driver.SetSwitch(5, False)
            End If
            If driver.MaxSwitch >= 7 Then
                LabelStatusSwitch6.BackColor = DefaultBackColor
                LabelStatusSwitch6.Text = ""
                driver.SetSwitch(6, False)
            End If
            If driver.MaxSwitch >= 8 Then
                LabelStatusSwitch7.BackColor = DefaultBackColor
                LabelStatusSwitch7.Text = ""
                driver.SetSwitch(7, False)
            End If
            driver.Connected = False
        End If
        SetUIState()
        ' the settings are saved automatically when this application is closed.
    End Sub

    ''' <summary>
    ''' Sets the state of the UI depending on the device state
    ''' </summary>
    Private Sub SetUIState()
        buttonConnect.Enabled = Not String.IsNullOrEmpty(My.Settings.DriverId)
        buttonChoose.Enabled = Not IsConnected
        buttonConnect.Text = IIf(IsConnected, "Disconnect", "Connect")
        ButtonSetSwitchName0.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 1)
        ButtonSwitch0_ON.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 1)
        ButtonSwitch0_OFF.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 1)
        TextBoxSwitchName0.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 1)
        LabelStatusSwitch0.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 1)
        Label1.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 1)
        ButtonSetSwitchName1.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 2)
        ButtonSwitch1_ON.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 2)
        ButtonSwitch1_OFF.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 2)
        TextBoxSwitchName1.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 2)
        LabelStatusSwitch1.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 2)
        Label2.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 2)
        ButtonSetSwitchName2.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 3)
        ButtonSwitch2_ON.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 3)
        ButtonSwitch2_OFF.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 3)
        TextBoxSwitchName2.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 3)
        LabelStatusSwitch2.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 3)
        Label3.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 3)
        ButtonSetSwitchName3.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 4)
        ButtonSwitch3_ON.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 4)
        ButtonSwitch3_OFF.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 4)
        TextBoxSwitchName3.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 4)
        LabelStatusSwitch3.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 4)
        Label4.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 4)
        ButtonSetSwitchName4.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 5)
        ButtonSwitch4_ON.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 5)
        ButtonSwitch4_OFF.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 5)
        TextBoxSwitchName4.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 5)
        LabelStatusSwitch4.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 5)
        Label5.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 5)
        ButtonSetSwitchName5.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 6)
        ButtonSwitch5_ON.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 6)
        ButtonSwitch5_OFF.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 6)
        TextBoxSwitchName5.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 6)
        LabelStatusSwitch5.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 6)
        Label6.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 6)
        ButtonSetSwitchName6.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 7)
        ButtonSwitch6_ON.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 7)
        ButtonSwitch6_OFF.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 7)
        TextBoxSwitchName6.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 7)
        LabelStatusSwitch6.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 7)
        Label7.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 7)
        ButtonSetSwitchName7.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 8)
        ButtonSwitch7_ON.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 8)
        ButtonSwitch7_OFF.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 8)
        TextBoxSwitchName7.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 8)
        LabelStatusSwitch7.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 8)
        Label8.Enabled = IsConnected AndAlso (driver.MaxSwitch >= 8)
    End Sub

    ''' <summary>
    ''' Gets a value indicating whether this instance is connected.
    ''' </summary>
    ''' <value>
    ''' 
    ''' <c>true</c> if this instance is connected; otherwise, <c>false</c>.
    ''' 
    ''' </value>
    Private ReadOnly Property IsConnected() As Boolean
        Get
            If Me.driver Is Nothing Then Return False
            Return driver.Connected
        End Get
    End Property

    Private Sub ButtonSwitch0_ON_Click(sender As Object, e As EventArgs) Handles ButtonSwitch0_ON.Click
        LabelStatusSwitch0.BackColor = Color.Lime
        LabelStatusSwitch0.Text = "ON"
        driver.SetSwitch(0, True)
    End Sub

    Private Sub ButtonSwitch0_OFF_Click(sender As Object, e As EventArgs) Handles ButtonSwitch0_OFF.Click
        LabelStatusSwitch0.BackColor = Color.Red
        LabelStatusSwitch0.Text = "OFF"
        driver.SetSwitch(0, False)
    End Sub

    Private Sub ButtonSwitch1_ON_Click(sender As Object, e As EventArgs) Handles ButtonSwitch1_ON.Click
        LabelStatusSwitch1.BackColor = Color.Lime
        LabelStatusSwitch1.Text = "ON"
        driver.SetSwitch(1, True)
    End Sub

    Private Sub ButtonSwitch1_OFF_Click(sender As Object, e As EventArgs) Handles ButtonSwitch1_OFF.Click
        LabelStatusSwitch1.BackColor = Color.Red
        LabelStatusSwitch1.Text = "OFF"
        driver.SetSwitch(1, False)
    End Sub

    Private Sub ButtonSwitch2_ON_Click(sender As Object, e As EventArgs) Handles ButtonSwitch2_ON.Click
        LabelStatusSwitch2.BackColor = Color.Lime
        LabelStatusSwitch2.Text = "ON"
        driver.SetSwitch(2, True)
    End Sub

    Private Sub ButtonSwitch2_OFF_Click(sender As Object, e As EventArgs) Handles ButtonSwitch2_OFF.Click
        LabelStatusSwitch2.BackColor = Color.Red
        LabelStatusSwitch2.Text = "OFF"
        driver.SetSwitch(2, False)
    End Sub

    Private Sub ButtonSwitch3_ON_Click(sender As Object, e As EventArgs) Handles ButtonSwitch3_ON.Click
        LabelStatusSwitch3.BackColor = Color.Lime
        LabelStatusSwitch3.Text = "ON"
        driver.SetSwitch(3, True)
    End Sub

    Private Sub ButtonSwitch3_OFF_Click(sender As Object, e As EventArgs) Handles ButtonSwitch3_OFF.Click
        LabelStatusSwitch3.BackColor = Color.Red
        LabelStatusSwitch3.Text = "OFF"
        driver.SetSwitch(3, False)
    End Sub

    Private Sub ButtonSwitch4_ON_Click(sender As Object, e As EventArgs) Handles ButtonSwitch4_ON.Click
        LabelStatusSwitch4.BackColor = Color.Lime
        LabelStatusSwitch4.Text = "ON"
        driver.SetSwitch(4, True)
    End Sub

    Private Sub ButtonSwitch4_OFF_Click(sender As Object, e As EventArgs) Handles ButtonSwitch4_OFF.Click
        LabelStatusSwitch4.BackColor = Color.Red
        LabelStatusSwitch4.Text = "OFF"
        driver.SetSwitch(4, False)
    End Sub

    Private Sub ButtonSwitch5_ON_Click(sender As Object, e As EventArgs) Handles ButtonSwitch5_ON.Click
        LabelStatusSwitch5.BackColor = Color.Lime
        LabelStatusSwitch5.Text = "ON"
        driver.SetSwitch(5, True)
    End Sub

    Private Sub ButtonSwitch5_OFF_Click(sender As Object, e As EventArgs) Handles ButtonSwitch5_OFF.Click
        LabelStatusSwitch5.BackColor = Color.Red
        LabelStatusSwitch5.Text = "OFF"
        driver.SetSwitch(5, False)
    End Sub

    Private Sub ButtonSwitch6_ON_Click(sender As Object, e As EventArgs) Handles ButtonSwitch6_ON.Click
        LabelStatusSwitch6.BackColor = Color.Lime
        LabelStatusSwitch6.Text = "ON"
        driver.SetSwitch(6, True)
    End Sub

    Private Sub ButtonSwitch6_OFF_Click(sender As Object, e As EventArgs) Handles ButtonSwitch6_OFF.Click
        LabelStatusSwitch6.BackColor = Color.Red
        LabelStatusSwitch6.Text = "OFF"
        driver.SetSwitch(6, False)
    End Sub

    Private Sub ButtonSwitch7_ON_Click(sender As Object, e As EventArgs) Handles ButtonSwitch7_ON.Click
        LabelStatusSwitch7.BackColor = Color.Lime
        LabelStatusSwitch7.Text = "ON"
        driver.SetSwitch(7, True)
    End Sub

    Private Sub ButtonSwitch7_OFF_Click(sender As Object, e As EventArgs) Handles ButtonSwitch7_OFF.Click
        LabelStatusSwitch7.BackColor = Color.Red
        LabelStatusSwitch7.Text = "OFF"
        driver.SetSwitch(7, False)
    End Sub

    Private Sub ButtonSetSwitchName0_Click(sender As Object, e As EventArgs) Handles ButtonSetSwitchName0.Click
        driver.SetSwitchName(0, TextBoxSwitchName0.Text)
    End Sub

    Private Sub ButtonSetSwitchName1_Click(sender As Object, e As EventArgs) Handles ButtonSetSwitchName1.Click
        driver.SetSwitchName(1, TextBoxSwitchName1.Text)
    End Sub

    Private Sub ButtonSetSwitchName2_Click(sender As Object, e As EventArgs) Handles ButtonSetSwitchName2.Click
        driver.SetSwitchName(2, TextBoxSwitchName2.Text)
    End Sub

    Private Sub ButtonSetSwitchName3_Click(sender As Object, e As EventArgs) Handles ButtonSetSwitchName3.Click
        driver.SetSwitchName(3, TextBoxSwitchName3.Text)
    End Sub

    Private Sub ButtonSetSwitchName4_Click(sender As Object, e As EventArgs) Handles ButtonSetSwitchName4.Click
        driver.SetSwitchName(4, TextBoxSwitchName4.Text)
    End Sub

    Private Sub ButtonSetSwitchName5_Click(sender As Object, e As EventArgs) Handles ButtonSetSwitchName5.Click
        driver.SetSwitchName(5, TextBoxSwitchName5.Text)
    End Sub

    Private Sub ButtonSetSwitchName6_Click(sender As Object, e As EventArgs) Handles ButtonSetSwitchName6.Click
        driver.SetSwitchName(6, TextBoxSwitchName6.Text)
    End Sub

    Private Sub ButtonSetSwitchName7_Click(sender As Object, e As EventArgs) Handles ButtonSetSwitchName7.Click
        driver.SetSwitchName(7, TextBoxSwitchName7.Text)
    End Sub

End Class
