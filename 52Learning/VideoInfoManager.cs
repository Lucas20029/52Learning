using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _52Learning
{
    //视频信息
    public class VideoInfoManager 
    {
        public static VideoInfoManager Instance = new VideoInfoManager();

        private const string TopMenuPath = "Data/Menu.vis";
        private List<VideoInfo> allVideoInfos = null;
        public List<VideoInfo> AllVideoInfos
        {
            get
            {
                if (allVideoInfos != null)
                    return allVideoInfos;
                allVideoInfos = LoadAllVideos();
                return allVideoInfos;
            }
        }
        private string[] LoadAllVideoFiles()
        {
            if (!File.Exists(TopMenuPath))
            {
                File.Create(TopMenuPath);
                return new string[0];
            }
            return File.ReadAllLines(TopMenuPath);
        }
        //1. 加载文件目录，从而获取本人（本地）所有的视频文件
        public List<VideoInfo> LoadAllVideos()
        {
            var allFiles = LoadAllVideoFiles();
            var result = new List<VideoInfo>();
            foreach (var file in allFiles)
            {
                var viJson = File.ReadAllText(file);
                var videoInfo = JsonConvert.DeserializeObject<VideoInfo>(viJson);
                result.Add(videoInfo);
            }
            return result;
        }
        //如果打开一个新的路径的视频文件，需要查找其下有没有视频信息文件，有的话，就读取，并加入到Menu中
        
       
        public string GetViPathFromVideoPath(string videoPath)
        {
            var dir = Path.GetDirectoryName(videoPath);
            var file = Path.GetFileNameWithoutExtension(videoPath);
            return  $"{dir}/{file}.vi";
        }
        
        //3. 

        public void SaveVideo(VideoInfo video)
        {
            /* 检查 video.VideoPath 在 allVideo中是否存在。
             *   如果存在，则只需要更新 videopath 下的 vi文件即可
             *   如果不存在，则需要把vi文件写入 menu中，再创建对应vi文件
             */
            var viPath = GetViPathFromVideoPath(video.VideoPath);
            //如果vi文件在menu中不存在,把当前文件路径写入Menu
            if (!AllVideoInfos.Any(p => p.VideoPath.Equals(video.VideoPath, StringComparison.OrdinalIgnoreCase)))
            {
                var files = AllVideoInfos.Select(p => GetViPathFromVideoPath(p.VideoPath)).ToList();
                files.Add(viPath);
                File.WriteAllLines(TopMenuPath, files);
            }
            //把VideoInfo信息写入Vi文件
            var viJson = JsonConvert.SerializeObject(video);
            File.WriteAllText(viPath, viJson);
        }
    }
}
