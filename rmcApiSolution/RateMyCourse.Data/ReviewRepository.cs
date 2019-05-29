namespace RateMyCourse.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;

    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(DataContext database) : base(database)
        {
            Database = database;
        }

        public override void Add(Review entity)
        {
            if (entity != null)
                base.Add(entity);
        }
        public override void Update(Review entity)
        {
            if (entity == null) return;
            Review updateReview = base.Get(entity.ReviewId);
            if (updateReview == null) return;
            updateReview.ReviewText = entity.ReviewText;
            updateReview.ReviewDate = entity.ReviewDate;
            updateReview.Stars = entity.Stars;
            updateReview.CourseId = entity.CourseId;
            updateReview.StudentId = entity.ReviewId;
        }
        public override IEnumerable<Review> FindBy(Expression<Func<Review, bool>> predicate)
        {
            return predicate == null ? GetAll() : base.FindBy(predicate);
        }

        public override Review Get(int id)
        {
            var review = (from r in Database.Reviews.Include("Course").Include("Student")
                where r.ReviewId == id
                select r).SingleOrDefault();

            return review;
        }

        public override IEnumerable<Review> GetAll()
        {
            var reviews = from r in Database.Reviews.Include("Course").Include("Student")
                         select r;

            return reviews;
        }

        public override void Remove(int id)
        {
            if (id > 0)
                base.Remove(id);
        }

        public override void Remove(Review entity)
        {
            if (entity != null)
                base.Remove(entity);
        }

        public override void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
