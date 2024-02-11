namespace InvoiceAPP.Controllers.EnumRoutes
{
    public static partial class Extensions
    {
        public class CustomRouteConstraint<TEnum> : IRouteConstraint
            where TEnum : struct, Enum
        {
            public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
            {
                var candidate = values[routeKey]?.ToString();
                return Enum.TryParse(candidate, true, out TEnum result);
            }
        }
    }
}