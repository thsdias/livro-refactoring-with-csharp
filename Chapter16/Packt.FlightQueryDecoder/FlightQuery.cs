namespace Packt.FlightQueryDecoder
{
    public class FlightQuery
    {
        public DateTime Date { get; set; }
        public string Origin { get; set; }
        public string Destination
        {
            get;
            set;
        }
    }
}
