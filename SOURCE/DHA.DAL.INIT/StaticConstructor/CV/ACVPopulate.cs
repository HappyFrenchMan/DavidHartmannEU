using DHA.DAL.QueryResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.INIT.StaticConstructor.CV
{
    internal abstract class ACVPopulate
    {

        protected static void AssertEntityUpdatedPositive(UpdateResult pUpdateResult, string pStrErrorMsg = "Expected Entity Updated Positive")
        {
            if (pUpdateResult.EntityUpdated < 1)
            {
                throw new Exception(pStrErrorMsg);
            }//if
        }//AssertEntityUpdatedPositive

        protected static void AssertEntityUpdated(UpdateResult pUpdateResult,int pIntExpected, string pStrErrorMsg = "Entity Updated Error")
        {
            if (pUpdateResult.EntityUpdated != pIntExpected)
            {
                throw new Exception(pStrErrorMsg);
            }//if
        }//AssertEntityUpdated

        protected static void AssertIsSuccess(UpdateResult pUpdateResult, string pStrErrorMsg="Success Expected")
        {
            if (!pUpdateResult.IsSuccess)
            {  
                throw new Exception(pStrErrorMsg);
            }//if
        }//AssertEntityUpdated
    }//class
}//namespace
