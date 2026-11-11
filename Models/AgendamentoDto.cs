namespace SimuladoVeterinaria.Models
{
    public class AgendamentoDto
    {
        public int Id { get; set; }
        public DateOnly Data { get; set; }
        public string Motivo { get; set; }
        public string Gravidade { get; set; }
        public int PetId { get; set; }
        public int TutorId { get; set; }
    }
}
