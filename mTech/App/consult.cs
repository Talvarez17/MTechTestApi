using Microsoft.EntityFrameworkCore;
using MediatR;
using AutoMapper;
using mTech.Models;
using mTech.Persistence;

namespace mTech.App

{
    public class Consult
    {
        public class Execute : IRequest<List<EmployeeInfo>> { }

        public class Handler : IRequestHandler<Execute, List<EmployeeInfo>> 
        {
            private readonly EmployeePersistence _context; 
            private readonly IMapper _mapper;

            public Handler(EmployeePersistence context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<EmployeeInfo>> Handle(Execute request, CancellationToken cancellationToken)
            {
                var employees = await _context.Employee.ToListAsync(cancellationToken);
                var employeesinfo = _mapper.Map<List<Employee>, List<EmployeeInfo>>(employees);
                return employeesinfo;
            }
        
        }
    }
}
