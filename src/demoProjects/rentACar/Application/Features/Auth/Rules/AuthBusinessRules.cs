using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        ///  E-posta Tekrarlanamaz
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException">This email is registered in the system</exception>
        public async Task EmailCannotBeRepeated(string email)
        {
           User? user =await _userRepository.GetAsync(x=>x.Email.ToLower()==email.ToLower());
                                                                //Bu e-posta sistemde kayıtlıdır.
            if (user != null)  throw new BusinessException("This email is registered in the system"); 
        }
    }
}
