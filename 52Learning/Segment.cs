using System.Collections.Generic;

namespace _52Learning
{
    public class Segment
    {
        public double Start { get; set; }             
        public double End { get; set; }
        public string Name
        {
            get
            {
                return $"{Start.ToString("0.00")}-{End.ToString("0.00")}";
            }
        }
        public override bool Equals(object obj)
        {
            if(obj is Segment)
            {
                var seg = ((Segment)obj);
                return seg.Start == seg.End;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
