namespace EMS.Infrastructure.Domain.Entities
{
    public class InstructorRooms
    {
        public int InstructorId{ set; get; }
        public int RoomId{ set; get; }
        public Instructor Instructor { set; get; }
        public Room Room { set; get; }
    }
}
