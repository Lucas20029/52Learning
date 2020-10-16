﻿using System.Collections.Generic;

namespace _52Learning
{
    public class VideoSegment:Segment
    {
        public VideoSegment()
        {

        }
        public VideoSegment(double start,double end) : base(start, end)
        {

        }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
