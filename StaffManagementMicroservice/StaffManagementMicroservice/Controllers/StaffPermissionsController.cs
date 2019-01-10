using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StaffManagementMicroservice.DB;
using StaffManagementMicroservice.DTOS;
using StaffManagementMicroservice.Services;

namespace StaffManagementMicroservice.Controllers
{
    public class StaffPermissionsController : Controller
    {
        private readonly DBService _context;

        private List<StaffPermissions> _staffPermissons;

        public StaffPermissionsController(DBService context)
        {
            _context = context;
            _staffPermissons = new List<StaffPermissions>();
            _staffPermissons.Add(new StaffPermissions() { StaffID = -1, Permissions = "Toggle customer purchasing", EmployeeFullName = "Default"} );
            _staffPermissons.Add(new StaffPermissions() { StaffID = -1, Permissions = "View customer invoices", EmployeeFullName = "Default" });
            _staffPermissons.Add(new StaffPermissions() { StaffID = -1, Permissions = "Send customer invoices", EmployeeFullName = "Default" });
            _staffPermissons.Add(new StaffPermissions() { StaffID = -1, Permissions = "Message customers", EmployeeFullName = "Default" });
            _staffPermissons.Add(new StaffPermissions() { StaffID = -1, Permissions = "View stock", EmployeeFullName = "Default" });
            _staffPermissons.Add(new StaffPermissions() { StaffID = -1, Permissions = "Create a sale window", EmployeeFullName = "Default" });
            _staffPermissons.Add(new StaffPermissions() { StaffID = -1, Permissions = "View customer Information", EmployeeFullName = "Default" });
        }

        public async Task<IActionResult> Index()
        {
            var allStaff = _context.GetAllStaff();
            if(allStaff != null)
                return View(allStaff);

            return NotFound();
        }

        public async Task<IActionResult> AddPermissions(int StaffID)
        {
            var AvailablePermissons = _staffPermissons;
            var staffPerms = _context.GetStaffAllfPermissions(StaffID);


            foreach (var perm in staffPerms)
                AvailablePermissons = AvailablePermissons.Where(x => !x.Permissions.Equals(perm.Permissions)).ToList();

            AvailablePermissons = AvailablePermissons.Select(s => { s.StaffID = StaffID; return s; }).ToList();

            if (AvailablePermissons == null)
                return NotFound();

            return View(AvailablePermissons);
        }

        public async Task<IActionResult> DeletePermissions(int StaffID)
        {
            if (StaffID == null)
                return NotFound();

            var staffPermissions = _context.GetStaffAllfPermissions(StaffID);
            if (staffPermissions == null)
                return NotFound();

            return View(staffPermissions);
        }

        public async Task<IActionResult> Delete(int StaffID, string Permissions)
        {
            if (StaffID != 0 && String.IsNullOrEmpty(Permissions))
                return NotFound();

            _context.DeletePermission(StaffID, Permissions);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Add(int StaffID, string Permissions)
        {
            if (StaffID == 0)
                return NotFound();

            _context.AddPermission(StaffID,Permissions);

            return RedirectToAction("Index");
        }

        [HttpGet("{Controller}/Get/{id}")]
        public IActionResult Get(int id)
        {
            if (_context.GetStaff(id) != null)
                return new JsonResult(_context.GetStaffAllfPermissions(id));

            return NotFound();
        }
    }
}
