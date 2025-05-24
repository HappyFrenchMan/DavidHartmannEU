using DAH.DAL;
using DHA.DAL.Entity;
//using DHA.DAL.CV.DAO;
using c= DHA.DAL.INIT.StaticConstructor.CV.Ref_Init_Const;

namespace DHA.DAL.Initializer.StaticConstructor.CV
{
    class Ref_Init
    {
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
                pMyDB.CVContractTypeRepository.Add(
                    new CV_ContractType() { Key = keyValuePair.Key, Name = keyValuePair.Value });
            }//foreach
        }//Init_ContractType

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
                pMyDB.CVKeyRoleRepository.Add(
                   new CV_KeyRole() { Key=keyValuePair.Key, Name=keyValuePair.Value});
            }//foreach
        }//Init_KeyRole


        public static void Init_SkillType(MyDb pMyDB)
        {
            string[] __tabSkill =
            {
                    "DB;BASE_DE_DONNEES",
                    "DEV;DEVELOPPEMENT",
                    "DEVW;DEVELOPPEMENT_WEB",
                    "DEVCL;DEVELOPPEMENT_CLIENT_LOURD",
                    "DEVSQL;DEVELOPPEMENT_SQL",
                    "DEVSOURCE;LOGICIEL_DE_GESTION_DE_VERSIONS",
                    "ERP;ERP_PROGICIEL_DE_GESTION_INTÉGRÉ",
                    "OS;SYSTEME_EXPLOITATION",
                    "CLOUD;INFRA CLOUD "
                };
            foreach (string __strSkill in __tabSkill)
            {
                pMyDB.CVSkillTypeRepository.Add(
                    new CV_SkillType() {  Key = __strSkill.Split(';')[0] , Description= __strSkill.Split(';')[1] });
            }
        }//Init_SkillType

        public static void Init_Language(MyDb pMyDB)
        {
            string[] __tabLanguage =
            {
                    "EN;Anglais",
                    "DE;Allemand"
                };
            foreach (string __strLanguage in __tabLanguage)
            {
                pMyDB.CVLanguageSpokenRepository.Add(
                    new CV_LanguageSpoken() { Code= __strLanguage.Split(';')[0] ,Name=__strLanguage.Split(';')[1] })
              
            }
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

            foreach (string lStrCity in lStrTabCity)
            {
                string[] lTabCity = lStrCity.Split(";");
                int lIntCP = Convert.ToInt32(lTabCity[0]);

                pMyDB.CVCityRepository.Add(
                    new CV_City()
                    {
                        PostalCode = lIntCP,
                        CityName = lTabCity[3],
                        Area = lTabCity[2],
                        Department = lTabCity[3]; 
                    });
            }
        }//Init_City

        public static void Init_Firm(MyDb pMyDB)
        {
            string[] lStrTabFirm = new string[] {
                    "SERVANTES;SERVANTES;ESN" ,
                    "BNPP;BNP PARIBAS;IT" ,
                    "W4;W4;Editeur de logiciel",
                    "SCPP;SCPP;Droits musicaux" ,
                    "MM;MEDIAMOBILE;TELECOM",
                    "AJILON;AJILON;ESN",
                    "LMSP;Laboratoires Mayoly Spindler;Industrie Pharma." ,
                    "MH;Malakoff Humanis;Groupe de Protection sociale",
                    "METSO;METSO;Technologies pour l'Industrie Minière",
                     "AGAP2;AGAP2;ESN"};
            foreach (string lStrFirm in lStrTabFirm)
            {
                string[] lTabFirm = lStrFirm.Split(";");
                pMyDB.CVFirmRepository.Add(
                    new CV_Firm()
                    {
                        Key = lTabFirm[0],
                        Name = lTabFirm[1],
                        Sector = lTabFirm[2]
                    });
            }//foreach
        }//Init_Firm

    }//class
}//namespace
