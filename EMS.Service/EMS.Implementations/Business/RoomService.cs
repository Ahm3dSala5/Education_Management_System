using EMS.Infrastructure.Domain.Entities;
using EMS.Infrastructure.Presistence.Context;
using EMS.Infrastructure.Repositories;
using EMS.Service.EMS.Abstractions.Business;
using Microsoft.Extensions.Configuration;

namespace EMS.Service.EMS.Implementations.Business
{
    public class RoomService :  MainRepository<Room>,IRoomService
    {
        private AppDbContext _app;
        public RoomService(AppDbContext app, IConfiguration config) : base(app, config)
        {
            this._app = app;
        }
        public ValueTask<ICollection<Course>> GetRoomCourses(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Instructor>> GetRoomInstructors(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Student>> GetRoomStudents(int id)
        {
            throw new NotImplementedException();
        }
    }
}
