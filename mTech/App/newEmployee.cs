using MediatR;
using FluentValidation;
using mTech.Models;
using mTech.Persistence;

namespace mTech.App
{
    public class NewEmployee
    {

        public class Execute : IRequest
        {
            public string? Name { get; set; }

            public string? LastName { get; set; }

            public string? RFC { get; set; }

            public DateTime? BornDate { get; set; }

            public string? Status { get; set; }

        } 


    public class ExecuteValidation : AbstractValidator<Execute>
        {

            public ExecuteValidation() 
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
                RuleFor(x => x.RFC).NotEmpty();
                RuleFor(x => x.BornDate).NotEmpty();
                RuleFor(x => x.Status).NotEmpty();

            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly EmployeePersistence _employeePersistence;

            public Handler(EmployeePersistence employeePersistence)
            {

                _employeePersistence = employeePersistence;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {

                var employee = new Employee {

                    Name = request.Name,
                    LastName = request.LastName,
                    RFC = request.RFC,
                    BornDate = request.BornDate,
                    Status = request.Status
                };

                _employeePersistence.Employee.Add(employee);


                var value = await _employeePersistence.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("We can't store a new employee");


            }

        }
    }
}
