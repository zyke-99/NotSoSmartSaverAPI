using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.Interfaces
{
    interface IUserVerification
    {
        bool isUserVerified(Users user);
    }
}
