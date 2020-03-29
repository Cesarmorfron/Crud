using System.ComponentModel.DataAnnotations;

namespace CrudExample.Models
{
    public class ObjectModelPostDTO
    {
        [Required]
        public string VariableString { get; set; }
        public int VariableInt { get; set; }
        public bool VariableBool { get; set; }
    }
}
