using DHA.DAL.DOC.DAO;
using DHA.DAL.DOC.Entity;

namespace DHA.DAL.Initializer.StaticConstructor.CV
{
    public static class RefDoc_Init
    {
        public static void Init_Doc_Ref()
        {
            MyDocRef.add_docContentType("LINK","Link");
            MyDocRef.add_docContentType("H1", "Title Level 1");
            MyDocRef.add_docContentType("H2", "Title level 2");
            MyDocRef.add_docContentType("PARA", "Paragraph");
            MyDocRef.add_docContentType("IMG", "Image Raw Binary data");
            MyDocRef.add_docContentType("CODE", "Code C#, shell ...");
            MyDocRef.add_docContentType("BULLETLIST", "List with Bullet");

            MyDocRef.add_TypeDocument("B", "Blog");
            MyDocRef.add_TypeDocument("H", "Howto");

            MyDocRef.add_SubTypeDocument("BLOG", "", "B");

            string const__strHowtoSys = "HOWTO_SYS";
            MyDocRef.add_SubTypeDocument(const__strHowtoSys, "Admin Système", "H");
            SubTypeDocument __stdHowtoSys = MyDocRef.select_SubTypeDocument(const__strHowtoSys);


            string const__strHowtoDev = "HOWTO_DEV";
            MyDocRef.add_SubTypeDocument(const__strHowtoDev, "DEV", "H");
            SubTypeDocument __stdHowtoDEV = MyDocRef.select_SubTypeDocument(const__strHowtoDev);

            MyDocRef.add_SubTypeDocument("HOWTO_DEV", "DEV", "H");

            MyDocRef.add_SubTypeDocument("HOWTO_LINUX", "", "H", __stdHowtoSys.ID);
            MyDocRef.add_SubTypeDocument("HOWTO_BLAZOR", "", "H", __stdHowtoDEV.ID);
            MyDocRef.add_SubTypeDocument("HOWTO_AZURE", "", "H", __stdHowtoSys.ID);

        }//Init_Link_Tab

    }//class
}//namespace
