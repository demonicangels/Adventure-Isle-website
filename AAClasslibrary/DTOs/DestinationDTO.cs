using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DestinationDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Country { get; private set; }
        public string BriefDescription { get; set; }
        public double AvgRating { get; set; }
        public string Currency { get; set; }
        public string Climate { get; private set; }
        public string ImgURL { get; private set; }
        public int? DesStatus { get; set; }
		public int? UsrId { get; private set; }

        public DestinationDTO() { }
        public DestinationDTO(int id, string name, string country, string? cur, string? brief, string climate, double? avg, string? img, int? usrId)
        {
            Id = id;
            Name = name;
            Country = country;
            Climate = climate;
            Currency = cur;
            BriefDescription = brief;
            AvgRating = (int)avg;
            ImgURL = img;
            UsrId = usrId;
        }
        public string DesInfo()
        {
            return $"City: {Name}, Country: {Country}, History: {BriefDescription}";
        }

    }
}
