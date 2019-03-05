using UnityEngine;
using System.Collections;

public class playerChanger : MonoBehaviour {
    public GameObject gloria;
    public GameObject miran;
    public GameObject lorina;
    public GameObject gloria2;
    public GameObject miran2;
    public GameObject lorina2;
    public float timetofalse;
    public bool GloriaIsAlive=true,LorinaIsAlive=true,MeranIsAlive=true;
    public Vector3 initialPositiom, newPosition;
    private int GloriaHealth, MeranHealth, LorinaHealth;
    private GameObject player;
    // Use this for initialization
    
    void Start () {
        FindObjectOfType<gameManager>().gameObject.SetActive(true);
        
        initialPositiom = this.transform.position;
        gloria2=Instantiate(gloria, initialPositiom, Quaternion.identity)as GameObject;
        miran2=Instantiate(miran, initialPositiom, Quaternion.identity)as GameObject;
        lorina2=Instantiate(lorina, initialPositiom, Quaternion.identity)as GameObject;
        
        gloria2.SetActive(true);
        lorina2.SetActive(true);
        miran2.SetActive(true);
        GloriaHealth = gloria2.GetComponent<PlayerController>().health;
        MeranHealth =miran2.GetComponent<PlayerController>().health;
        LorinaHealth = lorina2.GetComponent<PlayerController>().health;
        
    }
    public void switchPlayer(int num,Vector2 positon)
    {
        if (num == 1)
        {

            if (lorina2 != null)
            {
                lorina2.SetActive(true);
                lorina2.transform.position = positon;
            }
            else if (miran2 != null)
            {
                miran2.SetActive(true);
                miran2.transform.position = positon;
            }
            else
                //Application.LoadLevel(10);
                FindObjectOfType<NavigationController>().GoToGameOverScene();
            gloria2.SetActive(false);
            GloriaIsAlive = false;
        }
        else if (num == 2)
        {

            
            if (miran2 != null)
            {
                miran2.SetActive(true);
                miran2.transform.position = positon;
            }
            else if (gloria2 != null)
            {
                gloria2.SetActive(true);
                gloria2.transform.position = positon;
            }
            else
                //Application.LoadLevel(10);
                FindObjectOfType<NavigationController>().GoToGameOverScene();
            lorina2.SetActive(false);
            LorinaIsAlive = false;
        }
        else if (num == 3)
        {

            if (gloria2 != null)
            {
                gloria2.SetActive(true);
                gloria2.transform.position = positon;
            }
            else if (lorina2 != null)
            {
                lorina2.SetActive(true);
                lorina2.transform.position = positon;
            }
            else
                //Application.LoadLevel(10);
                FindObjectOfType<NavigationController>().GoToGameOverScene();
            miran2.SetActive(false);
            MeranIsAlive = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        FindObjectOfType<gameManager>().gameObject.SetActive(true);
        player = FindObjectOfType<PlayerController>().gameObject;
        newPosition = player.transform.position;
        if (Input.GetKeyDown(KeyCode.Q)&&GloriaIsAlive)
        {
            gloria2.SetActive(true);
            miran2.SetActive(false);
            lorina2.SetActive(false);
            gloria2.transform.position = newPosition;
        }
        if (Input.GetKeyDown(KeyCode.W)&&MeranIsAlive)
        {
            gloria2.SetActive(false);
            miran2.SetActive(true);
            lorina2.SetActive(false);
            miran2.transform.position = newPosition;
        }
        if (Input.GetKeyDown(KeyCode.E)&&LorinaIsAlive)
        {
            gloria2.SetActive(false);
            miran2.SetActive(false);
            lorina2.SetActive(true);
            lorina2.transform.position = newPosition;
        }
    }
    void Update() {

        timetofalse += Time.deltaTime;
        if (timetofalse >= 0.1f && timetofalse <= 0.3)
        {
            GloriaIsAlive = FindObjectOfType<gameManager>().GloriaIsAlive;
            LorinaIsAlive = FindObjectOfType<gameManager>().LorinaIsAlive;
            MeranIsAlive = FindObjectOfType<gameManager>().MeranIsAlive;
        }
        if (timetofalse >= 0.2f&&timetofalse<=0.4&&GloriaIsAlive) {
            lorina2.SetActive(false);
            miran2.SetActive(false);
        }
        else if (timetofalse >= 0.2f && timetofalse <= 0.4 && LorinaIsAlive)
        {
            gloria2.SetActive(false);
            miran2.SetActive(false);
        }
        else if (timetofalse >= 0.2f && timetofalse <= 0.4 && MeranIsAlive)
        {
            lorina2.SetActive(false);
            gloria2.SetActive(false);
        }
        if (!GloriaIsAlive && !MeranIsAlive && !LorinaIsAlive)
        {
            FindObjectOfType<NavigationController>().GoToGameOverScene();
            Time.timeScale = 0f;
        }
    }
}
