
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace AdoptAPI.Classes
{
    public class GenerateLog
    {
        private TextWriter LogFile { get; set; }
        private string FileName { get; set; }
        private string LogPath { get; set; }

        public GenerateLog(string owner)
        {
            if (string.IsNullOrEmpty(owner))
                owner = "UNDEFINED";
            this.FileName = "LOG_" + owner.ToUpper() + "_" + DateTime.Now.ToString("dd_MM_yyyy") + ".log";
            LogPath = ConfigurationManager.AppSettings["LOG_PATH"] + owner.ToUpper() + "\\";
        }

        public GenerateLog(string fileName, string owner, string subPath)
        {
            if (string.IsNullOrEmpty(owner))
                owner = "UNDEFINED";
            this.FileName = fileName + ".txt";
            LogPath = ConfigurationManager.AppSettings["LOG_PATH"] + owner.ToUpper() + "\\" + subPath + "\\";
        }

        public void WriteOnLogFile(bool error, string errorMessage, string sql)
        {
            try
            {
                if (!Directory.Exists(LogPath))
                    Directory.CreateDirectory(LogPath);
                LogFile = GetLogFile(LogPath, FileName);
                if (LogFile != null)
                {
                    if (!string.IsNullOrEmpty(errorMessage))
                        LogFile.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " - " + (error.Equals(true) ? "ERROR " : "") + "MESSAGE: " + errorMessage.ToUpper());
                    if (!string.IsNullOrEmpty(sql))
                        LogFile.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " - SQL: " + sql.ToUpper());
                }
            }
            catch
            {
            }
            CloseLogFile();
        }

        public void WriteOnLogFile(bool error, string errorMessage)
        {
            try
            {
                if (!Directory.Exists(LogPath))
                    Directory.CreateDirectory(LogPath);
                LogFile = GetLogFile(LogPath, FileName);
                if (LogFile != null)
                    if (!string.IsNullOrEmpty(errorMessage))
                        LogFile.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " - " + (error.Equals(true) ? "ERROR " : "") + "MESSAGE: " + errorMessage.ToUpper());
            }
            catch
            {
            }
            CloseLogFile();
        }

        private StreamWriter GetLogFile(string path, string fileName)
        {
            StreamWriter sw = null;
            string filePath = path + fileName;
            if (File.Exists(filePath))
                sw = File.AppendText(filePath);
            else
                sw = File.CreateText(filePath);
            return sw;
        }

        public void CloseLogFile()
        {
            try
            {
                LogFile.Close();
            }
            catch
            {
            }
        }
    }
}