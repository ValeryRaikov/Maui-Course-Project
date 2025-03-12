using SQLite;
using System.ComponentModel.DataAnnotations;

namespace StudentsManagement.Data
{
    [Table("students")]
    public class StudentEntity
    {
        [PrimaryKey, AutoIncrement]
        public int StudentId { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
