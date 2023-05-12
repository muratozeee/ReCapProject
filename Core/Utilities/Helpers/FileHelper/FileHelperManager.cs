using Core.Utilities.Helpers.GuidHelpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    //in this Class we will do CRUD(Create,Read,Update,Delete) operations for file.

    public class FileHelperManager : IFileHelperService
    {




        //We can upload the File in this root(in this way)
        //filepath is coming from ICarImageManager ,root is =jpeg it means way,which type of file
        public string Upload(IFormFile file, string root)
        {
            //if File Length is 0 return the null
            //it has a byte it means... it has a memory or no checking
            if (file.Length > 0)
            {
                //it is checking .jpeg have or no doesnt have it will create the way.
                if (!Directory.Exists(root))
                {
                    //this one is for UI memory working like that.firstly checking (random way=we created for photos in manager) have or no then
                    //dont have then again create the way for IU to save file in the service
                    Directory.CreateDirectory(root);
                }
                //extension is defined the extention variables file name
                string extension = Path.GetExtension(file.FileName);

               //which way will use the system we created random file way like that for safe.and guid was defined the this random numbers in the jpeg.
                string guid = GuidHelpers.GuidHelpers.CreatGuid();
                //then filepath was defined the total name and which way
                string filePath = guid + extension;

                //root and filepath created with IDısposable pattern
               //it means after do that then  will deleted with garbage collector
                using (FileStream fileStream = File.Create(root + filePath))
                {
                    //it is defined the with copy method in file full name
                    file.CopyTo(fileStream);
                    //then delete the flush in memory to new something.
                    fileStream.Flush();

                    return filePath;
                }
            }
            return null;
        }
        //filepath is coming from ICarImageManager 
        public void Delete(string filePath)
        {//if filepath way has a same file then we can delete the filePath
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        public string Update(IFormFile file, string filePath, string root)
        {
            //firstly We are checking file have or no than if it has firstly delete it then Upload the new file with way(root) 
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }
    }
}
