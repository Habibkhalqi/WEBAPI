using System.ComponentModel.DataAnnotations;

namespace RestulAPiCRUD.Models
{
    public class Student
    {
        public int id { get; set; }
        [Required]
        public string sName { get; set; }
        [Required]
        public int sAge { get; set; }
        [Required]
        public string sGender { get; set; }
        [Required]
        public string sFatherName { get; set; }
        [Required]
        public string sClass { get; set; }

    }
}
