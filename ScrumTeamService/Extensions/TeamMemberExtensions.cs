using Amazon.DynamoDBv2.Model;
using ScrumTeamService.Constants;
using ScrumTeamService.Models;

namespace ScrumTeamService.Extensions;

public static class TeamMemberExtensions
{
    public static PutItemRequest ToPutItemRequest(this TeamMember teamMember)
    {
        var putItemRequest = new PutItemRequest
        {
            TableName = DynamoDbConstants.TeamMemberTableName,
            Item = ConvertTeamMemberToDictionary(teamMember)
        };

        return putItemRequest;
    }

    private static Dictionary<string, AttributeValue> ConvertTeamMemberToDictionary(TeamMember teamMember)
    {
        return new Dictionary<string, AttributeValue>
        {
            {"Id", new AttributeValue(teamMember.Id.ToString())},
            {"LastName", new AttributeValue(teamMember.LastName)},
            {"FirstName", new AttributeValue(teamMember.FirstName)},
            {"TeamId", new AttributeValue(teamMember.TeamId.ToString())},
            {"DepartmentId", new AttributeValue(teamMember.DepartmentId.ToString())},
            {"Position", new AttributeValue(teamMember.Position)},
            {"Salary", new AttributeValue
            {
                N = teamMember.Salary.ToString()
            }},
        };
    }
}