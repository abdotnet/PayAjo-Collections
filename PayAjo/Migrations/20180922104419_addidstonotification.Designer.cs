﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PayAjo.Data;

namespace PayAjo.Migrations
{
    [DbContext(typeof(PayAjoContext))]
    [Migration("20180922104419_addidstonotification")]
    partial class addidstonotification
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PayAjo.Data.Entities.AuditTrail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("IPAddress");

                    b.Property<string>("Location");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.HasKey("Id");

                    b.ToTable("AuditTrail");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Claim", b =>
                {
                    b.Property<int>("ClaimId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.Property<long>("UserId");

                    b.Property<string>("Value");

                    b.HasKey("ClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Collection", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("CollectionCode");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long?>("CustomerId");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsCancelled");

                    b.Property<bool>("IsNotify");

                    b.Property<long?>("MerchantId");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("ReasonForCollection");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MerchantId");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.CollectionType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CollectionType");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Customer", b =>
                {
                    b.Property<long>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("ApplicationCode");

                    b.Property<int>("Channel");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CustomerCode");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsCancelled");

                    b.Property<bool>("IsLocked");

                    b.Property<bool>("IsSmsNotify");

                    b.Property<string>("LastName");

                    b.Property<long>("MerchantId");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Mobile");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("NokAddress");

                    b.Property<string>("NokEmail");

                    b.Property<string>("NokMobile");

                    b.Property<string>("NokName");

                    b.Property<string>("NokRelationship");

                    b.Property<DateTime>("SmsEndDate");

                    b.Property<DateTime>("SmsStartDate");

                    b.Property<string>("State");

                    b.Property<string>("Title");

                    b.Property<long>("UserId");

                    b.HasKey("CustomerId");

                    b.HasIndex("MerchantId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.CustomerBalance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<decimal>("CurrentBalance");

                    b.Property<long>("CustomerId");

                    b.Property<bool>("IsSmsFeeChargeable");

                    b.Property<bool>("IsTechFeeChargeable");

                    b.Property<long>("MerchantId");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<DateTime>("TechFeeEndDate");

                    b.Property<DateTime>("TechFeeStartDate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerBalance");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Merchant", b =>
                {
                    b.Property<long>("MerchantId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("BVN");

                    b.Property<string>("BusinessMobile");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("GovtRegNo");

                    b.Property<int>("ImageContentLength");

                    b.Property<string>("ImageContentType");

                    b.Property<string>("ImagePath");

                    b.Property<bool>("IsCancelled");

                    b.Property<string>("MerchantCode");

                    b.Property<string>("MerchantNo");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.HasKey("MerchantId");

                    b.ToTable("Merchant");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.MerchantAgentBalance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AgentId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<decimal>("CurrentBalance");

                    b.Property<long>("MerchantId");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.HasKey("Id");

                    b.HasIndex("MerchantId");

                    b.ToTable("MerchantAgentBalance");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.MerchantBalance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("MerchantId");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.HasKey("Id");

                    b.HasIndex("MerchantId");

                    b.ToTable("MerchantBalance");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.MerchantBalanceSetting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<long>("MerchantId");

                    b.Property<string>("MerchantMapCode");

                    b.HasKey("Id");

                    b.HasIndex("MerchantId");

                    b.ToTable("MerchantBalanceSetting");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.MerchantWalletBalance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long?>("MerchantId");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<long?>("SettingId");

                    b.Property<long>("UnitDepleted");

                    b.HasKey("Id");

                    b.HasIndex("MerchantId");

                    b.HasIndex("SettingId");

                    b.ToTable("MerchantWalletBalance");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Notification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("CustomerId");

                    b.Property<bool>("IsNotify");

                    b.Property<long>("MerchantId");

                    b.Property<string>("Message");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("NotificationSystem");

                    b.Property<int>("NotificationType");

                    b.Property<string>("Recipient");

                    b.Property<long>("SendToUserId");

                    b.Property<string>("Sender");

                    b.HasKey("Id");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Role", b =>
                {
                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.RolePermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<long>("PermissionId");

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermission");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Setting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsCancelled");

                    b.Property<long?>("MerchantId");

                    b.Property<decimal>("MinimumBalance");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<decimal>("SmsAmount");

                    b.Property<decimal>("SmsUnit");

                    b.Property<decimal>("TechAmount");

                    b.HasKey("Id");

                    b.HasIndex("MerchantId");

                    b.ToTable("Setting");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.SocialLogin", b =>
                {
                    b.Property<int>("SocialLoginId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Key");

                    b.Property<string>("Name");

                    b.Property<string>("Provider");

                    b.Property<string>("UserId");

                    b.Property<long?>("UserId1");

                    b.HasKey("SocialLoginId");

                    b.HasIndex("UserId1");

                    b.ToTable("SocialLogin");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<long?>("CollectionTypeId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long?>("CustomerId");

                    b.Property<bool>("IsNotified");

                    b.Property<long>("MerchantId");

                    b.Property<string>("Message");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("TransactionChannel");

                    b.Property<string>("TransactionCode");

                    b.Property<string>("TransactionMapCode");

                    b.Property<string>("TransactionNo");

                    b.Property<string>("TransactionType");

                    b.HasKey("Id");

                    b.HasIndex("CollectionTypeId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MerchantId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.TransactionLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<long?>("CollectionTypeId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long?>("CustomerId");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsNotified");

                    b.Property<long>("MerchantId");

                    b.Property<string>("Message");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("TransactionChannel");

                    b.Property<string>("TransactionCode");

                    b.Property<string>("TransactionMapCode");

                    b.Property<string>("TransactionNo");

                    b.Property<string>("TransactionType");

                    b.HasKey("Id");

                    b.HasIndex("CollectionTypeId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MerchantId");

                    b.ToTable("TransactionLog");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("Channel");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(450);

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsCancelled");

                    b.Property<bool>("IsEmailConfirmed");

                    b.Property<bool>("IsLocked");

                    b.Property<bool>("IsPhoneConfirmed");

                    b.Property<DateTime>("LastLoginDate");

                    b.Property<string>("LastName");

                    b.Property<long>("MerchantId");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Mobile");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Password");

                    b.Property<string>("PasswordCode");

                    b.Property<DateTime>("ResetCodeMinute");

                    b.Property<string>("Salt");

                    b.Property<string>("State");

                    b.Property<string>("UserName");

                    b.Property<int>("UserStatus");

                    b.Property<int>("UserType");

                    b.HasKey("UserId");

                    b.HasIndex("MerchantId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.UserRole", b =>
                {
                    b.Property<long>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<long>("RoleId");

                    b.Property<long>("UserId");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Withdrawal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("CustomerId");

                    b.Property<bool>("IsCancelled");

                    b.Property<long>("MerchantId");

                    b.Property<string>("Message");

                    b.Property<long>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("WithdrawalStatus");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Withdrawal");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Claim", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Collection", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("PayAjo.Data.Entities.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Customer", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayAjo.Data.Entities.CustomerBalance", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayAjo.Data.Entities.MerchantAgentBalance", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayAjo.Data.Entities.MerchantBalance", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayAjo.Data.Entities.MerchantBalanceSetting", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayAjo.Data.Entities.MerchantWalletBalance", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId");

                    b.HasOne("PayAjo.Data.Entities.Setting", "Setting")
                        .WithMany()
                        .HasForeignKey("SettingId");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.RolePermission", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayAjo.Data.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Setting", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.SocialLogin", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.User", "User")
                        .WithMany("SocialLogins")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Transaction", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.CollectionType", "CollectionType")
                        .WithMany()
                        .HasForeignKey("CollectionTypeId");

                    b.HasOne("PayAjo.Data.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("PayAjo.Data.Entities.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayAjo.Data.Entities.TransactionLog", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.CollectionType", "CollectionType")
                        .WithMany()
                        .HasForeignKey("CollectionTypeId");

                    b.HasOne("PayAjo.Data.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("PayAjo.Data.Entities.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayAjo.Data.Entities.User", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayAjo.Data.Entities.UserRole", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayAjo.Data.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayAjo.Data.Entities.Withdrawal", b =>
                {
                    b.HasOne("PayAjo.Data.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
