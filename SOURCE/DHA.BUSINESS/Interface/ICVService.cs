using DHA.BUSINESS.Model;
using DHA.DAL.CV.Model;

namespace DHA.BUSINESS.Interface
{
    interface ICVService
    {
        List<TrainingBM> readTrainingM();
        List<SkillStatBM> readSkillStatM();
        List<ExperienceBM> readExperienceM();
    }
}
