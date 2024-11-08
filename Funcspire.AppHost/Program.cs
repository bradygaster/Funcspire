var builder = DistributedApplication.CreateBuilder(args);

var storage = builder.AddAzureStorage("storage").RunAsEmulator();
var blobs = storage.AddBlobs("blobs");

var functions = builder.AddAzureFunctionsProject<Projects.Funcspire_Functions>("functions")
                       .WithReference(blobs);

var frontend = builder.AddProject<Projects.Frontend>("frontend")
                      .WithReference(functions)
                      .WithReference(blobs);

builder.Build().Run();
