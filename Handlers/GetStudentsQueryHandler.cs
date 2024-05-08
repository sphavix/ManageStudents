using ManageStudents.Models;
using ManageStudents.Queries;
using ManageStudents.Repositories;
using MediatR;

namespace ManageStudents.Handlers
{
    public class GetStudentsQueryHandler: IRequestHandler<GetStudentsQuery, List<Student>>
    {
        private readonly IStudentRepository _repository;

        public GetStudentsQueryHandler(IStudentRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetStudentsAsync();
        }
    }
}