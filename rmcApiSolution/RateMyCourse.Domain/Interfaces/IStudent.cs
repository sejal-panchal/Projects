namespace RateMyCourse.Domain
{
    public interface IStudent
    {
        string City { get; set; }
        string Name { get; set; }
        string PhoneNumber { get; set; }
        int StudentId { get; set; }
    }
}