using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Catalog_training.ViewModel {
    public class MateriaViewModel {
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
