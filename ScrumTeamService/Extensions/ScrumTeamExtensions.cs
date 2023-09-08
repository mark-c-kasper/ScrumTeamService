using Amazon.DynamoDBv2.Model;
using ScrumTeamService.Constants;
using ScrumTeamService.Models;

namespace ScrumTeamService.Extensions;

public static class ScrumTeamExtensions
{
    public static PutItemRequest ToPutItemRequest(this ScrumTeam scrumTeam)
    {
        var putItemRequest = new PutItemRequest
        {
            TableName = DynamoDbConstants.ScrumTeamTableName,
            Item = ConvertScrumTeamToDictionary(scrumTeam)
        };

        return putItemRequest;
    }

    private static Dictionary<string, AttributeValue> ConvertScrumTeamToDictionary(ScrumTeam scrumTeam)
    {
        return new Dictionary<string, AttributeValue>
        {
            {"Id", new AttributeValue(scrumTeam.Id.ToString())},
            {"Name", new AttributeValue(scrumTeam.Name)},
            {"OrganizationId", new AttributeValue(scrumTeam.OrganizationId.ToString())},
        };
    }
}