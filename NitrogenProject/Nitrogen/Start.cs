﻿namespace Nitrogen
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
    using Nitrogen.PdfReport;
    using Newtonsoft.Json;
    

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

            //MongoRepository mongoCtx = new MongoRepository();

            //List<Nitrogen.Mongo.Models.Place> allPlaces = mongoCtx.GetAllPlaces().ToList();
            
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

            //var xmlSerializer = new Nitrogen.Serializers.XmlSerialzer();
            
            //var xmlString = xmlSerializer.Serialize<List<Nitrogen.Mongo.Models.Place>>(allPlaces);

            //var xmlFilePath = "../../places.xml";

            //using (var str = new StreamWriter(xmlFilePath))
            //{
            //    str.Write(xmlString);
            //}

            //var objectsFromXml = xmlSerializer.ParseXml<List<Nitrogen.Mongo.Models.Place>>(xmlFilePath);

            //Console.WriteLine();

            /*ReportImporter importer = new ReportImporter();
            importer.GetZipFile();*/
/*
            PdfProcess pdfReport = new PdfProcess();
            pdfReport.ProcessDocument();*/

            using (NitrogenMsSqlDb ctx = new NitrogenMsSqlDb())
            {
                var reports = (from s in ctx.Sales
                               join p in ctx.Products on s.ProductId equals p.ProductId
                               join pl in ctx.Places on s.PlaceId equals pl.PlaceId
                               select new
                               {
                                   Date = s.Date,
                                   ProductName = p.Name,
                                   ThePlace = pl.Name,
                                   Quantity = s.Quantity,
                                   PricePerUnit = s.PricePerUnit,
                                   Sum = s.Sum
                               })
                             .GroupBy(s => s.Date)
                             .ToList();

                int counter = 1;

                foreach (var rep in reports)
                {
                    using (var writer = new StreamWriter("../../report" + counter + ".json"))
                    {
                        writer.Write(JsonConvert.SerializeObject(rep, Formatting.Indented));
                    }
                    counter++;
                }
            }
        }
    }
}
