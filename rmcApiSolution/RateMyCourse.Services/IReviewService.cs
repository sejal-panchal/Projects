namespace RateMyCourse.Services
{
    using Domain;
    using ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IReviewService
    {
        Review CreateEntity(ReviewViewModel ReviewViewModel);
        ReviewViewModel CreateViewModel(Review ReviewEntity);
        ReviewViewModel Get(int id);
        IEnumerable<ReviewViewModel> GetAll();
        void Add(ReviewViewModel entity);
        void Update(ReviewViewModel entity);
        IEnumerable<ReviewViewModel> FindBy(Expression<Func<Review, bool>> predicate);
        void Remove(ReviewViewModel entity);
        void Remove(int id);
        void SaveChanges();
    }
}
