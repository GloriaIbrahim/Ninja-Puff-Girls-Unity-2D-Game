using UnityEngine;
using System.Collections;

public class animal : EnemieController {
    public AudioClip animalSound;
	// Use this for initialization
	void Start () {

        FindObjectOfType<AudioManager>().playSingle(animalSound);
    }
	
	// Update is called once per frame
	void Update () {

    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Weapon")
            Destroy(this.gameObject);
        else if (other.tag == "Meran"|| other.tag == "Gloria" || other.tag == "Lorina")
        {
            FindObjectOfType<HealthController>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
