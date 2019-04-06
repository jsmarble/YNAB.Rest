using System;
namespace YNAB.Rest
{
    public class PayeeLocation
    {
        public string Id { get; set; }
        public string PayeeId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool Deleted { get; set; }
    }

    /*
{
  "data": {
    "payee_locations": [
      {
        "id": "string",
        "payee_id": "string",
        "latitude": "string",
        "longitude": "string",
        "deleted": true
      }
    ]
  }
}
    */
}
