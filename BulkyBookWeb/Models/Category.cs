using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key] //Or we couldn't use that because entity could understand that by Itself
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display order must be 1 to 100 only!!")] 
        public int Age { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
