using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Gloria" || other.tag == "Meran" || other.tag == "Lorina")
        {
            FindObjectOfType<PlayerController>().isClimbing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Gloria" || other.tag == "Meran" || other.tag == "Lorina")
        {
            FindObjectOfType<PlayerController>().isClimbing = false;
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
