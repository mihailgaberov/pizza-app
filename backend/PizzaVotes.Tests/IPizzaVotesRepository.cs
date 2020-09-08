using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend
{
    public interface IPizzaVotesRepository
    {
        Task<PizzaVotes> GetByIdAsync(string id);
        Task<List<PizzaVotes>> ListAsync();
        Task AddAsync(PizzaVotes vote);
        Task UpdateAsync(PizzaVotes vote);
    }
}