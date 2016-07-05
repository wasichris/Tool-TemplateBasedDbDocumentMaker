using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDocumentMaker.Models
{
    class ConfigContent
    {
        // Properties
        public string CurrentConnectionName { get; set; }

        public Connection CurrentConnection
        {
            get
            {
                return Connections.Where(c => c.Name == CurrentConnectionName).FirstOrDefault();
            }
        }

        public string CurrentDocTemplateName { get; set; }

        public string CurrentDocTemplatePath
        {
            get
            {
                return DocTemplateLocation + CurrentDocTemplateName;
            }
        }

        public string DocTemplateLocation { get; set; }

        public string OutputDocLocation { get; set; }

        public Dictionary<string, List<string>> DocTablePackages { get; set; }

        public List<Connection> Connections { get; set; }
      

        // Constructors
        public ConfigContent()
        {
            this.DocTemplateLocation = @"DocTemplate\";
            this.CurrentDocTemplateName = @"db report template.xlsx";
            this.OutputDocLocation = @"OutputDoc\";
            this.DocTablePackages = new Dictionary<string, List<string>>();
            this.Connections = new List<Connection>()
            { new Connection() {
                Name= "Sample",
                Str = "Data Source=oooo; Initial Catalog=xxxx;Integrated Security=False;User ID=oooo;Password=xxxx; Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            } };
            this.CurrentConnectionName = "Sample";
        }


        // Methods
        public bool IsValid(ref StringWriter msg)
        {
            if (string.IsNullOrWhiteSpace(CurrentConnectionName))
                msg.WriteLine("Please choose a connection!");

            if (string.IsNullOrWhiteSpace(CurrentDocTemplateName))
                msg.WriteLine("Please choose a template!");

            return string.IsNullOrWhiteSpace(msg.ToString());
        }
    }
}
