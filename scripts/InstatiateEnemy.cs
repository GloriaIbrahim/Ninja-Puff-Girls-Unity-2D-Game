using UnityEngine;
using System.Collections;

public class InstatiateEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Meran"|| other.tag =="Gloria"|| other.tag =="Lorina")
            FindObjectOfType<SceneManager>().RespawnEnemy();
    }
    // Update is called once per frame
    void Update () {
	
	}
}
