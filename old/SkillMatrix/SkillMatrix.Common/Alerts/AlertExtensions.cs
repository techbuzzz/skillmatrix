using System.Collections.Generic;
using System.Web.Mvc;

namespace SkillMatrix.Common.Alerts
{
	public static class AlertExtensions
	{
		const string Alerts = "_Alerts";
	    const string ToastAlerts = "_toastAlerts";


        public static List<Alert> GetAlerts(this TempDataDictionary tempData)
		{
			if (!tempData.ContainsKey(Alerts))
			{
				tempData[Alerts] = new List<Alert>();
			}

			return (List<Alert>)tempData[Alerts];
		}

	    public static List<ToastAlert> GetToastAlerts(this TempDataDictionary tempData)
	    {
	        if (!tempData.ContainsKey(ToastAlerts))
	        {
	            tempData[ToastAlerts] = new List<ToastAlert>();
	        }

	        return (List<ToastAlert>)tempData[ToastAlerts];
	    }

        //      public static ActionResult WithSuccess(this ActionResult result, string message)
        //{
        //	return new AlertDecoratorResult(result, "alert-success", message, 5);
        //}

        //public static ActionResult WithInfo(this ActionResult result, string message)
        //{
        //	return new AlertDecoratorResult(result, "alert-info", message,5) ;
	    //}
	    //public static ActionResult WithWarning(this ActionResult result, string message)
	    //{
	    //    return new AlertDecoratorResult(result, "alert-warning", message, 5);
	    //}

	    //public static ActionResult WithError(this ActionResult result, string message)
	    //{
	    //    return new AlertDecoratorResult(result, "alert-danger", message, 5);
	    //}

        public static ActionResult WithInfo(this ActionResult result,string title, string message)
	    {
	        return new AlertToastDecoratorResult(result,"info", title, message);
	    }

	    public static ActionResult WithWarning(this ActionResult result, string title, string message)
	    {
	        return new AlertToastDecoratorResult(result, "warning", title, message);
	    }
	    public static ActionResult WithSuccess(this ActionResult result, string title, string message)
	    {
	        return new AlertToastDecoratorResult(result, "success", title, message);
	    }
	    public static ActionResult WithError(this ActionResult result, string title, string message)
	    {
	        return new AlertToastDecoratorResult(result, "error", title, message);
	    }

        
	}
}