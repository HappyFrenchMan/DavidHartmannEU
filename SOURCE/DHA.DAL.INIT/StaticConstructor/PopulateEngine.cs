using DAH.DAL;
using DHA.DAL.INIT.StaticConstructor.CV;
using DHA.DAL.INIT.StaticConstructor.DOC;
using DHA.DAL.Initializer.StaticConstructor.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.INIT.StaticConstructor
{
    internal class PopulateEngine
    {
        private MyDb _myDb;
        private int _intCurrentStep = -1;

        private enum STEP
        {
            INIT_MYDB = 0,
            Init_Link_Tab,
            Init_ContractType,
            Init_KeyRole,
            Init_SkillType,
            Init_LanguageSpoken,
            Init_City,
            Init_Firm,
            Init_Skill,
            Init_Training,
            Init_ExperienceEntity
        }

        public PopulateEngine() 
        {
            _myDb = null;
        }//PopulateEngine

        // return true if last action
        public bool doNextAction()
        {
            _intCurrentStep++;

            switch (_intCurrentStep)
            {
                case (int)STEP.INIT_MYDB: _myDb = new MyDb(); break;
                case (int)STEP.Init_Link_Tab: DOC_Init.Init_Link_Tab(_myDb); break;
                case (int)STEP.Init_ContractType: CV_Populate_ZeroLinkEntity.Init_ContractType(_myDb); break;
                case (int)STEP.Init_KeyRole: CV_Populate_ZeroLinkEntity.Init_KeyRole(_myDb); break;
                case (int)STEP.Init_SkillType: CV_Populate_ZeroLinkEntity.Init_SkillType(_myDb); break;
                case (int)STEP.Init_LanguageSpoken: CV_Populate_ZeroLinkEntity.Init_LanguageSpoken(_myDb); break;
                case (int)STEP.Init_City:CV_Populate_ZeroLinkEntity.Init_City(_myDb); break;
                case (int)STEP.Init_Firm:CV_Populate_ZeroLinkEntity.Init_Firm(_myDb); break;
                case (int)STEP.Init_Skill:CV_Populate_OneLinkEntity.Init_Skill(_myDb); break;
                case (int)STEP.Init_Training: CV_Populate_OneLinkEntity.Init_Training(_myDb); break;
                case (int)STEP.Init_ExperienceEntity: CV_Populate_ExperienceEntity.Init(_myDb); break;
            }//switch

            return _intCurrentStep == (int)STEP.Init_ExperienceEntity;
        }//doNextaction

    }//class
}//namespace
