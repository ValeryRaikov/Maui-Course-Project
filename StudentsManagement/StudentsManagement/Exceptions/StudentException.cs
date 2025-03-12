namespace StudentsManagement.Exceptions
{
    public class StudentException : Exception
    {
        public StudentException() { }

        public StudentException(string message) : base(message) { }

        public StudentException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}