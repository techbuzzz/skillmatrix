using System.Web.Mvc;

namespace SkillMatrix.Common
{
    public class TrimModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueResult == null || string.IsNullOrWhiteSpace(valueResult.AttemptedValue)) return null;
            return valueResult.AttemptedValue;
        }
    }
}