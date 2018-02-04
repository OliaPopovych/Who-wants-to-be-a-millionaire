using System.ComponentModel.DataAnnotations;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    public class MailViewModel
    {
        public string Sender { get; set; }
        [Required(ErrorMessage = "Recipient is required")]
        public string Recipient { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}