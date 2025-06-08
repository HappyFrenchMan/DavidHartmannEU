using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.QueryResult
{
    public class UpdateResult : AQueryResult
    {

        private int _intEntityUpdated;
        public int EntityUpdated { get { return _intEntityUpdated; } }

        private UpdateResult() : base()
        { 
        }//UpdateResult

        public UpdateResult(bool success, int intEntityUpdated) : base(success)
        {
            _intEntityUpdated = intEntityUpdated;
        }//UpdateResult

        public UpdateResult(Exception exception) : base(false, exception)
        {
            _intEntityUpdated = -1;
        }//UpdateResult

        public UpdateResult(string pStrMessage) : base(false,new Exception(pStrMessage))
        {
            _intEntityUpdated = -1;
        }//UpdateResult
    }//class
}//namespace
