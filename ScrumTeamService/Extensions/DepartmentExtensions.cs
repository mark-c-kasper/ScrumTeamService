using Amazon.DynamoDBv2.Model;
using ScrumTeamService.Constants;
using ScrumTeamService.Models;

namespace ScrumTeamService.Extensions;

public static class DepartmentExtensions
{
    public static PutItemRequest ToPutItemRequest(this Department department)
    {
        var putItemRequest = new PutItemRequest
        {
            TableName = DynamoDbConstants.DepartmentsTableName,
            Item = GetDepartmentAsDictionary(department)
        };

        return putItemRequest;
    }

    private static Dictionary<string, AttributeValue> GetDepartmentAsDictionary(Department department)
    {
        return new Dictionary<string, AttributeValue>
        {
            {"Id", new AttributeValue(department.Id.ToString())},
            {"Name", new AttributeValue(department.Name)}
        };
    }
}