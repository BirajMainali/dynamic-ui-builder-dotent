namespace expr_dynamic_ui_builder;

public interface IConfigBuilder
{
    IConfigBuilder WithType(string type);
    IConfigBuilder WithTitle(string title);
    IConfigBuilder WithEndpoint(string endpoint);
    IConfigBuilder WithRoute(string route);
    IConfigBuilder WithMethod(string method);
    IConfigBuilder WithMessage(string message);
}