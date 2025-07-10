using Microsoft.Data.SqlClient;
using Dapper; 

public static class BD
{
    private static string _connectionString = @"Server=localhost;DataBase=EquipoLosPibes;Integrated Security=True;TrustServerCertificate=True;";

public static Integrante BuscarIntegrante(string email, string contraseña)
{
    Integrante integrante = null;
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Integrantes WHERE Email = @Email AND Password = @Password";
        integrante = connection.QueryFirstOrDefault<Integrante>(query, new { Email = email, Password = contraseña });
    }
    return integrante;
}
    public static void AgregarIntegrante(Integrante integrante)
    {
     string query = "INSERT INTO Integrantes (Email, Password, Nombre, DNI, Hobby, Edad, Genero) " +
               "VALUES (@Email, @Password, @Nombre, @DNI, @Hobby, @Edad, @Genero)";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new
            {
                Email = integrante.Email,
                Password = integrante.Password,
                Nombre = integrante.Nombre,
                DNI = integrante.DNI,
                Hobby = integrante.Hobby,
                Edad = integrante.Edad,
                Genero = integrante.Genero
            });
        }
    }
}