namespace Nitrogen.PdfReport
{
    using System;
    using System.Linq;

    using iTextSharp;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.IO;
    using Nitrogen.App_data;

    public class PdfProcess
    {
        public void ProcessDocument()
        {
            FileStream fileStream = new FileStream("../../../Report.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document pdfDocumnet = new Document();
            PdfWriter pdrWriter = PdfWriter.GetInstance(pdfDocumnet, fileStream);
            pdfDocumnet.Open();


            using (NitrogenMsSqlDb dbCon = new NitrogenMsSqlDb())
            {
                var manja = (from s in dbCon.Sales
                             join p in dbCon.Products on s.ProductId equals p.ProductId
                             join pl in dbCon.Places on s.PlaceId equals pl.PlaceId
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

                var mainTable = new PdfPTable(1);
                mainTable.AddCell("All sales");
                pdfDocumnet.Add(Chunk.NEWLINE);

                foreach (var key in manja)
                {
                    mainTable.AddCell(key.Key.ToShortDateString());
                    pdfDocumnet.Add(Chunk.NEWLINE);

                    var innerTable = new PdfPTable(5);

                    innerTable.AddCell("The place");
                    innerTable.AddCell("Product Name");
                    innerTable.AddCell("Quantity");
                    innerTable.AddCell("Price Per Unit");
                    innerTable.AddCell("Sum");

                    foreach (var item in key)
                    {
                        innerTable.AddCell(item.ThePlace);
                        innerTable.AddCell(item.ProductName);
                        innerTable.AddCell(item.Quantity.ToString());
                        innerTable.AddCell(string.Format("{0:F2}", item.ProductName));
                        innerTable.AddCell(string.Format("{0:F2}", item.Sum));
                    }

                    mainTable.AddCell(innerTable);
                }

                pdfDocumnet.Add(mainTable);
                pdfDocumnet.Close();
                /*
             * dbCon.Database.ExecuteSqlCommand("SELECT s.Date, pl.Name, COUNT(p.Name) AS [Sales for today]" +
                                             "FROM [Sales] s" +
                                             "JOIN [Products] p ON p.ProductId = s.ProductId" +
                                             "JOIN [Places] pl ON pl.PlaceId = s.PlaceId" +
                                             "GROUP BY s.Date, pl.Name");
            for (int i = 0; i < manja.Count; i++)
            {
                Console.WriteLine(items[i].Sales);
            } */
            }
        }
    }
}
