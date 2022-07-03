<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetupDialogForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetupDialogForm))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LabelCopyRight = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxSwitchName7 = New System.Windows.Forms.TextBox()
        Me.TextBoxSwitchName6 = New System.Windows.Forms.TextBox()
        Me.TextBoxSwitchName5 = New System.Windows.Forms.TextBox()
        Me.TextBoxSwitchName4 = New System.Windows.Forms.TextBox()
        Me.TextBoxSwitchName3 = New System.Windows.Forms.TextBox()
        Me.TextBoxSwitchName2 = New System.Windows.Forms.TextBox()
        Me.TextBoxSwitchName1 = New System.Windows.Forms.TextBox()
        Me.TextBoxSwitchName0 = New System.Windows.Forms.TextBox()
        Me.LabelSwitchName7 = New System.Windows.Forms.Label()
        Me.LabelSwitchName6 = New System.Windows.Forms.Label()
        Me.LabelSwitchName5 = New System.Windows.Forms.Label()
        Me.LabelSwitchName4 = New System.Windows.Forms.Label()
        Me.LabelSwitchName3 = New System.Windows.Forms.Label()
        Me.LabelSwitchName2 = New System.Windows.Forms.Label()
        Me.LabelSwitchName1 = New System.Windows.Forms.Label()
        Me.LabelSwitchName0 = New System.Windows.Forms.Label()
        Me.ComboBoxComPort = New System.Windows.Forms.ComboBox()
        Me.chkTrace = New System.Windows.Forms.CheckBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxConnectionDelay = New System.Windows.Forms.ComboBox()
        Me.ComboBoxnumSwitch = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(232, 409)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.ASCOM.wittinobiArduinoSwitchASCOMv2usbDRIVER.My.Resources.Resources.ASCOM
        Me.PictureBox1.Location = New System.Drawing.Point(329, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'LabelCopyRight
        '
        Me.LabelCopyRight.AutoSize = True
        Me.LabelCopyRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCopyRight.Location = New System.Drawing.Point(12, 422)
        Me.LabelCopyRight.Name = "LabelCopyRight"
        Me.LabelCopyRight.Size = New System.Drawing.Size(187, 13)
        Me.LabelCopyRight.TabIndex = 129
        Me.LabelCopyRight.Text = "© 2022 by Tobias Wittmann (wittinobi)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 128
        Me.Label4.Text = "Relay"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 127
        Me.Label3.Text = "Switch Name"
        '
        'TextBoxSwitchName7
        '
        Me.TextBoxSwitchName7.Location = New System.Drawing.Point(61, 357)
        Me.TextBoxSwitchName7.Name = "TextBoxSwitchName7"
        Me.TextBoxSwitchName7.Size = New System.Drawing.Size(316, 20)
        Me.TextBoxSwitchName7.TabIndex = 126
        '
        'TextBoxSwitchName6
        '
        Me.TextBoxSwitchName6.Location = New System.Drawing.Point(61, 331)
        Me.TextBoxSwitchName6.Name = "TextBoxSwitchName6"
        Me.TextBoxSwitchName6.Size = New System.Drawing.Size(316, 20)
        Me.TextBoxSwitchName6.TabIndex = 125
        '
        'TextBoxSwitchName5
        '
        Me.TextBoxSwitchName5.Location = New System.Drawing.Point(61, 305)
        Me.TextBoxSwitchName5.Name = "TextBoxSwitchName5"
        Me.TextBoxSwitchName5.Size = New System.Drawing.Size(316, 20)
        Me.TextBoxSwitchName5.TabIndex = 124
        '
        'TextBoxSwitchName4
        '
        Me.TextBoxSwitchName4.Location = New System.Drawing.Point(61, 279)
        Me.TextBoxSwitchName4.Name = "TextBoxSwitchName4"
        Me.TextBoxSwitchName4.Size = New System.Drawing.Size(316, 20)
        Me.TextBoxSwitchName4.TabIndex = 123
        '
        'TextBoxSwitchName3
        '
        Me.TextBoxSwitchName3.Location = New System.Drawing.Point(61, 253)
        Me.TextBoxSwitchName3.Name = "TextBoxSwitchName3"
        Me.TextBoxSwitchName3.Size = New System.Drawing.Size(316, 20)
        Me.TextBoxSwitchName3.TabIndex = 122
        '
        'TextBoxSwitchName2
        '
        Me.TextBoxSwitchName2.Location = New System.Drawing.Point(61, 227)
        Me.TextBoxSwitchName2.Name = "TextBoxSwitchName2"
        Me.TextBoxSwitchName2.Size = New System.Drawing.Size(316, 20)
        Me.TextBoxSwitchName2.TabIndex = 121
        '
        'TextBoxSwitchName1
        '
        Me.TextBoxSwitchName1.Location = New System.Drawing.Point(61, 201)
        Me.TextBoxSwitchName1.Name = "TextBoxSwitchName1"
        Me.TextBoxSwitchName1.Size = New System.Drawing.Size(316, 20)
        Me.TextBoxSwitchName1.TabIndex = 120
        '
        'TextBoxSwitchName0
        '
        Me.TextBoxSwitchName0.Location = New System.Drawing.Point(61, 175)
        Me.TextBoxSwitchName0.Name = "TextBoxSwitchName0"
        Me.TextBoxSwitchName0.Size = New System.Drawing.Size(316, 20)
        Me.TextBoxSwitchName0.TabIndex = 119
        '
        'LabelSwitchName7
        '
        Me.LabelSwitchName7.AutoSize = True
        Me.LabelSwitchName7.Location = New System.Drawing.Point(12, 360)
        Me.LabelSwitchName7.Name = "LabelSwitchName7"
        Me.LabelSwitchName7.Size = New System.Drawing.Size(43, 13)
        Me.LabelSwitchName7.TabIndex = 118
        Me.LabelSwitchName7.Text = "Relay 8"
        '
        'LabelSwitchName6
        '
        Me.LabelSwitchName6.AutoSize = True
        Me.LabelSwitchName6.Location = New System.Drawing.Point(12, 334)
        Me.LabelSwitchName6.Name = "LabelSwitchName6"
        Me.LabelSwitchName6.Size = New System.Drawing.Size(43, 13)
        Me.LabelSwitchName6.TabIndex = 117
        Me.LabelSwitchName6.Text = "Relay 7"
        '
        'LabelSwitchName5
        '
        Me.LabelSwitchName5.AutoSize = True
        Me.LabelSwitchName5.Location = New System.Drawing.Point(12, 308)
        Me.LabelSwitchName5.Name = "LabelSwitchName5"
        Me.LabelSwitchName5.Size = New System.Drawing.Size(43, 13)
        Me.LabelSwitchName5.TabIndex = 116
        Me.LabelSwitchName5.Text = "Relay 6"
        '
        'LabelSwitchName4
        '
        Me.LabelSwitchName4.AutoSize = True
        Me.LabelSwitchName4.Location = New System.Drawing.Point(12, 282)
        Me.LabelSwitchName4.Name = "LabelSwitchName4"
        Me.LabelSwitchName4.Size = New System.Drawing.Size(43, 13)
        Me.LabelSwitchName4.TabIndex = 115
        Me.LabelSwitchName4.Text = "Relay 5"
        '
        'LabelSwitchName3
        '
        Me.LabelSwitchName3.AutoSize = True
        Me.LabelSwitchName3.Location = New System.Drawing.Point(12, 256)
        Me.LabelSwitchName3.Name = "LabelSwitchName3"
        Me.LabelSwitchName3.Size = New System.Drawing.Size(43, 13)
        Me.LabelSwitchName3.TabIndex = 114
        Me.LabelSwitchName3.Text = "Relay 4"
        '
        'LabelSwitchName2
        '
        Me.LabelSwitchName2.AutoSize = True
        Me.LabelSwitchName2.Location = New System.Drawing.Point(12, 230)
        Me.LabelSwitchName2.Name = "LabelSwitchName2"
        Me.LabelSwitchName2.Size = New System.Drawing.Size(43, 13)
        Me.LabelSwitchName2.TabIndex = 113
        Me.LabelSwitchName2.Text = "Relay 3"
        '
        'LabelSwitchName1
        '
        Me.LabelSwitchName1.AutoSize = True
        Me.LabelSwitchName1.Location = New System.Drawing.Point(12, 204)
        Me.LabelSwitchName1.Name = "LabelSwitchName1"
        Me.LabelSwitchName1.Size = New System.Drawing.Size(43, 13)
        Me.LabelSwitchName1.TabIndex = 112
        Me.LabelSwitchName1.Text = "Relay 2"
        '
        'LabelSwitchName0
        '
        Me.LabelSwitchName0.AutoSize = True
        Me.LabelSwitchName0.Location = New System.Drawing.Point(12, 178)
        Me.LabelSwitchName0.Name = "LabelSwitchName0"
        Me.LabelSwitchName0.Size = New System.Drawing.Size(43, 13)
        Me.LabelSwitchName0.TabIndex = 111
        Me.LabelSwitchName0.Text = "Relay 1"
        '
        'ComboBoxComPort
        '
        Me.ComboBoxComPort.FormattingEnabled = True
        Me.ComboBoxComPort.Location = New System.Drawing.Point(76, 81)
        Me.ComboBoxComPort.Name = "ComboBoxComPort"
        Me.ComboBoxComPort.Size = New System.Drawing.Size(84, 21)
        Me.ComboBoxComPort.TabIndex = 110
        '
        'chkTrace
        '
        Me.chkTrace.AutoSize = True
        Me.chkTrace.Location = New System.Drawing.Point(76, 112)
        Me.chkTrace.Name = "chkTrace"
        Me.chkTrace.Size = New System.Drawing.Size(69, 17)
        Me.chkTrace.TabIndex = 109
        Me.chkTrace.Text = "Trace on"
        Me.chkTrace.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 84)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(58, 13)
        Me.label2.TabIndex = 108
        Me.label2.Text = "Comm Port"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(288, 45)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "wittinobiArduinoSwitchASCOMv2usbDRIVER" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Setup"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ComboBoxConnectionDelay
        '
        Me.ComboBoxConnectionDelay.FormattingEnabled = True
        Me.ComboBoxConnectionDelay.Items.AddRange(New Object() {"0", "5000"})
        Me.ComboBoxConnectionDelay.Location = New System.Drawing.Point(305, 81)
        Me.ComboBoxConnectionDelay.Name = "ComboBoxConnectionDelay"
        Me.ComboBoxConnectionDelay.Size = New System.Drawing.Size(72, 21)
        Me.ComboBoxConnectionDelay.TabIndex = 145
        '
        'ComboBoxnumSwitch
        '
        Me.ComboBoxnumSwitch.FormattingEnabled = True
        Me.ComboBoxnumSwitch.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8"})
        Me.ComboBoxnumSwitch.Location = New System.Drawing.Point(305, 108)
        Me.ComboBoxnumSwitch.Name = "ComboBoxnumSwitch"
        Me.ComboBoxnumSwitch.Size = New System.Drawing.Size(72, 21)
        Me.ComboBoxnumSwitch.TabIndex = 144
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(225, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 143
        Me.Label6.Text = "Max Switches"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(189, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 13)
        Me.Label5.TabIndex = 142
        Me.Label5.Text = "Connection Delay (ms)"
        '
        'SetupDialogForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(390, 450)
        Me.Controls.Add(Me.ComboBoxConnectionDelay)
        Me.Controls.Add(Me.ComboBoxnumSwitch)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LabelCopyRight)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxSwitchName7)
        Me.Controls.Add(Me.TextBoxSwitchName6)
        Me.Controls.Add(Me.TextBoxSwitchName5)
        Me.Controls.Add(Me.TextBoxSwitchName4)
        Me.Controls.Add(Me.TextBoxSwitchName3)
        Me.Controls.Add(Me.TextBoxSwitchName2)
        Me.Controls.Add(Me.TextBoxSwitchName1)
        Me.Controls.Add(Me.TextBoxSwitchName0)
        Me.Controls.Add(Me.LabelSwitchName7)
        Me.Controls.Add(Me.LabelSwitchName6)
        Me.Controls.Add(Me.LabelSwitchName5)
        Me.Controls.Add(Me.LabelSwitchName4)
        Me.Controls.Add(Me.LabelSwitchName3)
        Me.Controls.Add(Me.LabelSwitchName2)
        Me.Controls.Add(Me.LabelSwitchName1)
        Me.Controls.Add(Me.LabelSwitchName0)
        Me.Controls.Add(Me.ComboBoxComPort)
        Me.Controls.Add(Me.chkTrace)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SetupDialogForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "wittinobiArduinoSwitchASCOMv2usbDRIVER Setup"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelCopyRight As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxSwitchName7 As TextBox
    Friend WithEvents TextBoxSwitchName6 As TextBox
    Friend WithEvents TextBoxSwitchName5 As TextBox
    Friend WithEvents TextBoxSwitchName4 As TextBox
    Friend WithEvents TextBoxSwitchName3 As TextBox
    Friend WithEvents TextBoxSwitchName2 As TextBox
    Friend WithEvents TextBoxSwitchName1 As TextBox
    Friend WithEvents TextBoxSwitchName0 As TextBox
    Private WithEvents LabelSwitchName7 As Label
    Private WithEvents LabelSwitchName6 As Label
    Private WithEvents LabelSwitchName5 As Label
    Private WithEvents LabelSwitchName4 As Label
    Private WithEvents LabelSwitchName3 As Label
    Private WithEvents LabelSwitchName2 As Label
    Private WithEvents LabelSwitchName1 As Label
    Private WithEvents LabelSwitchName0 As Label
    Friend WithEvents ComboBoxComPort As ComboBox
    Friend WithEvents chkTrace As CheckBox
    Private WithEvents label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxConnectionDelay As TextBox
    Friend WithEvents ComboBoxConnectionDelay As ComboBox
    Friend WithEvents ComboBoxnumSwitch As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
End Class
