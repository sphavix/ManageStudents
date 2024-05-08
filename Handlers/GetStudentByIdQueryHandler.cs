using ManageStudents.Models;
using ManageStudents.Queries;
using ManageStudents.Repositories;
using MediatR;

namespace ManageStudents.Handlers
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly IStudentRepository _repository;

        public GetStudentByIdQueryHandler(IStudentRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Student> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetStudentByIdAsync(query.Id);
        }
    }
}