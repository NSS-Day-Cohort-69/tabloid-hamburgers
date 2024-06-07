



using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;

[ApiController]
[Route("/api/[controller]")]
public class AdminController : ControllerBase
{

    private TabloidDbContext _db;

    public AdminController(TabloidDbContext context)
    {
        _db = context;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAllDemotes()
    {
        return Ok(_db.DemoteAdmins.Select(dA => new DemoteAdminDTO
        {
            Id = dA.Id,
            AdminApprovalId = dA.AdminApprovalId,
            AdminToDemoteId = dA.AdminToDemoteId
        }));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult AddNewDemote(DemoteAdminDTO newDemote)
    {
        _db.DemoteAdmins.Add(new DemoteAdmin {
            AdminToDemoteId = newDemote.AdminToDemoteId,
            AdminApprovalId = newDemote.AdminApprovalId
        });

        _db.SaveChanges();

        return Ok();
    }

    [HttpDelete("{Id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteDemote(int Id)
    {

        DemoteAdmin AdminToDelete = _db.DemoteAdmins.FirstOrDefault(da => da.Id == Id);

        _db.DemoteAdmins.Remove(AdminToDelete);
        _db.SaveChanges();
        return Ok();
    }

}