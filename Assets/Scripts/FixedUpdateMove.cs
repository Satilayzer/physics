using UnityEngine;

public class FixedUpdateMove : MonoBehaviour
{
    public float speed = 0.5f;
    
    private void FixedUpdate()
    {
        transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
