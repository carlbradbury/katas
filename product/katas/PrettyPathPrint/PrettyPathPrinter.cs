using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace katas.PrettyPathPrint
{


    public class PrettyPathPrinter
    {
        public string print(string path)
        {
            if (File.Exists(path))
            {
                StringBuilder sb = new StringBuilder();

                FileAttributes fas = File.GetAttributes(path);
                if ((fas & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    
                    DirectoryInfo di = new DirectoryInfo(path);
                    AppendLeaf(sb, 0, di.Name);

                    foreach (FileInfo fileInfo in di.EnumerateFiles())
                    {
                        AppendLeaf(sb, 1, fileInfo.Name);
                    }

                    foreach (DirectoryInfo dirInfo in di.EnumerateDirectories())
                    {
                        AppendLeaf(sb, 1, dirInfo.Name);
                    }

                    Console.WriteLine("Given path is directory");
                }
                else
                {
                    // is path to a file
                    AppendLeaf(sb, 0, path);
                    return sb.ToString();
                }


            }
            throw new ArgumentException("No such path exists");
        }

        

        private static void AppendLeaf(StringBuilder sb, int depth, string name)
        {
            for (int i = 0; i < depth; i++)
            {
                sb.Append("  ");
            }
            sb.Append(name).Append(Environment.NewLine);
        }

    }
}
