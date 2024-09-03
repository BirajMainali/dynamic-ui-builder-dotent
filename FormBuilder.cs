namespace expr_dynamic_ui_builder;

public class FormBuilder(List<InputField> inputs) : IFormBuilder
{
    public IFormBuilder AddInput(Action<IInputFieldBuilder> inputAction)
    {
        var inputFieldBuilder = new InputFieldBuilder();
        inputAction(inputFieldBuilder);
        inputs.Add(inputFieldBuilder.Build());
        return this;
    }
}