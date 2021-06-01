namespace Models.Search
{
    public class Entry
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Relevance { get; set; }
        public int ItemId { get; set; }
    }
}