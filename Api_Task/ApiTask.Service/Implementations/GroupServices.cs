using ApiTask.core.Entities;
using ApiTask.core.Repositories;
using ApiTask.Service.Dtos.Common;
using ApiTask.Service.Dtos.GroupDtos;
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
    public class GroupServices : IGroupServices
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;


        public GroupServices( IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }


        public CreatResultDto Create(GroupCreatDto dto)
        {
            if (_groupRepository.isExists(x=>x.GroupNo == dto.GroupNo))
            {

                throw new RestExceptions(System.Net.HttpStatusCode.BadRequest, "GroupNo", "GroupNo already taken");
            }
            var entity = _mapper.Map<Group>(dto);

            _groupRepository.Add(entity);
            _groupRepository.Commit();
            return new CreatResultDto { Id = entity.Id };

        }

        public void Delete(int id)
        {

            var entity = _groupRepository.Get(x => x.Id == id);

            if (entity == null)
            {
                throw new RestExceptions(System.Net.HttpStatusCode.NotFound, $"Group not found by id : {id}");
            }
            _groupRepository.Delete(entity);
            _groupRepository.Commit();
        }

        public List<GroupGetAllDto> GetAll()
        {
            var entities = _groupRepository.GetQueryable(x=>true).ToList();
            return _mapper.Map<List<GroupGetAllDto>>(entities);
        }

        public GroupGetDto GetById(int id)
        {

            var entity = _groupRepository.Get(x => x.Id == id, "Students");
            if (entity == null)
            {
                throw new RestExceptions(System.Net.HttpStatusCode.NotFound, $"Group not found by id : {id}");

               
            }
            var dto = _mapper.Map<GroupGetDto>(entity);
            return dto;

        }

        public void Update(int id, GroupEditDto dto)
        {
            var entity = _groupRepository.Get(x => x.Id == id);

            if (entity == null)
                throw new RestExceptions(System.Net.HttpStatusCode.NotFound,  $"Group not found by id {id}");

            if (entity.GroupNo != dto.GroupNo && _groupRepository.isExists(x=>x.GroupNo == dto.GroupNo))
            {
                throw new RestExceptions(System.Net.HttpStatusCode.BadRequest, "GroupNo", "GroupNo already taken")
                {
                    Code = System.Net.HttpStatusCode.NotFound,
                    Errors = new List<RestExceptionsErrorItem> { new RestExceptionsErrorItem("GroupNo","GroupNo already taken")}

                };


            }
               entity.GroupNo = dto.GroupNo;
            _groupRepository.Commit();


        }
    }
}
