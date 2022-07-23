namespace MVC.Models.Requests
{
    public class AddRequest
    {
        [Required]
        [StringLength(200, ErrorMessage ="Too long name")]
        public string Name { get; set; } = null!;
    }
}
