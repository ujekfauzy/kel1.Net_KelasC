using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace FP
{
    public class PegawaiController
    {
        HospitalEntities context = new HospitalEntities();

        public IEnumerable<Pegawai> ShowData()
        {
            IEnumerable<Pegawai> result = from b in context.Pegawais
                                           select b;

            return result;
        }

        public IEnumerable<Pegawai> ShowDokter()
        {
            IEnumerable<Pegawai> result = from b in context.Pegawais
                                          where b.Jenis_Pegawai == "Dokter"
                                          select b;

            return result;
        }

        public void AddPegawi(Pegawai Pegawai)
        {
            try
            {
                Console.WriteLine("Insert Success");
                context.Pegawais.Add(Pegawai);
                context.SaveChanges();
                Console.WriteLine("Add Success");
            }
            catch (Exception ex)
            {
                {
                    Console.WriteLine("Error on inserting...");
                    Console.WriteLine(ex.InnerException.
                    InnerException.Message);
                }
            }
        }

        public void updatePegawai(Pegawai e)
        {
           
                Pegawai UpdatePegawai = (from b in context.Pegawais
                                          where b.ID_Pegawai == e.ID_Pegawai
                                          select b).FirstOrDefault();
                if (UpdatePegawai != null)
                {
                    //UpdatePegawai.ID_Pegawai = e.ID_Pegawai;
                    UpdatePegawai.Jenis_Pegawai = e.Jenis_Pegawai;
                    UpdatePegawai.Nama_Pegawai = e.Nama_Pegawai;
                    UpdatePegawai.Alamat_Pegawai = e.Alamat_Pegawai;
                    UpdatePegawai.Telp_Pegawai = e.Telp_Pegawai;
                    UpdatePegawai.Kota = e.Kota;
                    UpdatePegawai.Email = e.Email;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("No Update");
                }
            
        }
        public void deletePegawai(int a)
        {
            Pegawai pegawaiDelete = context.Pegawais.Find(a);
            if (pegawaiDelete != null)
            {
                context.Pegawais.Remove(pegawaiDelete);
                context.SaveChanges();
                
            }
        }
        

        // silahkan di tambah i query - query yang lain 
    }
}
