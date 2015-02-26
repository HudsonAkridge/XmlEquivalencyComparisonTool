using System.Xml.Linq;

namespace XmlEquivalencyComparisonTool
{
    public abstract class XmlPreProcessor
    {
        public abstract XElement Process(XElement document);
    }
}
