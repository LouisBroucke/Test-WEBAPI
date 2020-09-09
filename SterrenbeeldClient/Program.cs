using SterrenbeeldService.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SterrenbeeldClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string localHost = "http://localhost:56622/";
            stringBuilder.Append(localHost);
            stringBuilder.Append("api/sterrenbeelden?dagmaand=");

            Console.WriteLine("Geboortedag: ");
            stringBuilder.Append(Console.ReadLine());
            stringBuilder.Append('-');

            Console.WriteLine("Maand: ");
            stringBuilder.Append(Console.ReadLine());

            using var client = new HttpClient();

            var response =
                await client.GetAsync(stringBuilder.ToString());

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var sterrenbeeld = await response.Content.ReadAsAsync<Sterrenbeeld>();
                    Console.WriteLine(sterrenbeeld.Naam);
                    break;
                case HttpStatusCode.BadRequest:
                    Console.WriteLine("Foute input");
                    break;
                default:
                    Console.WriteLine("Technisch probleem");
                    break;
            }
        }
    }
}
