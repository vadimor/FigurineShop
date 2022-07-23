namespace MVC.Models.Requests
{
    public class UpdateRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = null!;
    }
}
