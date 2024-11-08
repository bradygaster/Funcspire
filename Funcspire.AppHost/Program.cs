var builder = DistributedApplication.CreateBuilder(args);

var functions = builder.AddAzureFunctionsProject<Projects.Funcspire_Functions>("functions");

var frontend = builder.AddProject<Projects.Frontend>("frontend")
                      .WithReference(functions);

builder.Build().Run();
