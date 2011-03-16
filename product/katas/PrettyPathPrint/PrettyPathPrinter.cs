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
        public static string print(string path)
        {
            if (File.Exists(path))
            {
                StringBuilder sb = new StringBuilder();

                FileAttributes fas = File.GetAttributes(path);
                if ((fas & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    Console.WriteLine("Given path is directory");
                }
                else
                {
                    AppendLeaf(ref sb, 0, path);
                    return sb.ToString();
                }


            }
            throw new ArgumentException("No such path exists");
        }

        private static void AppendLeaf(ref StringBuilder sb, int depth, string name)
        {
            for (int i = 0; i < depth; i++)
            {
                sb.Append("  ");
            }
            sb.Append(name).Append(Environment.NewLine);
        }

    }
}
