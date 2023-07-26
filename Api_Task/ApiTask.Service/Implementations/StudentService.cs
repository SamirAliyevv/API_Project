using ApiTask.core.Entities;
using ApiTask.core.Repositories;
using ApiTask.Service.Dtos.Common;
using ApiTask.Service.Dtos.StudentDtos;
using ApiTask.Service.Exceptions;
using ApiTask.Service.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTask.Service.Implementations
{
    public class StudentService : IStudentServices
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;


        public StudentService( IGroupRepository groupRepository,IStudentRepository  studentRepository,IMapper mapper)
        {
            _groupRepository = groupRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;

        }


        public CreatResultDto Create(StudentCreatDto dto)
        {

            if (!_groupRepository.isExists(x => x.Id == dto.GroupId))
                throw new RestExceptions(System.Net.HttpStatusCode.BadRequest, "GroupId", $"Group not found by id {dto.GroupId}");

            if (_studentRepository.isExists(x => x.FullName == dto.FullName))
                throw new RestExceptions(System.Net.HttpStatusCode.BadRequest, "Name", $"FullName already taken  {dto.FullName}");
            var entity = _mapper.Map<Student>(dto);

            _studentRepository.Add(entity);
            _studentRepository.Commit();

            return new CreatResultDto { Id = entity.Id };

        }

        public void Delete(int id)
        {
            var entity = _studentRepository.Get(x => x.Id == id);
            if (entity == null)
            {
                throw new RestExceptions(System.Net.HttpStatusCode.NotFound, $"Student not found by id {id}");
            }
                

            _studentRepository.Delete(entity);
            _studentRepository.Commit();

        }

        public void Edit(int id, StudentEditDto dto)
        {

            var entity = _studentRepository.Get(x => x.Id == id);

            if (entity == null)
                throw new RestExceptions(System.Net.HttpStatusCode.NotFound, $"Student not found by id : {id}");
            if (entity.GroupId != dto.GroupId && _groupRepository.isExists(x => x.Id == dto.GroupId))
                throw new RestExceptions(System.Net.HttpStatusCode.BadRequest, "GroupId", $"GroupId not found ");

            if (entity.FullName != dto.FullName && !_studentRepository.isExists(x => x.FullName == dto.FullName))
                throw new RestExceptions(System.Net.HttpStatusCode.BadRequest,"FullName",$"FullName already taken");

            entity.FullName = dto.FullName; 
            entity.Point = dto.Point;
            entity.GroupId = dto.GroupId;

            _studentRepository.Commit();


        }

        public List<StudentGetAllDto> GetAll()
        {
            var entities = _studentRepository.GetQueryable(x=>true,"Group").ToList();
            return _mapper.Map<List<StudentGetAllDto>>(entities);
        }

        public StudentGetDto GetById(int id)
        {
            var entity = _studentRepository.Get(x => x.Id == id, "Group");
            if (entity == null)
                throw new RestExceptions(System.Net.HttpStatusCode.NotFound,$"Student not found by id : {id}");
            var dto = _mapper.Map<StudentGetDto>(entity);
            return dto;

        }
    }
}
