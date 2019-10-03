using System.Collections.Generic;

namespace src.Models {
    public class Topic {
        public long TopicId { get; set; }

        public string Topico { get; set; }

        public IList<Todo> Todos { get; set; } = new List<Todo>();
    }
}