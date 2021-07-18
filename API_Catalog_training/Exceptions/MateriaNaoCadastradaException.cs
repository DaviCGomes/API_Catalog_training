using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Catalog_training.Exceptions {
    public class MateriaNaoCadastradaException : Exception {
        public MateriaNaoCadastradaException()
            : base("Esta matéria não está cadastrada") {
        }
    }
}
