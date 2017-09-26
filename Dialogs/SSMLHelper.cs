using System.Xml.Linq;

namespace LuisBot.FormOrder
{
    /// <summary>
    /// the class SSMLHelper helps to format and structure the output voice with which the app reads text to users.
    /// </summary>
    internal class SSMLHelper
    {
        public static string Speak(string text)
        {
            var ssml = new XDocument(new XElement(
                "speak",
                new XAttribute("version", "1.0"),
                new XAttribute(XNamespace.Xml + "lang", "en-US"),
                text));

            return ssml.ToString();
        }

        public static string Emphasis(string text)
        {
            var ssml = new XElement("emphasis", text);
            return ssml.ToString();
        }

        public static string SayAs(string interpretAs, string text)
        {
            var ssml = new XElement(
                "say-as",
                new XAttribute("interpret-as", interpretAs),
                text);

            return ssml.ToString();
        }
    
    }
}