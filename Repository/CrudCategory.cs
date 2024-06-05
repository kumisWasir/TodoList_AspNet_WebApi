using ToDoList.DataContext;
using ToDoList.Model;
using ToDoList.DTO;
using ToDoList.Interface;

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
namespace ToDoList.Repository
{
    public class CrudCategory : ICrud
    {
        private readonly Connection _context;

        public CrudCategory(Connection conetxt){
            _context = conetxt;
        }

        public async Task<int> Create (CategoryDto categoryDTO){
            
            _context.category.Add(categoryDTO.Covert_To_Model());
            return await _context.SaveChangesAsync();
        }

        public async Task<Category> GetById (int id){
            var result = await _context.category.FirstOrDefaultAsync<Category>( x => x.Id == id);
            if (result == null){
                throw new ArgumentNullException(String.Format("Object Null : {0}" , result));
            }
            return result;
        }

        public async Task<List<Category>> GetAll(){
            return await _context.category.Select(c => c).ToListAsync();
        }


        public async Task Update (int id, CategoryDto categoryDto){
            var result = GetById(id);
            if (result.Result == null){
                throw new ArgumentNullException(String.Format("Object Null : {0}" , result));
            }
            result.Result.Name = categoryDto.Name;
            await _context.SaveChangesAsync();
        }

        public async Task Delete (int id){
            var result = GetById(id);
            if (result.Result == null){
                throw new ArgumentNullException(String.Format("Object Null : {0}" , result));
            }
            _context.category.Remove(result.Result);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Tugas>> GetTugasByCategory (string categoryname){
            var category_result = _context.category.FirstOrDefaultAsync(c => c.Name == categoryname);
            return await  _context.tugas.Where(t => t.Category_ID == category_result.Result.Id).ToListAsync();
        }
    }
}