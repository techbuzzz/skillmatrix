using System;
using System.ComponentModel.DataAnnotations;
using SkillMatrix.Common;

namespace SkillMatrix.ViewModel
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            UId = Guid.NewGuid().ToString();
            CreatedOn = DateTime.UtcNow;
        }

        public BaseViewModel(string createdUserId):this()
        {
            CreatedById = createdUserId;
        }
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public string UId { get; set; }

        //[ScaffoldColumn(false)]
        //public string CreatedById { get; set; }
        public AccountBaseViewModel CreatedBy { get; set; }
        public string CreatedById { get; set; }


        public DateTime? CreatedOn { get; set; }

        public string CreatedOnDisplay => Utilities.FormatLongDate(Utilities.ParseDate(CreatedOn));

        //[ScaffoldColumn(false)]
        //public string UpdatedById { get; set; }
        public AccountBaseViewModel UpdatedBy { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedOn { get; set; }


        public void GenerateNewId()
        {
            UId = Guid.NewGuid().ToString();
        }
    }
}
