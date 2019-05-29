namespace RateMyCourse.ViewModels
{
    using Domain;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class MVCBaseViewModel
    {
        public Status Status { get; set; }
        public string SelectedStatus { get; set; }
        public List<SelectListItem> StatusList { get; set; }

    }
}
