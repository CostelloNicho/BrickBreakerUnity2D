
public class Player
{
	private int _playerScore;
	public int PlayerScore 
	{
		get{ return _playerScore; }
		private set { _playerScore = value; }
	}

	public Player()
	{
		PlayerScore = 0;
	}

	public Player(int playerScore)
	{
		PlayerScore = playerScore;
	}

	public void AddIntToScore(int value)
	{
		PlayerScore += value;
	}
}
