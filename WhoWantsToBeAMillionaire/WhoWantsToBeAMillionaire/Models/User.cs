using System.ComponentModel.DataAnnotations;

namespace WhoWantsToBeAMillionaire.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public int Winning { get; set; }
    }
}