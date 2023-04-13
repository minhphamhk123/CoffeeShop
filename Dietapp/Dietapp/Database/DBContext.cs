using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Dynamic;
using Dietapp.Database.Models;

namespace Dietapp.Database
{
    internal class DBContext: DbContext
    {
        public static DBContext CreateInstance()
        {
            var db = new DBContext(DBConfig.GetConnectionString());
            return db;
        }

        internal DBContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<BaiTap> BaiTapTbl { get; set; }
        public DbSet<DangNhap> DangNhapTbl { get; set; }
        public DbSet<HoatDong> HoatDongTbl { get; set; }
        public DbSet<KhachHang> KhachHangTbl { get; set; }
        public DbSet<LichSu> LichSuTbl { get; set; }
        public DbSet<MonAn> MonAnTbl { get; set; }
        public DbSet<NauAn> NauAnTbl { get; set; }
        public DbSet<NguyenLieu> NguyenLieuTbl { get; set; }
        public DbSet<QuanLy> QuanLyTbl { get; set; }
        public DbSet<ThamSo> ThamSoTbl { get; set; }
    }
}
