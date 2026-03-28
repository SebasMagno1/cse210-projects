using System;
using System.Collections.Generic;

// ===============================
// Comment Class
// ===============================
class Comment
{
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetText()
    {
        return _text;
    }
}

// ===============================
// Video Class
// ===============================
class Video
{
    private string _title;
    private string _author;
    private int _length; // in seconds
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLength()
    {
        return _length;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}

// ===============================
// Program (Main)
// ===============================
class YoutubeProgram
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // ===============================
        // Video 1
        // ===============================
        Video video1 = new Video("Learn C# in 10 Minutes", "CodeMaster", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Carlos", "I learned a lot."));
        videos.Add(video1);

        // ===============================
        // Video 2
        // ===============================
        Video video2 = new Video("JavaScript Basics", "WebDevPro", 900);
        video2.AddComment(new Comment("Diana", "Awesome video!"));
        video2.AddComment(new Comment("Ethan", "Clear and simple."));
        video2.AddComment(new Comment("Fernanda", "Loved it!"));
        videos.Add(video2);

        // ===============================
        // Video 3
        // ===============================
        Video video3 = new Video("HTML & CSS Crash Course", "DesignGuru", 1200);
        video3.AddComment(new Comment("George", "Very informative."));
        video3.AddComment(new Comment("Hannah", "Good pace."));
        video3.AddComment(new Comment("Ivan", "Helped me a lot."));
        videos.Add(video3);

        // ===============================
        // Video 4
        // ===============================
        Video video4 = new Video("Python for Beginners", "TechWorld", 800);
        video4.AddComment(new Comment("Julia", "Excellent tutorial."));
        video4.AddComment(new Comment("Kevin", "Easy to follow."));
        video4.AddComment(new Comment("Luis", "Thanks for sharing!"));
        videos.Add(video4);

        // ===============================
        // Display Videos
        // ===============================
        foreach (Video video in videos)
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");

            Console.WriteLine("---- Comments ----");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }
        }
    }
}