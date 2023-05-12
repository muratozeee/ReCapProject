using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelperService
    {
        //IFormFile Http protocol to which file will upload,Root is which way will follow...
        string Upload(IFormFile file, string root);
        void Delete(string filepath);
        string Update(IFormFile file, string filePath, string root);


    }
}
