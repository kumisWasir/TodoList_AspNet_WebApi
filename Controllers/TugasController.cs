<<<<<<< HEAD

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;

using ToDoList.Interface;
using ToDoList.DTO;
using ToDoList.Model;
namespace ToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TugasController : ControllerBase
    {
        private ICrudTugas _tugasCrud;

        public TugasController (ICrudTugas tugas){

            _tugasCrud = tugas;
        }

        [HttpGet]
        public IActionResult GetAll (){
            var result = _tugasCrud.GetAll();
            return Ok(result.Result);
        }

        [HttpGet("id")]
        public IActionResult Get (int id){
            var result = _tugasCrud.GetById(id);
            return Ok(result.Result);
        }

        [HttpGet("category")]
        public IActionResult GetAll (int id){
            var result = _tugasCrud.Category_name(id);
            return Ok(result.Result);
        }


        [HttpPost("Change_Category/id")]
        public async Task<IActionResult> Create_Tugas(TugasDto tugasDto){
            try {
                await _tugasCrud.Create(tugasDto);
                return Ok();
            }catch (ArgumentNullException e){
                return NotFound(e);
            }catch{
                return StatusCode(500);
            }
        }

        [HttpPut("Change_Status/id")]
        public async Task<IActionResult> Change_status(int id, TugasSelesai status){
            try{
            await _tugasCrud.Change_Status(id,status);
            return Ok();
            }catch (ArgumentNullException e){
                return NotFound(e);
            }catch{
                return StatusCode(500);
            }
        }

        [HttpPut("Change_Category/id")]
        public async Task<IActionResult> Change_category (string newCategory, int id){
            try{
            await _tugasCrud.Change_Category(newCategory,id);
            return Ok();
            }catch (ArgumentNullException e){
                return NotFound(e);
            }catch{
                return StatusCode(500);
            
            }   
        }
        
        [HttpDelete("id")]
        public async Task<IActionResult> Delete_tugas(int id){
            try{
            await _tugasCrud.Delete_Tugas(id);
            return Ok();
            }catch (ArgumentNullException e){
                return NotFound(e);
            }catch{
                return StatusCode(500);
            
            }   
        }

        [HttpPut("Change_Deskripsi_tugas/id")]

        public async Task<IActionResult> Change_Deksipri_Tugas(int id , TugasDto tugasDto){
             try{
            await _tugasCrud.Edit_Deskripsi_Tugas(id, tugasDto);
            return Ok();
            }catch (ArgumentNullException e){
                return NotFound(e);
            }catch{
                return StatusCode(500);
            }
        
        }
    }

