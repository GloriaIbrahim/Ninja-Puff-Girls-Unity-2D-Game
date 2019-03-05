using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {
    public Instantiate[] enemies;
    public Instantiate boss;
    public Image[] images;
    public UIManager pause;
    //gameover;
    int lives;
    float timetofalse;
    // Use this for initialization
    public void pasteHealth()
    {
        GameObject.FindGameObjectWithTag("Gloria").gameObject.GetComponent<HealthController>().lives =FindObjectOfType<gameManager>().GloriaLives;
        GameObject.FindGameObjectWithTag("Lorina").gameObject.GetComponent<HealthController>().lives = FindObjectOfType<gameManager>().LorinaLives;
        GameObject.FindGameObjectWithTag("Meran").gameObject.GetComponent<HealthController>().lives = FindObjectOfType<gameManager>().MeranLives;
    }
    void Start () {
        pause.GetComponentInChildren<Canvas>().enabled = false;
        //gameover.GetComponentInChildren<Canvas>().enabled = false;
        images[0].enabled = true;
        images[1].enabled = true;
        images[2].enabled = true;
        images[3].enabled = true;
        images[4].enabled = true;
    }
    public void RespawnEnemy()
    {
        randomize();
    }
    public void RespawnBoss()
    {
        boss.instantiate();
    }
    public void randomize()
    {
        int index = Random.Range(0, enemies.Length);
        enemies[index].instantiate();
    }
    // Update is called once per frame
    void Update () {

        timetofalse += Time.deltaTime;
        if (timetofalse >= 0.1f && timetofalse <= 0.3)
        { pasteHealth(); }
        FindObjectOfType<Slider>().value = FindObjectOfType<HealthController>().healthUI.value;
        lives = FindObjectOfType<HealthController>().lives;
        if (Input.GetKeyDown(KeyCode.Escape))
            this.TogglePauseMenu();
        if (lives == 5)
        {
            images[0].enabled = true;
            images[1].enabled = true;
            images[2].enabled = true;
            images[3].enabled = true;
            images[4].enabled = true;
        }
        else if (lives == 4)
        {
            images[0].enabled = true;
            images[1].enabled = true;
            images[2].enabled = true;
            images[3].enabled = true;
            images[4].enabled = false;
        }
        else if (lives == 3)
        {
            images[0].enabled = true;
            images[1].enabled = true;
            images[2].enabled = true;
            images[3].enabled = false;
            images[4].enabled = false;
        }
        else if (lives == 2)
        {
            images[0].enabled = true;
            images[1].enabled = true;
            images[2].enabled = false;
            images[3].enabled = false;
            images[4].enabled = false;
        }
        else if (lives == 1)
        {
            images[0].enabled = true;
            images[1].enabled = false;
            images[2].enabled = false;
            images[3].enabled = false;
            images[4].enabled = false;
        }
        else if (lives == 0)
        {
            images[0].enabled = false;
            images[1].enabled = false;
            images[2].enabled = false;
            images[3].enabled = false;
            images[4].enabled = false;
        }
        //if (lives == 4)
        //{
        //    //Destroy(images[4]);
        //    images[4].enabled = false;
        //}
        //else if (lives == 3)
        //{
        //    //Destroy(images[3]);
        //    images[3].enabled = false;
        //}
        //else if (lives == 2)
        //{
        //    //Destroy(images[2]);
        //    images[2].enabled = false;
        //}
        //else if (lives == 1)
        //{
        //    //Destroy(images[1]);
        //    images[1].enabled = false;
        //}
        //else if (lives == 0)
        //{
        //    //Destroy(images[0]);
        //    images[0].enabled = false;
        //}
        //if (lives <= 0)
        //    images[0].enabled = false;
        //else if (lives == 1)
        //{
        //    //Instantiate(images[0]);
        //    images[0].enabled = true;
        //}
        //else if (lives == 2)
        //{
        //    //Instantiate(images[0]);
        //    images[0].enabled = true;
        //    images[1].enabled = true;
        //}
        //else if (lives == 3)
        //{
        //    //Instantiate(images[]);
        //    images[0].enabled = true;
        //    images[1].enabled = true;
        //    images[2].enabled = true;
        //}
        //else if (lives == 4)
        //{
        //    //Instantiate(images[0]);
        //    images[0].enabled = true;
        //    images[1].enabled = true;
        //    images[2].enabled = true;
        //    images[3].enabled = true;
        //}
        //else if (lives == 5)
        //{
        //    //Instantiate(images[0]);
        //    images[0].enabled = true;
        //    images[1].enabled = true;
        //    images[2].enabled = true;
        //    images[3].enabled = true;
        //    images[4].enabled = true;
        //}
    }
    public void TogglePauseMenu()
    {
        // not the optimal way but for the sake of readability
        if (pause.GetComponentInChildren<Canvas>().enabled)
        {
            pause.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
        }
        else if (!pause.GetComponentInChildren<Canvas>().enabled)
        {
            pause.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0f;
        }

        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }
    //public void gameOver()
    //{
    //    //gameObject.GetComponentInChildren<Canvas>().enabled = true;
    //    //GoToGameOverScene();
    //    //Application.LoadLevel(10);
    //    FindObjectOfType<NavigationController>().GoToGameOverScene();
    //    Time.timeScale = 0f;
    //}
}
