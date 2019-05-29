namespace RateMyCourse.Data.Migrations
{
    using Domain;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext context)
        {

            context.Courses.AddOrUpdate(
              c => c.Name,
              new Course { Status=Status.Active, Code= "CCTP150", Name = "C# Level 1", Description = "C# Level 1"},
              new Course { Status=Status.Active, Code= "CCTP250", Name = "C# Level 2", Description = "C# Level 2"},
              new Course { Status=Status.Active, Code= "CCTP151", Name = "Entity Framework", Description = "Entity Framework" },
              new Course { Status=Status.Active, Code= "CCTP152", Name = "MVC Level 1", Description = "MVC Level 1"},
              new Course { Status=Status.Active, Code= "CCTP153", Name = "MVC Level 2", Description = "MVC Level 2"},
              new Course { Status=Status.Active, Code= "CCTP154A", Name = "TypeScript", Description = "TypeScript"},
              new Course { Status=Status.Active, Code= "CCTP154B", Name = "Angular", Description = "Angular"}
            );

            context.Students.AddOrUpdate(
              p => p.Name,
              new Student { Status = Status.Active, Name = "Andrew Peters", City = "Edmonton", PhoneNumber = "(780) 423-1234" },
              new Student { Status = Status.Active, Name = "Kevin Small", City = "Edmonton", PhoneNumber = "(780) 573-3453" },
              new Student { Status = Status.Active, Name = "Larry Smith", City = "Edmonton", PhoneNumber = "(780) 423-1234" },
              new Student { Status = Status.Active, Name = "Susan Simian", City = "Edmonton", PhoneNumber = "(780) 578-7345" },
              new Student { Status = Status.Active, Name = "Mark Jones", City = "Edmonton", PhoneNumber = "(780) 423-8456" },
              new Student { Status = Status.Active, Name = "Kerry Anderson", City = "Edmonton", PhoneNumber = "(780) 873-3453" },
              new Student { Status = Status.Active, Name = "Frank Johnston", City = "Edmonton", PhoneNumber = "(780) 323-8456" },
              new Student { Status = Status.Active, Name = "Jerry Lambson", City = "Edmonton", PhoneNumber = "(780) 986-3403" },
              new Student { Status = Status.Active, Name = "Peter Stanson", City = "Edmonton", PhoneNumber = "(780) 715-1234" },
              new Student { Status = Status.Active, Name = "Ian Prantbrook", City = "Edmonton", PhoneNumber = "(780) 956-3453" },
              new Student { Status = Status.Active, Name = "Mary Debonet", City = "Edmonton", PhoneNumber = "(780) 725-1234" },
              new Student { Status = Status.Active, Name = "Kathleen Pang", City = "Edmonton", PhoneNumber = "(780) 756-7345" },
              new Student { Status = Status.Active, Name = "William Valieva", City = "Edmonton", PhoneNumber = "(780) 962-8456" },
              new Student { Status = Status.Active, Name = "Harold Candal", City = "Edmonton", PhoneNumber = "(780) 852-7455" },
              new Student { Status = Status.Active, Name = "Cheryl Rudyak", City = "Edmonton", PhoneNumber = "(780) 235-2343" },
              new Student { Status = Status.Active, Name = "Fred O'Leary", City = "Edmonton", PhoneNumber = "(780) 847-9363" },
              new Student { Status = Status.Active, Name = "Kim Grutza", City = "Edmonton", PhoneNumber = "(780) 7354-8754" }
            );
            context.SaveChanges();

            var studentList = context.Students.ToList();
            var courseList = context.Courses.ToList();

            var skipCourses = false;
            foreach (var student in studentList)
            {
                student.Courses.Clear();
                skipCourses = !skipCourses;
                var theseCourses = skipCourses ? courseList.Skip(3).Take(4).ToList() : courseList.Take(4).ToList();
                foreach (var c in theseCourses)
                {
                    c.Students.Add(student);
                }
            }
            context.SaveChanges();

            Queue<Review> availReviews = new Queue<Review>();
            foreach (Review review in ReviewsList)
            {
                availReviews.Enqueue(review);
            }

            foreach (Course c in context.Courses.ToList())
            {
                var counter = 0;
                foreach (Student student in c.Students)
                {

                    Review review = availReviews.Dequeue();
                    review.StudentId = student.StudentId;
                    review.CourseId = c.CourseId;

                    context.Reviews.Add(review);

                    counter++;
                    if (counter > 4)
                        break;
                }

            }
            
            context.SaveChanges();


        }

        private static readonly Review[] ReviewsList =
        {
            new Review { ReviewDate = DateTime.Now.AddDays(-100), Stars=4, ReviewText = "The hands-on programming assignment only requires editing small little functions, and thus do not yield the same sense of achievement as other MOOCs where your code actually does something significant."},
            new Review { ReviewDate = DateTime.Now.AddDays(-96), Stars=4, ReviewText = "Having dived into CS work without a foundation in theory, this course gave me a nice background. Would recommend to anyone looking to gain understanding/get practice in different data structures, especially in Python."},
            new Review { ReviewDate = DateTime.Now.AddDays(-95), Stars=5, ReviewText = "This is not a beginner level course. You should have a decent understanding of programing or be prepared to spend a significant amount of time Python tutorials."},
            new Review { ReviewDate = DateTime.Now.AddDays(-92), Stars=4, ReviewText = "This is the first time I have attended a class in this format and wondered how effective it would be. It was very effective and therefore I would definitely be interested in attending other classes in the same format."},
            new Review { ReviewDate = DateTime.Now.AddDays(-89), Stars=3, ReviewText = "The instructor was very knowlegeable and provided a wealth of information about the current version, especially since the last version I used was several releases ago."},
            new Review { ReviewDate = DateTime.Now.AddDays(-86), Stars=5, ReviewText = "I've never completed a course like this before and I cannot express how great the instructor was and the overall content of the material. I would defintely recommend this to my co-workers as well as friends."},
            new Review { ReviewDate = DateTime.Now.AddDays(-83), Stars=2, ReviewText = "I just finished this class. It was much harder and moved much quicker than any other MOOC I have taken. I learned a lot, but it was a lot more work than I had really anticipated. I am a complete novice with no programming experience, so perhaps that was my fault."},
            new Review { ReviewDate = DateTime.Now.AddDays(-78), Stars=4, ReviewText = "This was probably the best introduction to computer programming I have ever seen. The professors are engaging and the lectures are short and to the point. Finger exercises between lectures really drive home the points that the professors were trying to make."},
            new Review { ReviewDate = DateTime.Now.AddDays(-75), Stars=5, ReviewText = "Great course! But you have to work a lot, not get frustrated and be ready to think out of the box and get out of the comfort zone to solve the problems. One of the things to take away from this course for me was that coding of complex programs is not done alone."},
            new Review { ReviewDate = DateTime.Now.AddDays(-75), Stars=4, ReviewText = "I'm taking this class as a refresher and as a way to dig into some sorting algorithms that I haven't used in awhile but if I was new to coding/python, I would find this class to be very confusing. The lectures aren't presented very clearly."},
            new Review { ReviewDate = DateTime.Now.AddDays(-73), Stars=5, ReviewText = "The course moves very quickly and has required 20+ additional hours of work weekly beyond the instruction. The lectures are very contained in their scope, but the scope of the problems jumps far beyond the lecture and requires much unsupported research."},
            new Review { ReviewDate = DateTime.Now.AddDays(-71), Stars=4, ReviewText = "This course has been my best online 'tutorial'. Instructor approaches teaching from 'first principle' and for me that is the way to go. I was able to grasp the fundamentals of programming on the fly."},
            new Review { ReviewDate = DateTime.Now.AddDays(-69), Stars=2, ReviewText = "The many practice quizzes are very useful and I could follow the first half of the course but when I encountered a problem with an exercise around the middle of the course I couldn't solve it and since I was too busy to find other help."},
            new Review { ReviewDate = DateTime.Now.AddDays(-66), Stars=2, ReviewText = "This course covers a lot of ground, so it may be demanding for a beginner. However, if you have some programming experience and just want to get all you knowledge into a system and learn some python it can be pretty manageable."},
            new Review { ReviewDate = DateTime.Now.AddDays(-63), Stars=4, ReviewText = "This is am amazing class. One of the best so far MOOCs I've taken so far. I not only learned python, but also computational thinking that expands the power of programming. "},
            new Review { ReviewDate = DateTime.Now.AddDays(-58), Stars=3, ReviewText = "Excellent introduction class for anyone wanted to learn Python either you are a beginner/student or a professional experienced engineer wanted to learn something new. The class is somewhat medium-to-hard to follow and requires quite an attention and regularity of attendance."},
            new Review { ReviewDate = DateTime.Now.AddDays(-56), Stars=2, ReviewText = "Prior experience: 1 year of computer science education. This was my first MOOC, and up to this point, the most rewarding one. The way it approaches CS is the best I've seen so far, giving real examples of usage of all the concepts, it's really motivating."},
            new Review { ReviewDate = DateTime.Now.AddDays(-52), Stars=5, ReviewText = "Okay, so for someone who has never coded, and wants to learn to program, you can safely assume this is the best course, yet the hardest out their. Even for someone who has programmed for a year or so, this course can be tough."},
            new Review { ReviewDate = DateTime.Now.AddDays(-47), Stars=4, ReviewText = "An excellent introduction to thinking computationally. I liked the instructor, and the exercises and problems sets largely struck a nice balance, being challenging but not discouraging. The midterm and final, though, I found very difficult."},
            new Review { ReviewDate = DateTime.Now.AddDays(-42), Stars=5, ReviewText = "I really enjoyed this course. Prof. Grimson's lectures were a pleasure to watch. I had very little programming experience (just Python for Informatics on Coursera), so I found this course to be difficult, but very rewarding."},
            new Review { ReviewDate = DateTime.Now.AddDays(-37), Stars=1, ReviewText = "In summer last year, I took this course as my first course to learn CS and I was satisfied with the quality and rigor of this course. I learned many CS concepts and did practice with tons of programming exercises."},
            new Review { ReviewDate = DateTime.Now.AddDays(-32), Stars=3, ReviewText = "Challenging and rewarding introductory CS course. Downloading the Python interpreter is practically mandatory. If you can't install software on the machine you use, this may not be the course for you."},
            new Review { ReviewDate = DateTime.Now.AddDays(-28), Stars=5, ReviewText = "This course is hard like other MIT courses. Be prepared to work a lot to perform well. A good news that it's not that hard like previous course in functional programming."},
            new Review { ReviewDate = DateTime.Now.AddDays(-27), Stars=2, ReviewText = "Very useful course, with plenty of practice exercises. Covers programming methods beyond just the python language. A very good introduction, that goes fairly deep into the concepts. I hesitated rating it intermediate, rather than beginner."},
            new Review { ReviewDate = DateTime.Now.AddDays(-23), Stars=4, ReviewText = "Excellent class. It is a very serious introduction to programming, beyond the usual college introductory level. It discusses some data structures and a good number of algorithms. Its programming assignments are challenging."},
            new Review { ReviewDate = DateTime.Now.AddDays(-17), Stars=5, ReviewText = "I don't consider this an introduction to Python. They expect you to solve some of the problems without giving you the information in the lectures."},
            new Review { ReviewDate = DateTime.Now.AddDays(-14), Stars=2, ReviewText = "Video and audio quality (thus far) is a little poor by 2015 standards but the course content is deep, engaging and applicable. Both easy and challenging problems are interspersed at just the right intervals to keep you attentive and learning."},
            new Review { ReviewDate = DateTime.Now.AddDays(-92), Stars=4, ReviewText = "This is the first time I have attended a class in this format and wondered how effective it would be. It was very effective and therefore I would definitely be interested in attending other classes in the same format."},
            new Review { ReviewDate = DateTime.Now.AddDays(-89), Stars=4, ReviewText = "The instructor was very knowlegeable and provided a wealth of information about the current version, especially since the last version I used was several releases ago."},
            new Review { ReviewDate = DateTime.Now.AddDays(-86), Stars=4, ReviewText = "I've never completed a course like this before and I cannot express how great the instructor was and the overall content of the material. I would defintely recommend this to my co-workers as well as friends."},
            new Review { ReviewDate = DateTime.Now.AddDays(-83), Stars=3, ReviewText = "I just finished this class. It was much harder and moved much quicker than any other MOOC I have taken. I learned a lot, but it was a lot more work than I had really anticipated. I am a complete novice with no programming experience, so perhaps that was my fault."},
            new Review { ReviewDate = DateTime.Now.AddDays(-78), Stars=5, ReviewText = "This was probably the best introduction to computer programming I have ever seen. The professors are engaging and the lectures are short and to the point. Finger exercises between lectures really drive home the points that the professors were trying to make."},
            new Review { ReviewDate = DateTime.Now.AddDays(-75), Stars=4, ReviewText = "Great course! But you have to work a lot, not get frustrated and be ready to think out of the box and get out of the comfort zone to solve the problems. One of the things to take away from this course for me was that coding of complex programs is not done alone."},
            new Review { ReviewDate = DateTime.Now.AddDays(-75), Stars=3, ReviewText = "I'm taking this class as a refresher and as a way to dig into some sorting algorithms that I haven't used in awhile but if I was new to coding/python, I would find this class to be very confusing. The lectures aren't presented very clearly."},
            new Review { ReviewDate = DateTime.Now.AddDays(-73), Stars=2, ReviewText = "The course moves very quickly and has required 20+ additional hours of work weekly beyond the instruction. The lectures are very contained in their scope, but the scope of the problems jumps far beyond the lecture and requires much unsupported research."}
        };
    }
}
