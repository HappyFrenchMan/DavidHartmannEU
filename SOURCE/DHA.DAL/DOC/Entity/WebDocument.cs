using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DHA.DAL.DOC.Entity
{
    [Table("doc.T_WebDocument")]
    public class WebDocument
    {
        [Column("DOC_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Unicode(true)]
        [MaxLength(64)]
        [Column("DOC_Label")]
        public string Label { get; set; }

        [Column("Doc_DateInsert")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Column("Doc_DateUpdate")]
        public DateTime? UpdateDate { get; set; }

        [Column("FK_SubTypeDoc")]
        public int SubTypeDocumentId { get; set; }
        public SubTypeDocument Parent { get; set; }

    }
}
