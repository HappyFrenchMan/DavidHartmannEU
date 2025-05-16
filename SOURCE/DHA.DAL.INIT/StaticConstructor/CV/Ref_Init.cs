using DHA.DAL.CV.DAO;
using c= DHA.DAL.Initializer.StaticConstructor.CV.Ref_Init_Const;

namespace DHA.DAL.Initializer.StaticConstructor.CV
{
    class Ref_Init
    {
        public static void Init_ContractType()
        {
            MyCatalog.add_contract_type(c.CT_EMPLOYE_CODE, c.CT_EMPLOYE_LBL);
            MyCatalog.add_contract_type(c.CT_ALTERNANT_CODE, c.CT_ALTERNANT_LBL);
            MyCatalog.add_contract_type(c.CT_PRESTA_CODE, c.CT_PRESTA_LBL);
            MyCatalog.add_contract_type(c.CT_STAGIAIRE_CODE, c.CT_STAGIAIRE_LBL);
        }//Init_ContractType

        public static void Init_KeyRole()
        {
            MyCatalog.add_keyrole(c.KR_ANALYST_CODE, c.KR_ANALYST_LBL);
            MyCatalog.add_keyrole(c.KR_DEVELOPPEUR_CODE, c.KR_DEVELOPPEUR_LBL);
            MyCatalog.add_keyrole(c.KR_EXPERTTECH_CODE, c.KR_EXTPERTTECH_LBL);
        }//Init_ContractType


        public static void Init_SkillType()
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
                MyCatalog.add_skill_type(
                    __strSkill.Split(';')[0],
                    __strSkill.Split(';')[1]);
            }
        }//Init_SkillType

        public static void Init_Language()
        {
            string[] __tabLanguage =
            {
                "EN;Anglais",
                "DE;Allemand"
            };
            foreach (string __strLanguage in __tabLanguage)
            {
                MyCatalog.add_language(
                    __strLanguage.Split(';')[0],
                    __strLanguage.Split(';')[1]);
            }
        }//Init_Language

        public static void Init_City()
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
                string [] lTabCiry = lStrCity.Split(";");
                int lIntCP = Convert.ToInt32(lTabCiry[0]);

                MyCatalog.add_cities(
                    lIntCP,
                    lTabCiry[3], /* City */
                    lTabCiry[2], /* Area */
                    lTabCiry[1]); /* Department */
            }
         }//Init_City

        public static void Init_Firm()
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
                MyCatalog.add_firm(
                    lTabFirm[0], /* Key */
                    lTabFirm[1], /* Name */
                    lTabFirm[2]); /* Sector */
            }
        }//Init_Firm

    }//class
}//namespace
