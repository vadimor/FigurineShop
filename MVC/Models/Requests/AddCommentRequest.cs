namespace MVC.Models.Requests
{
    public class AddCommentRequest
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }
        [Required]
        [StringLength(1000)]
        public string Commentary { get; set; } = null!;
    }
}
