namespace expr_dynamic_ui_builder;

public class FormConfiguration
{
    public Configuration Configuration { get; set; } = new Configuration();
    public List<InputField> Form { get; set; } = new List<InputField>();
    public List<Column> Table { get; set; } = new List<Column>();
}

public class Configuration
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string HttpMethod { get; set; }
    public string ApiEndpoint { get; set; }
    public bool RefreshOnSubmission { get; set; }
    public Layout Layout { get; set; } = new Layout();
}

public class Layout
{
    public string Type { get; set; }
    public int Columns { get; set; }
}

public class InputField
{
    public string Name { get; set; }
    public string Label { get; set; }
    public InputType Type { get; set; } = new InputType();
    public bool Required { get; set; }
    public string ValidationPattern { get; set; }
    public string ComputationEndpoint { get; set; }
}

public class InputType
{
    public string Type { get; set; }
    public int? MinLength { get; set; }
    public int? MaxLength { get; set; }
    public string Format { get; set; }
    public string Culture { get; set; }
    public string OptionUrl { get; set; }
    public List<OptionItem> Options { get; set; } = new List<OptionItem>();
    public List<DependsOnItem> DependsOn { get; set; } = new List<DependsOnItem>();
}

public class OptionItem
{
    public object Id { get; set; }
    public string Name { get; set; }
}

public class DependsOnItem
{
    public string Name { get; set; }
}

public class Column
{
    public string Name { get; set; }
    public string Label { get; set; }
    public string Type { get; set; }
    public List<Action> Actions { get; set; } = new List<Action>();
}

public class Action
{
    public string Name { get; set; }
    public string Label { get; set; }
    public Config Config { get; set; } = new Config();
}

public class Config
{
    public string Type { get; set; }
    public string Title { get; set; }
    public string Endpoint { get; set; }
    public string Method { get; set; }
    public string Message { get; set; }
    public string Route { get; set; }
}