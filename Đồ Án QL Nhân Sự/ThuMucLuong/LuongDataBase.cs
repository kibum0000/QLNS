using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Đồ_Án_QL_Nhân_Sự.ThuMucLuong
{
    public partial class LuongDataBase : DbContext
    {
        public LuongDataBase()
            : base("name=LuongDataBase")
        {
        }

        public virtual DbSet<Luong> Luongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Luong>()
                .Property(e => e.Mã_Bộ_Phận)
                .IsUnicode(false);

            modelBuilder.Entity<Luong>()
                .Property(e => e.Mã_Phòng)
                .IsUnicode(false);

            modelBuilder.Entity<Luong>()
                .Property(e => e.Mã_Nhân_Viên)
                .IsUnicode(false);
        }
    }
}
