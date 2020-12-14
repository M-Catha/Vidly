using System.Collections.Generic;

namespace Vidly.DTOs
{
    public class RentalDTO
    {
        public int CustomerID { get; set; }
        
        public List<int> MovieIDs { get; set; }
    }
}