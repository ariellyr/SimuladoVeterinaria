namespace SimuladoVeterinaria.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateOnly Data { get; set; }
        public string Motivo { get; set; }
        public string Gravidade { get; set; } 
        public int PetId { get; set; }
        public int TutorId { get; set; }

        public virtual Pet? Pet {  get; set; }
        public virtual Tutor? Tutor { get; set; }
    }
}
