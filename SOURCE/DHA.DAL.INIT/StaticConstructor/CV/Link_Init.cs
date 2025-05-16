using DHA.DAL.DOC.DAO;

namespace DHA.DAL.Initializer.StaticConstructor.CV
{
    public static class Link_Init
    {
        public static void Init_Link_Tab()
        {
            string[] __tabStringLink =
            {
                "AUTRE; Google; https://www.google.fr",
                "AUTO; Caradisiac; https://www.caradisiac.com/",
                "AUTO; L'argus;https://www.largus.fr/",
                "TECH; 01Net; https://www.01net.com/",
                "MEDIA; Le Monde; https://www.lemonde.fr/",
                "MEDIA; Les Echos; https://www.lesechos.fr/",
                "TECH; LinuxFr; https://www.linuxfr.org",
                "TECH; Developpez.com; https://www.developpez.com/",
                "TECH; ASP.NET Core; https://docs.microsoft.com/aspnet/core"
            };
            
            foreach (string __strLinkInfo in __tabStringLink)
            {
                string[] lStrTabInfo = __strLinkInfo.Split(';');
                string lStrCategorie = lStrTabInfo[0];
                string lStrDescription = lStrTabInfo[1];
                string lStrURL = lStrTabInfo[2];
                MyLinks.add(lStrCategorie, lStrDescription, lStrURL);
            }
        }//Init_Link_Tab

    }//class
}//namespace
