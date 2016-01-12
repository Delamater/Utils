using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;

namespace SampleWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileLocation = @"C:\temp\test.txt";

            //Directory must exist
            if (Directory.Exists(@"C:\temp") == true)
            {

                //Do not overwrite the file
                if (!File.Exists(@"C:\temp\test.txt"))
                {
                    StringBuilder sb = new StringBuilder();
                    StreamWriter sw = new StreamWriter(FileLocation);

                    sb.Append("My name is Inigo Montoya");

                    sw.Write(sb.ToString());
                    sw.Flush();
                    sw.Close();
                }

            }



            

        }
    }
}
