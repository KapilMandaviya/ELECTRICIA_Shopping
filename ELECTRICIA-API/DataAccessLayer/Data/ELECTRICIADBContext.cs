using System;
using System.Collections.Generic;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data;

public partial class ELECTRICIADBContext : DbContext
{
    public ELECTRICIADBContext()
    {
    }

    public ELECTRICIADBContext(DbContextOptions<ELECTRICIADBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AboutDetail> AboutDetails { get; set; }

    public virtual DbSet<AccessoriesMaster> AccessoriesMasters { get; set; }

    public virtual DbSet<BlogCommentDetail> BlogCommentDetails { get; set; }

    public virtual DbSet<BlogDescription> BlogDescriptions { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CategoriesMaster> CategoriesMasters { get; set; }

    public virtual DbSet<CityMaster> CityMasters { get; set; }

    public virtual DbSet<ContactU> ContactUs { get; set; }

    public virtual DbSet<CountryMaster> CountryMasters { get; set; }

    public virtual DbSet<EnquiryDetail> EnquiryDetails { get; set; }

    public virtual DbSet<FaqDetail> FaqDetails { get; set; }

    public virtual DbSet<LoginStatus> LoginStatuses { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<ParentCategory> ParentCategories { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<PaymentStatusType> PaymentStatusTypes { get; set; }

    public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductVariant> ProductVariants { get; set; }

    public virtual DbSet<ProductsMaster> ProductsMasters { get; set; }

    public virtual DbSet<ReasonMaster> ReasonMasters { get; set; }

    public virtual DbSet<ReturnsMaster> ReturnsMasters { get; set; }

    public virtual DbSet<ReviewDetail> ReviewDetails { get; set; }

    public virtual DbSet<ReviewVote> ReviewVotes { get; set; }

    public virtual DbSet<RoleMaster> RoleMasters { get; set; }

    public virtual DbSet<ServiceDetail> ServiceDetails { get; set; }

    public virtual DbSet<ShipmentDetail> ShipmentDetails { get; set; }

    public virtual DbSet<ShippingProvider> ShippingProviders { get; set; }

    public virtual DbSet<StateMaster> StateMasters { get; set; }

    public virtual DbSet<UserAddress> UserAddresses { get; set; }

    public virtual DbSet<UserMaster> UserMasters { get; set; }

    public virtual DbSet<WishlistsMaster> WishlistsMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Database=kapilmandaviya1_ELECTRICIAShopping;User Id=kapilmandaviya1_ELECTRICIAShopping;Password=kapil@192151;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AboutDetail>(entity =>
        {
            entity.HasKey(e => e.AbId);

            entity.ToTable("AboutDetail");

            entity.Property(e => e.AbId).HasColumnName("Ab_Id");
            entity.Property(e => e.AboutDescription)
                .IsUnicode(false)
                .HasColumnName("About_Description");
            entity.Property(e => e.AboutHeader)
                .IsUnicode(false)
                .HasColumnName("About_Header");
            entity.Property(e => e.AboutImgName)
                .IsUnicode(false)
                .HasColumnName("About_ImgName");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<AccessoriesMaster>(entity =>
        {
            entity.HasKey(e => e.AccessoryId);

            entity.ToTable("AccessoriesMaster");

            entity.Property(e => e.AccessoryId).HasColumnName("AccessoryID");
            entity.Property(e => e.CompatibleProductId)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("CompatibleProductID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.ImgName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Img_Name");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.Name)
                .HasMaxLength(350)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<BlogCommentDetail>(entity =>
        {
            entity.HasKey(e => e.CmId);

            entity.ToTable("Blog_CommentDetail");

            entity.Property(e => e.CmId).HasColumnName("Cm_Id");
            entity.Property(e => e.BlogId).HasColumnName("Blog_Id");
            entity.Property(e => e.CommentDate)
                .HasColumnType("datetime")
                .HasColumnName("comment_date");
            entity.Property(e => e.CommentDescription)
                .IsUnicode(false)
                .HasColumnName("Comment_Description");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
            entity.Property(e => e.UserId).HasColumnName("User_Id");
        });

        modelBuilder.Entity<BlogDescription>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Blog_Description");

            entity.Property(e => e.BlogId).HasColumnName("Blog_Id");
            entity.Property(e => e.BlogBy)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Blog_By");
            entity.Property(e => e.BlogCaption)
                .IsUnicode(false)
                .HasColumnName("Blog_Caption");
            entity.Property(e => e.BlogDate).HasColumnName("Blog_Date");
            entity.Property(e => e.BlogDescription1)
                .IsUnicode(false)
                .HasColumnName("Blog_Description");
            entity.Property(e => e.BlogImage)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Blog_Image");
            entity.Property(e => e.BlogTags)
                .IsUnicode(false)
                .HasColumnName("Blog_Tags");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.Property(e => e.CartId).HasColumnName("Cart_ID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Product_Name");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
            entity.Property(e => e.UserId).HasColumnName("User_ID");
        });

        modelBuilder.Entity<CategoriesMaster>(entity =>
        {
            entity.HasKey(e => e.CategoriesId);

            entity.ToTable("CategoriesMaster");

            entity.Property(e => e.CatName)
                .IsUnicode(false)
                .HasColumnName("Cat_Name");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.PcId).HasColumnName("PC_Id");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<CityMaster>(entity =>
        {
            entity.HasKey(e => e.CityId);

            entity.ToTable("CityMaster");

            entity.Property(e => e.CityId).HasColumnName("City_Id");
            entity.Property(e => e.CityName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("City_Name");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.StateId).HasColumnName("State_Id");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<ContactU>(entity =>
        {
            entity.HasKey(e => e.ContactId);

            entity.ToTable("Contact_us");

            entity.Property(e => e.ContactId).HasColumnName("Contact_id");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.EmailAddress)
                .IsUnicode(false)
                .HasColumnName("Email_Address");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.OfficeAddress)
                .IsUnicode(false)
                .HasColumnName("Office_Address");
            entity.Property(e => e.PhoneNumber).HasColumnName("Phone_Number");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<CountryMaster>(entity =>
        {
            entity.HasKey(e => e.CountryId);

            entity.ToTable("CountryMaster");

            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.CountryName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Country_Name");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<EnquiryDetail>(entity =>
        {
            entity.HasKey(e => e.EnqId);

            entity.Property(e => e.EnqId).HasColumnName("Enq_Id");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Email_Address");
            entity.Property(e => e.EnqMessage)
                .IsUnicode(false)
                .HasColumnName("Enq_Message");
            entity.Property(e => e.EnqName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Enq_Name");
            entity.Property(e => e.EnqSubject)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Enq_Subject");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.PhoneNo).HasColumnName("Phone_No");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<FaqDetail>(entity =>
        {
            entity.HasKey(e => e.FaqId);

            entity.ToTable("Faq_Details");

            entity.Property(e => e.FaqId).HasColumnName("Faq_Id");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.FaqAnswer)
                .IsUnicode(false)
                .HasColumnName("Faq_answer");
            entity.Property(e => e.FaqQuestion)
                .IsUnicode(false)
                .HasColumnName("Faq_question");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<LoginStatus>(entity =>
        {
            entity.HasKey(e => e.LoginId);

            entity.ToTable("LoginStatus");

            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IP_Address");
            entity.Property(e => e.LoginStatus1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Login_Status");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.RefreshToken)
                .IsUnicode(false)
                .HasColumnName("Refresh_Token");
            entity.Property(e => e.Token).IsUnicode(false);
            entity.Property(e => e.TokenExpiration)
                .HasColumnType("datetime")
                .HasColumnName("Token_Expiration");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
            entity.Property(e => e.UserId).HasColumnName("User_Id");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");
            entity.Property(e => e.PaymentStatusId).HasColumnName("PaymentStatusID");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.ToTable("OrderStatus");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.StatusType)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Status_type");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<ParentCategory>(entity =>
        {
            entity.HasKey(e => e.PcId);

            entity.ToTable("ParentCategory");

            entity.Property(e => e.PcId).HasColumnName("PC_Id");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.PcName)
                .IsUnicode(false)
                .HasColumnName("PC_Name");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.PaymentId);

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.PaymentStatusId).HasColumnName("PaymentStatusID");
            entity.Property(e => e.TransactionId).IsUnicode(false);
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<PaymentStatusType>(entity =>
        {
            entity.HasKey(e => e.PaymentStatusId);

            entity.ToTable("PaymentStatusType");

            entity.Property(e => e.PaymentStatusId).HasColumnName("PaymentStatusID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.PstatusTyp)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("PStatus_Typ");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<ProductAttribute>(entity =>
        {
            entity.HasKey(e => e.AttributeId);

            entity.Property(e => e.AttributeId).HasColumnName("Attribute_ID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.PaName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("PA_Name");
            entity.Property(e => e.PaValue)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("PA_Value");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.ImageId);

            entity.Property(e => e.ImageId).HasColumnName("ImageID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ImgName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Img_Name");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<ProductVariant>(entity =>
        {
            entity.HasKey(e => e.VarientId);

            entity.Property(e => e.VarientId).HasColumnName("VarientID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.PvName)
                .IsUnicode(false)
                .HasColumnName("PV_Name");
            entity.Property(e => e.PvPrice).HasColumnName("PV_Price");
            entity.Property(e => e.PvSku)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("PV_SKU");
            entity.Property(e => e.PvStock).HasColumnName("PV_Stock");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<ProductsMaster>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("ProductsMaster");

            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.PBasePrice).HasColumnName("P_BasePrice");
            entity.Property(e => e.PDescription).HasColumnName("P_Description");
            entity.Property(e => e.PName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("P_Name");
            entity.Property(e => e.PSku)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("P_SKU");
            entity.Property(e => e.PStock).HasColumnName("P_Stock");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<ReasonMaster>(entity =>
        {
            entity.HasKey(e => e.ReasonId);

            entity.ToTable("ReasonMaster");

            entity.Property(e => e.ReasonId).HasColumnName("ReasonID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.ReasonRemarks)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Reason_remarks");
            entity.Property(e => e.ReasonType)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<ReturnsMaster>(entity =>
        {
            entity.HasKey(e => e.ReturnId);

            entity.ToTable("ReturnsMaster");

            entity.Property(e => e.ReturnId).HasColumnName("ReturnID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ReasonId).HasColumnName("ReasonID");
            entity.Property(e => e.ReturnStatus)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<ReviewDetail>(entity =>
        {
            entity.HasKey(e => e.ReviewId);

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.RatingNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReviewComment).IsUnicode(false);
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<ReviewVote>(entity =>
        {
            entity.HasKey(e => e.VoteId);

            entity.ToTable("ReviewVote");

            entity.Property(e => e.VoteId).HasColumnName("VoteID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.VoteType)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Vote_type");
        });

        modelBuilder.Entity<RoleMaster>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("RoleMaster");

            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.RoleName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Role_Name");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<ServiceDetail>(entity =>
        {
            entity.HasKey(e => e.ServiceId);

            entity.ToTable("Service_Detail");

            entity.Property(e => e.ServiceId).HasColumnName("Service_Id");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.ServiceCaption)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Service_caption");
            entity.Property(e => e.ServiceDetail1)
                .IsUnicode(false)
                .HasColumnName("Service_detail");
            entity.Property(e => e.ServiceLink)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Service_Link");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<ShipmentDetail>(entity =>
        {
            entity.HasKey(e => e.ShipmentId);

            entity.Property(e => e.ShipmentId).HasColumnName("ShipmentID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<ShippingProvider>(entity =>
        {
            entity.HasKey(e => e.ProviderId);

            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.ProviderName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Provider_Name");
            entity.Property(e => e.TrackingUrl)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("TrackingURL");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<StateMaster>(entity =>
        {
            entity.HasKey(e => e.StateId);

            entity.ToTable("StateMaster");

            entity.Property(e => e.StateId).HasColumnName("State_Id");
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.StateName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("State_Name");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<UserAddress>(entity =>
        {
            entity.HasKey(e => e.AddId);

            entity.Property(e => e.AddId).HasColumnName("Add_Id");
            entity.Property(e => e.AddressType)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.StreetName)
                .IsUnicode(false)
                .HasColumnName("Street_Name");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<UserMaster>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserMaster");

            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.Password)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
        });

        modelBuilder.Entity<WishlistsMaster>(entity =>
        {
            entity.HasKey(e => e.WishlistId);

            entity.ToTable("WishlistsMaster");

            entity.Property(e => e.WishlistId).HasColumnName("WishlistID");
            entity.Property(e => e.CreatedByUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_UserId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_Date");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ModifyAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modify_Action");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Product_Name");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
