// See https://aka.ms/new-console-template for more information
using DrugPrevention.GrpcService.DuyenCTT;
using Grpc.Net.Client;

Console.WriteLine("Hello, World!");


using var channel = GrpcChannel.ForAddress(" https://localhost:7177");

var client = new CourseEnrollmentDuyenCTTGRPC.CourseEnrollmentDuyenCTTGRPCClient(channel);

Console.WriteLine("==== Course Enrollment gRPC Client ====");

// CREATE
var createRequest = new CourseEnrollmentDuyenCTT
{
    UserId = 1,
    CourseId = 4,
    EnrolledAt = DateTime.UtcNow.ToString("o"),
    CompletedAt = "", // Optional
    Score = 88.5,
    CertificateUrl = "https://example.com/cert/501",
    IsCertified = true,
    EnrollmentSource = "gRPCConsole",
    Progress = 90
};

var createResponse = client.CreateAsync(createRequest);
int newId = createResponse.Value;
Console.WriteLine($"[CREATE] Created Enrollment ID: {newId}");

// GET BY ID
var getById = client.GetByIdAsync(new CourseEnrollmentDuyenCTTIdRequest
{
    CourseEnrollmentDuyenCTTId = newId
});
Console.WriteLine($"[READ] Got Enrollment: UserId={getById.UserId}, Score={getById.Score}");

// UPDATE
getById.Score = 91.75;
getById.Progress = 100;
var updateResponse = client.UpdateAsync(getById);
Console.WriteLine($"[UPDATE] Updated Enrollment ID: {updateResponse.Value}");

// GET ALL
var allResponse = client.GetAllAsync(new EmptyRequest());
Console.WriteLine($"[GET ALL] Total Enrollments: {allResponse.Items.Count}");
foreach (var item in allResponse.Items)
{
    Console.WriteLine($"  - ID: {item.EnrollmentId}, User: {item.UserId}, Score: {item.Score}");
}

// DELETE
var deleteResponse = client.DeleteAsync(new CourseEnrollmentDuyenCTTIdRequest
{
    CourseEnrollmentDuyenCTTId = newId
});
Console.WriteLine($"[DELETE] Deleted ID {newId}: Success = {deleteResponse.Value}");

Console.WriteLine("==== Done ====");