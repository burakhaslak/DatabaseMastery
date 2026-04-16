namespace DatabaseMastery.TransportMongoDb.Models
{
    public class TrackingResultViewModel
    {
        public string TrackingNumber { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string OriginCity { get; set; }
        public string OriginDistrict { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationDistrict { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CurrentStatus { get; set; }
        public List<TrackingEventViewModel> Events { get; set; } = new();

        // Geçerli duruma göre progress bar'daki adım index'i (0-4)
        public int CurrentStepIndex => CurrentStatus switch
        {
            "Shipment Received" => 0,
            "At Sorting Centre" => 1,
            "In Transit" => 2,
            "Out for Delivery" => 3,
            "Delivered" => 4,
            _ => 0
        };

        public bool IsDelivered => CurrentStatus == "Delivered";
    }
}
