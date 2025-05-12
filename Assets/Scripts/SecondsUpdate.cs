using UnityEngine;

public class SecondsUpdate : MonoBehaviour
{
    private float timeStartOffset;
    private bool gotStartTime ;
    
    public float speed = 0.5f;

    private void Update()
    {
        if (!gotStartTime)
        {
            timeStartOffset = Time.realtimeSinceStartup;
            gotStartTime = true;
        }
        
        transform.position = new Vector3(transform.position.x, transform.position.y, (Time.realtimeSinceStartup - timeStartOffset) * speed);
    }
}
