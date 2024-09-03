namespace expr_dynamic_ui_builder;

public interface IInputFieldBuilder
{
    IInputFieldBuilder WithName(string name);
    IInputFieldBuilder WithLabel(string label);
    IInputFieldBuilder WithConfiguration(Action<IInputTypeBuilder> typeAction);
    IInputFieldBuilder IsRequired(bool required);
    IInputFieldBuilder WithValidationPattern(string pattern);
    IInputFieldBuilder WithComputationEndpoint(string endpoint);
}