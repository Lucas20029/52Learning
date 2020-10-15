using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _52Learning
{
    public class PlayerController
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

        public List<Segment> SegPlayingList = new List<Segment>();
        public PlayingMode PlayingMode { get; set; } = PlayingMode.Once;



    }

    public enum PlayingMode
    {
        Once,//播放一次，结束后，继续向后播放剩下影片
        Repeat,//循环播放所有片段
        RandomOnce, //随机一次，结束后，继续向后播放剩下影片
        RandomRepeat //随机重复
    }
}
