using UnityEngine;
using Utils;

public class GameProcess : MonoBehaviour
{
    GameState _gameState;

    void Start()
    {
        ChangeGameState(new DefenseRunning());
    }

    void Update()
    {
        if (_gameState != null)
            _gameState.MainLoop();
    }

    public void ChangeGameState(GameState gameState)
    {
        _gameState = gameState;
        if (_gameState != null)
            _gameState.OnEnter();
    }
}