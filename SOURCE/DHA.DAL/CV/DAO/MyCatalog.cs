using DHA.DAL.CV.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.CV.DAO
{
    public class MyCatalog
    {
        public static void add_skill(
            string pStrSkillKey,
            string pStrSkillTypeKey,
            string pStrName,
            string pStrDetail="")
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                Skill_Type? lSkillType =
                    select_skill_type(pStrSkillTypeKey);
                lDHA_Db_Context.Attach<Skill_Type>(lSkillType);

                Skill lSkill = new Skill()
                {
                    Key = pStrSkillKey,
                    Type = lSkillType,
                    Name = pStrName,
                    Detail = pStrDetail
                };

                lDHA_Db_Context.Skills.Add(lSkill);
                lDHA_Db_Context.SaveChanges();
            }//using
        }//add_skill

        public static void add_keyrole(string pStrKey, string pStrName)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                KeyRole lKR = new KeyRole()
                {
                    Key = pStrKey,
                    Name = pStrName
                };

                lDHA_Db_Context.KeyRoles.Add(lKR);
                lDHA_Db_Context.SaveChanges();
            }
        }//add_keyrole

        public static void add_contract_type(string pStrKey, string pStrName)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                ContractType lContractType = new ContractType()
                {
                    Key = pStrKey,
                    Name = pStrName
                };

                lDHA_Db_Context.ContractTypes.Add(lContractType);
                lDHA_Db_Context.SaveChanges();
            }
        }//add_contract_type

        public static void add_skill_type(string pStrKey, string pStrDescription)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                Skill_Type lMySkill_Type = new Skill_Type()
                {                    
                    Key = pStrKey,
                    Description = pStrDescription
                };

                lDHA_Db_Context.Skill_Types.Add(lMySkill_Type);
                lDHA_Db_Context.SaveChanges();
            }
        }//add_skill_type

        public static Skill_Type? select_skill_type(string pStrKey)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                return
                    lDHA_Db_Context.Skill_Types.Where(
                        p => p.Key.Equals(pStrKey)
                        ).FirstOrDefault();
            }
        }//select_skill_type

        public static void add_language(string pStrCode, string pStrLanguage)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                LanguageSpoken lLanguage = new LanguageSpoken()
                {
                    Code = pStrCode,
                    Name = pStrLanguage
                };

                lDHA_Db_Context.Languages.Add(lLanguage);
                lDHA_Db_Context.SaveChanges();
            }
        }//add_language

        public static void add_cities(
            int pIntCP, 
            string pStrCity,
            string pStrArea,
            string pStrDepartment)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                City lCity = new City()
                {
                    PostalCode = pIntCP,
                    CityName = pStrCity,
                    Area = pStrArea,
                    Department = pStrDepartment
                };

                lDHA_Db_Context.Cities.Add(lCity);
                lDHA_Db_Context.SaveChanges();
            }
        }//add_cities

        public static City? select_city(int pIntPostalCode)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                return 
                    lDHA_Db_Context.Cities.Where(
                        p => p.PostalCode.Equals(pIntPostalCode)
                        ).FirstOrDefault();
            }//using
        }//select_city

        public static void add_firm(string pStrKey, 
                                    string pStrName,
                                    string pStrSector)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                Firm lFirm = new Firm()
                {
                    Key = pStrKey,
                    Name = pStrName,
                    Sector = pStrSector
                };

                lDHA_Db_Context.Firms.Add(lFirm);
                lDHA_Db_Context.SaveChanges();
            }
        }//add_firm

        public static Firm? select_firm(string pStrFirmKey)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                return
                    lDHA_Db_Context.Firms.Where(
                        p => p.Key.Equals(pStrFirmKey)
                        ).FirstOrDefault();
            }//using
        }//select_firm

        public static Firm? select_firm(int pIntFirmId)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                return
                    lDHA_Db_Context.Firms.Where(
                        p => p.ID.Equals(pIntFirmId)
                        ).FirstOrDefault();
            }//using
        }//select_firm

        public static Skill? select_skill(int pStrSkillCode)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                return
                    lDHA_Db_Context.Skills.Where(
                        p => p.Key.Equals(pStrSkillCode)
                        ).FirstOrDefault();
            }//using
        }//select_skill

        public static Skill? select_skill(string pStrKey)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                return
                    lDHA_Db_Context.Skills.Where(
                        p => p.Key.Equals(pStrKey)
                        ).FirstOrDefault();
            }//using
        }//select_skill

        public static KeyRole? select_keyrole(string pStrKey)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                return
                    lDHA_Db_Context.KeyRoles.Where(p => p.Key.Equals(pStrKey)).FirstOrDefault();
            }//using
        }//select_keyrole

        public static ContractType? select_contractType(string pStrKey)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                return
                    lDHA_Db_Context.ContractTypes.Where(p => p.Key.Equals(pStrKey)).FirstOrDefault();
            }//using
        }//select_contractType

    }//class
}//namespace
