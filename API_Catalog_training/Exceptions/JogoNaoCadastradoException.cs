﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Catalog_training.Exceptions {
    public class JogoNaoCadastradoException : Exception {
        public JogoNaoCadastradoException()
            : base("Este jogo não está cadastrado") {
        }
    }
}
