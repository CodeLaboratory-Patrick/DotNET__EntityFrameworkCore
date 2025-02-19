using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

//First we need an instance of Context
using var context = new FootballLeagueDbContext();

//Select all the teams in a database
//GetAllTeams();

//Selecting a single record - First one in the list
var teamOne = await context.Teams.FirstAsync();

//Selecting a single record - First one in the list that meets a condition
var teamTwo = await context.Teams.FirstAsync(team => team.TeamId == 1);
//var teamTwo = await context.Teams.FirstOrDefaultAsync(team => team.TeamId == 1);

//Selecting a single record - Only we record should be returned
var teamThree = await context.Teams.SingleAsync(team => team.TeamId == 2);
//var teamThree = await context.Teams.SingleOrDefaultAsync(team => team.TeamId == 2);

//Selecting based on ID
var TeamBasedOnId = await context.Teams.FindAsync();

void GetAllTeams()
{
    //SELECT * FROM Teams
    var teams = context.Teams.ToList();
    foreach (var t in teams)
    {
        Console.WriteLine($"TeamId: {t.TeamId}, Name: {t.Name}, CreatedDate: {t.CreatedDate}");
    }
}