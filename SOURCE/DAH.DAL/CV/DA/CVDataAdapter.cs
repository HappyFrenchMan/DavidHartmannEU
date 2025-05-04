using DAH.DAL.CV.Model;
using DHA.EntityFrameworkCore_Models.CV.DAO;
using DHA.EntityFrameworkCore_Models.CV.Entity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAH.DAL.CV.DA
{
    public class CVDataAdapter
    {
        public static List<TrainingM> readTrainingM()
        {
            List<TrainingM> __lstTrainingM = new List<TrainingM>();
            foreach (Training __training in MyTraining.select_Training())
            {
                List<string> __lstStringDetail = new List<string>();
                foreach (TrainingDetail __TrainingDetail in __training.TrainingDetails)
                {
                    __lstStringDetail.Add(__TrainingDetail.Detail.ToString());
                }

                TrainingM __trainingM = new TrainingM();
                __trainingM.year = __training.Year;
                __trainingM.location = __training.Location.ToString();
                __trainingM.details = __lstStringDetail.ToArray();
                __lstTrainingM.Add( __trainingM);
            }//foreach 

            return __lstTrainingM;
        }//readTrainingM
    }//class
}//namespace
