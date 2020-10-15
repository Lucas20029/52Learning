using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _52Learning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var tagNames = AllVideos.SelectMany(p => p.Segments).SelectMany(p => p.Tags).Select(p => p.TagName).Distinct();
            foreach (var tag in tagNames)
                cbTags.Items.Add(tag);
        }
        const string MenuFile = "Data\\menu.txt";

        private void btnStartAdd_Click(object sender, EventArgs e)
        {
            tbSegStart.Text = player.Ctlcontrols.currentPosition.ToString();
        }

        private void btnEndAdd_Click(object sender, EventArgs e)
        {
            tbSegEnd.Text = player.Ctlcontrols.currentPosition.ToString();
        }
        private VideoSegment MakeVideoSeg()
        {
            double start, end = 0;
            if (!double.TryParse(tbSegStart.Text, out start))
            {
                MessageBox.Show("开始时间格式不对");
                return null;
            }
            if (!double.TryParse(tbSegEnd.Text, out end))
            {
                MessageBox.Show("结束时间格式不对");
                return null;
            }
            if (start > end)
            {
                MessageBox.Show("开始时间不能晚于结束时间");
                return null;
            }
            return new VideoSegment()
            {
                Start = start,
                End = end
            };
        }
        private void btnSaveSeg_Click(object sender, EventArgs e)
        {
            var seg = MakeVideoSeg();
            if (seg == null)
                return;
            //如果现有存在，则不处理；不存在，则创建
            var existingSeg = CurrentVideo.Segments.FirstOrDefault(p => p == seg);
            if (existingSeg == null)
            {
                CurrentVideo.Segments.Add(seg);
                var json = JsonConvert.SerializeObject(AllVideos);
                File.WriteAllText(MenuFile, json);
                RefreshSegTree();
            }   
        }

        private void btnRelateTagSeg_Click(object sender, EventArgs e)
        {
            var tag = cbTags.Text;
            var seg = MakeVideoSeg();
            if (seg == null)
                return;
            //如果现有存在，则关联现有的；不存在，则创建新的，并关联
            var existingSeg = CurrentVideo.Segments.FirstOrDefault(p => p == seg);
            if (existingSeg == null)
            {//不存在
                seg.Tags.Add(new Tag(tag));
                CurrentVideo.Segments.Add(seg);
            }
            else
            {
                if (!existingSeg.Tags.Any(p => p.TagName == tag))
                    existingSeg.Tags.Add(new Tag(tag));
            }
            var json = JsonConvert.SerializeObject(AllVideos);
            File.WriteAllText(MenuFile, json);
            RefreshSegTree();
            RefreshTagTree();
        }
        private List<VideoInfo> allVideos = null;
        private List<VideoInfo> AllVideos
        {
            get
            {
                if(allVideos==null)
                {
                    var json = File.ReadAllText(MenuFile);
                    allVideos = JsonConvert.DeserializeObject<List<VideoInfo>>(json) ?? new List<VideoInfo>();
                    return allVideos;
                }
                return allVideos;
            }
        }
        VideoInfo CurrentVideo
        {
            get
            {
                var filePath = player.URL;
                var current = AllVideos.FirstOrDefault(p => p.VideoPath == filePath);
                if (current == null)
                {
                    current = new VideoInfo(player.URL);
                    AllVideos.Add(current);
                }   
                return current;
            }
        }

        private void btnOpenVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog()== DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;
                //1. 播放器打开新视频
                player.URL = filePath;
                player.Ctlcontrols.play();
                //2. 加载新视频的片段树、标签树
                //重建片段树
                RefreshSegTree();
                //重建标签树
                RefreshTagTree();
            }
        }
        private void RefreshSegTree()
        {
            treeSegs.Nodes.Clear();
            foreach (var seg in CurrentVideo.Segments)
            {
                var treeNode = new TreeNode(seg.Name);
                foreach (var tag in seg.Tags)
                {
                    treeNode.Nodes.Add(tag.TagName);
                }
                treeSegs.Nodes.Add(treeNode);
            }
        }
        private void RefreshTagTree()
        {
            treeTags.Nodes.Clear();
            var tags = CurrentVideo.Segments.SelectMany(p => p.Tags);
            foreach (var tag in tags)
            {
                var treeNode = new TreeNode(tag.TagName);
                var tagSegs = CurrentVideo.Segments.Where(p => p.Tags.Contains(tag));
                foreach (var tagSeg in tagSegs)
                {
                    treeNode.Nodes.Add(tagSeg.Name);
                }
                treeTags.Nodes.Add(treeNode);
            }
        }

        private void btnPlaySegs_Click(object sender, EventArgs e)
        {
            //需要做一个定时器，每秒触发一次时间检查。如果超过，则进入下一Seg
        }
    }
}
