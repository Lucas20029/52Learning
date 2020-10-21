using _52Learning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static double CurrentTime = 0;
        static void Main(string[] args)
        {

            TestPlayerController();
        }

        static void TestPlayerController()
        {
            PlayerController.GetCurrentPlayTime = () =>
            {
                CurrentTime++;
                Console.WriteLine($"Called Get Current Position:{CurrentTime}");
                return CurrentTime;
            };
            PlayerController.SetPlayPosition = (p) =>
            {
                CurrentTime = p;
                Console.WriteLine($"Current Position Set to :{p}");
            };
            PlayerController.PlayingMode = PlayingMode.RandomOnce;
            PlayerController.SegPlayingList = new List<VideoSegment>()
            {
                new VideoSegment(){ Start=6.9,End=10.2 },
                new VideoSegment(){ Start=7.8, End =9.2},
                new VideoSegment(){ Start=15.9, End=20.1}
            };
            PlayerController.Start();
            Console.ReadKey();
        }

        static void TestSegmentCOntroller()
        {
            SegmentController.GetCurrentPlayTime = () =>
            {
                CurrentTime++;
                Console.WriteLine($"Called Get Current Position:{CurrentTime}");
                return CurrentTime;
            };
            SegmentController.OnEndTimeArrived = (p) =>
            {
                Console.WriteLine("EndTime Arrived!");
            };

            SegmentController.CurrentPlayingSegment = new Segment()
            {
                Start = 1,
                End = 10
            };

            SegmentController.Start();

            Console.ReadKey();
        }
    }
}
