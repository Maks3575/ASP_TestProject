using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //WorkWithFile.UploadFile("testDoc", @"C:\test\original.docx");
            WorkWithFile.DownloadFile(1, @"C:\test\FromDB.docx");
        }
    }
}
