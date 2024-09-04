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
            .WithEndpoint("/api/personal-information")
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
                        .WithConfiguration(typeBuilder =>
                        {
                            typeBuilder
                                .WithType(InputTypeEnum.Text)
                                .WithMinLength(1)
                                .WithMaxLength(100);
                        })
                        .IsRequired(true)
                        .WithValidationPattern("^[a-zA-Z]+$");
                })
                .AddInput(fieldBuilder =>
                {
                    fieldBuilder.WithName("GenderId")
                        .WithLabel("Gender")
                        .WithConfiguration(typeBuilder =>
                        {
                            typeBuilder.WithType(InputTypeEnum.Select);
                            typeBuilder.WithOptions(optionItems =>
                            {
                                optionItems.AddRange(new List<OptionItem>
                                {
                                    new()
                                    {
                                        Id = 1,
                                        Name = "Male"
                                    },
                                    new()
                                    {
                                        Id = 2,
                                        Name = "Female"
                                    }
                                });
                            });
                        });
                })
                .AddInput(fieldBuilder =>
                {
                    fieldBuilder
                        .WithName("DistrictId")
                        .WithLabel("District")
                        .WithConfiguration(x =>
                        {
                            x.WithType(InputTypeEnum.Select);
                            x.WithOptionEndpoint("/api/districts");
                        });
                })
                .AddInput(x =>
                {
                    x.WithLabel("Municipality")
                        .WithName("MunicipalityId")
                        .WithConfiguration(typeBuilder =>
                        {
                            typeBuilder
                                .WithType(InputTypeEnum.Select)
                                .WithDependsOn(list =>
                                {
                                    list.Add(new DependsOnItem()
                                    {
                                        Name = "DistrictId",
                                    });
                                })
                                .WithOptionEndpoint("/api/municipalities?districtId={DistrictId}");
                        });
                })
                .AddInput(inputFieldBuilder =>
                {
                    inputFieldBuilder
                        .WithName("dateOfBirth")
                        .WithLabel("Date of Birth")
                        .WithConfiguration(typeBuilder => typeBuilder
                            .WithType(InputTypeEnum.DateTime)
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
                        .WithConfiguration(typeBuilder => typeBuilder
                            .WithType(InputTypeEnum.Number))
                        .WithComputationEndpoint("/api/age");
                });
        }).Build();

    return formConfiguration;
}).WithOpenApi();
app.Run();