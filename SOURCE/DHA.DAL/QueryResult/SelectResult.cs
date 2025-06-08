namespace DHA.DAL.QueryResult
{
    public class SelectResult : AQueryResult
    {
        private SelectResult() : base() { }
        public  SelectResult(bool success) : base(success) { }
        public  SelectResult(Exception exception) : base(false, exception) { }
        public  SelectResult(string pStrMessage) : base(false, new Exception(pStrMessage)) { }

    }//class
}//namespace
