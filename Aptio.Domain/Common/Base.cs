using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptio.Domain.Common
{
    public abstract class Base
    {
        public long? CreatedById { get; set; }

        public long? ModifiedById { get; set; } 

        public DateTime CreatedOn { get; set; }=DateTime.Now; 

        public DateTime? ModifiedOn { get; set; }

        public bool IsActive { get; set; }

    }
}
