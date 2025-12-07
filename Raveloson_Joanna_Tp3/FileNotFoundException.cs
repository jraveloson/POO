using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FileNotFoundException : Exception
{
    public FileNotFoundException(string message, string filePath):base("Can't find the file!") { }
}
