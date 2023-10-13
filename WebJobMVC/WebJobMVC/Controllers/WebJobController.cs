using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
namespace WebJobMVC.Controllers
{
    public class WebJobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> TriggerWebJob()
        {
            using (HttpClient client = new HttpClient())
            {
                string functionUrl = "https://$FinalPractice:9xQu01ljMZqcHXGcxZCujGWobAhhM3XWAHo7rprgWn23TMvbw3Cdzjp7nM5m@finalpractice.scm.azurewebsites.net/api/triggeredwebjobs/TrigeredManualzDemo/run"; 
                HttpResponseMessage response = await client.PostAsync(functionUrl, null);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Web job triggered successfully.";
                }
                else
                {
                    TempData["Message"] = "Failed to trigger web job.";
                }
            }

            return RedirectToAction("Index"); 
        }
    }
}





