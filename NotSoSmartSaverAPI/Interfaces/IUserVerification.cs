using NotSoSmartSaverAPI.DTO.UserDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.Interfaces
{
    public interface IUserVerification
    {
        public Task<bool> IsUserVerifiedAsync(UserLoginDTO user);
    }
}
