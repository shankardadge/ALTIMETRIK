using ALTIMETRIK.Application.Base.ViewModels;
using ALTIMETRIK.Application.ZipUsers.Commands;
using ALTIMETRIK.Application.ZipUsers.Dto;
using ALTIMETRIK.Application.ZipUsers.Queries;
using ALTIMETRIK.Application.ZipUsers.ZipUserQueries;
using ALTIMETRIK.Persistence;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ALTIMETRIK.ZipUserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZipUserController : ControllerBase
    {
        private IMediator _mediator;
        public IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        private IValidator<ZipUserDto> _validator;

        private readonly ALTIMETRIKContext _context;
        public ZipUserController(ALTIMETRIKContext context, IValidator<ZipUserDto> validator)
        {
            _context = context;
            _validator = validator;
        }



        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await Mediator.Send(new GetAllZipUserQuery()
                { });
                return new ObjectResult(response)
                {
                    StatusCode = response.ResponseCode
                };
            }catch(Exception ex)
            {
                return new ObjectResult(ex)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }

        }

        [HttpGet]
        [Route("GetUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUser(long userId)
        {
            try
            {
                var response = await Mediator.Send(new GetZipUserQuery()
            {
                Id= userId
            });
            return new ObjectResult(response)
            {
                StatusCode = response.ResponseCode
            };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        [HttpPost("Add")]
        [Route("GetUserById")]
        [ProducesResponseType(201)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Add([FromBody]ZipUserDto zipUser)
        {
            try
            {
                ValidationResult result = await _validator.ValidateAsync(zipUser);
                if (!result.IsValid)
                {
                    ResponseModel<bool> validationRes = new ResponseModel<bool>()
                    {
                        IsSuccess = false,
                        Response = false,
                        Message = result.Errors[0].ErrorMessage,
                        ResponseCode = (int)HttpStatusCode.BadRequest
                    };
                    return new ObjectResult(validationRes)
                    {
                        StatusCode = validationRes.ResponseCode
                    };
                }
                var response = await Mediator.Send(new AddZipUserCommand()
                {
                    FirstName = zipUser.FirstName,
                    LastName = zipUser.LastName,
                    Email = zipUser.Email,
                    JobTitle = zipUser.JobTitle,
                    MonthlyExpense = zipUser.MonthlyExpense,
                    MonthlySalary = zipUser.MonthlySalary,
                    Phone = zipUser.Phone,
                });
                return new ObjectResult(response)
                {
                    StatusCode = response.ResponseCode
                };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }

        }
    }
}
