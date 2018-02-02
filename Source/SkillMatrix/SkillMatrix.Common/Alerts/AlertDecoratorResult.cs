using System.Web.Mvc;

namespace SkillMatrix.Common.Alerts
{
	public class AlertDecoratorResult : ActionResult
	{
		public ActionResult InnerResult { get; set; }
		public string AlertClass { get; set; }
		public string Message { get; set; }

        public int Timeout { get; set; }


        public AlertDecoratorResult(ActionResult innerResult,
				string alertClass,
				string message, int timeout)
		{
			InnerResult = innerResult;
			AlertClass = alertClass;
			Message = message;
		    Timeout = timeout;

		}

	   

        public override void ExecuteResult(ControllerContext context)
		{
			var alerts = context.Controller.TempData.GetAlerts();
			alerts.Add(new Alert(AlertClass, Message, Timeout));
			InnerResult.ExecuteResult(context);
		}
	}
}