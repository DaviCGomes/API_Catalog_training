using API_Catalog_training.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Catalog_training.Repositories {
    public class MateriaSqlServerRepository : IMateriaRepository {
        private readonly SqlConnection sqlConnection;

        public MateriaSqlServerRepository(IConfiguration configuration) {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public async Task<List<Materia>> Obter(int pagina, int quantidade) {
            var Materias = new List<Materia>();

            var comando = $"select * from Materias order by id offset {((pagina - 1) * quantidade)} rows fetch next {quantidade} rows only";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while(sqlDataReader.Read()) {
                Materias.Add(new Materia {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    PreRequisitos = (string)sqlDataReader["PreRequisitos"]
                });
            }

            await sqlConnection.CloseAsync();

            return Materias;
        }

        public async Task<Materia> Obter(Guid id) {
            Materia Materia = null;

            var comando = $"select * from Materias where Id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while(sqlDataReader.Read()) {
                Materia = new Materia {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    PreRequisitos = (string)sqlDataReader["PreRequisitos"]
                };
            }

            await sqlConnection.CloseAsync();

            return Materia;
        }

        public async Task<List<Materia>> Obter(string nome) {
            var Materias = new List<Materia>();

            var comando = $"select * from Materias where Nome = '{nome}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while(sqlDataReader.Read()) {
                Materias.Add(new Materia {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    PreRequisitos = (string)sqlDataReader["PreRequisitos"]
                });
            }

            await sqlConnection.CloseAsync();

            return Materias;
        }

        public async Task Inserir(Materia Materia) {
            var comando = $"insert Materias (Id, Nome, Produtora, Preco) values ('{Materia.Id}', '{Materia.Nome}', '{Materia.PreRequisitos}')";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Atualizar(Materia Materia) {
            var comando = $"update Materias set Nome = '{Materia.Nome}', Produtora = '{Materia.PreRequisitos}' where Id = '{Materia.Id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Remover(Guid id) {
            var comando = $"delete from Materias where Id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public void Dispose() {
            sqlConnection?.Close();
            sqlConnection?.Dispose();
        }
    }
}
