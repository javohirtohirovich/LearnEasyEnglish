using System;
using System.IO;

namespace EduCenter.Desktop.Helpers;

public class ContentNameMaker
{
    public static string GetImageName(string filepath)
    {
        FileInfo fileInfo = new FileInfo(filepath);
        return "IMG_"+Guid.NewGuid().ToString()+fileInfo.Extension;
        // IMG_47864f-245-34534gfe.jpg
    }
}
