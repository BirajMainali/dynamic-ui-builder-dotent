namespace expr_dynamic_ui_builder;

public interface IConfigurationBuilder
{
    IConfigurationBuilder WithTitle(string title);
    IConfigurationBuilder WithDescription(string description);
    IConfigurationBuilder WithHttpMethod(string method);
    IConfigurationBuilder WithApiEndpoint(string endpoint);
    IConfigurationBuilder WithRefreshOnSubmission(bool refresh);
    IConfigurationBuilder WithLayout(Action<ILayoutBuilder> layoutAction);
}