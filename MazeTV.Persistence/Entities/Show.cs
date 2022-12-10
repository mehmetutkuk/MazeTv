using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTV.Persistence.Entities
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Person> Cast { get; set; }

    }
}
