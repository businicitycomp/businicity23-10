using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastrucer.Migrations
{
    public partial class finaldb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CareerPath",
                columns: table => new
                {
                    CareerPathID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCareer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerPath", x => x.CareerPathID);
                });

            migrationBuilder.CreateTable(
                name: "CatPerson",
                columns: table => new
                {
                    CatPersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatPerson", x => x.CatPersonID);
                });

            migrationBuilder.CreateTable(
                name: "CatTemp",
                columns: table => new
                {
                    CatTempID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SixMointh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnYears = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTemp", x => x.CatTempID);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    ContactUsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Messsage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.ContactUsID);
                });

            migrationBuilder.CreateTable(
                name: "Educationlevel",
                columns: table => new
                {
                    EducationlevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    levelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educationlevel", x => x.EducationlevelID);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    InfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flag = table.Column<int>(type: "int", nullable: false),
                    Linklinkedin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.InfoID);
                });

            migrationBuilder.CreateTable(
                name: "jobVacancy",
                columns: table => new
                {
                    jobVacancyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requirements = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pathpdf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobVacancy", x => x.jobVacancyID);
                });

            migrationBuilder.CreateTable(
                name: "PostCompany",
                columns: table => new
                {
                    PostCompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitelePost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailsPost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCompany", x => x.PostCompanyID);
                });

            migrationBuilder.CreateTable(
                name: "SkillsPerson",
                columns: table => new
                {
                    SkillsPersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Courses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsPerson", x => x.SkillsPersonID);
                });

            migrationBuilder.CreateTable(
                name: "Targetsector",
                columns: table => new
                {
                    TargetsectorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    namesector = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targetsector", x => x.TargetsectorID);
                });

            migrationBuilder.CreateTable(
                name: "TypeCompany",
                columns: table => new
                {
                    TypeCompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typename = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCompany", x => x.TypeCompanyID);
                });

            migrationBuilder.CreateTable(
                name: "TypeIdea",
                columns: table => new
                {
                    TypeIdeaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeIdea", x => x.TypeIdeaID);
                });

            migrationBuilder.CreateTable(
                name: "Univircity",
                columns: table => new
                {
                    UnivircityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Univircity", x => x.UnivircityID);
                });

            migrationBuilder.CreateTable(
                name: "yourstatus",
                columns: table => new
                {
                    yourstatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yourstatus", x => x.yourstatusID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "DetailsPerson",
                columns: table => new
                {
                    DetailsPersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutUs = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    Expirence = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    AboutImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebooklink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Whatslink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatPersonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsPerson", x => x.DetailsPersonID);
                    table.ForeignKey(
                        name: "FK_DetailsPerson_CatPerson_CatPersonID",
                        column: x => x.CatPersonID,
                        principalTable: "CatPerson",
                        principalColumn: "CatPersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Templete",
                columns: table => new
                {
                    TempleteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackgroundTemp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoTemp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChoesePrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatTempID = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templete", x => x.TempleteID);
                    table.ForeignKey(
                        name: "FK_Templete_CatTemp_CatTempID",
                        column: x => x.CatTempID,
                        principalTable: "CatTemp",
                        principalColumn: "CatTempID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sFirstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sLastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    volunteerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.volunteerID);
                    table.ForeignKey(
                        name: "FK_Volunteer_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OurServices",
                columns: table => new
                {
                    OurServicesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbuotServ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkFace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkTwet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkInsta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkWats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyNo = table.Column<int>(type: "int", nullable: false),
                    DomainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoID = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurServices", x => x.OurServicesID);
                    table.ForeignKey(
                        name: "FK_OurServices_Info_InfoID",
                        column: x => x.InfoID,
                        principalTable: "Info",
                        principalColumn: "InfoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServicesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servicename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paragraph = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoID = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServicesID);
                    table.ForeignKey(
                        name: "FK_Services_Info_InfoID",
                        column: x => x.InfoID,
                        principalTable: "Info",
                        principalColumn: "InfoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplayJob",
                columns: table => new
                {
                    ApplayJobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobVacancyID = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserbusID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplayJob", x => x.ApplayJobID);
                    table.ForeignKey(
                        name: "FK_ApplayJob_jobVacancy_JobVacancyID",
                        column: x => x.JobVacancyID,
                        principalTable: "jobVacancy",
                        principalColumn: "jobVacancyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invistor",
                columns: table => new
                {
                    InvistorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flag = table.Column<int>(type: "int", nullable: false),
                    TargetsectorID = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invistor", x => x.InvistorID);
                    table.ForeignKey(
                        name: "FK_Invistor_Targetsector_TargetsectorID",
                        column: x => x.TargetsectorID,
                        principalTable: "Targetsector",
                        principalColumn: "TargetsectorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuppourtIdea",
                columns: table => new
                {
                    SuppourtIdeaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commercialrecord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Careerslicense = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateofRegistration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flag = table.Column<int>(type: "int", nullable: false),
                    TargetsectorID = table.Column<int>(type: "int", nullable: true),
                    TypeCompanyID = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuppourtIdea", x => x.SuppourtIdeaID);
                    table.ForeignKey(
                        name: "FK_SuppourtIdea_Targetsector_TargetsectorID",
                        column: x => x.TargetsectorID,
                        principalTable: "Targetsector",
                        principalColumn: "TargetsectorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SuppourtIdea_TypeCompany_TypeCompanyID",
                        column: x => x.TypeCompanyID,
                        principalTable: "TypeCompany",
                        principalColumn: "TypeCompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Idea",
                columns: table => new
                {
                    IdeaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ideaname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descreption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fileidea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeIdeaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idea", x => x.IdeaID);
                    table.ForeignKey(
                        name: "FK_Idea_TypeIdea_TypeIdeaID",
                        column: x => x.TypeIdeaID,
                        principalTable: "TypeIdea",
                        principalColumn: "TypeIdeaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataPerson",
                columns: table => new
                {
                    DataPersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderID = table.Column<int>(type: "int", nullable: true),
                    EducationlevelID = table.Column<int>(type: "int", nullable: true),
                    UnivircityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPerson", x => x.DataPersonID);
                    table.ForeignKey(
                        name: "FK_DataPerson_Educationlevel_EducationlevelID",
                        column: x => x.EducationlevelID,
                        principalTable: "Educationlevel",
                        principalColumn: "EducationlevelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataPerson_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataPerson_Univircity_UnivircityID",
                        column: x => x.UnivircityID,
                        principalTable: "Univircity",
                        principalColumn: "UnivircityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedInLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cvpdf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flag = table.Column<int>(type: "int", nullable: false),
                    EducationlevelID = table.Column<int>(type: "int", nullable: true),
                    UnivircityID = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Person_Educationlevel_EducationlevelID",
                        column: x => x.EducationlevelID,
                        principalTable: "Educationlevel",
                        principalColumn: "EducationlevelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Univircity_UnivircityID",
                        column: x => x.UnivircityID,
                        principalTable: "Univircity",
                        principalColumn: "UnivircityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Datavocational",
                columns: table => new
                {
                    DatavocationalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: true),
                    CareerPathID = table.Column<int>(type: "int", nullable: true),
                    yourstatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datavocational", x => x.DatavocationalID);
                    table.ForeignKey(
                        name: "FK_Datavocational_CareerPath_CareerPathID",
                        column: x => x.CareerPathID,
                        principalTable: "CareerPath",
                        principalColumn: "CareerPathID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Datavocational_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Datavocational_yourstatus_yourstatusID",
                        column: x => x.yourstatusID,
                        principalTable: "yourstatus",
                        principalColumn: "yourstatusID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "SupportedIdeas",
                columns: table => new
                {
                    SupportedIdeasID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdeaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportedIdeas", x => x.SupportedIdeasID);
                    table.ForeignKey(
                        name: "FK_SupportedIdeas_Idea_IdeaID",
                        column: x => x.IdeaID,
                        principalTable: "Idea",
                        principalColumn: "IdeaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplayJob_JobVacancyID",
                table: "ApplayJob",
                column: "JobVacancyID");

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
                name: "IX_AspNetUsers_GenderID",
                table: "AspNetUsers",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DataPerson_EducationlevelID",
                table: "DataPerson",
                column: "EducationlevelID");

            migrationBuilder.CreateIndex(
                name: "IX_DataPerson_GenderID",
                table: "DataPerson",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_DataPerson_UnivircityID",
                table: "DataPerson",
                column: "UnivircityID");

            migrationBuilder.CreateIndex(
                name: "IX_Datavocational_CareerPathID",
                table: "Datavocational",
                column: "CareerPathID");

            migrationBuilder.CreateIndex(
                name: "IX_Datavocational_GenderID",
                table: "Datavocational",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Datavocational_yourstatusID",
                table: "Datavocational",
                column: "yourstatusID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsPerson_CatPersonID",
                table: "DetailsPerson",
                column: "CatPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Idea_TypeIdeaID",
                table: "Idea",
                column: "TypeIdeaID");

            migrationBuilder.CreateIndex(
                name: "IX_Invistor_TargetsectorID",
                table: "Invistor",
                column: "TargetsectorID");

            migrationBuilder.CreateIndex(
                name: "IX_OurServices_InfoID",
                table: "OurServices",
                column: "InfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_EducationlevelID",
                table: "Person",
                column: "EducationlevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_UnivircityID",
                table: "Person",
                column: "UnivircityID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_InfoID",
                table: "Services",
                column: "InfoID");

            migrationBuilder.CreateIndex(
                name: "IX_SupportedIdeas_IdeaID",
                table: "SupportedIdeas",
                column: "IdeaID");

            migrationBuilder.CreateIndex(
                name: "IX_SuppourtIdea_TargetsectorID",
                table: "SuppourtIdea",
                column: "TargetsectorID");

            migrationBuilder.CreateIndex(
                name: "IX_SuppourtIdea_TypeCompanyID",
                table: "SuppourtIdea",
                column: "TypeCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Templete_CatTempID",
                table: "Templete",
                column: "CatTempID");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_GenderID",
                table: "Volunteer",
                column: "GenderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplayJob");

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
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "DataPerson");

            migrationBuilder.DropTable(
                name: "Datavocational");

            migrationBuilder.DropTable(
                name: "DetailsPerson");

            migrationBuilder.DropTable(
                name: "Invistor");

            migrationBuilder.DropTable(
                name: "OurServices");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "PostCompany");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "SkillsPerson");

            migrationBuilder.DropTable(
                name: "SupportedIdeas");

            migrationBuilder.DropTable(
                name: "SuppourtIdea");

            migrationBuilder.DropTable(
                name: "Templete");

            migrationBuilder.DropTable(
                name: "Volunteer");

            migrationBuilder.DropTable(
                name: "jobVacancy");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CareerPath");

            migrationBuilder.DropTable(
                name: "yourstatus");

            migrationBuilder.DropTable(
                name: "CatPerson");

            migrationBuilder.DropTable(
                name: "Educationlevel");

            migrationBuilder.DropTable(
                name: "Univircity");

            migrationBuilder.DropTable(
                name: "Info");

            migrationBuilder.DropTable(
                name: "Idea");

            migrationBuilder.DropTable(
                name: "Targetsector");

            migrationBuilder.DropTable(
                name: "TypeCompany");

            migrationBuilder.DropTable(
                name: "CatTemp");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "TypeIdea");
        }
    }
}
