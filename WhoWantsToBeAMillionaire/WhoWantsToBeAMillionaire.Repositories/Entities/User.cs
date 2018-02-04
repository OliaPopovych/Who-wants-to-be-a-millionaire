using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhoWantsToBeAMillionaire.Repositories.Entities
{
    [Table("UserRating")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Sum { get; set; }

        public User(string name, string sum)
        {
            Name = name;
            Sum = sum;
        }

        public User()
        {
        }
    }
}
