using System.Collections.Concurrent;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TestAssignmentSenseCapitalModels.Models;
using TestAssignmentSenseCapitalWeb;
using Utils;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer().AddSwaggerGen().Configure<JsonOptions>(opts =>
{
	opts.JsonSerializerOptions.Converters.Add(new TwoDimensionalPlayerArrayJsonConverter());
});
// builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
// builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();
app.UseSwagger().UseSwaggerUI();


var games = new ConcurrentDictionary<Guid, GameBoard>();


var options = new JsonSerializerOptions();
options.Converters.Add(new TwoDimensionalPlayerArrayJsonConverter());





app.MapPost("/create_game", (int? fieldSize) =>
{
	try
	{
		var guid = Guid.NewGuid();
		var newGame = fieldSize is null ? GameBoard.CreateNewGame() : GameBoard.CreateNewGame(fieldSize.Value);

		games.TryAdd(guid, newGame);
		return Results.Ok(guid);
	}
	catch (ArgumentOutOfRangeException argumentOutOfRangeException)
	{
		return Results.BadRequest(argumentOutOfRangeException.Message);
	}
});

app.MapPatch("/make_next_turn", (int row, int col, PlayerMark player, Guid guid) =>
{
	try
	{
		var gameExists = games.TryGetValue(guid, out var gameBoard);
		if (!gameExists || gameBoard is null) return Results.NotFound("There is not game with given id.");

		if (player != gameBoard.CurrentPlayer) throw new ArgumentException("Not your turn yet.");

		gameBoard.SetNextFieldCell(row, col);
		return Results.Ok(BoardStateResponse.CreateFromGameBoard(gameBoard));
	}
	catch (ArgumentException argumentException)
	{
		return Results.BadRequest(argumentException.Message);
	}
});

app.MapGet("/get_info_about_the_game", (Guid guid) =>
{
	var gameExists = games.TryGetValue(guid, out var gameBoard);
	if (!gameExists || gameBoard is null) return Results.NotFound();
	


	return Results.Ok(JsonSerializer.Serialize(BoardStateResponse.CreateFromGameBoard(gameBoard), options));
	//return Results.Ok(BoardStateResponse.CreateFromGameBoard(gameBoard));
});

app.Run();