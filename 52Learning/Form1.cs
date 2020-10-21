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
            var allVideos = VideoInfoManager.Instance.AllVideoInfos;
            BuildSegTree();
            var tagNames = allVideos.SelectMany(p => p.Segments).SelectMany(p => p.Tags).Select(p => p.TagName).Distinct();
            foreach (var tag in tagNames)
                cbTags.Items.Add(tag);

        }
        private void BuildSegTree()
        {
            foreach(var video in VideoInfoManager.Instance.AllVideoInfos)
            {
                var videoNode = BuildTreeNodeByVideo(video);
                treeSegs.Nodes.Add(videoNode);
            }
        }
        #region 根据Video、Segment、Tag 构建 TreeNode及其 子Node
        private TreeNode BuildTreeNodeByTag(Tag tag)
        {
            TreeNode node = new TreeNode(tag.TagName);
            node.Tag = tag;
            return node;
        }
        private TreeNode BuildTreeNodeBySegment(VideoSegment seg)
        {
            TreeNode node = new TreeNode(seg.Name);
            node.Tag = seg;
            foreach(var tag in seg.Tags)
            {
                var tagNode = BuildTreeNodeByTag(tag);
                node.Nodes.Add(tagNode);
            }
            return node;
        }
        private TreeNode BuildTreeNodeByVideo(VideoInfo videoInfo)
        {
            var videoName = Path.GetFileName(videoInfo.VideoPath);
            TreeNode node = new TreeNode(videoName);
            node.Tag = videoInfo;
            foreach(var seg in videoInfo.Segments)
            {
                var segNode = BuildTreeNodeBySegment(seg);
                node.Nodes.Add(segNode);
            }
            return node;
        }
        #endregion

        
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
            var videoPath = player.URL;
            return new VideoSegment(start, end) { VideoPath = videoPath };
        }
        private void btnSaveSeg_Click(object sender, EventArgs e)
        {
            var seg = MakeVideoSeg();
            if (seg == null)
                return;
            //只有选中了片段树上本视频的片段节点，才更新该节点的起止时间
            if (treeSegs.SelectedNode != null && treeSegs.SelectedNode.Level==1)
            {
                //更新内存数据,持久化
                var selectedSeg = treeSegs.SelectedNode.Tag as VideoSegment;
                if (selectedSeg != null)
                {
                    selectedSeg.Start = seg.Start;
                    selectedSeg.End = seg.End;
                }
                var playingVideoInfo = treeSegs.SelectedNode.Parent.Tag as VideoInfo;
                VideoInfoManager.Instance.SaveVideo(playingVideoInfo);
                //更新UI
                treeSegs.SelectedNode.Text = selectedSeg.Name;
            }
        }
        /// <summary>
        /// 根据当前播放的视频文件地址，获取片段树上对应节点
        /// </summary>
        /// <param name="videoPath"></param>
        /// <returns></returns>
        private TreeNode GetPlayingNode(string videoPath)
        {
            foreach (var node in treeSegs.Nodes)
            {
                var treeNode = node as TreeNode;
                if (treeNode == null)
                    continue;
                var videoInfo = treeNode.Tag as VideoInfo;
                if (videoPath.Equals(videoInfo?.VideoPath, StringComparison.OrdinalIgnoreCase))
                {
                    return treeNode;
                }
            }
            return null;
        }
        private void btnAddNewSeg_Click(object sender, EventArgs e)
        {
            var seg = MakeVideoSeg();
            if (seg == null)
                return;
            var playingVideoPath = player.URL;
            //当前播放视频的片段树节点
            TreeNode playingVideoNode = GetPlayingNode(player.URL);
            //当前播放视频的 数据实体
            VideoInfo playingVideoInfo = playingVideoNode?.Tag as VideoInfo;
            //如果为空，则新建VideoInfo、TreeNode。（防御性代码，基本不会发生）
            if (playingVideoNode == null || playingVideoInfo == null)
            {
                playingVideoInfo = new VideoInfo(playingVideoPath);
                var videoName = Path.GetFileName(playingVideoPath);
                playingVideoNode = new TreeNode(videoName);
                playingVideoNode.Tag = playingVideoNode;
                treeSegs.Nodes.Add(playingVideoNode);
            }
            //更新数据
            playingVideoInfo.Segments.Add(seg);
            //更新UI
            var segNode = new TreeNode(seg.Name);
            segNode.Tag = seg;
            playingVideoNode.Nodes.Add(segNode);
            
            //写入文件
            VideoInfoManager.Instance.SaveVideo(playingVideoInfo);
        }

        private void btnRelateTagSeg_Click(object sender, EventArgs e)
        {
            ////片段树 没有选择任何节点
            //if (treeSegs.SelectedNode == null)
            //    return;

            ////片段树选择了 片段节点，那么，在此片段下，新增标签
            //if (treeSegs.SelectedNode.Parent==null)
            //{
            //    var tag = new _52Learning.Tag(cbTags.Text);
            //    //给片段数据增加标签
            //    var selectedSeg = treeSegs.SelectedNode.Tag as VideoSegment;
            //    selectedSeg.Tags.Add(tag);
            //    //给树增加节点
            //    var treeNode = new TreeNode(cbTags.Text);
            //    treeNode.Tag = tag;
            //    treeSegs.SelectedNode.Nodes.Add(treeNode);
            //}
            //else //片段树选择了 标签节点，那边编辑选中的标签
            //{
            //    //给标签数据修改标签名称
            //    var selectedTag = treeSegs.SelectedNode.Tag as Tag;
            //    selectedTag.TagName = cbTags.Text;
            //    //给树设置节点名称
            //    treeSegs.SelectedNode.Text = cbTags.Text;
            //}
            //var json = JsonConvert.SerializeObject(AllVideos);
            //File.WriteAllText(MenuFile, json);
        }

        VideoInfo GetPlayingVideoInfo()
        {
            var allVideo = VideoInfoManager.Instance.AllVideoInfos;
            var playingVideoPath = player.URL;
            return allVideo.FirstOrDefault(p => p.VideoPath == playingVideoPath)??new VideoInfo();
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
                //2. 片段树上进行定位，或在片段树上新增节点
                var videoNode = GetPlayingNode(filePath);
                if (videoNode != null)
                    treeSegs.SelectedNode = videoNode;
                else //新视频
                {
                    //新加 数据实体
                    var videoInfo = new VideoInfo(filePath);
                    VideoInfoManager.Instance.AddVideoInfo(videoInfo);
                    //新加 UI节点
                    videoNode = BuildTreeNodeByVideo(videoInfo);
                    treeSegs.Nodes.Insert(0,videoNode);
                }
            }
        } 
        
        private void btnPlaySegs_Click(object sender, EventArgs e)
        {
            var segments = VideoInfoManager.Instance.AllVideoInfos.SelectMany(p => p.Segments).ToList();
            PlayerController.SegPlayingList = segments;
            PlayerController.GetCurrentPlayTime = () => player.Ctlcontrols.currentPosition;
            PlayerController.SetPlayPosition = (p) => player.Ctlcontrols.currentPosition = p;
            PlayerController.PlayVideo = path => player.URL = path;

            PlayerController.PlayingMode = PlayingMode.Once;
            if (cbPlayMode.Text == "循环")
                PlayerController.PlayingMode = PlayingMode.Repeat;
            if (cbPlayMode.Text == "随机单次")
                PlayerController.PlayingMode = PlayingMode.RandomOnce;
            if (cbPlayMode.Text == "随机循环")
                PlayerController.PlayingMode = PlayingMode.RandomRepeat;

            PlayerController.Start();

        }

        private void treeSegs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //选中了 片段节点
            if (e.Node.Level == 0)
            {
                tbSegStart.Visible = true;
                tbSegEnd.Visible = true;
                lbstart.Visible = true;
                lbend.Visible = true;
                btnSaveSeg.Visible = false;
                btnAddNewSeg.Visible = true;
                cbTags.Visible = false;
                btnRelateTagSeg.Visible = false;
                tbSegStart.Text = player.Ctlcontrols.currentPosition.ToString();
                tbSegEnd.Text = (player.Ctlcontrols.currentPosition+10).ToString();
            }
            if (e.Node.Level == 1)
            {
                tbSegStart.Visible = true;
                tbSegEnd.Visible = true;
                lbstart.Visible = true;
                lbend.Visible = true;
                btnSaveSeg.Visible = true;
                btnAddNewSeg.Visible = false;
                cbTags.Visible = false;
                btnRelateTagSeg.Visible = false;
                var seg = e.Node.Tag as Segment;
                tbSegStart.Text = seg.Start.ToString("0.0");
                tbSegEnd.Text = seg.End.ToString("0.0");
            }
        }
    }
}
