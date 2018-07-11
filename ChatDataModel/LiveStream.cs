using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataModel
{
    public class LiveStream
    {
        public string ID { get; set; }
        public string LiveUser { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int Views { get; set; }
        public LiveStream()
        {
            
        }

        public LiveStream(string id, string liverUser, DateTime startTime, int duration, int views)
        {
            ID = id;
            LiveUser = liverUser;
            StartTime = startTime;
            Duration = duration;
            Views = views;
        }
    }
}
