using UnityEngine;
using System.Collections;

public class EnemieController : MonoBehaviour
{
    public int damage;
    public bool isFacingRight = false;
    
    public Transform shotingPoint;
    public int speed;

    public float distance;
    public float mesure_distance; 
    float x, y, z;
    // Use this for initialization
    void Start()
    {
           
    }
    public void flipPose()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y,transform.localScale.z);
    }
    
    public void flip()
    {
        if (!isFacingRight)
        {
            flipPose();
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            isFacingRight = true;
        }
        else if (isFacingRight)
        {
            flipPose();
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
            isFacingRight = false;
        }
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {

    }
    void FixedUpdate()
    {
        if (this.isFacingRight == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    
}
