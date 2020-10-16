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
            return new VideoSegment(start, end);
        }
        private void btnSaveSeg_Click(object sender, EventArgs e)
        {
            var seg = MakeVideoSeg();
            if (seg == null)
                return;

            if (treeSegs.SelectedNode != null && treeSegs.SelectedNode.Parent==null)//片段树选择了片段节点
            {
                var selectedSeg = treeSegs.SelectedNode.Tag as VideoSegment;
                if (selectedSeg != null)
                {
                    selectedSeg.Start = seg.Start;
                    selectedSeg.End = seg.End;
                }
                treeSegs.SelectedNode.Text = selectedSeg.Name;
            }
            else
            {
                CurrentVideo.Segments.Add(seg);
                var treeNode = new TreeNode(seg.Name);
                treeNode.Tag = seg;
                treeSegs.Nodes.Add(treeNode);
            }
            //Save to file and refresh tree
            var json = JsonConvert.SerializeObject(AllVideos);
            File.WriteAllText(MenuFile, json);
        }

        private void btnRelateTagSeg_Click(object sender, EventArgs e)
        {
            //片段树 没有选择任何节点
            if (treeSegs.SelectedNode == null)
                return;

            //片段树选择了 片段节点，那么，在此片段下，新增标签
            if (treeSegs.SelectedNode.Parent==null)
            {
                var tag = new _52Learning.Tag(cbTags.Text);
                //给片段数据增加标签
                var selectedSeg = treeSegs.SelectedNode.Tag as VideoSegment;
                selectedSeg.Tags.Add(tag);
                //给树增加节点
                var treeNode = new TreeNode(cbTags.Text);
                treeNode.Tag = tag;
                treeSegs.SelectedNode.Nodes.Add(treeNode);
            }
            else //片段树选择了 标签节点，那边编辑选中的标签
            {
                //给标签数据修改标签名称
                var selectedTag = treeSegs.SelectedNode.Tag as Tag;
                selectedTag.TagName = cbTags.Text;
                //给树设置节点名称
                treeSegs.SelectedNode.Text = cbTags.Text;
            }
            var json = JsonConvert.SerializeObject(AllVideos);
            File.WriteAllText(MenuFile, json);
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
                treeNode.Tag = seg;
                foreach (var tag in seg.Tags)
                {
                    var subTreeNode = new TreeNode(tag.TagName);
                    subTreeNode.Tag = tag;
                    treeNode.Nodes.Add(subTreeNode);
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
                treeNode.Tag = tag;
                var tagSegs = CurrentVideo.Segments.Where(p => p.Tags.Contains(tag));
                foreach (var tagSeg in tagSegs)
                {
                    var subNode = new TreeNode(tagSeg.Name);
                    subNode.Tag = tagSeg;
                    treeNode.Nodes.Add(subNode);
                }
                treeTags.Nodes.Add(treeNode);
            }
        }

        private void btnPlaySegs_Click(object sender, EventArgs e)
        {
            PlayerController.SegPlayingList = CurrentVideo.Segments.Select(p=>p as Segment).ToList();
            PlayerController.GetCurrentPlayTime = () => player.Ctlcontrols.currentPosition;
            PlayerController.SetPlayPosition = (p) => player.Ctlcontrols.currentPosition = p;
            
            PlayerController.PlayingMode = PlayingMode.Once;
            if (cbPlayMode.Text == "循环")
                PlayerController.PlayingMode = PlayingMode.Repeat;
            if (cbPlayMode.Text == "随机单次")
                PlayerController.PlayingMode = PlayingMode.RandomOnce;
            if (cbPlayMode.Text == "随机循环")
                PlayerController.PlayingMode = PlayingMode.RandomRepeat;

            PlayerController.Start();

        }
    }
}
