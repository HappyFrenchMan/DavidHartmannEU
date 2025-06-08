namespace DHA.DAL.QueryResult
{
    public abstract class AQueryResult
    {
        private bool _success;
        private Exception? _exception;

        public bool IsSuccess { get { return _success; } }
        public Exception? Exception { get { return _exception; } }

        protected AQueryResult() { }

        public AQueryResult(bool success, Exception? exception=null)
        {
            _success = success;
            _exception = exception;
        }//AQueryResult

    }//class
}//namespace
