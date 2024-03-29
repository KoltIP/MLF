﻿using PetProject.Web.Pages.Content.Models.File;

namespace PetProject.Web.Pages.Advertisement.Models.Advertisement
{
    public class AdvertisementResponse
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public bool Gender { get; set; }
        public bool IsWanted { get; set; }
        public string? PetName { get; set; } = string.Empty;
        public string? PetDescription { get; set; } = string.Empty;
        public float? Price { get; set; }
        public int PetColorId { get; set; }
        public string PetColor { get; set; } = string.Empty;
        public int PetBreedId { get; set; }
        public string PetBreed { get; set; } = string.Empty;
        public int PetTypeId { get; set; }
        public string PetType { get; set; } = string.Empty;
        public int CityId { get; set; }
        public string City { get; set; } = string.Empty;
        public int? Age { get; set; }
        public DateTime? DateLost { get; set; }
        public List<FileResponse> Images { get; set; }
        //public int ImageId { get; set; }
        //public byte[] ImageContent { get; set; }
        //public string ImageContentType { get; set; } = string.Empty;
    }
}
