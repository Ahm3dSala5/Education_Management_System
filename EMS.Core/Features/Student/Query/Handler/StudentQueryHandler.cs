using AutoMapper;
using EMS.Core.Features.Courses.Query.Model;
using EMS.Core.Features.Instructors.Query.Model;
using EMS.Core.Features.Students.Query.Model;
using EMS.Core.Features.Students.Query.Request;
using EMS.Core.Response;
using EMS.Service.UnitOfWorks;
using MediatR;

namespace EMS.Core.Features.Students.Query.Handler
{
    public class StudentQueryHandler
        : ResultHandler,
        IRequestHandler<GetStudentByIdQuery, Result<StudentModel>> ,
        IRequestHandler<GetAllStudentsQuery ,Result<ICollection<StudentModel>>> ,
        IRequestHandler<GetStudentInstructorsQuery ,Result<ICollection<InstractorModel>>> ,
        IRequestHandler<GetStudentCoursesQuery ,Result<ICollection<CourseModel>>> 
       
        
    {
        private readonly IUnitOfWork _service;
        private readonly IMapper _mapper;

        public StudentQueryHandler(IUnitOfWork service,
            IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        public async Task<Result<StudentModel>> Handle
            (GetStudentByIdQuery request,CancellationToken cancellationToken)
        {
            var student = await _service.Students.GetOne(request.std_Id);
            var studentMapped =  _mapper.Map<StudentModel>(student);

            return studentMapped != null ? Success(studentMapped) 
                : NotFound<StudentModel>(_message:"Not Found");
        }

        public async Task<Result<ICollection<StudentModel>>> Handle
            (GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _service.Students.GetAll();
            var studentMapped = _mapper.Map<ICollection<StudentModel>>(students);

            return studentMapped.Count()!=0 ?
                Success(studentMapped,_meta:$"Number Of Students = {studentMapped.Count()}") :
                NotFound<ICollection<StudentModel>>(_message:"Students List Is Empty");
        }

        public async Task<Result<ICollection<InstractorModel>>> Handle
            (GetStudentInstructorsQuery request, CancellationToken cancellationToken)
        {
            var instructors = await _service.Students.GetStudentInstructor(request.std_Id);
            var instructorsMapped = _mapper.Map<ICollection<InstractorModel>>(instructors);

            return instructorsMapped.Count()!= 0 ?
                Success(instructorsMapped ,_meta:$"Student Has {instructorsMapped.Count()} Instructors") :
                NotFound<ICollection<InstractorModel>>(_message:"Student Not Has Any Instructors");
        }

        public async Task<Result<ICollection<CourseModel>>> Handle
            (GetStudentCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _service.Students.GetStudentInstructor(request.std_Id);
            var coursesMapped = _mapper.Map<ICollection<CourseModel>>(courses);

            return coursesMapped.Count() != 0 ?
                Success(coursesMapped, _meta: $"Student Has {coursesMapped.Count()} courses") :
                NotFound<ICollection<CourseModel>>(_message: "Student Not Has Any Courses");
        }
    }
}
