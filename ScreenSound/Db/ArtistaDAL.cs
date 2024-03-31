using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Db
{
    internal class ArtistaDAL
    {
        
        public List<Artista> GetArtistas()
        {
            List<Artista> artistas = new List<Artista>();

            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();
                string query = "select * from Artistas";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        string nomeArtista = Convert.ToString(dataReader["Nome"]) ?? string.Empty;
                        string bio = Convert.ToString(dataReader["Bio"]) ?? string.Empty;
                        string FotoPerfil = Convert.ToString(dataReader["FotoPerfil"]) ?? string.Empty;
                        int id = Convert.ToInt32(dataReader["Id"]);

                        Artista a = new Artista(nomeArtista, bio);
                        a.Id = id;

                        artistas.Add(a);
                    }
                }
            }

            return artistas;
        }

        public void InserirArtista(Artista artista)
        {
            using (SqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                string sqlCommand = "insert into Artistas(Nome, Bio, FotoPerfil) values (@nome, @bio, @fotoPerfil)";

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.AddWithValue("@nome", artista.Nome);
                command.Parameters.AddWithValue("@bio", artista.Bio);
                command.Parameters.AddWithValue("@fotoPerfil", artista.FotoPerfil);

                int result = command.ExecuteNonQuery();
                Console.WriteLine(result);
            }
        }
    }
}
