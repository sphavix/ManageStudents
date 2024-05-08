using ManageStudents.Data;
using ManageStudents.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageStudents.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.Where(s => s.Id == id).FirstOrDefaultAsync().ConfigureAwait(true);
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            var result = _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteStudentAsync(int Id)
        {
            var student = _context.Students.Where(x => x.Id == Id).FirstOrDefault();
            _context.Students.Remove(student);
            return await _context.SaveChangesAsync();
        }

    }
}