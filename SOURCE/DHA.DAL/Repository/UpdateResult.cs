using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.Repository
{
    public class UpdateResult
    {
        private bool _success;
        private int? _intEntityUpdated;
        private Exception? _exception;

        private UpdateResult() 
        { 
        }//UpdateResult

        public UpdateResult(bool success, int intEntityUpdated)
        {
            _success = success;
            _intEntityUpdated = intEntityUpdated;
        }//UpdateResult

        public UpdateResult(Exception exception)
        {
            _success = false;
            _intEntityUpdated = -1;
            _exception = exception;
        }//UpdateResult
    }//class
}//namespace
