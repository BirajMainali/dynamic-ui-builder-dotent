using expr_dynamic_ui_builder;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/person-form", () =>
{
    var formConfiguration = new FormConfigurationBuilder()
        .WithConfiguration(configBuilder => configBuilder
            .WithTitle("Personal Information")
            .WithDescription("Form to collect personal information of the user.")
            .WithHttpMethod("POST")
            .WithApiEndpoint("/api/personal-information")
            .WithRefreshOnSubmission(true)
            .WithLayout(layoutBuilder =>
            {
                layoutBuilder
                    .WithType("vertical")
                    .WithColumns(1);
            }))
        .WithForm(formBuilder =>
        {
            formBuilder
                .AddInput(inputFieldBuilder =>
                {
                    inputFieldBuilder
                        .WithName("firstName")
                        .WithLabel("First Name")
                        .WithType(typeBuilder => typeBuilder
                            .WithType("string")
                            .WithMinLength(1)
                            .WithMaxLength(100))
                        .IsRequired(true)
                        .WithValidationPattern("^[a-zA-Z]+$");
                })
                .AddInput(inputFieldBuilder =>
                {
                    inputFieldBuilder
                        .WithName("dateOfBirth")
                        .WithLabel("Date of Birth")
                        .WithType(typeBuilder => typeBuilder
                            .WithType("date")
                            .WithFormat("YYYY-MM-DD")
                            .WithCulture("en-US"))
                        .IsRequired(true)
                        .WithValidationPattern("^[0-9]{4}-[0-9]{2}-[0-9]{2}$");
                })
                .AddInput(inputFieldBuilder =>
                {
                    inputFieldBuilder
                        .WithName("currentAge")
                        .WithLabel("Current Age")
                        .WithType(typeBuilder => typeBuilder
                            .WithType("computed"))
                        .WithComputationEndpoint("/api/age");
                });
        })
        .WithTable(tableBuilder =>
        {
            tableBuilder
                .AddColumn(columnBuilder => columnBuilder
                    .WithName("Id")
                    .WithLabel("Id")
                    .WithType("hidden"))
                .AddColumn(columnBuilder => columnBuilder
                    .WithName("firstName")
                    .WithLabel("First Name")
                    .WithType("string"))
                .AddColumn(columnBuilder => columnBuilder
                    .WithName("dateOfBirth")
                    .WithLabel("Date of Birth")
                    .WithType("date"))
                .AddColumn(columnBuilder => columnBuilder
                    .WithName("currentAge")
                    .WithLabel("Current Age")
                    .WithType("number"))
                .AddColumn(columnBuilder => columnBuilder
                    .WithName("actions")
                    .WithLabel("Actions")
                    .WithType("actions")
                    .AddAction(actionBuilder =>
                    {
                        actionBuilder
                            .WithName("edit")
                            .WithLabel("Edit")
                            .WithConfig(configBuilder =>
                            {
                                configBuilder
                                    .WithType("modal")
                                    .WithTitle("Edit Record")
                                    .WithRoute("/person-form/edit/{Id}")
                                    .WithMethod("PUT");
                            });
                    })
                    .AddAction(actionBuilder =>
                    {
                        actionBuilder
                            .WithName("delete")
                            .WithLabel("Delete")
                            .WithConfig(configBuilder =>
                            {
                                configBuilder
                                    .WithType("modal")
                                    .WithTitle("Delete Record")
                                    .WithMessage("Are you sure you want to delete this record?")
                                    .WithEndpoint("/api/personal-information")
                                    .WithMethod("DELETE");
                            });
                    }));
        }).Build();

    return formConfiguration;
}).WithOpenApi();
app.Run();