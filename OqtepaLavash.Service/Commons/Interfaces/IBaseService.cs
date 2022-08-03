

using System.Linq.Expressions;

namespace OqtepaLavash.Service.Commons.Interfaces
{
    public interface IBaseService<TOutput, TInput>
    {
#pragma warning disable
        Task<TOutput> CreateAsync(TInput entityCreation);
        Task<TOutput> GetAsync(Int64 id);
        Task<IEnumerable<TOutput>> GetAllAsync(Tuple<Int32, Int32>? pagenation = null, Expression<Func<TOutput, Boolean>>? predicate = null);
        Task<TOutput> UpdateAsync(Int64 id, TInput entityCreation);
        Task<Boolean> DeleteAsync(Int64 id);
    }
}
