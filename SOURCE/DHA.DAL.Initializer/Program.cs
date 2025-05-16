// See https://aka.ms/new-console-template for more information

using DHA.DAL;
using DHA.DAL.Initializer;
using DHA.DAL.Initializer.StaticConstructor.CV;


Console.WriteLine("Hello, World!");

// init Database Context --> EF_StaticConfiguration

EF_StaticConfiguration.SQL_LITE_FILE_NAME = DHAConfig.DbFileName();
// recréer la base à chaque fois
EF_StaticConfiguration.EF_CORE_ENSURE_DELETED = true; 
EF_StaticConfiguration.EF_CORE_ENSURE_CREATED = true;

// Fill database CV **********************************
Ref_Init.Init_ContractType();
Ref_Init.Init_KeyRole();
Ref_Init.Init_SkillType();
Ref_Init.Init_Language();
Ref_Init.Init_City();
Ref_Init.Init_Firm();
RefLinked_Init.Init_Skill();
Link_Init.Init_Link_Tab();
Training_Init.Init_Training();
Experience_Init.Init();


// Document ******************************************
RefDoc_Init.Init_Doc_Ref();
