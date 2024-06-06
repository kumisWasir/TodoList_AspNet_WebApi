using ToDoList.Model;

namespace ToDoList.DTO
{
    public record CategoryDto (string Name);


    public static class Category_Dto_ToModel {
        public static Category Covert_To_Model(this CategoryDto categoryDto){
            return new Category{
                
                Name = categoryDto.Name
            };
        }
    }

    public record TugasDto(string deskripsi, int category_name);

    public static class Tugas_Dto_ToModel {
        public static Tugas Covert_To_Model(this TugasDto tugasDto){
            return new Tugas{
                Deskripsi = tugasDto.deskripsi,
                
            };
        }
    }

}
