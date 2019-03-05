using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthController : MonoBehaviour {

    public int health = 16, lives = 5;
    bool isImmune = true;
    float immuneDuration = 0.5f, immuneCounter = 0f, flickerDuration = 0.1f, flickerCounter = 0f;
    SpriteRenderer sr;
    public Slider healthUI;
    //public AudioClip audio;
    // Use this for initialization
  
    void Start()
    {

        sr = this.GetComponent<SpriteRenderer>();
        //health = FindObjectOfType<PlayerController>().health;
    }


    public void takeDamage(int d)
    {
        //if (!isImmune)
        //{
            health -= d;
            if (health < 0)
                health = 0;
            if (health == 0 && lives > 0)
            {
                //FindObjectOfType<SceneManager>().respawn2();
                health = 16;
                lives--;
            }
            if (lives == 0 && health == 0)
            {
                if (this.gameObject.tag == "Gloria")
                    FindObjectOfType<playerChanger>().switchPlayer(1,this.gameObject.GetComponent<Transform>().position);
                else if (this.gameObject.tag == "Lorina")
                    FindObjectOfType<playerChanger>().switchPlayer(2, this.gameObject.GetComponent<Transform>().position);
                else if (this.gameObject.tag == "Meran")
                    FindObjectOfType<playerChanger>().switchPlayer(3, this.gameObject.GetComponent<Transform>().position);
                //Debug.Log("GameOver");
                //Destroy(this.gameObject);
                //FindObjectOfType<SceneManager>().gameOver();
                
                    //FindObjectOfType<NavigationController>().GoToGameOverScene();
                //audioManager.instance.playSingle(audio);
            }

        //}
        //else
        //{
        //    health -= d;
        //    if (health < 0)
        //        health = 0;
        //    if (health == 0 && lives > 0)
        //    {
        //        //FindObjectOfType<SceneManager>().respawn2();
        //        health = 16;
        //        lives--;
        //    }
        //    if (lives == 0 && health == 0)
        //    {
        //        if (this.gameObject.tag == "Gloria")
        //            FindObjectOfType<playerChanger>().switchPlayer(1);
        //        else if (this.gameObject.tag == "Lorina")
        //            FindObjectOfType<playerChanger>().switchPlayer(2);
        //        else if (this.gameObject.tag == "Meran")
        //            FindObjectOfType<playerChanger>().switchPlayer(3);
        //        //Debug.Log("GameOver");
        //        //Destroy(this.gameObject);
        //        //FindObjectOfType<SceneManager>().gameOver();
        //        //FindObjectOfType<NavigationController>().GoToIntroScene();
        //        //audioManager.instance.playSingle(audio);
        //    }

        //}
        isImmune = true;
        immuneCounter = 0f;
    }
    void spriteFlicker()
    {
        if (this.flickerCounter < this.flickerDuration)
            flickerCounter += Time.deltaTime;
        else if (flickerCounter >= flickerDuration)
        {
            sr.enabled = !sr.enabled;
            flickerCounter = 0;
        }
    }
    public void incrementHealth()
    {
        health++;
    }
    // Update is called once per frame
    void Update()
    {
        //health = FindObjectOfType<PlayerController>().health;
        healthUI.value = health;
        if (isImmune == true)
        {
            spriteFlicker();
            immuneCounter += Time.deltaTime;
            if (immuneCounter >= immuneDuration)
            {
                isImmune = false;
                sr.enabled = true;
            }
        }
    }
}
