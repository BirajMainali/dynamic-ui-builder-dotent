namespace expr_dynamic_ui_builder;

public class InputFieldBuilder : IInputFieldBuilder
{
    private readonly InputField _inputField = new InputField();

    public IInputFieldBuilder WithName(string name)
    {
        _inputField.Name = name;
        return this;
    }

    public IInputFieldBuilder WithLabel(string label)
    {
        _inputField.Label = label;
        return this;
    }
    
    
    public IInputFieldBuilder WithConfiguration(Action<IInputTypeBuilder> typeAction)
    {
        var typeBuilder = new InputTypeBuilder(_inputField.Type);
        typeAction(typeBuilder);
        return this;
    }

    public IInputFieldBuilder IsRequired(bool required)
    {
        _inputField.Required = required;
        return this;
    }

    public IInputFieldBuilder WithValidationPattern(string pattern)
    {
        _inputField.ValidationPattern = pattern;
        return this;
    }

    public IInputFieldBuilder WithComputationEndpoint(string endpoint)
    {
        _inputField.ComputationEndpoint = endpoint;
        return this;
    }

    public InputField Build()
    {
        return _inputField;
    }
}