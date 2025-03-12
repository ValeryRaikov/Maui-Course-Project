using StudentsManagement.Data;

namespace StudentsManagement.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentEntity>> GetStudentList();

        Task<int> AddStudent(StudentEntity student);

        Task<int> DeleteStudent(StudentEntity student);

        Task<int> UpdateStudent(StudentEntity student);
    }
}
