using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HP_Project.DAL.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apollo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AccountNameLatin = table.Column<string>(nullable: true),
                    AccountType = table.Column<int>(nullable: false),
                    AccountSubType = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IndustrySegment = table.Column<string>(nullable: true),
                    IndustryVertical = table.Column<string>(nullable: true),
                    MyProperty = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    SubRegion1 = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    PrivateAccount = table.Column<bool>(nullable: false),
                    AccountSTID = table.Column<int>(nullable: false),
                    AccountSTName = table.Column<string>(nullable: true),
                    TopParentSTID = table.Column<int>(nullable: true),
                    TopParentSTName = table.Column<string>(nullable: true),
                    PartialAccountSTID = table.Column<int>(nullable: false),
                    PartialAccountSTName = table.Column<string>(nullable: true),
                    OrganizationID = table.Column<int>(nullable: false),
                    OPSIID = table.Column<int>(nullable: false),
                    PRMID = table.Column<string>(nullable: true),
                    BusinessRelationshipID = table.Column<int>(nullable: false),
                    TaxIdentifier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apollo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesTerritoryId = table.Column<int>(nullable: false),
                    SalesTerritoryName = table.Column<string>(nullable: true),
                    AmountEmployee = table.Column<int>(nullable: false),
                    ITspendByYear = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientEmployees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Client = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstallBase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesTerritoryId = table.Column<int>(nullable: false),
                    Dell = table.Column<int>(nullable: false),
                    Apple = table.Column<int>(nullable: false),
                    Hp = table.Column<int>(nullable: false),
                    Samsung = table.Column<int>(nullable: false),
                    Msi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductHierarchy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaCode = table.Column<string>(nullable: true),
                    PlCode = table.Column<string>(nullable: true),
                    L6Description = table.Column<string>(nullable: true),
                    L5Description = table.Column<string>(nullable: true),
                    L4Description = table.Column<string>(nullable: true),
                    L3Description = table.Column<string>(nullable: true),
                    L2Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductHierarchy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RAD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountStId = table.Column<int>(nullable: false),
                    SalesLetterName = table.Column<string>(nullable: true),
                    TopSalesTerritoryName = table.Column<string>(nullable: true),
                    CustSegCode = table.Column<string>(nullable: true),
                    PcFrameName = table.Column<string>(nullable: true),
                    PcFrameRadFinal = table.Column<string>(nullable: true),
                    PcTam = table.Column<double>(nullable: false),
                    NumberOfEmployees = table.Column<int>(nullable: false),
                    Vertical = table.Column<string>(nullable: true),
                    HpSow = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevenueActuals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(nullable: false),
                    Quarter = table.Column<string>(nullable: true),
                    Month = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    SubBusinessGroupL3 = table.Column<string>(nullable: true),
                    BusinessUnitL5 = table.Column<string>(nullable: true),
                    Ba = table.Column<string>(nullable: true),
                    SalesChannelName = table.Column<string>(nullable: true),
                    FulfillmentModel = table.Column<string>(nullable: true),
                    PsoacMcCode = table.Column<string>(nullable: true),
                    EndCustomerName = table.Column<string>(nullable: true),
                    Amid2Customer = table.Column<string>(nullable: true),
                    ClassCode = table.Column<string>(nullable: true),
                    RevKSadj = table.Column<double>(nullable: false),
                    CosKSadj = table.Column<double>(nullable: false),
                    Units = table.Column<int>(nullable: false),
                    DealId = table.Column<int>(nullable: false),
                    Dataflow = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueActuals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workday",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountStId = table.Column<int>(nullable: false),
                    SalesLetterName = table.Column<string>(nullable: true),
                    FsrPc = table.Column<string>(nullable: true),
                    IsrPc = table.Column<string>(nullable: true),
                    PcHunter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workday", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<long>(nullable: false),
                    Mkt = table.Column<bool>(nullable: false),
                    CIOCircle = table.Column<string>(nullable: true),
                    InnovationForum = table.Column<bool>(nullable: false),
                    TAC = table.Column<bool>(nullable: false),
                    PostalAddress = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TerritoryCompany",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    AmountDesktop = table.Column<int>(nullable: false),
                    AmountThinClient = table.Column<int>(nullable: false),
                    AmountLaptop = table.Column<int>(nullable: false),
                    InstallBaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritoryCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerritoryCompany_InstallBase_InstallBaseId",
                        column: x => x.InstallBaseId,
                        principalTable: "InstallBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Touchpoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    SortOfEvent = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Reminder = table.Column<DateTime>(nullable: false),
                    ContactId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Touchpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Touchpoints_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Touchpoints_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Apollo",
                columns: new[] { "Id", "AccountNameLatin", "AccountSTID", "AccountSTName", "AccountSubType", "AccountType", "BusinessRelationshipID", "City", "Country", "IndustrySegment", "IndustryVertical", "MyProperty", "Name", "OPSIID", "OrganizationID", "PRMID", "PartialAccountSTID", "PartialAccountSTName", "PrivateAccount", "Province", "Region", "Status", "SubRegion1", "TaxIdentifier", "TopParentSTID", "TopParentSTName" },
                values: new object[,]
                {
                    { 1, "Ah Development", 225954, null, 0, 0, 0, null, null, null, null, 0, "Ah Development", 0, 0, null, 0, null, false, null, null, 0, null, null, null, null },
                    { 2, "Adobe Systems Belgium BVBA", 0, null, 0, 0, 0, null, null, null, null, 0, "Adobe Systems Belgium BVBA", 0, 0, null, 0, null, false, null, null, 0, null, null, null, null },
                    { 3, "BELGACOM", 0, null, 0, 0, 0, null, null, null, null, 0, "BELGACOM", 0, 0, null, 0, null, false, null, null, 0, null, null, null, null },
                    { 4, "Machiels Building solutions", 0, null, 0, 0, 0, null, null, null, null, 0, "Machiels Building solutions", 0, 0, null, 0, null, false, null, null, 0, null, null, null, null },
                    { 5, "Henco Industries", 0, null, 0, 0, 0, null, null, null, null, 0, "Henco Industries", 0, 0, null, 0, null, false, null, null, 0, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "42925b4b-11b3-453e-9078-849701c26242", "annick.verscheuren@hptest.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEBFD/mzYDUJIbacSc4JjveEuqc8eG/V2a1Zwl2L90szemfF7x/Dni6MATosSOKstTQ==", null, false, "ec52066d-4298-464e-bc81-adefd13cd570", false, "Annick Verscheuren" },
                    { "2", 0, "5814ff5f-11d0-409b-9fc4-b0a8c073020d", "koen.vanbeneden@hptest.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEBFD/mzYDUJIbacSc4JjveEuqc8eG/V2a1Zwl2L90szemfF7x/Dni6MATosSOKstTQ==", null, false, "954216a6-3756-4abd-92e6-b99901f65c37", false, "Koen Van Beneden" },
                    { "3", 0, "2db5a959-ad01-4f07-970c-edfd0554a963", "jan.das@hptest.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEBFD/mzYDUJIbacSc4JjveEuqc8eG/V2a1Zwl2L90szemfF7x/Dni6MATosSOKstTQ==", null, false, "d49c44a2-42eb-434c-84fd-fcad9fb0be5f", false, "Jan Das" }
                });

            migrationBuilder.InsertData(
                table: "ClientEmployees",
                columns: new[] { "Id", "AmountEmployee", "ITspendByYear", "SalesTerritoryId", "SalesTerritoryName" },
                values: new object[,]
                {
                    { 1, 160000, 9280000.0, 225954, "A. DEVELOPMENT - BE" },
                    { 2, 50, 22050.0, 226950, "ADOBE SYSTEMS BENELUX - BE" },
                    { 3, 1000, 53960.0, 238502, "PROXIMUS - BE" },
                    { 4, 293, 29890.0, 700005236, "GROUP MACHIELS NV - BE" },
                    { 5, 160, 53600.0, 700013305, "HENCO NV - BE" }
                });

            migrationBuilder.InsertData(
                table: "InstallBase",
                columns: new[] { "Id", "Apple", "Dell", "Hp", "Msi", "SalesTerritoryId", "Samsung" },
                values: new object[,]
                {
                    { 4, 5, 6, 4, 1, 700005236, 3 },
                    { 3, 1, 4, 6, 8, 238502, 7 },
                    { 5, 7, 7, 5, 4, 700013305, 9 },
                    { 1, 2, 10, 2, 7, 225954, 2 },
                    { 2, 7, 3, 8, 9, 226950, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductHierarchy",
                columns: new[] { "Id", "BaCode", "L2Description", "L3Description", "L4Description", "L5Description", "L6Description", "PlCode" },
                values: new object[] { 1, "5T00", "Print", "Office Printing Solutions", "OPS Supplies", "A4 Value LaserJet Supplies", "A4 Value LaserJet C-SKU Supplies", "5T" });

            migrationBuilder.InsertData(
                table: "RAD",
                columns: new[] { "Id", "AccountStId", "CustSegCode", "HpSow", "NumberOfEmployees", "PcFrameName", "PcFrameRadFinal", "PcTam", "SalesLetterName", "TopSalesTerritoryName", "Vertical" },
                values: new object[,]
                {
                    { 1, 225954, "SMB", 0.0, 1, "-", "MM - A1", 97.058823529411796, "A. DEVELOPMENT - BE", "COMPUDRUG SA - WW", "MANUFACTURING" },
                    { 2, 226950, "CORPORATE", 0.0, 11, "-", "CEP - A1", 1598.23529411765, "ADOBE SYSTEMS BENELUX - BE", "ADOBE SYSTEMS INCORPORATED - WW", "CONSULTING" },
                    { 3, 238502, "CORPORATE", 33.0, 13209, "-", "CEP - D3", 3176470.5882352898, "PROXIMUS - BE", "PROXIMUS SA - WW", "TELCO" },
                    { 4, 700005236, "SMB", 0.0, 222, "-", "MM - A1", 11707.352941176499, "GROUP MACHIELS NV - BE", "-", "MANUFACTURING" },
                    { 5, 700013305, "SMB", 18.0, 240, "-", "MM - A2", 20588.2352941176, "HENCO NV - BE", "-", "MANUFACTURING" }
                });

            migrationBuilder.InsertData(
                table: "RevenueActuals",
                columns: new[] { "Id", "Amid2Customer", "Ba", "BusinessUnitL5", "ClassCode", "CosKSadj", "Country", "Dataflow", "DealId", "EndCustomerName", "FulfillmentModel", "Month", "PsoacMcCode", "Quarter", "RevKSadj", "SalesChannelName", "SubBusinessGroupL3", "Units", "Year" },
                values: new object[,]
                {
                    { 5, "", "AN00", "Commercial Notebooks", "GSM", 1.0, "Belgium", "Transactions", 0, "Van Hecke Dirk", "?", 201709, "YA9A", "2017Q4", 23.0, "Mid Market", "Business PC Solutions", 24, 2017 },
                    { 4, "", "MP00", "Commercial Accessories", "PUBL", 2.0, "Belgium", "Transactions", 41113723, "Brands in Motion", "STM", 201812, "Y72A", "2019Q1", 30.0, "VAR", "Business PC Solutions", 0, 2019 },
                    { 2, "", "TA00", "Mobile Workstations", "GSM", 2.0, "Belgium", "Transactions", 0, "Belgacom", "STM", 201710, "Y72A", "2017Q4", 40.0, "VAR", "Business PC Solutions", 115, 2017 },
                    { 1, "", "5T00", "Commercial Notebooks", "GMN", 0.0, "Belgium", "Cash Discount_Claims", 0, "Bocimar International", "?", 201611, "AA9R", "2017Q1", -0.0015127456932420801, "Mid Market", "Business PC Solutions", 0, 2017 },
                    { 3, "", "DG00", "Commercial Desktops", "PUBL", 3.0, "Belgium", "Transactions", 41402383, "Real Estate and Leasing Company", "?", 201807, "Y2MA", "2018Q3", 37.0, "Distributor Code", "Business PC Solutions", 70, 2018 }
                });

            migrationBuilder.InsertData(
                table: "TerritoryCompany",
                columns: new[] { "Id", "AmountDesktop", "AmountLaptop", "AmountThinClient", "CompanyId", "CompanyName", "InstallBaseId" },
                values: new object[,]
                {
                    { 5, 78, 54, 4, 700013305, "HENCO NV - BE", null },
                    { 1, 270, 87, 6, 225954, "A. DEVELOPMENT - BE", null },
                    { 2, 123, 81, 7, 226950, "ADOBE SYSTEMS BENELUX - BE", null },
                    { 3, 54, 752, 45, 238502, "PROXIMUS - BE", null },
                    { 4, 524, 95, 44, 700005236, "GROUP MACHIELS NV - BE", null }
                });

            migrationBuilder.InsertData(
                table: "Workday",
                columns: new[] { "Id", "AccountStId", "FsrPc", "IsrPc", "PcHunter", "SalesLetterName" },
                values: new object[] { 1, 225954, "-", "-", "-", "A. DEVELOPMENT - BE" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "ApplicationUserId", "CIOCircle", "Comments", "Email", "FirstName", "InnovationForum", "LastName", "Mkt", "Phone", "PostalAddress", "Role", "TAC" },
                values: new object[,]
                {
                    { 1, "1", "", "", "jos@axa.be", "Jos", false, "De Bosvos", true, 32477901011L, "Abcde", "IT director", true },
                    { 3, "1", "", "", "willy@axa.be", "Willy", true, "Willems", false, 32477901013L, "Abcde", "Device Manager", false },
                    { 2, "2", "nominated", "", "freddy@axa.be", "Freddy", false, "De Zoetwatervis", false, 32477901012L, "Abcde", "CIO", false },
                    { 4, "3", "", "", "kenny@axa.be", "Kenny", true, "Kenens", false, 32477901014L, "Abcde", "Image creator", true }
                });

            migrationBuilder.InsertData(
                table: "Touchpoints",
                columns: new[] { "Id", "ApplicationUserId", "ContactId", "Date", "Description", "Reminder", "SortOfEvent" },
                values: new object[,]
                {
                    { 1, "1", 1, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New RFP for Notebooks and desktops (old RFP ends 6/18)", new DateTime(2018, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RFP" },
                    { 2, "1", 1, new DateTime(2018, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plan roadmap update", new DateTime(2017, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "meeting" },
                    { 4, "3", 3, new DateTime(2016, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intro mailer Elite x3 - opened and followed link to landing page", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marketing email" },
                    { 3, "2", 2, new DateTime(2016, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roadmap update 2016 - interested in Elitebook 840/850 and Elite x3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "meeting" },
                    { 5, "2", 4, new DateTime(2016, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elite x3 CIO event - interested in MFP renewal and DaaS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ApplicationUserId",
                table: "Contacts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryCompany_InstallBaseId",
                table: "TerritoryCompany",
                column: "InstallBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Touchpoints_ApplicationUserId",
                table: "Touchpoints",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Touchpoints_ContactId",
                table: "Touchpoints",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apollo");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClientEmployees");

            migrationBuilder.DropTable(
                name: "Insights");

            migrationBuilder.DropTable(
                name: "ProductHierarchy");

            migrationBuilder.DropTable(
                name: "RAD");

            migrationBuilder.DropTable(
                name: "RevenueActuals");

            migrationBuilder.DropTable(
                name: "TerritoryCompany");

            migrationBuilder.DropTable(
                name: "Touchpoints");

            migrationBuilder.DropTable(
                name: "Workday");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "InstallBase");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
