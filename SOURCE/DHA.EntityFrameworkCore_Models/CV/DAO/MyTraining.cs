using DHA.EntityFrameworkCore_Models;
using DHA.EntityFrameworkCore_Models.CV.Entity;
using Microsoft.EntityFrameworkCore;

namespace DHA.EntityFrameworkCore_Models.CV.DAO
{
    public class MyTraining
    {
        public static void add(
            int pIntCodePostal,
            int  pIntYear,
            params string [] pStrTabDetail)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                City lCity = MyCatalog.select_city(pIntCodePostal);
                lDHA_Db_Context.Attach<City>(lCity);

                Training lTraining = new Training();
                lTraining.Year = pIntYear;                
                lTraining.Location = lCity;

                foreach (string lStrDetail in pStrTabDetail)
                {
                    TrainingDetail lTrainingDetail = new TrainingDetail();
                    lTrainingDetail.Detail = lStrDetail;

                    lTraining.TrainingDetails.Add(lTrainingDetail);
                }//foreach                

                lDHA_Db_Context.Trainings.Add(lTraining);
                lDHA_Db_Context.SaveChanges();
            }//using 
        }//class

        public static List<Training> select_Training()
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                return lDHA_Db_Context.Trainings
                    .Include(x => x.TrainingDetails)
                    .Include(y => y.Location)
                   .ToList();
            }//using 
        }//Select_Training

    }//class
}//namespace
