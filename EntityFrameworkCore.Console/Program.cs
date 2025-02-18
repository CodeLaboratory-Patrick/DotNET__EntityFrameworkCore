using EntityFrameworkCore.Data;

//First we need an instance of Context
var context = new FootballLeagueDbContext();

//Select all the teams in a database
//SELECT * FROM Teams

var teams = context.Teams.ToList();

foreach (var team in teams)
{
    Console.WriteLine($"TeamId: {team.TeamId}, Name: {team.Name}, CreatedDate: {team.CreatedDate}");
}
