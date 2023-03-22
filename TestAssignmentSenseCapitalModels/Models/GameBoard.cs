using Microsoft.Toolkit.HighPerformance;

namespace TestAssignmentSenseCapitalModels.Models;

/// <summary>
/// Describes state of tic-tac-toe game
/// </summary>
public class GameBoard
{
	/// <summary>
	/// Instantiate new instance of game field
	/// </summary>
	/// <returns></returns>
	public static GameBoard CreateNewGame(int fieldSize = 3)
	{
		if (fieldSize <= 2)
			throw new ArgumentOutOfRangeException(nameof(fieldSize), "Field size mast be not lower than 2");
		
		return new GameBoard(fieldSize);
	}

	private GameBoard(int fieldSize)
	{
		_fieldSize = fieldSize;

		_board = new PlayerMark[_fieldSize, _fieldSize];
	}

	private readonly int _fieldSize;

	private readonly PlayerMark[,] _board;

	/// <summary>
	/// Properly encapsulated state of board
	/// </summary>
	public ReadOnlyMemory2D<PlayerMark> Board => _board;

	/// <summary>
	/// Winner in current game
	/// </summary>
	public PlayerMark? Winner { get; private set; }

	/// <summary>
	/// Current player which should decide next turn
	/// </summary>
	public PlayerMark CurrentPlayer { get; private set; } = PlayerMark.Cross;


	/// <summary>
	/// Apply turn and define winner afterwards.
	/// </summary>
	/// <param name="x">Row of field</param>
	/// <param name="y">Column of field</param>
	/// <exception cref="ArgumentException">Thrown if chosen not empty cell of field</exception>
	/// <exception cref="ArgumentOutOfRangeException">Thrown if given row or column are invalid</exception>
	public PlayerMark? SetNextFieldCell(int x, int y)
	{
		if (_board[x, y] is not PlayerMark.Nobody)
			throw new ArgumentException("This field cell is busy");

		if (x < 0 || x >= _fieldSize)
			throw new ArgumentOutOfRangeException(nameof(x), "Row value is out of range");

		if (y < 0 || y >= _fieldSize)
			throw new ArgumentOutOfRangeException(nameof(y), "Column value is out of range");

		_board[x, y] = CurrentPlayer;

		//check end conditions

		//check col
		for (var i = 0; i < _fieldSize; i++)
		{
			if (_board[x, i] != CurrentPlayer) break;

			if (i == _fieldSize - 1) return Winner = CurrentPlayer;
		}

		//check row
		for (var i = 0; i < _fieldSize; i++)
		{
			if (_board[i, y] != CurrentPlayer) break;

			if (i == _fieldSize - 1) return Winner = CurrentPlayer;
		}

		//check diag
		if (x == y)
		{
			//we're on a diagonal
			for (var i = 0; i < _fieldSize; i++)
			{
				if (_board[i, i] != CurrentPlayer) break;

				if (i == _fieldSize - 1) return Winner = CurrentPlayer;
			}
		}

		//check anti diag
		if (x + y == _fieldSize - 1)
		{
			for (var i = 0; i < _fieldSize; i++)
			{
				if (_board[i, _fieldSize - 1 - i] != CurrentPlayer) break;

				if (i == _fieldSize - 1) return Winner = CurrentPlayer;
			}
		}

#pragma warning disable CS8509 There is no possible way to get unexpected value of current PlayerMark
		CurrentPlayer = CurrentPlayer switch
#pragma warning restore CS8509
		{
			PlayerMark.Cross => PlayerMark.Zeroes,

			PlayerMark.Zeroes => PlayerMark.Cross,
		};

		return null;
	}
}