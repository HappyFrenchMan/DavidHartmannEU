// See https://aka.ms/new-console-template for more information

using DAH.DAL;
using DHA.DAL;
using DHA.DAL.INIT.StaticConstructor.DOC;
using DHA.DAL.Initializer;
using DHA.DAL.Initializer.StaticConstructor.CV;


Console.WriteLine("Début - DAL INIT !");


MyDb __myDb = new MyDb();


// Fill database **********************************
// Doc Tablespace
DOC_Init.Init_Link_Tab(__myDb);
// CV TableSpace
CV_Populate_ZeroLinkEntity.Init_ContractType(__myDb);
CV_Populate_ZeroLinkEntity.Init_KeyRole(__myDb);
CV_Populate_ZeroLinkEntity.Init_SkillType(__myDb);
CV_Populate_ZeroLinkEntity.Init_LanguageSpoken(__myDb);
CV_Populate_ZeroLinkEntity.Init_City(__myDb);
CV_Populate_ZeroLinkEntity.Init_Firm(__myDb);
CV_Populate_OneLinkEntity.Init_Skill(__myDb);
CV_Populate_OneLinkEntity.Init_Training(__myDb);
//Experience_Init.Init();


// Document ******************************************
//RefDoc_Init.Init_Doc_Ref();


Console.WriteLine("Fin - DAL INIT !");