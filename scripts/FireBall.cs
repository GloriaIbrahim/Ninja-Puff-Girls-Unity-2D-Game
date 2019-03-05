using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {
    public int damage;
    public AudioClip fireball;
    void Start()
    {
        FindObjectOfType <AudioManager>().playSingle(fireball);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Meran" || other.tag == "Gloria" || other.tag == "Lorina")
        {
            FindObjectOfType<HealthController>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
