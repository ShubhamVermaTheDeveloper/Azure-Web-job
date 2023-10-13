using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> TriggerWebJob()
    {
        string webJobUrl = "https://webjobtask1.scm.azurewebsites.net/api/triggeredwebjobs/WebJobTriggeredManual/run";

        using (HttpClient client = new HttpClient())
        {
            var username = "$WebJobTask1";
            var password = "Bzm7xMlcpkSe0PxozYHt8cC9iewmvTkDJlpPKwSSnsdSRrFN2RvR0vAgAvvp";
            var byteArray = System.Text.Encoding.ASCII.GetBytes($"{username}:{password}");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            HttpResponseMessage response = await client.PostAsync(webJobUrl, null);
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "WebJob triggered successfully.";
            }
            else
            {
                TempData["Message"] = "Failed to trigger the WebJob.";
            }
        }

        return View("Index");
    }

}
