// See https://aka.ms/new-console-template for more information

using DAH.DAL;
using DHA.DAL;
using DHA.DAL.Initializer;
using DHA.DAL.Initializer.StaticConstructor.CV;


Console.WriteLine("Début - DAL INIT !");


MyDb __myDb = new MyDb();

// init Database Context --> EF_StaticConfiguration

// Fill database CV **********************************
Ref_Init.Init_ContractType(__myDb);
Ref_Init.Init_KeyRole(__myDb);
Ref_Init.Init_SkillType(__myDb);
Ref_Init.Init_Language(__myDb);
Ref_Init.Init_City(__myDb);
Ref_Init.Init_Firm(__myDb);

RefLinked_Init.Init_Skill(__myDb);
//Link_Init.Init_Link_Tab();
//Training_Init.Init_Training();
//Experience_Init.Init();


// Document ******************************************
//RefDoc_Init.Init_Doc_Ref();


Console.WriteLine("Fin - DAL INIT !");