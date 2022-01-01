using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductChange>> GetAllTodosAsync();
        Task<int> SaveAsync(ProductChange company);
        Task<int> UpdateTodoStatusAsync(ProductChange updateTodo);
        Task<int> DeleteAsync(int id);
        Task<ProductChange> GetTodoByIdAsync(int id);

        Task<TodosContainer> GetTodosAndCountAsync();
    }
}
