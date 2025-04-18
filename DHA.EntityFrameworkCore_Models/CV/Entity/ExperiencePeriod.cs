using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.EntityFrameworkCore_Models.CV.Entity
{
    [Owned]
    public class ExperiencePeriod
    {
        [Column("EXP_YearStart")]
        public int YearStart { get; set; }
        [Column("EXP_MonthStart")]
        public int MonthStart { get; set; }
        [Column("EXP_YearEnd")]
        public int YearEnd { get; set; }
        [Column("EXP_MonthEnd")]
        public int MonthEnd { get; set; }


        public TimeSpan DureeExperience()
        {
            DateTime __dtDebut = new DateTime(YearStart, MonthStart, 1);
            DateTime __dtFin = new DateTime(YearEnd, MonthEnd, 1);
            if (__dtDebut.Ticks == __dtFin.Ticks || __dtDebut > __dtFin)
            {
                throw new Exception("Erreur dans les dates");
            }//if

            return __dtFin - __dtDebut;
        }//DureeExperience

        public string Get_Duree_String()
        {
            DateTime __dtDebut = new DateTime(YearStart, MonthStart, 1);
            DateTime __dtFin = new DateTime(YearEnd, MonthEnd, 1);
            if (__dtDebut.Ticks == __dtFin.Ticks || __dtDebut > __dtFin)
            {
                return "Erreur dans les dates";
            }

            // Compter les mois
            int __intDureeMoisTotal = 0;
            DateTime __dtCalculDebut = new DateTime(__dtDebut.Ticks);
            DateTime __dtCalculFin = new DateTime(__dtDebut.Ticks);
            while (__dtCalculFin <= __dtFin)
            {
                if (__dtCalculFin.Month != __dtCalculDebut.Month)
                {
                    __intDureeMoisTotal++;
                    __dtCalculDebut = new DateTime(__dtCalculFin.Ticks);
                }

                __dtCalculFin = __dtCalculFin.AddDays(1);
            }//while

            // Textualiser la durée
            string __strDureeTexte = string.Empty;
            if (__intDureeMoisTotal < 12)
            {
                __strDureeTexte = $"{__intDureeMoisTotal.ToString()} Mois";
            }//if
            else
            {
                int __intAnnee = __intDureeMoisTotal / 12;
                int __intMois = __intDureeMoisTotal - __intAnnee * 12;
                string __strLBLAnnee = string.Empty;
                if (__intAnnee == 1)
                {
                    __strLBLAnnee = "Année";
                }
                else
                {
                    __strLBLAnnee = "Ans";
                }

                if (__intMois == 0)
                {
                    __strDureeTexte = $"{__intAnnee.ToString()} {__strLBLAnnee}";
                }
                else
                {
                    __strDureeTexte = $"{__intAnnee.ToString()} {__strLBLAnnee} et {__intMois} Mois";
                }
            }//else
            return __strDureeTexte;
        }//Get_Duree_String
    }//class
}//namespace
