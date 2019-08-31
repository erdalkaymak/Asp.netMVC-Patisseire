namespace DataAccessLayer.Migrations
{
    using DataAccessLayer.MyEntities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLayer.Model1 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Model1 ctx = new Model1();
            Cake pat = new Cake();
            pat.Id = 1;
            pat.ImgeUrl = "1.jpg";
            pat.Name = "cheese cake with lemon";
            pat.Price = 10.5M;
            pat.Description = "a delicious cake with lemon";

            ctx.Cakes.AddOrUpdate(pat);

            Cake pat1 = new Cake();
            pat1.Id = 2;
            pat1.ImgeUrl = "2.jpg";
            pat1.Name = "cheese cake with lemon";
            pat1.Price = 10.5M;
            pat1.Description = "a delicious cake with lemon";

            ctx.Cakes.AddOrUpdate(pat1);

            Cake pat3 = new Cake();
            pat3.Id = 3;
            pat3.ImgeUrl = "3.jpg";
            pat3.Name = "cheese cake with lemon";
            pat3.Price = 10.5M;
            pat3.Description = "a delicious cake with lemon";

            ctx.Cakes.AddOrUpdate(pat3);

            Cake pat4 = new Cake();
            pat4.Id = 3;
            pat4.ImgeUrl = "3.jpg";
            pat4.Name = "cheese cake with lemon";
            pat4.Price = 10.5M;
            pat4.Description = "a delicious cake with lemon";

            ctx.Cakes.AddOrUpdate(pat4);
            ctx.SaveChanges();

        }
    }
}
