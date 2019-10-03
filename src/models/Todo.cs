namespace src.Models {
    public class Todo {
        public long id { get; set; }

        public string todo { get; set; }

        public bool isComplete { get; set; }

        public long TopicId { get; set; }
        
        public Topic Topic { get; set; }
    }
}