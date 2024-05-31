
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;
using Tabloid.Models;


[ApiController]
[Route("/api/[controller]")]
public class SubscriptionController : ControllerBase
{
    private TabloidDbContext _db;

    public SubscriptionController(TabloidDbContext context)
    {
        _db = context;
    }


   [HttpPost]
   [Authorize]
   public IActionResult CreateSubscription(Subscription newSubscription)
   {
   
    if (newSubscription != null)
    {
        newSubscription.SubbedDate = DateTime.Now;
        newSubscription.UnsubbedDate = null;
        _db.Subscriptions.Add(newSubscription);
        _db.SaveChanges();

        return Ok();
    }
    
    return NoContent();
   }
}
