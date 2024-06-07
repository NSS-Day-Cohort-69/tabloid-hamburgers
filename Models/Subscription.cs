using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabloid.Models;

public class Subscription
{
    [Required]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Subscriber")]
    public int SubscriberId { get; set; }
    [ForeignKey("SubscriberId")]
    public UserProfile Subscriber { get; set; }
    [Required]
    [ForeignKey("UserProfile")]
    public int FollowerId { get; set; }

    [Required]
    public DateTime SubbedDate { get; set; }
    public DateTime? UnsubbedDate { get; set; }
}
