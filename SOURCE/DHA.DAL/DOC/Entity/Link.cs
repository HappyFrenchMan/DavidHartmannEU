using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.DAL.DOC.Entity
{
    [Table("CV.T_Link")]
    public class Link
    {
        [Column("LNK_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Unicode(true)]
        [MaxLength(64)]
        [Column("LNK_Categorie")]
        // DEV ou DIVERS ou AUTO
        public string? Categorie { get; set; }


        [Unicode(true)]
        [MaxLength(255)]
        [Column("LNK_Description")]
        // Google
        public string? Description { get; set; }


        [Unicode(true)]
        [MaxLength(255)]
        [Column("LNK_Url")]
        // https://www.google.fr
        public string? Url { get; set; }

    }
}
