using System.Data.SqlClient;
using Kolokwium.Exceptions;
using Kolokwium.Models;

namespace Kolokwium.Repository;

public class MedicamentRepository : IMedicamentRepository
{
    private readonly IConfiguration _configuration;

    public MedicamentRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Medicament? GetMedicamentById(int id)
    {
        Medicament medicament = null;
        using var connection = new SqlConnection(_configuration["ConnectionString:DefaultConnection"]);
        connection.Open();
        using var command =
            new SqlCommand("SELECT IdMedicament,Name, Description,Type FROM MEDICAMENT WHERE IdMedicament = @Id",
                connection);
        command.Parameters.AddWithValue("@Id", id);
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            medicament = new Medicament()
            {
                Id = (int)reader["IdMedicament"],
                Name = reader["Name"].ToString()!,
                Description = reader["Description"].ToString()!,
                Type = reader["Type"].ToString()!
            };
        }
        else
        {
            throw new NotFoundException($"Medicament with id: {id} not found");
        }

        return medicament;
    }
}

public interface IMedicamentRepository
{
    public Medicament? GetMedicamentById(int id);
}