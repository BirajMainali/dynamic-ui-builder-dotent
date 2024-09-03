namespace expr_dynamic_ui_builder;

public interface IColumnBuilder
{
    IColumnBuilder WithName(string name);
    IColumnBuilder WithLabel(string label);
    IColumnBuilder WithType(string type);
    IColumnBuilder AddAction(Action<IActionBuilder> actionAction);
}