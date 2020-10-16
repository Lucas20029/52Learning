using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _52Learning
{
    public class SegmentController
    {
        //Client使用时，希望注册一个回调函数,设置执行时间范围，当到达时间时，自动触发这个回调函数的执行，
        //例如，Client在一开始的时候，就注册 在 10s~18内执行，也就是说，在18s的时候，自动触发OnEndTimeArrived

        /// <summary>
        /// 由Client设置传入，Timer每秒调这个函数检查时间
        /// </summary>
        public static Func<double> GetCurrentPlayTime { get; set; }
        /// <summary>
        /// 由Client设置传入，到达片段的结束时间时，会执行该函数
        /// </summary>
        public static Action OnEndTimeArrived { get; set; }
        /// <summary>
        /// 执行的时间范围，当到达结束时间时，会触发OnEndTimeArrived函数执行
        /// </summary>
        public static Segment CurrentPlayingSegment { get; set; }


        private const int TimeInterval = 1000;
        private static Timer innerTimer = new Timer(new TimerCallback(progress), null, Timeout.Infinite, TimeInterval);
        private static bool IsEnable { get; set; } = false;


        //每秒触发一次。调用GetCurrentPlayTime获取当前播放时间
        private static void progress(object b)
        {
            if (!IsEnable || CurrentPlayingSegment == null)
                return;
            var currentPosition = GetCurrentPlayTime();
            if (currentPosition >= CurrentPlayingSegment.End)
            {
                //下面这两句不能调换。
                //需要先结束掉Timer，然后如果client有需求，可以再开启，如果没需求，不管就行。
                Stop();
                OnEndTimeArrived();
            }
        }
        public static void Start()
        {
            if (CurrentPlayingSegment == null || GetCurrentPlayTime == null || OnEndTimeArrived == null)
                return;
            IsEnable = true;
            innerTimer.Change(0, TimeInterval);
        }
        public static void Stop()
        {
            IsEnable = false;
            innerTimer.Change(Timeout.Infinite, TimeInterval);
        }
    }

}
