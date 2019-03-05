using UnityEngine;
using System.Collections;

public class BossLimit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boss")
            FindObjectOfType<Bosses>().flip();
        if (other.tag == "Gloria" || other.tag == "Lorina" || other.tag == "Meran")
            FindObjectOfType<Bosses>().bossHealthAppear();
    }
    // Update is called once per frame
    void Update () {
	
	}
}
