using DHA.BUSINESS.Model;
using DHA.BUSINESS.Result;

namespace DHA.BUSINESS.Interface
{
    public interface ICVReadService
    {
        List<TrainingBM> readTrainingM(out BusinessResult oBusinessResult);
        List<SkillStatBM> readSkillStatM(out BusinessResult oBusinessResult);
        List<ExperienceBM> readExperienceM(out BusinessResult oBusinessResult);
    }
}
