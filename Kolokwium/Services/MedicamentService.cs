using Kolokwium.Exceptions;
using Kolokwium.Models;
using Kolokwium.Repository;

namespace Kolokwium;

public class MedicamentService : IMedicamentService
{
    private readonly IMedicamentRepository _medicamentRepository;
    private readonly IPrescriptionRepository _prescriptionRepository;

    public MedicamentService(IMedicamentRepository repository,IPrescriptionRepository prescriptionRepository)
    {
        _medicamentRepository = repository;
        _prescriptionRepository = prescriptionRepository;

    }

    public Medicament? GetMedicamentById(int id)
    {
        var medicament = _medicamentRepository.GetMedicamentById(id);
        if (medicament == null)
        {
            throw new NotFoundException("Medicament Not Found");
        }
        var prescriptionList = _prescriptionRepository.GetPrescriptionByMedicamentId(id);
        medicament.PerscriptionList = prescriptionList;
        return medicament;
    }
}

public interface IMedicamentService
{
    public Medicament? GetMedicamentById(int id);
}