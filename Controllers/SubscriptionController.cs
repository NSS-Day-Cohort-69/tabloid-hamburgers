
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;


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
    public IActionResult CreateSubscription(newSubscriptionDTO newSubscription)
    {

        if (newSubscription != null)
        {
            Subscription subscription = new Subscription
            {
                SubscriberId = newSubscription.SubscriberId,
                FollowerId = newSubscription.FollowerId,
                SubbedDate = DateTime.Now,
                UnsubbedDate = null
            };

            _db.Subscriptions.Add(subscription);
            _db.SaveChanges();

            return Ok();
        }

        return NoContent();
    }

    [HttpPut]
    public IActionResult Unsubscribe([FromQuery] int followerId, [FromQuery] int subscriberId)
    {
    
        Subscription subscriptionToCancel = _db.Subscriptions.SingleOrDefault(s => s.FollowerId == followerId && s.SubscriberId == subscriberId);

        if (subscriptionToCancel == null)
        {
            return BadRequest("this subscription doesn't exist");
        }
        else 
        {
            subscriptionToCancel.UnsubbedDate = DateTime.Now;
            _db.SaveChanges();
            return Ok();
        }

    }

 
}

