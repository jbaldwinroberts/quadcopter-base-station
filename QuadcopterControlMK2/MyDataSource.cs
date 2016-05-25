using System;

namespace QuadcopterControlMK2
{
      public class MyDataSource
      {
            private int _comPort;
            private double _yaw;
            private double _pitch;
            private double _roll;
            private double _thrust;
            private double _yawRatePIDControllerP;
            private double _yawRatePIDControllerI;
            private double _yawRatePIDControllerD;
            private double _pitchRatePIDControllerP;
            private double _pitchRatePIDControllerI;
            private double _pitchRatePIDControllerD;
            private double _rollRatePIDControllerP;
            private double _rollRatePIDControllerI;
            private double _rollRatePIDControllerD;
            private double _yawStabPIDControllerP;
            private double _yawStabPIDControllerI;
            private double _yawStabPIDControllerD;
            private double _pitchStabPIDControllerP;
            private double _pitchStabPIDControllerI;
            private double _pitchStabPIDControllerD;
            private double _rollStabPIDControllerP;
            private double _rollStabPIDControllerI;
            private double _rollStabPIDControllerD;
            private double _altitudeRatePIDControllerP;
            private double _altitudeRatePIDControllerI;
            private double _altitudeRatePIDControllerD;
            private double _altitudeStabPIDControllerP;
            private double _altitudeStabPIDControllerI;
            private double _altitudeStabPIDControllerD;

            public MyDataSource()
            {
                  comPort = 9;
                  yaw = 0;
                  pitch = 0;
                  roll = 0;
                  thrust = 0;
                  _yawRatePIDControllerP = 0;
                  _yawRatePIDControllerI = 0;
                  _yawRatePIDControllerD = 0;
                  _pitchRatePIDControllerP = 0;
                  _pitchRatePIDControllerI = 0;
                  _pitchRatePIDControllerD = 0;
                  _rollRatePIDControllerP = 0;
                  _rollRatePIDControllerI = 0;
                  _rollRatePIDControllerD = 0;
                  _yawStabPIDControllerP = 0;
                  _yawStabPIDControllerI = 0;
                  _yawStabPIDControllerD = 0;
                  _pitchStabPIDControllerP = 0;
                  _pitchStabPIDControllerI = 0;
                  _pitchStabPIDControllerD = 0;
                  _rollStabPIDControllerP = 0;
                  _rollStabPIDControllerI = 0;
                  _rollStabPIDControllerD = 0;
                  _altitudeRatePIDControllerP = 0;
                  _altitudeRatePIDControllerI = 0;
                  _altitudeRatePIDControllerD = 0;
                  _altitudeStabPIDControllerP = 0;
                  _altitudeStabPIDControllerI = 0;
                  _altitudeStabPIDControllerD = 0;
            }

            public int comPort
            {
                  get { return _comPort; }
                  set { _comPort = value; }
            }

            public double yaw
            {
                  get { return _yaw; }
                  set { _yaw = value; }
            }

            public double pitch
            {
                  get { return _pitch; }
                  set { _pitch = value; }
            }

            public double roll
            {
                  get { return _roll; }
                  set { _roll = value; }
            }

            public double thrust
            {
                  get { return _thrust; }
                  set { _thrust = value; }
            }

            public double yawRatePIDControllerP
            {
                  get { return _yawRatePIDControllerP; }
                  set { _yawRatePIDControllerP = value; }
            }

            public double yawRatePIDControllerI
            {
                  get { return _yawRatePIDControllerI; }
                  set { _yawRatePIDControllerI = value; }
            }

            public double yawRatePIDControllerD
            {
                  get { return _yawRatePIDControllerD; }
                  set { _yawRatePIDControllerD = value; }
            }

            public double pitchRatePIDControllerP
            {
                  get { return _pitchRatePIDControllerP; }
                  set { _pitchRatePIDControllerP = value; }
            }

            public double pitchRatePIDControllerI
            {
                  get { return _pitchRatePIDControllerI; }
                  set { _pitchRatePIDControllerI = value; }
            }

            public double pitchRatePIDControllerD
            {
                  get { return _pitchRatePIDControllerD; }
                  set { _pitchRatePIDControllerD = value; }
            }

            public double rollRatePIDControllerP
            {
                  get { return _rollRatePIDControllerP; }
                  set { _rollRatePIDControllerP = value; }
            }

            public double rollRatePIDControllerI
            {
                  get { return _rollRatePIDControllerI; }
                  set { _rollRatePIDControllerI = value; }
            }

            public double rollRatePIDControllerD
            {
                  get { return _rollRatePIDControllerD; }
                  set { _rollRatePIDControllerD = value; }
            }

            public double yawStabPIDControllerP
            {
                  get { return _yawStabPIDControllerP; }
                  set { _yawStabPIDControllerP = value; }
            }

            public double yawStabPIDControllerI
            {
                  get { return _yawStabPIDControllerI; }
                  set { _yawStabPIDControllerI = value; }
            }

            public double yawStabPIDControllerD
            {
                  get { return _yawStabPIDControllerD; }
                  set { _yawStabPIDControllerD = value; }
            }

            public double pitchStabPIDControllerP
            {
                  get { return _pitchStabPIDControllerP; }
                  set { _pitchStabPIDControllerP = value; }
            }

            public double pitchStabPIDControllerI
            {
                  get { return _pitchStabPIDControllerI; }
                  set { _pitchStabPIDControllerI = value; }
            }

            public double pitchStabPIDControllerD
            {
                  get { return _pitchStabPIDControllerD; }
                  set { _pitchStabPIDControllerD = value; }
            }

            public double rollStabPIDControllerP
            {
                  get { return _rollStabPIDControllerP; }
                  set { _rollStabPIDControllerP = value; }
            }

            public double rollStabPIDControllerI
            {
                  get { return _rollStabPIDControllerI; }
                  set { _rollStabPIDControllerI = value; }
            }

            public double rollStabPIDControllerD
            {
                  get { return _rollStabPIDControllerD; }
                  set { _rollStabPIDControllerD = value; }
            }

            public double altitudeRatePIDControllerP
            {
                  get { return _altitudeRatePIDControllerP; }
                  set { _altitudeRatePIDControllerP = value; }
            }

            public double altitudeRatePIDControllerI
            {
                  get { return _altitudeRatePIDControllerI; }
                  set { _altitudeRatePIDControllerI = value; }
            }

            public double altitudeRatePIDControllerD
            {
                  get { return _altitudeRatePIDControllerD; }
                  set { _altitudeRatePIDControllerD = value; }
            }

            public double altitudeStabPIDControllerP
            {
                  get { return _altitudeStabPIDControllerP; }
                  set { _altitudeStabPIDControllerP = value; }
            }

            public double altitudeStabPIDControllerI
            {
                  get { return _altitudeStabPIDControllerI; }
                  set { _altitudeStabPIDControllerI = value; }
            }

            public double altitudeStabPIDControllerD
            {
                  get { return _altitudeStabPIDControllerD; }
                  set { _altitudeStabPIDControllerD = value; }
            }
      }
}
