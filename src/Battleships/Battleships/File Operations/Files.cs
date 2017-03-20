using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.File_Operations
{
    class Files
    {
        public enum FileEnum
        {
            WriteSuccessful = 0,
            WriteFailed = 1,
            ReadFailed = 2
        }

        public static string Read(string path)
        {
            try
            {
                if (!File.Exists(path))
                    throw new FileLoadException("Failed To Read File As Path '" + path + "' Doesn't Exist.");

                string text = File.ReadAllText(path);
                return text;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static FileEnum Write(string path, string content)
        {
            try
            {
                if (File.Exists(path))
                    throw new Exception("Failed To Write File In Path " + path);

                File.WriteAllText(path, content);
                return FileEnum.WriteSuccessful;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
