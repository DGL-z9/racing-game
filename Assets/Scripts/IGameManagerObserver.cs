using UnityEngine;

public interface IGameManagerObserver
{
    void OnGameStart(int fuel);
    void OnFuelUpdated(int fuel);
    void OnGameOver();
}
