namespace TrainBookingApp.Models
{
    public class Tren
    {
        public long Id { get; set; }
        public string? Ad { get; set; }
        public Vagon? Vagonlar { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}
