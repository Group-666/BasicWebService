using System.Threading.Tasks;

namespace Kea.BasicWebService.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mainController = new MainController();

            Task.Run(mainController.HandleUserInput).Wait();
        }
    }
}
