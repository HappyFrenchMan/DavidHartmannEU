using DHA.BUSINESS.Model;
using DHA.BUSINESS.Result;

namespace DHA.BUSINESS.Interface
{
    interface ICVService
    {
        List<TrainingBM> readTrainingM(out BusinessResult oBusinessResult);
        List<SkillStatBM> readSkillStatM(out BusinessResult oBusinessResult);
        List<ExperienceBM> readExperienceM(BusinessResult oBusinessResult);
    }
}
