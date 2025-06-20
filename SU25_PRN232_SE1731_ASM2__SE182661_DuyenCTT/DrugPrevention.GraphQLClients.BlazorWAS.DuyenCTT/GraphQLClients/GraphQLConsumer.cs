using DrugPrevention.GraphQLClients.BlazorWAS.DuyenCTT.ModelExtensions;
using DrugPrevention.GraphQLClients.BlazorWAS.DuyenCTT.Models;
using DrugPrevention.GraphQLClients.BlazorWAS.DuyenCTT.Response;
using GraphQL;
using GraphQL.Client.Abstractions;

namespace DrugPrevention.GraphQLClients.BlazorWAS.DuyenCTT.GraphQLClients
{
    public class GraphQLConsumer
    {
        private readonly IGraphQLClient _graphQLClient;

        public GraphQLConsumer(IGraphQLClient graphQLClient)
        {
            _graphQLClient = graphQLClient ?? throw new ArgumentNullException(nameof(graphQLClient), "GraphQL client cannot be null");
        }

        //getAll method
        public async Task<PaginationResult<CourseEnrollmentDuyenCtt>> GetAllAsync(int page, int size)
        {
            var query = @"
        query ($page: Int!, $size: Int!) {
          courseEnrollmentDuyenCtts(page: $page, size: $size) {
            items {
              enrollmentDuyenCttid
              userId
              courseId
              enrolledAt
              progress
              completedAt
              score
              certificateUrl
              isCertified
              enrollmentSource
              course {
                isActive
                courseDuyenCttid
                description
              }
            }
            pageIndex
            pageSize
            totalItems
            totalPages
            hasPreviousPage
            hasNextPage
          }
        }";

            var request = new GraphQLRequest
            {
                Query = query,
                Variables = new { page, size }
            };

            try
            {
                var response = await _graphQLClient.SendQueryAsync<CourseEnrollmentDuyenCTTResponse>(request);

                if (response.Errors != null && response.Errors.Any())
                {
                    Console.WriteLine("GraphQL errors:");
                    foreach (var error in response.Errors)
                    {
                        Console.WriteLine($"- {error.Message}");
                    }

                    return new PaginationResult<CourseEnrollmentDuyenCtt>(new(), 0, page, size);
                }

                if (response.Data == null)
                {
                    Console.WriteLine("GraphQL response.Data is null.");
                    return new PaginationResult<CourseEnrollmentDuyenCtt>(new(), 0, page, size);
                }

                return response.Data.CourseEnrollmentDuyenCtts;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred while calling GraphQL: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                return new PaginationResult<CourseEnrollmentDuyenCtt>(new(), 0, page, size);
            }
        }
    }
}
