using ToDoList.DTO;
using ToDoList.Model;
using System;

namespace ToDoList.Interface
{
    public interface ICrud
    {
        public Task<int> Create ( CategoryDto categoryDTO);
        public  Task <Category> GetById (int id);
        public Task<List<Category>> GetAll();
        public Task Update (int id, CategoryDto categoryDto);
        public Task Delete (int id);
        
       public Task<List<Tugas>> GetTugasByCategory (string categoryname);
    }

    public interface ICrudTugas{
        public Task<int> Create (TugasDto tugasDto);
        public Task<List<Tugas>> GetAll();
        public Task<Tugas> GetById(int id);
        public  Task<int> Change_Status(int id, TugasSelesai status);
        public Task<int> Change_Category(string newCategory, int id);
        public Task<string> Category_name(int id);
        public Task<int> Delete_Tugas(int id);
        public Task <int> Edit_Deskripsi_Tugas(int id , TugasDto tugasDto);
    }
}