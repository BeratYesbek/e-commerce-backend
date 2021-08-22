using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileType
    {
        public String[] Extensions { get; }

        public FileType(String[] fileExtensions)
        {
            Extensions = fileExtensions;
        }
    }
}