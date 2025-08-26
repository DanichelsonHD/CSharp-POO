namespace Secao8.exercicio_02
{
    class Program
    {
        static void Main2(string[] args)
        {
            List<Comment> comments = new List<Comment>()
            {
                new Comment("Have a nice trip"),
                new Comment("Wow that's awesome!")
            };

            Post post1 = new Post(
                DateTime.Parse("21/06/2018 13:05:44"),
                "Traveling to New Zealand",
                "I'm going to visit this wonderful country!",
                13,
                comments
            );
            post1.Dislike();

            Post post2 = new Post(
                DateTime.Parse("28/07/2018 23:14:19"),
                "Good night guys",
                "See you tomorrow",
                4
            );
            post2.Like();
            post2.AddComment(new Comment("Good night"));
            post2.AddComment(new Comment("May the Force be with you"));

            Console.WriteLine(post1.ToString() + "\n");
            Console.WriteLine(post2.ToString());
        }
    }
}