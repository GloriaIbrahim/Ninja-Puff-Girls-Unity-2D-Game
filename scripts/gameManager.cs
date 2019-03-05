using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
    //public int GloriaHealth, MeranHealth, LorinaHealth, 
    public int GloriaLives, MeranLives, LorinaLives;
    public bool GloriaIsAlive, LorinaIsAlive, MeranIsAlive;
    public GameObject Gloria, Meran, Lorina;
    // Use this for initialization
    void Start()
    {
        GloriaLives = 5;
        MeranLives = 5;
        LorinaLives = 5;
        GloriaIsAlive = true;
        LorinaIsAlive = true;
        MeranIsAlive = true;
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

    }
 
    public void copyHealth()
    {
        GloriaLives = Gloria.GetComponent<HealthController>().lives;
        LorinaLives = Lorina.GetComponent<HealthController>().lives;
        MeranLives = Meran.GetComponent<HealthController>().lives;
    }
    // Update is called once per frame
    void Update()
    {
        Gloria = GameObject.FindGameObjectWithTag("Gloria").gameObject;
        Lorina = GameObject.FindGameObjectWithTag("Lorina").gameObject;
        Meran = GameObject.FindGameObjectWithTag("Meran").gameObject;
        GloriaIsAlive = FindObjectOfType<playerChanger>().GloriaIsAlive;
        MeranIsAlive = FindObjectOfType<playerChanger>().MeranIsAlive;
        LorinaIsAlive = FindObjectOfType<playerChanger>().LorinaIsAlive;
    }
}
