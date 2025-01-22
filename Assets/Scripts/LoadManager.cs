using UnityEngine;

public class LoadManager : MonoBehaviour
{
    [Header("Load Settings")]
    public GameObject[] loads; 
    public float moveSpeed = 5f;
    public float resetPositionZ = -40f; // Load가 리셋될 z 위치
    public float startPositionZ = 40;  // Load가 다시 시작할 z 위치
    
    private Load[] loadComponents;

    private void Start()
    {
        loadComponents = new Load[loads.Length];
        for (int i = 0; i < loadComponents.Length; i++)
        {
            loadComponents[i] = loads[i].GetComponent<Load>();
        }
    }
    private void Update()
    {
        if (!GameManager.Instance.isGameStarted) return;
        for (int i = 0; i < loads.Length; i++)
        {
            MoveLoad(i);
        }
    }

    void MoveLoad(int index)
    {
        GameObject load = loads[index];
        Load loadComponent = loadComponents[index];
        
        load.transform.position += Vector3.back * (moveSpeed * Time.deltaTime);

        if (load.transform.position.z <= resetPositionZ)
        {
            Vector3 newPosition = load.transform.position;
            newPosition.z = startPositionZ;
            load.transform.position = newPosition;
            
            loadComponent.GenerateFuel();
        }
    }
}
