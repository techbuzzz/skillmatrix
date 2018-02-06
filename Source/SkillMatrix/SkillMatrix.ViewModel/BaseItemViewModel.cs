namespace SkillMatrix.ViewModel
{
    public class BaseItemViewModel:BaseViewModel
    {
        public BaseItemViewModel():base()
        {
            
        }

        public BaseItemViewModel(string createdById) : base(createdById)
        {

        }

        public string Title { get; set; }

        public string Description { get; set; }

        

    }
}
