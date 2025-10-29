using SocialMedia.Core.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IEjerciciosDapperService
    {
        Task<IEnumerable<SimpleUser>> PrimerEjerciciosDapperAsync();
        Task<IEnumerable<SimplePost>> TercerEjerciciosDapperAsync();
        Task<IEnumerable<UserAndCantUsers>> CuartoEjerciciosDapperAsync();
        Task<IEnumerable<PostAndMinorComments>> QuintoEjerciciosDapperAsync();
        Task<IEnumerable<Weekdays>> SextoEjerciciosDapperAsync();
    }
}
