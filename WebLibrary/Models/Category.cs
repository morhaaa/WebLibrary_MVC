using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebLibrary.Models
{

    public class Category
    {
        [Key]
         public int Id { get; set; }

         [Required]
         [DisplayName("Category Name")]// Nome da far vedere nella label
         [MaxLength(30, ErrorMessage = "Max length of 30 characters")]
         public string Name { get; set; }
    }
}
