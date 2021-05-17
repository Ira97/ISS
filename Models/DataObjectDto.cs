namespace Models.ViewModels
{
    public class DataObjectDto
    {
        public string Name{set; get; }
        public virtual TypeObjectDto TypeObjectDto { set; get; }
    }
}