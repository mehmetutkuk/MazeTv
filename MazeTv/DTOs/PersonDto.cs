using MazeTV.Persistence.Entities;

namespace MazeTv.DTOs
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public static PersonDto Map(Person person)
        {
            var model = new PersonDto { Id = person.Id, Name = person.Name, BirthDate = person.BirthDate };
            return model;

        }

    }
}
