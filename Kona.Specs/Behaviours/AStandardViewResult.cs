using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Kona.Specs.Extensions;
using Machine.Specifications;

namespace Kona.Specs.Behaviours
{
    [Behaviors]
    public class AStandardViewResult
    {
        It should_be_a_view_and_the_viewname_should_be_empty = () =>
             result.is_a_view_and().ViewName.ShouldBeEmpty();

        // we could have  number of Its in here

        protected static ActionResult result;
    }
}
