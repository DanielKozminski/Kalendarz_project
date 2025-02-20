using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalendarz_project
{
    class TaskEvent : Event
    {
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override DateTime Start { get; set; }
        public override DateTime End { get; set; }
        public TaskEvent()
        {

        }
        public override void StartSet(DateTime start)
        {
            start = DateTime.Now;
            this.Start = start;
        }
        public override void EndSet(DateTime end)
        {
            end = DateTime.Now;
            this.End = end;
        }
    }
}
