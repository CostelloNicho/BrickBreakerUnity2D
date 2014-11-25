// Copyright 2014 Nicholas Costello <NicholasJCostello@gmail.com>

using UnityEngine.UI;

public class HUDManager : Singleton<HUDManager>
{
    public Text ScoreText;

    private int _score;

    public void Start()
    {
        _score = 0;
        DisplayScore();
    }

    public void OnEnable ()
    {
        Messenger<int>.AddListener(BrickBreakerEvents.PlayerScore, OnPlayerScored);
    }
    public void OnDisable ()
    {
        Messenger<int>.RemoveListener(BrickBreakerEvents.PlayerScore, OnPlayerScored);
    }

    public void OnPlayerScored(int points)
    {
        _score += points;
        DisplayScore();
    }

    private void DisplayScore()
    {
        ScoreText.text = string.Format("Score: {0}", _score);
    }
}