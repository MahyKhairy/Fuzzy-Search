using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.apache.tika;

namespace Fuzzy_Search
{
    public class TikaFile
    {
        public string ReadPdfFile(string filePath)
        {
            try
            {
                Tika t = new Tika();
                return t.parseToString(new java.io.File(filePath));

            }
            catch (Exception)
            {

                return "";
            }
        }
    }
}
