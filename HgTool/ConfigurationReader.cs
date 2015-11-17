using System;
using System.Collections.Generic;
using System.Xml;
using System.Configuration;

namespace HgTool
{
    public class ConfigurationReader
    {
        /// <summary>
        /// Reads the repository configuration.
        /// </summary>
        /// <param name="xmlFullPath">The XML full path.</param>
        /// <returns>List of repositories.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public List<string> ReadRepositoryConfig(string xmlFullPath)
        {
            var reader = new XmlTextReader(xmlFullPath);

            var repos = new List<string>();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                    case XmlNodeType.EndElement:
                        if (reader.Name == "Repository")
                        {
                            repos.Add(reader.GetAttribute("name"));
                        }
                        break;
                    case XmlNodeType.None:
                        break;
                    case XmlNodeType.Attribute:
                        break;
                    case XmlNodeType.Text:
                        break;
                    case XmlNodeType.CDATA:
                        break;
                    case XmlNodeType.EntityReference:
                        break;
                    case XmlNodeType.Entity:
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        break;
                    case XmlNodeType.Comment:
                        break;
                    case XmlNodeType.Document:
                        break;
                    case XmlNodeType.DocumentType:
                        break;
                    case XmlNodeType.DocumentFragment:
                        break;
                    case XmlNodeType.Notation:
                        break;
                    case XmlNodeType.Whitespace:
                        break;
                    case XmlNodeType.SignificantWhitespace:
                        break;
                    case XmlNodeType.EndEntity:
                        break;
                    case XmlNodeType.XmlDeclaration:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return repos;
        }

        public string Port
        {
            get { return ConfigurationManager.AppSettings["port"]; }
        }

        public string QaHost
        {
            get { return ConfigurationManager.AppSettings["qa_host"]; }
        }

        public string TeamUrl
        {
            get { return "http://" + QaHost + ":" + Port; }
        }

        public string CheckoutPath
        {
            get { return ConfigurationManager.AppSettings["checkout_path"]; }

        }

        public string UserName
        {
            get { return ConfigurationManager.AppSettings["username"]; }
        }

        public string Password
        {
            get { return ConfigurationManager.AppSettings["password"]; }
        }

        public string Milestone
        {
            get { return ConfigurationManager.AppSettings["milestone"]; }
        }

        public string SoftwareType
        {
            get { return ConfigurationManager.AppSettings["software_type"]; }
        }

        public string Release
        {
            get { return ConfigurationManager.AppSettings["release"]; }
        }

        public string BranchLocation
        {
            get { return SoftwareType + "/" + Release; }
        }

        public string LocalBranchParameters
        {
            get { return " --branch-location " + BranchLocation + " --use-local-repos-organisation"; }
        }
    }
}