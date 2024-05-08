using ManageStudents.Commands;
using ManageStudents.Repositories;
using MediatR;

namespace ManageStudents.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentByIdAsync(command.Id);
            if (student == null)
            {
                return default;
            }

            student.StudentName = command.StudentName;
            student.StudentEmail = command.StudentEmail;
            student.StudentAddress = command.StudentAddress;
            student.StudentAge = command.StudentAge;

            await _studentRepository.UpdateStudentAsync(student);

            return student.Id;
        }
    }
}