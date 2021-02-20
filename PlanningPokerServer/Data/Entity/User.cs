using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningPokerServer.Data.Entity {
    [Table("USER")]
    public class User {
        [Key]
        [Column("ID", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("NAME", TypeName = "varchar(200)")]
        public string Name { get; set; }

        [Required]
        [Column("USERNAME", TypeName = "varchar(200)")]
        public string Username { get; set; }

        [Required]
        [Column("PASSWORD", TypeName = "varchar(200)")]
        public string Password { get; set; }

        public override string ToString() {
            return "{" +
            "Id: " + Id.ToString() + ", " + 
            "Name: " + Name.ToString() + ", " +
            "Username: " + Username.ToString() + ", " +
            "Password: " + Password.ToString() + ", " +
            "}";
        }
    }
}