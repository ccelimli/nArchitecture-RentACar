using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand:IRequest<CreatedBrandResponse>, ITransactionalRequest, ICacheRemoverRequest
{
    public string Name{ get; set; }
}
