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
        static int CurrentTime = 0;
        static void Main(string[] args)
        {

            SegmentController.GetCurrentPlayTime = () =>
            {
                CurrentTime++;
                Console.WriteLine($"Called Get Current Position:{CurrentTime}");
                return CurrentTime;
            };
            SegmentController.OnEndTimeArrived = () =>
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
