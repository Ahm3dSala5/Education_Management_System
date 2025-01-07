using AutoMapper;
using EMS.Core.Features.Courses.Command.Request;
using EMS.Core.Response;
using EMS.Infrastructure.Domain.Entities;
using EMS.Service.UnitOfWorks;
using MediatR;

namespace EMS.Core.Features.Courses.Command.Handler
{

    public class CourseCommandHandler
        : ResultHandler,
        IRequestHandler<CreateCourseCommand, Result<string>> ,
        IRequestHandler<UpdateCourseCommand, Result<string>> ,
        IRequestHandler<DeleteCourseCommand, Result<string>> 
    {
        private IMapper _mapper;
        private IUnitOfWork _service;
        public CourseCommandHandler(IUnitOfWork service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<Result<string>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request);
            if (course == null)
                return BadRequest<string>(_message:"Invalid Course Data");

            var creationResult = await _service.Courses.Create(course);

            return creationResult == "Created" ?
                Create(creationResult) :
                BadRequest<string>(creationResult);
        }

        public async Task<Result<string>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var deletionResult = await _service.Courses.Delete(request.Id);
            if (deletionResult == "Not Found")
                return NotFound<string>(_message:"Course Not Found");

            return deletionResult == "Created" ?
                Create(deletionResult) :
                BadRequest<string>(deletionResult);
        }

        public async Task<Result<string>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request);
            if (course == null)
                return BadRequest<string>(_message: "Invalid Course Data");

            var updationResult = await _service.Courses.Update(course,request.Id);
            if (updationResult == "Not Found")
                return NotFound<string>(_message: "Course Not Found Or Invalid Id");

            return updationResult == "Updated" ?
                Create(updationResult) :
                BadRequest<string>(updationResult);
        }
    }


}
