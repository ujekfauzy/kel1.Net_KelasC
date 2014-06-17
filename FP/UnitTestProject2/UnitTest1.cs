using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FP;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        //HospitalEntities context = new HospitalEntities();
        [TestMethod]
        public void TarifPasien()
        {
            //arrange
            int expectedHarga = 470012;

            Patient p = new Patient()
            {
                Id_Pasien = 2
            };
            PeriksaController pc = new PeriksaController();
            int hargaPeriksa = pc.TotalPeriksa(p);

            PasienController pac = new PasienController();
            int hari = pac.HariKamar(p);

            RoomController rc = new RoomController();
            int harga = rc.HargaKamar(p);

            //act
            int total = hargaPeriksa + (harga * hari);

            //assert
            Assert.AreEqual(expectedHarga, total, "Should be: 470012");
        }

        [TestMethod]
        public void AddPegawai()
        {
            PegawaiController pc = new PegawaiController();
            int count1 = (pc.ShowData().Count()) + 1;

            using (HospitalEntities context = new HospitalEntities())
            {
                int result = (int)(context.GetNewPegawaiId().FirstOrDefault());
                if (result > -1)
                {
                    Pegawai p = new Pegawai()
                    {
                        ID_Pegawai = result,
                        Jenis_Pegawai = "Dokter",
                        Nama_Pegawai = "Ipir",
                        Alamat_Pegawai = "Keputih",
                        Telp_Pegawai = 0912,
                        Kota = "asd",
                        Email = "asdfs"
                    };
                    //PegawaiController pac = new PegawaiController();
                    pc.AddPegawi(p);
                }

                int count2 = pc.ShowData().Count();

                Assert.AreEqual(count1, count2, "Wrong");

            }
        }


    }
}
