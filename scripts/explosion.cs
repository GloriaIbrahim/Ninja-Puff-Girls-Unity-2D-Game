using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {
    public AudioClip explo;
    void Start()
    {
        FindObjectOfType<AudioManager>().playSingle(explo);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Gloria" || other.tag == "Meran" || other.tag == "Lorina")
        {
            FindObjectOfType<HealthController>().takeDamage(1);
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 3);
    }
}
