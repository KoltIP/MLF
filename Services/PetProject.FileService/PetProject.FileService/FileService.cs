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


        public async Task Add(FileModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            byte[] content = model.Content;
            string dbContent = Convert.ToBase64String(content);

            PetFile entity = new PetFile()
            {
                Name = model.Name,
                Size = model.Size,
                ImageDataUrl = model.ImageDataUrl,
                ContentType = model.ContentType,
                Content = dbContent
            };
            var result = context.PetFiles.Add(entity);
            context.SaveChanges();
        }

        public async Task<byte[]> Get()
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var fileEntity = context.PetFiles.First();

            string contentStr = fileEntity.Content;

            byte[] content = System.Text.Encoding.Default.GetBytes(contentStr);

            return content;
        }
    }
}
