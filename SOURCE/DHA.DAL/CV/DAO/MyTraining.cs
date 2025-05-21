using DHA.DAL;
using DHA.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DHA.DAL.CV.DAO
{
    public class MyTraining
    {
        public static void add(
            int pIntCodePostal,
            int  pIntYear,
            params string [] pStrTabDetail)
        {
            using (Db_Context lDHA_Db_Context = new Db_Context())
            {
                CV_City lCity = MyCatalog.select_city(pIntCodePostal);
                lDHA_Db_Context.Attach<CV_City>(lCity);

                CV_Training lTraining = new CV_Training();
                lTraining.Year = pIntYear;                
                lTraining.Location = lCity;

                foreach (string lStrDetail in pStrTabDetail)
                {
                    CV_TrainingDetail lTrainingDetail = new CV_TrainingDetail();
                    lTrainingDetail.Detail = lStrDetail;

                    lTraining.TrainingDetails.Add(lTrainingDetail);
                }//foreach                

                lDHA_Db_Context.Trainings.Add(lTraining);
                lDHA_Db_Context.SaveChanges();
            }//using 
        }//class

        public static List<CV_Training> select_Training()
        {
            using (Db_Context lDHA_Db_Context = new Db_Context())
            {
                return lDHA_Db_Context.Trainings
                    .Include(x => x.TrainingDetails)
                    .Include(y => y.Location)
                   .ToList();
            }//using 
        }//Select_Training

    }//class
}//namespace
