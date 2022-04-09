// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using ManagementService.gRPCClient;

Console.WriteLine("Hello, World!");

var channel = GrpcChannel.ForAddress("http://localhost:5192");
var client = new Greeter.GreeterClient(channel);


client.SayHello(new HelloRequest { Name = "sssssssss" });
