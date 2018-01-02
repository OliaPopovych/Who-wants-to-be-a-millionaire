using System.ComponentModel.DataAnnotations;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    public class MailViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email required")]
        public string Sender { get; set; }
        [Required]
        public string Recipient { get; set; }
        [Required]
        public string Text { get; set; }
    }
}