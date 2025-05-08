using DHA.EntityFrameworkCore_Models.CV.Entity;
using DHA.EntityFrameworkCore_Models.DOC.Entity;

namespace DHA.EntityFrameworkCore_Models.DOC.DAO
{
    public class MyDocRef
    {
        public static bool add_docContentType(string pStrCode,string pStrLabel)
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

        public static bool add_TypeDocument(string pStrCode,string pStrLabel)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                lDHA_Db_Context.TypeDocuments.Add(
                    new TypeDocument()
                    {
                        Code = pStrCode,
                        Label = pStrLabel
                    });
                return (lDHA_Db_Context.SaveChanges() == 1);
            }//using           
        }//add_docContentType

        public static bool add_SubTypeDocument(string pStrCode, string pStrLabel, string pStrTypeDocumentCode, 
            int pSubTypeDocId=-1)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                SubTypeDocument __std = new SubTypeDocument()
                {
                    Code = pStrCode,
                    Label = pStrLabel,
                    TypeDocumentCode = pStrTypeDocumentCode
                };
                if (pSubTypeDocId!=-1)
                {
                    __std.SubTypeDocumentId = pSubTypeDocId;
                }

                lDHA_Db_Context.SubTypeDocuments.Add(__std);
                return (lDHA_Db_Context.SaveChanges() == 1);
            }//using           
        }//add_docContentType

        public static DocContentType? select_DocContentType(string pStrCode)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                return
                    lDHA_Db_Context.DocContentTypes.Where(p => p.Code.Equals(pStrCode)).FirstOrDefault();
            }
        }//select_DocContentType

        public static TypeDocument? select_TypeDocument(string pStrCode)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                return
                    lDHA_Db_Context.TypeDocuments.Where(p => p.Code.Equals(pStrCode)).FirstOrDefault();
            }
        }//select_TypeDocument

        public static SubTypeDocument? select_SubTypeDocument(string pStrCode)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                return
                    lDHA_Db_Context.SubTypeDocuments.Where(p => p.Code.Equals(pStrCode)).FirstOrDefault();
            }
        }//select_SubTypeDocument

    }//class
}//namespace
