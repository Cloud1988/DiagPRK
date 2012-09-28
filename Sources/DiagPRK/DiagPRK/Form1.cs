using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;
using DiagPRK.Commands;
using DiagPRK.Spring;

namespace DiagPRK
{
    public partial class DiagRPK : Form
    {
        static SerialPort _serialPort;

        enum ASC_Symbol : byte
        {
            ASC_Null = 48,
            ASC_Eight = 8,
            ASC_Nine = 57
        }

        private CommandFactory CommandFactory;

        public DiagRPK()
        {
            InitializeComponent();

            Flag_reset();

            gbCommand.Enabled = false;
            grParams.Enabled = false;

            _SendTo.Tag = false;
            _GetFrom.Tag = false;

            _SendPack.Enabled = false;

            _SendTo.Validating += TextBoxValidator;
            _GetFrom.Validating += TextBoxValidator;

            CommandFactory = SpringContext.GetObject<CommandFactory>();
        }

        private void TextBoxValidator(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.BackColor = Color.Red;
                    //Is it realy needed?
                    textBox.Tag = false;
                }
                else
                {
                    textBox.BackColor = SystemColors.Window;
                    //Is it realy needed?
                    textBox.Tag = true;
                    ValidateCommand();
                }
            }
        }

        private void _SendTo_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Tag = false;
                    textBox.BackColor = Color.Crimson;
                }
                else
                {
                    textBox.Tag = true;
                    textBox.BackColor = SystemColors.Window;
                }
                ValidateCommand();
            }
        }


        // Change this property name
        private bool IsSendToAndGetFromEnabled
        {
            get { return string.IsNullOrEmpty(_SendTo.Text) && string.IsNullOrEmpty(_GetFrom.Text); }
        }

        private void ValidateCommand()
        {
            bool isEnabled = IsSendToAndGetFromEnabled;
            gbCommand.Enabled = isEnabled;
            _SendPack.Enabled = isEnabled;
        }

        private int GetSendTo
        {
            get
            {
                int sendTo;
                if (int.TryParse(_SendTo.Text, out sendTo))
                {
                    return sendTo;
                }
                else
                {
                    return 0; //default
                }
            }
        }

        private int GetFrom
        {
            get
            {
                int sendTo;
                if (int.TryParse(_GetFrom.Text, out sendTo))
                {
                    return sendTo;
                }
                else
                {
                    return 0; //default
                }
            }
        }

        private void SetCommandList(int sum)
        {
            CommandList.Items.Add("Command sent: ");
            CommandList.Items.Add(string.Format("{0} {1}", _command.Text, sum));
            CommandList.Items.Add(string.Empty);
        }

        private bool IsValueInSomeStrangeList(int value)
        {
            var someStrangeList = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 14, 15, 16, 17 };
            return someStrangeList.Contains(value);
        }

        private void ChooseCommandlist()
        {
            var sum = ChooseMassPar().Last();
            SetCommandList(sum);
        }

        //It is strange method
        private int[] ChooseMassPar()// TODO: choose_mass_par
        {
            int par1 = Convert.ToInt32(_par1.Text);
            int _command = 33;

            var paramSet = new List<int> { GetSendTo, GetFrom, _command };

            if (IsValueInSomeStrangeList(par1))
            {
                paramSet.Add(1);
                paramSet.Add(Convert.ToInt32(_par1.Text));
                paramSet.Add(paramSet.Sum());
            }
            else if (par1 == 12 || par1 == 13)
            {
                paramSet.Add(2);
                paramSet.Add(Convert.ToInt32(_par1.Text));
                paramSet.Add(Convert.ToInt32(_par2.Text));
                paramSet.Add(paramSet.Sum());
            }
            else if (par1 == 18)
            {
                paramSet.Add(7);
                paramSet.Add(Convert.ToInt32(_par1.Text));
                paramSet.Add(Convert.ToInt32(_par2.Text));
                paramSet.Add(Convert.ToInt32(_par3.Text));
                paramSet.Add(Convert.ToInt32(_par4.Text));
                paramSet.Add(Convert.ToInt32(_par5.Text));
                paramSet.Add(Convert.ToInt32(_par6.Text));
                paramSet.Add(Convert.ToInt32(_par7.Text));
                paramSet.Add(paramSet.Sum());
            }
            else if (par1 == 20)
            {
                paramSet.Add(5);
                paramSet.Add(Convert.ToInt32(_par1.Text));
                paramSet.Add(Convert.ToInt32(_par2.Text));
                paramSet.Add(Convert.ToInt32(_par3.Text));
                paramSet.Add(Convert.ToInt32(_par4.Text));
                paramSet.Add(Convert.ToInt32(_par5.Text));
                paramSet.Add(paramSet.Sum());
            }
            else
            {
                paramSet.Add(3);
                paramSet.Add(Convert.ToInt32(_par1.Text));
                paramSet.Add(Convert.ToInt32(_par2.Text));
                paramSet.Add(Convert.ToInt32(_par3.Text));
                paramSet.Add(paramSet.Sum());
            }
            return paramSet.ToArray();
        }

        private void TbPortKeyPress(object sender, KeyPressEventArgs e)
        {
            //try to use System.Windows.Forms.Keys instead ASC_Symbol
            if (e.KeyChar != (char)Keys.Decimal && e.KeyChar != (char)ASC_Symbol.ASC_Eight)
            {
                e.Handled = true;
            }
        }

        private void _ClearList_Click(object sender, EventArgs e)
        {
            CommandList.Items.Clear();
        }

        private string[] _Init_Port() //TODO: changed int value
        {
            string _portName, _checkPort, _adapter_first = string.Empty, _adapter_second = string.Empty;
            string PortNumb = string.Empty;
            string[] param;
            param = new string[3];
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_SerialPort");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    _Progress.Increment(50);
                    _portName = Convert.ToString(queryObj["Name"]);
                    _checkPort = Convert.ToString(queryObj["StatusInfo"]);
                    if ((_portName.Contains(Res.Adapter_name)) && (_checkPort == _free) && (_rbutton1.Checked))
                    {
                        CommandList.Items.Add(_portName);
                        CommandList.Items.Add(Res.Adapter_rdy);
                        _adapter_first = Convert.ToString(queryObj["DeviceID"]);
                        _Progress.Value = _Progress.Minimum;
                        _serialPort = new SerialPort();
                        _serialPort.PortName = _adapter_first;
                        _serialPort.BaudRate = 57600;
                        _serialPort.Parity = Parity.None;
                        _serialPort.StopBits = StopBits.One;
                        _serialPort.DataBits = 8;
                        _serialPort.Handshake = Handshake.None;
                        _serialPort.ReadTimeout = 2000;
                        _serialPort.WriteTimeout = 1000;
                        param[0] = _adapter_first;
                        break;
                    }
                    else if ((_portName.Contains(Res.Adapter_name)) && (_checkPort == _free) && (_rbutton2.Checked))
                    {
                        CommandList.Items.Add(_portName);
                        CommandList.Items.Add(Res.Adapter_rdy);
                        CommandList.Items.Add(string.Empty);
                        if (_adapter_first == string.Empty)
                        {
                            _adapter_first = Convert.ToString(queryObj["DeviceID"]);
                            param[1] = _adapter_first;
                        }
                        else
                        {
                            _adapter_second = Convert.ToString(queryObj["DeviceID"]);
                            param[2] = _adapter_second;
                            _Progress.Value = _Progress.Minimum;
                            _serialPort = new SerialPort();
                            _serialPort.BaudRate = 57600;
                            _serialPort.Parity = Parity.None;
                            _serialPort.StopBits = StopBits.One;
                            _serialPort.DataBits = 8;
                            _serialPort.Handshake = Handshake.None;
                            _serialPort.ReadTimeout = 2000;
                            _serialPort.WriteTimeout = 1000;
                        }
                    }
                }
                _Progress.Value = _Progress.Minimum;
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
            return param;
        }

        private void WriteToPort(SerialPort serialPort, string portName, byte[] buffer)
        {
            serialPort.PortName = portName;
            serialPort.Open();
            serialPort.Write(buffer, 0, buffer.Length);
            serialPort.Close();
        }

        private void _Trans_Data(byte Command)
        {
            int sendto_value, getfrom_value, Sum;
            int param = 0, param_value_1 = 0, param_value_2 = 0, param_value_3 = 0, param_value_4 = 0,
                param_value_5 = 0, param_value_6 = 0, param_value_7 = 0, param_value_8 = 0, param_value_9 = 0,
                param_value_10 = 0, param_value_11 = 0, param_value_12 = 0;

            string[] _value = _Init_Port();
            sendto_value = Convert.ToInt32(_SendTo.Text);
            getfrom_value = Convert.ToInt32(_GetFrom.Text);
            Sum = Command + getfrom_value + sendto_value;

            switch (Command)
            {
                case 5:
                    param = 0;
                    int[] Send_5 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_5 = new byte[Send_5.Length];
                    for (int i = 0; i < Send_5.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_5[i]);
                        byte_5[i] = byteConv[0];
                    }

                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        WriteToPort(_serialPort, _value[0], byte_5);
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        WriteToPort(_serialPort, _value[1], byte_5);
                        WriteToPort(_serialPort, _value[2], byte_5);
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;
                case 9:
                    param = 0;
                    int[] Send_9 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_9 = new byte[Send_9.Length];
                    for (int i = 0; i < Send_9.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_9[i]);
                        byte_9[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_9, 0, byte_9.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_9, 0, byte_9.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_9, 0, byte_9.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;
                case 10:
                    param = 0;
                    int[] Send_10 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_10 = new byte[Send_10.Length];
                    for (int i = 0; i < Send_10.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_10[i]);
                        byte_10[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_10, 0, byte_10.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_10, 0, byte_10.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_10, 0, byte_10.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;
                case 11:
                    param = 0;
                    int[] Send_11 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_11 = new byte[Send_11.Length];
                    for (int i = 0; i < Send_11.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_11[i]);
                        byte_11[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_11, 0, byte_11.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_11, 0, byte_11.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_11, 0, byte_11.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;

                case 12:
                    param = 1;
                    param_value_1 = Convert.ToInt32(this._par1.Text);
                    sendto_value = Convert.ToInt32(this._SendTo.Text);
                    getfrom_value = Convert.ToInt32(this._GetFrom.Text);
                    Sum = Command + getfrom_value + sendto_value + param + param_value_1;
                    int[] _sendPack_12 = { sendto_value, getfrom_value, Command, param, param_value_1, Sum };
                    byte[] byte_12 = new byte[_sendPack_12.Length];
                    for (int i = 0; i < _sendPack_12.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(_sendPack_12[i]);
                        byte_12[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_12, 0, byte_12.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + sendto_value + " " + getfrom_value + " " + Command + " " + param + " " + param_value_1 + " " + Sum);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_12, 0, byte_12.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_12, 0, byte_12.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + sendto_value + " " + getfrom_value + " " + Command + " " + param + " " + param_value_1 + " " + Sum);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }

                    break;

                case 17:
                    param = 0;
                    int[] Send_17 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_17 = new byte[Send_17.Length];
                    for (int i = 0; i < Send_17.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_17[i]);
                        byte_17[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_17, 0, byte_17.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_17, 0, byte_17.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_17, 0, byte_17.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;

                case 18:
                    param = 0;
                    int[] Send_18 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_18 = new byte[Send_18.Length];
                    for (int i = 0; i < Send_18.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_18[i]);
                        byte_18[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_18, 0, byte_18.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_18, 0, byte_18.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_18, 0, byte_18.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }

                    break;

                case 19:
                    param = 0;
                    int[] Send_19 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_19 = new byte[Send_19.Length];
                    for (int i = 0; i < Send_19.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_19[i]);
                        byte_19[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_19, 0, byte_19.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_19, 0, byte_19.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_19, 0, byte_19.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;

                case 20:
                    param = 0;
                    int[] Send_20 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_20 = new byte[Send_20.Length];
                    for (int i = 0; i < Send_20.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_20[i]);
                        byte_20[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_20, 0, byte_20.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_20, 0, byte_20.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_20, 0, byte_20.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;

                case 21:
                    param = 0;
                    int[] Send_21 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_21 = new byte[Send_21.Length];
                    for (int i = 0; i < Send_21.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_21[i]);
                        byte_21[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_21, 0, byte_21.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_21, 0, byte_21.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_21, 0, byte_21.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;

                case 22:
                    param = 0;
                    int[] Send_22 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_22 = new byte[Send_22.Length];
                    for (int i = 0; i < Send_22.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_22[i]);
                        byte_22[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_22, 0, byte_22.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_22, 0, byte_22.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_22, 0, byte_22.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;

                case 24:
                    param = 0;
                    int[] Send_24 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_24 = new byte[Send_24.Length];
                    for (int i = 0; i < Send_24.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_24[i]);
                        byte_24[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_24, 0, byte_24.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_24, 0, byte_24.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_24, 0, byte_24.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;

                case 25:
                    param = 0;
                    int[] Send_25 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_25 = new byte[Send_25.Length];
                    for (int i = 0; i < Send_25.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_25[i]);
                        byte_25[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_25, 0, byte_25.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_25, 0, byte_25.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_25, 0, byte_25.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;

                case 26:
                    param = 0;
                    int[] Send_26 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_26 = new byte[Send_26.Length];
                    for (int i = 0; i < Send_26.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_26[i]);
                        byte_26[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_26, 0, byte_26.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_26, 0, byte_26.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_26, 0, byte_26.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;

                case 27:
                    param = 0;
                    int[] Send_27 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_27 = new byte[Send_27.Length];
                    for (int i = 0; i < Send_27.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_27[i]);
                        byte_27[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_27, 0, byte_27.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_27, 0, byte_27.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_27, 0, byte_27.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }

                    break;

                case 28:
                    param = 2;
                    param_value_1 = Convert.ToInt32(this._par1.Text);
                    param_value_2 = Convert.ToInt32(this._par2.Text);
                    sendto_value = Convert.ToInt32(this._SendTo.Text);
                    getfrom_value = Convert.ToInt32(this._GetFrom.Text);
                    Sum = Command + getfrom_value + sendto_value + param + param_value_1 + param_value_2;
                    int[] _sendPack_28 = { sendto_value, getfrom_value, Command, param, param_value_1, param_value_2, Sum };
                    byte[] byte_28 = new byte[_sendPack_28.Length];
                    for (int i = 0; i < 256; i++)
                    {
                        if (_par1.Text == Convert.ToString(i))
                        {
                            param_value_1 = i;
                            break;
                        }
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        if (_par2.Text == Convert.ToString(i))
                        {
                            param_value_2 = i;
                            break;
                        }
                    }
                    if (Sum > 256)
                    {
                        Sum = Sum - 256;
                    }
                    for (int i = 0; i < _sendPack_28.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(_sendPack_28[i]);
                        byte_28[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_28, 0, byte_28.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + sendto_value + " " + getfrom_value + " " + Command + " " + param + " " + param_value_1 + " " + param_value_2 + " " + Sum);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_28, 0, byte_28.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_28, 0, byte_28.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + sendto_value + " " + getfrom_value + " " + Command + " " + param + " " + param_value_1 + " " + param_value_2 + " " + Sum);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;

                case 29:
                    param = 1;
                    param_value_1 = Convert.ToInt32(this._par1.Text);
                    sendto_value = Convert.ToInt32(this._SendTo.Text);
                    getfrom_value = Convert.ToInt32(this._GetFrom.Text);
                    Sum = Command + getfrom_value + sendto_value + param + param_value_1;
                    int[] _sendPack_29 = { sendto_value, getfrom_value, Command, param, param_value_1, Sum };
                    byte[] byte_29 = new byte[_sendPack_29.Length];
                    for (int i = 0; i < _sendPack_29.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(_sendPack_29[i]);
                        byte_29[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_29, 0, byte_29.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + " " + sendto_value + " " + getfrom_value + " " +
                                               Command + " " + param + " " + param_value_1 + " " + Sum);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_29, 0, byte_29.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_29, 0, byte_29.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + " " + sendto_value + " " + getfrom_value + " " +
                                               Command + " " + param + " " + param_value_1 + " " + Sum);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;

                case 30:
                    param = 12;
                    param_value_1 = Convert.ToInt32(this._par1.Text); param_value_2 = Convert.ToInt32(this._par2.Text);
                    param_value_3 = Convert.ToInt32(this._par3.Text); param_value_4 = Convert.ToInt32(this._par4.Text);
                    param_value_5 = Convert.ToInt32(this._par5.Text); param_value_6 = Convert.ToInt32(this._par6.Text);
                    param_value_7 = Convert.ToInt32(this._par7.Text); param_value_8 = Convert.ToInt32(this._par8.Text);
                    param_value_9 = Convert.ToInt32(this._par9.Text); param_value_10 = Convert.ToInt32(this._par10.Text);
                    param_value_11 = Convert.ToInt32(this._par11.Text); param_value_12 = Convert.ToInt32(this._par12.Text);
                    Sum = Command + getfrom_value + sendto_value + param + param_value_1 + param_value_2 +
                          param_value_3 + param_value_4 + param_value_5 + param_value_6 + param_value_7 +
                          param_value_8 + param_value_9 + param_value_10 + param_value_11 + param_value_12;

                    int[] _sendPack_30 = { sendto_value, getfrom_value, Command, param, param_value_1, param_value_2,
                                           param_value_3, param_value_4, param_value_5, param_value_6, param_value_7,
                                           param_value_8, param_value_9, param_value_10, param_value_11, param_value_12, Sum };// by the command, choose the correct count of param

                    byte[] byte_30 = new byte[_sendPack_30.Length];
                    sendto_value = Convert.ToInt32(this._SendTo.Text);
                    getfrom_value = Convert.ToInt32(this._GetFrom.Text);
                    for (int i = 0; i < _sendPack_30.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(_sendPack_30[i]);
                        byte_30[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {

                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_30, 0, byte_30.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: ");
                        CommandList.Items.Add(sendto_value + " " + getfrom_value + " " + Command + " " + param + " " + param_value_1 + " " + param_value_2 + " " +
                                              param_value_3 + " " + param_value_4 + " " + param_value_5 + " " + param_value_6 + " " + param_value_7 + " " +
                                              param_value_8 + " " + param_value_9 + " " + param_value_10 + " " + param_value_11 + " " + param_value_12 + " " + Sum);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_30, 0, byte_30.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_30, 0, byte_30.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: ");
                        CommandList.Items.Add(sendto_value + " " + getfrom_value + " " + Command + " " + param + " " + param_value_1 + " " + param_value_2 + " " +
                                              param_value_3 + " " + param_value_4 + " " + param_value_5 + " " + param_value_6 + " " + param_value_7 + " " +
                                              param_value_8 + " " + param_value_9 + " " + param_value_10 + " " + param_value_11 + " " + param_value_12 + " " + Sum);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;

                case 31:
                    param = 0;
                    int[] Send_31 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_31 = new byte[Send_31.Length];
                    for (int i = 0; i < Send_31.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_31[i]);
                        byte_31[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_31, 0, byte_31.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_31, 0, byte_31.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_31, 0, byte_31.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;
                case 32:
                    param = 12;
                    param_value_1 = Convert.ToInt32(this._par1.Text); param_value_2 = Convert.ToInt32(this._par2.Text);
                    param_value_3 = Convert.ToInt32(this._par3.Text); param_value_4 = Convert.ToInt32(this._par4.Text);
                    param_value_5 = Convert.ToInt32(this._par5.Text); param_value_6 = Convert.ToInt32(this._par6.Text);
                    param_value_7 = Convert.ToInt32(this._par7.Text); param_value_8 = Convert.ToInt32(this._par8.Text);
                    param_value_9 = Convert.ToInt32(this._par9.Text); param_value_10 = Convert.ToInt32(this._par10.Text);
                    param_value_11 = Convert.ToInt32(this._par11.Text); param_value_12 = Convert.ToInt32(this._par12.Text);
                    Sum = Command + getfrom_value + sendto_value + param + param_value_1 + param_value_2 +
                          param_value_3 + param_value_4 + param_value_5 + param_value_6 + param_value_7 +
                          param_value_8 + param_value_9 + param_value_10 + param_value_11 + param_value_12;

                    int[] _sendPack_32 = { sendto_value, getfrom_value, Command, param, param_value_1, param_value_2,
                                           param_value_3, param_value_4, param_value_5, param_value_6, param_value_7,
                                           param_value_8, param_value_9, param_value_10, param_value_11, param_value_12, Sum };// by the command, choose the correct count of param

                    byte[] byte_32 = new byte[_sendPack_32.Length];
                    sendto_value = Convert.ToInt32(this._SendTo.Text);
                    getfrom_value = Convert.ToInt32(this._GetFrom.Text);
                    for (int i = 0; i < _sendPack_32.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(_sendPack_32[i]);
                        byte_32[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {

                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_32, 0, byte_32.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: ");
                        CommandList.Items.Add(sendto_value + " " + getfrom_value + " " + Command + " " + param + " " + param_value_1 + " " + param_value_2 + " " +//TODO: заменить эту всю кучу переменных на указатели с массива _sendPack_
                                              param_value_3 + " " + param_value_4 + " " + param_value_5 + " " + param_value_6 + " " + param_value_7 + " " +
                                              param_value_8 + " " + param_value_9 + " " + param_value_10 + " " + param_value_11 + " " + param_value_12 + " " + Sum);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_32, 0, byte_32.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_32, 0, byte_32.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: ");
                        CommandList.Items.Add(sendto_value + " " + getfrom_value + " " + Command + " " + param + " " + param_value_1 + " " + param_value_2 + " " +
                                              param_value_3 + " " + param_value_4 + " " + param_value_5 + " " + param_value_6 + " " + param_value_7 + " " +
                                              param_value_8 + " " + param_value_9 + " " + param_value_10 + " " + param_value_11 + " " + param_value_12 + " " + Sum);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;
                case 33:
                    int[] _sendPack_33 = ChooseMassPar();
                    byte[] byte_33 = new byte[_sendPack_33.Length];
                    for (int i = 0; i < _sendPack_33.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(_sendPack_33[i]);
                        byte_33[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {

                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_33, 0, byte_33.Length);
                        _serialPort.Close();
                        ChooseCommandlist();
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_33, 0, byte_33.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_33, 0, byte_33.Length);
                        _serialPort.Close();
                        ChooseCommandlist();
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;

                case 155:
                    param = 0;
                    int[] Send_155 = { sendto_value, getfrom_value, Command, param, Sum };// by the command, choose the correct count of param
                    byte[] byte_155 = new byte[Send_155.Length];
                    for (int i = 0; i < Send_155.Length; i++)
                    {
                        byte[] byteConv = BitConverter.GetBytes(Send_155[i]);
                        byte_155[i] = byteConv[0];
                    }
                    if (_rbutton1.Checked && !string.IsNullOrEmpty(_value[0]))
                    {
                        _serialPort.PortName = _value[0];
                        _serialPort.Open();
                        _serialPort.Write(byte_155, 0, byte_155.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else if (_rbutton2.Checked && !string.IsNullOrEmpty(_value[1]) && !string.IsNullOrEmpty(_value[2]))
                    {
                        _serialPort.PortName = _value[1];
                        _serialPort.Open();
                        _serialPort.Write(byte_155, 0, byte_155.Length);
                        _serialPort.Close();
                        _serialPort.PortName = _value[2];
                        _serialPort.Open();
                        _serialPort.Write(byte_155, 0, byte_155.Length);
                        _serialPort.Close();
                        CommandList.Items.Add("Command sent: " + this._command.Text);
                        CommandList.Items.Add(string.Empty);
                    }
                    else
                    {
                        CommandList.Items.Add(Res.Adapter_error);
                        CommandList.Items.Add(string.Empty);
                    }
                    break;
            }
        }

        private int Command_Select()
        {
            int key = -1;
            foreach (var control in gbCommand.Controls)
            {
                Button commandButton = control as Button;

                if (commandButton != null && (bool)commandButton.Tag && int.TryParse(commandButton.Text, out key))
                {
                    break;
                }
            }
            return key;
        }

        private void Com_Click(object sender, EventArgs e)
        {   
            var button = sender as Button;
            if (button != null)
            {
                Flag_reset();
                Par_reset();
                button.Tag = true;

                int commandId = int.Parse(button.Text);
                var command = CommandFactory.GetCommand(commandId);

                var quantityOfParams = command.GetParams();
                InitComboBoxs(quantityOfParams);

                int sendtoValue = GetSendTo;
                int getfromValue = GetFrom;
                  
                var sendPack = command.GetPack(commandId, getfromValue, sendtoValue);
                _command.Text = string.Join(" ", sendPack);
            }
        }

        private void InitComboBoxs(IEnumerable<object[]> quantityOfParams)
        {
            int index = 1;
            foreach (var quantity in quantityOfParams)
            {
                string groupBoxName = String.Format("_par{0}", index);
                if (grParams.Controls.ContainsKey(groupBoxName))
                {
                    var comboBox = (ComboBox) grParams.Controls[groupBoxName];
                    comboBox.Items.Clear();
                    comboBox.Items.AddRange(quantity);
                    comboBox.SelectedIndex = 0;
                    index++;
                    grParams.Enabled = true; 
                }
                else
                {
                    throw new ArgumentNullException(String.Format("ComboBox {0} not exist on form.", index));
                }
            }
        }
        
        private void _SendPack_Click(object sender, EventArgs e)
        {
            int command = Command_Select();
            if (command != -1)
            {
                _Trans_Data((byte)command);
            }
            else
            {
                CommandList.Items.Add("choose the command");
                CommandList.Items.Add("");
            }
            _command.Text = "";
            Flag_reset();
            Par_reset();
            grParams.Enabled = false;
        }

        private void _par1_DropDown(object sender, EventArgs e)
        {
            _par1.BackColor = SystemColors.Window;
        }

        private void ParamTextChanged(object sender, EventArgs e)
        {
            Param_changed();
        }

        private void Param_changed()
        {
            string command_value = string.Empty, param = string.Empty;
            switch (Command_Select())
            {
                case 12:
                    command_value = "12";
                    param = "1";
                    _command.Text = (_SendTo.Text + " " + _GetFrom.Text + " " + command_value + " " + param + " " + _par1.Text);
                    break;
                case 28:
                    command_value = "28";
                    param = "2";
                    _command.Text = (_SendTo.Text + " " + _GetFrom.Text + " " + command_value + " " + param + " " + _par1.Text + " " + _par2.Text);
                    break;
                case 29:
                    command_value = "29";
                    param = "1";
                    _command.Text = (_SendTo.Text + " " + _GetFrom.Text + " " + command_value + " " + param + " " + _par1.Text);
                    break;
                case 30:
                    command_value = "30";
                    param = "12";
                    _command.Text = (_SendTo.Text + " " + _GetFrom.Text + " " + command_value +
                                     " " + param + " " + _par1.Text + " " + _par2.Text +
                                     " " + _par3.Text + " " + _par4.Text + " " + _par5.Text +
                                     " " + _par6.Text + " " + _par7.Text + " " + _par8.Text +
                                     " " + _par9.Text + " " + _par10.Text + " " + _par11.Text +
                                     " " + _par12.Text);
                    break;
                case 32:
                    command_value = "32";
                    param = "12";
                    _command.Text = (_SendTo.Text + " " + _GetFrom.Text + " " + command_value +
                                     " " + param + " " + _par1.Text + " " + _par2.Text +
                                     " " + _par3.Text + " " + _par4.Text + " " + _par5.Text +
                                     " " + _par6.Text + " " + _par7.Text + " " + _par8.Text +
                                     " " + _par9.Text + " " + _par10.Text + " " + _par11.Text +
                                     " " + _par12.Text);
                    break;
                case 33:
                    if ((_par1.Text == "1") || (_par1.Text == "2") || (_par1.Text == "3") ||
                        (_par1.Text == "4") || (_par1.Text == "5") || (_par1.Text == "6") ||
                        (_par1.Text == "7") || (_par1.Text == "8") || (_par1.Text == "9") ||
                        (_par1.Text == "10") || (_par1.Text == "14") || (_par1.Text == "15") ||
                        (_par1.Text == "16") || (_par1.Text == "17"))
                    {
                        Par_reset1();
                        command_value = "33";
                        param = "1";
                        _command.Text = (_SendTo.Text + " " + _GetFrom.Text + " " + command_value +
                                         " " + param + " " + _par1.Text);
                    }
                    else if ((_par1.Text == "12") || (_par1.Text == "13"))
                    {
                        if (_par2.Items.Count != 4)
                        {
                            Par_reset1();
                            for (int i = 2; i < 7; i++)
                            {
                                if (i == 5)
                                {
                                    continue;
                                }
                                _par2.Items.Add(i);
                            }
                            _par2.Text = "2";
                        }
                        command_value = "33";
                        param = "2";
                        _command.Text = (_SendTo.Text + " " + _GetFrom.Text + " " + command_value +
                                         " " + param + " " + _par1.Text + " " + _par2.Text);

                    }
                    else if (_par1.Text == "18")
                    {
                        if ((_par2.Items.Count != 256) & (_par7.Items.Count != 256))
                        {
                            for (int i = 0; i < 256; i++)
                            {
                                _par2.Items.Add(i);
                                _par3.Items.Add(i);
                                _par4.Items.Add(i);
                                _par5.Items.Add(i);
                                _par6.Items.Add(i);
                                _par7.Items.Add(i);
                            }
                            _par2.Text = zero;
                            _par3.Text = zero;
                            _par4.Text = zero;
                            _par5.Text = zero;
                            _par6.Text = zero;
                            _par7.Text = zero;
                        }
                        command_value = "33";
                        param = "7";
                        _command.Text = (_SendTo.Text + " " + _GetFrom.Text + " " + command_value +
                                         " " + param + " " + _par1.Text + " " + _par2.Text +
                                         " " + _par3.Text + " " + _par4.Text + " " + _par5.Text +
                                         " " + _par6.Text + " " + _par7.Text);
                    }
                    else if (_par1.Text == "20")
                    {
                        if ((_par3.Items.Count != 28) | (_par5.Items.Count != 256))
                        {
                            Par_reset1();
                            for (int i = 2; i < 5; i++)
                            {
                                _par2.Items.Add(i);
                            }
                            for (int i = 1; i < 29; i++)
                            {
                                _par3.Items.Add(i);
                            }
                            for (int i = 0; i < 256; i++)
                            {
                                _par4.Items.Add(i);
                                _par5.Items.Add(i);
                            }
                            _par2.Text = "2";
                            _par3.Text = "1";
                            _par4.Text = zero;
                            _par5.Text = zero;
                        }
                        command_value = "33";
                        param = "5";
                        _command.Text = (_SendTo.Text + " " + _GetFrom.Text + " " + command_value +
                                         " " + param + " " + _par1.Text + " " + _par2.Text +
                                         " " + _par3.Text + " " + _par4.Text + " " + _par5.Text);
                    }
                    else if (_par1.Text == "21")
                    {
                        if ((_par3.Items.Count != 28) | (_par5.Items.Count == 256))
                        {
                            Par_reset1();
                            for (int i = 2; i < 5; i++)
                            {
                                _par2.Items.Add(i);
                            }
                            for (int i = 1; i < 29; i++)
                            {
                                _par3.Items.Add(i);
                            }
                            _par2.Text = "2";
                            _par3.Text = "1";
                        }
                        command_value = "33";
                        param = "3";
                        _command.Text = (_SendTo.Text + " " + _GetFrom.Text + " " + command_value +
                                         " " + param + " " + _par1.Text + " " + _par2.Text + " " + _par3.Text);
                    }

                    break;
            }
        }

    }
}
