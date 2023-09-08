using Amazon.DynamoDBv2.Model;
using ScrumTeamService.Constants;
using ScrumTeamService.Models;

namespace ScrumTeamService.Extensions;

public static class ScrumOrganizationExtensions
{
    public static PutItemRequest ToPutItemRequest(this ScrumOrganization scrumOrganization)
    {
        var putItemRequest = new PutItemRequest
        {
            TableName = DynamoDbConstants.ScrumOrganizationTableName,
            Item = ConvertScrumOrganizationToDictionary(scrumOrganization)
        };

        return putItemRequest;
    }

    private static Dictionary<string, AttributeValue> ConvertScrumOrganizationToDictionary(ScrumOrganization scrumOrganization)
    {
        return new Dictionary<string, AttributeValue>
        {
            {"Id", new AttributeValue(scrumOrganization.Id.ToString())},
            {"Name", new AttributeValue(scrumOrganization.Name)}
        };
    }
}