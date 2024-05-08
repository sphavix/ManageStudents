using ManageStudents.Models;
using MediatR;

namespace ManageStudents.Queries
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int Id { get; set; }
    }
}