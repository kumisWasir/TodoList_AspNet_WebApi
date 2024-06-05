using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;

using ToDoList.DTO;
using ToDoList.Interface;
using ToDoList.Model;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController  : ControllerBase
    {
        private ICrud _crudCategory;

        public CategoryController(ICrud crudCategory ){
            _crudCategory = crudCategory;
        }
        [HttpGet]
        public IActionResult GetAll (){
            var result = _crudCategory.GetAll();
           
            return Ok(result.Result);
        }
        
        [HttpGet("id")]
        public IActionResult Get(int id){
            try{
            var result = _crudCategory.GetById(id).Result;
            if (result == null){
                return NotFound();
            }
            return Ok(result);}
            catch{
                return StatusCode(500);
            }
        }
        [HttpGet("CategoryName")]
        public async Task<IActionResult> GetTugasByCategory (string categoryname){
            try{
            var result = await _crudCategory.GetTugasByCategory(categoryname);
            if (result == null){
                return NotFound();
            }
            return Ok(result);}
            catch{
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create_Category(CategoryDto categoryDto){
            try {
                await _crudCategory.Create(categoryDto);
                return Ok();
            }catch (ArgumentException e){
                return NotFound(e);
            }catch{
                return StatusCode(500);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit_Category(int id, CategoryDto categoryDto){
            try{
            await _crudCategory.Update(id, categoryDto);
            return Ok();
            }catch (ArgumentNullException){
                return NotFound();
            }catch{
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete_Category(int Id){
            try{
            await _crudCategory.Delete(Id);
            
            return Ok();}
           catch (ArgumentNullException){
                return NotFound();
            }catch{
                return StatusCode(500);
            }
        }

    }

}