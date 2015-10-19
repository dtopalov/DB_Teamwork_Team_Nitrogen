namespace ZipExcelImporter
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using Excel;
    using Ionic.Zip;

    public class ReportImporter
    {
        public void GetZipFile()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FileStream fs = new FileStream(desktop + @"\Excel.zip", FileMode.Open, FileAccess.Read);
            using (var zipArchive = ZipFile.Read(fs))
            {
                IExcelDataReader excelReader;
                foreach (ZipEntry zEntity in zipArchive)
                {
                    var date = zEntity.FileName.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    DateTime timeOfTheReport = DateTime.Parse(date);

                    string fileExtenstion = zEntity.FileName.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    Console.WriteLine(fileExtenstion);

                    using (var memo = new MemoryStream())
                    {
                        zEntity.Extract(memo);

                        switch (fileExtenstion)
                        {
                            case "xlsx":
                                //Reading from a OpenXml Excel file (2007 - 2013 format; *.xlsx)  
                                excelReader = ExcelReaderFactory.CreateOpenXmlReader(memo);
                                break;
                            case "xls":
                                //Reading from a binary Excel file (97-2003 format; *.xls)
                                excelReader = ExcelReaderFactory.CreateBinaryReader(memo);
                                break;
                            default:
                                continue;
                        }

                        //4. DataSet - Create column names from first row
                        excelReader.IsFirstRowAsColumnNames = false;
                        DataSet result = excelReader.AsDataSet();

                        excelReader.Dispose();
                        DataRowCollection firstTableRows = result.Tables[0].Rows;

                        ImportInDB(firstTableRows, timeOfTheReport);
                    }
                }
            }
        }

        private void ImportInDB(DataRowCollection firstTableRows, DateTime dateTimeOfReports)
        {
            using (NitrogenNewEntities dbConnection = new NitrogenNewEntities())
            {
                var nameOfPlace = firstTableRows[0].ItemArray[0].ToString();
                var idOfThePlace = dbConnection.Places.Where(p => p.Name == nameOfPlace).Select(p => p.PlaceId).FirstOrDefault();
                Place newPlace = new Place();
                if (idOfThePlace == 0)
                {
                    newPlace = dbConnection.Places.Add(new Place()
                    {
                        Name = nameOfPlace,
                        Address = "Undefined",
                    });
                }

                Sale theNewSale = new Sale();
                for (int i = 2; i < firstTableRows.Count; i++)
                {
                    theNewSale = new Sale();

                    var row = firstTableRows[i];

                    theNewSale.ProductId = int.Parse(row.ItemArray[0].ToString());
                    theNewSale.Quantity = int.Parse(row.ItemArray[1].ToString());
                    theNewSale.PricePerUnit = decimal.Parse(row.ItemArray[2].ToString());
                    theNewSale.Sum = decimal.Parse(row.ItemArray[3].ToString());
                    theNewSale.PlaceId = idOfThePlace != null ? idOfThePlace : newPlace.PlaceId;
                    theNewSale.Date = dateTimeOfReports;
                    dbConnection.Sales.Add(theNewSale);

                    /*foreach (var property in row.ItemArray)
                    {

                        Console.Write('|' + property.ToString().PadLeft(20, ' '));
                    }

                    Console.Write('|');
                    Console.WriteLine();*/
                }

                try
                {
                    dbConnection.SaveChanges();
                }
                catch (Exception ex)
                {
                    ShowMessageException(ex);
                }
            }
        }

        private static void ShowMessageException(Exception exception)
        {
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
            }

            Console.WriteLine(exception.Message);
        }
    }
}
