using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luc.Common
{
    static public class LogFile
    {
        const string PATH_TOTAL_FILE = @"\Logs\TOTAL\Log";  //filename ex) Log20180101
        const string PATH_TOTAL_DIR = @"\Logs\TOTAL\";
        const string PATH_EXCEPTIONERROR_FILE = @"\Logs\ExceptionErro\Log";  //filename ex) Log20180101
        const string PATH_EXCEPTIONERROR_DIR = @"\Logs\ExceptionErro\";
        const string PATH_INFO_FILE = @"\Logs\Info\Log";  //filename ex) Log20180101
        const string PATH_INFO_DIR = @"\Logs\Info\";
        const string PATH_DEBUG_FILE = @"\Logs\DEBUG\Log";  //filename ex) Log20180101
        const string PATH_DEBUG_DIR = @"\Logs\DEBUG\";
        const string PATH_SEQUENCE_FILE = @"\Logs\Sequence\Log";  //filename ex) Log20180101
        const string PATH_SEQUENCE_DIR = @"\Logs\Sequence\";

        static private string GetDataTime()
        {
            DateTime NowData = DateTime.Now;
            return String.Format("{0}:{1}", NowData.ToString("yy-MM-dd HH:mm:ss"), NowData.Millisecond.ToString("000"));
        }

        static public void LogExceptionErr(string str)
        {
            string FilePath = String.Format("{0}{1}{2}.log", DefPath.ConfigPath, PATH_EXCEPTIONERROR_FILE, DateTime.Today.ToString("yyyyMMdd"));
            string DirPath = String.Format("{0}{1}", DefPath.ConfigPath, PATH_EXCEPTIONERROR_DIR);

            WriteLog(FilePath, DirPath, str);
        }

        static public void LogInfo(string str)
        {
            string FilePath = String.Format("{0}{1}{2}.log", DefPath.ConfigPath, PATH_INFO_FILE, DateTime.Today.ToString("yyyyMMdd"));
            string DirPath = String.Format("{0}{1}", DefPath.ConfigPath, PATH_INFO_DIR);

            WriteLog(FilePath, DirPath, str);
        }

        static public void LogSequence(string str)
        {
            string FilePath = String.Format("{0}{1}{2}.log", DefPath.ConfigPath, PATH_SEQUENCE_FILE, DateTime.Today.ToString("yyyyMMdd"));
            string DirPath = String.Format("{0}{1}", DefPath.ConfigPath, PATH_SEQUENCE_DIR);

            WriteLog(FilePath, DirPath, str);
        }

        static public void LogDebug(string str)
        {
            string FilePath = String.Format("{0}{1}{2}.log", DefPath.ConfigPath, PATH_DEBUG_FILE, DateTime.Today.ToString("yyyyMMdd"));
            string DirPath = String.Format("{0}{1}", DefPath.ConfigPath, PATH_DEBUG_DIR);

            WriteLog(FilePath, DirPath, str);
        }

        static private void WriteLog(string FilePath, string DirPath, string strDetail)
        {
            string temp;
            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);

            try
            {
                if (di.Exists == false) Directory.CreateDirectory(DirPath);

                temp = string.Format("[{0}] : {1}", GetDataTime(), strDetail);
                if (fi.Exists == false)
                {
                    using (StreamWriter sw = new StreamWriter(FilePath))
                    {
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }

                WriteLogTotal(temp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        static private void WriteLogTotal(string strDetail)
        {
            string FilePath = String.Format("{0}{1}{2}.log", DefPath.ConfigPath, PATH_TOTAL_FILE, DateTime.Today.ToString("yyyyMMdd"));
            string DirPath = String.Format("{0}{1}", DefPath.ConfigPath, PATH_TOTAL_DIR);

            //string temp;
            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);

            try
            {
                if (di.Exists == false) Directory.CreateDirectory(DirPath);
                
                if (fi.Exists == false)
                {
                    using (StreamWriter sw = new StreamWriter(FilePath))
                    {
                        sw.WriteLine(strDetail);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        sw.WriteLine(strDetail);
                        sw.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
