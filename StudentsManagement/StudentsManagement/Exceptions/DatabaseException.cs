namespace StudentsManagement.Exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException() : base("Database error occurred.") {}
    }
}
