using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetProject.Db.Context.Context;
using PetProject.Db.Entities;
using PetProject.FileService.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.FileService
{
    public class FileService : IFileService
    {
        private readonly IMapper mapper;
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public FileService(IMapper mapper,
            IDbContextFactory<MainDbContext> contextFactory)
        {
            this.mapper = mapper;
            this.contextFactory = contextFactory;
        }


        public async Task AddFile(AddFileModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            byte[] content = model.Content;
            string dbContent = Convert.ToBase64String(content);

            PetFile entity = new PetFile()
            {
                ContentType = model.ContentType,
                Content = dbContent
            };
            var result = context.PetFiles.Add(entity);
            context.SaveChanges();
        }

        public async Task<FileResponseModel> GetFile()
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var fileEntity = context.PetFiles.First();

            var result = new FileResponseModel()
            {
                Content = Convert.FromBase64String(fileEntity.Content),
                ContentType = fileEntity.ContentType,
            };

            return result;
        }

        public async Task<IEnumerable<FileResponseModel>> GetFiles()
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var filesEntities = context.PetFiles.ToList();

            var result = new List<FileResponseModel>();
            for (int i = 0; i < filesEntities.Count(); i++)
            {
                var item = new FileResponseModel()
                {
                    Content = Convert.FromBase64String(filesEntities[i].Content),
                    ContentType = filesEntities[i].ContentType,
                };
                result.Add(item);
            }

            return result;
        }
    }
}
