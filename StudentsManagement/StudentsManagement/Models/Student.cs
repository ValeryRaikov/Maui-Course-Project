namespace StudentsManagement.Models
{
    public class Student
    {
        private int _studentId;
        private string _firstName;
        private string _lastName;
        private string _email;

        public int StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}
