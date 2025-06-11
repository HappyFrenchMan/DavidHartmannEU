using DHA.DAL.QueryResult;

namespace DHA.BUSINESS.Result
{
    public class BusinessResult
    {
        private bool _boolErrorInBusiness;
        private Exception? _exceptionBusiness;


        private bool _boolErrorInDAL;
        private Exception? _exceptionDAL;

        public BusinessResult()
        {
            defaultInitNoError();
        }//BusinessResult

        public BusinessResult(bool pBoolErrorInBusiness, string pStrErrorMsgBusiness=null, Exception pException=null)
        {
            _boolErrorInBusiness = pBoolErrorInBusiness;
            if (pBoolErrorInBusiness)
            {
                _exceptionBusiness = new Exception(pStrErrorMsgBusiness);
            }
            else
            {
                _exceptionBusiness = null;
            }
            _boolErrorInDAL = false; ;
            _exceptionDAL = null;
        }//BusinessResult

        public BusinessResult(AQueryResult pAQueryResult)
        {
            if (pAQueryResult.IsSuccess)
            {
                defaultInitNoError();
            }//if
            else
            {
                
                _boolErrorInBusiness = false;
                _boolErrorInDAL = true;
                _exceptionBusiness = null; 
                _exceptionDAL = pAQueryResult.Exception;
            }//else
        }//BusinessResult

        private void defaultInitNoError()
        {
            _boolErrorInBusiness = _boolErrorInDAL = false;
            _exceptionBusiness = _exceptionDAL = null;
        }//defaultInitNoError

        public bool IsSuccess
        {
            get
            {
                return !_boolErrorInDAL && !_boolErrorInBusiness;
            }//get
        }//IsSuccess

        public Exception? ExceptionBusiness { get { return _exceptionBusiness; } }
        public Exception? ExceptionDAL { get { return _exceptionDAL; } }

        public bool ErrorInDAL {  get { return _boolErrorInDAL;  } }
        public bool ErrorInBusiness { get { return _boolErrorInBusiness; } }

    }//class
}//namespace
