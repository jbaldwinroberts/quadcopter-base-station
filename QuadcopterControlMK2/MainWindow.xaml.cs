using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using Microsoft.Maps.MapControl.WPF;

namespace QuadcopterControlMK2
{
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : Window
      {
            #region Bar chart collections

            //Bar charts
            public ObservableCollection<KeyValuePair<string, double>> _motorPowerBarGraphData = new ObservableCollection<KeyValuePair<string, double>>();
            public ObservableCollection<KeyValuePair<string, double>> _pidBarGraphData = new ObservableCollection<KeyValuePair<string, double>>();
            public ObservableCollection<KeyValuePair<string, double>> _imuYPRBarGraphData = new ObservableCollection<KeyValuePair<string, double>>();
            public ObservableCollection<KeyValuePair<string, double>> _imuRateBarGraphData = new ObservableCollection<KeyValuePair<string, double>>();
            public ObservableCollection<KeyValuePair<string, double>> _rawRCBarGraphData = new ObservableCollection<KeyValuePair<string, double>>();
            public ObservableCollection<KeyValuePair<string, double>> _mappedRCBarGraphData = new ObservableCollection<KeyValuePair<string, double>>();

            #endregion

            #region Line chart collections

            //Line charts
            private ObservableCollection<KeyValuePair<DateTime, double>>[] _motorPowerLineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[4];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] MotorPowerLineGraphData
            {
                  get { return _motorPowerLineGraphData; }
                  set { _motorPowerLineGraphData = value; }
            }

            private ObservableCollection<KeyValuePair<DateTime, double>>[] _PidLineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[3];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] PidLineGraphData
            {
                  get { return _PidLineGraphData; }
                  set { _PidLineGraphData = value; }
            }

            private ObservableCollection<KeyValuePair<DateTime, double>>[] _stabIMULineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[3];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] StabIMULineGraphData
            {
                  get { return _stabIMULineGraphData; }
                  set { _stabIMULineGraphData = value; }
            }

            private ObservableCollection<KeyValuePair<DateTime, double>>[] _rateIMULineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[3];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] RateIMULineGraphData
            {
                  get { return _rateIMULineGraphData; }
                  set { _rateIMULineGraphData = value; }
            }

            private ObservableCollection<KeyValuePair<DateTime, double>>[] _rawRCLineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[8];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] RawRCLineGraphData
            {
                  get { return _rawRCLineGraphData; }
                  set { _rawRCLineGraphData = value; }
            }

            private ObservableCollection<KeyValuePair<DateTime, double>>[] _mappedRCLineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[4];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] MappedRCLineGraphData
            {
                  get { return _mappedRCLineGraphData; }
                  set { _mappedRCLineGraphData = value; }
            }

            private ObservableCollection<KeyValuePair<DateTime, double>>[] _yawTuningRateLineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[3];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] YawTuningRateLineGraphData
            {
                  get { return _yawTuningRateLineGraphData; }
                  set { _yawTuningRateLineGraphData = value; }
            }

            private ObservableCollection<KeyValuePair<DateTime, double>>[] _yawTuningStabLineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[3];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] YawTuningStabLineGraphData
            {
                  get { return _yawTuningStabLineGraphData; }
                  set { _yawTuningStabLineGraphData = value; }
            }

            private ObservableCollection<KeyValuePair<DateTime, double>>[] _pitchTuningRateLineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[3];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] PitchTuningRateLineGraphData
            {
                  get { return _pitchTuningRateLineGraphData; }
                  set { _pitchTuningRateLineGraphData = value; }
            }

            private ObservableCollection<KeyValuePair<DateTime, double>>[] _pitchTuningStabLineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[3];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] PitchTuningStabLineGraphData
            {
                  get { return _pitchTuningStabLineGraphData; }
                  set { _pitchTuningStabLineGraphData = value; }
            }

            private ObservableCollection<KeyValuePair<DateTime, double>>[] _rollTuningRateLineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[3];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] RollTuningRateLineGraphData
            {
                  get { return _rollTuningRateLineGraphData; }
                  set { _rollTuningRateLineGraphData = value; }
            }

            private ObservableCollection<KeyValuePair<DateTime, double>>[] _rollTuningStabLineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[3];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] RollTuningStabLineGraphData
            {
                  get { return _rollTuningStabLineGraphData; }
                  set { _rollTuningStabLineGraphData = value; }
            }

            private ObservableCollection<KeyValuePair<DateTime, double>>[] _altitudeLineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[4];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] AltitudeLineGraphData
            {
                  get { return _altitudeLineGraphData; }
                  set { _altitudeLineGraphData = value; }
            }

            private ObservableCollection<KeyValuePair<DateTime, double>>[] _velocityLineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[7];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] VelocityLineGraphData
            {
                  get { return _velocityLineGraphData; }
                  set { _velocityLineGraphData = value; }
            }

            private ObservableCollection<KeyValuePair<DateTime, double>>[] _lidarLineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[7];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] LidarLineGraphData
            {
                  get { return _lidarLineGraphData; }
                  set { _lidarLineGraphData = value; }
            }

            private ObservableCollection<KeyValuePair<DateTime, double>>[] _altitudeModeLineGraphData = new ObservableCollection<KeyValuePair<DateTime, double>>[5];
            public ObservableCollection<KeyValuePair<DateTime, double>>[] AltitudeModeLineGraphData
            {
                  get { return _altitudeModeLineGraphData; }
                  set { _altitudeModeLineGraphData = value; }
            }

            #endregion

            #region Map variables

            MapLayer _waypointLayer;
            MapLayer _positionLayer;
            MapLayer _plannedRouteLayer;
            MapLayer _actualRouteLayer;
            MapPolyline _plannnedRoutePolyline;
            MapPolyline _actualRoutePolyline;
            Image image;
            double _latitude;
            double _longitude;

            #endregion

            #region Constructor

            public MainWindow()
            {
                  InitializeComponent();

                  _motorPowerBarGraphData.Clear();
                  _motorPowerBarGraphData.Add(new KeyValuePair<string, double>("M1 0", 0));
                  _motorPowerBarGraphData.Add(new KeyValuePair<string, double>("M2 0", 0));
                  _motorPowerBarGraphData.Add(new KeyValuePair<string, double>("M3 0", 0));
                  _motorPowerBarGraphData.Add(new KeyValuePair<string, double>("M4 0", 0));

                  MotorPowerLineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  MotorPowerLineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  MotorPowerLineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  MotorPowerLineGraphData[3] = new ObservableCollection<KeyValuePair<DateTime, double>>();

                  _pidBarGraphData.Clear();
                  _pidBarGraphData.Add(new KeyValuePair<String, double>("Yaw 0", 0));
                  _pidBarGraphData.Add(new KeyValuePair<String, double>("Pitch 0", 0));
                  _pidBarGraphData.Add(new KeyValuePair<String, double>("Roll 0", 0));

                  PidLineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  PidLineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  PidLineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();

                  _imuYPRBarGraphData.Clear();
                  _imuYPRBarGraphData.Add(new KeyValuePair<String, double>("Yaw 0", 0));
                  _imuYPRBarGraphData.Add(new KeyValuePair<String, double>("Pitch 0",  0));
                  _imuYPRBarGraphData.Add(new KeyValuePair<String, double>("Roll 0",  0));

                  StabIMULineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  StabIMULineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  StabIMULineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();

                  _imuRateBarGraphData.Clear();
                  _imuRateBarGraphData.Add(new KeyValuePair<String, double>("Yaw 0", 0));
                  _imuRateBarGraphData.Add(new KeyValuePair<String, double>("Pitch 0", 0));
                  _imuRateBarGraphData.Add(new KeyValuePair<String, double>("Roll 0", 0));

                  RateIMULineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  RateIMULineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  RateIMULineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();

                  _mappedRCBarGraphData.Clear();
                  _mappedRCBarGraphData.Add(new KeyValuePair<string, double>("Yaw 0", 0));
                  _mappedRCBarGraphData.Add(new KeyValuePair<string, double>("Pitch 0", 0));
                  _mappedRCBarGraphData.Add(new KeyValuePair<string, double>("Roll 0", 0));
                  _mappedRCBarGraphData.Add(new KeyValuePair<string, double>("Thrust 0", 0));

                  MappedRCLineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  MappedRCLineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  MappedRCLineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  MappedRCLineGraphData[3] = new ObservableCollection<KeyValuePair<DateTime, double>>();

                  _rawRCBarGraphData.Clear();
                  _rawRCBarGraphData.Add(new KeyValuePair<string, double>("Channel 1 0", 0));
                  _rawRCBarGraphData.Add(new KeyValuePair<string, double>("Channel 2 0", 0));
                  _rawRCBarGraphData.Add(new KeyValuePair<string, double>("Channel 3 0", 0));
                  _rawRCBarGraphData.Add(new KeyValuePair<string, double>("Channel 4 0", 0));
                  _rawRCBarGraphData.Add(new KeyValuePair<string, double>("Channel 5 0", 0));
                  _rawRCBarGraphData.Add(new KeyValuePair<string, double>("Channel 6 0", 0));
                  _rawRCBarGraphData.Add(new KeyValuePair<string, double>("Channel 7 0", 0));
                  _rawRCBarGraphData.Add(new KeyValuePair<string, double>("Channel 8 0", 0));

                  RawRCLineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  RawRCLineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  RawRCLineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  RawRCLineGraphData[3] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  RawRCLineGraphData[4] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  RawRCLineGraphData[5] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  RawRCLineGraphData[6] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  RawRCLineGraphData[7] = new ObservableCollection<KeyValuePair<DateTime, double>>();

                  YawTuningRateLineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  YawTuningRateLineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  YawTuningRateLineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();

                  YawTuningStabLineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  YawTuningStabLineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  YawTuningStabLineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();

                  PitchTuningRateLineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  PitchTuningRateLineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  PitchTuningRateLineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();

                  PitchTuningStabLineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  PitchTuningStabLineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  PitchTuningStabLineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();

                  RollTuningRateLineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  RollTuningRateLineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  RollTuningRateLineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();

                  RollTuningStabLineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  RollTuningStabLineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  RollTuningStabLineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();

                  AltitudeLineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  AltitudeLineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  AltitudeLineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  AltitudeLineGraphData[3] = new ObservableCollection<KeyValuePair<DateTime, double>>();

                  VelocityLineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  VelocityLineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  VelocityLineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  VelocityLineGraphData[3] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  VelocityLineGraphData[4] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  VelocityLineGraphData[5] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  VelocityLineGraphData[6] = new ObservableCollection<KeyValuePair<DateTime, double>>();

                  LidarLineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  LidarLineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  LidarLineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  LidarLineGraphData[3] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  LidarLineGraphData[4] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  LidarLineGraphData[5] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  LidarLineGraphData[6] = new ObservableCollection<KeyValuePair<DateTime, double>>();

                  AltitudeModeLineGraphData[0] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  AltitudeModeLineGraphData[1] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  AltitudeModeLineGraphData[2] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  AltitudeModeLineGraphData[3] = new ObservableCollection<KeyValuePair<DateTime, double>>();
                  AltitudeModeLineGraphData[4] = new ObservableCollection<KeyValuePair<DateTime, double>>();


                  this.DataContext = this;
                  motorPowerBarChart.DataContext = _motorPowerBarGraphData;
                  PidBarChart.DataContext = _pidBarGraphData;
                  imuYPRBarChart.DataContext = _imuYPRBarGraphData;
                  imuRateBarChart.DataContext = _imuRateBarGraphData;
                  rawRCBarChart.DataContext = _rawRCBarGraphData;
                  mappedRCBarChart.DataContext = _mappedRCBarGraphData;

                  _waypointLayer = new MapLayer();
                  _positionLayer = new MapLayer();
                  _plannedRouteLayer = new MapLayer();
                  _actualRouteLayer = new MapLayer();
                  Map.Children.Add(_waypointLayer);
                  Map.Children.Add(_positionLayer);
                  Map.Children.Add(_plannedRouteLayer);
                  Map.Children.Add(_actualRouteLayer);

                  _plannnedRoutePolyline = new MapPolyline();
                  _plannnedRoutePolyline.Locations = new LocationCollection();
                  _plannnedRoutePolyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
                  _plannnedRoutePolyline.StrokeThickness = 5;
                  _plannnedRoutePolyline.Opacity = 0.7;
                  _plannedRouteLayer.Children.Add(_plannnedRoutePolyline);

                  _actualRoutePolyline = new MapPolyline();
                  _actualRoutePolyline.Locations = new LocationCollection();
                  _actualRoutePolyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
                  _actualRoutePolyline.StrokeThickness = 5;
                  _actualRoutePolyline.Opacity = 0.7;
                  _actualRouteLayer.Children.Add(_actualRoutePolyline);

                  image = new Image();
                  image.Height = 50;
                  BitmapImage myBitmapImage = new BitmapImage();
                  myBitmapImage.BeginInit();
                  myBitmapImage.UriSource = new Uri("clear background.png", UriKind.Relative);
                  myBitmapImage.DecodePixelHeight = 50;
                  myBitmapImage.EndInit();
                  image.Source = myBitmapImage;
                  image.Opacity = 1.0;
                  image.Stretch = System.Windows.Media.Stretch.None;
                  _latitude = 53.811492580082;
                  _longitude = -1.56330633812645;
                  Location start = new Location(_latitude, _longitude);
                  Map.Center = start;
                  SetActualPos(_latitude, _longitude);

                  SerialCommunications.NewStatus += new SerialCommunications.StatusHandler(updateStatus);
            }

            #endregion

            #region Status event

            private void updateStatus(Status status)
            {
                  Dispatcher.Invoke(DispatcherPriority.Render, new Action(() =>
                  {
                        if (motorBarTabItem != null && motorBarTabItem.IsSelected || motorLineTabItem != null && motorLineTabItem.IsSelected)
                        {
                              foreach (KeyValuePair<string, float> keyValuePair in status.quadcopterStatus)
                              {
                                    switch (keyValuePair.Key)
                                    {
                                          case "M1":
                                                _motorPowerBarGraphData[0] = new KeyValuePair<String, double>("M1 " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                MotorPowerLineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (MotorPowerLineGraphData[0].Count > (1000))
                                                {
                                                      MotorPowerLineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          case "M2":
                                                _motorPowerBarGraphData[1] = new KeyValuePair<String, double>("M2 " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                MotorPowerLineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (MotorPowerLineGraphData[1].Count > (1000))
                                                {
                                                      MotorPowerLineGraphData[1].RemoveAt(0);
                                                };
                                                break;

                                          case "M3":
                                                _motorPowerBarGraphData[2] = new KeyValuePair<String, double>("M3 " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                MotorPowerLineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (MotorPowerLineGraphData[2].Count > (1000))
                                                {
                                                      MotorPowerLineGraphData[2].RemoveAt(0);
                                                }
                                                break;

                                          case "M4":
                                                _motorPowerBarGraphData[3] = new KeyValuePair<String, double>("M4 " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                MotorPowerLineGraphData[3].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (MotorPowerLineGraphData[3].Count > (1000))
                                                {
                                                      MotorPowerLineGraphData[3].RemoveAt(0);
                                                }
                                          break;

                                          default:
                                                break;
                                    }
                              }
                        }
                        else if (pidBarTabItem != null && pidBarTabItem.IsSelected || pidLineTabItem != null && pidLineTabItem.IsSelected)
                        {
                              foreach (KeyValuePair<string, float> keyValuePair in status.quadcopterStatus)
                              {
                                    switch (keyValuePair.Key)
                                    {
                                         case "YPID":
                                                _pidBarGraphData[0] = new KeyValuePair<String, double>("Yaw " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                PidLineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (PidLineGraphData[0].Count > (1000))
                                                {
                                                      PidLineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          case "PPID":
                                                _pidBarGraphData[1] = new KeyValuePair<String, double>("Pitch " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                PidLineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (PidLineGraphData[1].Count > (1000))
                                                {
                                                      PidLineGraphData[1].RemoveAt(0);
                                                }
                                                break;

                                          case "RPID":
                                                _pidBarGraphData[2] = new KeyValuePair<String, double>("Roll " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                PidLineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (PidLineGraphData[2].Count > (1000))
                                                {
                                                      PidLineGraphData[2].RemoveAt(0);
                                                }
                                                break;

                                          default:
                                                break;
                                    }
                              }
                        }
                        else if (imuBarTabItem != null && imuBarTabItem.IsSelected || imuLineTabItem != null && imuLineTabItem.IsSelected)
                        {
                              foreach (KeyValuePair<string, float> keyValuePair in status.quadcopterStatus)
                              {
                                    switch (keyValuePair.Key)
                                    {
                                          case "SY":
                                                _imuYPRBarGraphData[0] = new KeyValuePair<String, double>("Yaw " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                StabIMULineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (StabIMULineGraphData[0].Count > (1000))
                                                {
                                                      StabIMULineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          case "SP":
                                                _imuYPRBarGraphData[1] = new KeyValuePair<String, double>("Pitch " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                StabIMULineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (StabIMULineGraphData[1].Count > (1000))
                                                {
                                                      StabIMULineGraphData[1].RemoveAt(0);
                                                }
                                                break;

                                          case "SR":
                                                _imuYPRBarGraphData[2] = new KeyValuePair<String, double>("Roll " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                StabIMULineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (StabIMULineGraphData[2].Count > (1000))
                                                {
                                                      StabIMULineGraphData[2].RemoveAt(0);
                                                }
                                                break;

                                          case "RY":
                                                _imuRateBarGraphData[0] = new KeyValuePair<String, double>("Yaw " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                RateIMULineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (RateIMULineGraphData[0].Count > (1000))
                                                {
                                                      RateIMULineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          case "RP":
                                                _imuRateBarGraphData[1] = new KeyValuePair<String, double>("Pitch " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                RateIMULineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (RateIMULineGraphData[1].Count > (1000))
                                                {
                                                      RateIMULineGraphData[1].RemoveAt(0);
                                                }
                                                break;

                                          case "RR":
                                                _imuRateBarGraphData[2] = new KeyValuePair<String, double>("Roll " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                RateIMULineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (RateIMULineGraphData[2].Count > (1000))
                                                {
                                                      RateIMULineGraphData[2].RemoveAt(0);
                                                }
                                                break;

                                          default:
                                                break;
                                    }
                              }
                        }
                        else if (statusTabItem != null && statusTabItem.IsSelected)
                        {
                              foreach (KeyValuePair<string, float> keyValuePair in status.quadcopterStatus)
                              {
                                    switch (keyValuePair.Key)
                                    {
                                         case "Batt":
                                                if (keyValuePair.Value == 1) batteryLabel.Content = "Battery Level: Charged";
                                                else batteryLabel.Content = "Battery Level: Empty";
                                                break;

                                          case "Armed":
                                                if (keyValuePair.Value == 1)
                                                {
                                                      armedLabel.Content = "Armed: True";
                                                      settingsTabItem.IsEnabled = false;
                                                }
                                                else
                                                {
                                                      armedLabel.Content = "Armed: False";
                                                      settingsTabItem.IsEnabled = true;
                                                }
                                                break;

                                          case "Init":
                                                if (keyValuePair.Value == 1) initialisedLabel.Content = "Initialised: True";
                                                else initialisedLabel.Content = "Initialised: False";
                                                break;

                                          case "FlightMode":
                                                if (keyValuePair.Value == 0)
                                                {
                                                      modeLabel.Content = "Mode: Rate";
                                                }
                                                else if (keyValuePair.Value == 1)
                                                {
                                                      modeLabel.Content = "Mode: Stability";
                                                }
                                                else if (keyValuePair.Value == 2)
                                                {
                                                      modeLabel.Content = "Mode: None";
                                                }
                                                break;

                                          case "NavMode":
                                                if (keyValuePair.Value == 0)
                                                {
                                                     navModeLabel.Content = "Nav Mode: NONE";
                                                }
                                                else if (keyValuePair.Value == 1)
                                                {
                                                      navModeLabel.Content = "Nav Mode: ALTITUDE HOLD";
                                                }
                                                else if (keyValuePair.Value == 2)
                                                {
                                                      navModeLabel.Content = "Nav Mode: POSITION HOLD";
                                                }
                                                break;

                                          case "State":
                                               switch((int)keyValuePair.Value)
                                               {
                                                     case 0:
                                                           stateLabel.Content = "State: PREFLIGHT";
                                                           break;

                                                     case 1:
                                                           stateLabel.Content = "State: STANDBY";
                                                           break;

                                                     case 2:
                                                           stateLabel.Content = "State: GROUND READY";
                                                           break;

                                                     case 3:
                                                           stateLabel.Content = "State: MANUAL";
                                                           break;

                                                     case 4:
                                                           stateLabel.Content = "State: STABILISED";
                                                           break;

                                                     case 5:
                                                           stateLabel.Content = "State: AUTO";
                                                           break;

                                                     case 6:
                                                           stateLabel.Content = "State: ERROR";
                                                           break;

                                                     default:
                                                           break;
                                               }
                                               break;

                                          default:
                                                break;
                                    }
                              } 
                        }
                        else if (rcBarTabItem != null && rcBarTabItem.IsSelected || rcLineTabItem != null && rcLineTabItem.IsSelected)
                        {
                              foreach (KeyValuePair<string, float> keyValuePair in status.quadcopterStatus)
                              {
                                    switch (keyValuePair.Key)
                                    {
                                          case "MRCY":
                                                _mappedRCBarGraphData[0] = new KeyValuePair<String, double>("Yaw " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                MappedRCLineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (MappedRCLineGraphData[0].Count > (1000))
                                                {
                                                      MappedRCLineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          case "MRCP":
                                                _mappedRCBarGraphData[1] = new KeyValuePair<String, double>("Pitch " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                MappedRCLineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (MappedRCLineGraphData[1].Count > (1000))
                                                {
                                                      MappedRCLineGraphData[1].RemoveAt(0);
                                                }
                                                break;

                                          case "MRCR":
                                                _mappedRCBarGraphData[2] = new KeyValuePair<String, double>("Roll " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                MappedRCLineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (MappedRCLineGraphData[2].Count > (1000))
                                                {
                                                      MappedRCLineGraphData[2].RemoveAt(0);
                                                }
                                                break;

                                          case "MRCT":
                                                _mappedRCBarGraphData[3] = new KeyValuePair<String, double>("Thrust " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                MappedRCLineGraphData[3].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (MappedRCLineGraphData[3].Count > (1000))
                                                {
                                                      MappedRCLineGraphData[3].RemoveAt(0);
                                                }
                                                break;

                                          case "RRC1":
                                                _rawRCBarGraphData[0] = new KeyValuePair<String, double>("Channel 1 " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                RawRCLineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (RawRCLineGraphData[0].Count > (1000))
                                                {
                                                      RawRCLineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          case "RRC2":
                                                _rawRCBarGraphData[1] = new KeyValuePair<String, double>("Channel 2 " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                RawRCLineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (RawRCLineGraphData[1].Count > (1000))
                                                {
                                                      RawRCLineGraphData[1].RemoveAt(0);
                                                }
                                                break;

                                          case "RRC3":
                                                _rawRCBarGraphData[2] = new KeyValuePair<String, double>("Channel 3 " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                RawRCLineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (RawRCLineGraphData[2].Count > (1000))
                                                {
                                                      RawRCLineGraphData[2].RemoveAt(0);
                                                }
                                                break;

                                          case "RRC4":
                                                _rawRCBarGraphData[3] = new KeyValuePair<String, double>("Channel 4 " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                RawRCLineGraphData[3].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (RawRCLineGraphData[3].Count > (1000))
                                                {
                                                      RawRCLineGraphData[3].RemoveAt(0);
                                                }
                                                break;

                                          case "RRC5":
                                                _rawRCBarGraphData[4] = new KeyValuePair<String, double>("Channel 5 " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                RawRCLineGraphData[4].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (RawRCLineGraphData[4].Count > (1000))
                                                {
                                                      RawRCLineGraphData[4].RemoveAt(0);
                                                }
                                                break;

                                          case "RRC6":
                                                if (rcBarTabItem != null && rcBarTabItem.IsSelected || rcLineTabItem != null && rcLineTabItem.IsSelected)
                                                {
                                                      _rawRCBarGraphData[5] = new KeyValuePair<String, double>("Channel 6 " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                      RawRCLineGraphData[5].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                      if (RawRCLineGraphData[5].Count > (1000))
                                                      {
                                                            RawRCLineGraphData[5].RemoveAt(0);
                                                      }
                                                }
                                                break;

                                          case "RRC7":
                                                _rawRCBarGraphData[6] = new KeyValuePair<String, double>("Channel 7 " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                RawRCLineGraphData[6].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (RawRCLineGraphData[6].Count > (1000))
                                                {
                                                      RawRCLineGraphData[6].RemoveAt(0);
                                                }
                                                break;

                                          case "RRC8":
                                                _rawRCBarGraphData[7] = new KeyValuePair<String, double>("Channel 8 " + String.Format("{0:0.00}", keyValuePair.Value), keyValuePair.Value);
                                                RawRCLineGraphData[7].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (RawRCLineGraphData[7].Count > (1000))
                                                {
                                                      RawRCLineGraphData[7].RemoveAt(0);
                                                }
                                                break;

                                          default:
                                                break;
                                    }
                              }
                        }
                        else if (settingsTabItem != null && settingsTabItem.IsSelected)
                        {
                              foreach (KeyValuePair<string, float> keyValuePair in status.quadcopterStatus)
                              {
                                    switch (keyValuePair.Key)
                                    {
                                          case "RYPIDP":
                                                if (!yawRatePIDControllerPTextBox.IsFocused && !setYawPID1PButton.IsFocused) yawRatePIDControllerPTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "RYPIDI":
                                                if (!yawRatePIDControllerITextBox.IsFocused && !setYawPID1IButton.IsFocused) yawRatePIDControllerITextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "RYPIDD":
                                                if (!yawRatePIDControllerDTextBox.IsFocused && !setYawPID1DButton.IsFocused) yawRatePIDControllerDTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "RPPIDP":
                                                if (!pitchRatePIDControllerPTextBox.IsFocused && !setPitchPID1PButton.IsFocused) pitchRatePIDControllerPTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "RPPIDI":
                                                if (!pitchRatePIDControllerITextBox.IsFocused && !setPitchPID1IButton.IsFocused) pitchRatePIDControllerITextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "RPPIDD":
                                                if (!pitchRatePIDControllerDTextBox.IsFocused && !setPitchPID1DButton.IsFocused) pitchRatePIDControllerDTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "RRPIDP":
                                                if (!rollRatePIDControllerPTextBox.IsFocused && !setRollPID1PButton.IsFocused) rollRatePIDControllerPTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "RRPIDI":
                                                if (!rollRatePIDControllerITextBox.IsFocused && !setRollPID1IButton.IsFocused) rollRatePIDControllerITextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "RRPIDD":
                                                if (!rollRatePIDControllerDTextBox.IsFocused && !setRollPID1DButton.IsFocused) rollRatePIDControllerDTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "SYPIDP":
                                                if (!yawStabPIDControllerPTextBox.IsFocused && !setYawPID2PButton.IsFocused) yawStabPIDControllerPTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "SYPIDI":
                                                if (!yawStabPIDControllerITextBox.IsFocused && !setYawPID2IButton.IsFocused) yawStabPIDControllerITextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "SYPIDD":
                                                if (!yawStabPIDControllerDTextBox.IsFocused && !setYawPID2DButton.IsFocused) yawStabPIDControllerDTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "SPPIDP":
                                                if (!pitchStabPIDControllerPTextBox.IsFocused && !setPitchPID2PButton.IsFocused) pitchStabPIDControllerPTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "SPPIDI":
                                                if (!pitchStabPIDControllerITextBox.IsFocused && !setPitchPID2IButton.IsFocused) pitchStabPIDControllerITextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "SPPIDD":
                                                if (!pitchStabPIDControllerDTextBox.IsFocused && !setPitchPID2DButton.IsFocused) pitchStabPIDControllerDTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "SRPIDP":
                                                if (!rollStabPIDControllerPTextBox.IsFocused && !setRollPID2PButton.IsFocused) rollStabPIDControllerPTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "SRPIDI":
                                                if (!rollStabPIDControllerITextBox.IsFocused && !setRollPID2IButton.IsFocused) rollStabPIDControllerITextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "SRPIDD":
                                                if (!rollStabPIDControllerDTextBox.IsFocused && !setRollPID2DButton.IsFocused) rollStabPIDControllerDTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "ARPIDP":
                                                if (!altitudeRatePIDControllerPTextBox.IsFocused && !altitudeRatePIDControllerPTextBox.IsFocused) altitudeRatePIDControllerPTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "ARPIDI":
                                                if (!altitudeRatePIDControllerITextBox.IsFocused && !altitudeRatePIDControllerITextBox.IsFocused) altitudeRatePIDControllerITextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "ARPIDD":
                                                if (!altitudeRatePIDControllerDTextBox.IsFocused && !altitudeRatePIDControllerDTextBox.IsFocused) altitudeRatePIDControllerDTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "ASPIDP":
                                                if (!altitudeStabPIDControllerPTextBox.IsFocused && !altitudeStabPIDControllerPTextBox.IsFocused) altitudeStabPIDControllerPTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "ASPIDI":
                                                if (!altitudeStabPIDControllerITextBox.IsFocused && !altitudeStabPIDControllerITextBox.IsFocused) altitudeStabPIDControllerITextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          case "ASPIDD":
                                                if (!altitudeStabPIDControllerDTextBox.IsFocused && !altitudeStabPIDControllerDTextBox.IsFocused) altitudeStabPIDControllerDTextBox.Text = keyValuePair.Value.ToString();
                                                break;

                                          default:
                                                break;
                                    }
                              } 
                        }
                        else if (gpsTabItem != null && gpsTabItem.IsSelected)
                        {
                              foreach (KeyValuePair<string, float> keyValuePair in status.quadcopterStatus)
                              {
                                    switch (keyValuePair.Key)
                                    {
                                          case "GLat":
                                                latitudeLabel.Content = "Latitude: " + keyValuePair.Value.ToString();
                                                _latitude = keyValuePair.Value;
                                                break;

                                          case "GLon":
                                                longitudeLabel.Content = "Longitude: " + keyValuePair.Value.ToString();
                                                _longitude = keyValuePair.Value;
                                                break;

                                          case "GAlt":
                                                altitudeLabel.Content = "Altitude: " + keyValuePair.Value.ToString();
                                                break;

                                          case "GAng":
                                                courseLabel.Content = "Course: " + keyValuePair.Value.ToString();
                                                break;

                                          case "GSpd":
                                                speedLabel.Content = "Speed: " + keyValuePair.Value.ToString();
                                                break;

                                          case "GInit":
                                                if (keyValuePair.Value == 1)
                                                {
                                                      gpsConnectedLabel.Content = "Connected: True";
                                                }
                                                else
                                                {
                                                      gpsConnectedLabel.Content = "Connected: False";
                                                }
                                                break;

                                          default:
                                                break;
                                    }
                              }
                              SetActualPos(_latitude, _longitude);
                        }
                        else if (zeroTabItem != null && zeroTabItem.IsSelected)
                        {
                              foreach (KeyValuePair<string, float> keyValuePair in status.quadcopterStatus)
                              {
                                    switch (keyValuePair.Key)
                                    {
                                          case "Lev":
                                                if (keyValuePair.Value == 1)
                                                {
                                                     // levelLabel.Content = "Level: True";
                                                }
                                              //  else levelLabel.Content = "Level: False";
                                                break;

                                          case "ZP":
                                                zeroPitchLabel.Content = "Zero Pitch: " + keyValuePair.Value.ToString();
                                                break;

                                          case "ZR":
                                                zeroRollLabel.Content = "Zero Roll: " + keyValuePair.Value.ToString();
                                                break;

                                          default:
                                                break;
                                    }
                              }
                        }
                        else if (rateTuningTabItem != null && rateTuningTabItem.IsSelected)
                        {
                              foreach (KeyValuePair<string, float> keyValuePair in status.quadcopterStatus)
                              {
                                    switch (keyValuePair.Key)
                                    {
                                         case "RYPIDO":
                                                YawTuningRateLineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (YawTuningRateLineGraphData[2].Count > (1000))
                                                {
                                                      YawTuningRateLineGraphData[2].RemoveAt(0);
                                                }
                                                break;

                                          case "RPPIDO":
                                                PitchTuningRateLineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (PitchTuningRateLineGraphData[2].Count > (1000))
                                                {
                                                      PitchTuningRateLineGraphData[2].RemoveAt(0);
                                                }
                                                break;

                                          case "RRPIDO":
                                                RollTuningRateLineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (RollTuningRateLineGraphData[2].Count > (1000))
                                                {
                                                      RollTuningRateLineGraphData[2].RemoveAt(0);
                                                }
                                                break;


                                          case "RYPIDP":
                                                YawTuningRateLineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (YawTuningRateLineGraphData[1].Count > (1000))
                                                {
                                                      YawTuningRateLineGraphData[1].RemoveAt(0);
                                                }
                                                break;

                                          case "RPPIDP":
                                                PitchTuningRateLineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (PitchTuningRateLineGraphData[1].Count > (1000))
                                                {
                                                      PitchTuningRateLineGraphData[1].RemoveAt(0);
                                                }
                                                break;

                                          case "RRPIDP":
                                                RollTuningRateLineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (RollTuningRateLineGraphData[1].Count > (1000))
                                                {
                                                      RollTuningRateLineGraphData[1].RemoveAt(0);
                                                }
                                          break;

                                          case "RYPIDS":
                                                YawTuningRateLineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (YawTuningRateLineGraphData[0].Count > (1000))
                                                {
                                                      YawTuningRateLineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          case "RPPIDS":
                                                PitchTuningRateLineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (PitchTuningRateLineGraphData[0].Count > (1000))
                                                {
                                                      PitchTuningRateLineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          case "RRPIDS":
                                                RollTuningRateLineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (RollTuningRateLineGraphData[0].Count > (1000))
                                                {
                                                      RollTuningRateLineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          default:
                                                break;
                                    }
                              }
                        }
                        else if (stabTuningTabItem != null && stabTuningTabItem.IsSelected)
                        {
                              foreach (KeyValuePair<string, float> keyValuePair in status.quadcopterStatus)
                              {
                                    switch (keyValuePair.Key)
                                    {
                                          case "SYPIDO":
                                                YawTuningStabLineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (YawTuningStabLineGraphData[2].Count > (1000))
                                                {
                                                      YawTuningStabLineGraphData[2].RemoveAt(0);
                                                }
                                                break;

                                          case "SPPIDO":
                                                PitchTuningStabLineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (PitchTuningStabLineGraphData[2].Count > (1000))
                                                {
                                                      PitchTuningStabLineGraphData[2].RemoveAt(0);
                                                }
                                                break;

                                          case "SRPIDO":
                                                RollTuningStabLineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (RollTuningStabLineGraphData[2].Count > (1000))
                                                {
                                                      RollTuningStabLineGraphData[2].RemoveAt(0);
                                                }
                                                break;


                                          case "SYPIDP":
                                                YawTuningStabLineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (YawTuningStabLineGraphData[1].Count > (1000))
                                                {
                                                      YawTuningStabLineGraphData[1].RemoveAt(0);
                                                }
                                                break;

                                          case "SPPIDP":
                                                PitchTuningStabLineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (PitchTuningStabLineGraphData[1].Count > (1000))
                                                {
                                                      PitchTuningStabLineGraphData[1].RemoveAt(0);
                                                }
                                                break;

                                          case "SRPIDP":
                                                RollTuningStabLineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (RollTuningStabLineGraphData[1].Count > (1000))
                                                {
                                                      RollTuningStabLineGraphData[1].RemoveAt(0);
                                                }
                                                break;


                                          case "SYPIDS":
                                                YawTuningStabLineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (YawTuningStabLineGraphData[0].Count > (1000))
                                                {
                                                      YawTuningStabLineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          case "SPPIDS":
                                                PitchTuningStabLineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (PitchTuningStabLineGraphData[0].Count > (1000))
                                                {
                                                      PitchTuningStabLineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          case "SRPIDS":
                                                RollTuningStabLineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));
                                                if (RollTuningStabLineGraphData[0].Count > (1000))
                                                {
                                                      RollTuningStabLineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          default:
                                                break;
                                    }
                              }
                        }
                        else if (altitudeLineTabItem != null && altitudeLineTabItem.IsSelected)
                        {
                              foreach (KeyValuePair<string, float> keyValuePair in status.quadcopterStatus)
                              {
                                    switch (keyValuePair.Key)
                                    {
                                          case "ZVEL":
                                                AltitudeLineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value * 10));

                                                if (AltitudeLineGraphData[0].Count > (1000))
                                                {
                                                      AltitudeLineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          case "CAlt":
                                                AltitudeLineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (AltitudeLineGraphData[2].Count > (1000))
                                                {
                                                      AltitudeLineGraphData[2].RemoveAt(0);
                                                }
                                                break;

                                          case "BAlt":
                                                //AltitudeLineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (AltitudeLineGraphData[1].Count > (1000))
                                                {
                                                      AltitudeLineGraphData[1].RemoveAt(0);
                                                }
                                                break;

                                          case "LAlt":
                                                AltitudeLineGraphData[3].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (AltitudeLineGraphData[3].Count > (1000))
                                                {
                                                      AltitudeLineGraphData[3].RemoveAt(0);
                                                }
                                                break;

                                          default:
                                                break;
                                    }
                              }
                        }
                        else if (velocityLineTabItem != null && velocityLineTabItem.IsSelected)
                        {
                              foreach (KeyValuePair<string, float> keyValuePair in status.quadcopterStatus)
                              {
                                    switch (keyValuePair.Key)
                                    {
                                          case "XVEL":
                                                VelocityLineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (VelocityLineGraphData[0].Count > (1000))
                                                {
                                                      VelocityLineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          case "YVEL":
                                                VelocityLineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (VelocityLineGraphData[1].Count > (1000))
                                                {
                                                      VelocityLineGraphData[1].RemoveAt(0);
                                                }
                                                break;

                                          case "ZVEL":
                                                VelocityLineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (VelocityLineGraphData[2].Count > (1000))
                                                {
                                                      VelocityLineGraphData[2].RemoveAt(0);
                                                }
                                                break;

                                          default:
                                                break;
                                    }
                              }
                        }
                        else if (lidarLineTabItem != null && lidarLineTabItem.IsSelected)
                        {
                              foreach (KeyValuePair<string, float> keyValuePair in status.quadcopterStatus)
                              {
                                    switch (keyValuePair.Key)
                                    {
                                          case "SP":
                                                LidarLineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (LidarLineGraphData[0].Count > (1000))
                                                {
                                                      LidarLineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          case "SR":
                                                LidarLineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (LidarLineGraphData[1].Count > (1000))
                                                {
                                                      LidarLineGraphData[1].RemoveAt(0);
                                                }
                                                break;

                                          case "LAlt":
                                                LidarLineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (LidarLineGraphData[2].Count > (1000))
                                                {
                                                      LidarLineGraphData[2].RemoveAt(0);
                                                }
                                                break;

                                          default:
                                                break;
                                    }
                              }
                        }
                        else if (altitudeModeLineTabItem != null && altitudeModeLineTabItem.IsSelected)
                        {
                              foreach (KeyValuePair<string, float> keyValuePair in status.quadcopterStatus)
                              {
                                    switch (keyValuePair.Key)
                                    {
                                          case "ACR":
                                                AltitudeModeLineGraphData[0].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (AltitudeModeLineGraphData[0].Count > (1000))
                                                {
                                                      AltitudeModeLineGraphData[0].RemoveAt(0);
                                                }
                                                break;

                                          case "ATA":
                                                AltitudeModeLineGraphData[1].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (AltitudeModeLineGraphData[1].Count > (1000))
                                                {
                                                      AltitudeModeLineGraphData[1].RemoveAt(0);
                                                }
                                                break;

                                          case "ATHR":
                                                AltitudeModeLineGraphData[2].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (AltitudeModeLineGraphData[2].Count > (1000))
                                                {
                                                      AltitudeModeLineGraphData[2].RemoveAt(0);
                                                }
                                                break;

                                          case "CAlt":
                                                AltitudeModeLineGraphData[3].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (AltitudeModeLineGraphData[3].Count > (1000))
                                                {
                                                      AltitudeModeLineGraphData[3].RemoveAt(0);
                                                }
                                                break;

                                          case "ZVEL":
                                                AltitudeModeLineGraphData[4].Add(new KeyValuePair<DateTime, double>(DateTime.Now, keyValuePair.Value));

                                                if (AltitudeModeLineGraphData[4].Count > (1000))
                                                {
                                                      AltitudeModeLineGraphData[4].RemoveAt(0);
                                                }
                                                break;

                                          default:
                                                break;
                                    }
                              }
                        }                  
                  }));
            }

            #endregion

            #region Connect

            private void connectButton_Click(object sender, RoutedEventArgs e)
            {
                  if (SerialCommunications.IsSerialPortOpen() == false)
                  {
                        SerialCommunications.OpenSerialPort(Convert.ToInt32(portTextBox.Text));
                        if (SerialCommunications.IsSerialPortOpen() == true)
                        {
                              connectButton.Content = "Disconnect";
                              connectedLabel.Content = "Connected: True";
                        }
                        else
                        {
                              MessageBox.Show("Failed to open COM port, maybe it does not exist", "Error");
                        }
                  }
                  else
                  {
                        SerialCommunications.CloseSerialPort();
                        connectButton.Content = "Connect";
                        connectedLabel.Content = "Connected:";
                        initialisedLabel.Content = "Initialised:";
                        armedLabel.Content = "Armed:";
                        batteryLabel.Content = "Battery Level:";
                        modeLabel.Content = "Mode:";
                        stateLabel.Content = "State:";
                  }
            }

            #endregion

            #region Commands

            private void setYawPID1PButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetYawRatePIDControllerP(yawRatePIDControllerPTextBox.Text);
            }

            private void setYawPID1IButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetYawRatePIDControllerI(yawRatePIDControllerITextBox.Text);
            }

            private void setYawPID1DButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetYawRatePIDControllerD(yawRatePIDControllerDTextBox.Text);
            }

            private void setPitchPID1PButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetPitchRatePIDControllerP(pitchRatePIDControllerPTextBox.Text);
            }

            private void setPitchPID1IButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetPitchRatePIDControllerI(pitchRatePIDControllerITextBox.Text);
            }

            private void setPitchPID1DButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetPitchRatePIDControllerD(pitchRatePIDControllerDTextBox.Text);
            }

            private void setRollPID1PButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetRollRatePIDControllerP(rollRatePIDControllerPTextBox.Text);
            }

            private void setRollPID1IButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetRollRatePIDControllerI(rollRatePIDControllerITextBox.Text);
            }

            private void setRollPID1DButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetRollRatePIDControllerD(rollRatePIDControllerDTextBox.Text);
            }

            private void setYawPID2PButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetYawStabPIDControllerP(yawStabPIDControllerPTextBox.Text);
            }

            private void setYawPID2IButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetYawStabPIDControllerI(yawStabPIDControllerITextBox.Text);
            }

            private void setYawPID2DButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetYawStabPIDControllerD(yawStabPIDControllerDTextBox.Text);
            }

            private void setPitchPID2PButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetPitchStabPIDControllerP(pitchStabPIDControllerPTextBox.Text);
            }

            private void setPitchPID2IButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetPitchStabPIDControllerI(pitchStabPIDControllerITextBox.Text);
            }

            private void setPitchPID2DButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetPitchStabPIDControllerD(pitchStabPIDControllerDTextBox.Text);
            }

            private void setRollPID2PButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetRollStabPIDControllerP(rollStabPIDControllerPTextBox.Text);
            }

            private void setRollPID2IButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetRollStabPIDControllerI(rollStabPIDControllerITextBox.Text);
            }

            private void setRollPID2DButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetRollStabPIDControllerD(rollStabPIDControllerDTextBox.Text);
            }

            private void setAltitudeRatePIDPButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetAltitudeRatePIDControllerP(altitudeRatePIDControllerPTextBox.Text);
            }

            private void setAltitudeRatePIDIButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetAltitudeRatePIDControllerI(altitudeRatePIDControllerITextBox.Text);
            }

            private void setAltitudeRatePIDDButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetAltitudeRatePIDControllerD(altitudeRatePIDControllerDTextBox.Text);
            }

            private void setAltitudeStabPIDPButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetAltitudeStabPIDControllerP(altitudeStabPIDControllerPTextBox.Text);
            }

            private void setAltitudeStabPIDIButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetAltitudeStabPIDControllerI(altitudeStabPIDControllerITextBox.Text);
            }

            private void setAltitudeStabPIDDButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.SetAltitudeStabPIDControllerD(altitudeStabPIDControllerDTextBox.Text);
            }

            private void zeroOffsetButton_Click(object sender, RoutedEventArgs e)
            {
                  SerialCommunications.ZeroOffset();
            }

            private void mainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                  if (motorBarTabItem != null && motorBarTabItem.IsSelected || motorLineTabItem != null && motorLineTabItem.IsSelected)
                  {
                        SerialCommunications.SetCommsMode("0");
                  }
                  if (pidBarTabItem != null && pidBarTabItem.IsSelected || pidLineTabItem != null && pidLineTabItem.IsSelected)
                  {
                        SerialCommunications.SetCommsMode("1");
                  }
                  if (imuBarTabItem != null && imuBarTabItem.IsSelected || imuLineTabItem != null && imuLineTabItem.IsSelected)
                  {
                        SerialCommunications.SetCommsMode("2");
                  }
                  if (statusTabItem != null && statusTabItem.IsSelected)
                  {
                        SerialCommunications.SetCommsMode("3");
                  }
                  if (rcBarTabItem != null && rcBarTabItem.IsSelected || rcLineTabItem != null && rcLineTabItem.IsSelected)
                  {
                        SerialCommunications.SetCommsMode("4");
                  }
                  if (settingsTabItem != null && settingsTabItem.IsSelected)
                  {
                        SerialCommunications.SetCommsMode("5");
                  }
                  if (gpsTabItem != null && gpsTabItem.IsSelected)
                  {
                        SerialCommunications.SetCommsMode("6");
                  }
                  if (zeroTabItem != null && zeroTabItem.IsSelected)
                  {
                        SerialCommunications.SetCommsMode("7");
                  }
                  if (rateTuningTabItem != null && rateTuningTabItem.IsSelected)
                  {
                        SerialCommunications.SetCommsMode("8");
                  }
                  if (stabTuningTabItem != null && stabTuningTabItem.IsSelected)
                  {
                        SerialCommunications.SetCommsMode("9");
                  }
                  if (altitudeLineTabItem != null && altitudeLineTabItem.IsSelected)
                  {
                        SerialCommunications.SetCommsMode("10");
                  }
                  if (velocityLineTabItem != null && velocityLineTabItem.IsSelected)
                  {
                        SerialCommunications.SetCommsMode("11");
                  }
                  if (altitudeModeLineTabItem != null && altitudeModeLineTabItem.IsSelected)
                  {
                        SerialCommunications.SetCommsMode("12");
                  }
                  if (lidarLineTabItem != null && lidarLineTabItem.IsSelected)
                  {
                        SerialCommunications.SetCommsMode("13");
                  }
            }

            #endregion

            #region Mapping

            private void MapWithPushpins_MouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
                  // Disables the default mouse double-click action.
                  e.Handled = true;

                  //Get the mouse click coordinates
                  Point mousePosition = e.GetPosition(Map);

                  //Convert the mouse coordinates to a location on the map
                  Location location = Map.ViewportPointToLocation(mousePosition);
            
                  // The pushpin to add to the map.
                  Pushpin pin = new Pushpin();
                  pin.Location = location;
            
                  // Adds the pushpin to the map.
                  _waypointLayer.Children.Add(pin);

                  //Tooltip
                  int waypointNo = _waypointLayer.Children.Count;
                  string tooltip = "Waypoint " + waypointNo + "\r\nLat: " + pin.Location.Latitude + "\r\nLon: " + pin.Location.Longitude + "\r\n";
                  ToolTipService.SetToolTip(pin, tooltip);

                  //Planned Route
                  _plannnedRoutePolyline.Locations.Add(location);
                  
            }

            private void SetActualPos(double lat, double lon)
            {
                  //The map location to place the image at
                  Location location = new Location(lat, lon);
                  //Center the image around the location specified
                  PositionOrigin position = PositionOrigin.Center;

                  //Add the image to the defined map layer
                  if(_positionLayer.Children.Count != 0) _positionLayer.Children.RemoveAt(0);
                  _positionLayer.AddChild(image, location, position);

                  //Actual route
                  _actualRoutePolyline.Locations.Add(location);

                  //Centre map on location
                  Map.Center = location;

            }

            #endregion

      }   
}
