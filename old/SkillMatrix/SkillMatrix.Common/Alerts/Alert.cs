namespace SkillMatrix.Common.Alerts
{
	public class Alert
	{
		public string AlertClass { get; set; }

        public int Timeout { get; set; }

        public string Message { get; set; }

		public Alert(string alertClass, string message, int timeout)
		{
			AlertClass = alertClass;
			Message = message;
		    Timeout = timeout;

		}
	}

    public class ToastAlert
    {

        public string Type { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string Content => $"toastr.{Type}('{Message}', '{Title}');";


        public ToastAlert(string type, string title, string message)
        {
            Title = title;
            Message = message;
            Type = type;
        }
    }
}