using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace eUseControl.web
{
     public static class BundleConfig
     {
          public static void RegisterBundles(BundleCollection bundles)
          {
               // Bootstrap4 style
               bundles.Add(new StyleBundle("~/bundles/boostrap4/css").Include(
                         "~/styles/bootstrap4/boostrap.min.css", new CssRewriteUrlTransform()));

               // Cateogires responsive.css
               bundles.Add(new StyleBundle("~/bundles/categories_responsive/css").Include(
                         "~/styles/categories_responsive.css", new CssRewriteUrlTransform()));

               // Cateogires styles.css
               bundles.Add(new StyleBundle("~/bundles/categories_styles/css").Include(
                         "~/styles/categories_styles.css", new CssRewriteUrlTransform()));

               // Contact responsive.css
               bundles.Add(new StyleBundle("~/bundles/contact_responsive/css").Include(
                         "~/styles/contact_responsive.css", new CssRewriteUrlTransform()));

               // Contact styles.css
               bundles.Add(new StyleBundle("~/bundles/contact_styles/css").Include(
                         "~/styles/contact_styles.css", new CssRewriteUrlTransform()));

               // Main styles.css
               bundles.Add(new StyleBundle("~/bundles/main_styles/css").Include(
                         "~/styles/main_styles.css", new CssRewriteUrlTransform()));

               // Responsive.css
               bundles.Add(new StyleBundle("~/bundles/responsive/css").Include(
                         "~/styles/responsive.css", new CssRewriteUrlTransform()));

               // Single responsive.css
               bundles.Add(new StyleBundle("~/bundles/single_responsive/css").Include(
                         "~/styles/single_responsive.css", new CssRewriteUrlTransform()));

               // Single styles.css
               bundles.Add(new StyleBundle("~/bundles/single_styles/css").Include(
                         "~/styles/single_styles.css", new CssRewriteUrlTransform()));

               // Font awesome.css
               bundles.Add(new StyleBundle("~/bundles/font_awesome/css").Include(
                         "~/plugins/font-awesome-4.7.0/css/font-awesome.css", new CssRewriteUrlTransform()));

               //Font awesome min.css
               bundles.Add(new StyleBundle("~/bundles/font_awesome_min/css").Include(
                         "~/plugins/font-awesome-4.7.0/css/font-awesome.min.css", new CssRewriteUrlTransform()));

               //jQuery_ui.css
               bundles.Add(new StyleBundle("~/bundles/jquery-ui/css").Include(
                         "~/plugins/jquery-ui-1.12.1.custom/jquery-ui.css", new CssRewriteUrlTransform()));

               //Animate.css
               bundles.Add(new StyleBundle("~/bundles/animate/css").Include(
                         "~/plugins/OwlCarousel2-2.2.1/animate.css", new CssRewriteUrlTransform()));

               //Owl.carousel.css
               bundles.Add(new StyleBundle("~/bundles/owl.carousel/css").Include(
                         "~/plugins/OwlCarousel2-2.2.1/owl.carousel.css", new CssRewriteUrlTransform()));

               //Owl.theme.deafault.css
               bundles.Add(new StyleBundle("~/bundles/owl.theme.default/css").Include(
                         "~/plugins/OwlCarousel2-2.2.1/owl.theme.default.css", new CssRewriteUrlTransform()));


               //Themify-icons.css
               bundles.Add(new StyleBundle("~/bundles/themify.icons/css").Include(
                         "~/plugins/themify-icons/themify-icons.css", new CssRewriteUrlTransform()));

               //----JS---//

               // Bootstrap min.js
               bundles.Add(new ScriptBundle("~/bundles/bootstrap.min/js").Include(
                         "~/styles/bootstrap4/bootstrap.min.js"));

               // Popper.js
               bundles.Add(new ScriptBundle("~/bundles/popper/js").Include(
                         "~/styles/bootstrap4/popper.js"));

               // Categories_custom.js
               bundles.Add(new ScriptBundle("~/bundles/categories_custom/js").Include(
                         "~/js/categories_custom.js"));

               // Contact_custom.js
               bundles.Add(new ScriptBundle("~/bundles/contact_custom/js").Include(
                         "~/js/contact_custom.js"));

               // custom.js
               bundles.Add(new ScriptBundle("~/bundles/custom/js").Include(
                         "~/js/custom.js"));

               //jQuery
               bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                         "~/js/jquery-3.2.1.min.js"));

               // Single_custom.js
               bundles.Add(new ScriptBundle("~/bundles/single_custom/js").Include(
                         "~/js/single_custom.js"));

               // Easing.js
               bundles.Add(new ScriptBundle("~/bundles/easing/js").Include(
                         "~/plugins/easing/easing.js"));

               // isotope.js
               bundles.Add(new ScriptBundle("~/bundles/isotope.pkgd.min/js").Include(
                         "~/plugins/Isotope/isotope.pkgd.min.js"));

               // jQuery ui.js
               bundles.Add(new ScriptBundle("~/bundles/jquery-ui/js").Include(
                         "~/plugins/jquery-ui-1.12.1.custom/jquery-ui.js"));

               // Owl.carousel.js
               bundles.Add(new ScriptBundle("~/bundles/owl.carousel/js").Include(
                         "~/plugins/OwlCarousel2-2.2.1/owl.carousel.js"));

          }
     }
}