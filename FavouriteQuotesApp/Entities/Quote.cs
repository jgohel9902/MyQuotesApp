namespace FavouriteQuotesApp.Entities
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; } 
        public string Author { get; set; } 
        public int Rating { get; set; }  
        public string Description { get; set; } 

        
        public string DisplayText => Text.Length <= 16 ? Text : Text.Substring(0, 16) + "...";
    }
}
