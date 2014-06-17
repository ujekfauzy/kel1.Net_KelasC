using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP
{
    public class RoomController
    {
        HospitalEntities context = new HospitalEntities();
        public IEnumerable<Kamar> showRoom()
        {
            IEnumerable<Kamar> result = from b in context.Kamars
                                       select b;

            return result;
        }

        public int HargaKamar(Patient pat)
        {
            Patient idr = (from i in context.Patients
                          where i.Id_Pasien == pat.Id_Pasien
                          select i).FirstOrDefault();
            Kamar result = (from b in context.Kamars
                          where b.Id_Room == idr.ID_Room
                          select b).FirstOrDefault();

            int harga;
            harga = result.Harga_Sewa;
            return harga;
        }

        public void addRoom(Kamar room)
        {
            context.Kamars.Add(room);
            context.SaveChanges();
        }

        public void updateStatus(Patient pa)
        {
            Kamar updateStats = (from b in context.Kamars
                                 where b.Id_Room == pa.ID_Room
                                 select b).FirstOrDefault();
            if (updateStats != null)
            {
                //byte bit = System.Convert.ToByte(a);
                updateStats.Status_Kamar = System.Convert.ToByte(1);
                context.SaveChanges();
            }
        }

        public void updateFreeStatus(Patient pa)
        {
            Kamar updateStats = (from b in context.Kamars
                                 where b.Id_Room == pa.ID_Room
                                 select b).FirstOrDefault();
            if (updateStats != null)
            {
                //byte bit = System.Convert.ToByte(a);
                updateStats.Status_Kamar = System.Convert.ToByte(0);
                context.SaveChanges();
            }
        }

        public void Update(Kamar r)
        {
            Kamar updateRoom = (from b in context.Kamars
                               where b.Id_Room == r.Id_Room
                               select b).FirstOrDefault();
            if (updateRoom != null)
            {
                //updateRoom.Id_Room = r.Id_Room;
                updateRoom.Nama_Kamar = r.Nama_Kamar;
                updateRoom.Harga_Sewa = r.Harga_Sewa;
                updateRoom.Status_Kamar = r.Status_Kamar;
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
                Kamar roomDelete = context.Kamars.Find(id);
                if (roomDelete != null)
                {
                    context.Kamars.Remove(roomDelete);
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
