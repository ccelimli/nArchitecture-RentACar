using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetList
{
    public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, GetListResponse<GetListModelListItemDto>>
    {
        IModelRepository _modelRepository;
        IMapper _mapper;

        public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListModelListItemDto>> Handle(GetListModelQuery request, CancellationToken cancellationToken)
        {
            Paginate<Model> model= await _modelRepository.GetListAsync(
                include:model=>model.Include(model=>model.Brand).Include(model => model.Fuel).Include(model => model.Transmission),
                   index: request.PageRequest.PageIndex,
                   size: request.PageRequest.PageSize
                );

            GetListResponse<GetListModelListItemDto> response = _mapper.Map<GetListResponse<GetListModelListItemDto>>(model);

            return response;
        }
    }
}
