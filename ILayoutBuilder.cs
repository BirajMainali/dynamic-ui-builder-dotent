namespace expr_dynamic_ui_builder;

public interface ILayoutBuilder
{
    ILayoutBuilder WithType(string type);
    ILayoutBuilder WithColumns(int columns);
}