using APIBoletim.Context;
using APIBoletim.Domains;
using APIBoletim.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Repositories {
    public class AlunoRepository : IAluno {

        //Calling the Database connection class
        BoletimContext connect = new BoletimContext();

        //Calling the objects that will be able to receive and execute the database commands
        SqlCommand cmd = new SqlCommand();

        public Aluno Change(Aluno a) { 
            throw new NotImplementedException();
    }

        public Aluno Delete(Aluno a) {
            throw new NotImplementedException();
        }

        public List<Aluno> ReadAll() {
            //Open Connection
            cmd.Connection = connect.ToConnect();

            //Prepare Query
            cmd.CommandText = "SELECT * FROM ALUNO";

            SqlDataReader data = cmd.ExecuteReader();

            // Creating list for to save students
            List<Aluno> alunos = new List<Aluno>();

            while (data.Read()) {
                alunos.Add(new Aluno() {
                    IdAluno = Convert.ToInt32(data.GetValue(0)),
                    Nome    = data.GetValue(1).ToString(),
                    Ra      = data.GetValue(2).ToString(),
                    Idade   = Convert.ToInt32(data.GetValue(3))
                });
            }

            //Close Connection
            connect.Desconect();

            return alunos;
        }

        public Aluno Register(Aluno a) {
            cmd.Connection = connect.ToConnect();

            cmd.CommandText =
                "INSERT INTO ALUNO (Nome, Ra, Idade)" +
                "VALUES" +
                "(@nome, @ra, @idade)";
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.Ra);
            cmd.Parameters.AddWithValue("@idade", a.Idade);

            // Inserindo comando responsável por injetar os dados no Banco de dados
            //Inserting command responsible for injecting data into the database
            cmd.ExecuteNonQuery();

            //DML -> ExecuteNonQuery

            return a;
        }


        // Buscar por ID
        public Aluno SearchbyId(int id) {
            cmd.Connection = connect.ToConnect();
            cmd.CommandText = "SELECT * FROM Aluno WHERE IdAluno = @id ";

            //definindo de onde vem o id // defining where the id comes from
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader data = cmd.ExecuteReader();

            Aluno a = new Aluno();

            while (data.Read()) {
                a.IdAluno = Convert.ToInt32(data.GetValue(0));
                a.Nome    = data.GetValue(1).ToString();
                a.Ra      = data.GetValue(2).ToString();
                a.Idade   = Convert.ToInt32(data.GetValue(3));
            }

            connect.Desconect();

            return a;
        }
    }
}
