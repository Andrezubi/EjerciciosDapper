using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.CustomEntities
{
    public class UserAndCantUsers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CantUsuariosDiferentes   { get; set; }
    }
}
