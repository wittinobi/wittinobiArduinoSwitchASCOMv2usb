'tabs=4
' --------------------------------------------------------------------------------
' TODO fill in this information for your driver, then remove this line!
'
' ASCOM Switch driver for wittinobiArduinoSwitchASCOMv2usbDRIVER
'
' Description:	Driver for Arduino Nano with 8Channel Relay Switch.
'
' Implements:	ASCOM Switch interface version: 2.0
' Author:		Tobias Wittmann (wittinobi) <wittinobi@wittinobi.de>
'
' Edit Log:
'
' Date			Who	                         Vers	Description
' -----------	---------------------------	 -----	-------------------------------
' 27-06-2022	Tobias Wittmann (wittinobi)	 1.0.0	Initial edit, from Switch template
' ---------------------------------------------------------------------------------
'
'
' Your driver's ID is ASCOM.wittinobiArduinoSwitchASCOMv2usbDRIVER.Switch
'
' The Guid attribute sets the CLSID for ASCOM.DeviceName.Switch
' The ClassInterface/None attribute prevents an empty interface called
' _Switch from being created and used as the [default] interface
'

' This definition is used to select code that's only applicable for one device type
#Const Device = "Switch"

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports ASCOM
Imports ASCOM.Astrometry
Imports ASCOM.Astrometry.AstroUtils
Imports ASCOM.DeviceInterface
Imports ASCOM.Utilities

<Guid("69c5366b-2499-4a6d-bbfb-62e6ca84f54f")>
<ClassInterface(ClassInterfaceType.None)>
Public Class Switch

    ' The Guid attribute sets the CLSID for ASCOM.wittinobiArduinoSwitchASCOMv2usbDRIVER.Switch
    ' The ClassInterface/None attribute prevents an empty interface called
    ' _wittinobiArduinoSwitchASCOMv2usbDRIVER from being created and used as the [default] interface

    ' TODO Replace the not implemented exceptions with code to implement the function or
    ' throw the appropriate ASCOM exception.
    '
    Implements ISwitchV2

    '
    ' Driver ID and descriptive string that shows in the Chooser
    '
    Friend Shared driverID As String = "ASCOM.wittinobiArduinoSwitchASCOMv2usbDRIVER.Switch"
    Private Shared driverDescription As String = "wittinobiArduinoSwitchASCOMv2usbDRIVER Switch"

    Friend Shared comPortProfileName As String = "COM Port" 'Constants used for Profile persistence
    Friend Shared traceStateProfileName As String = "Trace Level"
    Friend Shared comPortDefault As String = "COM1"
    Friend Shared traceStateDefault As String = "False"

    Friend Shared comPort As String ' Variables to hold the current device configuration
    Friend Shared traceState As Boolean

    Private connectedState As Boolean ' Private variable to hold the connected state
    Private utilities As Util ' Private variable to hold an ASCOM Utilities object
    Private astroUtilities As AstroUtils ' Private variable to hold an AstroUtils object to provide the Range method
    Private TL As TraceLogger ' Private variable to hold the trace logger object (creates a diagnostic log file with information that you specify)

    Private objSerial As ASCOM.Utilities.Serial

    Friend Shared ConnectionDelayProfileName As String = "Connection Delay (ms)"
    Friend Shared ConnectionDelayDefault As String = "0"
    Friend Shared ConnectionDelay As String

    Friend Shared numSwitchProfileName As String = "Max Switches"
    Friend Shared numSwitchDefault As String = "8"
    Friend Shared numSwitch As String

    Friend Shared SwitchName0ProfileName As String = "SwitchName 0"
    Friend Shared SwitchName1ProfileName As String = "SwitchName 1"
    Friend Shared SwitchName2ProfileName As String = "SwitchName 2"
    Friend Shared SwitchName3ProfileName As String = "SwitchName 3"
    Friend Shared SwitchName4ProfileName As String = "SwitchName 4"
    Friend Shared SwitchName5ProfileName As String = "SwitchName 5"
    Friend Shared SwitchName6ProfileName As String = "SwitchName 6"
    Friend Shared SwitchName7ProfileName As String = "SwitchName 7"
    Friend Shared SwitchName0Default As String = "Relay 0"
    Friend Shared SwitchName1Default As String = "Relay 1"
    Friend Shared SwitchName2Default As String = "Relay 2"
    Friend Shared SwitchName3Default As String = "Relay 3"
    Friend Shared SwitchName4Default As String = "Relay 4"
    Friend Shared SwitchName5Default As String = "Relay 5"
    Friend Shared SwitchName6Default As String = "Relay 6"
    Friend Shared SwitchName7Default As String = "Relay 7"
    Friend Shared SwitchName0 As String
    Friend Shared SwitchName1 As String
    Friend Shared SwitchName2 As String
    Friend Shared SwitchName3 As String
    Friend Shared SwitchName4 As String
    Friend Shared SwitchName5 As String
    Friend Shared SwitchName6 As String
    Friend Shared SwitchName7 As String

    Friend Shared CanWrite0ProfileName As String = "CanWrite 0"
    Friend Shared CanWrite1ProfileName As String = "CanWrite 1"
    Friend Shared CanWrite2ProfileName As String = "CanWrite 2"
    Friend Shared CanWrite3ProfileName As String = "CanWrite 3"
    Friend Shared CanWrite4ProfileName As String = "CanWrite 4"
    Friend Shared CanWrite5ProfileName As String = "CanWrite 5"
    Friend Shared CanWrite6ProfileName As String = "CanWrite 6"
    Friend Shared CanWrite7ProfileName As String = "CanWrite 7"
    Friend Shared CanWrite8ProfileName As String = "CanWrite 8"
    Friend Shared CanWrite9ProfileName As String = "CanWrite 9"
    Friend Shared CanWrite0Default As String = "YES"
    Friend Shared CanWrite1Default As String = "YES"
    Friend Shared CanWrite2Default As String = "YES"
    Friend Shared CanWrite3Default As String = "YES"
    Friend Shared CanWrite4Default As String = "YES"
    Friend Shared CanWrite5Default As String = "YES"
    Friend Shared CanWrite6Default As String = "YES"
    Friend Shared CanWrite7Default As String = "YES"
    Friend Shared CanWrite8Default As String = "YES"
    Friend Shared CanWrite9Default As String = "YES"
    Friend Shared CanWrite0 As String
    Friend Shared CanWrite1 As String
    Friend Shared CanWrite2 As String
    Friend Shared CanWrite3 As String
    Friend Shared CanWrite4 As String
    Friend Shared CanWrite5 As String
    Friend Shared CanWrite6 As String
    Friend Shared CanWrite7 As String
    Friend Shared CanWrite8 As String
    Friend Shared CanWrite9 As String

    Friend Shared SwitchValue0ProfileName As String = "SwitchValue 0"
    Friend Shared SwitchValue1ProfileName As String = "SwitchValue 1"
    Friend Shared SwitchValue2ProfileName As String = "SwitchValue 2"
    Friend Shared SwitchValue3ProfileName As String = "SwitchValue 3"
    Friend Shared SwitchValue4ProfileName As String = "SwitchValue 4"
    Friend Shared SwitchValue5ProfileName As String = "SwitchValue 5"
    Friend Shared SwitchValue6ProfileName As String = "SwitchValue 6"
    Friend Shared SwitchValue7ProfileName As String = "SwitchValue 7"
    Friend Shared SwitchValue0Default As String = "0"
    Friend Shared SwitchValue1Default As String = "0"
    Friend Shared SwitchValue2Default As String = "0"
    Friend Shared SwitchValue3Default As String = "0"
    Friend Shared SwitchValue4Default As String = "0"
    Friend Shared SwitchValue5Default As String = "0"
    Friend Shared SwitchValue6Default As String = "0"
    Friend Shared SwitchValue7Default As String = "0"
    Friend Shared SwitchValue0 As String
    Friend Shared SwitchValue1 As String
    Friend Shared SwitchValue2 As String
    Friend Shared SwitchValue3 As String
    Friend Shared SwitchValue4 As String
    Friend Shared SwitchValue5 As String
    Friend Shared SwitchValue6 As String
    Friend Shared SwitchValue7 As String

    Friend Shared SwitchState0ProfileName As String = "SwitchState 0"
    Friend Shared SwitchState1ProfileName As String = "SwitchState 1"
    Friend Shared SwitchState2ProfileName As String = "SwitchState 2"
    Friend Shared SwitchState3ProfileName As String = "SwitchState 3"
    Friend Shared SwitchState4ProfileName As String = "SwitchState 4"
    Friend Shared SwitchState5ProfileName As String = "SwitchState 5"
    Friend Shared SwitchState6ProfileName As String = "SwitchState 6"
    Friend Shared SwitchState7ProfileName As String = "SwitchState 7"
    Friend Shared SwitchState0Default As String = "OFF"
    Friend Shared SwitchState1Default As String = "OFF"
    Friend Shared SwitchState2Default As String = "OFF"
    Friend Shared SwitchState3Default As String = "OFF"
    Friend Shared SwitchState4Default As String = "OFF"
    Friend Shared SwitchState5Default As String = "OFF"
    Friend Shared SwitchState6Default As String = "OFF"
    Friend Shared SwitchState7Default As String = "OFF"
    Friend Shared SwitchState0 As String
    Friend Shared SwitchState1 As String
    Friend Shared SwitchState2 As String
    Friend Shared SwitchState3 As String
    Friend Shared SwitchState4 As String
    Friend Shared SwitchState5 As String
    Friend Shared SwitchState6 As String
    Friend Shared SwitchState7 As String

    '
    ' Constructor - Must be public for COM registration!
    '
    Public Sub New()

        ReadProfile() ' Read device configuration from the ASCOM Profile store
        TL = New TraceLogger("", "wittinobiArduinoSwitchASCOMv2usbDRIVER")
        TL.Enabled = traceState
        TL.LogMessage("Switch", "Starting initialisation")

        connectedState = False ' Initialise connected to false
        utilities = New Util() ' Initialise util object
        astroUtilities = New AstroUtils 'Initialise new astro utilities object

        'TODO: Implement your additional construction here

        TL.LogMessage("Switch", "Completed initialisation")
    End Sub

    '
    ' PUBLIC COM INTERFACE ISwitchV2 IMPLEMENTATION
    '

#Region "Common properties and methods"
    ''' <summary>
    ''' Displays the Setup Dialog form.
    ''' If the user clicks the OK button to dismiss the form, then
    ''' the new settings are saved, otherwise the old values are reloaded.
    ''' THIS IS THE ONLY PLACE WHERE SHOWING USER INTERFACE IS ALLOWED!
    ''' </summary>
    Public Sub SetupDialog() Implements ISwitchV2.SetupDialog
        ' consider only showing the setup dialog if not connected
        ' or call a different dialog if connected
        If IsConnected Then
            System.Windows.Forms.MessageBox.Show("Already connected, just press OK")
        End If

        Using F As SetupDialogForm = New SetupDialogForm()
            Dim result As System.Windows.Forms.DialogResult = F.ShowDialog()
            If result = DialogResult.OK Then
                WriteProfile() ' Persist device configuration values to the ASCOM Profile store
            End If
        End Using
    End Sub

    Public ReadOnly Property SupportedActions() As ArrayList Implements ISwitchV2.SupportedActions
        Get
            TL.LogMessage("SupportedActions Get", "Returning empty arraylist")
            Return New ArrayList()
        End Get
    End Property

    Public Function Action(ByVal ActionName As String, ByVal ActionParameters As String) As String Implements ISwitchV2.Action
        Throw New ActionNotImplementedException("Action " & ActionName & " is not supported by this driver")
    End Function

    Public Sub CommandBlind(ByVal Command As String, Optional ByVal Raw As Boolean = False) Implements ISwitchV2.CommandBlind
        CheckConnected("CommandBlind")
        ' TODO The optional CommandBlind method should either be implemented OR throw a MethodNotImplementedException
        ' If implemented, CommandBlind must send the supplied command to the mount And return immediately without waiting for a response

        Throw New MethodNotImplementedException("CommandBlind")
    End Sub

    Public Function CommandBool(ByVal Command As String, Optional ByVal Raw As Boolean = False) As Boolean _
        Implements ISwitchV2.CommandBool
        CheckConnected("CommandBool")
        ' TODO The optional CommandBool method should either be implemented OR throw a MethodNotImplementedException
        ' If implemented, CommandBool must send the supplied command to the mount, wait for a response and parse this to return a True Or False value

        ' Dim retString as String = CommandString(command, raw) ' Send the command And wait for the response
        ' Dim retBool as Boolean = XXXXXXXXXXXXX ' Parse the returned string And create a boolean True / False value
        ' Return retBool ' Return the boolean value to the client

        Throw New MethodNotImplementedException("CommandBool")
    End Function

    Public Function CommandString(ByVal Command As String, Optional ByVal Raw As Boolean = False) As String _
        Implements ISwitchV2.CommandString
        CheckConnected("CommandString")
        ' TODO The optional CommandString method should either be implemented OR throw a MethodNotImplementedException
        ' If implemented, CommandString must send the supplied command to the mount and wait for a response before returning this to the client

        Throw New MethodNotImplementedException("CommandString")
    End Function

    Public Property Connected() As Boolean Implements ISwitchV2.Connected
        Get
            TL.LogMessage("Connected Get", IsConnected.ToString())
            Return IsConnected
        End Get
        Set(value As Boolean)
            TL.LogMessage("Connected Set", value.ToString())
            If value = IsConnected Then
                Return
            End If

            If value Then
                connectedState = True
                TL.LogMessage("Connected Set", "Connecting to port " + comPort)
                ' TODO connect to the device
                objSerial = New ASCOM.Utilities.Serial
                Dim numComPort As String
                numComPort = comPort.Replace("COM", "")
                objSerial.Port = CShort(numComPort)
                objSerial.Speed = 9600
                objSerial.ReceiveTimeout = 5
                objSerial.Connected = True
                Threading.Thread.Sleep(CShort(ConnectionDelay))
                objSerial.ClearBuffers()
                If CShort(numSwitch) >= 1 Then
                    SwitchState0 = "OFF"
                ElseIf CShort(numSwitch) >= 2 Then
                    SwitchState1 = "OFF"
                ElseIf CShort(numSwitch) >= 3 Then
                    SwitchState2 = "OFF"
                ElseIf CShort(numSwitch) >= 4 Then
                    SwitchState3 = "OFF"
                ElseIf CShort(numSwitch) >= 5 Then
                    SwitchState4 = "OFF"
                ElseIf CShort(numSwitch) >= 6 Then
                    SwitchState5 = "OFF"
                ElseIf CShort(numSwitch) >= 7 Then
                    SwitchState6 = "OFF"
                ElseIf CShort(numSwitch) >= 8 Then
                    SwitchState7 = "OFF"
                Else
                    TL.LogMessage("Switch" + numSwitch.ToString(), "Invalid Value")
                    Throw New InvalidValueException("Switch", numSwitch.ToString(), String.Format("0 to {0}", numSwitches - 1))
                End If
            Else
                connectedState = False
                TL.LogMessage("Connected Set", "Disconnecting from port " + comPort)
                ' TODO disconnect from the device
                objSerial.Connected = False
            End If
        End Set
    End Property

    Public ReadOnly Property Description As String Implements ISwitchV2.Description
        Get
            ' this pattern seems to be needed to allow a public property to return a private field
            Dim d As String = driverDescription
            TL.LogMessage("Description Get", d)
            Return d
        End Get
    End Property

    Public ReadOnly Property DriverInfo As String Implements ISwitchV2.DriverInfo
        Get
            Dim m_version As Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
            ' TODO customise this driver description
            Dim s_driverInfo As String = "Information about the driver itself. Version: " + m_version.Major.ToString() + "." + m_version.Minor.ToString()
            TL.LogMessage("DriverInfo Get", s_driverInfo)
            Return s_driverInfo
        End Get
    End Property

    Public ReadOnly Property DriverVersion() As String Implements ISwitchV2.DriverVersion
        Get
            ' Get our own assembly and report its version number
            TL.LogMessage("DriverVersion Get", Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString(2))
            Return Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString(2)
        End Get
    End Property

    Public ReadOnly Property InterfaceVersion() As Short Implements ISwitchV2.InterfaceVersion
        Get
            TL.LogMessage("InterfaceVersion Get", "2")
            Return 2
        End Get
    End Property

    Public ReadOnly Property Name As String Implements ISwitchV2.Name
        Get
            Dim s_name As String = "wittinobiArduinoSwitchASCOMv2usbDRIVER"
            TL.LogMessage("Name Get", s_name)
            Return s_name
        End Get
    End Property

    Public Sub Dispose() Implements ISwitchV2.Dispose
        ' Clean up the trace logger and util objects
        TL.Enabled = False
        TL.Dispose()
        TL = Nothing
        utilities.Dispose()
        utilities = Nothing
        astroUtilities.Dispose()
        astroUtilities = Nothing
        objSerial.Dispose()
        objSerial = Nothing
    End Sub

#End Region

#Region "ISwitchV2 Implementation"

    Dim numSwitches As Short = CShort(numSwitch)

    ''' <summary>
    ''' The number of switches managed by this driver
    ''' </summary>
    Public ReadOnly Property MaxSwitch As Short Implements ISwitchV2.MaxSwitch
        Get
            TL.LogMessage("MaxSwitch Get", numSwitches.ToString())
            Return numSwitches
        End Get
    End Property

    ''' <summary>
    ''' Return the name of switch n
    ''' </summary>
    ''' <param name="id">The switch number to return</param>
    ''' <returns>The name of the switch</returns>
    Public Function GetSwitchName(id As Short) As String Implements ISwitchV2.GetSwitchName
        Validate("GetSwitchName", id)
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Switch"
            If id = 0 And CShort(numSwitch) >= 1 Then
                TL.LogMessage("GetSwitchName " + id.ToString(), SwitchName0)
                Return SwitchName0
            ElseIf id = 1 And CShort(numSwitch) >= 2 Then
                TL.LogMessage("GetSwitchName " + id.ToString(), SwitchName1)
                Return SwitchName1
            ElseIf id = 2 And CShort(numSwitch) >= 3 Then
                TL.LogMessage("GetSwitchName " + id.ToString(), SwitchName2)
                Return SwitchName2
            ElseIf id = 3 And CShort(numSwitch) >= 4 Then
                TL.LogMessage("GetSwitchName " + id.ToString(), SwitchName3)
                Return SwitchName3
            ElseIf id = 4 And CShort(numSwitch) >= 5 Then
                TL.LogMessage("GetSwitchName " + id.ToString(), SwitchName4)
                Return SwitchName4
            ElseIf id = 5 And CShort(numSwitch) >= 6 Then
                TL.LogMessage("GetSwitchName " + id.ToString(), SwitchName5)
                Return SwitchName5
            ElseIf id = 6 And CShort(numSwitch) >= 7 Then
                TL.LogMessage("GetSwitchName " + id.ToString(), SwitchName6)
                Return SwitchName6
            ElseIf id = 7 And CShort(numSwitch) >= 8 Then
                TL.LogMessage("GetSwitchName " + id.ToString(), SwitchName7)
                Return SwitchName7
            Else
                TL.LogMessage("GetSwitchName" + id.ToString(), "Invalid Value")
                Throw New InvalidValueException("GetSwitchName", id.ToString(), String.Format("0 to {0}", numSwitches - 1))
            End If
        End Using
    End Function

    ''' <summary>
    ''' Sets a switch name to a specified value
    ''' </summary>
    ''' <param name="id">The number of the switch whose name is to be set</param>
    ''' <param name="name">The name of the switch</param>
    Sub SetSwitchName(id As Short, name As String) Implements ISwitchV2.SetSwitchName
        Validate("SetSwitchName", id)
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Switch"
            If id = 0 And CShort(numSwitch) >= 1 Then
                TL.LogMessage("SetSwitchName " + id.ToString(), name)
                SwitchName0 = name
                driverProfile.WriteValue(driverID, SwitchName0ProfileName, SwitchName0.ToString(), "Switch0")
            ElseIf id = 1 And CShort(numSwitch) >= 2 Then
                TL.LogMessage("SetSwitchName " + id.ToString(), name)
                SwitchName1 = name
                driverProfile.WriteValue(driverID, SwitchName1ProfileName, SwitchName1.ToString(), "Switch1")
            ElseIf id = 2 And CShort(numSwitch) >= 3 Then
                TL.LogMessage("SetSwitchName " + id.ToString(), name)
                SwitchName2 = name
                driverProfile.WriteValue(driverID, SwitchName2ProfileName, SwitchName2.ToString(), "Switch2")
            ElseIf id = 3 And CShort(numSwitch) >= 4 Then
                TL.LogMessage("SetSwitchName " + id.ToString(), name)
                SwitchName3 = name
                driverProfile.WriteValue(driverID, SwitchName3ProfileName, SwitchName3.ToString(), "Switch3")
            ElseIf id = 4 And CShort(numSwitch) >= 5 Then
                TL.LogMessage("SetSwitchName " + id.ToString(), name)
                SwitchName4 = name
                driverProfile.WriteValue(driverID, SwitchName4ProfileName, SwitchName4.ToString(), "Switch4")
            ElseIf id = 5 And CShort(numSwitch) >= 6 Then
                TL.LogMessage("SetSwitchName " + id.ToString(), name)
                SwitchName5 = name
                driverProfile.WriteValue(driverID, SwitchName5ProfileName, SwitchName5.ToString(), "Switch5")
            ElseIf id = 6 And CShort(numSwitch) >= 7 Then
                TL.LogMessage("SetSwitchName " + id.ToString(), name)
                SwitchName6 = name
                driverProfile.WriteValue(driverID, SwitchName6ProfileName, SwitchName6.ToString(), "Switch6")
            ElseIf id = 7 And CShort(numSwitch) >= 8 Then
                TL.LogMessage("SetSwitchName " + id.ToString(), name)
                SwitchName7 = name
                driverProfile.WriteValue(driverID, SwitchName7ProfileName, SwitchName7.ToString(), "Switch7")
            Else
                TL.LogMessage("SetSwitchName" + id.ToString(), "Invalid Value")
                Throw New InvalidValueException("SetSwitchName", id.ToString(), String.Format("0 to {0}", numSwitches - 1))
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Gets the description of the specified switch. This is to allow a fuller description of the switch to be returned, for example for a tool tip.
    ''' </summary>
    ''' <param name="id">The number of the switch whose description is to be returned</param><returns></returns>
    ''' <exception cref="InvalidValueException">If id is outside the range 0 to MaxSwitch - 1</exception>
    Public Function GetSwitchDescription(id As Short) As String Implements ISwitchV2.GetSwitchDescription
        Validate("GetSwitchDescription", id)
        TL.LogMessage("GetSwitchDescription " + id.ToString(), "Relay " + id.ToString())
        Dim s_GetSwitchDescription As String = "Relay" + id.ToString()
        Return s_GetSwitchDescription
    End Function

    ''' <summary>
    ''' Reports if the specified switch can be written to.
    ''' This is false if the switch cannot be written to, for example a limit switch or a sensor.
    ''' </summary>
    ''' <param name="id">The number of the switch whose write state is to be returned</param>
    ''' <returns>
    ''' <c>true</c> if the switch can be set, otherwise <c>false</c>.
    ''' </returns>
    ''' <exception cref="MethodNotImplementedException">If the method is not implemented</exception>
    ''' <exception cref="InvalidValueException">If id is outside the range 0 to MaxSwitch - 1</exception>
    Public Function CanWrite(id As Short) As Boolean Implements ISwitchV2.CanWrite
        Validate("CanWrite", id)
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Switch"
            If id = 0 And CShort(numSwitch) >= 1 Then
                If CanWrite0 = "NO" Then
                    TL.LogMessage("CanWrite " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("CanWrite " + id.ToString(), "True")
                    Return True
                End If
            ElseIf id = 1 And CShort(numSwitch) >= 2 Then
                If CanWrite1 = "NO" Then
                    TL.LogMessage("CanWrite " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("CanWrite " + id.ToString(), "True")
                    Return True
                End If
            ElseIf id = 2 And CShort(numSwitch) >= 3 Then
                If CanWrite2 = "NO" Then
                    TL.LogMessage("CanWrite " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("CanWrite " + id.ToString(), "True")
                    Return True
                End If
            ElseIf id = 3 And CShort(numSwitch) >= 4 Then
                If CanWrite3 = "NO" Then
                    TL.LogMessage("CanWrite " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("CanWrite " + id.ToString(), "True")
                    Return True
                End If
            ElseIf id = 4 And CShort(numSwitch) >= 5 Then
                If CanWrite4 = "NO" Then
                    TL.LogMessage("CanWrite " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("CanWrite " + id.ToString(), "True")
                    Return True
                End If
            ElseIf id = 5 And CShort(numSwitch) >= 6 Then
                If CanWrite5 = "NO" Then
                    TL.LogMessage("CanWrite " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("CanWrite " + id.ToString(), "True")
                    Return True
                End If
            ElseIf id = 6 And CShort(numSwitch) >= 7 Then
                If CanWrite6 = "NO" Then
                    TL.LogMessage("CanWrite " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("CanWrite " + id.ToString(), "True")
                    Return True
                End If
            ElseIf id = 7 And CShort(numSwitch) >= 8 Then
                If CanWrite7 = "NO" Then
                    TL.LogMessage("CanWrite " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("CanWrite " + id.ToString(), "True")
                    Return True
                End If
            Else
                TL.LogMessage("CanWrite" + id.ToString(), "Invalid Value")
                Throw New InvalidValueException("CanWrite", id.ToString(), String.Format("0 to {0}", numSwitches - 1))
            End If
        End Using
    End Function

#Region "boolean members"
    ''' <summary>
    ''' Return the state of switch n as a boolean.
    ''' A multi-value switch must throw a MethodNotImplementedException.
    ''' </summary>
    ''' <param name="id">The switch number to return</param>
    ''' <returns>True or false</returns>
    Function GetSwitch(id As Short) As Boolean Implements ISwitchV2.GetSwitch
        Validate("GetSwitch", id, True)
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Switch"
            If id = 0 And CShort(numSwitch) >= 1 Then
                If SwitchState0 = "OFF" Then
                    TL.LogMessage("GetSwitch " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("GetSwitch " + id.ToString(), "True")
                    Return True
                End If
            ElseIf id = 1 And CShort(numSwitch) >= 2 Then
                If SwitchState1 = "OFF" Then
                    TL.LogMessage("GetSwitch " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("GetSwitch " + id.ToString(), "True")
                    Return True
                End If
            ElseIf id = 2 And CShort(numSwitch) >= 3 Then
                If SwitchState2 = "OFF" Then
                    TL.LogMessage("GetSwitch " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("GetSwitch " + id.ToString(), "True")
                    Return True
                End If
            ElseIf id = 3 And CShort(numSwitch) >= 4 Then
                If SwitchState3 = "OFF" Then
                    TL.LogMessage("GetSwitch " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("GetSwitch " + id.ToString(), "True")
                    Return True
                End If
            ElseIf id = 4 And CShort(numSwitch) >= 5 Then
                If SwitchState4 = "OFF" Then
                    TL.LogMessage("GetSwitch " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("GetSwitch " + id.ToString(), "True")
                    Return True
                End If
            ElseIf id = 5 And CShort(numSwitch) >= 6 Then
                If SwitchState5 = "OFF" Then
                    TL.LogMessage("GetSwitch " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("GetSwitch " + id.ToString(), "True")
                    Return True
                End If
            ElseIf id = 6 And CShort(numSwitch) >= 7 Then
                If SwitchState6 = "OFF" Then
                    TL.LogMessage("GetSwitch " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("GetSwitch " + id.ToString(), "True")
                    Return True
                End If
            ElseIf id = 7 And CShort(numSwitch) >= 8 Then
                If SwitchState7 = "OFF" Then
                    TL.LogMessage("GetSwitch " + id.ToString(), "False")
                    Return False
                Else
                    TL.LogMessage("GetSwitch " + id.ToString(), "True")
                    Return True
                End If
            Else
                TL.LogMessage("GetSwitch" + id.ToString(), "Invalid Value")
                Throw New InvalidValueException("GetSwitch", id.ToString(), String.Format("0 to {0}", numSwitches - 1))
            End If
        End Using
    End Function

    ''' <summary>
    ''' Sets a switch to the specified state, true or false.
    ''' If the switch cannot be set then throws a MethodNotImplementedException.
    ''' </summary>
    ''' <param name="ID">The number of the switch to set</param>
    ''' <param name="State">The required switch state</param>
    Sub SetSwitch(id As Short, state As Boolean) Implements ISwitchV2.SetSwitch
        Validate("SetSwitch", id, True)
        If state = False Then
            TL.LogMessage("SetSwitch", id.ToString(), state.ToString())
            Using driverProfile As New Profile()
                driverProfile.DeviceType = "Switch"
                If id = 0 And CShort(numSwitch) >= 1 Then
                    SwitchState0 = "OFF"
                    driverProfile.WriteValue(driverID, SwitchState0ProfileName, SwitchState0.ToString(), "Switch0")
                    Dim numSetSwitch As String
                    numSetSwitch = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                ElseIf id = 1 And CShort(numSwitch) >= 2 Then
                    SwitchState1 = "OFF"
                    driverProfile.WriteValue(driverID, SwitchState1ProfileName, SwitchState1.ToString(), "Switch1")
                    Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                ElseIf id = 2 And CShort(numSwitch) >= 3 Then
                    SwitchState2 = "OFF"
                    driverProfile.WriteValue(driverID, SwitchState2ProfileName, SwitchState2.ToString(), "Switch2")
                    Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                ElseIf id = 3 And CShort(numSwitch) >= 4 Then
                    SwitchState3 = "OFF"
                    driverProfile.WriteValue(driverID, SwitchState3ProfileName, SwitchState3.ToString(), "Switch3")
                    Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                ElseIf id = 4 And CShort(numSwitch) >= 5 Then
                    SwitchState4 = "OFF"
                    driverProfile.WriteValue(driverID, SwitchState4ProfileName, SwitchState4.ToString(), "Switch4")
                    Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                ElseIf id = 5 And CShort(numSwitch) >= 6 Then
                    SwitchState5 = "OFF"
                    driverProfile.WriteValue(driverID, SwitchState5ProfileName, SwitchState5.ToString(), "Switch5")
                    Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                ElseIf id = 6 And CShort(numSwitch) >= 7 Then
                    SwitchState6 = "OFF"
                    driverProfile.WriteValue(driverID, SwitchState6ProfileName, SwitchState6.ToString(), "Switch6")
                    Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                ElseIf id = 7 And CShort(numSwitch) >= 8 Then
                    SwitchState7 = "OFF"
                    driverProfile.WriteValue(driverID, SwitchState7ProfileName, SwitchState7.ToString(), "Switch7")
                    Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                Else
                    TL.LogMessage("SetSwitch" + id.ToString(), "Invalid Value")
                    Throw New InvalidValueException("SetSwitch", id.ToString(), String.Format("0 to {0}", numSwitches - 1))
                End If
            End Using
        ElseIf state = True Then
            TL.LogMessage("SetSwitch", id.ToString(), state.ToString())
            Using driverProfile As New Profile()
                driverProfile.DeviceType = "Switch"
                If id = 0 And CShort(numSwitch) >= 1 Then
                    SwitchState0 = "ON"
                    driverProfile.WriteValue(driverID, SwitchState0ProfileName, SwitchState0.ToString(), "Switch0")
                    Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                ElseIf id = 1 And CShort(numSwitch) >= 2 Then
                    SwitchState1 = "ON"
                    driverProfile.WriteValue(driverID, SwitchState1ProfileName, SwitchState1.ToString(), "Switch1")
                    Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                ElseIf id = 2 And CShort(numSwitch) >= 3 Then
                    SwitchState2 = "ON"
                    driverProfile.WriteValue(driverID, SwitchState2ProfileName, SwitchState2.ToString(), "Switch2")
                    Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                ElseIf id = 3 And CShort(numSwitch) >= 4 Then
                    SwitchState3 = "ON"
                    driverProfile.WriteValue(driverID, SwitchState3ProfileName, SwitchState3.ToString(), "Switch3")
                    Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                ElseIf id = 4 And CShort(numSwitch) >= 5 Then
                    SwitchState4 = "ON"
                    driverProfile.WriteValue(driverID, SwitchState4ProfileName, SwitchState4.ToString(), "Switch4")
                    Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                ElseIf id = 5 And CShort(numSwitch) >= 6 Then
                    SwitchState5 = "ON"
                    driverProfile.WriteValue(driverID, SwitchState5ProfileName, SwitchState5.ToString(), "Switch5")
                    Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                ElseIf id = 6 And CShort(numSwitch) >= 7 Then
                    SwitchState6 = "ON"
                    driverProfile.WriteValue(driverID, SwitchState6ProfileName, SwitchState6.ToString(), "Switch6")
                    Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                ElseIf id = 7 And CShort(numSwitch) >= 8 Then
                    SwitchState7 = "ON"
                    driverProfile.WriteValue(driverID, SwitchState7ProfileName, SwitchState7.ToString(), "Switch7")
                    Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                    objSerial.Transmit(numSetSwitch)
                    objSerial.ReceiveTerminated("#")
                Else
                    TL.LogMessage("SetSwitch" + id.ToString(), "Invalid Value")
                    Throw New InvalidValueException("SetSwitch", id.ToString(), String.Format("0 to {0}", numSwitches - 1))
                End If
            End Using
        Else
            TL.LogMessage("SetSwitch", "Not Implemented")
            Throw New ASCOM.MethodNotImplementedException("SetSwitch")
        End If
    End Sub

#End Region

#Region "Analogue members"
    ''' <summary>
    ''' Returns the maximum analogue value for this switch
    ''' Boolean switches must return 1.0
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Function MaxSwitchValue(id As Short) As Double Implements ISwitchV2.MaxSwitchValue
        Validate("MaxSwitchValue", id)
        If CanWrite(id) = True Then
            TL.LogMessage("MaxSwitchValue", "1")
            Return 1
        Else
            TL.LogMessage("MaxSwitchValue", "100")
            Return 100
        End If
    End Function

    ''' <summary>
    ''' Returns the minimum analogue value for this switch
    ''' Boolean switches must return 0.0
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Function MinSwitchValue(id As Short) As Double Implements ISwitchV2.MinSwitchValue
        Validate("MinSwitchValue", id)
        If CanWrite(id) = True Then
            TL.LogMessage("MinSwitchValue", "0")
            Return 0
        Else
            TL.LogMessage("MinSwitchValue", "0")
            Return 0
        End If
    End Function

    ''' <summary>
    ''' returns the step size that this switch supports. This gives the difference between successive values of the switch.
    ''' The number of values is ((MaxSwitchValue - MinSwitchValue) / SwitchStep) + 1
    ''' boolean switches must return 1.0, giving two states.
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Function SwitchStep(id As Short) As Double Implements ISwitchV2.SwitchStep
        Validate("SwitchStep", id)
        If CanWrite(id) = True Then
            TL.LogMessage("SwitchStep", "1")
            Return 1
        Else
            TL.LogMessage("SwitchStep", "1")
            Return 1
        End If
    End Function

    ''' <summary>
    ''' Returns the analogue switch value for switch id
    ''' Boolean switches must throw a MethodNotImplementedException
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Function GetSwitchValue(id As Short) As Double Implements ISwitchV2.GetSwitchValue
        Validate("GetSwitchValue", id, True)
        If (MaxSwitchValue(id) - MinSwitchValue(id) / SwitchStep(id) + 1) = 1.0 Then
            TL.LogMessage("GetSwitchValue", "Not Implemented")
            Throw New MethodNotImplementedException("GetSwitchValue")
        Else
            Using driverProfile As New Profile()
                driverProfile.DeviceType = "Switch"
                If id = 0 And CShort(numSwitch) >= 1 Then
                    TL.LogMessage("GetSwitchValue " + id.ToString(), SwitchValue0)
                    Return SwitchValue0
                ElseIf id = 1 And CShort(numSwitch) >= 2 Then
                    TL.LogMessage("GetSwitchValue " + id.ToString(), SwitchValue1)
                    Return SwitchValue1
                ElseIf id = 2 And CShort(numSwitch) >= 3 Then
                    TL.LogMessage("GetSwitchValue " + id.ToString(), SwitchValue2)
                    Return SwitchValue2
                ElseIf id = 3 And CShort(numSwitch) >= 4 Then
                    TL.LogMessage("GetSwitchValue " + id.ToString(), SwitchValue3)
                    Return SwitchValue3
                ElseIf id = 4 And CShort(numSwitch) >= 5 Then
                    TL.LogMessage("GetSwitchValue " + id.ToString(), SwitchValue4)
                    Return SwitchValue4
                ElseIf id = 5 And CShort(numSwitch) >= 6 Then
                    TL.LogMessage("GetSwitchValue " + id.ToString(), SwitchValue5)
                    Return SwitchValue5
                ElseIf id = 6 And CShort(numSwitch) >= 7 Then
                    TL.LogMessage("GetSwitchValue " + id.ToString(), SwitchValue6)
                    Return SwitchValue6
                ElseIf id = 7 And CShort(numSwitch) >= 8 Then
                    TL.LogMessage("GetSwitchValue " + id.ToString(), SwitchValue7)
                    Return SwitchValue7
                Else
                    TL.LogMessage("GetSwitchValue" + id.ToString(), "Invalid Value")
                    Throw New InvalidValueException("GetSwitchValue", id.ToString(), String.Format("0 to {0}", numSwitches - 1))
                End If
            End Using
        End If
    End Function

    ''' <summary>
    ''' Set the analogue value for this switch.
    ''' A MethodNotImplementedException should be thrown if CanWrite returns False
    ''' If the value is not between the maximum and minimum then throws an InvalidValueException
    ''' boolean switches must throw a MethodNotImplementedException
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="value"></param>
    Sub SetSwitchValue(id As Short, value As Double) Implements ISwitchV2.SetSwitchValue
        Validate("SetSwitchValue", id, True)
        If CanWrite(id) = False Then
            TL.LogMessage("SetSwitchValue", "Not Implemented")
            Throw New MethodNotImplementedException("SetSwitchValue")
        Else
            If value < MinSwitchValue(id) Or value > MaxSwitchValue(id) Then
                Throw New InvalidValueException("", value.ToString(), String.Format("{0} to {1}", MinSwitchValue(id), MaxSwitchValue(id)))
            ElseIf (MaxSwitchValue(id) - MinSwitchValue(id) / SwitchStep(id) + 1) = 1.0 Then
                TL.LogMessage("SetSwitchValue", "Not Implemented")
                Throw New MethodNotImplementedException("SetSwitchValue")
            Else
                Using driverProfile As New Profile()
                    driverProfile.DeviceType = "Switch"
                    If id = 0 And CShort(numSwitch) >= 1 Then
                        SwitchValue0 = value
                        TL.LogMessage("SetSwitchValue ", id.ToString(), SwitchValue0.ToString())
                        If value = MinSwitchValue(id) Then
                            SwitchState0 = "OFF"
                            driverProfile.WriteValue(driverID, SwitchState0ProfileName, SwitchState0.ToString(), "Switch0")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        Else
                            SwitchState0 = "ON"
                            driverProfile.WriteValue(driverID, SwitchState0ProfileName, SwitchState0.ToString(), "Switch0")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        End If
                        driverProfile.WriteValue(driverID, SwitchValue0ProfileName, SwitchValue0.ToString(), "Switch0")
                        driverProfile.WriteValue(driverID, SwitchState0ProfileName, SwitchState0.ToString(), "Switch0")
                    ElseIf id = 1 And CShort(numSwitch) >= 2 Then
                        SwitchValue1 = value
                        TL.LogMessage("SetSwitchValue ", id.ToString(), SwitchValue1.ToString())
                        If value = MinSwitchValue(id) Then
                            SwitchState1 = "OFF"
                            driverProfile.WriteValue(driverID, SwitchState1ProfileName, SwitchState1.ToString(), "Switch1")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        Else
                            SwitchState1 = "ON"
                            driverProfile.WriteValue(driverID, SwitchState1ProfileName, SwitchState1.ToString(), "Switch1")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        End If
                        driverProfile.WriteValue(driverID, SwitchValue1ProfileName, SwitchValue1.ToString(), "Switch1")
                        driverProfile.WriteValue(driverID, SwitchState1ProfileName, SwitchState1.ToString(), "Switch1")
                    ElseIf id = 2 And CShort(numSwitch) >= 3 Then
                        SwitchValue2 = value
                        TL.LogMessage("SetSwitchValue ", id.ToString(), SwitchValue2.ToString())
                        If value = MinSwitchValue(id) Then
                            SwitchState2 = "OFF"
                            driverProfile.WriteValue(driverID, SwitchState2ProfileName, SwitchState2.ToString(), "Switch2")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        Else
                            SwitchState2 = "ON"
                            driverProfile.WriteValue(driverID, SwitchState2ProfileName, SwitchState2.ToString(), "Switch2")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        End If
                        driverProfile.WriteValue(driverID, SwitchValue2ProfileName, SwitchValue2.ToString(), "Switch2")
                        driverProfile.WriteValue(driverID, SwitchState2ProfileName, SwitchState2.ToString(), "Switch2")
                    ElseIf id = 3 And CShort(numSwitch) >= 4 Then
                        SwitchValue3 = value
                        TL.LogMessage("SetSwitchValue ", id.ToString(), SwitchValue3.ToString())
                        If value = MinSwitchValue(id) Then
                            SwitchState3 = "OFF"
                            driverProfile.WriteValue(driverID, SwitchState3ProfileName, SwitchState3.ToString(), "Switch3")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        Else
                            SwitchState3 = "ON"
                            driverProfile.WriteValue(driverID, SwitchState3ProfileName, SwitchState3.ToString(), "Switch3")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        End If
                        driverProfile.WriteValue(driverID, SwitchValue3ProfileName, SwitchValue3.ToString(), "Switch3")
                        driverProfile.WriteValue(driverID, SwitchState3ProfileName, SwitchState3.ToString(), "Switch3")
                    ElseIf id = 4 And CShort(numSwitch) >= 5 Then
                        SwitchValue4 = value
                        TL.LogMessage("SetSwitchValue ", id.ToString(), SwitchValue4.ToString())
                        If value = MinSwitchValue(id) Then
                            SwitchState4 = "OFF"
                            driverProfile.WriteValue(driverID, SwitchState4ProfileName, SwitchState4.ToString(), "Switch4")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        Else
                            SwitchState4 = "ON"
                            driverProfile.WriteValue(driverID, SwitchState4ProfileName, SwitchState4.ToString(), "Switch4")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        End If
                        driverProfile.WriteValue(driverID, SwitchValue4ProfileName, SwitchValue4.ToString(), "Switch4")
                        driverProfile.WriteValue(driverID, SwitchState4ProfileName, SwitchState4.ToString(), "Switch4")
                    ElseIf id = 5 And CShort(numSwitch) >= 6 Then
                        SwitchValue5 = value
                        TL.LogMessage("SetSwitchValue ", id.ToString(), SwitchValue5.ToString())
                        If value = MinSwitchValue(id) Then
                            SwitchState5 = "OFF"
                            driverProfile.WriteValue(driverID, SwitchState5ProfileName, SwitchState5.ToString(), "Switch5")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        Else
                            SwitchState5 = "ON"
                            driverProfile.WriteValue(driverID, SwitchState5ProfileName, SwitchState5.ToString(), "Switch5")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        End If
                        driverProfile.WriteValue(driverID, SwitchValue5ProfileName, SwitchValue5.ToString(), "Switch5")
                        driverProfile.WriteValue(driverID, SwitchState5ProfileName, SwitchState5.ToString(), "Switch5")
                    ElseIf id = 6 And CShort(numSwitch) >= 7 Then
                        SwitchValue6 = value
                        TL.LogMessage("SetSwitchValue ", id.ToString(), SwitchValue6.ToString())
                        If value = MinSwitchValue(id) Then
                            SwitchState6 = "OFF"
                            driverProfile.WriteValue(driverID, SwitchState6ProfileName, SwitchState6.ToString(), "Switch6")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        Else
                            SwitchState6 = "ON"
                            driverProfile.WriteValue(driverID, SwitchState6ProfileName, SwitchState6.ToString(), "Switch6")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        End If
                        driverProfile.WriteValue(driverID, SwitchValue6ProfileName, SwitchValue6.ToString(), "Switch6")
                        driverProfile.WriteValue(driverID, SwitchState6ProfileName, SwitchState6.ToString(), "Switch6")
                    ElseIf id = 7 And CShort(numSwitch) >= 8 Then
                        SwitchValue7 = value
                        TL.LogMessage("SetSwitchValue ", id.ToString(), SwitchValue7.ToString())
                        If value = MinSwitchValue(id) Then
                            SwitchState7 = "OFF"
                            driverProfile.WriteValue(driverID, SwitchState7ProfileName, SwitchState7.ToString(), "Switch7")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_0#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        Else
                            SwitchState7 = "ON"
                            driverProfile.WriteValue(driverID, SwitchState7ProfileName, SwitchState7.ToString(), "Switch7")
                            Dim numSetSwitch As String = ("SETSTATUSRELAY" + id.ToString() + "_1#")
                            objSerial.Transmit(numSetSwitch)
                            objSerial.ReceiveTerminated("#")
                        End If
                        driverProfile.WriteValue(driverID, SwitchValue7ProfileName, SwitchValue7.ToString(), "Switch7")
                        driverProfile.WriteValue(driverID, SwitchState7ProfileName, SwitchState7.ToString(), "Switch7")
                    Else
                        TL.LogMessage("SetSwitchValue" + id.ToString(), "Invalid Value")
                        Throw New InvalidValueException("SetSwitchValue", id.ToString(), String.Format("0 to {0}", numSwitches - 1))
                    End If
                End Using
            End If
        End If
    End Sub

#End Region

#End Region

#Region "Private methods"

    ''' <summary>
    ''' Checks that the switch id is in range and throws an InvalidValueException if it isn't
    ''' </summary>
    ''' <param name="message">The message.</param>
    ''' <param name="id">The id.</param>
    Private Sub Validate(message As String, id As Short)
        If (id < 0 Or id >= numSwitches) Then
            Throw New InvalidValueException(message, id.ToString(), String.Format("0 to {0}", numSwitches - 1))
        End If
    End Sub

    ''' <summary>
    ''' Checks that the number of states for the switch is correct and throws a methodNotImplemented exception if not.
    ''' Boolean switches must have 2 states and multi-value switches more than 2.
    ''' </summary>
    ''' <param name="message"></param>
    ''' <param name="id"></param>
    ''' <param name="expectBoolean"></param>
    Private Sub Validate(message As String, id As Short, expectBoolean As Boolean)
        Validate(message, id)
        Dim ns As Integer = (((MaxSwitchValue(id) - MinSwitchValue(id)) / SwitchStep(id)) + 1)
        If (expectBoolean And ns <> 2) Or (Not expectBoolean And ns <= 2) Then
            TL.LogMessage(message, String.Format("Switch {0} has the wrong number of states", id, ns))
            Throw New MethodNotImplementedException(String.Format("{0}({1})", message, id))
        End If
    End Sub

    ''' <summary>
    ''' Checks that the switch id and value are in range and throws an
    ''' InvalidValueException if they are not.
    ''' </summary>
    ''' <param name="message">The message.</param>
    ''' <param name="id">The id.</param>
    ''' <param name="value">The value.</param>
    Private Sub Validate(message As String, id As Short, value As Double)
        Validate(message, id, False)
        Dim min = MinSwitchValue(id)
        Dim max = MaxSwitchValue(id)
        If (value < min Or value > max) Then
            TL.LogMessage(message, String.Format("Value {1} for Switch {0} is out of the allowed range {2} to {3}", id, value, min, max))
            Throw New InvalidValueException(message, value.ToString(), String.Format("Switch({0}) range {1} to {2}", id, min, max))
        End If
    End Sub
#End Region

#Region "Private properties and methods"
    ' here are some useful properties and methods that can be used as required
    ' to help with

#Region "ASCOM Registration"

    Private Shared Sub RegUnregASCOM(ByVal bRegister As Boolean)

        Using P As New Profile() With {.DeviceType = "Switch"}
            If bRegister Then
                P.Register(driverID, driverDescription)
            Else
                P.Unregister(driverID)
            End If
        End Using

    End Sub

    <ComRegisterFunction()>
    Public Shared Sub RegisterASCOM(ByVal T As Type)

        RegUnregASCOM(True)

    End Sub

    <ComUnregisterFunction()>
    Public Shared Sub UnregisterASCOM(ByVal T As Type)

        RegUnregASCOM(False)

    End Sub

#End Region

    ''' <summary>
    ''' Returns true if there is a valid connection to the driver hardware
    ''' </summary>
    Private ReadOnly Property IsConnected As Boolean
        Get
            ' TODO check that the driver hardware connection exists and is connected to the hardware
            If Not objSerial Is Nothing Then
                If objSerial.Connected Then
                    connectedState = True
                Else
                    connectedState = False
                End If
            Else
                connectedState = False
            End If
            Return connectedState
        End Get
    End Property

    ''' <summary>
    ''' Use this function to throw an exception if we aren't connected to the hardware
    ''' </summary>
    ''' <param name="message"></param>
    Private Sub CheckConnected(ByVal message As String)
        If Not IsConnected Then
            Throw New NotConnectedException(message)
        End If
    End Sub

    ''' <summary>
    ''' Read the device configuration from the ASCOM Profile store
    ''' </summary>
    Friend Sub ReadProfile()
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Switch"
            traceState = Convert.ToBoolean(driverProfile.GetValue(driverID, traceStateProfileName, String.Empty, traceStateDefault))
            comPort = driverProfile.GetValue(driverID, comPortProfileName, String.Empty, comPortDefault)
            ConnectionDelay = driverProfile.GetValue(driverID, ConnectionDelayProfileName, String.Empty, ConnectionDelayDefault)
            numSwitch = driverProfile.GetValue(driverID, numSwitchProfileName, String.Empty, numSwitchDefault)
            SwitchName0 = driverProfile.GetValue(driverID, SwitchName0ProfileName, "Switch0", SwitchName0Default)
            SwitchName1 = driverProfile.GetValue(driverID, SwitchName1ProfileName, "Switch1", SwitchName1Default)
            SwitchName2 = driverProfile.GetValue(driverID, SwitchName2ProfileName, "Switch2", SwitchName2Default)
            SwitchName3 = driverProfile.GetValue(driverID, SwitchName3ProfileName, "Switch3", SwitchName3Default)
            SwitchName4 = driverProfile.GetValue(driverID, SwitchName4ProfileName, "Switch4", SwitchName4Default)
            SwitchName5 = driverProfile.GetValue(driverID, SwitchName5ProfileName, "Switch5", SwitchName5Default)
            SwitchName6 = driverProfile.GetValue(driverID, SwitchName6ProfileName, "Switch6", SwitchName6Default)
            SwitchName7 = driverProfile.GetValue(driverID, SwitchName7ProfileName, "Switch7", SwitchName7Default)
            CanWrite0 = driverProfile.GetValue(driverID, CanWrite0ProfileName, "Switch0", CanWrite0Default)
            CanWrite1 = driverProfile.GetValue(driverID, CanWrite1ProfileName, "Switch1", CanWrite1Default)
            CanWrite2 = driverProfile.GetValue(driverID, CanWrite2ProfileName, "Switch2", CanWrite2Default)
            CanWrite3 = driverProfile.GetValue(driverID, CanWrite3ProfileName, "Switch3", CanWrite3Default)
            CanWrite4 = driverProfile.GetValue(driverID, CanWrite4ProfileName, "Switch4", CanWrite4Default)
            CanWrite5 = driverProfile.GetValue(driverID, CanWrite5ProfileName, "Switch5", CanWrite5Default)
            CanWrite6 = driverProfile.GetValue(driverID, CanWrite6ProfileName, "Switch6", CanWrite6Default)
            CanWrite7 = driverProfile.GetValue(driverID, CanWrite7ProfileName, "Switch7", CanWrite7Default)
            SwitchValue0 = driverProfile.GetValue(driverID, SwitchValue0ProfileName, "Switch0", SwitchValue0Default)
            SwitchValue1 = driverProfile.GetValue(driverID, SwitchValue1ProfileName, "Switch1", SwitchValue1Default)
            SwitchValue2 = driverProfile.GetValue(driverID, SwitchValue2ProfileName, "Switch2", SwitchValue2Default)
            SwitchValue3 = driverProfile.GetValue(driverID, SwitchValue3ProfileName, "Switch3", SwitchValue3Default)
            SwitchValue4 = driverProfile.GetValue(driverID, SwitchValue4ProfileName, "Switch4", SwitchValue4Default)
            SwitchValue5 = driverProfile.GetValue(driverID, SwitchValue5ProfileName, "Switch5", SwitchValue5Default)
            SwitchValue6 = driverProfile.GetValue(driverID, SwitchValue6ProfileName, "Switch6", SwitchValue6Default)
            SwitchValue7 = driverProfile.GetValue(driverID, SwitchValue7ProfileName, "Switch7", SwitchValue7Default)
            SwitchState0 = driverProfile.GetValue(driverID, SwitchState0ProfileName, "Switch0", SwitchState0Default)
            SwitchState1 = driverProfile.GetValue(driverID, SwitchState1ProfileName, "Switch1", SwitchState1Default)
            SwitchState2 = driverProfile.GetValue(driverID, SwitchState2ProfileName, "Switch2", SwitchState2Default)
            SwitchState3 = driverProfile.GetValue(driverID, SwitchState3ProfileName, "Switch3", SwitchState3Default)
            SwitchState4 = driverProfile.GetValue(driverID, SwitchState4ProfileName, "Switch4", SwitchState4Default)
            SwitchState5 = driverProfile.GetValue(driverID, SwitchState5ProfileName, "Switch5", SwitchState5Default)
            SwitchState6 = driverProfile.GetValue(driverID, SwitchState6ProfileName, "Switch6", SwitchState6Default)
            SwitchState7 = driverProfile.GetValue(driverID, SwitchState7ProfileName, "Switch7", SwitchState7Default)
        End Using
    End Sub

    ''' <summary>
    ''' Write the device configuration to the  ASCOM  Profile store
    ''' </summary>
    Friend Sub WriteProfile()
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Switch"
            driverProfile.WriteValue(driverID, traceStateProfileName, traceState.ToString())
            If comPort IsNot Nothing Then
                driverProfile.WriteValue(driverID, comPortProfileName, comPort.ToString())
            End If
            driverProfile.WriteValue(driverID, ConnectionDelayProfileName, ConnectionDelay.ToString())
            driverProfile.WriteValue(driverID, numSwitchProfileName, numSwitch.ToString())
            driverProfile.WriteValue(driverID, SwitchName0ProfileName, SwitchName0.ToString(), "Switch0")
            driverProfile.WriteValue(driverID, SwitchName1ProfileName, SwitchName1.ToString(), "Switch1")
            driverProfile.WriteValue(driverID, SwitchName2ProfileName, SwitchName2.ToString(), "Switch2")
            driverProfile.WriteValue(driverID, SwitchName3ProfileName, SwitchName3.ToString(), "Switch3")
            driverProfile.WriteValue(driverID, SwitchName4ProfileName, SwitchName4.ToString(), "Switch4")
            driverProfile.WriteValue(driverID, SwitchName5ProfileName, SwitchName5.ToString(), "Switch5")
            driverProfile.WriteValue(driverID, SwitchName6ProfileName, SwitchName6.ToString(), "Switch6")
            driverProfile.WriteValue(driverID, SwitchName7ProfileName, SwitchName7.ToString(), "Switch7")
            driverProfile.WriteValue(driverID, CanWrite0ProfileName, CanWrite0.ToString(), "Switch0")
            driverProfile.WriteValue(driverID, CanWrite1ProfileName, CanWrite1.ToString(), "Switch1")
            driverProfile.WriteValue(driverID, CanWrite2ProfileName, CanWrite2.ToString(), "Switch2")
            driverProfile.WriteValue(driverID, CanWrite3ProfileName, CanWrite3.ToString(), "Switch3")
            driverProfile.WriteValue(driverID, CanWrite4ProfileName, CanWrite4.ToString(), "Switch4")
            driverProfile.WriteValue(driverID, CanWrite5ProfileName, CanWrite5.ToString(), "Switch5")
            driverProfile.WriteValue(driverID, CanWrite6ProfileName, CanWrite6.ToString(), "Switch6")
            driverProfile.WriteValue(driverID, CanWrite7ProfileName, CanWrite7.ToString(), "Switch7")
            driverProfile.WriteValue(driverID, SwitchValue0ProfileName, SwitchValue0.ToString(), "Switch0")
            driverProfile.WriteValue(driverID, SwitchValue1ProfileName, SwitchValue1.ToString(), "Switch1")
            driverProfile.WriteValue(driverID, SwitchValue2ProfileName, SwitchValue2.ToString(), "Switch2")
            driverProfile.WriteValue(driverID, SwitchValue3ProfileName, SwitchValue3.ToString(), "Switch3")
            driverProfile.WriteValue(driverID, SwitchValue4ProfileName, SwitchValue4.ToString(), "Switch4")
            driverProfile.WriteValue(driverID, SwitchValue5ProfileName, SwitchValue5.ToString(), "Switch5")
            driverProfile.WriteValue(driverID, SwitchValue6ProfileName, SwitchValue6.ToString(), "Switch6")
            driverProfile.WriteValue(driverID, SwitchValue7ProfileName, SwitchValue7.ToString(), "Switch7")
            driverProfile.WriteValue(driverID, SwitchState0ProfileName, SwitchState0.ToString(), "Switch0")
            driverProfile.WriteValue(driverID, SwitchState1ProfileName, SwitchState1.ToString(), "Switch1")
            driverProfile.WriteValue(driverID, SwitchState2ProfileName, SwitchState2.ToString(), "Switch2")
            driverProfile.WriteValue(driverID, SwitchState3ProfileName, SwitchState3.ToString(), "Switch3")
            driverProfile.WriteValue(driverID, SwitchState4ProfileName, SwitchState4.ToString(), "Switch4")
            driverProfile.WriteValue(driverID, SwitchState5ProfileName, SwitchState5.ToString(), "Switch5")
            driverProfile.WriteValue(driverID, SwitchState6ProfileName, SwitchState6.ToString(), "Switch6")
            driverProfile.WriteValue(driverID, SwitchState7ProfileName, SwitchState7.ToString(), "Switch7")
        End Using
    End Sub

#End Region

End Class
