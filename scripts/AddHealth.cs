using UnityEngine;
using System.Collections;

public class AddHealth : MonoBehaviour {
    public AudioClip collectLife;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Meran"|| other.tag == "Lorina"|| other.tag == "Gloria")
        {

            FindObjectOfType<AudioManager>().playSingle(collectLife);
            Destroy(this.gameObject);
            FindObjectOfType<HealthController>().incrementHealth();
        }
    }
    void Update()
    {
        Destroy(this.gameObject, 3);
    }
}
