namespace DatabaseMastery.TransportMongoDb.Models
{
    public class TrackingEventViewModel
    {
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string TrackingStatus { get; set; }

        // Timeline marker CSS sınıfı
        public string MarkerClass => TrackingStatus switch
        {
            "Delivered" => "delivered",
            "In Transit" => "transit",
            "Out for Delivery" => "transit",
            _ => "processing"
        };

        // Timeline'da gösterilecek Bootstrap icon
        public string IconClass => TrackingStatus switch
        {
            "Delivered" => "bi-check-circle-fill",
            "Out for Delivery" => "bi-truck",
            "In Transit" => "bi-arrow-right-circle-fill",
            "At Sorting Centre" => "bi-building",
            "Shipment Received" => "bi-box-seam",
            _ => "bi-circle"
        };
    }
}
