using System;
using System.IO;
using WakeMeUpApp.Droid;
using WakeMeUpApp.SQL;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace WakeMeUpApp.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}