using UnityEngine;
using System.Collections;

public class InstantiateBoss : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Meran" || other.tag == "Gloria" || other.tag == "Lorina")
        {
            FindObjectOfType<SceneManager>().RespawnBoss();
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
