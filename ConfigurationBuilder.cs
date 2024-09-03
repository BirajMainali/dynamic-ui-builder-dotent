namespace expr_dynamic_ui_builder;

public class ConfigurationBuilder(Configuration configuration) : IConfigurationBuilder
{
    public IConfigurationBuilder WithTitle(string title)
    {
        configuration.Title = title;
        return this;
    }

    public IConfigurationBuilder WithDescription(string description)
    {
        configuration.Description = description;
        return this;
    }

    public IConfigurationBuilder WithHttpMethod(string method)
    {
        configuration.HttpMethod = method;
        return this;
    }

    public IConfigurationBuilder WithEndpoint(string endpoint)
    {
        configuration.ApiEndpoint = endpoint;
        return this;
    }

    public IConfigurationBuilder WithRefreshOnSubmission(bool refresh)
    {
        configuration.RefreshOnSubmission = refresh;
        return this;
    }

    public IConfigurationBuilder WithLayout(Action<ILayoutBuilder> layoutAction)
    {
        var layoutBuilder = new LayoutBuilder(configuration.Layout);
        layoutAction(layoutBuilder);
        return this;
    }
}