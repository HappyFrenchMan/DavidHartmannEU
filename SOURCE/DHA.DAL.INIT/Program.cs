// See https://aka.ms/new-console-template for more information
using DHA.DAL.INIT.StaticConstructor;

Console.WriteLine("Début - DAL INIT !");

PopulateEngine __populateEngine = new PopulateEngine();
while (!__populateEngine.doNextAction())
{
    __populateEngine.doNextAction();
}//while


Console.WriteLine("Fin - DAL INIT !");