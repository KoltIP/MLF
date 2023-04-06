using PetProject.Web.Pages.Content.Models.File;

namespace PetProject.Web.Pages.Content.Models.Advertisement
{
    public class AdvertisementFilterModel
    {
        public int IsWanted { get; set; }
        public float? PriceStart { get; set; }
        public float? PriceEnd { get; set; }
        public int PetColorId { get; set; }
        public int PetBreedId { get; set; }
        public int PetTypeId { get; set; }
        public int CityId { get; set; }
        public int? AgeStart { get; set; }
        public int? AgeEnd { get; set; }
        public DateTime? DateLostStart { get; set; }
        public DateTime? DateLostEnd { get; set; }
    }
}
