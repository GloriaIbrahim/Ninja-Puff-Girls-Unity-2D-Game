using UnityEngine;
using System.Collections;

public class humanenemies : EnemieController {
    public Bullet bullet;
    public float minimum,maximum;
    // Use this for initialization
    void Start () {
        
        minimum = 0f;
        maximum = 5f;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
    public void shot()
    {

        Instantiate(bullet, shotingPoint.position, shotingPoint.rotation);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Weapon")
            Destroy(this.gameObject);
        else if (other.tag == "Meran"|| other.tag == "Gloria" || other.tag == "Lorina")
        {
            FindObjectOfType<HealthController>().takeDamage(damage);
            Destroy(this.gameObject);
        }
        
    }
}
