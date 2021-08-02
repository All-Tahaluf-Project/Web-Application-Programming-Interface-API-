using Batch3.Core.Data.DTO;
using Batch3.Core.Data.Models;
using Batch3.Core.Repository;
using Batch3.Core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Batch3.Infra.Service
{
    public class ServiceJWTUserAuth : IServiceJWTUserAuth
    {
        private IRepositoryJWTUserAuth _repositoryUser;
        public ServiceJWTUserAuth(IRepositoryJWTUserAuth repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public object LogIn(User model)
        {
            var User = _repositoryUser.GetUser(model);
            if(User == null) { return null; }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("Batch4OsamaAl-Daja");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
new Claim("UserId", User.Id.ToString()),
new Claim(ClaimTypes.Role, User.Role.Name)
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

        public DetailsTraineeUserDTO GetTraineeUserById(int Id)
        {
            return _repositoryUser.GetTraineeUserById(Id);
        }

        public DetailsTeacherUserDTO GetTeacherUserById(int Id)
        {
            return _repositoryUser.GetTeacherUserById(Id);
        }
    }
}
