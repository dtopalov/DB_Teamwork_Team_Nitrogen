namespace NitrogenManager.Data.WebService.Logic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class XmlParser : IXmlFileParser
    {
        public string GenerateXmlFile()
        {
            IDataRepository repo = new DataRepository();
            var employees = repo.GetAllEmployees();

            XmlDocument resultDocument = new XmlDocument();
            var a = new XDocument(new XElement("Employees"));
            
            //resultDocument.AppendChild(resultDocument.CreateNode(XmlNodeType.Element, "employees", string.Empty));

            foreach (var emp in employees)
            {
                //XmlNode employeeTag = resultDocument.CreateNode(XmlNodeType.Element, "employee", string.Empty);
                //XmlNode employeeName = resultDocument.CreateNode(XmlNodeType.Element, "employee", string.Empty);
                a.Root.Add(new XElement("Employee", 
                            new XElement("FirstName", emp.FirstName),
                            new XElement("LastName", emp.LastName),
                            new XElement("Age", emp.Age),
                            new XElement("Job", emp.JobPosition)
                            ));
            }

            string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "xmlReport.xml";
            
            try
            {
                a.Save(pathToDesktop + "\\" + fileName);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                return ex.Message;
            }

            string result = "File saved at " + pathToDesktop + "\\" + fileName;
            return result.ToString();
        }
    }
}
