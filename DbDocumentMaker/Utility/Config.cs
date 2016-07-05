using DbDocumentMaker.Models;
using Jil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDocumentMaker.Utility
{
    class Config
    {
        // Fields
        private static readonly Lazy<Config> _lazyUniqueConfig =
            new Lazy<Config>(() => new Config());

        private const string _configFilePath = @"maker.config";


        // Constructors
        private Config()
        {
            LoadConfig();
        }


        // Properties
        public ConfigContent Content { get; set; }



        // Methods
        public static Config GetInstance()
        {
            return _lazyUniqueConfig.Value;
        }

        public void SaveConfig()
        {
            using (var output = new StringWriter())
            {
                JSON.Serialize(this.Content, output);

                StreamWriter file = new StreamWriter(_configFilePath);
                file.Write(output.ToString());
                file.Close();
            }
        }

        public void LoadConfig()
        {
            if (File.Exists(_configFilePath))
            {
                using (StreamReader sr = new StreamReader(_configFilePath))
                {
                    using (var input = new StringReader(sr.ReadToEnd()))
                    {
                        this.Content = JSON.Deserialize<ConfigContent>(input);
                    }
                }
            }
            else
            {
                this.Content = new ConfigContent();
            }
        }

    }




}
