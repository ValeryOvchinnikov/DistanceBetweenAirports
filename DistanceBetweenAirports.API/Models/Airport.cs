namespace DistanceBetweenAirports.API.Models
{
    public class Airport
    {
        public string Iata { get; set; }

        public string Name { get; set; }    

        public double Latitude {  get; set; }

        public double Longitude { get; set; }
    }
}
