namespace Bloggable.Web.Infrastructure.HtmlHelpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;

    public static class KendoGridHelpers
    {
        public static GridBuilder<T> KendoGrid<T>(
                this HtmlHelper helper,
                Expression<Func<T, object>> modelIdExpression,
                Action<CrudOperationBuilder> readOperation,
                Action<CrudOperationBuilder> createOperation = null,
                Action<CrudOperationBuilder> updateOperation = null,
                Action<CrudOperationBuilder> destroyOperation = null,
                string gridId = null,
                Action<GridColumnFactory<T>> columns = null,
                Action<GridToolBarCommandFactory<T>> toolbar = null,
                string editorTemplateName = null)
            where T : class
        {
            var grid = helper.Kendo().Grid<T>()
                .Name(gridId ?? "data-grid")
                .Columns(columns ?? GetDefaultColumns<T>(updateOperation, destroyOperation))
                .ColumnMenu()
                .Pageable(page => page.Refresh(true))
                .Pageable(x => x.Refresh(true))
                .Sortable(x => x.Enabled(true).AllowUnsort(false))
                .Filterable(x => x.Enabled(true))
                .Reorderable(x => x.Columns(true))
                .Resizable(x => x.Columns(true))
                .ToolBar(toolbar ?? GetDefaultToolbar<T>(createOperation))
                .Editable(GetEditingSettings<T>(editorTemplateName))
                .DataSource(GetDataSource(modelIdExpression, readOperation, createOperation, updateOperation, destroyOperation));

            return grid;
        }

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
                string editorTemplateName = null)
            where T : class
            where TController : Controller
        {
            Action<CrudOperationBuilder> createOperation = null;
            Action<CrudOperationBuilder> readOperation = read => read.Action(readAction);
            Action<CrudOperationBuilder> updateOperation = null;
            Action<CrudOperationBuilder> destroyOperation = null;

            if (createAction != null)
            {
                createOperation = create => create.Action(createAction);
            }

            if (updateAction != null)
            {
                updateOperation = update => update.Action(updateAction);
            }

            if (destroyAction != null)
            {
                destroyOperation = destroy => destroy.Action(destroyAction);
            }

            return KendoGrid(
                helper,
                modelIdExpression,
                readOperation,
                createOperation,
                updateOperation,
                destroyOperation,
                gridId,
                columns,
                toolbar,
                editorTemplateName);
        }

        private static Action<GridColumnFactory<T>> GetDefaultColumns<T>(
                Action<CrudOperationBuilder> updateOperation,
                Action<CrudOperationBuilder> destroyOperation)
            where T : class => 
        cols =>
        {
            cols.AutoGenerate(true);
            if (updateOperation != null)
            {
                cols.Command(c => c.Edit());
            }

            if (destroyOperation != null)
            {
                cols.Command(c => c.Destroy());
            }
        };

        private static Action<GridToolBarCommandFactory<T>> GetDefaultToolbar<T>(Action<CrudOperationBuilder> createAction)
            where T : class
        {
            if (createAction != null)
            {
                return toolbar => toolbar.Create().Text("Create");
            }

            return toolbar => { };
        }

        private static Action<GridEditingSettingsBuilder<T>> GetEditingSettings<T>(string editorTemplateName)
            where T : class => 
        editable =>
        {
            editable.Mode(GridEditMode.PopUp);
            editable.DisplayDeleteConfirmation("Do you really want to delete this item?");

            if (editorTemplateName != null)
            {
                editable.TemplateName(editorTemplateName);
            }
        };

        private static Action<DataSourceBuilder<T>> GetDataSource<T>(
                Expression<Func<T, object>> modelIdExpression,
                Action<CrudOperationBuilder> readOperation,
                Action<CrudOperationBuilder> createOperation,
                Action<CrudOperationBuilder> updateOperation,
                Action<CrudOperationBuilder> destroyOperation)
            where T : class => 
        dataSource =>
        {
            var dataSourceBuilder = dataSource.Ajax();
            dataSourceBuilder.Model(m => m.Id(modelIdExpression));
            dataSourceBuilder.Read(readOperation);

            if (createOperation != null)
            {
                dataSourceBuilder.Create(createOperation);
            }

            if (updateOperation != null)
            {
                dataSourceBuilder.Update(updateOperation);
            }

            if (destroyOperation != null)
            {
                dataSourceBuilder.Destroy(destroyOperation);
            }
        };
    }
}
