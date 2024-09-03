namespace expr_dynamic_ui_builder;

public interface IInputTypeBuilder
{
    IInputTypeBuilder WithType(InputTypeEnum type);
    IInputTypeBuilder WithMinLength(int minLength);
    IInputTypeBuilder WithMaxLength(int maxLength);
    IInputTypeBuilder WithFormat(string format);
    IInputTypeBuilder WithCulture(string culture);
    IInputTypeBuilder WithOptionEndpoint(string endpoint);
    InputTypeBuilder WithOptions(Action<List<OptionItem>> optionsConfig);
    IInputTypeBuilder WithDependsOn(Action<List<DependsOnItem>> dependsOnConfig);
}

public enum InputTypeEnum
{
    Text,
    Number,
    Date,
    Time,
    DateTime,
    Email,
    Phone,
    Url,
    Password,
    File,
    Checkbox,
    Radio,
    Select,
    MultiSelect,
    TextArea,
    Hidden,
    Button,
    Submit,
    Reset
}