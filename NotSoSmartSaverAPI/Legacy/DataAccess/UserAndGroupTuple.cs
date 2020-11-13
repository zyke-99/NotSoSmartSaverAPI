using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoSmartSaverWFA.DataAccess
{
    struct UserAndGroupTuple
    {
        public UserAndGroupTuple (string groupId, string userId)
        {
            this.groupId = groupId;
            this.userId = userId;
        }
        public string groupId;
        public string userId;
    }
}
