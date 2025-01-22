using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Car Settings")]
    public float moveSpeed = 3f; 
    public float xLimit = 5f;

    private Vector3 moveDirection = Vector3.zero;
    private void Update()
    {
        MoveInput();
        MoveCar();
    }

    private void MoveInput()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 screenPosition = Input.mousePosition;
            float screenMiddle = Screen.width / 2f;

            if (screenPosition.x < screenMiddle)
            {
                moveDirection = Vector3.left;
            }
            else
            {
                moveDirection = Vector3.right;
            }
        }
        else
        {
            moveDirection = Vector3.zero;
        }
    }
    
    private void MoveCar()
    {
        transform.Translate(moveDirection * (moveSpeed * Time.deltaTime));
        
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -xLimit, xLimit);
        transform.position = pos;
    }
}


