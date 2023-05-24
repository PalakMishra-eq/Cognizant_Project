public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string SubjectTaken { get; set; }
    public string Password { get; set; }
    public string MobileNumber { get; set; }
}

public class Mentor
{
    public int MentorId { get; set; }
    public string Name { get; set; }
    public string Subject { get; set; }
    public int SubjectId { get; set; }
}

public class Subject
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public string MentorName { get; set; }
}
