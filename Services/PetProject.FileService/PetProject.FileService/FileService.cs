using PetProject.FileService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.FileService
{
    public class FileService : IFileService
    {
        public Task Add(List<FileModel> model)
        {
            return Task.CompletedTask;
        }
    }
}
