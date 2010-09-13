using System.Web.Mvc;


namespace Kona.Specs.Extensions
{
    public static class SpecExtensions
    {
        public static ViewResult is_a_view_and(this ActionResult result)
        {
            return result as ViewResult;
        }
    }
}
