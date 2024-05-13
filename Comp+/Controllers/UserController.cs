using System.Linq.Expressions;
using System.Text.RegularExpressions;
using COMP_.Entities;
using COMP_.Entities.Enum;
using COMP_.UOW.Interface;
using Microsoft.AspNetCore.Mvc;

namespace COMP_.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var result = await _unitOfWork.UserRepository.GetAllAsync();
            if (result == null) { return NotFound("No content found"); }
            return Ok(result);
        }
        [HttpGet("Composters")]
        public async Task<ActionResult<IEnumerable<User>>> GetCompostersAsync()
        {
            var result = await _unitOfWork.UserRepository.GetCompostersAsync();
            if (result == null) { return NotFound("No Composters found"); }
            return Ok(result);

        }
        [HttpGet("WannaCompost")]
        public async Task<ActionResult<IEnumerable<User>>> GetWannaCompost()
        {
            var result = await _unitOfWork.UserRepository.GetWannaCompostAsync();
            if (result == null) { return NotFound("No users wanna compost has been found"); }
            return Ok(result);
        }
        [HttpGet("zip/{zip}")]
        public async Task<ActionResult<User>> GetByZip(string zip)
        {
           
            if(!(Regex.IsMatch(zip, "^[0-9]{5}-[0-9]{3}"))) { return BadRequest("Invalid ZIP Code format"); }
          var matchedUsers=  await _unitOfWork.UserRepository.GetByZIP(zip);
            if (matchedUsers == null) { return NotFound("No matched users found"); }
            return Ok(matchedUsers);
           
        }
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user is null) { return BadRequest("Impossible to register"); }
            var test = await _unitOfWork.UserRepository.GetByExpressionAsync(x => x.CPF == user.CPF);
            if (test != null) { return BadRequest("This user is already register in our system"); }
            _unitOfWork.UserRepository.Create(user);
            await _unitOfWork.CommitAsync();
            return Ok(user);

        }
        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<User>> Put(User user, int id)
        {
            if (id != user.Id) { return BadRequest("It seems you sent two different Ids, on in the body request and one in the URI"); }
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.CommitAsync();
            return Ok(user);
        }
        [HttpDelete]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var ToBeDelete = await _unitOfWork.UserRepository.GetByExpressionAsync(x => id == x.Id);
            if (ToBeDelete == null) { return BadRequest("The Id provided is not in our database"); }
            _unitOfWork.UserRepository.Delete(ToBeDelete);
            await _unitOfWork.CommitAsync();
            return Ok(ToBeDelete);
        }


    }
}
