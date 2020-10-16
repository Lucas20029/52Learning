using System;
using System.Collections.Generic;

namespace _52Learning
{
    public class Segment
    {
        public Segment()
        {

        }
        public Segment(double start, double end)
        {
            Id = Guid.NewGuid();
            Start = start;
            End = end;
        }
        public Guid Id { get; set; }
        public double Start { get; set; }             
        public double End { get; set; }
        public string Name
        {
            get
            {
                return $"{Start.ToString("0.0")}-{End.ToString("0.0")}";
            }
        }
        
        private string secondsToTimeStr(double secondStamp) 
        {
            DateTime dateTime = DateTime.MinValue;
            dateTime.AddSeconds(secondStamp);
            if (dateTime.Hour != 0)
                return $"{dateTime.ToString("HH:mm:ss:f")}";
            if (dateTime.Minute != 0)
                return $"{dateTime.ToString("mm:ss:f")}";
            return dateTime.ToString("ss:f");
        }
        public double timeStrToSeconds(string str)
        {
            var times =str.Split(':');
            if (times.Length == 3)
                return int.Parse(times[0]) * 3600 + int.Parse(times[1]) * 60 + double.Parse(times[2]);
            if(times.Length==2)
                return int.Parse(times[1]) * 60 + double.Parse(times[2]);
            if(times.Length==1)
                return double.Parse(times[2]);
            return 0;
        }
    }
}
