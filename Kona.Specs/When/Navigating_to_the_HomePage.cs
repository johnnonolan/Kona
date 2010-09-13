using System.Web.Mvc;
using Kona.Controllers;
using Kona.Specs.Behaviours;
using Kona.Specs.Extensions;
using Machine.Specifications;
using Machine.Specifications.Model;
using StructureMap.AutoMocking;

#region the basics
//namespace When
//{
//    [Subject(typeof(HomeController))]
//    public class Navigating_to_the_HomePage
//    {
//        //Arrange
//        Establish context = () =>
//            {
//                mock = new RhinoAutoMocker<HomeController>();
//                controller = mock.ClassUnderTest;
//            };
//        //Act
//        Because of = () =>
//               result = controller.Index();

//        //Assert(s)
//        It should_show_the_index_view;

//        It should_return_a_productListViewModelType;
//        static HomeController controller;
//        static RhinoAutoMocker<HomeController> mock;
//        static ActionResult result;

//        //Don't forget HTML output
//        #region setUpAndTearDowns
//        Context before_each; // SetUp
//        Context before_all; // SetUpFixture
//        Context after_each; // TearDown  
//        Context after_all; // TearDownFixture        
//        #endregion


//    }
//}
#endregion

#region Adding some meat to the spec
//namespace When
//{
//    [Subject(typeof(HomeController))]
//    public class Navigating_to_the_HomePage
//    {

//        Establish context = () =>
//        {
//            var mock = new RhinoAutoMocker<HomeController>();
//            controller = mock.ClassUnderTest;
//        };

//        Because of = () =>
//            result = controller.Index();
//        //lots of extension methods
//        //reads like a sentence
//        It should_show_the_index_view = () =>
//               result.is_a_view_and().ViewName.ShouldBeEmpty();

//        It should_return_a_productListViewModelType; 
            
//        static HomeController controller;
//        static ActionResult result;

//    }
//}
#endregion 

#region gettingDRY
//namespace When
//{
//    //dont forget about action
//    [Subject(typeof(HomeController))]
//    public class Navigating_to_the_HomePage : ControllerContext<HomeController>
//    {

//        Because of = () =>
//            result = controller.Index();

//        It should_show_the_index_view = () =>
//               result.is_a_view_and().ViewName.ShouldBeEmpty();
//        It should_return_a_productListViewModelType;

//        static ActionResult result;

//    }

//    //obviously can be used for any controller context
//    public class ControllerContext<T> where T : class
//    {
//        Establish automocking = () =>
//            {
//                mock = new RhinoAutoMocker<T>();
//                controller = mock.ClassUnderTest;
//            };
//        protected static RhinoAutoMocker<T> mock;
//        protected static T controller;
//    }
//}
#endregion

#region behaviours
//namespace When
//{
//    [Subject(typeof(HomeController))]
//    public class Navigating_to_the_HomePage : ControllerContext<HomeController>
//    {


//        Because of = () =>
//            result = controller.Index();


//        It should_return_a_productListViewModelType;

//        Behaves_like<AStandardViewResult> your_common_or_garden_controller_Action;

//        protected static ActionResult result; //needs to be protected for behaviours

//    }


//    public class ControllerContext<T> where T : class
//    {
//        Establish automocking = () =>
//        {
//            mock = new RhinoAutoMocker<T>();
//            controller = mock.ClassUnderTest;
//        };
//        protected static RhinoAutoMocker<T> mock;
//        protected static T controller;
//    }
//}
#endregion


