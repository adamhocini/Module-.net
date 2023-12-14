namespace BookStoreAPI.Entities
{
    public class Book
    {


        // Une prop mets a dispostion des accesseurs (getters et setters)
        // ceci est une property
        public int Id { get; set; }

        public required string Title { get; init; }
        
        //public Author Author { get; set; }

        //public Genre? Genre { get; set; }

        public string Abstract { get; set; } = string.Empty;



    }
}