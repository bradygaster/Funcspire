var builder = DistributedApplication.CreateBuilder(args);

var functions = builder.AddAzureFunctionsProject<Projects.Funcspire>("functions");

var frontend = builder.AddProject<Projects.Frontend>("frontend")
                      .WithReference(functions);

builder.Build().Run();
