using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float speed;
    private humanenemies enemie;
    public int damage;
    // Use this for initialization
    void Start () {
        enemie = FindObjectOfType<humanenemies>();
        if (enemie.transform.localScale.x < 0)
            speed = -speed;
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

	
	}
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Meran" || other.tag == "Lorina" || other.tag == "Gloria")
        {
            FindObjectOfType<HealthController>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
