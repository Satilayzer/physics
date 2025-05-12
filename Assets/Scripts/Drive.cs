using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public Transform transGun;
    public Transform gun;
    public GameObject bullet;
    
    private void Update()
    {
        var translation = Input.GetAxis("Vertical") * speed;
        var rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetKey(KeyCode.T))
        {
            transGun.RotateAround(transGun.position, transGun.right, -2); 
        }
        else if(Input.GetKey(KeyCode.G))
        {
            transGun.RotateAround(transGun.position, transGun.right, 2); 
        }
        else if(Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(bullet, gun.position, gun.rotation);
        }
    }
}
