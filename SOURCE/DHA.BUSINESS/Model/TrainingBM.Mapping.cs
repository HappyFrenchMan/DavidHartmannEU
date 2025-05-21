using DHA.DAL.Entity;

namespace DHA.BUSINESS.Model
{
    public partial class TrainingBM
    {
        public static TrainingBM ToTrainingBM(CV_Training pCVTraining)
        {
            List<string> __lstStringDetail = new List<string>();
            foreach (CV_TrainingDetail __TrainingDetail in pCVTraining.TrainingDetails)
            {
                __lstStringDetail.Add(__TrainingDetail.Detail.ToString());
            }//foreach

            TrainingBM __trainingM = new TrainingBM();
            __trainingM.year = pCVTraining.Year;
            __trainingM.location = pCVTraining.Location.ToString();
            __trainingM.details = __lstStringDetail.ToArray();

            return __trainingM;
        }//ToTrainingBM

    }//class
}//namespace
