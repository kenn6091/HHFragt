using System;

namespace FragtSource {
    public class Package
    {
        private DateTime _date;

        public int Id { get; set; }
        public DateTime Date {
            get { return _date; }
            set {
                _date = value.Date;
            }
        }

        public string Type { get; set; }
        public string Country { get; set; }
        public string Price { get; set; }
        public string Comment { get; set; }

        public Package()
        {
            Country = "";
            Price = "";
            Comment = "";
        }
    }
}
