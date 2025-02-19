using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

//First we need an instance of Context
using var context = new FootballLeagueDbContext();

//Selecting a single record - First one in the list
// -> var teamOne = await context.Teams.FirstAsync();

//Selecting a single record - First one in the list that meets a condition
// -> var teamTwo = await context.Teams.FirstAsync(team => team.TeamId == 1);
// -> var teamTwo = await context.Teams.FirstOrDefaultAsync(team => team.TeamId == 1);

//Selecting a single record - Only we record should be returned
// -> var teamThree = await context.Teams.SingleAsync(team => team.TeamId == 2);
// -> var teamThree = await context.Teams.SingleOrDefaultAsync(team => team.TeamId == 2);

//Selecting based on ID
// -> var TeamBasedOnId = await context.Teams.FindAsync();



//Select all the teams in a database
//await GetAllTeams();

//Select one team
// await GetOneTeam();

//Select all record that meet a condition
async Task GetFilteredTeams()
{
    Console.WriteLine("Enter Search Term");
    var searchTerm = Console.ReadLine();

    var teamsFiltered = await context.Teams.Where(q => q.Name == searchTerm)
        .ToListAsync();

    foreach (var item in teamsFiltered)
    {
        Console.WriteLine(item.Name);
    }

    //Select Partial Matches
    //var partialMatches = await context.Teams.Where(q => q.Name.Contains(searchTerm)).ToListAsync();
    
    // SELECT * FROM Teams WHERE Name LIKE '%F.C.%'
    var partialMatches = await context.Teams.Where(q => EF.Functions.Like(q.Name, $"%{searchTerm}%"))
        .ToListAsync();
    foreach (var item in partialMatches)
    {
        Console.WriteLine(item.Name);
    }
}

async Task GetAllTeams()
{
    //SELECT * FROM Teams
    var teams = await context.Teams.ToListAsync();
    foreach (var t in teams)
    {
        Console.WriteLine($"TeamId: {t.TeamId}, Name: {t.Name}, CreatedDate: {t.CreatedDate}");
    }
}

async Task GetOneTeam()
{
    //Selecting a single record -First one in the list
    var teamFirst = await context.Coaches.FirstAsync();
    if (teamFirst != null)
    {
        Console.WriteLine(teamFirst.Name);
    }
    var teamFirstOrDefault = await context.Coaches.FirstOrDefaultAsync();
    if (teamFirstOrDefault != null)
    {
        Console.WriteLine(teamFirstOrDefault.Name);
    }

    //Selecting a single record -First one in the list that meets a condition
    var teamFirstWithCondition = await context.Teams.FirstAsync(team => team.TeamId == 1);
    if (teamFirstWithCondition != null)
    {
        Console.WriteLine(teamFirstWithCondition.Name);
    }
    var teamFirstOrDefaultWithCondition = await context.Teams.FirstOrDefaultAsync(team => team.TeamId == 1);
    if (teamFirstOrDefaultWithCondition != null)
    {
        Console.WriteLine(teamFirstOrDefaultWithCondition.Name);
    }

    //Selecting a single record -Only one record should be returned, or an exception will be thrown
    var teamSingle = await context.Teams.SingleAsync();
    if (teamSingle != null)
    {
        Console.WriteLine(teamSingle.Name);
    }
    var teamSingleWithCondition = await context.Teams.SingleAsync(team => team.TeamId == 2);
    if (teamSingleWithCondition != null)
    {
        Console.WriteLine(teamSingleWithCondition.Name);
    }
    var SingleOrDefault = await context.Teams.SingleOrDefaultAsync(team => team.TeamId == 2);
    if (SingleOrDefault != null)
    {
        Console.WriteLine(SingleOrDefault.Name);
    }

    //Selecting based on Primary Key Id value
    var teamBasedOnId = await context.Teams.FindAsync(3);
    if (teamBasedOnId != null)
    {
        Console.WriteLine(teamBasedOnId.Name);
    }
}