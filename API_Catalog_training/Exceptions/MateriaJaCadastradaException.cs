using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Catalog_training.Exceptions {
    public class MateriaJaCadastradaException : Exception {
        public MateriaJaCadastradaException()
            : base("Esta matéria já está cadastrada") {
        }
    }
}
