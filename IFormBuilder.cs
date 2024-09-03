namespace expr_dynamic_ui_builder;

public interface IFormBuilder
{
    IFormBuilder AddInput(Action<IInputFieldBuilder> inputAction);
}