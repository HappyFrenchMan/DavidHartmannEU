using DHA.BUSINESS.Model;

namespace DHA.BUSINESS.Interface
{
    interface ICVService
    {
        List<TrainingBM> readTrainingM();
        List<SkillStatBM> readSkillStatM();
        List<ExperienceBM> readExperienceM();
    }
}
