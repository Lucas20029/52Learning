using System.Collections.Generic;

namespace _52Learning
{
    public class VideoInfo
    {
        public VideoInfo()
        {
        }
        public VideoInfo(string videoPath)
        {
            VideoPath = videoPath;
        }

        public string VideoPath { get; set; } 
        public List<VideoSegment> Segments { get; set; } = new List<VideoSegment>();

        public void AddSegment(double start, double end)
        {
            if (Segments == null)
                Segments = new List<VideoSegment>();
            Segments.Add(new VideoSegment(start, end)
            {
                VideoPath = VideoPath
            });
        }
    }
}
