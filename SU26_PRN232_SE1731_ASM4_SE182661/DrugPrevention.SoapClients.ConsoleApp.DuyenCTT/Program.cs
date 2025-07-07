using System;
using System.ServiceModel;
using System.Threading.Tasks;
using AccountServiceReference;
using SoapServiceReference;

class Program
{
    static async Task Main(string[] args)
    {
        // Create SOAP binding
        var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport); // For HTTPS

        // Account service endpoint and client
        var accountEndpoint = new EndpointAddress("https://localhost:7287/AccountSoapService.asmx");
        var accountClient = new AccountSoapServiceClient(binding, accountEndpoint);

        // Course enrollment service endpoint and client
        var enrollmentEndpoint = new EndpointAddress("https://localhost:7287/CourseEnrollmentDuyenCTTSoapService.asmx");
        var enrollmentClient = new CourseEnrollmentDuyenCTTSoapServiceClient(binding, enrollmentEndpoint);

        try
        {
            //Console.WriteLine("Login required. Please enter your credentials.");
            //Console.Write("Username: ");
            //var username = Console.ReadLine();
            //Console.Write("Password: ");
            //var password = Console.ReadLine();

            //// Call GetByCredentialsAsync to simulate login
            //var user = await accountClient.GetByCredentialsAsync(username, password);

            //if (user == null || !user.IsActive)
            //{
            //    Console.WriteLine("Login failed or user is inactive.");
            //    return;
            //}

            //Console.WriteLine($"Login successful! Welcome, {user.FullName} (UserID: {user.UserAccountId})");
            //// Simulate token as user object (since no real token is provided)
            //// Now call GetAllAsync for users
            //var users = await accountClient.GetAllAsync();
            //if (users == null || users.Length == 0)
            //{
            //    Console.WriteLine("No user accounts found.");
            //}
            //else
            //{
            //    Console.WriteLine($"Total User Accounts: {users.Length}");
            //    foreach (var u in users)
            //    {
            //        Console.WriteLine($"ID: {u.UserAccountId}");
            //        Console.WriteLine($"Username: {u.UserName}");
            //        Console.WriteLine($"Full Name: {u.FullName}");
            //        Console.WriteLine($"Email: {u.Email}");
            //        Console.WriteLine($"IsActive: {u.IsActive}");
            //        Console.WriteLine("--------------------------");
            //    }
            //}

            // Now call GetAllAsync for course enrollments (page 1, size 5)
            var enrollmentsResult = await enrollmentClient.GetAllAsync(1, 5);
         Console.WriteLine($"[DEBUG] enrollmentsResult is null? {enrollmentsResult == null}");
Console.WriteLine($"[DEBUG] Items is null? {enrollmentsResult?.Items == null}");
Console.WriteLine($"[DEBUG] Items count: {enrollmentsResult?.Items?.Count}");
            if (enrollmentsResult == null || enrollmentsResult.Items == null)
            {
                Console.WriteLine("No course enrollments found.");
            }
            else
            {
                Console.WriteLine($"Total Course Enrollments: {enrollmentsResult.TotalItems}");
                foreach (var item in enrollmentsResult.Items)
                {
                    Console.WriteLine($"ID: {item.EnrollmentDuyenCttid}");
                    Console.WriteLine($"Enrollment Source: {item.EnrollmentSource}");
                    Console.WriteLine($"Score: {item.Score}");
                    Console.WriteLine($"Certificate URL: {item.CertificateUrl}");
                    Console.WriteLine("--------------------------");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error calling SOAP service:");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            await accountClient.CloseAsync();
            await enrollmentClient.CloseAsync();
        }

        Console.WriteLine("Done. Press any key to exit.");
        Console.ReadKey();
    }
}
