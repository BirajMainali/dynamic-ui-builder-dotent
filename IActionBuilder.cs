namespace expr_dynamic_ui_builder;

public interface IActionBuilder
{
    IActionBuilder WithName(string name);
    IActionBuilder WithLabel(string label);
    IActionBuilder WithConfig(Action<IConfigBuilder> configAction);
}