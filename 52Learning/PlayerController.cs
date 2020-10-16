using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _52Learning
{
    public static class PlayerController
    {
        /*整个播放控制器，需要支持以下功能：
         * 1. 单个Seg播放一次
         * 2. 单个Seg循环播放
         * 3. 多个Seg播放一次
         * 4. 多个Seg循环播放
         * 5. 插播
         * 
         * 需要支持，正在播放中的情况下，停止当前的，启动新的
         */

        public static List<Segment> SegPlayingList = new List<Segment>();
        private static int CurrentPlayingIndex = 0;
        private static List<int> RandomlyLeftIndexes { get; set; }

        private static Random Random = new Random();
        public static PlayingMode PlayingMode { get; set; } = PlayingMode.Once;

        //回调播放器的设置播放位置函数
        public static Action<double> SetPlayPosition { get; set; }

        //获取
        public static Func<double> GetCurrentPlayTime { get; set; }
        public static void Start()
        {
            if (SegPlayingList.Count == 0)
                return;
            CurrentPlayingIndex = 0;
            if (PlayingMode == PlayingMode.RandomOnce || PlayingMode == PlayingMode.RandomRepeat)
            {
                RandomlyLeftIndexes = CreateSequence(SegPlayingList.Count);
                CurrentPlayingIndex = Random.Next(SegPlayingList.Count);
                RandomlyLeftIndexes.RemoveAt(CurrentPlayingIndex);
            }   
            SegmentController.GetCurrentPlayTime = GetCurrentPlayTime;
            SegmentController.OnEndTimeArrived = OnOneSegEnd;
            SegmentController.CurrentPlayingSegment = SegPlayingList[CurrentPlayingIndex];
            SetPlayPosition(SegPlayingList[CurrentPlayingIndex].Start);
            SegmentController.Start();
        }
        private static void OnOneSegEnd()
        {
            CurrentPlayingIndex++; //指向下一个Seg
            if (PlayingMode== PlayingMode.Once)
            {
                if (CurrentPlayingIndex >= SegPlayingList.Count) //播放到末尾了，结束本次播放。也就是不管播放器，让它继续播放
                {
                    Console.WriteLine("End of Total Playing");
                    return;
                }
                //其他情况，currentplayindex+1，播放下一个片段
            }
            else if(PlayingMode == PlayingMode.Repeat)
            {
                CurrentPlayingIndex = CurrentPlayingIndex % SegPlayingList.Count;//取余后，从头播放
            }
            else if(PlayingMode== PlayingMode.RandomOnce)
            {
                if (!RandomlyLeftIndexes.Any())
                {
                    Console.WriteLine("Random Play End!");
                    return;
                }   
                var nextIndex = Random.Next(RandomlyLeftIndexes.Count());
                CurrentPlayingIndex = RandomlyLeftIndexes[nextIndex];
                RandomlyLeftIndexes.RemoveAt(nextIndex);
            }
            else if (PlayingMode == PlayingMode.RandomRepeat)
            {
                if (!RandomlyLeftIndexes.Any())
                {
                    RandomlyLeftIndexes = CreateSequence(SegPlayingList.Count);
                }
                var nextIndex = Random.Next(RandomlyLeftIndexes.Count());
                CurrentPlayingIndex = RandomlyLeftIndexes[nextIndex];
                RandomlyLeftIndexes.RemoveAt(nextIndex);
            }
            SegmentController.CurrentPlayingSegment = SegPlayingList[CurrentPlayingIndex];
            SetPlayPosition(SegPlayingList[CurrentPlayingIndex].Start);
            SegmentController.Start();
        }
        private static List<int> CreateSequence(int count)
        {
            List<int> result = new List<int>(count);
            for (int i = 0; i < count; i++)
                result.Add(i);
            return result;
        }

    }

    public enum PlayingMode
    {
        Once,//播放一次，结束后，继续向后播放剩下影片
        Repeat,//循环播放所有片段
        RandomOnce, //随机一次，结束后，继续向后播放剩下影片
        RandomRepeat //随机重复
    }
}
