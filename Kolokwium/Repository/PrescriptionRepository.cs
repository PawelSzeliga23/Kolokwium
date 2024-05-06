using System.Data.SqlClient;
using Kolokwium.Models;

namespace Kolokwium.Repository;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly IConfiguration _configuration;

    public PrescriptionRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Prescription> GetPrescriptionByMedicamentId(int id)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();

        using var command =
            new SqlCommand(
                $"SELECT IdPrescription ,Date , DueTo FROM PRESCRIPTION P Inner Join PRESCRIPTION_MEDICINE PM ON P.IdPrescription = PM.IdPrescription Where PM.IdMedicament = @id Order By P.Date Desc",
                connection);
        using var reader = command.ExecuteReader();
        var prescriptions = new List<Prescription>();
        while (reader.Read())
        {
            var prescription = new Prescription()
            {
                Id = (int)reader["IdPrescription"],
                Date = (DateOnly)reader["Date"],
                DueTo = (DateOnly)reader["DueTo"]
            };
            prescriptions.Add(prescription);
        }

        return prescriptions;
    }
}

public interface IPrescriptionRepository
{
    public IEnumerable<Prescription> GetPrescriptionByMedicamentId(int id);
}