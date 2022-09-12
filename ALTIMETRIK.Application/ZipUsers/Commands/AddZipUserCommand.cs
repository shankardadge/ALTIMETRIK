using ALTIMETRIK.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ALTIMETRIK.Domain.Entities;
using System;
using System.Linq;
using ALTIMETRIK.Application.Base.ViewModels;

namespace ALTIMETRIK.Application.ZipUsers.Commands
{
    public class AddZipUserCommand : IRequest<ResponseModel<int>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal MonthlyExpense { get; set; }
    }
    public class AddZipUserCommandHandler : IRequestHandler<AddZipUserCommand, ResponseModel<int>>
    {
        private readonly ALTIMETRIKContext _context;
        public AddZipUserCommandHandler(ALTIMETRIKContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<int>> Handle(AddZipUserCommand request, CancellationToken cancellationToken)
        {
            if (_context.ZipUser.Any(x => x.Email == request.Email))
            {
                return new ResponseModel<int>()
                {
                    IsSuccess = false,
                    Message = "Account already exist for that email",
                    Response = 0,
                    ResponseCode = 409
                };
            }

            ZipUser zipUser = new ZipUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                JobTitle = request.JobTitle,
                Phone = request.Phone,
                MonthlySalary = request.MonthlySalary,
                MonthlyExpense = request.MonthlyExpense,
                ModifiedOn = DateTime.Now
            };
            _context.ZipUser.Add(zipUser);
            var result = await _context.SaveChangesAsync();

            return new ResponseModel<int>()
            {
                IsSuccess = true,
                Message = "Account created succssfully",
                Response = result,
                ResponseCode = 201
            };
        }

    }
}

    
