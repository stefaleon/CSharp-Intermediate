using System;

namespace StackOverflowPost
{
    public class Post
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        private int _currentVote = 0;

        // default constructor - sets the Created datetime
        public Post()
        {
            Created = DateTime.Now;
        }

        // constructor with title and description parameters
        // inherits from the default constructor with : this()
        public Post(string title, string description)
            : this()
        {
            Title = title;
            Description = description;
        }

        public void UpVote()
        {
            _currentVote++;
        }

        public void DownVote()
        {
            if (_currentVote == 0)
            {
                Console.WriteLine("Cannot Down Vote. Press Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                _currentVote--;
            }

        }

        public int GetVotes()
        {
            return _currentVote;
        }
        
    }
}
