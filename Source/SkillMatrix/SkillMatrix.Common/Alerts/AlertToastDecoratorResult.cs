using System.Web.Mvc;

namespace SkillMatrix.Common.Alerts
{
    public class AlertToastDecoratorResult:ActionResult
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public ActionResult InnerResult { get; set; }

        public AlertToastDecoratorResult(ActionResult innerResult,
            string type,
            string title,
            string message)
        {
            InnerResult = innerResult;
            Message = message;
            Title = title;
            Type = type;
        }

        

        public override void ExecuteResult(ControllerContext context)
        {
            var alerts = context.Controller.TempData.GetToastAlerts();
            alerts.Add(new ToastAlert(Type,Title, Message));
            InnerResult.ExecuteResult(context);
        }
    }
}
