using PetProject.FileService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.FileService
{
    public interface IFileService
    {
        Task Add(FileModel model);
        Task<byte[]> Get();
    }
}
