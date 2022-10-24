namespace PetProject.Web.Pages.Content.Models.Comment
{
    public class CommentListItem
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public int AdvertisementId { get; set; }
    }
}
