using AutoMapper;
using EMS.Core.Features.Departments.Query.Model;
using EMS.Core.Features.Departments.Query.Request;
using EMS.Core.Response;
using EMS.Infrastructure.Domain.DTOs.Courses;
using EMS.Infrastructure.Domain.DTOs.Department;
using EMS.Infrastructure.Domain.DTOs.Instractors;
using EMS.Service.UnitOfWorks;
using MediatR;

namespace EMS.Core.Features.Departments.Query.Handler
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, Response<DepartmentDTO>> ,
        IRequestHandler<GetAllDepartmentQuery, Response<List<DepartmentDTO>>> ,
         IRequestHandler<GetDepartmentInstractors, Response<List<InstractorModel>>>,
         IRequestHandler<GetDepartmentStudents, Response<List<StudentModel>>>,
         IRequestHandler<GetDepartmentCourses, Response<List<CourseModel>>>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork  _service;

        public DepartmentQueryHandler(IMapper mapper, IUnitOfWork  service)
        {
            this._mapper = mapper;
            this._service = service;
        }

        public async Task<Response<DepartmentDTO>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _service.Departments.GetOne(request.Id);
            var deptMapped = _mapper.Map<DepartmentDTO>(department);
            return deptMapped != null ? Success<DepartmentDTO>(deptMapped) : BadRequest<DepartmentDTO>(_message:"Department Not Found"); 
        }

        public async Task<Response<List<DepartmentDTO>>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var departments = await _service.Departments.GetAll();
            var deptMapped = _mapper.Map<List<DepartmentDTO>>(departments);
            return departments.Count() != 0 ? Success<List<DepartmentDTO>>(deptMapped) : BadRequest<List<DepartmentDTO>>(_message:"Department List Is Empty");
        }

        public async Task<Response<List<InstractorModel>>> Handle(GetDepartmentInstractors request, CancellationToken cancellationToken)
        {
            var instractors = await _service.Departments.GetDepartmentInstructor(request.dept_Id);
            var instractorMapped =  _mapper.Map<List<InstractorModel>>(instractors);

            return instractorMapped.Any() ? Success(instractorMapped, _meta: instractorMapped.Count()) :
                   BadRequest<List<InstractorModel>>(_message: "Department Not Has Any Instractors");
        }

        public async Task<Response<List<StudentModel>>> Handle(GetDepartmentStudents request, CancellationToken cancellationToken)
        {
            var students = await _service.Departments.GetDepartmentStudents(request.dept_Id);
            var studentsMapped = _mapper.Map<List<StudentModel>>(students);

            return studentsMapped.Any() ? Success(studentsMapped, _meta: studentsMapped.Count()) :
                  BadRequest<List<StudentModel>>(_message: "Department Not Has Any Student");
        }

        public async Task<Response<List<CourseModel>>> Handle(GetDepartmentCourses request, CancellationToken cancellationToken)
        {
            var courses = await _service.Departments.GetDepartmentCourses(request.dept_Id);
            var coursesMapped = _mapper.Map<List<CourseModel>>(courses);

            return coursesMapped.Any() ? Success(coursesMapped, _meta: coursesMapped.Count()) :
                  BadRequest<List<CourseModel>>(_message: "Department Not Has Any Student");
        }
    }
}
