namespace BookStoreAPI.Entities
{
    public class Author
    {


        // Une prop mets a dispostion des accesseurs (getters et setters)
        // ceci est une property
        public int Id { get; set; }
        public required string Name { get; init; }

        public string Abstract { get; set; } = string.Empty;



    }
}