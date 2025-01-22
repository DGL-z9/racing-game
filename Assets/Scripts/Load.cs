using UnityEngine;
using Random = UnityEngine.Random;

public class Load : MonoBehaviour
{
    [Header("Fuel")]
    public GameObject fuelPrefab;
    public Transform[] SpawnPoints;

    private void Start()
    {
        GenerateFuel();
    }

    public void GenerateFuel()
    {
        int randomIndex = Random.Range(0, 3);
        
        fuelPrefab.transform.position = SpawnPoints[randomIndex].position;
        fuelPrefab.SetActive(true);
    }
}
