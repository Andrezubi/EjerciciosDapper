using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;

using SocialMedia.Core.Enum;





namespace SocialMedia.Infrastructure.Repositories
{
    public class EjerciciosDapperRepository : IEjerciciosDapperRepository
    {
        private readonly DapperContext _dapper;
        public EjerciciosDapperRepository( DapperContext dapper)
        {
            _dapper = dapper;   
            
        }
        public async Task<IEnumerable<SimpleUser>> PrimerEjerciciosDapperAsync()
        {
            try
            {
                var sql = _dapper.Provider switch
                {
                    
                    DatabaseProvider.SqlServer => @"
                    SELECT 
                        u.FirstName,
                        u.LastName,
                        u.Email
                    FROM [dbo].[User] as u
                    LEFT JOIN [dbo].[Comment] c ON u.Id = c.UserId
                    WHERE c.Id IS NULL;
            ",

                    DatabaseProvider.MySql => @";",

                    _ => throw new NotSupportedException("Provider no soportado")
                };
                return await _dapper.QueryAsync<SimpleUser>(sql);
            }
            catch (Exception err)
            {
                throw new Exception($"Error en GetAutoUserDapperAsync: {err.Message}");
            }
        }

        public async Task<IEnumerable<SimplePost>> TercerEjerciciosDapperAsync()
        {
            try
            {
                var sql = _dapper.Provider switch
                {

                    DatabaseProvider.SqlServer => @"
                    SELECT 
    p.Id as PostId,
    p.Description AS PostDescription,
    p.Date as PostDate
FROM [dbo].[Post] p
LEFT JOIN dbo.Comment c ON p.Id = c.PostId
LEFT JOIN [dbo].[User] u ON c.UserId = u.Id AND u.IsActive = 1
WHERE u.Id IS NULL;
            ",

                    DatabaseProvider.MySql => @";",

                    _ => throw new NotSupportedException("Provider no soportado")
                };
                return await _dapper.QueryAsync<SimplePost>(sql);
            }
            catch (Exception err)
            {
                throw new Exception($"Error en GetAutoUserDapperAsync: {err.Message}");
            }
        }



        public async Task<IEnumerable<UserAndCantUsers>> CuartoEjerciciosDapperAsync()
        {
            try
            {
                var sql = _dapper.Provider switch
                {

                    DatabaseProvider.SqlServer => @"
                    SELECT 
    u.FirstName,
    u.LastName,
    COUNT(DISTINCT p.UserId) AS CantUsuariosDiferentes
FROM dbo.Comment c
INNER JOIN dbo.Post p ON c.PostId = p.Id
INNER JOIN [dbo].[User] u ON c.UserId = u.Id
GROUP BY u.Id, u.FirstName, u.LastName
HAVING COUNT(DISTINCT p.UserId) >= 3;
            ",

                    DatabaseProvider.MySql => @";",

                    _ => throw new NotSupportedException("Provider no soportado")
                };
                return await _dapper.QueryAsync<UserAndCantUsers>(sql);
            }
            catch (Exception err)
            {
                throw new Exception($"Error en GetAutoUserDapperAsync: {err.Message}");
            }
        }


        public async Task<IEnumerable<PostAndMinorComments>> QuintoEjerciciosDapperAsync()
        {
            try
            {
                var sql = _dapper.Provider switch
                {

                    DatabaseProvider.SqlServer => @"
                    SELECT 
    p.Id AS IdPost,
    p.Description AS PostDescription,
    COUNT(c.Id) AS CantidadComentariosMenores
FROM [dbo].[Post] AS p
INNER JOIN [dbo].[Comment] AS c
    ON p.Id = c.PostId
INNER JOIN [dbo].[User] AS u
    ON c.UserId = u.Id
WHERE DATEDIFF(YEAR, u.DateOfBirth, GETDATE()) < 18
GROUP BY p.Id, p.Description;
            ",

                    DatabaseProvider.MySql => @";",

                    _ => throw new NotSupportedException("Provider no soportado")
                };
                return await _dapper.QueryAsync<PostAndMinorComments>(sql);
            }
            catch (Exception err)
            {
                throw new Exception($"Error en GetAutoUserDapperAsync: {err.Message}");
            }
        }


        public async Task<IEnumerable<Weekdays>> SextoEjerciciosDapperAsync()
        {
            try
            {
                var sql = _dapper.Provider switch
                {

                    DatabaseProvider.SqlServer => @"
                    SELECT 
    DATENAME(WEEKDAY, c.Date) AS DiaSemana,
    COUNT(c.Id) AS TotalComentarios,
    COUNT(DISTINCT c.UserId) AS UsuariosUnicos
FROM [dbo].[Comment] AS c
GROUP BY DATENAME(WEEKDAY, c.Date)
ORDER BY DATEPART(WEEKDAY, MIN(c.Date));
            ",

                    DatabaseProvider.MySql => @";",

                    _ => throw new NotSupportedException("Provider no soportado")
                };
                return await _dapper.QueryAsync<Weekdays>(sql);
            }
            catch (Exception err)
            {
                throw new Exception($"Error en GetAutoUserDapperAsync: {err.Message}");
            }
        }






    }
}
