namespace expr_dynamic_ui_builder;

public class FormConfigurationBuilder : IFormConfigurationBuilder
{
    private readonly FormConfiguration _formConfiguration = new FormConfiguration();

    public IFormConfigurationBuilder WithConfiguration(Action<IConfigurationBuilder> configAction)
    {
        var configBuilder = new ConfigurationBuilder(_formConfiguration.Configuration);
        configAction(configBuilder);
        return this;
    }

    public IFormConfigurationBuilder WithForm(Action<IFormBuilder> formAction)
    {
        var formBuilder = new FormBuilder(_formConfiguration.Form);
        formAction(formBuilder);
        return this;
    }

    public IFormConfigurationBuilder WithTable(Action<ITableBuilder> tableAction)
    {
        var tableBuilder = new TableBuilder(_formConfiguration.Table);
        tableAction(tableBuilder);
        return this;
    }

    public FormConfiguration Build()
    {
        return _formConfiguration;
    }
}

public class InputTypeBuilder(InputType inputType) : IInputTypeBuilder
{
    public IInputTypeBuilder WithType(InputTypeEnum type)
    {
        inputType.Type = type.ToString();
        return this;
    }


    public IInputTypeBuilder WithDependsOn(Action<List<DependsOnItem>> dependsOnConfig)
    {
        var dependsOn = new List<DependsOnItem>();
        dependsOnConfig(dependsOn);
        inputType.DependsOn = dependsOn;
        return this;
    }

    public InputTypeBuilder WithOptions(Action<List<OptionItem>> optionsConfig)
    {
        var options = new List<OptionItem>();
        optionsConfig(options);
        inputType.Options = options;
        return this;
    }

    public IInputTypeBuilder WithMinLength(int minLength)
    {
        inputType.MinLength = minLength;
        return this;
    }

    public IInputTypeBuilder WithMaxLength(int maxLength)
    {
        inputType.MaxLength = maxLength;
        return this;
    }

    public IInputTypeBuilder WithFormat(string format)
    {
        inputType.Format = format;
        return this;
    }

    public IInputTypeBuilder WithCulture(string culture)
    {
        inputType.Culture = culture;
        return this;
    }

    public IInputTypeBuilder WithOptionEndpoint(string endpoint)
    {
        inputType.OptionUrl = endpoint;
        return this;
    }
}

public class TableBuilder(List<Column> columns) : ITableBuilder
{
    public ITableBuilder AddColumn(Action<IColumnBuilder> columnAction)
    {
        var columnBuilder = new ColumnBuilder();
        columnAction(columnBuilder);
        columns.Add(columnBuilder.Build());
        return this;
    }
}

public class ColumnBuilder : IColumnBuilder
{
    private readonly Column _column = new Column();

    public IColumnBuilder WithName(string name)
    {
        _column.Name = name;
        return this;
    }

    public IColumnBuilder WithLabel(string label)
    {
        _column.Label = label;
        return this;
    }

    public IColumnBuilder WithType(string type)
    {
        _column.Type = type;
        return this;
    }

    public IColumnBuilder AddAction(Action<IActionBuilder> actionAction)
    {
        var actionBuilder = new ActionBuilder();
        actionAction(actionBuilder);
        _column.Actions.Add(actionBuilder.Build());
        return this;
    }

    public Column Build()
    {
        return _column;
    }
}

public class ActionBuilder : IActionBuilder
{
    private readonly Action _action = new Action();

    public IActionBuilder WithName(string name)
    {
        _action.Name = name;
        return this;
    }

    public IActionBuilder WithLabel(string label)
    {
        _action.Label = label;
        return this;
    }

    public IActionBuilder WithConfig(Action<IConfigBuilder> configAction)
    {
        var configBuilder = new ConfigBuilder(_action.Config);
        configAction(configBuilder);
        return this;
    }

    public Action Build()
    {
        return _action;
    }
}

public class ConfigBuilder(Config config) : IConfigBuilder
{
    public IConfigBuilder WithType(string type)
    {
        config.Type = type;
        return this;
    }

    public IConfigBuilder WithTitle(string title)
    {
        config.Title = title;
        return this;
    }

    public IConfigBuilder WithEndpoint(string endpoint)
    {
        config.Endpoint = endpoint;
        return this;
    }

    public IConfigBuilder WithRoute(string route)
    {
        config.Route = route;
        return this;
    }

    public IConfigBuilder WithMethod(string method)
    {
        config.Method = method;
        return this;
    }

    public IConfigBuilder WithMessage(string message)
    {
        config.Message = message;
        return this;
    }
}