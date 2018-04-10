using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Parlocameon.Generic.Logger
{
    public class Logspace
    {
        public static String appDataLocalPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static String DateLog(String dirpath, String filename, Boolean autoComplete=false)
        {
            //Provide a folder path if autoComplete is true, will append dated file path
            //Example: C:/Users/User/Desktop/
            if(autoComplete)  {

                String date = Regex.Replace(DateTime.Now.ToString(), @":|/|\s", @"-");
                String autopath = dirpath + @"" + date + ".log";
                Directory.CreateDirectory(dirpath);
                
                File.AppendAllText(autopath, DateTime.Now.ToString()+Environment.NewLine);
                //returns path to reference in WriteLog();
                return autopath;
            }
            else
            {
                Directory.CreateDirectory(dirpath);
                File.AppendAllText(dirpath+filename, DateTime.Now.ToString()+Environment.NewLine);
                return null;
            }
        }
        public static void WriteLog(String dirpath, String filename, String message, Headers h)
        {
            String[] SHeaders = { "", "[STATUS]: ", "[WARNING]: ", "[INFO]: ", "[ERROR]: " };
            if (filename != null)
            {
                Directory.CreateDirectory(dirpath);
            }
            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(dirpath));
            }
            File.AppendAllText(dirpath+filename, SHeaders[Convert.ToInt32(h)] + message+Environment.NewLine);
            

        }
    }

    [Flags]
    public enum Headers
    {
        None = 0,
        STATUS = 1,
        WARNING = 2,
        INFO = 3,
        ERROR = 4

    }

}
