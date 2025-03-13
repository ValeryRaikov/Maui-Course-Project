using System.ComponentModel.DataAnnotations;
using SQLite;
using StudentsManagement.Models;

namespace StudentsManagement.Data
{
    [Table("students")]
    public class StudentEntity : Student
    {
        [PrimaryKey, AutoIncrement]
        public int StudentId { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.MaxLength(50)]
        public new string FirstName { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.MaxLength(50)]
        public new string LastName { get; set; }

        [Required]
        [EmailAddress]
        public new string Email { get; set; }
    }
}
