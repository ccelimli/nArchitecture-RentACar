using Application.Features.Brands.Commands.Update;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommand:IRequest<DeletedBrandResponse> , ICacheRemoverRequest
{
    public Guid Id{ get; set; }
    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetBrands";

    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
    {
        IMapper _mapper;
        IBrandRepository _brandRepository;

        public DeleteBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await _brandRepository.GetAsync(predicate: brand => brand.Id == request.Id,withDeleted:true, cancellationToken: cancellationToken);
            await _brandRepository.DeleteAsync(brand);
            DeletedBrandResponse response = _mapper.Map<DeletedBrandResponse>(brand);
            return response;
        }
    }
}
