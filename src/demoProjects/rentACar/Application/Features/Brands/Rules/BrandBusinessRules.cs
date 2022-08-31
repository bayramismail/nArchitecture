using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Brand> result = await _brandRepository.GetListAsync(b => b.Name.ToLower() == name.ToLower());
            if (result.Items.Any()) throw new BusinessException("Brand name exists.");
        }
        /// <summary>
        /// Marka İstendiğinde Var Olmalı
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public async Task BrandShouldExistWhenRequested(int id)
        {
            Brand result = await _brandRepository.GetAsync(b => b.Id == id);
            //Request brand dos not  exists=Talep markası mevcut değil.
            if (result == null) throw new BusinessException("Request brand dos not  exists.");
        }
    }
}
