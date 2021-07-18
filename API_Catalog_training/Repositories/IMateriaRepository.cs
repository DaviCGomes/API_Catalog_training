using API_Catalog_training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Catalog_training.Repositories {
    interface IMateriaRepository {
        Task<List<Materia>> Obter(int pagina, int quantidade);
        Task<Materia> Obter(Guid id);
        Task<List<Materia>> Obter(string nome);
        Task Inserir(Materia materia);
        Task Atualizar(Materia materia);
        Task Remover(Guid id);
    }
}
