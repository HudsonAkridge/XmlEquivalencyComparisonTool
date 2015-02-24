namespace XmlEquivalencyComparisonTool
{
    public class AreEquivalentResponse
    {
        public AreEquivalentResponse(bool equivalent, string reason = "", AreEquivalentResponse innerResponse = null)
        {
            Equivalent = equivalent;
            Reason = reason;
            InnerResponse = innerResponse;
        }

        public bool Equivalent { get; set; }
        public string Reason { get; set; }
        public AreEquivalentResponse InnerResponse { get; set; }
    }
}