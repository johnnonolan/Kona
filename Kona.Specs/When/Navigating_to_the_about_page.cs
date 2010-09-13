using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Kona.Controllers;
using Kona.Specs.Behaviours;
using Kona.Specs.Extensions;
using Machine.Specifications;

#region gettingDry
//namespace When
//{
//    [Subject(typeof(HomeController))]
//    public class Navigating_to_the_about_page : ControllerContext<HomeController>
//    {
//        Establish context = () =>
//            {
//                // we could be setting up mocks n stubs n stuff here.
//                // e.g. extra context specific to this
//            };
//        Because of = () => result = controller.About();
//        //note that it is asserting the same thing (view is empty)
//        It should_show_the_about_view = () =>
//           result.is_a_view_and().ViewName.ShouldBeEmpty();

//        static ActionResult result;
//    }

//}
#endregion

#region behaviors
//namespace When
//{
//    [Subject(typeof(HomeController))]
//    public class Navigating_to_the_about_page : ControllerContext<HomeController>
//    {
//        Because of = () => result = controller.About();

//        Behaves_like<AStandardViewResult> your_common_or_garden_controller_action;

//        protected static ActionResult result; //need to change me to protected
//    }
//}
#endregion
