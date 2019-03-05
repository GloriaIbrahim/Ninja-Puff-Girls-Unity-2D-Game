using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    public int scene;
	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Gloria" || other.tag == "Meran" || other.tag == "Lorina")
        {
            FindObjectOfType<gameManager>().copyHealth();
            Application.LoadLevel(scene);
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
