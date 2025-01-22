using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>, IGameManagerObserver
{
    [Header("Main")]
    public GameObject startPanel;
    public GameObject endPanel;
    
    [Header("Game")]
    public TextMeshProUGUI fuelText;
    public GameObject gamePanel;
    
    [Header("Over")]
    public Button startButton;
    public Button endButton;


    public void Start()
    {
        PanelSetting();
        
        GameManager.Instance.AddObserver(this);
        
        startButton.onClick.AddListener(StartGame);
        endButton.onClick.AddListener(PanelSetting);
    }

    private void PanelSetting()
    {
        startPanel.SetActive(true);
        endPanel.SetActive(false);
        gamePanel.SetActive(false);
    }

    private void StartGame()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        endPanel.SetActive(false);
        
        GameManager.Instance.GameStart();
    }

    private void EndGame()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(false);
        endPanel.SetActive(true);
    }
    
    public void OnGameStart(int fuel)
    {
        fuelText.text = $"fuel : {fuel}";
    }

    public void OnFuelUpdated(int fuel)
    {
        fuelText.text = $"fuel : {fuel}";
    }

    public void OnGameOver()
    {
        EndGame();
    }
}
