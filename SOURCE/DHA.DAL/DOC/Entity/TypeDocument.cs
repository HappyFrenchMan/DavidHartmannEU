using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DHA.DAL.DOC.Entity
{
    [Table("doc.T_Ref_TypeDocument")]
    public class TypeDocument
    {
        // On met un code en clé car sa valeur n'est pas sensé changer
        // valeur prévues : BLOG ou HOWTO
        [Unicode(true)]
        [MaxLength(10)]
        [Column("TD_Code")]
        [Key]
        public string Code { get; set; }

        [Unicode(true)]
        [MaxLength(64)]
        [Column("TD_Label")]
        public string Label { get; set; }
    }
}
