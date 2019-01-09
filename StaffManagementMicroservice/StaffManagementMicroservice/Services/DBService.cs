using StaffManagementMicroservice.DB;
using StaffManagementMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagementMicroservice.Services
{

    interface IDBService
    {
        StaffPermissions GetStaff(int StaffID);

        List<StaffPermissions> GetStafAllfPermissions();

        void SaveStaff(StaffPermissions Staff);

        void DeleteStaff(int StaffID);

        void UpdatePermissions(int StaffID);
    }

    public class DBService
    {
        private readonly StaffPermContext _context;

        public DBService(StaffPermContext context)
        {
            _context = context;
        }

        public StaffPermissions GetStaff(int StaffID)
        {
            if (0 == _context.StaffPermissions.Count())
                return null;
            var first = _context.StaffPermissions.FirstOrDefault(x => x.StaffID == StaffID);
            return first;
        }

        public List<StaffPermissions> GetAllStaff()
        {
            if (0 == _context.StaffPermissions.Count())
                return null;
            var AllStaff = _context.StaffPermissions.Where(x => x.StaffID != null).ToList();

            var filteredStaff = AllStaff.Select(s => new {s.StaffID
                 ,s.EmployeeFullName }).Distinct().ToList();

            List<StaffPermissions> Staff = new List<StaffPermissions>();

            foreach (var staff in filteredStaff)
            {
                var s = new StaffPermissions();
                s.StaffID = staff.StaffID;
                s.EmployeeFullName = staff.EmployeeFullName;
               
                Staff.Add(s);
            }


            return Staff;
        }

        public List<StaffPermissions> GetStaffAllfPermissions(int staffID)
        {
            List<string> permissions = new List<string>();
            List<StaffPermissions> Entries = _context.StaffPermissions.Where( x => x.StaffID == staffID).ToList();

            foreach (var obj in Entries)
                permissions.Add(obj.Permissions);

            return Entries;
        }

        public void SaveStaff(StaffPermissions Staff)
        {
            _context.StaffPermissions.Add(Staff);
            _context.SaveChanges();
        }

        public void DeleteStaff(int StaffID)
        {
            _context.StaffPermissions.RemoveRange(_context.StaffPermissions.Where(x => x.StaffID == StaffID));
            _context.SaveChanges();
        }

        public void DeletePermission(int StaffID,string Permission)
        {
            _context.StaffPermissions.RemoveRange(_context.StaffPermissions.Where(x => x.StaffID == StaffID && x.Permissions.Equals(Permission)));
            _context.SaveChanges();
        }

        public void AddPermission(int StaffID, string Permission)
        {
            _context.StaffPermissions.Add(new StaffPermissions()
             {
                EmployeeFullName = GetStaff(StaffID).EmployeeFullName,
                StaffID =StaffID,
                Permissions = Permission
            });
            _context.SaveChanges();
        }


    }
}


