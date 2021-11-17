using System;
using System.Threading.Tasks;
using UserManagementApp.API.Model;
using JobPortalApp.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using JobPortalApp.Model;
using Microsoft.AspNetCore.Http;

namespace UserManagementApp.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.        /// </summary>
       
        /// <param name="candidateService">The user service.</param>
        public UsersController( IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// List of users
        /// </summary>       
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserRequest>> Get()
        {
            try
            {
                var response = await _userService.GetUsers();
                return Ok(response);
            }
            catch (Exception e)
            {
                //LOG The Exception
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// User Add
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ApiResponse>> Add(UserRequest userRequest)
        {
            try
            {
                //Validation
                if (!ModelState.IsValid)
                    return BadRequest();

                var user = new User { Name = userRequest.Name };
                if (_userService.IsUserExists(user))
                {
                    return BadRequest("User name already exist.");
                }

                //Add to DB
                await _userService.Add(user);

                //Return
                return Created("", new ApiResponse { Message = "User has been added successfully" });
            }
            catch (Exception e)
            {
                //LOG The Exception
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> Update([FromRoute] int id, UserRequest userRequest)
        {
            try
            {
                //Validation
                if (!ModelState.IsValid)
                    return BadRequest();

                if (!_userService.IsUserIdExists(id))
                {
                    return NotFound("User Id is not found.");
                }

                var user = new User { Id = id, Name = userRequest.Name };
                if (_userService.IsUserExists(user))
                {
                    return BadRequest("User name already exist.");
                }

                //Update to DB
                await _userService.Update(user);

                //Return
                return Ok(new ApiResponse { Message = "User has been updated successfully" });
            }
            catch (Exception e)
            {
                //LOG The Exception
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> Delete([FromRoute] int id)
        {
            try
            {
                //Validation
                if (!ModelState.IsValid)
                    return BadRequest();

                if (!_userService.IsUserIdExists(id))
                {
                    return NotFound("User Id is not found.");
                }
               
                //Update to DB
                await _userService.Delete(id);

                //Return
                return Ok(new ApiResponse { Message = "User has been deleted successfully" });
            }
            catch (Exception e)
            {
                //LOG The Exception
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



    }
}