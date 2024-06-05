using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
namespace ToDoList.Model
{
    
    public class Category {
        [Key]
        public int Id{get;set;}
        [Required, MaxLength(200)]
        public string Name {get;set;} = string.Empty;
         [JsonIgnore]
        public ICollection<Tugas>? Tugas {get;set;}

    }
    [Flags]
    public enum TugasSelesai {
        Selesai = 1,
        BelumSelesai = 0,
    }
    
    
    public class Tugas {

        [Key]
        public int Id {get;set;}

        [MaxLength(500)]
        [Required]
        public string Deskripsi {get;set;} = string.Empty;
        
        public TugasSelesai Status {get;set;}

        public int? Category_ID {get;set;}
        [JsonIgnore]
        public virtual Category Category_FK {get; set;}
    }
   
}