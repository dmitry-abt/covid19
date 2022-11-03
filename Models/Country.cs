namespace CovidWatch.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Iso { get; set; }
        public string Name { get; set; }
        public int Confirmed { get; set; }
        public int Recovered { get; set; }
        public int Deaths { get; set; }
        public string Coordinates {get; set;}
        public string Type { get; set; }
    }
}