using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Text.RegularExpressions;

namespace SIMA.WorkFlowEngine.WebApi.Conventions
{
    public class ModelConvention : IApplicationModelConvention
    {
        private const string Query = "QueryController";
        private const string StrRegex = @"api/v\d+/";
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers.Where(a => a.ControllerType.Name.EndsWith(Query, StringComparison.OrdinalIgnoreCase)))
            {
                foreach (var selectorModel in controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList())
                {
                    var newTemplate = string.Empty;
                    var match = Regex.Match(selectorModel.AttributeRouteModel.Template, StrRegex, RegexOptions.IgnoreCase);

                    if (match.Success)
                    {
                        newTemplate = match.Value;
                    }

                    selectorModel.AttributeRouteModel =
                        new AttributeRouteModel
                        {
                            Template = newTemplate +
                                       controller.ControllerType.Name.Replace(Query, "", StringComparison.OrdinalIgnoreCase)
                        };
                }
            }
        }
    }
}
