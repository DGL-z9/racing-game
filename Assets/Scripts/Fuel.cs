using UnityEngine;

public class Fuel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        GameManager.Instance.AddFuel();
    }
}
