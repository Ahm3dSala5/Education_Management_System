using EMS.Infrastructure.Domain.Entities;

namespace EMS.Service.EMS.Abstractions.Business
{
    public interface IRoomService
    {
        ValueTask<ICollection<Student>> GetRoomStudents(int id);
        ValueTask<ICollection<Course>> GetRoomCourses(int id);
        ValueTask<ICollection<Instructor>> GetRoomInstructors(int id);
    }
}
