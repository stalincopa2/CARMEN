using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SaraCoffe.Service
{
    public class PictureService
    {
        private String PathDirectory;
        public PictureService(string pathDirectory)
        {
            PathDirectory = pathDirectory;
        }
        //"/Content/ImgProducts/{0}"
        public String Insert(HttpPostedFileBase File, HttpServerUtilityBase Server)
        {
            Guid g = Guid.NewGuid();

            var FileName = g.ToString().Substring(0, 10) + File.FileName.Substring(File.FileName.Length - 5, 5);
            Stream stream = File.InputStream;
            String Ruta = String.Format(PathDirectory, FileName);
            String oPath = Server.MapPath("~" + Ruta);

            File.SaveAs(oPath);
            return FileName;
        }

        public String Edit(HttpPostedFileBase File, HttpServerUtilityBase Server, String CurrentName)
        {
            if (CurrentName != "NA")
            {
                Delete(CurrentName, Server); 
            }
            Guid g = Guid.NewGuid();

            var FileName = g.ToString().Substring(0, 10) + File.FileName.Substring(File.FileName.Length - 5, 5);
            Stream stream = File.InputStream;
            String Ruta = String.Format(PathDirectory, FileName);
            String oPath = Server.MapPath("~" + Ruta);

            File.SaveAs(oPath);
            return FileName;
        }

        public void Delete(String FileName, HttpServerUtilityBase Server)
        {
            String Ruta = String.Format(PathDirectory, FileName);
            String oPath = Server.MapPath("~" + Ruta);

            if (System.IO.File.Exists(oPath))
                System.IO.File.Delete(oPath);
        }
    }
}