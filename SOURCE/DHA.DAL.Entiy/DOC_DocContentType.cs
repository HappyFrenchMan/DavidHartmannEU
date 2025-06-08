using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DHA.DAL.Entity
{
    [Table("doc.T_Ref_DocContentType")]
    public class DOC_DocContentType
    {
        //LINK, H1, H2.....

        [Unicode(true)]
        [MaxLength(10)]
        [Column("TDC_Code")]
        [Key]
        public string Code { get; set; }

        [Unicode(true)]
        [MaxLength(64)]
        [Column("TDC_Label")]
        public string Label { get; set; }
    }
}
