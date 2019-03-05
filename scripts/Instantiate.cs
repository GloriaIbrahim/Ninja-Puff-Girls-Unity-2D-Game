using UnityEngine;
using System.Collections;

public class Instantiate : MonoBehaviour {
    public GameObject obj;
	// Use this for initialization
	void Start () {
        //Instantiate(obj, transform.position, transform.rotation);
    }
	public void instantiate()
    {
        Instantiate(obj, transform.position, transform.rotation);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
