using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Bosses : EnemieController{
    public BossBullet bullet;
    public int health;
    //public GameObject target;
    //private Vector3 offset, newPosition;
    bool isImmune = true;
    float immuneDuration = 1.5f, immuneCounter = 0f, flickerDuration = 0.1f, flickerCounter = 0f;
    public float minimum, maximum;
    SpriteRenderer sr;
    public Slider healthUI;
    //public float timeToShot;
    // Use this for initialization
    void Start () {
        sr = this.GetComponent<SpriteRenderer>();
        //timeToShot = 0f;
        minimum = 0f;
        maximum = 0.45f;
        //offset = this.transform.position - target.transform.position;
    }
	public void bossHealthAppear()
    {
        healthUI.gameObject.SetActive(true);
        healthUI.value = healthUI.maxValue;
    }
    //void FixedUpdate()
    //{
    //    newPosition = target.transform.position + offset;
    //    this.transform.position = Vector3.Lerp(this.transform.position, newPosition,Time.deltaTime);
    //}
    public void takeD (int d)
    {
        
            health -= d;
            if (health < 0)
                health = 0;
            if (health == 0)
            {
                Destroy(this.gameObject);
            }

        
        isImmune = true;
        immuneCounter = 0f;
    }
    public void shot()
    {

        Instantiate(bullet, shotingPoint.position, shotingPoint.rotation);

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


    // Update is called once per frame
    void Update () {
        //target = FindObjectOfType<PlayerController>().gameObject;
        mesure_distance = Vector2.Distance(FindObjectOfType<PlayerController>().transform.position, transform.position);
        Debug.Log(FindObjectOfType<PlayerController>().transform.position);
        minimum += (float)Time.deltaTime;
        if (10 >= mesure_distance)
        {
            if (minimum >= maximum)
            {

                shot();
                minimum = 0;
            }
        }
        //timeToShot += Time.deltaTime;
        //if (timeToShot >= 0.2f)
        //    shot();
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
