using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetById
{
    public class GetBrandByIdQuery : IRequest<GetBrandByIdDto>
    {
        public int Id { get; set; }
        public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, GetBrandByIdDto>
        {
            private readonly IBrandRepository _branRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public GetBrandByIdQueryHandler(IBrandRepository branRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _branRepository = branRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<GetBrandByIdDto> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandShouldExistWhenRequested(request.Id);
                var getBrand = await _branRepository.GetAsync(x => x.Id == request.Id);
                var getBrandMapper = _mapper.Map<GetBrandByIdDto>(getBrand);
                return getBrandMapper;
            }
        }
    }
}
