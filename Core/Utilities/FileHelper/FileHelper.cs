using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\images\\";

        public static IResult Upload(IFormFile file, FileType fileType)
        {
            var type = Path.GetExtension(file.Name);
            var typeValid = CheckFileType(type, fileType);
            var randomName = "";
            if (typeValid.Success)
            {
                randomName = Guid.NewGuid().ToString();
            }

            var realDirectory = _currentDirectory + _folderName + randomName + type;
            CreateImageFile(realDirectory, file);
            return new SuccessResult(realDirectory.Replace("\\", "/"));
        }

        public static IResult Update(IFormFile file, string filePath, FileType fileType)
        {
            var result = Delete(filePath);
            if (!result.Success)
            {
                return result;
            }

            var type = Path.GetExtension(file.Name);
            var typeValid = CheckFileType(type, fileType);
            if (!typeValid.Success)
            {
                return new ErrorResult(typeValid.Message);
            }

            var randomName = Guid.NewGuid().ToString();
            var realDirectory = _currentDirectory + _folderName + randomName + type;
            CreateImageFile(realDirectory, file);
            return new SuccessResult("Image has been updated successfully");
        }

        public static IResult Delete(string filePath)
        {
            if (!File.Exists(filePath.Replace("/", "\\")))
            {
                return new ErrorResult("File is not exists");
            }

            File.Delete(filePath.Replace("/", "\\"));
            return new SuccessResult("File has been deleted successfully");
        }

        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream fileStream = File.Create(directory))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
        }

        private static IResult CheckFileType(string type, FileType extensions)
        {
            for (int i = 0; i < extensions.Extensions.Length; i++)
            {
                if (type != extensions.Extensions[i])
                {
                    return new ErrorResult("Type is not valid");
                }
            }


            return new SuccessResult();
        }
    }
}