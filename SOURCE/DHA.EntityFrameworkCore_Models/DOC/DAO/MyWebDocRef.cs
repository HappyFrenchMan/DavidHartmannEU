using DHA.EntityFrameworkCore_Models.DOC.Entity;

namespace DHA.EntityFrameworkCore_Models.DOC.DAO
{
    public class MyWebDocRef
    {
        public static bool add_docContentType(
            string pStrCode,
            string pStrLabel)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                lDHA_Db_Context.DocContentTypes.Add(
                    new DocContentType()
                    {
                        Code = pStrCode,
                        Label = pStrLabel
                    });
                return (lDHA_Db_Context.SaveChanges() == 1);
            }//using           
        }//add_docContentType

    }//class
}//namespace
