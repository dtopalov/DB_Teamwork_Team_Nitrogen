namespace Nitrogen
{
    using Nitrogen.App_data;
    using Nitrogen.Mongo;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using ZipExcelImporter;

    internal class Start
    {
        static void Main()
        {

            //logs.Insert(new Place
            //{
            //    Id = ObjectId.GenerateNewId().ToString(),
            //    Name = "The Hole",
            //    Address = "1 Vitosha Blvd."
            //});

            //logs.Insert(new Place
            //{
            //    Id = ObjectId.GenerateNewId().ToString(),
            //    Name = "Shiny Place",
            //    Address = "2 Vitosha Blvd."
            //});

            //logs.Insert(new Place
            //{
            //    Id = ObjectId.GenerateNewId().ToString(),
            //    Name = "Space Bar",
            //    Address = "3 Vitosha Blvd."
            //});

            //var update = Update.Set("Text", "Changed Text at " + DateTime.Now);


            //var query = Query.And(
            //    Query.LT("LogDate", DateTime.Now.AddSeconds(-1))
            //    );

            //logs.Update(query, update);

            MongoRepository mongoCtx = new MongoRepository();

            List<Nitrogen.Mongo.Models.Place> allPlaces = mongoCtx.GetAllPlaces().ToList();

            //using (NitrogenMsSqlDb ctx = new NitrogenMsSqlDb())
            //{
            //    foreach (var place in allPlaces)
            //    {
            //        ctx.Places.Add(place);
            //    }

            //    ctx.SaveChanges();
            //}

            //var allProducts = mongoCtx.GetAllProducts().ToList();

            //using (NitrogenMsSqlDb ctx = new NitrogenMsSqlDb())
            //{
            //    foreach (var product in allProducts)
            //    {
            //        ctx.Products.Add(product);
            //    }

            //    ctx.SaveChanges();
            //}

            var xmlSerializer = new Nitrogen.Serializers.XmlSerialzer();
            
            var xmlString = xmlSerializer.Serialize<List<Nitrogen.Mongo.Models.Place>>(allPlaces);

            using (var str = new StreamWriter("../../places.xml"))
            {
                str.Write(xmlString);
            }

            /*ReportImporter reporter = new ReportImporter();
            reporter.GetZipFile();*/
        }
    }
}
