using ManageStudents.Models;
using MediatR;

namespace ManageStudents.Commands
{
    public class CreateStudentCommand : IRequest<Student>
    {
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public string StudentAddress { get; set; } = string.Empty;
        public int StudentAge { get; set; }
    
        public CreateStudentCommand(string studentName, string studentEmail, string studentAddress, int studentAge)
        {
            StudentName = studentName;
            StudentEmail = studentEmail;
            StudentAddress = studentAddress;
            StudentAge = studentAge;
        }
    }
}