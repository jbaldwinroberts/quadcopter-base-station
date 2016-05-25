using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace QuadcopterControlMK2
{
      public static class SerialCommunications
      {
            #region Serial methods

            private static SerialPort _serialPort;
            private static string _serialPortBuffer;
            public delegate void StatusHandler (Status status);
            public static event StatusHandler NewStatus;

            static SerialCommunications()
            {
                  _serialPort = new SerialPort();
            }

            private static void Send(string message, string value)
            {
                  Send(message + "=" + value);
            }

            private static void Send(string message)
            {
                  if (IsSerialPortOpen() == true)
                  {
                        _serialPort.Write('<' + message + '>');
                        _serialPort.DiscardInBuffer();
                  }
            }

            private static string Read()
            {
                  if (IsSerialPortOpen() == true)
                  {
                        while (_serialPort.BytesToRead <= 0) System.Threading.Thread.Sleep(100);
                        string reply = _serialPort.ReadLine();
                        return reply;
                  }
                  else return "";
            }

            public static bool IsSerialPortOpen()
            {
                  return _serialPort.IsOpen;
            }

            public static void CloseSerialPort()
            {
                  _serialPort.Close();
            }

            public static bool OpenSerialPort(int portNumber)
            {
                  try
                  {
                        _serialPort.BaudRate = 57600;
                        //_serialPort.BaudRate = 115200;
                        _serialPort.PortName = "COM" + portNumber;
                        _serialPort.DataBits = 8;
                        _serialPort.StopBits = StopBits.One;
                        _serialPort.Handshake = Handshake.None;
                        //_serialPort.Handshake = Handshake.XOnXOff;
                        _serialPort.Parity = Parity.None;
                        _serialPort.Open();
                        _serialPort.DiscardInBuffer();
                        _serialPort.RtsEnable = true;
                        _serialPort.DtrEnable = true;
                        //_serialPort.ReceivedBytesThreshold = 20;
                        _serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
                        return true;
                  }
                  catch (Exception ex)
                  {
                        Console.WriteLine("Error: " + ex);
                        return false;
                  }
            }

            private static void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
            {
                  try
                  {
                        // buffer up the latest data.
                        _serialPortBuffer += _serialPort.ReadExisting();

                        //Object to hold status
                        Status status = new Status();

                        //String to hold packet
                        string _packet = "";

                        // there could be more than one packet in the data so we have to keep looping.
                        bool done = false;

                        while (!done)
                        {
                              // check for a complete message.
                              int start = _serialPortBuffer.IndexOf("<");
                              int end = _serialPortBuffer.IndexOf(">");
                              
                              if (start > -1 && end > -1 && start < end)
                              {
                                    // A complete packet is in the buffer.
                                    _packet = _serialPortBuffer.Substring(start + 1, (end - start) - 1);

                                    // remove the packet from the buffer.
                                    _serialPortBuffer = _serialPortBuffer.Remove(start, (end - start) + 1);
                              }
                              else if (start > -1 && end > -1 && start > end)
                              {
                                    // remove half packet from start of buffer
                                    _serialPortBuffer = _serialPortBuffer.Remove(0, (end + 1));
                              }
                              else
                              {
                                    done = true;

                                    // split the packet up in to it's parameters
                                    string[] completeParameter = _packet.Split(':');

                                    //Add parameters to status dictionary
                                    foreach (string parameter in completeParameter)
                                    {
                                          string[] parameterParts = parameter.Split('=');
                                          if (parameterParts.Length == 2) status.AddKeyValuePair(parameterParts[0], float.Parse(parameterParts[1], System.Globalization.CultureInfo.InvariantCulture));
                                    }

                                    //Fire event
                                    // Console.WriteLine(_serialPortBuffer.Count());
                                    Console.WriteLine(DateTime.Now);
                                    NewStatus(status);
                              }
                        }
                  }
                  catch(Exception ex)
                  {
                  }
            }

            #endregion

            #region Commands

            public static void SetAltitudeRatePIDControllerP(string value)
            {
                  Send("a", value);
            }

            public static void SetAltitudeRatePIDControllerI(string value)
            {
                  Send("b", value);
            }

            public static void SetAltitudeRatePIDControllerD(string value)
            {
                  Send("c", value);
            }

            public static void SetAltitudeStabPIDControllerP(string value)
            {
                  Send("d", value);
            }

            public static void SetAltitudeStabPIDControllerI(string value)
            {
                  Send("e", value);
            }

            public static void SetAltitudeStabPIDControllerD(string value)
            {
                  Send("f", value);
            }

            public static void SetYawRatePIDControllerP(string value)
            {
                  Send("h", value);
            }

            public static void SetYawRatePIDControllerI(string value)
            {
                  Send("i", value);
            }

            public static void SetYawRatePIDControllerD(string value)
            {
                  Send("j", value);
            }

            public static void SetPitchRatePIDControllerP(string value)
            {
                  Send("k", value);
            }

            public static void SetPitchRatePIDControllerI(string value)
            {
                  Send("l", value);
            }

            public static void SetPitchRatePIDControllerD(string value)
            {
                  Send("m", value);
            }

            public static void SetRollRatePIDControllerP(string value)
            {
                  Send("n", value);
            }

            public static void SetRollRatePIDControllerI(string value)
            {
                  Send("o", value);
            }

            public static void SetRollRatePIDControllerD(string value)
            {
                  Send("p", value);
            }

            public static void SetYawStabPIDControllerP(string value)
            {
                  Send("q", value);
            }

            public static void SetYawStabPIDControllerI(string value)
            {
                  Send("r", value);
            }

            public static void SetYawStabPIDControllerD(string value)
            {
                  Send("s", value);
            }

            public static void SetPitchStabPIDControllerP(string value)
            {
                  Send("t", value);
            }

            public static void SetPitchStabPIDControllerI(string value)
            {
                  Send("u", value);
            }

            public static void SetPitchStabPIDControllerD(string value)
            {
                  Send("v", value);
            }

            public static void SetRollStabPIDControllerP(string value)
            {
                  Send("w", value);
            }

            public static void SetRollStabPIDControllerI(string value)
            {
                  Send("x", value);
            }

            public static void SetRollStabPIDControllerD(string value)
            {
                  Send("y", value);
            }

            public static void SetCommsMode(string value)
            {
                  Send("z", value);
            }

            public static void ZeroOffset()
            {
                  Send("g");
            }

            #endregion
     
      }
}
