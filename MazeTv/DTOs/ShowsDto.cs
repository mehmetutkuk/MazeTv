using MazeTV.Persistence.Entities;

namespace MazeTv.DTOs
{
    public class ShowsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PersonDto[] Cast { get; set; }



        public static ShowsDto Map(Show show)
        {
            var model = new ShowsDto { Id = show.Id, Name = show.Name, Cast = show.Cast?.Select(s => PersonDto.Map(s.Person)).ToArray() };

            return model;
  

        }
    }
}
