using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand:IRequest<CreatedBrandResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string Name{ get; set; }

    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey =>"GetBrands";
}
