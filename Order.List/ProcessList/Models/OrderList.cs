using System;

namespace ProcessList.Models
{
    internal class OrderList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime Created { get; set; }
        public string Status { get; set; }
    }
}
