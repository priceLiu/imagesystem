using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using imageSystem.Common;

namespace imageSystem.Web
{
    /// <summary>
    /// Summary description for FileUpload
    /// </summary>
    public class FileUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            if (context.Request.Files.Count == 0)
            {

                LogRequest("No files sent.");

                context.Response.ContentType = "text/plain";
                context.Response.Write("No files received.");

            }
            else
            {

                HttpPostedFile uploadedfile = context.Request.Files[0];

                //string FileName = uploadedfile.FileName;
                string fileName = FileProcess.GenerateFileName(uploadedfile.FileName);
                string path = FileProcess.CreateFloder(HttpContext.Current.Server.MapPath("/Upload"), 
                                                                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                string fileType = uploadedfile.ContentType;
                int fileSize = uploadedfile.ContentLength;

                LogRequest(fileName + ", " + fileType + ", " + fileSize);

                uploadedfile.SaveAs(path + "\\" + fileName);

                context.Response.ContentType = "text/plain";
                context.Response.Write("{\"name\":\"" + fileName + "\",\"type\":\"" + fileType + "\",\"size\":\"" + fileSize + "\"}");

            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void LogRequest(string Log)
        {
            StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("/Log") + "\\Log.txt", true);
            sw.WriteLine(DateTime.Now.ToString() + " - " + Log);
            sw.Flush();
            sw.Close();
        }
    }
}