using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Catalog_training.Entities {
    public class Materia {
        public Guid Id {
            get; set;
        }
        public string Nome {
            get; set;
        }
        public string PreRequisitos {
            get; set;
        }
    }
}
