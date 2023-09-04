using AutoMapper;
using BillWare.Application.Interfaces;
using BillWare.Application.Security.Models;
using BillWare.Application.Security.Query;
using MediatR;

namespace BillWare.Application.Security.Handler
{
    public class GetUsersPagedQueryHandler : IRequestHandler<GetUsersPagedQuery, PaginationResult<UserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersPagedQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<UserResponse>> Handle(GetUsersPagedQuery request, CancellationToken cancellationToken)
        {
            var usersPaged = await _userRepository.GetUsersPaged(request.PageIndex, request.PageSize);

            var usersPagedResponse = _mapper.Map<PaginationResult<UserResponse>>(usersPaged);

            return usersPagedResponse;
        }
    }
}
