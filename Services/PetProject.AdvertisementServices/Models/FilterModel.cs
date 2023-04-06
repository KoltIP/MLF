using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.AdvertisementServices.Models
{
    public class FilterModel
    {
        public int? IsWanted { get; set; }
        public float? Price { get; set; }
        public int? PetColorId { get; set; }
        public int? PetBreedId { get; set; }
        public int? PetTypeId { get; set; }
        public int? CityId { get; set; }
        public int? AgeStart { get; set; }
        public int? AgeEnd { get; set; }
        public DateTime? DateLostStart { get; set; }
        public DateTime? DateLostEnd { get; set; }
    }
}
