using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DHA.DAL.Entity
{
    [Table("doc.T_Ref_SubTypeDocument")]
    public class DOC_SubTypeDocument
    {
        [Column("STD_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Unicode(true)]
        [Column("STD_Code")]
        [MaxLength(32)]
        public string Code { get; set; }

        [Unicode(true)]
        [MaxLength(64)]
        [Column("STD_Label")]
        public string Label { get; set; }

        [Column("FK_TypeDocument")]
        public string TypeDocumentCode { get; set; }
        public DOC_TypeDocument TypeDocument { get; set; } = null!;

        [Column("FK_SubTypeDocParent")]
        public int SubTypeDocumentId { get; set; }
        public DOC_SubTypeDocument? Parent { get; set; } = null!;

    }
}
