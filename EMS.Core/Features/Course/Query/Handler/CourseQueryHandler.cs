using AutoMapper;
using EMS.Core.Features.Courses.Query.Model;
using EMS.Core.Features.Courses.Query.Request;
using EMS.Core.Features.Instructors.Query.Model;
using EMS.Core.Features.Students.Query.Model;
using EMS.Core.Response;
using EMS.Service.UnitOfWorks;
using MediatR;

namespace EMS.Core.Features.Courses.Query.Handler
{
    public class CourseQueryHandler
        : ResultHandler,
        IRequestHandler<GetCourseInstructorsQuery, Result<ICollection<InstractorModel>>> ,
        IRequestHandler<GetAllCoursesQuery, Result<ICollection<CourseModel>>> ,
        IRequestHandler<GetCourseByIdQuery, Result<CourseModel>> ,
        IRequestHandler<GetCourseStudentsQuery, Result<ICollection<StudentModel>>>
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _service;

        public CourseQueryHandler(IMapper mapper,IUnitOfWork service)
        {
            this._mapper = mapper;
            this._service = service;
        }

        public async Task<Result<ICollection<CourseModel>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _service.Courses.GetAll();
            if (courses.Count() == 0)
                return NotFound<ICollection<CourseModel>>(_message: "Course List Is Empty");

            var coursesMapping = _mapper.Map<List<CourseModel>>(courses);
            return Success<ICollection<CourseModel>>
                (coursesMapping, _meta: $"Count Of Courses = {coursesMapping.Count()}");
        }

        public async Task<Result<CourseModel>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var courses = await _service.Courses.GetOne(request.Id);
            if (courses == null)
                return NotFound<CourseModel>(_message: "Course Not Found");

            var courseMapping = _mapper.Map<CourseModel>(courses);
            return Success(courseMapping);
        }

        public async Task<Result<ICollection<InstractorModel>>> Handle
            (GetCourseInstructorsQuery request, CancellationToken cancellationToken)
        {
            var courses = await _service.Courses.GetCourseInstructor(request.Id);
            if (courses.Count() == 0)
                return NotFound<ICollection<InstractorModel>>(_message:"Course Not Has Any Instructrs");

            var courseMapping = _mapper.Map<List<InstractorModel>>(courses);
            return Success<ICollection<InstractorModel>>
                (courseMapping,_meta:$"Count Of Instructors That Tech this Course = {courseMapping.Count()}");
        }

        public async Task<Result<ICollection<StudentModel>>> Handle
            (GetCourseStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _service.Courses.GetCourseStudents(request.Id);
            if (students.Count()==0)
                return NotFound<ICollection<StudentModel>>(_message: "Course Not Has Any Students");

            var studentsMapping = _mapper.Map<List<StudentModel>>(students);
            return Success<ICollection<StudentModel>>
                (studentsMapping,_meta:$"Count Of Student That Take this Course = {studentsMapping.Count()}");
        }

       
    }
}
