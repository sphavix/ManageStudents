using ManageStudents.Commands;
using ManageStudents.Models;
using ManageStudents.Repositories;
using MediatR;

namespace ManageStudents.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                StudentName = command.StudentName,
                StudentEmail = command.StudentEmail,
                StudentAddress = command.StudentAddress,
                StudentAge = command.StudentAge,
            };

            await _studentRepository.AddStudentAsync(student);

            return student;
        }
    }
}