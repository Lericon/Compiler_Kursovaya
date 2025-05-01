using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler_Kursovaya
{
    public class File
    {
        public string filename;
        public string path;
        public string EditText;
        public string FinalText;
        public bool file_saved;
        public bool file_saved_as;

        public File(string filename, string path, string editText, string finalText, bool fileSaved, bool fileSavedAs)
        {
            this.filename = filename;
            this.path = path;
            this.EditText = editText;
            this.FinalText = finalText;
            this.file_saved = fileSaved;
            this.file_saved_as = fileSavedAs;
        }

        public static File OpenFile(string path)
        {
            string filename = System.IO.Path.GetFileName(path);
            string fileText = System.IO.File.ReadAllText(path);

            return new File(filename, path, fileText, null, true, true);
        }
    }
}
