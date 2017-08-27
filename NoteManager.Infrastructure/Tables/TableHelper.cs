using System.Web;
using System.Web.Mvc;
using NoteManager.Infrastructure.Settings;

namespace NoteManager.Infrastructure.Tables
{
    public static class TableHelper
    {
        public static IHtmlString InputFilterName(this HtmlHelper helper)
        {
            var htmlString = string.Empty;
            htmlString += "<div class='col-lg-3 container-left'>";
            htmlString += "<input type='text' id='Name' class='form-control' data-role='none' placeholder='Nombre' autocomplete='off' />";
            htmlString += "</div>";
            return new HtmlString(htmlString);
        }

        public static IHtmlString ButtonFilter(this HtmlHelper helper)
        {
            var htmlString = string.Empty;
            htmlString += "<div class='col-lg-1 container-left'>";
            htmlString += "<button type='button' class='btn btn-info btn-block btnFilter'><i class='fa fa-filter'></i> Filtrar</button>";
            htmlString += "</div>";
            return new HtmlString(htmlString);
        }

        public static IHtmlString ButtonExport(this HtmlHelper helper)
        {
            var htmlString = string.Empty;
            htmlString += "<div class='col-lg-1 container-left'>";
            htmlString += "<button type='button' class='btn btn-info btn-block btnExport'><i class='fa fa-file-excel-o'></i> Exportar</button>";
            htmlString += "</div>";
            return new HtmlString(htmlString);
        }

        public static IHtmlString ButtonHistory(this HtmlHelper helper)
        {
            var htmlString = string.Empty;
            htmlString += "<div class='col-lg-1 container-right'>";
            htmlString += "<button type='button' class='btn btn-primary btn-block btnHistory'><i class='fa fa-bar-chart'></i> Historial</button>";
            htmlString += "</div>";
            return new HtmlString(htmlString);
        }

        public static IHtmlString ButtonDeleteMany(this HtmlHelper helper)
        {
            var htmlString = string.Empty;
            htmlString += "<div class='col-lg-1 container-right'>";
            htmlString += "<button type='button' class='btn btnDeleteMany btn-danger btn-block' disabled><i class='fa fa-trash-o'></i> Eliminar</button>";
            htmlString += "</div>";
            return new HtmlString(htmlString);
        }

        public static IHtmlString ButtonNew(this HtmlHelper helper)
        {
            var controller = helper.ViewContext.RouteData.GetRequiredString("controller");
            var href = string.Format("{0}{1}/New", RootResolver.Resolver, controller);
            var htmlString = string.Empty;
            htmlString += "<div class='col-lg-1 container-right'>";
            htmlString += "<a class='btn btn-primary btn-block' href='" + href + "'><i class='fa fa-plus'></i> Nuevo</a>";
            htmlString += "</div>";
            return new HtmlString(htmlString);
        }

        public static IHtmlString ButtonAssign(this HtmlHelper helper)
        {
            var htmlString = string.Empty;
            htmlString += "<div class='col-lg-1 container-right'>";
            htmlString += "<a class='btn btn-primary btn-block' href='#'>Asignar</a>";
            htmlString += "</div>";
            return new HtmlString(htmlString);
        }

        public static IHtmlString Table(this HtmlHelper helper)
        {
            var htmlString = string.Empty;
            htmlString += "<table id='Table'></table>";
            htmlString += "<div id='TableLoading' class='col-lg-12 table-loadding'>";
            htmlString += "<i class='fa fa-cog fa-spin'></i><span id='TableLoadingText'>Generando tabla...</span>";
            htmlString += "</div>";
            return new HtmlString(htmlString);
        }
    }
}