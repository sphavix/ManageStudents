using MediatR;

namespace ManageStudents.Commands
{
    public class UpdateStudentCommand : IRequest<int>
    {
        public int Id { get; set;}
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public string StudentAddress { get; set; } = string.Empty;
        public int StudentAge { get; set; }

        // Overloaded constructor for UpdateStudentCommand
        public UpdateStudentCommand(int id, string studentName, string studentEmail, string studentAddress, int studentAge)
        {
            Id = id;
            StudentName = studentName;
            StudentEmail = studentEmail;
            StudentAddress = studentAddress;
            StudentAge = studentAge;
        }
    }
}