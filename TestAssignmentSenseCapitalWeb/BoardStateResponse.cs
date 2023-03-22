using TestAssignmentSenseCapitalModels.Models;

namespace TestAssignmentSenseCapitalWeb;

public readonly struct BoardStateResponse
{
	/// <summary>
	/// Instantiate new <see cref="BoardStateResponse"/> sample from <see cref="GameBoard"/> instance
	/// </summary>
	/// <param name="board">Given instance of <see cref="GameBoard"/></param>
	/// <returns>New instance of <see cref="GameBoard"/></returns>
	public static BoardStateResponse CreateFromGameBoard(GameBoard board)
	{
		return new BoardStateResponse
		{
			Winner = board.Winner,
			CurrentBoard = board.Board.ToArray(),
			CurrentPlayer = board.CurrentPlayer,
		};
	}


	/// <summary>
	/// Get information about current board`s state.
	/// So user does not need to store internal state. It is not the best solution for large boards.
	/// </summary>
	public required PlayerMark[,] CurrentBoard { get; init; }

	/// <summary>
	/// Let user know which player has to make turn
	/// </summary>
	public PlayerMark CurrentPlayer { get; init; }

	/// <summary>
	/// Let players who is winner if there is
	/// </summary>
	public PlayerMark? Winner { get; init; }
}