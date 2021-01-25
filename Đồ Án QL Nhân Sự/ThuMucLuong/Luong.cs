namespace Đồ_Án_QL_Nhân_Sự.ThuMucLuong
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Luong")]
    public partial class Luong
    {
        [Key]
        [Column("Mã Bộ Phận", Order = 0)]
        [StringLength(50)]
        public string Mã_Bộ_Phận { get; set; }

        [Key]
        [Column("Mã Phòng", Order = 1)]
        [StringLength(50)]
        public string Mã_Phòng { get; set; }

        [Key]
        [Column("Mã Nhân Viên", Order = 2)]
        [StringLength(50)]
        public string Mã_Nhân_Viên { get; set; }

        [Key]
        [Column("Tên Nhân Viên", Order = 3)]
        [StringLength(50)]
        public string Tên_Nhân_Viên { get; set; }

        [Key]
        [Column("Tổng Lương", Order = 4)]
        public double Tổng_Lương { get; set; }

        [Key]
        [Column("Số Ngày Nghỉ", Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Số_Ngày_Nghỉ { get; set; }

        [Key]
        [Column("Số Giờ Làm Thêm", Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Số_Giờ_Làm_Thêm { get; set; }

        [Column("Kỷ Luật")]
        [StringLength(50)]
        public string Kỷ_Luật { get; set; }

        [Key]
        [Column("Loại Nhân Viên", Order = 7)]
        [StringLength(50)]
        public string Loại_Nhân_Viên { get; set; }

        [Key]
        [Column("Tháng", Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tháng { get; set; }

        [Key]
        [Column("Năm", Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Năm { get; set; }
    }
}
