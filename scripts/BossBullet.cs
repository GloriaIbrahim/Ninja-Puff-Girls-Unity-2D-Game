using UnityEngine;
using System.Collections;

public class BossBullet : MonoBehaviour {
    public float speed;
    private Bosses enemie;
    public GameObject player;
    public int damage;
    // Use this for initialization
    void Start()
    {
        enemie = FindObjectOfType<Bosses>();
        if (enemie.transform.localScale.x > 0 && enemie.tag != "Big Boss")
        {
            speed = 6;
            speed = -speed;
        }
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);


    }
    void FixedUpdate()
    {
        if (enemie.tag == "Big Boss")
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Meran" || other.tag == "Lorina" || other.tag == "Gloria")
        {
            FindObjectOfType<HealthController>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
