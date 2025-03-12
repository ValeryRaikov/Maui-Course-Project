using SQLite;
using StudentsManagement.Data;
using StudentsManagement.Exceptions;

namespace StudentsManagement.Services
{
    public class StudentService : IStudentService
    {
        private readonly SQLiteAsyncConnection _dbConnection;

        public StudentService()
        {
            _dbConnection = SetupDb().Result;
        }

        private async Task<SQLiteAsyncConnection> SetupDb()
        {
            try
            {
                string dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "students.db3"
                );

                var connection = new SQLiteAsyncConnection(dbPath);
                await connection.CreateTableAsync<StudentEntity>().ConfigureAwait(false);

                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database initialization failed: {ex.Message}");
                throw new DatabaseException();
            }
        }

        public async Task<IEnumerable<StudentEntity>> GetStudentList()
        {
            try
            {
                return await _dbConnection.Table<StudentEntity>().ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new StudentException("An error occurred while retrieving the student list.", ex);
            }
        }

        public async Task<int> AddStudent(StudentEntity student)
        {
            try
            {
                if (student == null)
                    throw new ArgumentNullException(nameof(student), "Student data cannot be null.");

                return await _dbConnection.InsertAsync(student).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new StudentException("An error occurred while adding the student.", ex);
            }
        }

        public async Task<int> DeleteStudent(StudentEntity student)
        {
            try
            {
                if (student == null)
                    throw new ArgumentNullException(nameof(student), "Student data cannot be null.");

                return await _dbConnection.DeleteAsync(student).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new StudentException("An error occurred while removing the student.", ex);
            }
        }

        public async Task<int> UpdateStudent(StudentEntity student)
        {
            try
            {
                if (student == null)
                    throw new ArgumentNullException(nameof(student), "Student data cannot be null.");

                return await _dbConnection.UpdateAsync(student).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new StudentException("An error occurred while updating the student.", ex);
            }
        }
    }
}
