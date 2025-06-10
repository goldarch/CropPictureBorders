using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace CropPictureBorders
{
    /// <summary>
    /// A utility class for image processing.
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// Crops an image, cutting out a rectangular area from the source image.
        /// </summary>
        /// <param name="image">The image to modify.</param>
        /// <param name="x">The x-coordinate of the starting point.</param>
        /// <param name="y">The y-coordinate of the starting point.</param>
        /// <param name="width">The width of the new image.</param>
        /// <param name="height">The height of the new image.</param>
        public static Image CutPicture(Image image, int x, int y, int width, int height)
        {
            // Define the cropping rectangle
            System.Drawing.Rectangle cropArea = new System.Drawing.Rectangle(x, y, width, height);

            // Check for out-of-bounds positions
            if ((image.Width < x + width) || image.Height < y + height)
            {
                image.Dispose();
                string errorMessage = "Crop dimensions are outside the original image dimensions!";
                int horizontal = image.Width - x - width;
                int vertical = image.Height - y - height;
                if (horizontal < 0)
                {
                    errorMessage += $"  Width exceeds by {-horizontal}!";
                }
                if (vertical < 0)
                {
                    errorMessage += $"  Height exceeds by {-vertical}!";
                }
                throw new Exception(errorMessage);
            }

            // Define the Bitmap object
            System.Drawing.Bitmap bmpImage = new System.Drawing.Bitmap(image);

            // Perform the crop
            System.Drawing.Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);

            return bmpCrop;
        }
    }
}