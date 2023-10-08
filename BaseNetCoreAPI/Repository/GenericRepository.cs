using AutoMapper;
using BaseNetCoreAPI.Contracts;
using BaseNetCoreAPI.Data;

namespace BaseNetCoreAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;

        public GenericRepository(HotelListingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _configurationProvider = mapper.ConfigurationProvider;
        }
        public async Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
            //await _context.CreateCountry(entity);
            //return entity;
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
            //var result = _context.GetCounty(id);
            //return result;
        }

        public async Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
