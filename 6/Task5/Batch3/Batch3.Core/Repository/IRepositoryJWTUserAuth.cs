using Batch3.Core.Data.DTO;
using Batch3.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batch3.Core.Repository
{
    public interface IRepositoryJWTUserAuth
    {
        public User GetUser(User model);

        public DetailsTraineeUserDTO GetTraineeUserById(int Id);
        public DetailsTeacherUserDTO GetTeacherUserById(int Id);
    }
}
