using System.Xml;

namespace ObliAdvanced.Core
{
    /// <summary>
    /// Manages configuration settings loaded from XML file
    /// </summary>
    public class ConfigurationManager
    {
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        public string DifficultyLevel { get; private set; }

        public void LoadConfiguration(string xmlContent)
        {
            var doc = new XmlDocument();
            doc.Load(xmlContent);
            
            MaxX = int.Parse(doc.SelectSingleNode("//MaxX")?.InnerText ?? "10");
            MaxY = int.Parse(doc.SelectSingleNode("//MaxY")?.InnerText ?? "10");
            DifficultyLevel = doc.SelectSingleNode("//DifficultyLevel")?.InnerText ?? "normal";
        }
    }
}
