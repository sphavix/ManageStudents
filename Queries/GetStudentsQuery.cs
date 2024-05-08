using ManageStudents.Models;
using MediatR;

namespace ManageStudents.Queries
{
    public class GetStudentsQuery : IRequest<List<Student>> { }
}