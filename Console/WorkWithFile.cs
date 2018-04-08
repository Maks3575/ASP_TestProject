﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace Console
{
    public static class WorkWithFile
    {
        public static void UploadFile(string name, string path)
        {
            using (DocX Document = DocX.Load(path))
            {
                MemoryStream ms = new MemoryStream();
                Document.SaveAs(ms);

                using (TestASPEntities db = new TestASPEntities())
                {
                    File file = new File
                    {
                        Name = name,
                        File1 = ms.ToArray()
                    };
                    db.Files.Add(file);
                    db.SaveChanges();
                }
            }
        }

        public static void DownloadFile(int id, string path)
        {
            using( TestASPEntities db = new TestASPEntities())
            {
                var file = db.Files.FirstOrDefault(f => f.Id == id);
                using (DocX Document = DocX.Load(new MemoryStream(file.File1)))
                {
                    Document.SaveAs(path);
                }       
            }
        }
    }
}
