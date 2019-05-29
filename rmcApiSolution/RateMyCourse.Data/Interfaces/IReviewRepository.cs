namespace RateMyCourse.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Domain;

    public interface IReviewRepository
    {
        void Add(Review entity);
        IEnumerable<Review> FindBy(Expression<Func<Review, bool>> predicate);
        Review Get(int id);
        void Update(Review entity);
        IEnumerable<Review> GetAll();
        void Remove(Review entity);
        void Remove(int id);
        void SaveChanges();
    }
}