namespace SimuladoVeterinaria.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Descricao { get; set; }
        public int TutorId { get; set; }
    }
}
