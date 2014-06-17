using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP
{
    class AdminController
    {
        HospitalEntities context = new HospitalEntities();
        public IEnumerable<Admin> ShowData()
        {
            IEnumerable<Admin> result = from b in context.Admins
                                          select b;

            return result;
        }
        public bool SearchID(String username, String password)
        {

            var result = from b in context.Admins
                         where b.User_name == username && b.Password == password
                         select b;

            if (result.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        

        public void addAdmin(Admin admin)
        {
            context.Admins.Add(admin);
            context.SaveChanges();
        }

        public void updateAdmin(Admin ad)
        {
            Admin updateAdmin = (from b in context.Admins
                                         where b.Id_Admin == ad.Id_Admin
                                         select b).FirstOrDefault();
            if (updateAdmin != null)
            {
               // updateAdmin.Id_Admin = ad.Id_Admin;
                updateAdmin.Id_pegawai = ad.Id_pegawai;
                updateAdmin.User_name = ad.User_name;
                updateAdmin.Password = ad.Password;
                context.SaveChanges();

            }
            else
            {
                Console.WriteLine("No update");
            }
        }
        public void Delete(int id)
        {
            try
            {
                Admin AdminDelete = context.Admins.Find(id);
                if (AdminDelete != null)
                {
                    context.Admins.Remove(AdminDelete);
                    context.SaveChanges();

                }
                else
                {
                    Console.WriteLine("No delete");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on deleting...");
                Console.WriteLine(ex.InnerException.
                InnerException.Message);
            }
        }
    }
}
