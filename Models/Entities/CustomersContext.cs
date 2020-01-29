using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CustomersContext : DbContext
    {
        public CustomersContext()
        {
        }

        public CustomersContext(DbContextOptions<CustomersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CM_B_ATTACHMENT> CM_B_ATTACHMENT { get; set; }
        public virtual DbSet<CM_B_ATTACHMENT_ARCHIVE> CM_B_ATTACHMENT_ARCHIVE { get; set; }
        public virtual DbSet<CM_B_COUNTER> CM_B_COUNTER { get; set; }
        public virtual DbSet<CM_B_SHOP> CM_B_SHOP { get; set; }
        public virtual DbSet<CM_S_AREA_BOOK> CM_S_AREA_BOOK { get; set; }
        public virtual DbSet<CM_S_ATTACHMENT_DOCUMENT> CM_S_ATTACHMENT_DOCUMENT { get; set; }
        public virtual DbSet<CM_S_ATTACHMENT_TYPE> CM_S_ATTACHMENT_TYPE { get; set; }
        public virtual DbSet<CM_S_CAMPAIGN> CM_S_CAMPAIGN { get; set; }
        public virtual DbSet<CM_S_CITY_BOOK> CM_S_CITY_BOOK { get; set; }
        public virtual DbSet<CM_S_DAYCENTER> CM_S_DAYCENTER { get; set; }
        public virtual DbSet<CM_S_DAYCENTER_EXT_AUS> CM_S_DAYCENTER_EXT_AUS { get; set; }
        public virtual DbSet<CM_S_EMPLOYEE> CM_S_EMPLOYEE { get; set; }
        public virtual DbSet<CM_S_MEDIATYPE> CM_S_MEDIATYPE { get; set; }
        public virtual DbSet<CM_S_MP_DETAILS_EXT_AUS> CM_S_MP_DETAILS_EXT_AUS { get; set; }
        public virtual DbSet<CM_S_PRACTICE_DETAILS_EXT_AUS> CM_S_PRACTICE_DETAILS_EXT_AUS { get; set; }
        public virtual DbSet<CM_S_REFERENCE_SOURCE_EXT_AUS> CM_S_REFERENCE_SOURCE_EXT_AUS { get; set; }
        public virtual DbSet<CM_S_STATE_EXT_AUS> CM_S_STATE_EXT_AUS { get; set; }
        public virtual DbSet<CU_B_ACTIVITY> CU_B_ACTIVITY { get; set; }
        public virtual DbSet<CU_B_ACTIVITY_EXT_AUS> CU_B_ACTIVITY_EXT_AUS { get; set; }
        public virtual DbSet<CU_B_ADDRESS> CU_B_ADDRESS { get; set; }
        public virtual DbSet<CU_B_ADDRESS_BOOK> CU_B_ADDRESS_BOOK { get; set; }
        public virtual DbSet<CU_B_ADDRESS_BOOK_EXT_AUS> CU_B_ADDRESS_BOOK_EXT_AUS { get; set; }
        public virtual DbSet<CU_B_ADDRESS_EXT_AUS> CU_B_ADDRESS_EXT_AUS { get; set; }
        public virtual DbSet<CU_B_AUDIOGRAM> CU_B_AUDIOGRAM { get; set; }
        public virtual DbSet<CU_B_HA_ITEM_HISTORY> CU_B_HA_ITEM_HISTORY { get; set; }
        public virtual DbSet<CU_B_HA_ITEM_HISTORY_EXT_AUS> CU_B_HA_ITEM_HISTORY_EXT_AUS { get; set; }
        public virtual DbSet<CU_B_LEAD_ADDRESS_EXT_AUS> CU_B_LEAD_ADDRESS_EXT_AUS { get; set; }
        public virtual DbSet<CU_B_LEAD_EXT_AUS> CU_B_LEAD_EXT_AUS { get; set; }
        public virtual DbSet<CU_B_NOTE> CU_B_NOTE { get; set; }
        public virtual DbSet<CU_B_PROFILE> CU_B_PROFILE { get; set; }
        public virtual DbSet<CU_B_PROFILE_ATTRIBUTE_LOOKUP> CU_B_PROFILE_ATTRIBUTE_LOOKUP { get; set; }
        public virtual DbSet<CU_B_VOUCHER_EXT_AUS> CU_B_VOUCHER_EXT_AUS { get; set; }
        public virtual DbSet<CU_S_AUDIOGRAM_RULE> CU_S_AUDIOGRAM_RULE { get; set; }
        public virtual DbSet<CU_S_AUDIOGRAM_TYPE> CU_S_AUDIOGRAM_TYPE { get; set; }
        public virtual DbSet<CU_S_CATEGORY> CU_S_CATEGORY { get; set; }
        public virtual DbSet<CU_S_CUSTOMER_TYPE_EXT_AUS> CU_S_CUSTOMER_TYPE_EXT_AUS { get; set; }
        public virtual DbSet<CU_S_DVA_CARD_TYPE_EXT_AUS> CU_S_DVA_CARD_TYPE_EXT_AUS { get; set; }
        public virtual DbSet<CU_S_HICONDITION> CU_S_HICONDITION { get; set; }
        public virtual DbSet<CU_S_OCCUPATION> CU_S_OCCUPATION { get; set; }
        public virtual DbSet<CU_S_SALUTATION> CU_S_SALUTATION { get; set; }
        public virtual DbSet<CU_S_STATUS> CU_S_STATUS { get; set; }
        public virtual DbSet<CU_S_TITLE> CU_S_TITLE { get; set; }
        public virtual DbSet<CU_S_TYPE> CU_S_TYPE { get; set; }
        public virtual DbSet<PD_S_PRODUCT> PD_S_PRODUCT { get; set; }
        public virtual DbSet<PD_S_PRODUCT_EXT_AUS> PD_S_PRODUCT_EXT_AUS { get; set; }
        public virtual DbSet<SY_ACTIVITY_TYPE> SY_ACTIVITY_TYPE { get; set; }
        public virtual DbSet<SY_DOCUMENT_TYPE> SY_DOCUMENT_TYPE { get; set; }
        public virtual DbSet<SY_GENDER> SY_GENDER { get; set; }
        public virtual DbSet<SY_GENERAL_STATUS> SY_GENERAL_STATUS { get; set; }
        public virtual DbSet<SY_LANGUAGE> SY_LANGUAGE { get; set; }
        public virtual DbSet<SY_SIDE> SY_SIDE { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CAU02DB01FOXSIT.D09.ROOT.SYS;Database=FoxAustralia_SIT2;Trusted_Connection=False;User ID=foxuser;Password=Df0x35ZZ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CM_B_ATTACHMENT>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE, e.ATTACHMENT_COUNTER, e.REASON_ID });

                entity.HasIndex(e => e.CUSTOMER_CODE)
                    .HasName("missing_index_17791");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_B_ATTACHMENT_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.ATTACHMENT_COUNTER })
                    .HasName("missing_index_39637");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.ATTACHMENT_TYPE_CODE })
                    .HasName("IDX_CM_B_ATTACHMENT_CM_S_ATTACHMENT_TYPE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE })
                    .HasName("IDX_CM_B_ATTACHMENT_CU_B_ADDRESS_BOOK");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DOCUMENT_NUMBER })
                    .HasName("missing_index_18020");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DOCUMENT_TYPE_CODE })
                    .HasName("IDX_CM_B_ATTACHMENT_SY_DOCUMENT_TYPE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE })
                    .HasName("IDX_CM_B_ATTACHMENT_CM_B_SHOP");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DOCUMENT_TYPE_CODE, e.DOCUMENT_NUMBER })
                    .HasName("missing_index_25975");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DOCUMENT_NUMBER, e.DOCUMENT_DATE, e.DOCUMENT_TYPE_CODE })
                    .HasName("missing_index_26896");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DOCUMENT_TYPE_CODE, e.DOCUMENT_NUMBER, e.DOCUMENT_DATE })
                    .HasName("missing_index_17805");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE, e.DOCUMENT_NUMBER, e.DOCUMENT_DATE })
                    .HasName("missing_index_24803");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE, e.ATTACHMENT_TYPE_CODE, e.DOCUMENT_TYPE_CODE, e.DOCUMENT_NUMBER, e.DOCUMENT_DATE })
                    .HasName("missing_index_25022");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SHOP_CODE).HasMaxLength(3);

                entity.Property(e => e.ATTACHMENT_DATE).HasColumnType("date");

                entity.Property(e => e.ATTACHMENT_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_CODE).HasMaxLength(8);

                entity.Property(e => e.DOCUMENT_DATE).HasColumnType("date");

                entity.Property(e => e.DOCUMENT_NUMBER).HasMaxLength(10);

                entity.Property(e => e.DOCUMENT_TYPE_CODE)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.DT_EXPIRATION).HasColumnType("datetime");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE_STATUS).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE_VALIDATION_STATUS).HasColumnType("datetime");

                entity.Property(e => e.REASON_CODE).HasMaxLength(3);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.STATUS_CODE).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.Property(e => e.VALIDATION_STATUS_CODE).HasMaxLength(3);

                entity.Property(e => e.VERSION).HasMaxLength(6);

                entity.HasOne(d => d.CM_S_ATTACHMENT_TYPE)
                    .WithMany(p => p.CM_B_ATTACHMENT)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.ATTACHMENT_TYPE_CODE })
                    .HasConstraintName("FK_CM_B_ATTACHMENT_CM_S_ATTACHMENT_TYPE");

                entity.HasOne(d => d.CU_B_ADDRESS_BOOK)
                    .WithMany(p => p.CM_B_ATTACHMENT)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_CODE })
                    .HasConstraintName("FK_CM_B_ATTACHMENT_CU_B_ADDRESS_BOOK");

                entity.HasOne(d => d.SY_DOCUMENT_TYPE)
                    .WithMany(p => p.CM_B_ATTACHMENT)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.DOCUMENT_TYPE_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CM_B_ATTACHMENT_SY_DOCUMENT_TYPE");

                entity.HasOne(d => d.CM_B_SHOP)
                    .WithMany(p => p.CM_B_ATTACHMENT)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.SHOP_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CM_B_ATTACHMENT_CM_B_SHOP");
            });

            modelBuilder.Entity<CM_B_ATTACHMENT_ARCHIVE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE, e.ATTACHMENT_COUNTER });

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE, e.ATTACHMENT_COUNTER })
                    .HasName("missing_index_12697");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SHOP_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CM_B_COUNTER>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE, e.LAPTOP_CODE, e.TABLE_NAME, e.FIELD_NAME });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_B_COUNTER_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.SHOP_CODE, e.LAPTOP_CODE, e.VALUE, e.COMPANY_CODE, e.DIVISION_CODE, e.TABLE_NAME, e.FIELD_NAME })
                    .HasName("missing_index_31919");

                entity.HasIndex(e => new { e.SHOP_CODE, e.VALUE, e.MIN_VALUE, e.MAX_VALUE, e.COMPANY_CODE, e.DIVISION_CODE, e.TABLE_NAME, e.FIELD_NAME })
                    .HasName("missing_index_31922");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SHOP_CODE).HasMaxLength(3);

                entity.Property(e => e.LAPTOP_CODE).HasMaxLength(3);

                entity.Property(e => e.TABLE_NAME).HasMaxLength(50);

                entity.Property(e => e.FIELD_NAME).HasMaxLength(50);

                entity.Property(e => e.DATEFIELDFORCHECK).HasMaxLength(50);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FLG_AUTOMOVENEXT).HasMaxLength(1);

                entity.Property(e => e.FLG_BASE36).HasMaxLength(1);

                entity.Property(e => e.FLG_MANUAL_RESET).HasMaxLength(1);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CM_B_SHOP>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE })
                    .HasName("PK_CM_SHOP");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_B_SHOP_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.ORGANIZATION_CODE })
                    .HasName("IDX_CM_B_SHOP_CM_S_ORGANIZATION");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_TYPE_CODE })
                    .HasName("IDX_CM_B_SHOP_SY_SHOP_TYPE");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SHOP_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FLG_ACTIVE).HasMaxLength(1);

                entity.Property(e => e.LEGAL_DESCR).HasMaxLength(255);

                entity.Property(e => e.OBJ_CODE).HasMaxLength(8);

                entity.Property(e => e.ORGANIZATION_CODE).HasMaxLength(3);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SHOP_DESCR).HasMaxLength(255);

                entity.Property(e => e.SHOP_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CM_S_AREA_BOOK>(entity =>
            {
                entity.HasKey(e => new { e.COUNTRY_CODE, e.AREA_CODE })
                    .HasName("PK_CM_AREA_BOOK");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_S_AREA_BOOK_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COUNTRY_CODE).HasMaxLength(3);

                entity.Property(e => e.AREA_CODE).HasMaxLength(3);

                entity.Property(e => e.AREA_DESCR).HasMaxLength(255);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.REGION_CODE).HasMaxLength(2);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CM_S_ATTACHMENT_DOCUMENT>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.ATTACHMENT_TYPE_CODE, e.DOCUMENT_TYPE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_S_ATTACHMENT_DOCUMENT_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DOCUMENT_TYPE_CODE })
                    .HasName("IDX_CM_S_ATTACHMENT_DOCUMENT_SY_DOCUMENT_TYPE");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.ATTACHMENT_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DOCUMENT_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FLG_DATE).HasColumnType("date");

                entity.Property(e => e.FLG_MANDATORY).HasMaxLength(1);

                entity.Property(e => e.FLG_NOTE).HasMaxLength(1);

                entity.Property(e => e.MARKET_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.CM_S_ATTACHMENT_TYPE)
                    .WithMany(p => p.CM_S_ATTACHMENT_DOCUMENT)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.ATTACHMENT_TYPE_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CM_S_ATTACHMENT_DOCUMENT_CM_S_ATTACHMENT_TYPE");

                entity.HasOne(d => d.SY_DOCUMENT_TYPE)
                    .WithMany(p => p.CM_S_ATTACHMENT_DOCUMENT)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.DOCUMENT_TYPE_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CM_S_ATTACHMENT_DOCUMENT_SY_DOCUMENT_TYPE");
            });

            modelBuilder.Entity<CM_S_ATTACHMENT_TYPE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.ATTACHMENT_TYPE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_S_ATTACHMENT_TYPE_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.ATTACHMENT_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.ATTACHMENT_TYPE_DESCR).HasMaxLength(255);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CM_S_CAMPAIGN>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CAMPAIGN_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_S_CAMPAIGN_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.CAMPAIGN_DESCR, e.CAMPAIGN_CODE })
                    .HasName("missing_index_10331");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CAMPAIGN_TYPE_CODE })
                    .HasName("IDX_CM_S_CAMPAIGN_CM_S_CAMPAIGN_TYPE");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CAMPAIGN_CODE).HasMaxLength(15);

                entity.Property(e => e.CAMPAIGN_DESCR).HasMaxLength(255);

                entity.Property(e => e.CAMPAIGN_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE_STATUS).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.STATUS_CODE).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CM_S_CITY_BOOK>(entity =>
            {
                entity.HasKey(e => new { e.COUNTRY_CODE, e.AREA_CODE, e.ZIP_CODE, e.CITY_COUNTER })
                    .HasName("PK_CM_CITY_BOOK");

                entity.HasIndex(e => e.CITY_NAME);

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_S_CITY_BOOK_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => e.ZIP_CODE);

                entity.HasIndex(e => new { e.COUNTRY_CODE, e.AREA_CODE })
                    .HasName("IDX_CM_S_CITY_BOOK_CM_S_AREA_BOOK");

                entity.Property(e => e.COUNTRY_CODE).HasMaxLength(3);

                entity.Property(e => e.AREA_CODE).HasMaxLength(3);

                entity.Property(e => e.ZIP_CODE).HasMaxLength(15);

                entity.Property(e => e.CITY_NAME).HasMaxLength(25);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.Property(e => e.ZIP_CODE_UNIQUE_ID).HasMaxLength(50);

                entity.HasOne(d => d.CM_S_AREA_BOOK)
                    .WithMany(p => p.CM_S_CITY_BOOK)
                    .HasForeignKey(d => new { d.COUNTRY_CODE, d.AREA_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CM_S_CITY_BOOK_CM_S_AREA_BOOK");
            });

            modelBuilder.Entity<CM_S_DAYCENTER>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DAYCENTER_CODE, e.SHOP_CODE });

                entity.HasIndex(e => e.DAYCENTER_DESCR)
                    .HasName("missing_index_11058");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_S_DAYCENTER_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.DAYCENTER_DESCR, e.DAYCENTER_CODE })
                    .HasName("missing_index_16109");

                entity.HasIndex(e => new { e.DAYCENTER_CODE, e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE })
                    .HasName("missing_index_2425");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DAYCENTER_CODE, e.SHOP_CODE, e.DT_INSERT, e.USERUPDATE, e.DT_UPDATE })
                    .HasName("missing_index_183");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.DAYCENTER_CODE).HasMaxLength(8);

                entity.Property(e => e.SHOP_CODE).HasMaxLength(3);

                entity.Property(e => e.ACCOUNTING_ID).HasMaxLength(8);

                entity.Property(e => e.DAYCENTER_DESCR).HasMaxLength(255);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.MARKETING_ID).HasMaxLength(8);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CM_S_DAYCENTER_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DAYCENTER_CODE, e.SHOP_CODE });

                entity.HasIndex(e => new { e.LOCATION_TYPE, e.DAYCENTER_CODE })
                    .HasName("missing_index_16107");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.DAYCENTER_CODE).HasMaxLength(8);

                entity.Property(e => e.SHOP_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.LOCATION_TYPE).HasMaxLength(3);

                entity.Property(e => e.OHS_SITE_ID).HasMaxLength(20);

                entity.Property(e => e.USERINSERT)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.USERUPDATE)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CM_S_EMPLOYEE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE, e.EMPLOYEE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_SY_EMPLOYEE_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => e.SHOP_CODE)
                    .HasName("missing_index_25008");

                entity.HasIndex(e => new { e.EMPLOYEE_CODE, e.EMPLOYEE_TYPE_CODE })
                    .HasName("missing_index_39947");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.EMPLOYEE_DESCR })
                    .HasName("missing_index_18085");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.EMPLOYEE_TYPE_CODE })
                    .HasName("IDX_CM_S_EMPLOYEE_SY_EMPLOYEE_TYPE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE, e.EMPLOYEE_TYPE_CODE })
                    .HasName("missing_index_25194");

                entity.HasIndex(e => new { e.EMPLOYEE_CODE, e.DT_START, e.DT_END, e.EMPLOYEE_TYPE_CODE })
                    .HasName("missing_index_18113");

                entity.HasIndex(e => new { e.SHOP_CODE, e.FIRSTNAME, e.LASTNAME, e.EMPLOYEE_CODE })
                    .HasName("IDX_CM_S_EMPLOYEE_001");

                entity.HasIndex(e => new { e.EMPLOYEE_CODE, e.COMPANY_CODE, e.DIVISION_CODE, e.EMPLOYEE_TYPE_CODE, e.DT_START, e.DT_END })
                    .HasName("IDX_GET_EMPLOYEE_WH");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SHOP_CODE).HasMaxLength(3);

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(8);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_DESCR).HasMaxLength(255);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(10);

                entity.Property(e => e.EMPLOYEE_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.FIRSTNAME).HasMaxLength(50);

                entity.Property(e => e.LASTNAME).HasMaxLength(50);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CM_S_MEDIATYPE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.MEDIATYPE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_S_MEDIATYPE_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.MEDIATYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.MEDIATYPE_DESCR).HasMaxLength(255);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CM_S_MP_DETAILS_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.PRACTICE_CODE, e.PRACTITIONER_CODE })
                    .HasName("PK__CM_S_MP___0DB319332BFE5503");

                entity.HasIndex(e => e.PRACTITIONER_CODE)
                    .HasName("missing_index_18133");

                entity.HasIndex(e => new { e.PRACTICE_CODE, e.PRACTITIONER_NAME })
                    .HasName("missing_index_24905");

                entity.HasIndex(e => new { e.PRACTITIONER_NAME, e.PRACTITIONER_CODE })
                    .HasName("missing_index_25375");

                entity.HasIndex(e => new { e.PRACTITIONER_NAME, e.COMPANY_CODE, e.DIVISION_CODE, e.PRACTITIONER_CODE })
                    .HasName("missing_index_18125");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.PRACTICE_CODE).HasMaxLength(10);

                entity.Property(e => e.PRACTITIONER_CODE).HasMaxLength(10);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.PRACTITIONER_NAME).HasMaxLength(100);

                entity.Property(e => e.PRACTITIONER_NUMBER).HasMaxLength(30);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CM_S_PRACTICE_DETAILS_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.PRACTICE_CODE })
                    .HasName("PK__CM_S_PRA__F6F64B541D1DADF0");

                entity.HasIndex(e => e.PRACTICE_CODE)
                    .HasName("missing_index_17732");

                entity.HasIndex(e => new { e.PRACTICE_NAME, e.PRACTICE_CODE })
                    .HasName("missing_index_24848");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.PRACTICE_CODE).HasMaxLength(8);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.PRACTICE_NAME).HasMaxLength(50);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CM_S_REFERENCE_SOURCE_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CODE, e.TYPE_CATEGORY_CODE });

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CODE).HasMaxLength(9);

                entity.Property(e => e.TYPE_CATEGORY_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DESCRIPTION).HasMaxLength(50);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.REF_CODE).HasMaxLength(9);

                entity.Property(e => e.REF_TYPE_CATEGORY_CODE).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(25);

                entity.Property(e => e.USERUPDATE).HasMaxLength(25);

                entity.HasOne(d => d.CU_S_TYPE)
                    .WithMany(p => p.CM_S_REFERENCE_SOURCE_EXT_AUS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_TYPE_CODE })
                    .HasConstraintName("FK_CM_S_REFERENCE_SOURCE_EXT_AUS_CU_S_TYPE");

                entity.HasOne(d => d.CM_S_REFERENCE_SOURCE_EXT_AUSNavigation)
                    .WithMany(p => p.InverseCM_S_REFERENCE_SOURCE_EXT_AUSNavigation)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.REF_CODE, d.REF_TYPE_CATEGORY_CODE })
                    .HasConstraintName("FK_CM_S_REFERENCE_SOURCE_EXT_AUS_CM_S_REFERENCE_SOURCE_EXT_AUS_REF");
            });

            modelBuilder.Entity<CM_S_STATE_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.STATE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_S_STATE_EXT_AUS_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.STATE_CODE })
                    .HasName("IX_CM_S_STATE_EXT_AUS")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.STATE_CODE).HasMaxLength(3);

                entity.Property(e => e.DEFAULT_AREA_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.STATE_NAME).HasMaxLength(50);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_B_ACTIVITY>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE, e.LAPTOP_CODE, e.CUSTOMER_CODE, e.ACTIVITY_ID, e.ACTIVITY_DATE });

                entity.HasIndex(e => e.ACTIVITY_TYPE_CODE)
                    .HasName("IX_ACTIVITY_TYPE_CODE");

                entity.HasIndex(e => e.APPOINTMENT_ID)
                    .HasName("#IDX_APPOINTMENTID_CU_B_ACTIVITY");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_B_ACTIVITY_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => e.activity_rv)
                    .HasName("idx_activity_rv")
                    .IsUnique();

                entity.HasIndex(e => new { e.REFERENCE_DATE, e.REFERENCE_NUMBER })
                    .HasName("IX_REF_NAME_REF_DATE");

                entity.HasIndex(e => new { e.ACTIVITY_TYPE_CODE, e.USERINSERT, e.USERUPDATE })
                    .HasName("missing_index_47679");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.ACTIVITY_TYPE_CODE })
                    .HasName("IDX_CU_B_ACTIVITY_SY_ACTIVITY_TYPE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CAMPAIGN_CODE })
                    .HasName("IDX_CU_B_ACTIVITY_CM_S_CAMPAIGN");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE })
                    .HasName("IDX_CU_B_ACTIVITY_CU_B_ADDRESS_BOOK");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.RECOMMENDEDBY_CODE })
                    .HasName("IDX_CU_B_ACTIVITY_CU_B_ADDRESS_BOOK_RECOMMENDED");

                entity.HasIndex(e => new { e.ACTIVITY_TYPE_CODE, e.DT_UPDATE, e.USERINSERT, e.USERUPDATE })
                    .HasName("missing_index_47681");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.REFERENCE_NUMBER, e.ACTIVITY_TYPE_CODE })
                    .HasName("missing_index_47537");

                entity.HasIndex(e => new { e.SHOP_CODE, e.LAPTOP_CODE, e.ACTIVITY_ID, e.ACTIVITY_DATE, e.CUSTOMER_CODE, e.ACTIVITY_TYPE_CODE, e.EMPLOYEE_CODE, e.CAMPAIGN_CODE, e.PROMOTER_CODE, e.PHYSICIAN_MG_CODE, e.PHYSICIAN_ORL_CODE, e.LOCATION_TYPE_CODE, e.LOCATION_CODE, e.MEDIATYPE_CODE, e.NOTE, e.REFERENCE_DATE, e.TESTRESULT_LEFT, e.TESTRESULT_RIGHT, e.APPOINTMENT_ID, e.RESULT_CODE, e.REASON_CODE, e.DT_EXAM, e.DT_INSERT, e.USERINSERT, e.DT_UPDATE, e.USERUPDATE, e.ROWGUID, e.COMPANY_CODE, e.DIVISION_CODE, e.REFERENCE_NUMBER })
                    .HasName("IDX_CU_B_ACTIVITY_GetListByAppointmentId");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SHOP_CODE).HasMaxLength(3);

                entity.Property(e => e.LAPTOP_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_CODE).HasMaxLength(8);

                entity.Property(e => e.ACTIVITY_DATE).HasColumnType("date");

                entity.Property(e => e.ACTIVITY_TYPE_CODE)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.APPOINTMENT_ID).HasMaxLength(10);

                entity.Property(e => e.CAMPAIGN_CODE).HasMaxLength(15);

                entity.Property(e => e.DAYCENTER_CODE).HasMaxLength(8);

                entity.Property(e => e.DT_EXAM).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(8);

                entity.Property(e => e.LOCATION_CODE).HasMaxLength(8);

                entity.Property(e => e.LOCATION_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.MEDIATYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.NOTE).HasColumnType("nvarchar(max)");

                entity.Property(e => e.PHYSICIAN_MG_CODE).HasMaxLength(8);

                entity.Property(e => e.PHYSICIAN_ORL_CODE).HasMaxLength(8);

                entity.Property(e => e.PROMOTER_CODE).HasMaxLength(6);

                entity.Property(e => e.REASON_CODE).HasMaxLength(3);

                entity.Property(e => e.RECOMMENDEDBY_CODE).HasMaxLength(8);

                entity.Property(e => e.REFERENCE_DATE).HasColumnType("date");

                entity.Property(e => e.REFERENCE_NUMBER).HasMaxLength(15);

                entity.Property(e => e.RESULT_CODE).HasMaxLength(3);

                entity.Property(e => e.TESTRESULT_LEFT).HasMaxLength(2);

                entity.Property(e => e.TESTRESULT_RIGHT).HasMaxLength(2);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.Property(e => e.activity_rv)
                    .IsRequired()
                    .IsRowVersion();

                entity.HasOne(d => d.SY_ACTIVITY_TYPE)
                    .WithMany(p => p.CU_B_ACTIVITY)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.ACTIVITY_TYPE_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_ACTIVITY_SY_ACTIVITY_TYPE");

                entity.HasOne(d => d.CM_S_CAMPAIGN)
                    .WithMany(p => p.CU_B_ACTIVITY)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CAMPAIGN_CODE })
                    .HasConstraintName("FK_CU_B_ACTIVITY_CM_S_CAMPAIGN");

                entity.HasOne(d => d.CU_B_ADDRESS_BOOK)
                    .WithMany(p => p.CU_B_ACTIVITYCU_B_ADDRESS_BOOK)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_ACTIVITY_CU_B_ADDRESS_BOOK");

                entity.HasOne(d => d.CM_S_MEDIATYPE)
                    .WithMany(p => p.CU_B_ACTIVITY)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.MEDIATYPE_CODE })
                    .HasConstraintName("FK_CU_B_ACTIVITY_CM_S_MEDIATYPE");

                entity.HasOne(d => d.CU_B_ADDRESS_BOOKNavigation)
                    .WithMany(p => p.CU_B_ACTIVITYCU_B_ADDRESS_BOOKNavigation)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.RECOMMENDEDBY_CODE })
                    .HasConstraintName("FK_CU_B_ACTIVITY_CU_B_ADDRESS_BOOK_RECOMMENDED");
            });

            modelBuilder.Entity<CU_B_ACTIVITY_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.ACTIVITY_DATE, e.ACTIVITY_ID, e.COMPANY_CODE, e.CUSTOMER_CODE, e.DIVISION_CODE, e.LAPTOP_CODE, e.SHOP_CODE })
                    .HasName("PK__CU_B_ACT__E8C26A5EF3D359E6");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("missing_index_39328");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE })
                    .HasName("missing_index_39331");

                entity.HasIndex(e => new { e.ACTIVITY_ID, e.DT_APPOINTEMENT_FROM, e.DT_APPOINTEMENT_TO, e.COMPANY_CODE, e.DIVISION_CODE })
                    .HasName("IDX_CU_B_ACTIVITY_EXT_AUS_COMPANY_CODE_DIVISION_CODE");

                entity.HasIndex(e => new { e.DT_APPOINTEMENT_FROM, e.DT_APPOINTEMENT_TO, e.COMPANY_CODE, e.DIVISION_CODE, e.ACTIVITY_ID })
                    .HasName("IX_CU_B_ACTIVITY_EXT_AUS_Comp_Div_Act_Id");

                entity.Property(e => e.ACTIVITY_DATE).HasColumnType("date");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_CODE).HasMaxLength(8);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.LAPTOP_CODE).HasMaxLength(3);

                entity.Property(e => e.SHOP_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_APPOINTEMENT_FROM).HasColumnType("datetime");

                entity.Property(e => e.DT_APPOINTEMENT_TO).HasColumnType("datetime");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.SUB_REASON_CODE).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.CU_B_ADDRESS_BOOK)
                    .WithMany(p => p.CU_B_ACTIVITY_EXT_AUS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_ACTIVITY_EXT_AUS_CU_B_ADDRESS_BOOK");

                entity.HasOne(d => d.CM_B_SHOP)
                    .WithMany(p => p.CU_B_ACTIVITY_EXT_AUS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.SHOP_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_ACTIVITY_EXT_AUS_CM_B_SHOP");
            });

            modelBuilder.Entity<CU_B_ADDRESS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE, e.ADDRESS_COUNTER });

                entity.HasIndex(e => e.CUSTOMER_CODE)
                    .HasName("CU_B_ADDRES_CUSTOMER_CODE_IDX");

                entity.HasIndex(e => e.MOBILE);

                entity.HasIndex(e => e.PHONE1);

                entity.HasIndex(e => e.PHONE2);

                entity.HasIndex(e => e.PHONE3);

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_B_ADDRESS_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE })
                    .HasName("IDX_CU_B_ADDRESS_CU_B_ADDRESS_BOOK");

                entity.HasIndex(e => new { e.COUNTRY_CODE, e.AREA_CODE, e.ZIP_CODE, e.CITY_COUNTER })
                    .HasName("IDX_CU_B_ADDRESS_CM_S_CITY_BOOK");

                entity.HasIndex(e => new { e.MOBILE, e.PHONE1, e.PHONE2, e.PHONE3 })
                    .HasName("IX_CU_B_ADDRESS_ALLPHONES");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_CODE).HasMaxLength(8);

                entity.Property(e => e.ADDRESS_CODE).HasMaxLength(50);

                entity.Property(e => e.ADDRESS_LINE1).HasMaxLength(100);

                entity.Property(e => e.ADDRESS_LINE2).HasMaxLength(100);

                entity.Property(e => e.ADDRESS_LINE3).HasMaxLength(100);

                entity.Property(e => e.ADDRESS_LINE4).HasMaxLength(100);

                entity.Property(e => e.AREA_CODE).HasMaxLength(3);

                entity.Property(e => e.CITY_NAME).HasMaxLength(50);

                entity.Property(e => e.COUNTRY_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.EMAIL).HasMaxLength(100);

                entity.Property(e => e.FLG_INVOICE_DEFAULT).HasMaxLength(1);

                entity.Property(e => e.FLG_LETTER_DEFAULT).HasMaxLength(1);

                entity.Property(e => e.FLG_NORMALIZED).HasMaxLength(1);

                entity.Property(e => e.FLG_OTHER_CONTACT).HasMaxLength(1);

                entity.Property(e => e.LOCALITY).HasMaxLength(50);

                entity.Property(e => e.MOBILE).HasMaxLength(100);

                entity.Property(e => e.PHONE1).HasMaxLength(100);

                entity.Property(e => e.PHONE2).HasMaxLength(100);

                entity.Property(e => e.PHONE3).HasMaxLength(100);

                entity.Property(e => e.PO_BOX).HasMaxLength(30);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.Property(e => e.ZIP_CODE).HasMaxLength(15);

                entity.HasOne(d => d.CU_B_ADDRESS_BOOK)
                    .WithMany(p => p.CU_B_ADDRESS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_ADDRESS_CU_B_ADDRESS_BOOK");

                entity.HasOne(d => d.CM_S_CITY_BOOK)
                    .WithMany(p => p.CU_B_ADDRESS)
                    .HasForeignKey(d => new { d.COUNTRY_CODE, d.AREA_CODE, d.ZIP_CODE, d.CITY_COUNTER })
                    .HasConstraintName("FK_CU_B_ADDRESS_CM_S_CITY_BOOK");
            });

            modelBuilder.Entity<CU_B_ADDRESS_BOOK>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE });

                entity.HasIndex(e => e.BIRTHDATE)
                    .HasName("IX_CU_B_ADDRESS_BOOK_BIRTDATE");

                entity.HasIndex(e => e.CUSTOMER_CODE)
                    .HasName("IDX_CU_B_ADDRESS_BOOK_CU_S_CUSTOMER_CODE");

                entity.HasIndex(e => e.CUSTOMER_ID)
                    .HasName("IX_CUSTOMER_ID");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_B_ADDRESS_BOOK_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.LASTNAME, e.FIRSTNAME })
                    .HasName("IX_LASTNAME_FIRSTNAME");

                entity.HasIndex(e => new { e.CATEGORY_CODE, e.LASTNAME, e.FIRSTNAME })
                    .HasName("IX_CU_B_ADDRESS_BOOK_FIRSTNAMELASTNAME");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CATEGORY_CODE })
                    .HasName("IDX_CU_B_ADDRESS_BOOK_CU_S_CATEGORY");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_TYPE_CODE })
                    .HasName("IDX_CU_B_ADDRESS_BOOK_CU_S_TYPE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.GENDER_CODE })
                    .HasName("IDX_CU_B_ADDRESS_BOOK_SY_GENDER");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SALUTATION_CODE })
                    .HasName("IDX_CU_B_ADDRESS_BOOK_CU_S_SALUTATION");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.STATUS_CODE })
                    .HasName("IDX_CU_B_ADDRESS_BOOK_CU_S_STATUS");

                entity.HasIndex(e => new { e.CUSTOMER_CODE, e.LASTNAME, e.CUSTOMER_ID, e.COMPANY_CODE, e.DIVISION_CODE, e.CATEGORY_CODE })
                    .HasName("IX_CU_B_ADDRESS_BOOK_COMPANY_CODE_DIVISION_CODE_CATEGORY_CODE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE, e.CATEGORY_CODE, e.CUSTOMER_TYPE_CODE, e.FLG_NON_HA_PURCHASE, e.DT_INSERT, e.USERUPDATE, e.DT_UPDATE })
                    .HasName("IX_CU_B_ADDRESS_BOOK");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_CODE).HasMaxLength(8);

                entity.Property(e => e.BIRTHDATE).HasColumnType("date");

                entity.Property(e => e.BIRTHLOCATION).HasMaxLength(50);

                entity.Property(e => e.CATEGORY_CODE).HasMaxLength(3);

                entity.Property(e => e.COUNTRY_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_ID).HasMaxLength(100);

                entity.Property(e => e.CUSTOMER_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DEFAULT_PRICELIST_CODE).HasMaxLength(3);

                entity.Property(e => e.DISABILITY_CODE).HasMaxLength(2);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_PRIVACY_HQ_VALIDATION).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE_CUSTOMERTYPE).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE_STATUS).HasColumnType("datetime");

                entity.Property(e => e.DUPLICATE_CODE).HasMaxLength(8);

                entity.Property(e => e.FIRSTNAME).HasMaxLength(100);

                entity.Property(e => e.FLG_ADVERTISING).HasMaxLength(1);

                entity.Property(e => e.FLG_NON_HA_PURCHASE).HasMaxLength(1);

                entity.Property(e => e.FLG_PRIVACYPERSDATA).HasMaxLength(1);

                entity.Property(e => e.FLG_PROFILING).HasMaxLength(1);

                entity.Property(e => e.FLG_RETIRED).HasMaxLength(1);

                entity.Property(e => e.FLG_SENSDATA).HasMaxLength(1);

                entity.Property(e => e.FLG_TAX_EXEMPT).HasMaxLength(1);

                entity.Property(e => e.GENDER_CODE).HasMaxLength(1);

                entity.Property(e => e.LANGUAGE_CODE).HasMaxLength(5);

                entity.Property(e => e.LASTNAME).HasMaxLength(100);

                entity.Property(e => e.MIDDLENAME).HasMaxLength(100);

                entity.Property(e => e.OCCUPATION_CODE).HasMaxLength(3);

                entity.Property(e => e.OCCUPATION_OTHER).HasMaxLength(100);

                entity.Property(e => e.OTHERCONTACT_FIRSTNAME).HasMaxLength(100);

                entity.Property(e => e.OTHERCONTACT_LASTNAME).HasMaxLength(100);

                entity.Property(e => e.RELATION).HasMaxLength(50);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SALUTATION_CODE).HasMaxLength(3);

                entity.Property(e => e.STATUS_CODE).HasMaxLength(3);

                entity.Property(e => e.TAX_ID_NUMBER).HasMaxLength(100);

                entity.Property(e => e.TITLE_CODE).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.CU_S_CATEGORY)
                    .WithMany(p => p.CU_B_ADDRESS_BOOK)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CATEGORY_CODE })
                    .HasConstraintName("FK_CU_B_ADDRESS_BOOK_CU_S_CATEGORY");

                entity.HasOne(d => d.CU_S_TYPE)
                    .WithMany(p => p.CU_B_ADDRESS_BOOK)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_TYPE_CODE })
                    .HasConstraintName("FK_CU_B_ADDRESS_BOOK_CU_S_TYPE");

                entity.HasOne(d => d.SY_GENDER)
                    .WithMany(p => p.CU_B_ADDRESS_BOOK)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.GENDER_CODE })
                    .HasConstraintName("FK_CU_B_ADDRESS_BOOK_SY_GENDER");

                entity.HasOne(d => d.CU_S_OCCUPATION)
                    .WithMany(p => p.CU_B_ADDRESS_BOOK)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.OCCUPATION_CODE })
                    .HasConstraintName("FK_CU_B_ADDRESS_BOOK_CU_S_OCCUPATION");

                entity.HasOne(d => d.CU_S_SALUTATION)
                    .WithMany(p => p.CU_B_ADDRESS_BOOK)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.SALUTATION_CODE })
                    .HasConstraintName("FK_CU_B_ADDRESS_BOOK_CU_S_SALUTATION");

                entity.HasOne(d => d.CU_S_STATUS)
                    .WithMany(p => p.CU_B_ADDRESS_BOOK)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.STATUS_CODE })
                    .HasConstraintName("FK_CU_B_ADDRESS_BOOK_CU_S_STATUS");

                entity.HasOne(d => d.CU_S_TITLE)
                    .WithMany(p => p.CU_B_ADDRESS_BOOK)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.TITLE_CODE })
                    .HasConstraintName("FK_CU_B_ADDRESS_BOOK_CU_S_TITLE");
            });

            modelBuilder.Entity<CU_B_ADDRESS_BOOK_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE });

                entity.HasIndex(e => e.BPAY_CRN)
                    .HasName("missing_index_8382");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("missing_index_10492");

                entity.HasIndex(e => e.SHOP_CODE);

                entity.HasIndex(e => new { e.TYPE_CODE, e.SHOP_CODE, e.IS_TOPUP, e.CUSTOMER_CODE })
                    .HasName("IDX_CU_B_ADDRESS_BOOK_CUSTOMER_CODE");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_CODE).HasMaxLength(8);

                entity.Property(e => e.BPAY_CRN).HasMaxLength(20);

                entity.Property(e => e.CONTACTED_ON).HasColumnType("datetime");

                entity.Property(e => e.CURRENT_FILE_LOCATION)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CURRENT_LOCATION_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_ARCHIVE_REQUESTED).HasColumnType("datetime");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_REGISTERED).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE_VALIDATION_STATUS).HasColumnType("datetime");

                entity.Property(e => e.DVA_CARD_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DVA_CLIENT_NUMBER).HasMaxLength(12);

                entity.Property(e => e.ELIGIBILITY_CODE).HasMaxLength(10);

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(8);

                entity.Property(e => e.FLG_ARCHIVE_REQUESTED).HasMaxLength(1);

                entity.Property(e => e.FLG_LOST_OHS_ELIGIBILITY).HasMaxLength(1);

                entity.Property(e => e.FLG_MIGRATED_FROM_VC).HasMaxLength(1);

                entity.Property(e => e.FLG_TO_CALL).HasMaxLength(1);

                entity.Property(e => e.IDCALL).HasMaxLength(100);

                entity.Property(e => e.IS_CONTENT_INSURANCE).HasMaxLength(1);

                entity.Property(e => e.IS_DVA).HasMaxLength(1);

                entity.Property(e => e.IS_TOPUP)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Is_MCLRecieved).HasMaxLength(1);

                entity.Property(e => e.JOURNEY_STAGE_CODE).HasMaxLength(3);

                entity.Property(e => e.NOTES).HasColumnType("text");

                entity.Property(e => e.OLD_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.OUTCOMEID).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PRACTICE_CODE).HasMaxLength(10);

                entity.Property(e => e.PRACTITIONER_CODE).HasMaxLength(10);

                entity.Property(e => e.PREFERREDNAME).HasMaxLength(50);

                entity.Property(e => e.PREV_ALD_DVA).HasMaxLength(1);

                entity.Property(e => e.PRIVACY_CONSENT_SIGNED).HasMaxLength(1);

                entity.Property(e => e.REF_SOURCE_CODE).HasMaxLength(9);

                entity.Property(e => e.RELATION).HasMaxLength(20);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SHOP_CODE).HasMaxLength(3);

                entity.Property(e => e.SOURCE_CODE).HasMaxLength(9);

                entity.Property(e => e.SUB_SOURCE_CODE).HasMaxLength(9);

                entity.Property(e => e.TYPE_CODE)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.Property(e => e.VALIDATION_STATUS_CODE).HasMaxLength(3);

                entity.HasOne(d => d.CU_B_ADDRESS_BOOK)
                    .WithOne(p => p.CU_B_ADDRESS_BOOK_EXT_AUS)
                    .HasForeignKey<CU_B_ADDRESS_BOOK_EXT_AUS>(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_ADDRESS_BOOK_EXT_AUS_CU_B_ADDRESS_BOOK");

                entity.HasOne(d => d.CM_B_SHOP)
                    .WithMany(p => p.CU_B_ADDRESS_BOOK_EXT_AUS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.SHOP_CODE })
                    .HasConstraintName("FK_CU_B_ADDRESS_BOOK_EXT_AUS_CM_B_SHOP");

                entity.HasOne(d => d.CU_S_CUSTOMER_TYPE_EXT_AUS)
                    .WithMany(p => p.CU_B_ADDRESS_BOOK_EXT_AUS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.TYPE_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_ADDRESS_BOOK_EXT_AUS_CU_S_CUSTOMER_TYPE_EXT_AUS");

                entity.HasOne(d => d.CM_S_MP_DETAILS_EXT_AUS)
                    .WithMany(p => p.CU_B_ADDRESS_BOOK_EXT_AUS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.PRACTICE_CODE, d.PRACTITIONER_CODE })
                    .HasConstraintName("FK_CU_B_ADDRESS_BOOK_EXT_AUS_CM_S_MP_DETAILS_EXT_AUS");

                entity.HasOne(d => d.CM_S_EMPLOYEE)
                    .WithMany(p => p.CU_B_ADDRESS_BOOK_EXT_AUS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.SHOP_CODE, d.EMPLOYEE_CODE })
                    .HasConstraintName("FK_CU_B_ADDRESS_BOOK_EXT_AUS_CM_S_EMPLOYEE");
            });

            modelBuilder.Entity<CU_B_ADDRESS_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE, e.ADDRESS_COUNTER });

                entity.HasIndex(e => e.CUSTOMER_CODE)
                    .HasName("missing_index_41");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("missing_index_9849");

                entity.HasIndex(e => new { e.CUSTOMER_CODE, e.ADDRESS_COUNTER })
                    .HasName("missing_index_1891");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE, e.STATE_CODE, e.ADDRESS_COUNTER })
                    .HasName("missing_index_13714");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE, e.DT_INSERT, e.USERUPDATE, e.FLG_HOME_VISIT_DEFAULT, e.DT_UPDATE })
                    .HasName("missing_index_108");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_CODE).HasMaxLength(8);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FLG_HOME_VISIT_DEFAULT)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.HOMEVISIT_CONTACTNAME).HasMaxLength(100);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.STATE_CODE).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.CM_S_STATE_EXT_AUS)
                    .WithMany(p => p.CU_B_ADDRESS_EXT_AUS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.STATE_CODE })
                    .HasConstraintName("FK_CU_B_ADDRESS_EXT_AUS_CM_S_STATE_EXT_AUS");

                entity.HasOne(d => d.CU_B_ADDRESS)
                    .WithOne(p => p.CU_B_ADDRESS_EXT_AUS)
                    .HasForeignKey<CU_B_ADDRESS_EXT_AUS>(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_CODE, d.ADDRESS_COUNTER })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_ADDRESS_EXT_AUS_CU_B_ADDRESS");
            });

            modelBuilder.Entity<CU_B_AUDIOGRAM>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE, e.ACTIVITY_DATE, e.TYPE_CODE, e.TYPE_OUT_CODE, e.HICONDITION_CODE, e.SIDE_CODE, e.FRAME });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_B_AUDIOGRAM_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE })
                    .HasName("IDX_CU_B_AUDIOGRAM_CU_B_ADDRESS_BOOK");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SIDE_CODE })
                    .HasName("IDX_CU_B_AUDIOGRAM_SY_SIDE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.TYPE_CODE })
                    .HasName("IDX_CU_B_AUDIOGRAM_CU_S_AUDIOGRAM_TYPE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE, e.ACTIVITY_DATE, e.DT_INSERT, e.USERUPDATE, e.DT_UPDATE })
                    .HasName("missing_index_47509");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_CODE).HasMaxLength(8);

                entity.Property(e => e.ACTIVITY_DATE).HasColumnType("date");

                entity.Property(e => e.SIDE_CODE).HasMaxLength(1);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FLGMASK_1).HasMaxLength(1);

                entity.Property(e => e.FLGMASK_10).HasMaxLength(1);

                entity.Property(e => e.FLGMASK_11).HasMaxLength(1);

                entity.Property(e => e.FLGMASK_12).HasMaxLength(1);

                entity.Property(e => e.FLGMASK_13).HasMaxLength(1);

                entity.Property(e => e.FLGMASK_14).HasMaxLength(1);

                entity.Property(e => e.FLGMASK_15).HasMaxLength(1);

                entity.Property(e => e.FLGMASK_2).HasMaxLength(1);

                entity.Property(e => e.FLGMASK_3).HasMaxLength(1);

                entity.Property(e => e.FLGMASK_4).HasMaxLength(1);

                entity.Property(e => e.FLGMASK_5).HasMaxLength(1);

                entity.Property(e => e.FLGMASK_6).HasMaxLength(1);

                entity.Property(e => e.FLGMASK_7).HasMaxLength(1);

                entity.Property(e => e.FLGMASK_8).HasMaxLength(1);

                entity.Property(e => e.FLGMASK_9).HasMaxLength(1);

                entity.Property(e => e.FLGNOANSWER_1).HasMaxLength(1);

                entity.Property(e => e.FLGNOANSWER_10).HasMaxLength(1);

                entity.Property(e => e.FLGNOANSWER_11).HasMaxLength(1);

                entity.Property(e => e.FLGNOANSWER_12).HasMaxLength(1);

                entity.Property(e => e.FLGNOANSWER_13).HasMaxLength(1);

                entity.Property(e => e.FLGNOANSWER_14).HasMaxLength(1);

                entity.Property(e => e.FLGNOANSWER_15).HasMaxLength(1);

                entity.Property(e => e.FLGNOANSWER_2).HasMaxLength(1);

                entity.Property(e => e.FLGNOANSWER_3).HasMaxLength(1);

                entity.Property(e => e.FLGNOANSWER_4).HasMaxLength(1);

                entity.Property(e => e.FLGNOANSWER_5).HasMaxLength(1);

                entity.Property(e => e.FLGNOANSWER_6).HasMaxLength(1);

                entity.Property(e => e.FLGNOANSWER_7).HasMaxLength(1);

                entity.Property(e => e.FLGNOANSWER_8).HasMaxLength(1);

                entity.Property(e => e.FLGNOANSWER_9).HasMaxLength(1);

                entity.Property(e => e.MATERIAL).HasMaxLength(50);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.CU_B_ADDRESS_BOOK)
                    .WithMany(p => p.CU_B_AUDIOGRAM)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_AUDIOGRAM_CU_B_ADDRESS_BOOK");

                entity.HasOne(d => d.SY_SIDE)
                    .WithMany(p => p.CU_B_AUDIOGRAM)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.SIDE_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_AUDIOGRAM_SY_SIDE");

                entity.HasOne(d => d.CU_S_AUDIOGRAM_TYPE)
                    .WithMany(p => p.CU_B_AUDIOGRAM)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.TYPE_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_AUDIOGRAM_CU_S_AUDIOGRAM_TYPE");
            });

            modelBuilder.Entity<CU_B_HA_ITEM_HISTORY>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE, e.PRODUCT_CODE, e.SERIAL_NUMBER });

                entity.HasIndex(e => e.CUSTOMER_CODE);

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_B_HA_ITEM_HISTORY_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.DOCUMENT_NUMBER, e.SIDE_CODE });

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.COVERAGE_TYPE_CODE })
                    .HasName("IDX_CU_B_HA_ITEM_HISTORY_CU_S_COVERAGE_TYPE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE })
                    .HasName("IDX_CU_B_HA_ITEM_HISTORY_CU_B_ADDRESS_BOOK");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.PRODUCT_CODE })
                    .HasName("IDX_CU_B_HA_ITEM_HISTORY_PD_S_PRODUCT");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE, e.PRODUCT_CODE, e.SERIAL_NUMBER, e.DT_INSERT, e.USERUPDATE, e.DT_UPDATE })
                    .HasName("missing_index_47528");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_CODE).HasMaxLength(8);

                entity.Property(e => e.PRODUCT_CODE).HasMaxLength(8);

                entity.Property(e => e.SERIAL_NUMBER).HasMaxLength(15);

                entity.Property(e => e.COMPETITOR_CODE).HasMaxLength(3);

                entity.Property(e => e.COVERAGE_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DELIVERY_DATE).HasColumnType("date");

                entity.Property(e => e.DOCUMENT_DATE).HasColumnType("date");

                entity.Property(e => e.DOCUMENT_NUMBER).HasMaxLength(6);

                entity.Property(e => e.DOCUMENT_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_STATUS_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.EXT_WARRANTY_END_DATE).HasColumnType("date");

                entity.Property(e => e.EXT_WARRANTY_NUMBER).HasMaxLength(8);

                entity.Property(e => e.EXT_WARRANTY_START_DATE).HasColumnType("date");

                entity.Property(e => e.FUND_END_DATE).HasColumnType("date");

                entity.Property(e => e.FUND_START_DATE).HasColumnType("date");

                entity.Property(e => e.ITEM_STATUS_CODE).HasMaxLength(2);

                entity.Property(e => e.MARKET_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.ORIGINAL_DOCUMENT_DATE).HasColumnType("date");

                entity.Property(e => e.ORIGINAL_DOCUMENT_NUMBER).HasMaxLength(6);

                entity.Property(e => e.ORIGINAL_DOCUMENT_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.ORIGINAL_SERIAL_NUMBER).HasMaxLength(15);

                entity.Property(e => e.PURCHASE_DATE).HasColumnType("date");

                entity.Property(e => e.PURCHASE_NUMBER).HasMaxLength(6);

                entity.Property(e => e.PURCHASE_RECEIVING_DATE).HasColumnType("date");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SALE_PRICELIST_CODE).HasMaxLength(3);

                entity.Property(e => e.SIDE_CODE).HasMaxLength(1);

                entity.Property(e => e.SUPPORTED_PRODUCT_CODE).HasMaxLength(8);

                entity.Property(e => e.SUPPORTED_SERIAL_NUMBER).HasMaxLength(15);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.Property(e => e.WARRANTY_END_DATE).HasColumnType("date");

                entity.Property(e => e.WARRANTY_START_DATE).HasColumnType("date");

                entity.HasOne(d => d.CU_B_ADDRESS_BOOK)
                    .WithMany(p => p.CU_B_HA_ITEM_HISTORY)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_HA_ITEM_HISTORY_CU_B_ADDRESS_BOOK");

                entity.HasOne(d => d.SY_DOCUMENT_TYPE)
                    .WithMany(p => p.CU_B_HA_ITEM_HISTORYSY_DOCUMENT_TYPE)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.DOCUMENT_TYPE_CODE })
                    .HasConstraintName("FK_CU_B_HA_ITEM_HISTORY_DOCUMENT_SY_DOCUMENT_TYPE");

                entity.HasOne(d => d.SY_DOCUMENT_TYPENavigation)
                    .WithMany(p => p.CU_B_HA_ITEM_HISTORYSY_DOCUMENT_TYPENavigation)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.ORIGINAL_DOCUMENT_TYPE_CODE })
                    .HasConstraintName("FK_CU_B_HA_ITEM_HISTORY_ORIGINAL_DOCUMENT_SY_DOCUMENT_TYPE");

                entity.HasOne(d => d.PD_S_PRODUCT)
                    .WithMany(p => p.CU_B_HA_ITEM_HISTORY)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.PRODUCT_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_HA_ITEM_HISTORY_PD_S_PRODUCT");

                entity.HasOne(d => d.SY_SIDE)
                    .WithMany(p => p.CU_B_HA_ITEM_HISTORY)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.SIDE_CODE })
                    .HasConstraintName("FK_CU_B_HA_ITEM_HISTORY_SY_SIDE");
            });

            modelBuilder.Entity<CU_B_HA_ITEM_HISTORY_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE, e.PRODUCT_CODE, e.SERIAL_NUMBER });

                entity.HasIndex(e => e.CUSTOMER_CODE)
                    .HasName("missing_index_10264");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_B_HA_ITEM_HISTORY_EXT_AUS_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => e.SERIAL_NUMBER)
                    .HasName("missing_index_39223");

                entity.HasIndex(e => new { e.CUSTOMER_CODE, e.PRODUCT_CODE })
                    .HasName("missing_index_10309");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_CODE).HasMaxLength(8);

                entity.Property(e => e.PRODUCT_CODE).HasMaxLength(8);

                entity.Property(e => e.SERIAL_NUMBER).HasMaxLength(15);

                entity.Property(e => e.ADDITIONAL_NOTES).HasMaxLength(255);

                entity.Property(e => e.BATTERY_SIZE_CODE).HasMaxLength(3);

                entity.Property(e => e.DM_SIDE_CODE).HasMaxLength(1);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FITTING_DATE).HasColumnType("datetime");

                entity.Property(e => e.IS_DBR).HasMaxLength(1);

                entity.Property(e => e.IS_LOST).HasMaxLength(1);

                entity.Property(e => e.IS_WRITE_OFF).HasMaxLength(1);

                entity.Property(e => e.MAINTENANCE_PLAN_ID).HasMaxLength(8);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SERIAL_NUMBER_VC).HasMaxLength(30);

                entity.Property(e => e.SHELLREMAKE_DATE).HasColumnType("datetime");

                entity.Property(e => e.TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.Property(e => e.VOUCHER_NUMBER).HasMaxLength(19);

                entity.Property(e => e.WRITEOFF_DATE).HasColumnType("datetime");

                entity.Property(e => e.WRITEOFF_REASON).HasMaxLength(3);

                entity.HasOne(d => d.CU_B_ADDRESS_BOOK)
                    .WithMany(p => p.CU_B_HA_ITEM_HISTORY_EXT_AUS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_HA_ITEM_HISTORY_EXT_AUS_CU_B_ADDRESS_BOOK");

                entity.HasOne(d => d.PD_S_PRODUCT)
                    .WithMany(p => p.CU_B_HA_ITEM_HISTORY_EXT_AUS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.PRODUCT_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_HA_ITEM_HISTORY_EXT_AUS_PD_S_PRODUCT");

                entity.HasOne(d => d.CU_S_CUSTOMER_TYPE_EXT_AUS)
                    .WithMany(p => p.CU_B_HA_ITEM_HISTORY_EXT_AUS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.TYPE_CODE })
                    .HasConstraintName("FK_CU_B_HA_ITEM_HISTORY_EXT_AUS_CU_S_CUSTOMER_TYPE_EXT_AUS");
            });

            modelBuilder.Entity<CU_B_LEAD_ADDRESS_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.XID, e.ADDRESSTYPE });

                entity.HasIndex(e => e.MOBILENUMBER);

                entity.HasIndex(e => e.PHONE2);

                entity.HasIndex(e => e.PHONE3);

                entity.HasIndex(e => e.PHONENUMBER);

                entity.HasIndex(e => new { e.XID, e.ADDRESSTYPE })
                    .HasName("IX_XID_ADDRESSTYPE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.XID, e.ADDRESSTYPE, e.ADDRESSLINE1, e.ADDRESSLINE2, e.ADDRESSLINE3, e.ADDRESSLINE4, e.SUBURB, e.STATECODE, e.ZIPCODE, e.COUNTRY_CODE, e.PHONENUMBER, e.EMAIL, e.PHONE2, e.PHONE3, e.DT_INSERT, e.USERINSERT, e.DT_UPDATE, e.USERUPDATE, e.ROWGUID, e.MOBILENUMBER })
                    .HasName("IX_CU_B_LEAD_ADDRESS_EXT_AUS_MOBILENUMBER_8F712");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.XID, e.ADDRESSTYPE, e.ADDRESSLINE1, e.ADDRESSLINE2, e.ADDRESSLINE3, e.ADDRESSLINE4, e.SUBURB, e.STATECODE, e.ZIPCODE, e.COUNTRY_CODE, e.PHONENUMBER, e.MOBILENUMBER, e.PHONE2, e.PHONE3, e.DT_INSERT, e.USERINSERT, e.DT_UPDATE, e.USERUPDATE, e.ROWGUID, e.EMAIL })
                    .HasName("IX_CU_B_LEAD_ADDRESS_EXT_AUS_EMAIL_6D4D3");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.XID).HasMaxLength(15);

                entity.Property(e => e.ADDRESSTYPE).HasMaxLength(1);

                entity.Property(e => e.ADDRESSLINE1).HasMaxLength(100);

                entity.Property(e => e.ADDRESSLINE2).HasMaxLength(100);

                entity.Property(e => e.ADDRESSLINE3).HasMaxLength(100);

                entity.Property(e => e.ADDRESSLINE4).HasMaxLength(100);

                entity.Property(e => e.COUNTRY_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.EMAIL).HasMaxLength(100);

                entity.Property(e => e.MOBILENUMBER).HasMaxLength(100);

                entity.Property(e => e.PHONE2).HasMaxLength(100);

                entity.Property(e => e.PHONE3).HasMaxLength(100);

                entity.Property(e => e.PHONENUMBER).HasMaxLength(100);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.STATECODE).HasMaxLength(3);

                entity.Property(e => e.SUBURB).HasMaxLength(50);

                entity.Property(e => e.USERINSERT).HasMaxLength(25);

                entity.Property(e => e.USERUPDATE).HasMaxLength(25);

                entity.Property(e => e.ZIPCODE).HasMaxLength(15);

                entity.HasOne(d => d.CU_B_LEAD_EXT_AUS)
                    .WithMany(p => p.CU_B_LEAD_ADDRESS_EXT_AUS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.XID })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_LEAD_ADDRESS_EXT_AUS_LEADID");
            });

            modelBuilder.Entity<CU_B_LEAD_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.XID });

                entity.HasIndex(e => e.DATEOFBIRTH)
                    .HasName("IX_CU_B_LEAD_EXT_AUS_BIRTHDATE");

                entity.HasIndex(e => e.XID)
                    .HasName("IX_XID");

                entity.HasIndex(e => new { e.LASTNAME, e.FIRSTNAME })
                    .HasName("IX_LASTNAME_FIRSTNAME");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.FUNDINGTYPE })
                    .HasName("IDX_CU_B_LEAD_EXT_AUS_FUNDING_TYPE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.GENDER })
                    .HasName("IDX_CU_B_LEAD_EXT_AUS_SY_GENDER");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.LEADSOURCE })
                    .HasName("IDX_CU_B_LEAD_EXT_AUS_LEADSOURCE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.LEADSUBSOURCE })
                    .HasName("IDX_CU_B_LEAD_EXT_AUS_LEADSUBSOURCE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SALUTATION })
                    .HasName("IDX_CU_B_LEAD_EXT_AUS_CU_S_SALUTATION");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.STATUS_CODE })
                    .HasName("IDX_CU_B_LEAD_EXT_AUS_CU_S_STATUS");

                entity.HasIndex(e => new { e.LEADTYPE, e.LASTNAME, e.FIRSTNAME })
                    .HasName("IX_CU_B_LEAD_EXT_AUS_FIRSTNAMELASTNAME");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.XID).HasMaxLength(15);

                entity.Property(e => e.COMMON_VAUCHER_ID).HasMaxLength(15);

                entity.Property(e => e.CUSTOMER_CODE).HasMaxLength(8);

                entity.Property(e => e.DATEOFBIRTH).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FIRSTNAME).HasMaxLength(100);

                entity.Property(e => e.FUNDINGTYPE).HasMaxLength(3);

                entity.Property(e => e.GENDER).HasMaxLength(1);

                entity.Property(e => e.LASTNAME).HasMaxLength(100);

                entity.Property(e => e.LEADEXPIRATIONDATE).HasColumnType("date");

                entity.Property(e => e.LEADIMPORTSOURCE).HasMaxLength(100);

                entity.Property(e => e.LEADSOURCE).HasMaxLength(15);

                entity.Property(e => e.LEADSUBSOURCE).HasMaxLength(15);

                entity.Property(e => e.LEADTYPE).HasMaxLength(3);

                entity.Property(e => e.MIDDLENAME).HasMaxLength(100);

                entity.Property(e => e.NOTES).IsUnicode(false);

                entity.Property(e => e.PREFERREDNAME).HasMaxLength(50);

                entity.Property(e => e.REFERRALSOURCE).HasMaxLength(100);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SALUTATION).HasMaxLength(3);

                entity.Property(e => e.SOURCE_CUSTOMER_ID).HasMaxLength(50);

                entity.Property(e => e.SOURCE_TYPE).HasMaxLength(50);

                entity.Property(e => e.STATUS_CODE).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.CU_S_STATUS)
                    .WithMany(p => p.CU_B_LEAD_EXT_AUS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.STATUS_CODE })
                    .HasConstraintName("FK_CU_B_LEAD_EXT_AUS_CU_S_STATUS");
            });

            modelBuilder.Entity<CU_B_NOTE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE, e.NOTE_COUNTER, e.NOTE_DATE });

                entity.HasIndex(e => e.DOCUMENT_NUMBER)
                    .HasName("IDX_CU_B_NOTE_CU_B_DOCUMENT_NUMBER");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_B_NOTE_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.ACTIVITY_TYPE_CODE })
                    .HasName("IDX_CU_B_NOTE_SY_ACTIVITY_TYPE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE })
                    .HasName("IDX_CU_B_NOTE_CU_B_ADDRESS_BOOK");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DOCUMENT_TYPE_CODE })
                    .HasName("IDX_CU_B_NOTE_SY_DOCUMENT_TYPE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE, e.NOTE_DATE, e.NOTE_COUNTER })
                    .HasName("IDX_CU_B_NOTE_CUSTOMER_COUNTER");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_CODE).HasMaxLength(8);

                entity.Property(e => e.NOTE_DATE).HasColumnType("date");

                entity.Property(e => e.ACTIVITY_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.APPOINTMENT_ID).HasMaxLength(10);

                entity.Property(e => e.DOCUMENT_DATE).HasColumnType("date");

                entity.Property(e => e.DOCUMENT_NUMBER).HasMaxLength(6);

                entity.Property(e => e.DOCUMENT_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(8);

                entity.Property(e => e.FLG_RESERVED).HasMaxLength(1);

                entity.Property(e => e.NOTE).HasColumnType("text");

                entity.Property(e => e.NOTE_DATETIME).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SHOP_CODE).HasMaxLength(3);

                entity.Property(e => e.SUBJECT).HasMaxLength(50);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.SY_ACTIVITY_TYPE)
                    .WithMany(p => p.CU_B_NOTE)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.ACTIVITY_TYPE_CODE })
                    .HasConstraintName("FK_CU_B_NOTE_SY_ACTIVITY_TYPE");

                entity.HasOne(d => d.CU_B_ADDRESS_BOOK)
                    .WithMany(p => p.CU_B_NOTE)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_NOTE_CU_B_ADDRESS_BOOK");

                entity.HasOne(d => d.SY_DOCUMENT_TYPE)
                    .WithMany(p => p.CU_B_NOTE)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.DOCUMENT_TYPE_CODE })
                    .HasConstraintName("FK_CU_B_NOTE_SY_DOCUMENT_TYPE");

                entity.HasOne(d => d.CM_B_SHOP)
                    .WithMany(p => p.CU_B_NOTE)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.SHOP_CODE })
                    .HasConstraintName("FK_CU_B_NOTE_CM_B_SHOP");
            });

            modelBuilder.Entity<CU_B_PROFILE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE });

                entity.HasIndex(e => e.CUSTOMER_CODE)
                    .HasName("IX_CU_B_PROFILE");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_B_PROFILE_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE })
                    .HasName("IDX_CU_B_PROFILE_CU_B_ADDRESS_BOOK");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_CODE).HasMaxLength(8);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FLG_CAR).HasMaxLength(1);

                entity.Property(e => e.FLG_EMAIL).HasMaxLength(1);

                entity.Property(e => e.FLG_INTERNET).HasMaxLength(1);

                entity.Property(e => e.FLG_MOBILE).HasMaxLength(1);

                entity.Property(e => e.FLG_NEWSP).HasMaxLength(1);

                entity.Property(e => e.FLG_OTHERCONTACT).HasMaxLength(1);

                entity.Property(e => e.FLG_PHONE).HasMaxLength(1);

                entity.Property(e => e.FLG_PUBLICTRANSPORT).HasMaxLength(1);

                entity.Property(e => e.FLG_SMS).HasMaxLength(1);

                entity.Property(e => e.FLG_TRAVEL).HasMaxLength(1);

                entity.Property(e => e.FLG_TV).HasMaxLength(1);

                entity.Property(e => e.LIVEWITH_CODE).HasMaxLength(2);

                entity.Property(e => e.OTHERHOBBY).HasMaxLength(50);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.CU_B_ADDRESS_BOOK)
                    .WithOne(p => p.CU_B_PROFILE)
                    .HasForeignKey<CU_B_PROFILE>(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_PROFILE_CU_B_ADDRESS_BOOK");
            });

            modelBuilder.Entity<CU_B_PROFILE_ATTRIBUTE_LOOKUP>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE, e.ATTRIBUTE_CODE, e.VALUE_CODE });

                entity.HasIndex(e => e.CUSTOMER_CODE)
                    .HasName("IX_CU_B_PROFILE_ATTRIBUTE_LOOKUP");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_B_PROFILE_ATTRIBUTE_LOOKUP_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE })
                    .HasName("IDX_CU_B_PROFILE_ATTRIBUTE_LOOKUP_CU_B_PROFILE");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_CODE).HasMaxLength(8);

                entity.Property(e => e.ATTRIBUTE_CODE).HasMaxLength(3);

                entity.Property(e => e.VALUE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.CU_B_PROFILE)
                    .WithMany(p => p.CU_B_PROFILE_ATTRIBUTE_LOOKUP)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_PROFILE_ATTRIBUTE_LOOKUP_CU_B_PROFILE");
            });

            modelBuilder.Entity<CU_B_VOUCHER_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE, e.VOUCHER_ID, e.COMMON_VOUCHER_ID });

                entity.HasIndex(e => e.CUSTOMER_CODE);

                entity.HasIndex(e => e.ROWGUID);

                entity.HasIndex(e => e.VOUCHER_ID)
                    .HasName("UQ_VOUCHER_ID")
                    .IsUnique();

                entity.HasIndex(e => new { e.CUSTOMER_CODE, e.VOUCHER_ID })
                    .HasName("CU_B_VOUCHER_EXT_AUS_VOUCHER_ID");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CUSTOMER_CODE, e.VOUCHER_ID, e.DT_INSERT, e.USERUPDATE, e.DT_UPDATE })
                    .HasName("missing_index_47609");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_CODE).HasMaxLength(8);

                entity.Property(e => e.VOUCHER_ID).HasMaxLength(19);

                entity.Property(e => e.COMMON_VOUCHER_ID)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('F-'+right('0000000000'+CONVERT([varchar](10),NEXT VALUE FOR [NextFoxCommonVoucherId]),(10)))");

                entity.Property(e => e.CLIENT_REVIEW_DATE).HasColumnType("datetime");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.DVA_EXEMPT).HasMaxLength(1);

                entity.Property(e => e.EXPIRY_DATE).HasColumnType("datetime");

                entity.Property(e => e.FILE_RECEIVED_DATE).HasColumnType("datetime");

                entity.Property(e => e.FILE_REQUESTED_DATE).HasColumnType("datetime");

                entity.Property(e => e.ISSUE_DATE).HasColumnType("datetime");

                entity.Property(e => e.IS_LAST_ASSESSMENT).HasMaxLength(1);

                entity.Property(e => e.IS_RELOCATED).HasMaxLength(1);

                entity.Property(e => e.LAST_FIT_DATE_LEFT).HasColumnType("datetime");

                entity.Property(e => e.LAST_FIT_DATE_RIGHT).HasColumnType("datetime");

                entity.Property(e => e.LAST_REHAB_DATE).HasColumnType("datetime");

                entity.Property(e => e.MAINTENANCE_EXPIRY_DATE).HasColumnType("datetime");

                entity.Property(e => e.PROVIDER_CODE).HasMaxLength(8);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.STATUS_CODE).HasMaxLength(3);

                entity.Property(e => e.TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.CU_B_ADDRESS_BOOK)
                    .WithMany(p => p.CU_B_VOUCHER_EXT_AUS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CU_B_VOUCHER_EXT_AUS_CU_B_ADDRESS_BOOK");
            });

            modelBuilder.Entity<CU_S_AUDIOGRAM_RULE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.RESULT_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_S_AUDIOGRAM_RULE_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.RESULT_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.RESULT_DESCR).HasMaxLength(255);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_S_AUDIOGRAM_TYPE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.AUDIOGRAM_TYPE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_S_AUDIOGRAM_TYPE_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.AUDIOGRAM_TYPE_DESCR).HasMaxLength(255);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_S_CATEGORY>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CATEGORY_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_S_CATEGORY_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CATEGORY_CODE).HasMaxLength(3);

                entity.Property(e => e.CATEGORY_DESCR).HasMaxLength(255);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.MARKET_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_S_CUSTOMER_TYPE_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.TYPE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_S_CUSTOMER_TYPE_EXT_AUS_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.TYPE_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_S_DVA_CARD_TYPE_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DVA_CARD_TYPE_CODE });

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.DVA_CARD_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.DVA_CARD_TYPE_DESCR)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_S_HICONDITION>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.HICONDITION_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_S_HICONDITION_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.HICONDITION_DESCR).HasMaxLength(255);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_S_OCCUPATION>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.OCCUPATION_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_S_OCCUPATION_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.OCCUPATION_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.OCCUPATION_DESCR).HasMaxLength(255);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_S_SALUTATION>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SALUTATION_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_S_SALUTATION_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SALUTATION_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SALUTATION_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_S_STATUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.STATUS_CODE })
                    .HasName("PK_CUS_CONTACT_HOURS");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_S_STATUS_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.STATUS_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.STATUS_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_S_TITLE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.TITLE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_S_TITLE_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.TITLE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.GENDER_CODE).HasMaxLength(1);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.TITLE_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_S_TYPE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.TYPE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_S_TYPE_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.TYPE_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<PD_S_PRODUCT>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.PRODUCT_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_PD_S_PRODUCT_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.PRODUCT_CODE, e.CLASS_CODE })
                    .HasName("IDX_PD_S_PRODUCT_001");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.BAND_CODE })
                    .HasName("IDX_PD_S_PRODUCT_PD_S_BAND");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.BRAND_CODE })
                    .HasName("IDX_PD_S_PRODUCT_PD_S_SUPPLIER");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.FAMILY_CODE })
                    .HasName("IDX_PD_S_PRODUCT_PD_S_FAMILY");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.REPLENISHMENT_TYPE_CODE })
                    .HasName("IDX_PD_S_PRODUCT_PD_S_REPLENISHMENT_TYPE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CLASS_CODE, e.SUBCLASS_CODE })
                    .HasName("IDX_PD_S_PRODUCT_PD_S_SUBCLASS");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.PRODUCT_CODE, e.DT_INSERT, e.USERUPDATE, e.DT_UPDATE })
                    .HasName("missing_index_17741");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.PRODUCT_CODE).HasMaxLength(8);

                entity.Property(e => e.BAND_CODE).HasMaxLength(4);

                entity.Property(e => e.BATTERY_SIZE_CODE).HasMaxLength(3);

                entity.Property(e => e.BRAND_CODE).HasMaxLength(8);

                entity.Property(e => e.CLASS_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FAMILY_CODE).HasMaxLength(4);

                entity.Property(e => e.FLG_ACTIVE).HasMaxLength(1);

                entity.Property(e => e.FLG_CUSTOM).HasMaxLength(1);

                entity.Property(e => e.FLG_DUMMY).HasMaxLength(1);

                entity.Property(e => e.FLG_FRANCHISEE).HasMaxLength(1);

                entity.Property(e => e.FLG_ORDERABLE).HasMaxLength(1);

                entity.Property(e => e.FLG_QUALITYCHECK).HasMaxLength(1);

                entity.Property(e => e.FLG_QUICKSALE).HasMaxLength(1);

                entity.Property(e => e.FLG_SERIAL).HasMaxLength(1);

                entity.Property(e => e.FLG_SIDE).HasMaxLength(1);

                entity.Property(e => e.FLG_STOCKTAKE).HasMaxLength(1);

                entity.Property(e => e.FLG_TRIAL).HasMaxLength(1);

                entity.Property(e => e.GROUP_CODE).HasMaxLength(4);

                entity.Property(e => e.PRODUCT_DESCR).HasMaxLength(255);

                entity.Property(e => e.PRODUCT_STATUS).HasMaxLength(3);

                entity.Property(e => e.REPLENISHMENT_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SUBCLASS_CODE).HasMaxLength(3);

                entity.Property(e => e.SUPPLIER_CODE).HasMaxLength(8);

                entity.Property(e => e.TARIFF_POSITION_CODE).HasMaxLength(20);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.Property(e => e.VAT_CODE).HasMaxLength(3);
            });

            modelBuilder.Entity<PD_S_PRODUCT_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.PRODUCT_CODE })
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_PD_S_PRODUCT_EXT_AUS_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.PRODUCT_CODE).HasMaxLength(8);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_NHC_APPROVED_FROM).HasColumnType("datetime");

                entity.Property(e => e.DT_NHC_APPROVED_TO).HasColumnType("datetime");

                entity.Property(e => e.DT_OHS_APPROVED_FROM).HasColumnType("datetime");

                entity.Property(e => e.DT_OHS_APPROVED_TO).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.DVA).HasMaxLength(1);

                entity.Property(e => e.DVA_CODE).HasMaxLength(10);

                entity.Property(e => e.DVA_PRE_G_APPROVAL).HasMaxLength(1);

                entity.Property(e => e.DVA_PRE_W_APPROVAL).HasMaxLength(1);

                entity.Property(e => e.FLG_CUSTOM_DEVICE).HasMaxLength(1);

                entity.Property(e => e.NDIS_SUPPORT_NO).HasMaxLength(21);

                entity.Property(e => e.PRODUCT_COMMER).HasMaxLength(255);

                entity.Property(e => e.RAP_CODE).HasMaxLength(10);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SALE_TYPE).HasMaxLength(3);

                entity.Property(e => e.TECHNOLOGY).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.Property(e => e.WC_ACT).HasMaxLength(1);

                entity.Property(e => e.WC_ALLOWED_FOR_NSW_POST_MAY).HasMaxLength(1);

                entity.Property(e => e.WC_ALLOWED_FOR_VIC_WORKSAFE).HasMaxLength(1);

                entity.Property(e => e.WC_ALLSTATE).HasMaxLength(1);

                entity.Property(e => e.WC_INCLUDED_NSW_WC_LIST).HasMaxLength(1);

                entity.Property(e => e.WC_INCLUDED_VIC_WC_LIST).HasMaxLength(1);

                entity.Property(e => e.WC_NSW).HasMaxLength(1);

                entity.Property(e => e.WC_NSW_WS_CODE).HasMaxLength(15);

                entity.Property(e => e.WC_NT).HasMaxLength(1);

                entity.Property(e => e.WC_QLD).HasMaxLength(1);

                entity.Property(e => e.WC_SA).HasMaxLength(1);

                entity.Property(e => e.WC_TAS).HasMaxLength(1);

                entity.Property(e => e.WC_VIC).HasMaxLength(1);

                entity.Property(e => e.WC_VIC_WS_CODE).HasMaxLength(15);

                entity.Property(e => e.WC_WA).HasMaxLength(1);

                entity.Property(e => e.ZERO_TOPUP).HasMaxLength(1);
            });

            modelBuilder.Entity<SY_ACTIVITY_TYPE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.ACTIVITY_TYPE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_SY_ACTIVITY_TYPE_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DOCUMENT_TYPE_CODE })
                    .HasName("IDX_SY_ACTIVITY_TYPE_SY_DOCUMENT_TYPE");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.ACTIVITY_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.ACTIVITY_TYPE_DESCR).HasMaxLength(255);

                entity.Property(e => e.DOCUMENT_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.SY_DOCUMENT_TYPE)
                    .WithMany(p => p.SY_ACTIVITY_TYPE)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.DOCUMENT_TYPE_CODE })
                    .HasConstraintName("FK_SY_ACTIVITY_TYPE_SY_DOCUMENT_TYPE");
            });

            modelBuilder.Entity<SY_DOCUMENT_TYPE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DOCUMENT_TYPE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_SY_DOCUMENT_TYPE_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.DOCUMENT_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DOCUMENT_TYPE_DESCR).HasMaxLength(255);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<SY_GENDER>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.GENDER_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_SY_GENDER_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.GENDER_CODE).HasMaxLength(1);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.GENDER_DESCR).HasMaxLength(255);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<SY_GENERAL_STATUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.STATUS_CODE, e.ENTITY_TYPE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_SY_GENERAL_STATUS_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.ENTITY_TYPE_CODE })
                    .HasName("IDX_SY_GENERAL_STATUS_SY_ENTITY_TYPE");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.STATUS_CODE).HasMaxLength(3);

                entity.Property(e => e.ENTITY_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.STATUS_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<SY_LANGUAGE>(entity =>
            {
                entity.HasKey(e => e.LANGUAGE_CODE);

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_SY_LANGUAGE_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.LANGUAGE_CODE)
                    .HasMaxLength(5)
                    .ValueGeneratedNever();

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FLG_APPLICATION).HasMaxLength(1);

                entity.Property(e => e.LANGUAGE_DESCR).HasMaxLength(255);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<SY_SIDE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SIDE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_SY_SIDE_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SIDE_CODE).HasMaxLength(1);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SIDE_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.HasSequence("NextFoxid").StartsAt(0);

            modelBuilder.HasSequence("GETNEXTBATCHNUMBER").StartsAt(200);

            modelBuilder.HasSequence("NextFoxCommonVoucherId");

            modelBuilder.HasSequence("NextFoxCouponid").StartsAt(0);

            modelBuilder.HasSequence("NextFoxid").StartsAt(4000);

            modelBuilder.HasSequence("NextFoxVoucherId");
        }
    }
}
