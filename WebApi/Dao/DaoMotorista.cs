using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Dao
{
    public class DaoMotorista
    {
        //string conexao = "Data Source=HMDB0007;Initial Catalog=dbTest;User ID=test.femsa;Password=p@$$w0rd";
        string conexao = "Data Source=DESKTOP-JDK2GPD;Initial Catalog=dbTest;User ID=sa;Password=1234";

        public List<Motorista> GetMotoristas()
        {
            List<Motorista> motoristas = new List<Motorista>();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetMotoristas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {   
                                var motorista = new Motorista();

                                motorista.Codigo = int.Parse(reader["Codigo"].ToString());
                                motorista.Cpf = reader["Cpf"].ToString();
                                motorista.Nome = reader["Nome"].ToString();
                                motorista.Sexo = reader["Sexo"].ToString();
                                motorista.Idade = int.Parse(reader["Idade"].ToString());
                                motorista.Ativo = bool.Parse(reader["Ativo"].ToString());
                                motoristas.Add(motorista);
                            }
                        }
                    }
                }
            }
            return motoristas;
        }

        public Motorista GetMotorista(int codigo)
        {
            Motorista motorista = new Motorista();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetMotorista", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO", codigo);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                motorista.Codigo = int.Parse(reader["Codigo"].ToString());
                                motorista.Cpf = reader["Cpf"].ToString();
                                motorista.Nome = reader["Nome"].ToString();
                                motorista.Sexo = reader["Sexo"].ToString();
                                motorista.Idade = int.Parse(reader["Idade"].ToString());
                                motorista.Ativo = bool.Parse(reader["Ativo"].ToString());
                            }
                        }
                    }
                }
            }
            return motorista;
        }

        public void PostMotorista(Motorista motorista)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PostMotorista", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CPF", motorista.Cpf);
                    cmd.Parameters.AddWithValue("@NOME", motorista.Nome);
                    cmd.Parameters.AddWithValue("@SEXO", motorista.Sexo);
                    cmd.Parameters.AddWithValue("@IDADE", motorista.Idade);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void PutMotorista(Motorista motorista)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PutMotorista", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO", motorista.Codigo);
                    cmd.Parameters.AddWithValue("@CPF", motorista.Cpf);
                    cmd.Parameters.AddWithValue("@NOME", motorista.Nome);
                    cmd.Parameters.AddWithValue("@SEXO", motorista.Sexo);
                    cmd.Parameters.AddWithValue("@IDADE", motorista.Idade);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteMotorista(int codigo)
        {
            var Motorista = GetMotorista(codigo);

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DeleteMotorista", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO", Motorista.Codigo);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
