using AutoMapper;
using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Features.Security.Models;
using BillWare.Application.Features.Security.Query;
using MediatR;

namespace BillWare.Application.Features.Security.Handler
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

            var usersPagedMapped = _mapper.Map<PaginationResult<UserResponse>>(usersPaged);

            return usersPagedMapped;
        }
    }
}
