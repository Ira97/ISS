namespace ScientificDatabase.Models.Hierarchy
{
    /// <summary>
    /// Области - разделы связь 
    /// </summary>
    public class AreaSection:BaseEntity
    {
        public int AreaId { set; get; }
        public int SectionId { set; get; }
    }
}