using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP
{
    public class PasienController
    {
        HospitalEntities context = new HospitalEntities();

        public IEnumerable<Patient> showData()
        {
            IEnumerable<Patient> result = from b in context.Patients
                                         select b;
            return result;
        }

        public int HariKamar(Patient pa)
        {
            Patient result = (from b in context.Patients
                                          where b.Id_Pasien == pa.Id_Pasien
                                          select b).FirstOrDefault();
            /*int hari;
            hari = result.Tgl_Masuk.Value.Date - result.Tgl_Masuk.Value.Date;
            int hari1 = hari + 1;*/
            int masuk = (int)result.Tgl_Masuk.Value.ToOADate();
            int keluar = (int)result.Tgl_Keluar.Value.ToOADate();
            int hari = (keluar - masuk) + 1;

            
            return hari;
        }

        public void AddPasien(Patient pasien)
        {
            try
            {
                context.Patients.Add(pasien);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on inserting...");
                Console.WriteLine(ex.InnerException.
                InnerException.Message);
            }
        }

        public void updatePasien(Patient upd)
        {
            Patient PasienUpddate = (from bUpdate in context.Patients
                                   where bUpdate.Id_Pasien == upd.Id_Pasien
                                   select
                                       bUpdate).FirstOrDefault();
            if (PasienUpddate != null)
            {
                //PasienUpddate.Id_Pasien = upd.Id_Pasien;
                PasienUpddate.ID_Pegawai = upd.ID_Pegawai;
                PasienUpddate.ID_Room = upd.ID_Room;
                PasienUpddate.Nama_Pasien = upd.Nama_Pasien;
                PasienUpddate.Penyakit = upd.Penyakit;
                PasienUpddate.Jenis_Kelamin = upd.Jenis_Kelamin;
                PasienUpddate.Golongan_Darah = upd.Golongan_Darah;
                PasienUpddate.Jenis_Kelamin = upd.Jenis_Kelamin;
                PasienUpddate.Tgl_Lahir = upd.Tgl_Lahir;
                PasienUpddate.Alamat_Pasien = upd.Alamat_Pasien;
                PasienUpddate.Kota_Pasien = upd.Kota_Pasien;
                PasienUpddate.No_KTP = upd.No_KTP;
                PasienUpddate.No_Hp = upd.No_Hp;
                PasienUpddate.Pekerjaan = upd.Pekerjaan;
                PasienUpddate.Tgl_Masuk = upd.Tgl_Masuk;
                PasienUpddate.Tgl_Keluar = upd.Tgl_Keluar;
                PasienUpddate.Tarif_total = upd.Tarif_total;
                //PasienUpddate.Id_Pasien = upd.Id_Pasien;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("no Update");
            }
        }

        public void updateTarifPasien(Patient upd)
        {
            Patient PasienUpddate = (from bUpdate in context.Patients
                                     where bUpdate.Id_Pasien == upd.Id_Pasien
                                     select
                                         bUpdate).FirstOrDefault();
            if (PasienUpddate != null)
            {
                //PasienUpddate.Id_Pasien = upd.Id_Pasien;
                PasienUpddate.Tarif_total = upd.Tarif_total;
                //PasienUpddate.Id_Pasien = upd.Id_Pasien;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("no Update");
            }
        }

        public void deletePasien(int id)
        {

            Patient pasienDelete = context.Patients.Find(id);
            if (pasienDelete != null)
            {
                context.Patients.Remove(pasienDelete);
                context.SaveChanges();

            }
            else {
                Console.WriteLine("No delete");
            }
        }
        //Tambahkan query lain
    }
}
