﻿using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

//First we need an instance of Context
using var context = new FootballLeagueDbContext();
Console.WriteLine(context.DbPath);

#region Read Queries
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
//await GetAllTeamsQuerySyntax();

//Select one team
// await GetOneTeam();

// Select all record that meet a condition
//await GetFilteredTeams();

// Aggregate Methods
//await AggregateMethods();

// Grouping and Aggregating
//GroupByMethod();

// Ordering
//await OrderByMethods();

// Skip and Take - Great for Paging
//await SkipAndTake();

// Select and Projections - more precise queries
//await ProjectionsAndSelect();

// No Tracking - EF Core tracks objects that are returned by queries. This is less useful in
// disconnected applications like APIs and Web apps
//await NoTracking();

#endregion


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

async Task GetAllTeamsQuerySyntax()
{
    Console.WriteLine("Enter Search Term");
    var searchTerm = Console.ReadLine();

    var teams = await (from team in context.Teams
                       where EF.Functions.Like(team.Name, $"%{searchTerm}%")
                       select team)
                    .ToListAsync();
    foreach (var t in teams)
    {
        Console.WriteLine(t.Name);
    }
}

async Task AggregateMethods()
{
    // Count
    var numberOfTeams = await context.Teams.CountAsync();
    Console.WriteLine($"Number of Teams: {numberOfTeams}");

    var numberOfTeamsWithCondition = await context.Teams.CountAsync(q => q.TeamId == 1);
    Console.WriteLine($"Number of Teams with condition above: {numberOfTeamsWithCondition}");

    // Max
    var maxTeams = await context.Teams.MaxAsync(q => q.TeamId);
    // Min
    var minTeams = await context.Teams.MinAsync(q => q.TeamId);
    // Average
    var avgTeams = await context.Teams.AverageAsync(q => q.TeamId);
    // Sum
    var sumTeams = await context.Teams.SumAsync(q => q.TeamId);
}

void GroupByMethod()
{
    var groupedTeams = context.Teams
    //.Where(q => q.Name == '') // Translates to a WHERE clause
    .GroupBy(q => q.CreatedDate.Date);
    //.Where(q => q.Name == '')// Translates to a HAVING clause;
    //.ToList(); // Use the executing method to load the results into memory before processing

    // EF Core can iterate through records on demand. Here, there is no executing method, but EF Core is bringing back records per iteration. 
    // This is convenient, but dangerous when you have several operations to complete per iteration. 
    // It is generally better to execute with ToList() and then operate on whatever is returned to memory. 
    foreach (var group in groupedTeams)
    {
        Console.WriteLine(group.Key);
        Console.WriteLine(group.Sum(q => q.TeamId));

        foreach (var team in group)
        {
            Console.WriteLine(team.Name);
        }
    }
}

async Task OrderByMethods()
{
    var orderedTeams = await context.Teams
    .OrderBy(q => q.Name)
    .ToListAsync();

    foreach (var item in orderedTeams)
    {
        Console.WriteLine(item.Name);
    }

    var descOrderedTeams = await context.Teams
        .OrderByDescending(q => q.Name)
        .ToListAsync();

    foreach (var item in descOrderedTeams)
    {
        Console.WriteLine(item.Name);
    }

    // Getting the record with a maximum value
    var maxByDescendingOrder = await context.Teams
        .OrderByDescending(q => q.TeamId)
        .FirstOrDefaultAsync();

    var maxBy = context.Teams.MaxBy(q => q.TeamId);

    // Getting the record with a minimum value
    var minByDescendingOrder = await context.Teams
        .OrderBy(q => q.TeamId)
        .FirstOrDefaultAsync();

    var minBy = context.Teams.MinBy(q => q.TeamId);

}

async Task SkipAndTake()
{
    var recordCount = 3;
    var page = 0;
    var next = true;
    while (next)
    {
        var teams = await context.Teams.Skip(page * recordCount).Take(recordCount).ToListAsync();
        foreach (var team in teams)
        {
            Console.WriteLine(team.Name);
        }
        Console.WriteLine("Enter 'true' for the next set of records, 'false' to exit");
        next = Convert.ToBoolean(Console.ReadLine());

        if (!next) break;
        page += 1;
    }
}

async Task ProjectionsAndSelect()
{
    var teams = await context.Teams
        .Select(q => new TeamInfo { Name = q.Name, TeamId = q.TeamId })
        .ToListAsync();

    foreach (var team in teams)
    {
        Console.WriteLine($"{team.TeamId} - {team.Name}");
    }
}
class TeamInfo
{
    public int TeamId { get; set; }
    public string Name { get; set; }
}

async Task NoTracking()
{
    var teams = await context.Teams
        .AsNoTracking()
        .ToListAsync();

    foreach (var t in teams)
    {
        Console.WriteLine(t.Name);
    }
}
