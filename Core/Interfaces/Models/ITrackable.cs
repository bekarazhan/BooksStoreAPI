using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStoreAPI.Core.Interfaces.Models{
    public interface ITrackable {
        //public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        //public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
