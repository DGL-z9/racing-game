using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Game State")]
    public bool isGameStarted;

    [Header("Car")]
    public GameObject car;
    public int fuel;
    public int fuelPower = 30;
    
    [Header("Load")]
    public GameObject[] loads;
    
    private float elapsedTime;
    private List<IGameManagerObserver> observers = new List<IGameManagerObserver>();
    
    private void Update()
    {
        if (!isGameStarted) return;
        UpdateFuel();
    }
    
    #region Game Flow
    public void GameStart()
    {
        Time.timeScale = 1;
        isGameStarted = true;
        fuel = 100;
        elapsedTime = 0;
        car.SetActive(true);
        
        NotifyOnGameStart();
    }

    private void GameEnd()
    {
        Time.timeScale = 0;
        isGameStarted = false;
        car.SetActive(false);
        
        NotifyOnGameOver();
    }
    #endregion
    
    #region Fuel
    private void UpdateFuel()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 1)
        {
            elapsedTime = 0;
            RemoveFuel();
            if (fuel <= 0) GameEnd();
        }
    }
    public void AddFuel()
    {
        fuel += fuelPower;
        NotifyOnFuelUpdated();
    }

    private void RemoveFuel()
    {
        fuel -= 10;
        NotifyOnFuelUpdated();
    }
    #endregion

    #region Observer
    public void AddObserver(IGameManagerObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IGameManagerObserver observer)
    {
        observers.Remove(observer);
    }

    private void NotifyOnGameStart()
    {
        foreach (var observer in observers)
        {
            observer.OnGameStart(fuel);
        }
    }
    
    private void NotifyOnFuelUpdated()
    {
        foreach (var observer in observers)
        {
            observer.OnFuelUpdated(fuel);
        }
    }

    private void NotifyOnGameOver()
    {
        foreach (var observer in observers)
        {
            observer.OnGameOver();
        }
    }
    #endregion
}
