using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CropPictureBorders
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                foreach (string path in args)
                {
                    try
                    {
                        new Thread(new ParameterizedThreadStart(CropImageAndSaveAs)).Start(path);
                    }
                    catch (Exception ex)
                    {
                        // Log exceptions from the thread to the console
                        Console.WriteLine($"An error occurred while processing {path}: {ex.Message}");
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Crops an image and saves it.
        /// </summary>
        /// <param name="path">The path to the image.</param>
        private static void CropImageAndSaveAs(object path)
        {
            string filePath = (string)path;

            // For command-line operations, an output directory MUST be set.
            string outputDir = Properties.Settings.Default.outputDirectory;
            if (string.IsNullOrWhiteSpace(outputDir) || !Directory.Exists(outputDir))
            {
                Console.WriteLine($"Error: Output directory is not configured or is invalid. Please set one in the application. Skipping file: {Path.GetFileName(filePath)}");
                return;
            }

            using (Image result = Image.FromFile(filePath))
            {
                int x = Properties.Settings.Default.leftValue;
                int y = Properties.Settings.Default.topValue;
                int width = result.Width - x - Properties.Settings.Default.rightValue;
                int height = result.Height - y - Properties.Settings.Default.bottomValue;

                if (width < 1) width = 1;
                if (height < 1) height = 1;

                using (Image cropped = ImageHelper.CutPicture(result, x, y, width, height))
                {
                    cropped.Save(GetSuitablePath(filePath));
                }
            }
        }

        /// <summary>
        /// Gets a suitable file path for the processed image based on the set output directory.
        /// </summary>
        /// <param name="sourcePath">The original file path.</param>
        /// <returns>A new file path.</returns>
        public static string GetSuitablePath(string sourcePath)
        {
            string outputDirectory = Properties.Settings.Default.outputDirectory;
            string sourceDirectory = Path.GetDirectoryName(sourcePath);

            // Normalize paths to ensure a reliable comparison, removing any trailing slashes.
            string fullSourceDir = Path.GetFullPath(sourceDirectory).TrimEnd(Path.DirectorySeparatorChar);
            string fullOutputDir = Path.GetFullPath(outputDirectory).TrimEnd(Path.DirectorySeparatorChar);

            // If the output directory is the same as the source, append a number to avoid overwriting the original.
            if (fullSourceDir.Equals(fullOutputDir, StringComparison.OrdinalIgnoreCase))
            {
                string fileName = Path.GetFileNameWithoutExtension(sourcePath);
                string extension = Path.GetExtension(sourcePath);
                string newPath;
                int i = 1;
                do
                {
                    newPath = Path.Combine(outputDirectory, $"{fileName}({i}){extension}");
                    i++;
                } while (File.Exists(newPath));
                return newPath;
            }
            else
            {
                // If the directories are different, use the original filename, overwriting any existing file.
                string originalFileName = Path.GetFileName(sourcePath);
                return Path.Combine(outputDirectory, originalFileName);
            }
        }
    }
}