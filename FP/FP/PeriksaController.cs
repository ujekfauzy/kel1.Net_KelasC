using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP
{
    public class PeriksaController
    {
        HospitalEntities context = new HospitalEntities();
        public IEnumerable<Periksa> showPemeriksaan()
        {
            IEnumerable<Periksa> result = from b in context.Periksas
                                        select b;

            return result;
        }
        public int TotalPeriksa(Patient a)
        {
            IEnumerable<Periksa> harga = from b in context.Periksas
                            where b.id_Pasien == a.Id_Pasien
                            select b;

            int total = 0;
            foreach(var ax in harga)
            {
                
                total = total + ax.Tarif;
            }
            return total;
        }

        public void addPemeriksaan(Periksa priksa)
        {
            context.Periksas.Add(priksa);
            context.SaveChanges();
        }

        public void Update(Periksa pr)
        {
            Periksa updatePemeriksaan = (from b in context.Periksas
                                where b.No_Pemeriksaan == pr.No_Pemeriksaan
                                select b).FirstOrDefault();
            if (updatePemeriksaan != null)
            {
                //updatePemeriksaan.No_Pemeriksaan = pr.No_Pemeriksaan;
                updatePemeriksaan.id_Pegawai = pr.id_Pegawai;
                updatePemeriksaan.id_Pasien = pr.id_Pasien;
                updatePemeriksaan.Penyakit_Akhir = pr.Penyakit_Akhir;
                updatePemeriksaan.Tarif = pr.Tarif;
                updatePemeriksaan.Status_Rawat = pr.Status_Rawat;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("No update");
            }
        }
        public void Delete(int no)
        {
            try
            {
                Periksa PemeriksaanDelete = context.Periksas.Find(no);
                if (PemeriksaanDelete != null)
                {
                    context.Periksas.Remove(PemeriksaanDelete);
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
