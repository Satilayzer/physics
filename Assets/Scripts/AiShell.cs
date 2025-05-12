using UnityEngine;

public class AiShell : MonoBehaviour
{
    public GameObject explosion;
    public Rigidbody rb;

    private void Update()
    {
        transform.forward = rb.linearVelocity;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tank")
        {
            var exp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(gameObject);
        }    
    }
}
