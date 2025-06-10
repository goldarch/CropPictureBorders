# 批量图片边框裁剪工具
批量裁剪图片的四周，获得新的图片
参考自：https://github.com/catmade/CropPictureBorders 

# **CropPictureBorders**

**CropPictureBorders** is a practical and efficient desktop utility designed to remove unwanted transparent or solid-colored borders from images, especially screenshots. It offers both a graphical user interface (GUI) for interactive adjustments and a command-line interface for automated batch processing.

## **Features**

* **Dual-Mode Operation:**  
  * **GUI Mode:** An interactive interface with live "Before" and "After" previews for precise, per-image adjustments.  
  * **Command-Line Mode:** Drag and drop multiple image files onto the application's .exe to process them automatically using the last saved settings.  
* **Interactive Crop Adjustment:** Precise pixel-level control with Top, Bottom, Left, and Right sliders and numeric inputs.  
* **Dynamic UI:** Automatic adjustment of slider limits based on the loaded image dimensions.  
* **Persistent Settings:** Saves the last used crop values and output directory.  
* **Intelligent File Output:**  
  * Option to specify a dedicated output directory; files are saved with their original names.  
  * If the output directory is the same as the source directory, files are saved with a numeric suffix to prevent overwriting.  
* **User-Friendly Previews:**  
  * "Before" preview shows the full original image with a dashed border.  
  * "After" preview displays the full cropped image with a red border.

## **Screenshot**

*The main interface of CropPictureBorders.*
![image]([https://raw.githubusercontent.com/goldarch/ExceptionManager/master/img-folder/01.jpg])  

## **Usage**

### **Graphical User Interface (GUI)**

1. Run the CropPictureBorders.exe application.  
2. Drag and drop image files onto the "Before" preview box or the file list below.  
3. Select an image from the file list to load it into the previews.  
4. Adjust the Top, Bottom, Left, and Right sliders (or enter values in the numeric boxes) to define the crop area. The "After" preview will update in real-time.  
5. Optionally, set an "Output Directory" by browsing to your desired folder.  
6. Click "Save Default" to remember the current crop settings for future use.  
7. Click "Process Batch" to apply the current crop settings to all images in the file list and save the processed images to the specified (or source) directory.  
8. Click "Clear List" to remove all files from the processing queue.

### **Command-Line Interface**

1. Locate the CropPictureBorders.exe file.  
2. Drag one or more image files directly onto the CropPictureBorders.exe file.  
3. The application will automatically process all dropped images using the last saved crop settings.  
4. Processed images will be saved to the specified output directory (if set) or their original directories (with a numeric suffix if the output directory is the same as the source).

## **Getting Started**

1. Clone or download the repository from [https://github.com/goldarch/CropPictureBorders](https://github.com/goldarch/CropPictureBorders).  
2. If you wish to build from source, ensure you have the .NET SDK installed. You can open the .sln file in Visual Studio or use the dotnet build command.  
3. Alternatively, download the latest release from the [Releases](https://github.com/goldarch/CropPictureBorders/releases) page, which includes pre-built executables.

## **License**

This project is licensed under the [MIT License](https://github.com/goldarch/CropPictureBorders/blob/main/LICENSE).

## **Author**

This project is open-source and maintained by [goldarch](https://github.com/goldarch).

## **Acknowledgements**

Thank you to the .NET community for providing the framework and tools to build this application.
