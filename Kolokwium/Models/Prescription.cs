
namespace Kolokwium.Models;

public class Prescription
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueTo { get; set; }
}