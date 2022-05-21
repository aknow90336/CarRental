using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CarRental.DataAccess.DB.CarDB
{
    public partial class CarDBContext : DbContext
    {
        public CarDBContext()
        {
        }

        public CarDBContext(DbContextOptions<CarDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarMake> CarMakes { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<Merchant> Merchants { get; set; }
        public virtual DbSet<SmsLog> SmsLogs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=54.95.104.25;port=3306;database=car;user=root;password=Abc12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("car");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasComment("車種 (休旅/箱型/Jeep)");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Creator)
                    .HasMaxLength(128)
                    .HasColumnName("creator");

                entity.Property(e => e.CustomPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("custom_price")
                    .HasComment("活動");

                entity.Property(e => e.DoorNum)
                    .HasColumnName("door_num")
                    .HasComment("車門數");

                entity.Property(e => e.FridayPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("friday_price")
                    .HasComment("週五");

                entity.Property(e => e.HolidayPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("holiday_price")
                    .HasComment("特殊節日");

                entity.Property(e => e.InsuranceType)
                    .HasColumnName("insurance_type")
                    .HasComment("車體險");

                entity.Property(e => e.MakeId)
                    .HasColumnName("make_id")
                    .HasComment("品牌");

                entity.Property(e => e.MerchantId).HasColumnName("merchant_id");

                entity.Property(e => e.ModelId)
                    .HasColumnName("model_id")
                    .HasComment("車型");

                entity.Property(e => e.NormalPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("normal_price")
                    .HasComment("平日");

                entity.Property(e => e.Plate)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("plate")
                    .HasComment("牌照");

                entity.Property(e => e.PlateDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("plate_date")
                    .HasComment("領牌日期");

                entity.Property(e => e.Seat)
                    .HasColumnName("seat")
                    .HasComment("座位數");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("狀態 (上架/下架)");

                entity.Property(e => e.TransmissionType)
                    .HasColumnName("transmission_type")
                    .HasComment("排檔");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Updator)
                    .HasMaxLength(128)
                    .HasColumnName("updator");

                entity.Property(e => e.ValidFlag)
                    .IsRequired()
                    .HasColumnName("valid_flag")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.WeekendsPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("weekends_price")
                    .HasComment("週末");
            });

            modelBuilder.Entity<CarMake>(entity =>
            {
                entity.ToTable("car_make");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.ToTable("car_model");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarBrandId).HasColumnName("car_brand_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Merchant>(entity =>
            {
                entity.ToTable("merchant");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Creator)
                    .HasMaxLength(128)
                    .HasColumnName("creator");

                entity.Property(e => e.Desc)
                    .HasColumnType("text")
                    .HasColumnName("desc")
                    .HasComment("簡介");

                entity.Property(e => e.LocationAddr)
                    .HasMaxLength(60)
                    .HasColumnName("location_addr")
                    .HasComment("地址");

                entity.Property(e => e.LocationArea)
                    .HasMaxLength(10)
                    .HasColumnName("location_area")
                    .HasComment("區域");

                entity.Property(e => e.LocationCity)
                    .HasMaxLength(10)
                    .HasColumnName("location_city")
                    .HasComment("城市");

                entity.Property(e => e.LocationCode)
                    .HasMaxLength(10)
                    .HasColumnName("location_code")
                    .HasComment("區域代碼");

                entity.Property(e => e.LocationLat)
                    .HasPrecision(12, 9)
                    .HasColumnName("location_lat")
                    .HasComment("緯度");

                entity.Property(e => e.LocationLon)
                    .HasPrecision(12, 9)
                    .HasColumnName("location_lon")
                    .HasComment("經度");

                entity.Property(e => e.Mail)
                    .HasMaxLength(100)
                    .HasColumnName("mail")
                    .HasComment("信箱");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(10)
                    .HasColumnName("manager_name")
                    .HasComment("負責人名稱");

                entity.Property(e => e.ManagerPhone)
                    .HasColumnName("manager_Phone")
                    .HasComment("負責人電話");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name")
                    .HasComment("店名");

                entity.Property(e => e.NormalEnd)
                    .HasColumnType("time")
                    .HasColumnName("normal_end")
                    .HasComment("平日_結束_營業時間");

                entity.Property(e => e.NormalStart)
                    .HasColumnType("time")
                    .HasColumnName("normal_start")
                    .HasComment("平日_起始_營業時間");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("狀態");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(20)
                    .HasColumnName("tax_id")
                    .HasComment("統編");

                entity.Property(e => e.Tel)
                    .HasMaxLength(15)
                    .HasColumnName("tel")
                    .HasComment("市內電話");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Updator)
                    .HasMaxLength(128)
                    .HasColumnName("updator");

                entity.Property(e => e.ValidFlag)
                    .HasColumnName("valid_flag")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.WeekendsEnd)
                    .HasColumnType("time")
                    .HasColumnName("weekends_end")
                    .HasComment("週末_結束_營業時間");

                entity.Property(e => e.WeekendsStart)
                    .HasColumnType("time")
                    .HasColumnName("weekends_start")
                    .HasComment("週末_起始_營業時間");
            });

            modelBuilder.Entity<SmsLog>(entity =>
            {
                entity.ToTable("sms_log");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Act)
                    .HasMaxLength(64)
                    .HasColumnName("act");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time");

                entity.Property(e => e.DestName)
                    .HasMaxLength(16)
                    .HasColumnName("dest_name");

                entity.Property(e => e.DlvTime)
                    .HasColumnType("datetime")
                    .HasColumnName("dlv_time");

                entity.Property(e => e.DoneTime)
                    .HasColumnType("datetime")
                    .HasColumnName("done_time");

                entity.Property(e => e.DstAddr)
                    .HasMaxLength(10)
                    .HasColumnName("dst_addr");

                entity.Property(e => e.IsDlv).HasColumnName("is_dlv");

                entity.Property(e => e.IsSend).HasColumnName("is_send");

                entity.Property(e => e.Message)
                    .HasMaxLength(256)
                    .HasColumnName("message");

                entity.Property(e => e.MsgId)
                    .HasMaxLength(16)
                    .HasColumnName("msg_id");

                entity.Property(e => e.Note)
                    .HasMaxLength(256)
                    .HasColumnName("note");

                entity.Property(e => e.SendTime)
                    .HasColumnType("datetime")
                    .HasColumnName("send_time");

                entity.Property(e => e.StatusFlag).HasColumnName("status_flag");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_time");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Creator)
                    .HasMaxLength(128)
                    .HasColumnName("creator")
                    .UseCollation("utf8mb4_unicode_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(32)
                    .HasColumnName("name")
                    .UseCollation("utf8mb4_0900_ai_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(16)
                    .HasColumnName("phone");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Updator)
                    .HasMaxLength(128)
                    .HasColumnName("updator")
                    .UseCollation("utf8mb4_unicode_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.ValidFlag)
                    .IsRequired()
                    .HasColumnName("valid_flag")
                    .HasDefaultValueSql("'1'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
