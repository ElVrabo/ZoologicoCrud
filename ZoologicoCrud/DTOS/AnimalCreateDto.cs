namespace ZoologicoCrud.DTOS
{
    public class AnimalCreateDto
    {
        // se reciben los datos desde el cliente en JSON en este DTO y despues en un controller se convierte a
        //entidad Animal 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }

        public string FotoUrl { get; set; }
    }
}
