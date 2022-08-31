using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetList
{
    public class GetListBrandQuery: IRequest<GetBrandListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, GetBrandListModel>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<GetBrandListModel> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
               IPaginate<Brand> brands=await _brandRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
               GetBrandListModel mappedGetBrandListModel=_mapper.Map<GetBrandListModel>(brands);
                return mappedGetBrandListModel;
            }
        }
    }
}
