namespace XmlEquivalencyComparisonTool
{
    public class ComparisonConfiguration
    {
        public ComparisonConfiguration(string documentName, string attributeToIdentifyDuplicateElements = "name")
        {
            DocumentName = documentName;
            AttributeToIdentifyDuplicateElements = attributeToIdentifyDuplicateElements;
        }

        public string DocumentName { get; set; }
        public string AttributeToIdentifyDuplicateElements { get; set; }
    }
}
