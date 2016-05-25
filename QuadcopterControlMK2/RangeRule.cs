using System;
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;

namespace QuadcopterControlMK2
{
      public class IntegerValidationRule : ValidationRule
      {
            private int _min;
            private int _max;

            public IntegerValidationRule()
            {
            }

            public int Min
            {
                  get { return _min; }
                  set { _min = value; }
            }

            public int Max
            {
                  get { return _max; }
                  set { _max = value; }
            }

            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                  int number = 0;

                  try
                  {
                        if (((string)value).Length > 0)
                              number = Int32.Parse((String)value);
                  }
                  catch (Exception e)
                  {
                        return new ValidationResult(false, "Illegal characters or " + e.Message);
                  }

                  if ((number < Min) || (number > Max))
                  {
                        return new ValidationResult(false,
                          "Please enter a value in the range: " + Min + " - " + Max + ".");
                  }
                  else
                  {
                        return new ValidationResult(true, null);
                  }
            }
      }

      public class DoubleValidationRule : ValidationRule
      {
            private int _min;
            private int _max;

            public DoubleValidationRule()
            {
            }

            public int Min
            {
                  get { return _min; }
                  set { _min = value; }
            }

            public int Max
            {
                  get { return _max; }
                  set { _max = value; }
            }

            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                  double number = 0;

                  try
                  {
                        if (((string)value).Length > 0)
                              number = Double.Parse((String)value);
                  }
                  catch (Exception e)
                  {
                        return new ValidationResult(false, "Illegal characters or " + e.Message);
                  }

                  if ((number < Min) || (number > Max))
                  {
                        return new ValidationResult(false,
                          "Please enter a value in the range: " + Min + " - " + Max + ".");
                  }
                  else
                  {
                        return new ValidationResult(true, null);
                  }
            }
      }
}
