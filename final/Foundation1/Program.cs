using System;
using System.Collections.Generic;

//youtube video abstraction program

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Length: {Length} seconds, Comments: {GetNumberOfComments()}");
        foreach (var comment in comments)
        {
            Console.WriteLine($"   {comment.CommenterName}: {comment.CommentText}");
        }
    }
}

public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

public class Program
{
    public static void Main()
    {
        var videos = new List<Video>
        {
            new Video("Video 1", "Author 1", 120),
            new Video("Video 2", "Author 2", 300),
            new Video("Video 3", "Author 3", 240),
            new Video("Video 4", "Author 4", 150)
        };

        videos[0].AddComment(new Comment("User1", "Great video!"));
        videos[0].AddComment(new Comment("User2", "Very informative."));
        videos[0].AddComment(new Comment("User3", "Loved it!"));

        videos[1].AddComment(new Comment("User4", "Nice explanation."));
        videos[1].AddComment(new Comment("User5", "Helpful."));

        videos[2].AddComment(new Comment("User6", "Awesome!"));
        videos[2].AddComment(new Comment("User7", "Thanks for sharing."));

        videos[3].AddComment(new Comment("User8", "Good job."));
        videos[3].AddComment(new Comment("User9", "Well done."));
        videos[3].AddComment(new Comment("User10", "Excellent content."));

        foreach (var video in videos)
        {
            video.Display();
            Console.WriteLine();
        }
    }
}
