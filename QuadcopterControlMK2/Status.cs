using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuadcopterControlMK2
{
      public class Status:EventArgs
      {
            public Dictionary<string, float> quadcopterStatus { get; set; }

            public Status()
            {
                  quadcopterStatus = new Dictionary<string,float>();
            }

            public void AddKeyValuePair(string key, float value)
            {
                  if(!quadcopterStatus.ContainsKey(key)) quadcopterStatus.Add(key, value);
            }
      }
}
