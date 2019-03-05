using UnityEngine;
using System.Collections;

public class Kunai : MonoBehaviour {
    public float movespeed;
    public int damage;
    public AudioClip throwing;
    private float x, y, z;
    // Use this for initialization
    void Start () {
        PlayerController player = FindObjectOfType<PlayerController>();

        FindObjectOfType<AudioManager>().playSingle(throwing);
        x = GetComponent<Transform>().localScale.x;
        y = GetComponent<Transform>().localScale.y;
        z = GetComponent<Transform>().localScale.z;
        if (player.IsFacingRight == false)
        {
            movespeed = -movespeed;
            flip();
        }
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed, GetComponent<Rigidbody2D>().velocity.y);
        Destroy(this.gameObject,2);
    }
    void flip()
    {
        if (movespeed > 0)
            transform.localScale = new Vector3(x, y, z);
        else if (movespeed < 0)
            transform.localScale = new Vector3(-x, y, z);
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Enemy"||obj.tag=="Shot")
        { Destroy(obj.gameObject);
            Destroy(this.gameObject);
        }
        else if (obj.tag == "Boss" || obj.tag == "Big Boss")
        {
            FindObjectOfType<Bosses>().takeD(damage);
            Destroy(this.gameObject);
        }
    }
}
