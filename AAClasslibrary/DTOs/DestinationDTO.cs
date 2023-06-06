using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DestinationDTO
    {
        //make everything public in dto keep it private in destination 
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Country { get;  set; }
        public string BriefDescription { get; set; }
        public double AvgRating { get; set; }
        public string Currency { get; set; }
        public string Climate { get;  set; }
        public string ImgURL { get;  set; }
        public int? DesStatus { get; set; }
		public int? UsrId { get;  set; }

        //public DestinationDTO(int id, string name, string country, string? cur, string? brief, string climate, double? avg, string? img, int? usrId, int? des)
        //{
        //    Id = id;
        //    Name = name;
        //    Country = country;
        //    Climate = climate;
        //    Currency = cur;
        //    BriefDescription = brief;
        //    AvgRating = (double)avg;
        //    ImgURL = img;
        //    UsrId = usrId;
        //    DesStatus = des;
        //}
        public string DesInfo()
        {
            return $"City: {Name}, Country: {Country}, History: {BriefDescription}";
        }

    }
}
