using API_Catalog_training.InputModel;
using API_Catalog_training.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Catalog_training.Services {
    public interface IJogoService : IDisposable {
        Task<List<JogoViewModel>> Obter(int pagina, int quantidade);
        Task<JogoViewModel> Obter(Guid id);
        Task<JogoViewModel> Inserir(JogoInputModel jogo);
        Task Atualizar(Guid id, JogoInputModel jogo);
        Task Atualizar(Guid id, double preco);
        Task Remover(Guid id);
    }
}
