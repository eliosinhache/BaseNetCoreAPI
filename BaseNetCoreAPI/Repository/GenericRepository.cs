using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseNetCoreAPI.Contracts;
using BaseNetCoreAPI.Data;
using BaseNetCoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseNetCoreAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;
        private HotelListingDbContext context;

        public GenericRepository(HotelListingDbContext context)
        {
            this.context = context;
        }

        public GenericRepository(HotelListingDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<PageResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters)
        {
            var totalSize = await _context.Set<T>().CountAsync();
            var items = await _context.Set<T>()
                .Skip(queryParameters.StartIndex)
                .Take(queryParameters.PageSize)
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return new PageResult<TResult>
            {
                Items = items,
                TotalCount = totalSize,
                PageNumber = queryParameters.PageNumber,
                RecordNumber = queryParameters.PageSize
            };
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
                return null;
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity); 
            await _context.SaveChangesAsync();
        }
    }
}
