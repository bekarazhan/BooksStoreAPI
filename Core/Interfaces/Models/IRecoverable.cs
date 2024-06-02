using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStoreAPI.Core.Interfaces.Models {
    public interface IRecoverable {
        //string DeletedBy { get; set; }

        DateTime? DeletedAt { get; set; }

        bool IsDeleted { get; set; }
    }
}
