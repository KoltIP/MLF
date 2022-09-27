namespace PetProject.Web.Pages.Advertisement.Models
{
    public class AdvertisementList
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public float Price { get; set; }
        public int PetId { get; set; }
    }
}
