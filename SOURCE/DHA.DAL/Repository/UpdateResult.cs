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
        private int _intEntityUpdated;
        private Exception? _exception;

        public bool IsSuccess { get { return _success; } }
        public int EntityUpdated { get { return _intEntityUpdated; }}

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

        public UpdateResult(string pStrMessage)
        {
            _success = false;
            _intEntityUpdated = -1;
            _exception = new Exception(pStrMessage);
        }//UpdateResult
    }//class
}//namespace
