using DAH.DAL;
using DHA.DAL.Entity;

namespace DHA.DAL.Repository
{
    public class DOC_Update_Repo : ARepo
    {
        public DOC_Update_Repo(MyDb pMyDb) : base(pMyDb) { }

        public UpdateResult add_doc_link(string pStrCategorie, string pStrDescription, string pStrUrl)
        {
            DOC_Link __docLink = new DOC_Link()
            {
                Categorie = pStrCategorie,
                Description = pStrDescription,
                Url = pStrUrl
            };
            return Commit_Add(__docLink);
        }//add_doc_link
    }//class
}//namespace
