namespace expr_dynamic_ui_builder;

public interface IInputTypeBuilder
{
    IInputTypeBuilder WithType(string type);
    IInputTypeBuilder WithMinLength(int minLength);
    IInputTypeBuilder WithMaxLength(int maxLength);
    IInputTypeBuilder WithFormat(string format);
    IInputTypeBuilder WithCulture(string culture);
}