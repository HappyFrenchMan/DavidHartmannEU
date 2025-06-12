using DHA.DAL.Entity;
using DHA.DAL.QueryResult;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.Repository
{
    public class DOC_Select_Repo : ARepo
    {
        internal DOC_Select_Repo(MyDbContext pMyDbCtx) : base(pMyDbCtx) { }

        public List<DOC_Link> select_link(out SelectResult oOutSelectResult)
        {
            oOutSelectResult = new SelectResult(true);
            try
            {
                return
                        MyDbCtx.Links
                        .AsNoTracking() /* don't track all database info ! */
                        .ToList();
            }//try
            catch (Exception ex)
            {
                oOutSelectResult = new SelectResult(ex);
                return null;
            }//catch

        }//select_link

    }//class
}//namespace
