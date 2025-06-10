# 批量图片边框裁剪工具
批量裁剪图片的四周，获得新的图片
参考自：https://github.com/catmade/CropPictureBorders 

CropPictureBorders: An Intelligent Batch Image Border Cropping Tool
English Introduction
CropPictureBorders is a practical and efficient desktop utility designed to solve a common problem: removing unwanted transparent or solid-colored borders from images, especially screenshots. When capturing application windows that have modern UI effects like drop shadows, the resulting image often includes parts of the background. This tool provides an intuitive interface to precisely define crop values and apply them to a single image or a large batch of images automatically.

Built with C#, this application offers both a graphical user interface (GUI) for interactive adjustments and a command-line interface for automated batch processing. It intelligently saves user settings, manages output files to prevent overwriting originals, and dynamically adjusts its user interface based on the properties of the images being processed.

Key Features:
Dual-Mode Operation:
GUI Mode: A rich, interactive interface for processing images one by one. It features a live "Before" and "After" preview, allowing users to see the result of their cropping adjustments in real-time.
Command-Line Mode: Users can drag and drop multiple image files directly onto the application's .exe file. It will then automatically process all images using the last saved crop settings.
Interactive Crop Adjustment: Four sliders (Top, Bottom, Left, Right) allow for precise pixel-level control over the crop area. Corresponding numeric input boxes allow for direct value entry.
Dynamic UI: The cropping sliders' maximum value automatically adjusts to the dimensions of the first image loaded, preventing over-cropping.
Persistent Settings: The application saves the last used crop values and the designated output directory, so your preferred settings are ready for the next session.
Intelligent File Output:
Users can specify a dedicated output directory. When set, processed files are saved with their original names for easy organization.
If the output directory is the same as the source directory, the application automatically renames the processed file with a numeric suffix (e.g., image(1).png) to ensure the original file is never overwritten.
User-Friendly Previews:
The "Before" preview box displays the entire source image with a dashed border to clearly show its original dimensions, which is especially useful for images with transparent backgrounds.
The "After" preview box displays the entire resulting image with a red border to highlight the final cropped area.
Code Analysis
The application's logic is well-structured and separated into several key components:

Program.cs: This is the main entry point. It checks if the application was launched with command-line arguments (i.e., files dragged onto it). If so, it processes each file in a separate thread. Otherwise, it launches the main GUI window (MainForm).
MainForm.cs: This file is the heart of the GUI. It manages all user interactions, including:
Handling drag-and-drop operations for loading images into the file list.
Loading the selected image into memory for fast, lag-free previewing when sliders are adjusted.
Updating the UI based on events, such as selecting a new image or adjusting a slider.
Managing the output directory settings and orchestrating the batch processing when the "Process Batch" button is clicked.
ImageHelper.cs: A focused utility class responsible for the core image processing task. Its CutPicture method takes an image and cropping coordinates and returns a new, cropped image object. This separation of concerns keeps the image manipulation logic distinct from the UI code.
MyTrackBox.cs: A custom UserControl that combines a TrackBar, a NumericUpDown box, and a Label to create the composite slider control. This encapsulates the logic for keeping the slider and numeric input synchronized.
Settings.Designer.cs: Defines the application's settings, such as topValue, leftValue, and outputDirectory. These are automatically saved and loaded between sessions, providing a persistent user experience.
中文介绍
CropPictureBorders：一款智能的批量图片边框裁剪工具

CropPictureBorders 是一个为解决常见问题而设计的实用高效的桌面工具：移除图片（尤其是软件截图）中多余的透明或纯色边框。在截取带有现代UI（如窗口阴影）的程序窗口时，截图成品常常会包含不想要的背景部分。本工具提供了一个直观的界面，让用户可以精确地定义裁剪值，并将其自动应用于单张或大批量图片。

这款应用程序使用 C# 构建，同时提供了图形用户界面（GUI）用于交互式调整，以及命令行界面用于自动化批量处理。它能智能地保存用户设置、管理输出文件以防止覆盖原始文件，并根据所处理图片的属性动态调整其用户界面。

主要功能：
双模式操作：
GUI 模式： 功能丰富的交互式界面，可用于逐个处理图片。它具有实时的“裁剪前”和“裁剪后”预览功能，允许用户实时查看裁剪调整的结果。
命令行模式： 用户可以直接将一个或多个图片文件拖放到程序的 .exe 文件上。程序将使用最后一次保存的裁剪设置为所有图片进行自动化处理。
交互式裁剪调整： 四个（上、下、左、右）滑动条可实现精确到像素的裁剪区域控制。相应的数字输入框也允许用户直接输入精确的数值。
动态UI： 裁剪滑动条的最大值会根据加载的第一张图片的尺寸自动调整，以防止过度裁剪。
持久化设置： 应用程序会保存最后使用的裁剪值和指定的输出目录，您偏好的设置将在下次启动时自动加载。
智能文件输出：
用户可以指定一个专用的输出目录。设置后，处理完成的文件将以其原始文件名保存在该目录中，便于整理。
如果输出目录与源目录相同，程序会自动为处理后的文件重命名并添加数字后缀（例如 image(1).png），以确保原始文件永远不会被意外覆盖。
人性化预览：
“裁剪前”预览框会显示完整的源图像，并带有一个虚线边框以清晰展示其原始边界，这对于带透明背景的图片特别有用。
“裁剪后”预览框会显示完整的最终结果图，并带有一个红色边框以突出显示裁剪后的区域。
代码解析
此应用的逻辑结构清晰，分为几个关键组件：

Program.cs: 作为程序的主入口点，它会检查程序启动时是否附带了命令行参数（即是否有文件被拖拽到程序上）。如果有，它会为每个文件启动一个新线程进行处理；否则，它将启动主GUI窗口 (MainForm)。
MainForm.cs: 该文件是GUI的核心。它管理着所有的用户交互，包括：
处理拖放操作以将图片加载到文件列表中。
将当前选中的图片加载到内存中，以保证在调整滑块时能够流畅无卡顿地更新预览。
根据事件（如选择新图片或调整滑块）更新UI。
管理输出目录的设置，并在用户点击“处理批处理”按钮时统一调度所有文件的处理流程。
ImageHelper.cs: 一个专注的工具类，负责核心的图像处理任务。其 CutPicture 方法接收一个图像和裁剪坐标，并返回一个新的、经过裁剪的图像对象。这种关注点分离的设计使图像处理逻辑与UI代码保持独立。
MyTrackBox.cs: 一个自定义的 UserControl（用户控件），它将 TrackBar（滑块）、NumericUpDown（数字输入框）和 Label（标签）组合在一起，创建了功能丰富的复合滑块控件。它封装了保持滑块和数字输入同步的逻辑。
Settings.Designer.cs: 定义了应用程序的各项设置，如 topValue、leftValue 和 outputDirectory。这些设置会在不同会话之间自动保存和加载，提供了持久化的用户体验。
