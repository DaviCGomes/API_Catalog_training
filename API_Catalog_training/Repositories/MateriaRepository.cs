using API_Catalog_training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Catalog_training.Repositories {
    public class MateriaRepository : IMateriaRepository  {
        private static Dictionary<Guid, Materia> materias = new Dictionary<Guid, Materia>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Materia{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Introdução a portugues", PreRequisitos = ""} },
            {Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Materia{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Nome = "calculo1", PreRequisitos = ""} },
            {Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Materia{ Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), Nome = "calculo2", PreRequisitos = ""} },
            {Guid.Parse("da033439-f352-4539-879f-515759312d53"), new Materia{ Id = Guid.Parse("da033439-f352-4539-879f-515759312d53"), Nome = "calculo3", PreRequisitos = ""} },
            {Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), new Materia{ Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), Nome = "geografia", PreRequisitos = ""} },
            {Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), new Materia{ Id = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), Nome = "historia", PreRequisitos = ""} }
        };

        public Task<List<Materia>> Obter(int pagina, int quantidade) {
            return Task.FromResult(materias.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Materia> Obter(Guid id) {
            if(!materias.ContainsKey(id))
                return Task.FromResult<Materia>(null);

            return Task.FromResult(materias[id]);
        }

        public Task<List<Materia>> Obter(string nome) {
            return Task.FromResult(materias.Values.Where(Materia => Materia.Nome.Equals(nome)).ToList());
        }

        public Task<List<Materia>> ObterSemLambda(string nome, string produtora) {
            var retorno = new List<Materia>();

            foreach(var Materia in materias.Values) {
                if(Materia.Nome.Equals(nome))
                    retorno.Add(Materia);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Materia Materia) {
            materias.Add(Materia.Id, Materia);
            return Task.CompletedTask;
        }

        public Task Atualizar(Materia Materia) {
            materias[Materia.Id] = Materia;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id) {
            materias.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose() {
            //Fechar conexão com o banco
        }
    }
}
