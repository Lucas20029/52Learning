﻿namespace _52Learning
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.player = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnSaveSeg = new System.Windows.Forms.Button();
            this.tbSegStart = new System.Windows.Forms.TextBox();
            this.lbstart = new System.Windows.Forms.Label();
            this.lbend = new System.Windows.Forms.Label();
            this.tbSegEnd = new System.Windows.Forms.TextBox();
            this.cbTags = new System.Windows.Forms.ComboBox();
            this.btnRelateTagSeg = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeSegs = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeTags = new System.Windows.Forms.TreeView();
            this.btnStartAdd = new System.Windows.Forms.Button();
            this.btnEndAdd = new System.Windows.Forms.Button();
            this.btnOpenVideo = new System.Windows.Forms.Button();
            this.btnPlaySegs = new System.Windows.Forms.Button();
            this.cbPlayMode = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddNewSeg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(1, -1);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(836, 560);
            this.player.TabIndex = 0;
            // 
            // btnSaveSeg
            // 
            this.btnSaveSeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveSeg.Location = new System.Drawing.Point(3, 61);
            this.btnSaveSeg.Name = "btnSaveSeg";
            this.btnSaveSeg.Size = new System.Drawing.Size(70, 23);
            this.btnSaveSeg.TabIndex = 1;
            this.btnSaveSeg.Text = "保存片段";
            this.btnSaveSeg.UseVisualStyleBackColor = true;
            this.btnSaveSeg.Click += new System.EventHandler(this.btnSaveSeg_Click);
            // 
            // tbSegStart
            // 
            this.tbSegStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSegStart.Location = new System.Drawing.Point(62, 5);
            this.tbSegStart.Name = "tbSegStart";
            this.tbSegStart.Size = new System.Drawing.Size(100, 21);
            this.tbSegStart.TabIndex = 2;
            // 
            // lbstart
            // 
            this.lbstart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbstart.AutoSize = true;
            this.lbstart.Location = new System.Drawing.Point(3, 17);
            this.lbstart.Name = "lbstart";
            this.lbstart.Size = new System.Drawing.Size(53, 12);
            this.lbstart.TabIndex = 3;
            this.lbstart.Text = "开始时间";
            // 
            // lbend
            // 
            this.lbend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbend.AutoSize = true;
            this.lbend.Location = new System.Drawing.Point(3, 46);
            this.lbend.Name = "lbend";
            this.lbend.Size = new System.Drawing.Size(53, 12);
            this.lbend.TabIndex = 5;
            this.lbend.Text = "结束时间";
            // 
            // tbSegEnd
            // 
            this.tbSegEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSegEnd.Location = new System.Drawing.Point(62, 34);
            this.tbSegEnd.Name = "tbSegEnd";
            this.tbSegEnd.Size = new System.Drawing.Size(100, 21);
            this.tbSegEnd.TabIndex = 4;
            // 
            // cbTags
            // 
            this.cbTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbTags.FormattingEnabled = true;
            this.cbTags.Location = new System.Drawing.Point(3, 93);
            this.cbTags.Name = "cbTags";
            this.cbTags.Size = new System.Drawing.Size(110, 20);
            this.cbTags.TabIndex = 7;
            this.cbTags.Visible = false;
            // 
            // btnRelateTagSeg
            // 
            this.btnRelateTagSeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRelateTagSeg.Location = new System.Drawing.Point(119, 90);
            this.btnRelateTagSeg.Name = "btnRelateTagSeg";
            this.btnRelateTagSeg.Size = new System.Drawing.Size(70, 23);
            this.btnRelateTagSeg.TabIndex = 8;
            this.btnRelateTagSeg.Text = "关联标签";
            this.btnRelateTagSeg.UseVisualStyleBackColor = true;
            this.btnRelateTagSeg.Visible = false;
            this.btnRelateTagSeg.Click += new System.EventHandler(this.btnRelateTagSeg_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(843, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(216, 444);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeSegs);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(208, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "片段管理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeSegs
            // 
            this.treeSegs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSegs.Location = new System.Drawing.Point(3, 3);
            this.treeSegs.Name = "treeSegs";
            this.treeSegs.Size = new System.Drawing.Size(202, 412);
            this.treeSegs.TabIndex = 0;
            this.treeSegs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeSegs_AfterSelect);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeTags);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(166, 534);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "标签管理";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // treeTags
            // 
            this.treeTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeTags.Location = new System.Drawing.Point(3, 3);
            this.treeTags.Name = "treeTags";
            this.treeTags.Size = new System.Drawing.Size(160, 528);
            this.treeTags.TabIndex = 0;
            // 
            // btnStartAdd
            // 
            this.btnStartAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartAdd.Location = new System.Drawing.Point(168, 3);
            this.btnStartAdd.Name = "btnStartAdd";
            this.btnStartAdd.Size = new System.Drawing.Size(28, 23);
            this.btnStartAdd.TabIndex = 10;
            this.btnStartAdd.Text = "+";
            this.btnStartAdd.UseVisualStyleBackColor = true;
            this.btnStartAdd.Click += new System.EventHandler(this.btnStartAdd_Click);
            // 
            // btnEndAdd
            // 
            this.btnEndAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEndAdd.Location = new System.Drawing.Point(168, 32);
            this.btnEndAdd.Name = "btnEndAdd";
            this.btnEndAdd.Size = new System.Drawing.Size(28, 23);
            this.btnEndAdd.TabIndex = 11;
            this.btnEndAdd.Text = "+";
            this.btnEndAdd.UseVisualStyleBackColor = true;
            this.btnEndAdd.Click += new System.EventHandler(this.btnEndAdd_Click);
            // 
            // btnOpenVideo
            // 
            this.btnOpenVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenVideo.Location = new System.Drawing.Point(12, 568);
            this.btnOpenVideo.Name = "btnOpenVideo";
            this.btnOpenVideo.Size = new System.Drawing.Size(75, 23);
            this.btnOpenVideo.TabIndex = 12;
            this.btnOpenVideo.Text = "打开视频";
            this.btnOpenVideo.UseVisualStyleBackColor = true;
            this.btnOpenVideo.Click += new System.EventHandler(this.btnOpenVideo_Click);
            // 
            // btnPlaySegs
            // 
            this.btnPlaySegs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlaySegs.Location = new System.Drawing.Point(846, 570);
            this.btnPlaySegs.Name = "btnPlaySegs";
            this.btnPlaySegs.Size = new System.Drawing.Size(86, 23);
            this.btnPlaySegs.TabIndex = 13;
            this.btnPlaySegs.Text = "播放片段";
            this.btnPlaySegs.UseVisualStyleBackColor = true;
            this.btnPlaySegs.Click += new System.EventHandler(this.btnPlaySegs_Click);
            // 
            // cbPlayMode
            // 
            this.cbPlayMode.FormattingEnabled = true;
            this.cbPlayMode.Items.AddRange(new object[] {
            "单次",
            "循环",
            "随机单次",
            "随机循环"});
            this.cbPlayMode.Location = new System.Drawing.Point(938, 570);
            this.cbPlayMode.Name = "cbPlayMode";
            this.cbPlayMode.Size = new System.Drawing.Size(108, 20);
            this.cbPlayMode.TabIndex = 14;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lbstart);
            this.flowLayoutPanel1.Controls.Add(this.tbSegStart);
            this.flowLayoutPanel1.Controls.Add(this.btnStartAdd);
            this.flowLayoutPanel1.Controls.Add(this.lbend);
            this.flowLayoutPanel1.Controls.Add(this.tbSegEnd);
            this.flowLayoutPanel1.Controls.Add(this.btnEndAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnSaveSeg);
            this.flowLayoutPanel1.Controls.Add(this.btnAddNewSeg);
            this.flowLayoutPanel1.Controls.Add(this.cbTags);
            this.flowLayoutPanel1.Controls.Add(this.btnRelateTagSeg);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(843, 449);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 110);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // btnAddNewSeg
            // 
            this.btnAddNewSeg.Location = new System.Drawing.Point(79, 61);
            this.btnAddNewSeg.Name = "btnAddNewSeg";
            this.btnAddNewSeg.Size = new System.Drawing.Size(75, 23);
            this.btnAddNewSeg.TabIndex = 12;
            this.btnAddNewSeg.Text = "添加新片段";
            this.btnAddNewSeg.UseVisualStyleBackColor = true;
            this.btnAddNewSeg.Click += new System.EventHandler(this.btnAddNewSeg_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 602);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.cbPlayMode);
            this.Controls.Add(this.btnPlaySegs);
            this.Controls.Add(this.btnOpenVideo);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.player);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer player;
        private System.Windows.Forms.Button btnSaveSeg;
        private System.Windows.Forms.TextBox tbSegStart;
        private System.Windows.Forms.Label lbstart;
        private System.Windows.Forms.Label lbend;
        private System.Windows.Forms.TextBox tbSegEnd;
        private System.Windows.Forms.ComboBox cbTags;
        private System.Windows.Forms.Button btnRelateTagSeg;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView treeSegs;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeTags;
        private System.Windows.Forms.Button btnStartAdd;
        private System.Windows.Forms.Button btnEndAdd;
        private System.Windows.Forms.Button btnOpenVideo;
        private System.Windows.Forms.Button btnPlaySegs;
        private System.Windows.Forms.ComboBox cbPlayMode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAddNewSeg;
    }
}

