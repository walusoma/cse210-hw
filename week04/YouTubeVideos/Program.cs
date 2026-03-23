using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video v1 = new Video();
        v1._title = "Learn C# Basics";
        v1._author = "John";
        v1._length = 300;

        v1._comments.Add(new Comment { _name = "Alice", _text = "Great video!" });
        v1._comments.Add(new Comment { _name = "Bob", _text = "Very helpful." });
        v1._comments.Add(new Comment { _name = "Mark", _text = "Thanks!" });

        videos.Add(v1);

        // Video 2
        Video v2 = new Video();
        v2._title = "OOP in C#";
        v2._author = "Sarah";
        v2._length = 450;

        v2._comments.Add(new Comment { _name = "Tom", _text = "Nice explanation!" });
        v2._comments.Add(new Comment { _name = "Jane", _text = "Loved it." });
        v2._comments.Add(new Comment { _name = "Chris", _text = "Clear and simple." });

        videos.Add(v2);

        // Video 3
        Video v3 = new Video();
        v3._title = "Advanced C#";
        v3._author = "Mike";
        v3._length = 600;

        v3._comments.Add(new Comment { _name = "Anna", _text = "Awesome!" });
        v3._comments.Add(new Comment { _name = "Peter", _text = "Very detailed." });
        v3._comments.Add(new Comment { _name = "Sam", _text = "Helpful content." });

        videos.Add(v3);

        // Display
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($" - {comment._name}: {comment._text}");
            }

            Console.WriteLine();
        }
    }
}