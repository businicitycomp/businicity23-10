// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataContext.cs" company="Bisnicity.com">
//     Create By :: Samer 
//     Date  :: 07-10-2021
//     Action :: EntityObject
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisnicityApp.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Infrastrucer.Models;

namespace Infrastrucer
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        #region DB
        #region DataConetx
        /// <summary>
        //Add AspIdentity For DbContext
        //Install Entity For Identity
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        #endregion
        #endregion
        #region Methods
        #region Mehotd :: OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Info>().HasKey(x => x.InfoID);
            modelBuilder.Entity<OurServices>().HasKey(x => x.OurServicesID);
            modelBuilder.Entity<Services>().HasKey(x => x.ServicesID);
            modelBuilder.Entity<Templete>().HasKey(x => x.TempleteID);
            modelBuilder.Entity<CatTemp>().HasKey(x => x.CatTempID);
            modelBuilder.Entity<jobVacancy>().HasKey(x => x.jobVacancyID);
            modelBuilder.Entity<Person>().HasKey(x => x.PersonID);
            modelBuilder.Entity<Educationlevel>().HasKey(x => x.EducationlevelID);
            modelBuilder.Entity<Gender>().HasKey(x => x.GenderID);
            modelBuilder.Entity<CatPerson>().HasKey(x => x.CatPersonID);
            modelBuilder.Entity<DetailsPerson>().HasKey(x => x.DetailsPersonID);
            modelBuilder.Entity<SkillsPerson>().HasKey(x => x.SkillsPersonID);
            modelBuilder.Entity<DataPerson>().HasKey(x => x.DataPersonID);
            modelBuilder.Entity<PostCompany>().HasKey(x => x.PostCompanyID);
            modelBuilder.Entity<ApplayJob>().HasKey(x => x.ApplayJobID);
            modelBuilder.Entity<Univircity>().HasKey(x => x.UnivircityID);
            modelBuilder.Entity<Idea>().HasKey(x => x.IdeaID);
            modelBuilder.Entity<SuppourtIdea>().HasKey(x => x.SuppourtIdeaID);
            modelBuilder.Entity<CareerPath>().HasKey(x => x.CareerPathID);
            modelBuilder.Entity<TypeCompany>().HasKey(x => x.TypeCompanyID);
            modelBuilder.Entity<Targetsector>().HasKey(x => x.TargetsectorID);
            modelBuilder.Entity<Datavocational>().HasKey(x => x.DatavocationalID);
            modelBuilder.Entity<yourstatus>().HasKey(x => x.yourstatusID);
            modelBuilder.Entity<ContactUs>().HasKey(x => x.ContactUsID);
            modelBuilder.Entity<ContactUs>().HasKey(x => x.ContactUsID);
            modelBuilder.Entity<Invistor>().HasKey(x => x.InvistorID);
            modelBuilder.Entity<volunteer>().HasKey(x => x.volunteerID);
            modelBuilder.Entity<ApplicationUser>().Property(x => x.sFirstname);
            modelBuilder.Entity<ApplicationUser>().Property(x => x.sLastname);
            modelBuilder.Entity<ApplicationUser>().Property(x => x.GenderID);
            modelBuilder.Entity<SupportedIdeas>().Property(x => x.SupportedIdeasID);
            modelBuilder.Entity<TypeIdea>().Property(x => x.TypeIdeaID);

        }
        #endregion
        #endregion
        #region EntityObject
        /// <summary>
        ///   The Model For Data Base CodeFirst
        /// </summary>
        public virtual DbSet<Info> Info { get; set; }
        public virtual DbSet<OurServices> OurServices { get; set; }
        public virtual DbSet<Templete> Templete { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<CatTemp> CatTemp { get; set; }
        public virtual DbSet<jobVacancy> jobVacancy { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Educationlevel> Educationlevel { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<CatPerson> CatPerson { get; set; }
        public virtual DbSet<DetailsPerson> DetailsPerson { get; set; }
        public virtual DbSet<SkillsPerson> SkillsPerson { get; set; }
        public virtual DbSet<PostCompany> PostCompany { get; set; }
        public virtual DbSet<DataPerson> DataPerson { get; set; }
        public virtual DbSet<ApplayJob> ApplayJob { get; set; }
        public virtual DbSet<Univircity> Univircity { get; set; }
        public virtual DbSet<Targetsector> Targetsector { get; set; }
        public virtual DbSet<TypeCompany> TypeCompany { get; set; }
        public virtual DbSet<SuppourtIdea> SuppourtIdea { get; set; }
        public virtual DbSet<Datavocational> Datavocational { get; set; }
        public virtual DbSet<CareerPath> CareerPath { get; set; }
        public virtual DbSet<Idea> Idea { get; set; }
        public virtual DbSet<yourstatus> yourstatus { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        public virtual DbSet<Invistor> Invistor { get; set; }
        public virtual DbSet<volunteer> Volunteer { get; set; }
        public virtual DbSet<SupportedIdeas> SupportedIdeas { get; set; }
        public virtual DbSet<TypeIdea> TypeIdea { get; set; }


        #endregion
    }
}