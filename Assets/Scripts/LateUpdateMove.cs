using UnityEngine;

public class LateUpdateMove : MonoBehaviour
{
    public float speed = 0.5f;
    
    private void LateUpdate()
    {
        transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
