using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly DapperContext _context;
        public ProductRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ProductChange>> GetAllTodosAsync()
        {
            var query = "SELECT * FROM ProductChanges";

            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<ProductChange>(query);
                return companies.ToList();
            }
        }

		public async Task<int> SaveAsync(ProductChange company)
		{
			

			using (var conn = _context.CreateConnection())
			{

                var query = "INSERT INTO ProductChanges (product_no, target, mp,speed,ent_dtm) VALUES (@product_no, @target, @mp,@speed,@ent_dtm)";

                var parameters = new DynamicParameters();
                parameters.Add("product_no", company.product_no, DbType.String);
                parameters.Add("target", company.target, DbType.Int32);
                parameters.Add("mp", company.mp, DbType.Int32);
                parameters.Add("speed", company.speed, DbType.DateTime);
                parameters.Add("ent_dtm", company.ent_dtm, DbType.DateTime);

                var result = await conn.ExecuteAsync(sql: query, param: company);
                return result;

            }
		}

        public async Task<int> UpdateTodoStatusAsync(ProductChange updateTodo)
        {
            using (var conn = _context.CreateConnection())
            {
                string command = @" UPDATE ProductChanges SET product_no = @product_no WHERE Id = @Id";

                var result = await conn.ExecuteAsync(sql: command, param: updateTodo);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = _context.CreateConnection())
            {
                string command = @"DELETE FROM ProductChanges WHERE Id = @id";
                var result = await conn.ExecuteAsync(sql: command, param: new { id });
                return result;
            }
        }

        public async Task<ProductChange> GetTodoByIdAsync(int id)
        {
            using (var conn = _context.CreateConnection())
            {
                string query = "SELECT * from ProductChanges Todo WHERE Id = @id";
                ProductChange todo = await conn.QueryFirstOrDefaultAsync<ProductChange>(sql: query, param: new { id });
                return todo;
            }
        }

        public async Task<TodosContainer> GetTodosAndCountAsync()
        {
            using (var conn = _context.CreateConnection())
            {
                string query = @"
				SELECT COUNT(*) FROM ProductChanges
 
	
				SELECT * FROM ProductChanges";

                var reader = await conn.QueryMultipleAsync(sql: query);

                return new TodosContainer
                {
                    Count = (await reader.ReadAsync<int>()).FirstOrDefault(),
                    Product = (await reader.ReadAsync<ProductChange>()).ToList()
                };
            }
        }
    }
}
