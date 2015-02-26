using System.Text.RegularExpressions;

namespace XmlEquivalencyComparisonTool
{
    public class ClearXmlnsAttributeStringPreProcessor : StringPreProcessor
    {
        public override string Process(string document)
        {
            return Regex.Replace(
                document, @"(xmlns:?[^=]*=[""][^""]*[""])", "",
                RegexOptions.IgnoreCase |
                RegexOptions.Multiline);
        }
    }
}
