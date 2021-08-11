using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController:ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private IMapper _mapper;

        //private readonly MockCommanderRepo _repository= new MockCommanderRepo();
        public CommandsController(ICommanderRepo repository,IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
            
        }
        //GET api/commands
        [Authorize]
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems=_repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));

        }

        //[Route("api/commands/{id}")]
        [Authorize]
        [HttpGet("{id}",Name ="GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem=_repository.GetCommandByID(id);
            if(commandItem!=null)
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            else
                return NotFound();

        }

        //POST api/commands
        [Authorize]
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel=_mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();
            var commandReadDto= _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById),new {Id=commandReadDto.Id},commandCreateDto);
            //return Ok(CommandReadDto);
        }

        //PUT api/commands/{id}
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id,CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo=_repository.GetCommandByID(id);
            if(commandModelFromRepo==null) return NotFound();

            _mapper.Map(commandUpdateDto, commandModelFromRepo);
            
            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [Authorize]
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int Id,JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
             var commandModelFromRepo=_repository.GetCommandByID(Id);
            if(commandModelFromRepo==null) return NotFound();

            var commandToPatch=_mapper.Map<CommandUpdateDto>(commandModelFromRepo);

            patchDoc.ApplyTo(commandToPatch,ModelState);

            if(!TryValidateModel(commandToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(commandToPatch,commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo =_repository.GetCommandByID(id);
            if(commandModelFromRepo==null) return NotFound();

            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}