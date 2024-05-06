namespace Kolokwium.Models;

public class Medicament
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public IEnumerable<Prescription> PerscriptionList { get; set; }
}