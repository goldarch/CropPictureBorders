using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CropPictureBorders
{
    public partial class MyTrackBox : UserControl
    {
        private bool _isUpdatingByCode = false;

        /// <summary>
        /// The maximum value of the slider.
        /// </summary>
        public int Maximum
        {
            get { return this.trackBar1.Maximum; }
            set
            {
                this.trackBar1.Maximum = value;
                this.numValue.Maximum = value;
                this.lblMax.Text = $"/ {value}";
            }
        }

        /// <summary>
        /// The direction of the control.
        /// </summary>
        public Orientation Orientation
        {
            get { return this.trackBar1.Orientation; }
            set { this.trackBar1.Orientation = value; }
        }

        /// <summary>
        /// The value of the slider.
        /// </summary>
        public int Value
        {
            get { return this.trackBar1.Value; }
            set
            {
                if (value >= trackBar1.Minimum && value <= trackBar1.Maximum)
                {
                    this.trackBar1.Value = value;
                    this.numValue.Value = value;
                }
            }
        }

        /// <summary>
        /// This function is called after the slider value changes.
        /// </summary>
        public event EventHandler ValueChanged;

        public MyTrackBox()
        {
            InitializeComponent();
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingByCode) return;

            _isUpdatingByCode = true;
            this.numValue.Value = this.trackBar1.Value;
            _isUpdatingByCode = false;

            // Bubble up the event
            this.ValueChanged?.Invoke(this, e);
        }

        private void numValue_ValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingByCode) return;

            _isUpdatingByCode = true;
            this.trackBar1.Value = (int)this.numValue.Value;
            _isUpdatingByCode = false;

            // Bubble up the event
            this.ValueChanged?.Invoke(this, e);
        }
    }
}