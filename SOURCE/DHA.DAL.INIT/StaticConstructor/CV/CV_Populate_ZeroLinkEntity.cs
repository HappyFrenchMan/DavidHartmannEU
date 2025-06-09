using DAH.DAL;
using DHA.DAL.Entity;
using DHA.DAL.INIT.StaticConstructor.CV;
using DHA.DAL.QueryResult;
using DHA.DAL.Repository;

//using DHA.DAL.CV.DAO;
using c= DHA.DAL.INIT.StaticConstructor.CV.CV_DAL_Const;

namespace DHA.DAL.Initializer.StaticConstructor.CV
{
    class CV_Populate_ZeroLinkEntity : ACVPopulate
    {
        public static void Init_SkillType(MyDb pMyDB)
        {
            Dictionary<string, string> __dico = new Dictionary<string, string>()
            {
                {c.SK_DB_CODE, c.SK_DB_LBL },
                {c.SK_DEV_CODE, c.SK_DEV_LBL },
                {c.SK_DEVCL_CODE, c.SK_DEVCL_LBL },
                {c.SK_DEVSQL_CODE, c.SK_DEVSQL_LBL },
                {c.SK_DEVSRC_CODE, c.SK_DEVSRC_LBL },
                {c.SK_DEVW_CODE , c.SK_DEVW_LBL },
                {c.SK_ERP_CODE, c.SK_ERP_LBL },
                {c.SK_OS_CODE, c.SK_OS_LBL },
                {c.SK_CLOUD_CODE, c.SK_CLOUD_LBL }
            };
            foreach (KeyValuePair<string, string> keyValuePair in __dico)
            {
                UpdateResult __updateResult = 
                    pMyDB.RepoCVUpdate.add_entity(
                        new CV_SkillType() { Key = keyValuePair.Key, Description = keyValuePair.Value });
                AssertEntityUpdated(__updateResult, 1, "Error while add skill type !");
            }//foreach
        }//Init_SkillType

        public static void Init_KeyRole(MyDb pMyDB)
        {
            Dictionary<string, string> __dico = new Dictionary<string, string>()
            {
                {c.KR_ANALYST_CODE, c.KR_ANALYST_LBL },
                {c.KR_DEVELOPPEUR_CODE, c.KR_DEVELOPPEUR_LBL },
                {c.KR_EXPERTTECH_CODE, c.KR_EXTPERTTECH_LBL }
            };

            foreach (KeyValuePair<string, string> keyValuePair in __dico)
            {
                CV_KeyRole __cvKR = new CV_KeyRole() { Key = keyValuePair.Key, Name = keyValuePair.Value };
                UpdateResult __updateResult =
                    pMyDB.RepoCVUpdate.add_entity(__cvKR);
                AssertEntityUpdated(__updateResult, 1, "Error while add key role !");
            }//foreach
        }//Init_KeyRole

        public static void Init_ContractType(MyDb pMyDB)
        {
            Dictionary<string, string> __dico = new Dictionary<string, string>()
            {
                {c.CT_EMPLOYE_CODE, c.CT_EMPLOYE_LBL },
                {c.CT_ALTERNANT_CODE, c.CT_ALTERNANT_LBL },
                {c.CT_PRESTA_CODE, c.CT_PRESTA_LBL },
                {c.CT_STAGIAIRE_CODE, c.CT_STAGIAIRE_LBL }
            };

            foreach (KeyValuePair<string, string> keyValuePair in __dico)
            {
                CV_ContractType __cvContractType = new CV_ContractType() { Key = keyValuePair.Key, Name = keyValuePair.Value };
                UpdateResult __updateResult = pMyDB.RepoCVUpdate.add_entity(__cvContractType);

                AssertEntityUpdated(__updateResult, 1, "Error while add contract type !");
            }//foreach
        }//Init_ContractType      

        public static void Init_LanguageSpoken(MyDb pMyDB)
        {
            List<CV_LanguageSpoken> __lstCLS =
                new List<CV_LanguageSpoken>()
                {
                    new CV_LanguageSpoken()
                    {
                        Code = c.LG_ENGLISH_CODE,
                        Name = c.LG_ENGLISH_LBL
                    },
                    new CV_LanguageSpoken()
                    {
                        Code = c.LG_GERMAN_CODE,
                        Name = c.LG_GERMAN_LBL
                    }
                };

            UpdateResult __updateResult = pMyDB.RepoCVUpdate.add_entities(__lstCLS.ToArray());

            AssertEntityUpdated(__updateResult, __lstCLS.Count, "Error while add Language !");

        }//Init_Language

        public static void Init_City(MyDb pMyDB)
        {
            const string CONST_YVELINES = "Yvelines";
            const string CONST_ESSONNE = "Essonne";
            const string CONST_ILE_DE_FRANCE = "Île-de-France";
            const string CONST_CENTRE_VAL_DE_LOIRE = "Centre-Val de Loire";
            const string CONST_LOIRET = "Loiret";
            const string CONST_HAUT_DE_SEINE = "Hauts-de-Seine";
            const string CONST_SEINE_SAINT_DENIS = "Seine-Saint-Denis";
            const string CONST_VAL_DE_MARNE = "Val-de-Marne";

            string[] lStrTabCity = new string[] {
                 $"78220;{CONST_YVELINES};{CONST_ILE_DE_FRANCE};Viroflay",
                 $"78140;{CONST_YVELINES};{CONST_ILE_DE_FRANCE};Vélizy-Villacoublay" ,
                 $"78400;{CONST_YVELINES};{CONST_ILE_DE_FRANCE};Chatou",

                 $"91000;{CONST_ESSONNE};{CONST_ILE_DE_FRANCE};Evry",
                 $"91300;{CONST_ESSONNE};{CONST_ILE_DE_FRANCE};Massy",
                 $"91600;{CONST_ESSONNE};{CONST_ILE_DE_FRANCE};Savigny-sur-Orge",
                 $"92200;{CONST_HAUT_DE_SEINE};{CONST_ILE_DE_FRANCE};Neuilly -sur-Seine",
                 $"45000;{CONST_LOIRET};{CONST_CENTRE_VAL_DE_LOIRE};Orléans",
                 $"45160;{CONST_LOIRET};{CONST_CENTRE_VAL_DE_LOIRE};Olivet" ,

                 $"93170;{CONST_SEINE_SAINT_DENIS};{CONST_ILE_DE_FRANCE};Bagnolet",
                 $"93100;{CONST_SEINE_SAINT_DENIS};{CONST_ILE_DE_FRANCE};Montreuil" ,
                 $"94200;{CONST_VAL_DE_MARNE};{CONST_ILE_DE_FRANCE};Ivry-sur-Seine",
        $"92012;{CONST_HAUT_DE_SEINE};{CONST_ILE_DE_FRANCE};Boulogne Billancourt" };

            List<CV_City> __lstCity = new List<CV_City>();
            foreach (string lStrCity in lStrTabCity)
            {
                string[] lTabCity = lStrCity.Split(";");
                int lIntCP = Convert.ToInt32(lTabCity[0]);

                __lstCity.Add(
                    new CV_City()
                    {
                        PostalCode = lIntCP,
                        CityName = lTabCity[3],
                        Area = lTabCity[2],
                        Department = lTabCity[3] 
                    });
            }//foreach

            UpdateResult __updateResult = pMyDB.RepoCVUpdate.add_entities(__lstCity.ToArray());

            AssertEntityUpdated(__updateResult, __lstCity.Count, "Error while add cities !");

        }//Init_City

        public static void Init_Firm(MyDb pMyDB)
        {
            string[] lStrTabFirm = new string[] {
                    c.FI_SERVANTES_KEY+";SERVANTES;ESN" ,
                    c.FI_BNPP_KEY+";BNP PARIBAS;IT" ,
                    c.FI_W4_KEY+";W4;Editeur de logiciel",
                    c.FI_SCPP_KEY+";SCPP;Droits musicaux" ,
                    c.FI_MM_KEY+";MEDIAMOBILE;TELECOM",
                    c.FI_AJILON_KEY+";AJILON;ESN",
                    c.FI_LMSP_KEY+";Laboratoires Mayoly Spindler;Industrie Pharma." ,
                    c.FI_MH_KEY+";Malakoff Humanis;Groupe de Protection sociale",
                    c.FI_METSO_KEY+";METSO;Technologies pour l'Industrie Minière",
                     c.FI_AGAP2_KEY+";AGAP2;ESN"};

            List<CV_Firm> __lstFirms = new List<CV_Firm>();
            foreach (string lStrFirm in lStrTabFirm)
            {
                string[] lTabFirm = lStrFirm.Split(";");
                __lstFirms.Add(
                    new CV_Firm()
                    {
                        Key = lTabFirm[0],
                        Name = lTabFirm[1],
                        Sector = lTabFirm[2]
                    });
            }//foreach

            UpdateResult __updateResult = pMyDB.RepoCVUpdate.add_entities(__lstFirms.ToArray());

            AssertEntityUpdated(__updateResult,__lstFirms.Count, "Error while add firms !");

        }//Init_Firm

    }//class
}//namespace
