using Core.Entities.Concrete;
using Core.Utilities.Security.Encryptiom;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        public AccessToken CreateToken(User user, List<OperationClaim> operationsClaims)
        {
            return null;  
        }
    }
}
