using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CropPictureBorders
{
    public partial class MainForm : Form
    {
        // Keep the currently selected original image in memory for performance.
        private Image _currentOriginalImage;

        public MainForm()
        {
            InitializeComponent();
            LoadDefaultSetting();
            this.label1.Parent = this.pbBefore;
            this.label1.Location = new Point((this.pbBefore.Width - this.label1.Width) / 2, (this.pbBefore.Height - this.label1.Height) / 2);

            this.fileListView.DragEnter += new DragEventHandler(PbBefore_DragEnter);
            this.fileListView.DragDrop += new DragEventHandler(FileListView_DragDrop);

            this.txtOutputDir.Text = Properties.Settings.Default.outputDirectory;

            // Ensure the in-memory image is disposed when the form closes.
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clean up the image in memory to prevent memory leaks.
            _currentOriginalImage?.Dispose();
        }

        private void LoadDefaultSetting()
        {
            this.topTrackBox.Value = Properties.Settings.Default.topValue;
            this.bottomTrackBox.Value = Properties.Settings.Default.bottomValue;
            this.leftTrackBox.Value = Properties.Settings.Default.leftValue;
            this.rightTrackBox.Value = Properties.Settings.Default.rightValue;
        }

        private void SaveAsDefault_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.topValue = this.topTrackBox.Value;
            Properties.Settings.Default.bottomValue = this.bottomTrackBox.Value;
            Properties.Settings.Default.leftValue = this.leftTrackBox.Value;
            Properties.Settings.Default.rightValue = this.rightTrackBox.Value;
            Properties.Settings.Default.Save();
            this.saveAsDefault.Enabled = false;
        }

        /// <summary>
        /// Updates the 'After' preview based on the in-memory original image.
        /// </summary>
        private void UpdateAfterPreview()
        {
            if (_currentOriginalImage == null)
            {
                this.pbAfter.Image = null;
                return;
            }

            try
            {
                int x = this.leftTrackBox.Value;
                int y = this.topTrackBox.Value;
                int width = _currentOriginalImage.Width - x - this.rightTrackBox.Value;
                int height = _currentOriginalImage.Height - y - this.bottomTrackBox.Value;

                if (width < 1) width = 1;
                if (height < 1) height = 1;

                using (Image resultImage = ImageHelper.CutPicture(_currentOriginalImage, x, y, width, height))
                {
                    Image afterImageWithBorder = new Bitmap(resultImage);

                    using (Graphics g = Graphics.FromImage(afterImageWithBorder))
                    using (Pen redPen = new Pen(Color.Red, 2))
                    {
                        g.DrawRectangle(redPen, 1, 1, afterImageWithBorder.Width - 2, afterImageWithBorder.Height - 2);
                    }

                    this.pbAfter.Image = afterImageWithBorder;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during preview: {ex.Message}");
                this.pbAfter.Image = null;
            }
        }

        private void PbBefore_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void AddFilesToList(string[] files)
        {
            bool isFirstFile = this.fileListView.Items.Count == 0;

            foreach (string file in files)
            {
                if (!this.fileListView.Items.Cast<ListViewItem>().Any(item => item.Text.Equals(file, StringComparison.OrdinalIgnoreCase)))
                {
                    this.fileListView.Items.Add(new ListViewItem(file));
                }
            }

            if (this.fileListView.Items.Count > 0)
            {
                this.btnProcessBatch.Enabled = true;
                this.btnClearList.Enabled = true;
                this.label1.Visible = false;

                if (isFirstFile)
                {
                    this.fileListView.Items[0].Selected = true;
                }
            }
        }

        private void FileListView_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            AddFilesToList(files);
        }

        private void PbBefore_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            AddFilesToList(files);
        }

        private void TrackBox_valueChanged(object sender, EventArgs e)
        {
            this.saveAsDefault.Enabled = true;
            // This now only updates the 'After' preview using the in-memory image.
            UpdateAfterPreview();
        }

        private void BtnProcessBatch_Click(object sender, EventArgs e)
        {
            if (this.fileListView.Items.Count == 0)
            {
                MessageBox.Show("Please add files to the list first.", "No Files", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string outputDir = this.txtOutputDir.Text;
            if (string.IsNullOrWhiteSpace(outputDir) || !Directory.Exists(outputDir))
            {
                MessageBox.Show("Please set a valid output directory before processing.", "Output Directory Not Set", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int successCount = 0;
            foreach (ListViewItem item in this.fileListView.Items)
            {
                string filePath = item.Text;
                try
                {
                    using (Image result = Image.FromFile(filePath))
                    {
                        int x = this.leftTrackBox.Value;
                        int y = this.topTrackBox.Value;
                        int width = result.Width - x - this.rightTrackBox.Value;
                        int height = result.Height - y - this.bottomTrackBox.Value;

                        if (width < 1) width = 1;
                        if (height < 1) height = 1;

                        using (Image cropped = ImageHelper.CutPicture(result, x, y, width, height))
                        {
                            cropped.Save(Program.GetSuitablePath(filePath));
                            successCount++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to process {filePath}: {ex.Message}");
                }
            }
            MessageBox.Show($"{successCount} of {this.fileListView.Items.Count} files processed successfully.", "Batch Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBrowseOutputDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                this.txtOutputDir.Text = path;
                Properties.Settings.Default.outputDirectory = path;
                Properties.Settings.Default.Save();
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/1811455433/CropPictureBorders");
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pbBefore.BackColor = this.colorDialog1.Color;
                this.pbAfter.BackColor = this.colorDialog1.Color;
            }
        }

        private void FileListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.fileListView.SelectedItems.Count > 0)
            {
                string path = this.fileListView.SelectedItems[0].Text;

                // Dispose the old image if one exists.
                _currentOriginalImage?.Dispose();
                pbBefore.Image = null;

                try
                {
                    // Load the new image from disk into our memory field.
                    _currentOriginalImage = Image.FromFile(path);

                    // Set the 'Before' preview once.
                    this.pbBefore.Image = new Bitmap(_currentOriginalImage);

                    // If this is the first image, update the slider limits.
                    if (fileListView.Items.Count > 0 && fileListView.Items.IndexOf(fileListView.SelectedItems[0]) == 0)
                    {
                        UpdateCropLimits(path);
                    }

                    // Update the 'After' preview with the current crop settings.
                    UpdateAfterPreview();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error loading image: {ex.Message}");
                    _currentOriginalImage = null;
                    pbBefore.Image = null;
                    pbAfter.Image = null;
                }
            }
        }

        private void BtnClearList_Click(object sender, EventArgs e)
        {
            this.fileListView.Items.Clear();
            _currentOriginalImage?.Dispose();
            _currentOriginalImage = null;
            this.pbBefore.Image = null;
            this.pbAfter.Image = null;
            this.label1.Visible = true;
            this.btnProcessBatch.Enabled = false;
            this.btnClearList.Enabled = false;
            ResetCropLimits();
        }

        private void UpdateCropLimits(string imagePath)
        {
            try
            {
                using (Image img = Image.FromFile(imagePath))
                {
                    int verticalMax = img.Height;
                    int horizontalMax = img.Width;
                    topTrackBox.Maximum = verticalMax;
                    bottomTrackBox.Maximum = verticalMax;
                    leftTrackBox.Maximum = horizontalMax;
                    rightTrackBox.Maximum = horizontalMax;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Could not load image to set limits: {ex.Message}");
                ResetCropLimits();
            }
        }

        private void ResetCropLimits()
        {
            int defaultMax = 50;
            topTrackBox.Maximum = defaultMax;
            bottomTrackBox.Maximum = defaultMax;
            leftTrackBox.Maximum = defaultMax;
            rightTrackBox.Maximum = defaultMax;
        }

        private void pbBefore_Paint(object sender, PaintEventArgs e)
        {
            var pb = sender as PictureBox;
            if (pb == null || pb.Image == null)
            {
                return;
            }

            Rectangle imageRect = CalculateImageRectangle(pb);

            using (Pen borderPen = new Pen(Color.DimGray, 1))
            {
                borderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawRectangle(borderPen, imageRect.X, imageRect.Y, imageRect.Width - 1, imageRect.Height - 1);
            }
        }

        private Rectangle CalculateImageRectangle(PictureBox box)
        {
            if (box.Image == null) return new Rectangle();

            float boxWidth = box.ClientSize.Width;
            float boxHeight = box.ClientSize.Height;
            float imgWidth = box.Image.Width;
            float imgHeight = box.Image.Height;

            float imgRatio = imgWidth / imgHeight;
            float boxRatio = boxWidth / boxHeight;

            float newWidth = 0;
            float newHeight = 0;
            float x = 0;
            float y = 0;

            if (imgRatio > boxRatio)
            {
                newWidth = boxWidth;
                newHeight = newWidth / imgRatio;
                y = (boxHeight - newHeight) / 2;
            }
            else
            {
                newHeight = boxHeight;
                newWidth = newHeight * imgRatio;
                x = (boxWidth - newWidth) / 2;
            }

            return new Rectangle((int)x, (int)y, (int)newWidth, (int)newHeight);
        }
    }
}