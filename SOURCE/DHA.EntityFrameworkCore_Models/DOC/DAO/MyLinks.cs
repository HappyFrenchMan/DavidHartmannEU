using DHA.EntityFrameworkCore_Models.DOC.Entity;

namespace DHA.EntityFrameworkCore_Models.DOC.DAO
{
    public class MyLinks
    {
        public static void add(string pStrCategorie, string pStrDescription, string pStrURL)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                Link lMyLinkNew = new Link()
                {
                    Categorie = pStrCategorie,
                    Description = pStrDescription,
                    Url = pStrURL
                };

                lDHA_Db_Context.Links.Add(lMyLinkNew);

                lDHA_Db_Context.SaveChanges();
            }//using
        }//add
        
        public static List<Link> select_all_link()
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                return lDHA_Db_Context.Links.ToList();
            }//using
        }//select_all_link

    }//class
}//namespace
