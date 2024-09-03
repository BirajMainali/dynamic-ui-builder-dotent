namespace expr_dynamic_ui_builder;

public interface IFormConfigurationBuilder
{
    IFormConfigurationBuilder WithConfiguration(Action<IConfigurationBuilder> configAction);
    IFormConfigurationBuilder WithForm(Action<IFormBuilder> formAction);
    IFormConfigurationBuilder WithTable(Action<ITableBuilder> tableAction);
    FormConfiguration Build();
}