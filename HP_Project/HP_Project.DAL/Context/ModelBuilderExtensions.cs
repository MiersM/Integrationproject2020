using HP_Project.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Project.DAL.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // One to Many relation
            modelBuilder.Entity<Contact>()
                .HasOne<ApplicationUser>(c => c.ApplicationUser)
                .WithMany(au => au.Contacts)
                .HasForeignKey(c => c.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Touchpoint>()
                .HasOne<ApplicationUser>(t => t.ApplicationUser)
                .WithMany(au => au.Touchpoints)
                .HasForeignKey(t => t.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Touchpoint>()
                .HasOne<Contact>(t => t.Contact)
                .WithMany(c => c.Touchpoints)
                .HasForeignKey(t => t.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

            var applicationUser1 = new ApplicationUser()
            {
                Id = "1",
                UserName = "Annick Verscheuren",
                Email = "annick.verscheuren@hptest.com",
                PasswordHash = "AQAAAAEAACcQAAAAEBFD/mzYDUJIbacSc4JjveEuqc8eG/V2a1Zwl2L90szemfF7x/Dni6MATosSOKstTQ==" // Azerty123$
            };

            var applicationUser2 = new ApplicationUser()
            {
                Id = "2",
                UserName = "Koen Van Beneden",
                Email = "koen.vanbeneden@hptest.com",
                PasswordHash = "AQAAAAEAACcQAAAAEBFD/mzYDUJIbacSc4JjveEuqc8eG/V2a1Zwl2L90szemfF7x/Dni6MATosSOKstTQ==" // Azerty123$
            };

            var applicationUser3 = new ApplicationUser()
            {
                Id = "3",
                UserName = "Jan Das",
                Email = "jan.das@hptest.com",
                PasswordHash = "AQAAAAEAACcQAAAAEBFD/mzYDUJIbacSc4JjveEuqc8eG/V2a1Zwl2L90szemfF7x/Dni6MATosSOKstTQ==" // Azerty123$
            };

            modelBuilder.Entity<ApplicationUser>().HasData(
                applicationUser1,
                applicationUser2,
                applicationUser3);

            var contact1 = new Contact
            {
                Id = 1,
                FirstName = "Jos",
                LastName = "De Bosvos",
                Role = "IT director",
                Email = "jos@axa.be",
                Phone = 32477901011,
                Mkt = true,
                ApplicationUserId = applicationUser1.Id,
                //ApplicationUser = applicationUser1,
                CIOCircle = "",
                InnovationForum = false,
                TAC = true,
                PostalAddress = "Abcde",
                Comments = ""
            };
            var contact2 = new Contact
            {
                Id = 2,
                FirstName = "Freddy",
                LastName = "De Zoetwatervis",
                Role = "CIO",
                Email = "freddy@axa.be",
                Phone = 32477901012,
                Mkt = false,
                ApplicationUserId = applicationUser2.Id,
                //ApplicationUser = applicationUser2,
                CIOCircle = "nominated",
                InnovationForum = false,
                TAC = false,
                PostalAddress = "Abcde",
                Comments = ""
            };
            var contact3 = new Contact
            {
                Id = 3,
                FirstName = "Willy",
                LastName = "Willems",
                Role = "Device Manager",
                Email = "willy@axa.be",
                Phone = 32477901013,
                Mkt = false,
                ApplicationUserId = applicationUser1.Id,
                //ApplicationUser = applicationUser1,
                CIOCircle = "",
                InnovationForum = true,
                TAC = false,
                PostalAddress = "Abcde",
                Comments = ""
            };
            var contact4 = new Contact
            {
                Id = 4,
                FirstName = "Kenny",
                LastName = "Kenens",
                Role = "Image creator",
                Email = "kenny@axa.be",
                Phone = 32477901014,
                Mkt = false,
                ApplicationUserId = applicationUser3.Id,
                //ApplicationUser = applicationUser3,
                CIOCircle = "",
                InnovationForum = true,
                TAC = true,
                PostalAddress = "Abcde",
                Comments = "",
            };

            modelBuilder.Entity<Contact>().HasData(
                contact1,
                contact2,
                contact3,
                contact4
                );

            modelBuilder.Entity<Touchpoint>().HasData(
                new Touchpoint
                {
                    Id = 1,
                    Date = new DateTime(2018, 6, 1),
                    SortOfEvent = "RFP",
                    Description = "New RFP for Notebooks and desktops (old RFP ends 6/18)",
                    ContactId = contact1.Id,
                    //Contact = contact1,
                    ApplicationUserId = "1",
                    //ApplicationUser = applicationUser1,
                    Reminder = new DateTime(2018, 2, 1)
                },
                new Touchpoint
                {
                    Id = 2,
                    Date = new DateTime(2018, 2, 1),
                    SortOfEvent = "meeting",
                    Description = "Plan roadmap update",
                    ContactId = contact1.Id,
                    ApplicationUserId = "1",
                    //ApplicationUser = applicationUser1,
                    Reminder = new DateTime(2017, 12, 1)
                },
                new Touchpoint
                {
                    Id = 3,
                    Date = new DateTime(2016, 12, 1),
                    SortOfEvent = "meeting",
                    Description = "Roadmap update 2016 - interested in Elitebook 840/850 and Elite x3",
                    ContactId = contact2.Id,
                    //Contact = contact2,
                    ApplicationUserId = "2",
                    //ApplicationUser = applicationUser2
                },
                new Touchpoint
                {
                    Id = 4,
                    Date = new DateTime(2016, 11, 12),
                    SortOfEvent = "Marketing email",
                    Description = "Intro mailer Elite x3 - opened and followed link to landing page",
                    ContactId = contact3.Id,
                    //Contact = contact3,
                    ApplicationUserId = "3",
                    //ApplicationUser = applicationUser3,
                },
                new Touchpoint
                {
                    Id = 5,
                    Date = new DateTime(2016, 6, 23),
                    SortOfEvent = "Event",
                    Description = "Elite x3 CIO event - interested in MFP renewal and DaaS",
                    ContactId = contact4.Id,
                    //Contact = contact4,
                    ApplicationUserId = "2",
                    //ApplicationUser = applicationUser2,
                }
                );












            modelBuilder.Entity<ApolloRow>().HasData(
                new ApolloRow
                {
                    Id = 1,
                    Name = "Ah Development",
                    AccountNameLatin = "Ah Development",
                    AccountSTID = 225954,
                },
                new ApolloRow
                {
                    Id = 2,
                    Name = "Adobe Systems Belgium BVBA",
                    AccountNameLatin = "Adobe Systems Belgium BVBA"
                },
                new ApolloRow
                {
                    Id = 3,
                    Name = "BELGACOM",
                    AccountNameLatin = "BELGACOM"
                },
                new ApolloRow
                {
                    Id = 4,
                    Name = "Machiels Building solutions",
                    AccountNameLatin = "Machiels Building solutions"
                },
                new ApolloRow
                {
                    Id = 5,
                    Name = "Henco Industries",
                    AccountNameLatin = "Henco Industries"
                }
                );

            modelBuilder.Entity<ClientEmployee>().HasData(
                new ClientEmployee
                {
                    Id = 1,
                    SalesTerritoryId = 225954,
                    SalesTerritoryName = "A. DEVELOPMENT - BE",
                    AmountEmployee = 160000,
                    ITspendByYear = 9280000.00
                },
                new ClientEmployee
                {
                    Id = 2,
                    SalesTerritoryId = 226950,
                    SalesTerritoryName = "ADOBE SYSTEMS BENELUX - BE",
                    AmountEmployee = 50,
                    ITspendByYear = 22050
                },
                new ClientEmployee
                {
                    Id = 3,
                    SalesTerritoryId = 238502,
                    SalesTerritoryName = "PROXIMUS - BE",
                    AmountEmployee = 1000,
                    ITspendByYear = 53960
                },
                new ClientEmployee
                {
                    Id = 4,
                    SalesTerritoryId = 700005236,
                    SalesTerritoryName = "GROUP MACHIELS NV - BE",
                    AmountEmployee = 293,
                    ITspendByYear = 29890
                },
                new ClientEmployee
                {
                    Id = 5,
                    SalesTerritoryId = 700013305,
                    SalesTerritoryName = "HENCO NV - BE",
                    AmountEmployee = 160,
                    ITspendByYear = 53600
                }
                );

            //Installbase even skippen want speciaal geval
            modelBuilder.Entity<InstallBase>().HasData(
                new InstallBase
                {
                    Id = 1,
                    SalesTerritoryId = 225954,
                    Dell = 10,
                    Apple = 2,
                    Hp = 2,
                    Samsung = 2,
                    Msi = 7
                },
                new InstallBase
                {
                    Id = 2,
                    SalesTerritoryId = 226950,
                    Dell = 3,
                    Apple = 7,
                    Hp = 8,
                    Samsung = 1,
                    Msi = 9
                },
                new InstallBase
                {
                    Id = 3,
                    SalesTerritoryId = 238502,
                    Dell = 4,
                    Apple = 1,
                    Hp = 6,
                    Samsung = 7,
                    Msi = 8
                },
                new InstallBase
                {
                    Id = 4,
                    SalesTerritoryId = 700005236,
                    Dell = 6,
                    Apple = 5,
                    Hp = 4,
                    Samsung = 3,
                    Msi = 1
                },
                new InstallBase
                {
                    Id = 5,
                    SalesTerritoryId = 700013305,
                    Dell = 7,
                    Apple = 7,
                    Hp = 5,
                    Samsung = 9,
                    Msi = 4
                }
             );

            modelBuilder.Entity<ProductHierarchy>().HasData(
                new ProductHierarchy
                {
                    Id = 1,
                    BaCode = "5T00",
                    PlCode = "5T",
                    L6Description = "A4 Value LaserJet C-SKU Supplies",
                    L5Description = "A4 Value LaserJet Supplies",
                    L4Description = "OPS Supplies",
                    L3Description = "Office Printing Solutions",
                    L2Description = "Print"
                }
                );

            modelBuilder.Entity<RAD>().HasData(
                new RAD
                {
                    Id = 1,
                    AccountStId = 225954,
                    SalesLetterName = "A. DEVELOPMENT - BE",
                    TopSalesTerritoryName = "COMPUDRUG SA - WW",
                    CustSegCode = "SMB",
                    PcFrameName = "-",
                    PcFrameRadFinal = "MM - A1",
                    PcTam = 97.0588235294118,
                    NumberOfEmployees = 1,
                    Vertical = "MANUFACTURING",
                    HpSow = 0
                },
                new RAD
                {
                    Id = 2,
                    AccountStId = 226950,
                    SalesLetterName = "ADOBE SYSTEMS BENELUX - BE",
                    TopSalesTerritoryName = "ADOBE SYSTEMS INCORPORATED - WW",
                    CustSegCode = "CORPORATE",
                    PcFrameName = "-",
                    PcFrameRadFinal = "CEP - A1",
                    PcTam = 1598.23529411765,
                    NumberOfEmployees = 11,
                    Vertical = "CONSULTING",
                    HpSow = 0
                },
                new RAD
                {
                    Id = 3,
                    AccountStId = 238502,
                    SalesLetterName = "PROXIMUS - BE",
                    TopSalesTerritoryName = "PROXIMUS SA - WW",
                    CustSegCode = "CORPORATE",
                    PcFrameName = "-",
                    PcFrameRadFinal = "CEP - D3",
                    PcTam = 3176470.58823529,
                    NumberOfEmployees = 13209,
                    Vertical = "TELCO",
                    HpSow = 33
                },
                new RAD
                {
                    Id = 4,
                    AccountStId = 700005236,
                    SalesLetterName = "GROUP MACHIELS NV - BE",
                    TopSalesTerritoryName = "-",
                    CustSegCode = "SMB",
                    PcFrameName = "-",
                    PcFrameRadFinal = "MM - A1",
                    PcTam = 11707.3529411765,
                    NumberOfEmployees = 222,
                    Vertical = "MANUFACTURING",
                    HpSow = 0
                },
                new RAD
                {
                    Id = 5,
                    AccountStId = 700013305,
                    SalesLetterName = "HENCO NV - BE",
                    TopSalesTerritoryName = "-",
                    CustSegCode = "SMB",
                    PcFrameName = "-",
                    PcFrameRadFinal = "MM - A2",
                    PcTam = 20588.2352941176,
                    NumberOfEmployees = 240,
                    Vertical = "MANUFACTURING",
                    HpSow = 18
                }
                );

            modelBuilder.Entity<RevenueActuals>().HasData(
                new RevenueActuals
                {
                    Id = 1,
                    Year = 2017,
                    Quarter = "2017Q1",
                    Month = 201611,
                    Country = "Belgium",
                    SubBusinessGroupL3 = "Business PC Solutions",
                    BusinessUnitL5 = "Commercial Notebooks",
                    Ba = "5T00",
                    SalesChannelName = "Mid Market",
                    FulfillmentModel = "?",
                    PsoacMcCode = "AA9R",
                    EndCustomerName = "Bocimar International",
                    Amid2Customer = "",
                    ClassCode = "GMN",
                    RevKSadj = -0.00151274569324208,
                    CosKSadj = 0,
                    Units = 0,
                    DealId = 0,
                    Dataflow = "Cash Discount_Claims"
                },
                new RevenueActuals
                {
                    Id = 2,
                    Year = 2017,
                    Quarter = "2017Q4",
                    Month = 201710,
                    Country = "Belgium",
                    SubBusinessGroupL3 = "Business PC Solutions",
                    BusinessUnitL5 = "Mobile Workstations",
                    Ba = "TA00",
                    SalesChannelName = "VAR",
                    FulfillmentModel = "STM",
                    PsoacMcCode = "Y72A",
                    EndCustomerName = "Belgacom",
                    Amid2Customer = "",
                    ClassCode = "GSM",
                    RevKSadj = 40,
                    CosKSadj = 2,
                    Units = 115,
                    DealId = 0,
                    Dataflow = "Transactions"
                },
                new RevenueActuals
                {
                    Id = 3,
                    Year = 2018,
                    Quarter = "2018Q3",
                    Month = 201807,
                    Country = "Belgium",
                    SubBusinessGroupL3 = "Business PC Solutions",
                    BusinessUnitL5 = "Commercial Desktops",
                    Ba = "DG00",
                    SalesChannelName = "Distributor Code",
                    FulfillmentModel = "?",
                    PsoacMcCode = "Y2MA",
                    EndCustomerName = "Real Estate and Leasing Company",
                    Amid2Customer = "",
                    ClassCode = "PUBL",
                    RevKSadj = 37,
                    CosKSadj = 3,
                    Units = 70,
                    DealId = 41402383,
                    Dataflow = "Transactions"
                },
                new RevenueActuals
                {
                    Id = 4,
                    Year = 2019,
                    Quarter = "2019Q1",
                    Month = 201812,
                    Country = "Belgium",
                    SubBusinessGroupL3 = "Business PC Solutions",
                    BusinessUnitL5 = "Commercial Accessories",
                    Ba = "MP00",
                    SalesChannelName = "VAR",
                    FulfillmentModel = "STM",
                    PsoacMcCode = "Y72A",
                    EndCustomerName = "Brands in Motion",
                    Amid2Customer = "",
                    ClassCode = "PUBL",
                    RevKSadj = 30,
                    CosKSadj = 2,
                    Units = 0,
                    DealId = 41113723,
                    Dataflow = "Transactions"
                },
                new RevenueActuals
                {
                    Id = 5,
                    Year = 2017,
                    Quarter = "2017Q4",
                    Month = 201709,
                    Country = "Belgium",
                    SubBusinessGroupL3 = "Business PC Solutions",
                    BusinessUnitL5 = "Commercial Notebooks",
                    Ba = "AN00",
                    SalesChannelName = "Mid Market",
                    FulfillmentModel = "?",
                    PsoacMcCode = "YA9A",
                    EndCustomerName = "Van Hecke Dirk",
                    Amid2Customer = "",
                    ClassCode = "GSM",
                    RevKSadj = 23,
                    CosKSadj = 1,
                    Units = 24,
                    DealId = 0,
                    Dataflow = "Transactions"
                }
                );

            //territorycompany even skippen want speciaal geval zie installbase
            modelBuilder.Entity<TerritoryCompany>().HasData(
                new TerritoryCompany
                {
                    Id = 1,
                    CompanyId = 225954,
                    CompanyName = "A. DEVELOPMENT - BE",
                    AmountDesktop = 270,
                    AmountThinClient = 6,
                    AmountLaptop = 87,
                },
                new TerritoryCompany
                {
                    Id = 2,
                    CompanyId = 226950,
                    CompanyName = "ADOBE SYSTEMS BENELUX - BE",
                    AmountDesktop = 123,
                    AmountThinClient = 7,
                    AmountLaptop = 81,
                },
                new TerritoryCompany
                {
                    Id = 3,
                    CompanyId = 238502,
                    CompanyName = "PROXIMUS - BE",
                    AmountDesktop = 54,
                    AmountThinClient = 45,
                    AmountLaptop = 752,
                },
                new TerritoryCompany
                {
                    Id = 4,
                    CompanyId = 700005236,
                    CompanyName = "GROUP MACHIELS NV - BE",
                    AmountDesktop = 524,
                    AmountThinClient = 44,
                    AmountLaptop = 95,
                },
                new TerritoryCompany
                {
                    Id = 5,
                    CompanyId = 700013305,
                    CompanyName = "HENCO NV - BE",
                    AmountDesktop = 78,
                    AmountThinClient = 4,
                    AmountLaptop = 54,
                }
                );

            modelBuilder.Entity<Workday>().HasData(
                new Workday
                {
                    Id = 1,
                    AccountStId = 225954,
                    SalesLetterName = "A. DEVELOPMENT - BE",
                    FsrPc = "-",
                    IsrPc = "-",
                    PcHunter = "-"
                }
                );
        }
    }
}
