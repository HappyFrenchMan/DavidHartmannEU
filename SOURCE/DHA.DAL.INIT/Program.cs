// See https://aka.ms/new-console-template for more information

using DAH.DAL;
using DHA.DAL;
using DHA.DAL.INIT.StaticConstructor.CV;
using DHA.DAL.Initializer;
using DHA.DAL.Initializer.StaticConstructor.CV;


Console.WriteLine("Début - DAL INIT !");


MyDb __myDb = new MyDb();


// Fill database **********************************
// Doc Tablespace
DOC_Init.Init_Link_Tab(__myDb);
// CV TableSpace
 CV_Ref_Init.Init_ContractType(__myDb);
CV_Ref_Init.Init_KeyRole(__myDb);
CV_Ref_Init.Init_SkillType(__myDb);
CV_Ref_Init.Init_Language(__myDb);
CV_Ref_Init.Init_City(__myDb);
CV_Ref_Init.Init_Firm(__myDb);
CV_RefLinked_Init.Init_Skill(__myDb);
CV_RefLinked_Init.Init_Training(__myDb);
//Experience_Init.Init();


// Document ******************************************
//RefDoc_Init.Init_Doc_Ref();


Console.WriteLine("Fin - DAL INIT !");