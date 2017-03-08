using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.File_Operations
{
    class FileReader : Files
    {
        static string ReadString(string path)
        {
            try
            {
                if (!File.Exists(path))
                    return FileEnum.ReadFailed.ToString();

                string text = File.ReadAllText(path);
                return text;
            }
            catch
            {
                return FileEnum.ReadFailed.ToString();
            }
        }
    }
}
