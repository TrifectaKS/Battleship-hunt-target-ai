using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.File_Operations
{
    class FileWriter : Files
    {
        public static FileEnum Write(string path, string content)
        {
            try
            {
                if (File.Exists(path))
                    return FileEnum.WriteFailed;

                File.WriteAllText(path, content);
                return FileEnum.WriteSuccessful;
            }
            catch
            {
                return FileEnum.WriteFailed;
            }
        }
    }
}
