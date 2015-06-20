namespace Bloggable.Web.Infrastructure.HtmlHelpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;

    public static class KendoGridHelpers
    {
        public static GridBuilder<T> KendoGrid<T, TController>(
                this HtmlHelper helper,
                Expression<Func<T, object>> modelIdExpression,
                Expression<Action<TController>> readAction,
                Expression<Action<TController>> createAction = null,
                Expression<Action<TController>> updateAction = null,
                Expression<Action<TController>> destroyAction = null,
                string gridId = null,
                Action<GridColumnFactory<T>> columns = null,
                Action<GridToolBarCommandFactory<T>> toolbar = null,
                string editorTemplateName = null,
                string clientDetailTemplateId = null,
                string clientRowTemplate = null,
                string clientAltRowTemplate = null)
            where T : class
            where TController : Controller
        {
            var grid = helper.Kendo().Grid<T>()
                .Name(gridId ?? "data-grid")
                .Columns(columns ?? GetDefaultColumns<T, TController>(updateAction, destroyAction))
                .ColumnMenu()
                .Pageable(page => page.Refresh(true))
                .Pageable(x => x.Refresh(true))
                .Sortable(x => x.Enabled(true).AllowUnsort(false))
                .Filterable(x => x.Enabled(true))
                .Reorderable(x => x.Columns(true))
                .Resizable(x => x.Columns(true))
                .ToolBar(toolbar ?? GetDefaultToolbar<T, TController>(createAction))
                .Editable(editable =>
                {
                    editable.Mode(GridEditMode.PopUp);
                    editable.DisplayDeleteConfirmation("Do you really want to delete this item?");
                    if (editorTemplateName != null)
                    {
                        editable.TemplateName(editorTemplateName);
                    }
                })
                .DataSource(dataSource => SetDataSource(dataSource, modelIdExpression, readAction, createAction, updateAction, destroyAction));

            if (clientDetailTemplateId != null)
            {
                grid = grid.ClientDetailTemplateId(clientDetailTemplateId);
            }

            if (clientRowTemplate != null)
            {
                grid = grid.ClientRowTemplate(clientRowTemplate);
            }

            if (clientAltRowTemplate != null)
            {
                grid = grid.ClientRowTemplate(clientAltRowTemplate);
            }

            return grid;
        }

        private static Action<GridColumnFactory<T>> GetDefaultColumns<T, TController>(
                Expression<Action<TController>> updateAction,
                Expression<Action<TController>> destroyAction)
            where T : class
            where TController : Controller
        {
            return cols =>
            {
                cols.AutoGenerate(true);
                if (updateAction != null)
                {
                    cols.Command(c => c.Edit());
                }

                if (destroyAction != null)
                {
                    cols.Command(c => c.Destroy());
                }
            };
        }

        private static Action<GridToolBarCommandFactory<T>> GetDefaultToolbar<T, TController>(
                Expression<Action<TController>> createAction)
            where T : class
            where TController : Controller
        {
            if (createAction != null)
            {
                return toolbar => toolbar.Create().Text("Create");
            }

            return null;
        }

        private static void SetDataSource<T, TController>(
                DataSourceBuilder<T> dataSource,
                Expression<Func<T, object>> modelIdExpression,
                Expression<Action<TController>> readAction,
                Expression<Action<TController>> createAction,
                Expression<Action<TController>> updateAction,
                Expression<Action<TController>> destroyAction)
            where T : class
            where TController : Controller
        {
            var dataSourceBuilder = dataSource.Ajax();
            dataSourceBuilder.Model(m => m.Id(modelIdExpression));
            dataSourceBuilder.Read(read => read.Action(readAction));

            if (createAction != null)
            {
                dataSourceBuilder.Create(create => create.Action(createAction));
            }

            if (updateAction != null)
            {
                dataSourceBuilder.Update(update => update.Action(updateAction));
            }

            if (destroyAction != null)
            {
                dataSourceBuilder.Destroy(destroy => destroy.Action(destroyAction));
            }
        }
    }
}
