namespace Secao8.exercicio_02
{
    class Post
    {
        public DateTime Moment { get; private set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; private set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public Post(DateTime Moment, string Title, string Content)
        {
            this.Moment = Moment;
            this.Title = Title;
            this.Content = Content;
        }
        public Post(DateTime Moment, string Title, string Content, int Likes) 
            : this(Moment, Title, Content) => this.Likes = Likes;
        public Post(DateTime Moment, string Title, string Content, int Likes, List<Comment> Comments) 
            : this(Moment, Title, Content, Likes) => this.Comments = Comments;
        public void AddComment(Comment comment) => Comments.Add(comment);
        public void Like() => Likes++;
        public void Dislike() => Likes--;
        public override string ToString()
        {
            string text = $"{Title}\n{Likes} Likes - {Moment.ToString("dd/MM/yyyy HH:mm:ss")}\n{Content}\nComments:";
            foreach (Comment comment in Comments) text += "\n" + comment.Text;
            return text;
            
        }
    }
}