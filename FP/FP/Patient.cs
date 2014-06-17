//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patient
    {
        public Patient()
        {
            this.Periksas = new HashSet<Periksa>();
        }
    
        public int Id_Pasien { get; set; }
        public Nullable<int> ID_Pegawai { get; set; }
        public Nullable<int> ID_Room { get; set; }
        public string Nama_Pasien { get; set; }
        public string Penyakit { get; set; }
        public string Jenis_pasien { get; set; }
        public string Golongan_Darah { get; set; }
        public string Jenis_Kelamin { get; set; }
        public System.DateTime Tgl_Lahir { get; set; }
        public string Alamat_Pasien { get; set; }
        public string Kota_Pasien { get; set; }
        public Nullable<int> No_KTP { get; set; }
        public Nullable<int> No_Hp { get; set; }
        public string Pekerjaan { get; set; }
        public Nullable<System.DateTime> Tgl_Masuk { get; set; }
        public Nullable<System.DateTime> Tgl_Keluar { get; set; }
        public Nullable<int> Tarif_total { get; set; }
    
        public virtual Kamar Kamar { get; set; }
        public virtual Pegawai Pegawai { get; set; }
        public virtual ICollection<Periksa> Periksas { get; set; }
    }
}