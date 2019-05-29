using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RateMyCourse.Services
{
    using Data;
    using Domain;
    using ViewModels;

    public class ReviewService : Service<Review>, IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository) : base(reviewRepository  as IRepository<Review>)
        {
            _reviewRepository = reviewRepository;
        }

        public ReviewViewModel CreateViewModel(Review reviewEntity)
        {
            var model = new ReviewViewModel
            {
                ReviewId = reviewEntity.ReviewId,
                ReviewDate = reviewEntity.ReviewDate,
                ReviewText = reviewEntity.ReviewText,
                Stars = reviewEntity.Stars,
                CourseId = reviewEntity.CourseId,
                Course = new CourseViewModel
                {                 
                    CourseId = reviewEntity.Course.CourseId,
                    Name = reviewEntity.Course?.Name,
                    Description = reviewEntity.Course?.Description,
                    Code = reviewEntity.Course?.Code,
                    Status = reviewEntity.Course.Status
                },
                StudentId = reviewEntity.CourseId,
                Student = new StudentViewModel
                {
                    StudentId = reviewEntity.Student.StudentId,
                    Name = reviewEntity.Student?.Name,
                    City = reviewEntity.Student?.City,
                    PhoneNumber= reviewEntity.Student?.PhoneNumber,
                    Status = reviewEntity.Student.Status
                },
            };
            return model;
        }

        public new ReviewViewModel Get(int id)
        {
            return CreateViewModel(base.Get(id));
        }

        public new IEnumerable<ReviewViewModel> GetAll()
        {
            return base.GetAll().Select(CreateViewModel);
        }

        public void Add(ReviewViewModel entity)
        {
            base.Add(CreateEntity(entity));
        }

        public void Update(ReviewViewModel entity)
        {
            base.Update(CreateEntity(entity));
        }

        public new IEnumerable<ReviewViewModel> FindBy(Expression<Func<Review, bool>> predicate)
        {
            return base.FindBy(predicate).Select(CreateViewModel);
        }

        public void Remove(ReviewViewModel entity)
        {
            base.Remove(CreateEntity(entity));
        }

        public Review CreateEntity(ReviewViewModel reviewViewModel)
        {
            var entity = new Review
            {
                ReviewId = reviewViewModel.ReviewId,
                ReviewDate = reviewViewModel.ReviewDate,
                ReviewText = reviewViewModel.ReviewText,
                Stars =  reviewViewModel.Stars
            };
            return entity;
        }

    }
}
