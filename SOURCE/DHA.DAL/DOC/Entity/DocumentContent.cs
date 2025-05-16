using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DHA.DAL.DOC.Entity
{
    [Table("doc.T_DocumentContent")]
    public class DocumentContent
    {
        [Column("DCC_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Unicode(true)]
        [MaxLength(8192)]
        [Column("DCC_Content")]
        public string Content { get; set; }

        [Unicode(true)]
        [MaxLength(8192)]
        [Column("DCC_Sequence")]
        public short Sequence { get; set; }

        [Column("FK_DocId")]
        public int WebDocumentId { get; set; }
        public WebDocument WebDocument { get; set; }

        [Column("FK_DocContentTypeCode")]
        public string DocContentTypeCode { get; set; }
        public DocContentType DocContentType { get; set; }
    }
}
