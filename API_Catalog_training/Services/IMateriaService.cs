using API_Catalog_training.InputModel;
using API_Catalog_training.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Catalog_training.Services {
    public interface IMateriaService : IDisposable {
        Task<List<MateriaViewModel>> Obter(int pagina, int quantidade);
        Task<MateriaViewModel> Obter(Guid id);
        Task<MateriaViewModel> Inserir(MateriaInputModel materia);
        Task Atualizar(Guid id, MateriaInputModel materia);
        Task Atualizar(Guid id, string preRequisito);
        Task Remover(Guid id);
    }
}
