using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductChangeController : ControllerBase
    {
        private readonly IProductRepository _context;
        public ProductChangeController(IProductRepository context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _context.GetAllTodosAsync();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(ProductChange company)
        {

            var result = await _context.SaveAsync(company);
            return Ok(result);
        }

        [HttpPut]
        [Route("update-data")]
        public async Task<IActionResult> UpdateTodoStatusAsync(ProductChange updateTodo)
        {
            var result = await _context.UpdateTodoStatusAsync(updateTodo);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _context.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetTodoItemByIdAsync(int id)
        {
            var result = await _context.GetTodoByIdAsync(id);
            return Ok(result);
        }


        [HttpGet]
        [Route("get-todos-and-count")]
        public async Task<IActionResult> GetTodosAndCountAsync()
        {
            var result = await _context.GetTodosAndCountAsync();
            return Ok(result);
        }
    }   
}
