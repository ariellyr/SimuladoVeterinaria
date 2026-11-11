namespace SimuladoVeterinaria.Models
{
    public class InfoAgendamentos
    {
        public int Id { get; set; }
        public DateOnly Data { get; set; }
        public string NomeTutor { get; set; }
        public string NomePet { get; set; }
        public string RacaPet { get; set; }
        public int PetId { get; set; }
        public int TutorId { get; set; }
    }
}
