using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTV.Persistence.Entities
{
    public class ShowPerson
    {

        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int ShowId { get; set; } 
        public Show Show { get; set; }
        
    }
}
