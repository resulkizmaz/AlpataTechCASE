using Microsoft.AspNetCore.Http;

namespace Entity
{
    //Frontend'den gelen
    public class SetMeetingRequest : IDTO
    {
        public int UserID { get; set; }
        public string MeetingName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public IFormFile Documents { get; set; }
    }

    //Veri tabanı için dönüşen
    public class SetMeetingTransferObject : IDTO
    {
        public int UserID { get; set; }
        public string MeetingName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string DocumentPath { get; set; }
    }
        
}
