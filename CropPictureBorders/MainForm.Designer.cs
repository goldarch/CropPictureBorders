namespace CropPictureBorders
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.saveAsDefault = new System.Windows.Forms.Button();
            this.pbBefore = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowseOutputDir = new System.Windows.Forms.Button();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.lblOutputDir = new System.Windows.Forms.Label();
            this.lblTitleRight = new System.Windows.Forms.Label();
            this.lblTitleLeft = new System.Windows.Forms.Label();
            this.lblTitleBottom = new System.Windows.Forms.Label();
            this.lblTitleTop = new System.Windows.Forms.Label();
            this.btnClearList = new System.Windows.Forms.Button();
            this.fileListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnProcessBatch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbAfter = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.rightTrackBox = new CropPictureBorders.MyTrackBox();
            this.leftTrackBox = new CropPictureBorders.MyTrackBox();
            this.bottomTrackBox = new CropPictureBorders.MyTrackBox();
            this.topTrackBox = new CropPictureBorders.MyTrackBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBefore)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAfter)).BeginInit();
            this.SuspendLayout();
            // 
            // saveAsDefault
            // 
            this.saveAsDefault.Enabled = false;
            this.saveAsDefault.Location = new System.Drawing.Point(549, 718);
            this.saveAsDefault.Name = "saveAsDefault";
            this.saveAsDefault.Size = new System.Drawing.Size(95, 23);
            this.saveAsDefault.TabIndex = 3;
            this.saveAsDefault.Text = "Save Default";
            this.toolTip1.SetToolTip(this.saveAsDefault, "Saves the current crop values as the default for next time.");
            this.saveAsDefault.UseVisualStyleBackColor = true;
            this.saveAsDefault.Click += new System.EventHandler(this.SaveAsDefault_Click);
            // 
            // pbBefore
            // 
            this.pbBefore.AllowDrop = true;
            this.pbBefore.BackColor = System.Drawing.Color.Turquoise;
            this.pbBefore.Location = new System.Drawing.Point(17, 20);
            this.pbBefore.Name = "pbBefore";
            this.pbBefore.Size = new System.Drawing.Size(400, 400);
            this.pbBefore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBefore.TabIndex = 4;
            this.pbBefore.TabStop = false;
            this.toolTip1.SetToolTip(this.pbBefore, "This preview shows the corners of your image.\r\nDrag and drop one or more image fi" +
        "les here.");
            this.pbBefore.DragDrop += new System.Windows.Forms.DragEventHandler(this.PbBefore_DragDrop);
            this.pbBefore.DragEnter += new System.Windows.Forms.DragEventHandler(this.PbBefore_DragEnter);
            this.pbBefore.Paint += new System.Windows.Forms.PaintEventHandler(this.pbBefore_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowseOutputDir);
            this.groupBox2.Controls.Add(this.txtOutputDir);
            this.groupBox2.Controls.Add(this.lblOutputDir);
            this.groupBox2.Controls.Add(this.lblTitleRight);
            this.groupBox2.Controls.Add(this.lblTitleLeft);
            this.groupBox2.Controls.Add(this.lblTitleBottom);
            this.groupBox2.Controls.Add(this.lblTitleTop);
            this.groupBox2.Controls.Add(this.rightTrackBox);
            this.groupBox2.Controls.Add(this.leftTrackBox);
            this.groupBox2.Controls.Add(this.bottomTrackBox);
            this.groupBox2.Controls.Add(this.topTrackBox);
            this.groupBox2.Controls.Add(this.btnClearList);
            this.groupBox2.Controls.Add(this.fileListView);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.saveAsDefault);
            this.groupBox2.Controls.Add(this.btnProcessBatch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pbAfter);
            this.groupBox2.Controls.Add(this.pbBefore);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(860, 758);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image Preview";
            // 
            // btnBrowseOutputDir
            // 
            this.btnBrowseOutputDir.Location = new System.Drawing.Point(758, 545);
            this.btnBrowseOutputDir.Name = "btnBrowseOutputDir";
            this.btnBrowseOutputDir.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseOutputDir.TabIndex = 19;
            this.btnBrowseOutputDir.Text = "Browse...";
            this.btnBrowseOutputDir.UseVisualStyleBackColor = true;
            this.btnBrowseOutputDir.Click += new System.EventHandler(this.btnBrowseOutputDir_Click);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Location = new System.Drawing.Point(111, 547);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.ReadOnly = true;
            this.txtOutputDir.Size = new System.Drawing.Size(641, 21);
            this.txtOutputDir.TabIndex = 18;
            // 
            // lblOutputDir
            // 
            this.lblOutputDir.AutoSize = true;
            this.lblOutputDir.Location = new System.Drawing.Point(14, 550);
            this.lblOutputDir.Name = "lblOutputDir";
            this.lblOutputDir.Size = new System.Drawing.Size(107, 12);
            this.lblOutputDir.TabIndex = 17;
            this.lblOutputDir.Text = "Output Directory:";
            // 
            // lblTitleRight
            // 
            this.lblTitleRight.AutoSize = true;
            this.lblTitleRight.Location = new System.Drawing.Point(423, 442);
            this.lblTitleRight.Name = "lblTitleRight";
            this.lblTitleRight.Size = new System.Drawing.Size(41, 12);
            this.lblTitleRight.TabIndex = 16;
            this.lblTitleRight.Text = "Right:";
            // 
            // lblTitleLeft
            // 
            this.lblTitleLeft.AutoSize = true;
            this.lblTitleLeft.Location = new System.Drawing.Point(14, 442);
            this.lblTitleLeft.Name = "lblTitleLeft";
            this.lblTitleLeft.Size = new System.Drawing.Size(35, 12);
            this.lblTitleLeft.TabIndex = 15;
            this.lblTitleLeft.Text = "Left:";
            // 
            // lblTitleBottom
            // 
            this.lblTitleBottom.AutoSize = true;
            this.lblTitleBottom.Location = new System.Drawing.Point(423, 485);
            this.lblTitleBottom.Name = "lblTitleBottom";
            this.lblTitleBottom.Size = new System.Drawing.Size(47, 12);
            this.lblTitleBottom.TabIndex = 14;
            this.lblTitleBottom.Text = "Bottom:";
            // 
            // lblTitleTop
            // 
            this.lblTitleTop.AutoSize = true;
            this.lblTitleTop.Location = new System.Drawing.Point(14, 485);
            this.lblTitleTop.Name = "lblTitleTop";
            this.lblTitleTop.Size = new System.Drawing.Size(29, 12);
            this.lblTitleTop.TabIndex = 13;
            this.lblTitleTop.Text = "Top:";
            // 
            // btnClearList
            // 
            this.btnClearList.Enabled = false;
            this.btnClearList.Location = new System.Drawing.Point(760, 718);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(75, 23);
            this.btnClearList.TabIndex = 9;
            this.btnClearList.Text = "Clear List";
            this.toolTip1.SetToolTip(this.btnClearList, "Removes all files from the list.");
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.BtnClearList_Click);
            // 
            // fileListView
            // 
            this.fileListView.AllowDrop = true;
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.fileListView.FullRowSelect = true;
            this.fileListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.fileListView.HideSelection = false;
            this.fileListView.Location = new System.Drawing.Point(17, 575);
            this.fileListView.MultiSelect = false;
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(818, 137);
            this.fileListView.TabIndex = 8;
            this.toolTip1.SetToolTip(this.fileListView, "Drag and drop image files here.");
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            this.fileListView.SelectedIndexChanged += new System.EventHandler(this.FileListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Path";
            this.columnHeader1.Width = 790;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(838, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Change the background color of the preview boxes.");
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel1.Image")));
            this.linkLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.Location = new System.Drawing.Point(14, 718);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(118, 23);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "GoldArch Github";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // btnProcessBatch
            // 
            this.btnProcessBatch.Enabled = false;
            this.btnProcessBatch.Location = new System.Drawing.Point(658, 718);
            this.btnProcessBatch.Name = "btnProcessBatch";
            this.btnProcessBatch.Size = new System.Drawing.Size(92, 23);
            this.btnProcessBatch.TabIndex = 6;
            this.btnProcessBatch.Text = "Process Batch";
            this.toolTip1.SetToolTip(this.btnProcessBatch, "Processes all images in the list and saves them.");
            this.btnProcessBatch.UseVisualStyleBackColor = true;
            this.btnProcessBatch.Click += new System.EventHandler(this.BtnProcessBatch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Drag images here...";
            // 
            // pbAfter
            // 
            this.pbAfter.BackColor = System.Drawing.Color.Turquoise;
            this.pbAfter.Location = new System.Drawing.Point(423, 20);
            this.pbAfter.Name = "pbAfter";
            this.pbAfter.Size = new System.Drawing.Size(400, 400);
            this.pbAfter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAfter.TabIndex = 4;
            this.pbAfter.TabStop = false;
            this.toolTip1.SetToolTip(this.pbAfter, "This is a preview of the cropped image.");
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Select the output directory for processed images.";
            // 
            // rightTrackBox
            // 
            this.rightTrackBox.Location = new System.Drawing.Point(426, 458);
            this.rightTrackBox.Maximum = 50;
            this.rightTrackBox.Name = "rightTrackBox";
            this.rightTrackBox.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.rightTrackBox.Size = new System.Drawing.Size(397, 32);
            this.rightTrackBox.TabIndex = 12;
            this.rightTrackBox.Value = 0;
            this.rightTrackBox.ValueChanged += new System.EventHandler(this.TrackBox_valueChanged);
            // 
            // leftTrackBox
            // 
            this.leftTrackBox.Location = new System.Drawing.Point(17, 458);
            this.leftTrackBox.Maximum = 50;
            this.leftTrackBox.Name = "leftTrackBox";
            this.leftTrackBox.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.leftTrackBox.Size = new System.Drawing.Size(397, 32);
            this.leftTrackBox.TabIndex = 11;
            this.leftTrackBox.Value = 0;
            this.leftTrackBox.ValueChanged += new System.EventHandler(this.TrackBox_valueChanged);
            // 
            // bottomTrackBox
            // 
            this.bottomTrackBox.Location = new System.Drawing.Point(426, 501);
            this.bottomTrackBox.Maximum = 50;
            this.bottomTrackBox.Name = "bottomTrackBox";
            this.bottomTrackBox.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.bottomTrackBox.Size = new System.Drawing.Size(397, 32);
            this.bottomTrackBox.TabIndex = 10;
            this.bottomTrackBox.Value = 0;
            this.bottomTrackBox.ValueChanged += new System.EventHandler(this.TrackBox_valueChanged);
            // 
            // topTrackBox
            // 
            this.topTrackBox.Location = new System.Drawing.Point(17, 501);
            this.topTrackBox.Maximum = 50;
            this.topTrackBox.Name = "topTrackBox";
            this.topTrackBox.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.topTrackBox.Size = new System.Drawing.Size(397, 32);
            this.topTrackBox.TabIndex = 0;
            this.topTrackBox.Value = 0;
            this.topTrackBox.ValueChanged += new System.EventHandler(this.TrackBox_valueChanged);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(884, 781);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 820);
            this.Name = "MainForm";
            this.Text = "Batch Image Border Cropper - by GoldArch";
            ((System.ComponentModel.ISupportInitialize)(this.pbBefore)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAfter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbBefore;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbAfter;
        private MyTrackBox topTrackBox;
        private System.Windows.Forms.Button saveAsDefault;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProcessBatch;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private MyTrackBox rightTrackBox;
        private MyTrackBox leftTrackBox;
        private MyTrackBox bottomTrackBox;
        private System.Windows.Forms.Label lblTitleRight;
        private System.Windows.Forms.Label lblTitleLeft;
        private System.Windows.Forms.Label lblTitleBottom;
        private System.Windows.Forms.Label lblTitleTop;
        private System.Windows.Forms.Button btnBrowseOutputDir;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Label lblOutputDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}