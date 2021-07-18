using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Catalog_training.InputModel {
    public class MateriaInputModel {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da materia deve conter entre 3 e 100 caracteres")]
        public string Nome {
            get; set;
        }
        [Required]
        [StringLength(100, ErrorMessage = "A lista dos requisitos devem conter no máximo 100 caracteres")]
        public string PreRequisitos {
            get; set;
        }
    }
}
