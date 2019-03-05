using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

    public float movespeed;
    public int damage;
    private float x, y, z;
    public AudioClip throwing;
    // Use this for initialization
    void Start()
    {
        FindObjectOfType<AudioManager>().playSingle(throwing);
        x = GetComponent<Transform>().localScale.x;
        y = GetComponent<Transform>().localScale.y;
        z = GetComponent<Transform>().localScale.z;
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player.IsFacingRight == false)
        { movespeed = -movespeed; }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed, GetComponent<Rigidbody2D>().velocity.y);
        transform.localScale = new Vector3(x, -y, z);
        Destroy(this.gameObject, 2);
    }
    
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Enemy" || obj.tag == "Shot")
        {
            Destroy(obj.gameObject);
            Destroy(this.gameObject);
        }
        else if (obj.tag == "Boss" || obj.tag=="Big Boss")
        {
            FindObjectOfType<Bosses>().takeD(damage);
            Destroy(this.gameObject);
        }
        //Destroy(this.gameObject);
    }
}
