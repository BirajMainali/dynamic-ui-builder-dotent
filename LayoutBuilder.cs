namespace expr_dynamic_ui_builder;

public class LayoutBuilder(Layout layout) : ILayoutBuilder
{
    public ILayoutBuilder WithType(string type)
    {
        layout.Type = type;
        return this;
    }

    public ILayoutBuilder WithColumns(int columns)
    {
        layout.Columns = columns;
        return this;
    }
}