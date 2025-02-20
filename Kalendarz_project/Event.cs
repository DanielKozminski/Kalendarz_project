using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalendarz_project
{
    abstract class Event
    {
        abstract public string Name { get; set; }
        abstract public string Description { get; set; }
        abstract public DateTime Start { get; set; }
        abstract public DateTime End { get; set; }

        abstract public void StartSet(DateTime start);
        abstract public void EndSet(DateTime end);
    }
}
