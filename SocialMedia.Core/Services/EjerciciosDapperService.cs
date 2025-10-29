using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class EjerciciosDapperService : IEjerciciosDapperService
    {
        private readonly IEjerciciosDapperRepository _repository;
        public EjerciciosDapperService(IEjerciciosDapperRepository repository)
        {
            _repository = repository;
        }




        public async Task<IEnumerable<UserAndCantUsers>> CuartoEjerciciosDapperAsync()
        {
            return await _repository.CuartoEjerciciosDapperAsync();
            
        }

        public async Task<IEnumerable<SimpleUser>> PrimerEjerciciosDapperAsync()
        {
            return await _repository.PrimerEjerciciosDapperAsync();
        }

        public async Task<IEnumerable<PostAndMinorComments>>QuintoEjerciciosDapperAsync()
        {
            return await _repository.QuintoEjerciciosDapperAsync();
        }

        public async Task<IEnumerable<Weekdays>> SextoEjerciciosDapperAsync()
        {
            return await _repository.SextoEjerciciosDapperAsync();
        }

        public async Task<IEnumerable<SimplePost>>TercerEjerciciosDapperAsync()
        {
            return await _repository.TercerEjerciciosDapperAsync();
        }
    }
}
