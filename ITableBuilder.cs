namespace expr_dynamic_ui_builder;

public interface ITableBuilder
{
    ITableBuilder AddColumn(Action<IColumnBuilder> columnAction);
}