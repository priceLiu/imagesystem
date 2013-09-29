using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace imageSystem.Common
{
    public class FileProcess
    {
        public static string GenerateFileName(string sourceFileName)
        {
            FileInfo info = new FileInfo(sourceFileName);
            Guid guid = Guid.NewGuid();
            string newFileName = string.Format("{0}{1}", guid, info.Extension);

            return newFileName;
        }

        public static string CreateFloder(string root, int year, int month, int day)
        {
            string path = string.Format("{0}\\{1}\\{2}\\{3}", root, year,month, day);

            try
            {
                Directory.CreateDirectory(path);
                return path;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
