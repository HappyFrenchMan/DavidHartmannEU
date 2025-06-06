﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.DAL.CV.Entity
{
    [Table("CV.T_Ref_ContratType")]
    public class ContractType
    {
        [Unicode(true)]
        [MaxLength(255)]
        [Column("CTY_Key")]
        [Key]
        public string Key { get; set; }

        [Unicode(true)]
        [MaxLength(255)]
        [Column("CTY_Name")]
        public string Name { get; set; }
    }
}
