using API_Catalog_training.Entities;
using API_Catalog_training.Exceptions;
using API_Catalog_training.InputModel;
using API_Catalog_training.Repositories;
using API_Catalog_training.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Catalog_training.Services {
    public class MateriaService : IMateriaService {
        private readonly IMateriaRepository _materiaRepository;

        public MateriaService(IMateriaRepository materiaRepository) {
            _materiaRepository = materiaRepository;
        }

        public async Task<List<MateriaViewModel>> Obter(int pagina, int quantidade) {
            var Materias = await _materiaRepository.Obter(pagina, quantidade);

            return Materias.Select(Materia => new MateriaViewModel {
                Id = Materia.Id,
                Nome = Materia.Nome,
                PreRequisitos = Materia.PreRequisitos
            }).ToList();
        }

        public async Task<MateriaViewModel> Obter(Guid id) {
            var Materia = await _materiaRepository.Obter(id);

            if(Materia == null)
                return null;

            return new MateriaViewModel {
                Id = Materia.Id,
                Nome = Materia.Nome,
                PreRequisitos = Materia.PreRequisitos
            };
        }

        public async Task<MateriaViewModel> Inserir(MateriaInputModel Materia) {
            var entidadeMateria = await _materiaRepository.Obter(Materia.Nome);

            if(entidadeMateria.Count > 0)
                throw new MateriaJaCadastradaException();

            var MateriaInsert = new Materia {
                Id = Guid.NewGuid(),
                Nome = Materia.Nome,
                PreRequisitos = Materia.PreRequisitos
            };

            await _materiaRepository.Inserir(MateriaInsert);

            return new MateriaViewModel {
                Id = MateriaInsert.Id,
                Nome = Materia.Nome,
                PreRequisitos = Materia.PreRequisitos
            };
        }

        public async Task Atualizar(Guid id, MateriaInputModel Materia) {
            var entidadeMateria = await _materiaRepository.Obter(id);

            if(entidadeMateria == null)
                throw new MateriaNaoCadastradaException();

            entidadeMateria.Nome = Materia.Nome;
            entidadeMateria.PreRequisitos = Materia.PreRequisitos;

            await _materiaRepository.Atualizar(entidadeMateria);
        }

        public async Task Atualizar(Guid id, string preRequisitos) {
            var entidadeMateria = await _materiaRepository.Obter(id);

            if(entidadeMateria == null)
                throw new MateriaNaoCadastradaException();

            entidadeMateria.PreRequisitos = preRequisitos;

            await _materiaRepository.Atualizar(entidadeMateria);
        }

        public async Task Remover(Guid id) {
            var Materia = await _materiaRepository.Obter(id);

            if(Materia == null)
                throw new MateriaNaoCadastradaException();

            await _materiaRepository.Remover(id);
        }

        public void Dispose() {
            _materiaRepository?.Dispose();
        }
    }
}
