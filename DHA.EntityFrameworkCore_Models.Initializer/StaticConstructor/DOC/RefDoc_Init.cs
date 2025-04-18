using DHA.EntityFrameworkCore_Models.DOC.DAO;

namespace DHA.EntityFrameworkCore_Models.Initializer.StaticConstructor.CV
{
    public static class RefDoc_Init
    {
        public static void Init_Doc_Content_Type()
        {
            MyWebDocRef.add_docContentType("LINK","Link");
            MyWebDocRef.add_docContentType("H1", "Title Level 1");
            MyWebDocRef.add_docContentType("H2", "Title level 2");
            MyWebDocRef.add_docContentType("PARA", "Paragraph");
            MyWebDocRef.add_docContentType("IMG", "Image Raw Binary data");
            MyWebDocRef.add_docContentType("CODE", "Code C#, shell ...");
            MyWebDocRef.add_docContentType("BULLETLIST", "List with Bullet");
        }//Init_Link_Tab

    }//class
}//namespace
