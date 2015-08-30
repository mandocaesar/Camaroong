using System.Web;
using System.Web.Optimization;

namespace DeCamaroong
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bootstrap").Include(
                     "~/Assets/Bootstrap/js/bootstrap.js"));

            //Moved bootstrap css to own style tag in the _layout page.  This is to remove it from the optimizations which was breaking the fonts and icons.
            bundles.Add(new StyleBundle("~/styles").IncludeDirectory("~/Assets", "*.css", true));


            bundles.Add(new ScriptBundle("~/ng").Include(
                        "~/Assets/ng/angular.min.js",
                        "~/Assets/ng/angular-route.min.js",
                        "~/Assets/ng/angular-cookies.min.js",
                        "~/Assets/ng/textAngular-rangy.min.js",
                        "~/Assets/ng/textAngular-sanitize.min.js",
                        "~/Assets/ng/textAngular.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/app").IncludeDirectory("~/Assets/app", "*.js", true));

            bundles.Add(new ScriptBundle("~/jquery").Include(
                        "~/Assets/jquery/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/misc").IncludeDirectory("~/Assets/misc", "*.js", true));
   
            bundles.Add(new ScriptBundle("~/custom").Include(
                "~/Assets/custom/hover-dropdown-menu.js",
                "~/Assets/custom/jquery.hover-dropdown-menu-addon.js",
                "~/Assets/custom/jquery.easing.1.3.js",
                "~/Assets/custom/jquery.sticky.js",
                "~/Assets/custom/bootstrapValidator.min.js",
                "~/Assets/rs-plugin/jquery.themepunch.tools.min.js",
                "~/Assets/rs-plugin/jquery.themepunch.revolution.min.js",
                "~/Assets/custom/revolution-custom.js",
                "~/Assets/custom/jquery.mixitup.min.js",
                "~/Assets/custom/jquery.appear.js",
                "~/Assets/custom/effect.js",
                "~/Assets/custom/owl.carousel.min.js",
                "~/Assets/custom/jquery.prettyPhoto.js",
                "~/Assets/custom/jquery.parallax-1.1.3.js",
                "~/Assets/custom/jquery.countTo.js",
                "~/Assets/custom/jquery.mb.YTPlayer.js",
                "~/Assets/custom/custom.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
