using System;

namespace StackOverflowPost
{
    class Program
    {
        static void Main(string[] args)
        {
            var post1 = new Post("First Post", "This is the first post");
            Console.WriteLine($"Title: {post1.Title}");
            Console.WriteLine($"Description: {post1.Description}");
            Console.WriteLine($"Created: {post1.Created}");
            post1.DownVote(); // no can do - still has 0 votes
            post1.UpVote();
            post1.UpVote();
            post1.UpVote();
            post1.UpVote(); // has 4 votes
            post1.DownVote(); // has 3 votes
            Console.WriteLine($"Votes: {post1.GetVotes()}");


        }
    }
}
