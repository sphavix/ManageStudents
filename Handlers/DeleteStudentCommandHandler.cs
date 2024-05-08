using ManageStudents.Commands;
using ManageStudents.Repositories;
using MediatR;

namespace ManageStudents.Handlers
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentByIdAsync(request.Id);
            if (student == null)
            {
                return default;
            }

            await _studentRepository.DeleteStudentAsync(student.Id);
            return student.Id;
        }
    }
}