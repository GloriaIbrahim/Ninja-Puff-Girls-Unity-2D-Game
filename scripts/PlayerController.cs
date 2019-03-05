using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    public float moveSpeed, climbSpeed, jumpHeight,slideSpeed, radius;
    public LayerMask[] grounds;
    public bool grounded,grounded2, IsFacingRight = true, isClimbing = false, isAttacking = false,isThrowing=false,sliding=false,isRunning=false;
    public Transform ground_check;
    private Animator anime;
    private float x, y, z, gravityStore, climbVelocity, attackTimer, cd;
    Rigidbody2D rigidBody;
    public int health;
    public Star newStar;
    public Kunai newKunai;
    public Transform throwingPoint;
    // Use this for initialization
    void Start()
    {
        x = GetComponent<Transform>().localScale.x;
        y = GetComponent<Transform>().localScale.y;
        z = GetComponent<Transform>().localScale.z;
        anime = GetComponent<Animator>();
        gravityStore = GetComponent<Rigidbody2D>().gravityScale;
        rigidBody = GetComponent<Rigidbody2D>();
        attackTimer = 2;
        cd = 0.5f;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(ground_check.position, radius, grounds[0]);
        grounded2 = Physics2D.OverlapCircle(ground_check.position, radius, grounds[1]);   //change here
    }

    // Used to flip the character left and right
    void flip()
    {
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(x, y, z);
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-x, y, z);
    }
    public void climb()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * climbSpeed * Time.deltaTime;
            rigidBody.gravityScale = 0;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.up * -climbSpeed/2 * Time.deltaTime;
            rigidBody.gravityScale = gravityStore;
        }
    }
    void throwStar()
    {
        isThrowing = true;
        Instantiate(newStar, throwingPoint.position, throwingPoint.rotation);
        
    }
    void throwKunai()
    {
        isThrowing = true;
        Instantiate(newKunai, throwingPoint.position, throwingPoint.rotation);
        
    }
    //GameObject FindClosestEnemy()
    //{
    //    GameObject[] gos;
    //    gos = GameObject.FindGameObjectsWithTag("Enemy");
    //    GameObject closest = null;
    //    float distance = Mathf.Infinity;
    //    Vector3 position = transform.position;
    //    foreach (GameObject enemy in gos)
    //    {
    //        Vector3 diff = enemy.transform.position - position;
    //        float curDistance = diff.sqrMagnitude;
    //        if (curDistance < distance)
    //        {
    //            closest = enemy;
    //            distance = curDistance;
    //        }
    //    }
    //    return closest;
    //}
    //void Example()
    //{
    //    print(FindClosestEnemy().name);
    //}
    void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.tag == "Ladder")
        {
            isClimbing = true;
            Debug.Log("hi");
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            isClimbing = false;
            rigidBody.gravityScale = gravityStore;
            Debug.Log("bye");
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            isRunning = true;
            if (!IsFacingRight)
            {
                flip();
                IsFacingRight = true;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            isRunning = true;
            if (IsFacingRight)
            {
                flip();
                IsFacingRight = false;
            }
        }
        
        anime.SetBool("Running", isRunning);
        isRunning = false;
        if (Input.GetKey(KeyCode.DownArrow) && (grounded||grounded2))
        {
            sliding = true;
            if (IsFacingRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(slideSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else if (!IsFacingRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-slideSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        anime.SetBool("Sliding", sliding);
        sliding = false;

        if (Input.GetKeyDown(KeyCode.Space) && (grounded ||grounded2))
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);

        anime.SetBool("Grounded", grounded||grounded2);
        if (isClimbing)
        {
            climb();
        }
        anime.SetBool("Climbing", isClimbing);

        
        if (Input.GetKeyDown(KeyCode.S))
        {
            throwStar();
        }
        else
            isThrowing = false;

        anime.SetBool("Throwing", isThrowing);

        if (Input.GetKeyDown(KeyCode.D))
        {
            throwKunai();
        }
        else
            isThrowing = false;

        anime.SetBool("Throwing", isThrowing);

        if (Input.GetKey(KeyCode.A))
        {
            isAttacking=true;
        }
        else
            isAttacking = false;

        anime.SetBool("Attack", isAttacking);
    }
    //void LateUpdate()
    //{
    //    anime.SetBool("Attack", isAttacking);
    //    if (attackTimer > 0)
    //    {
    //        attackTimer -= Time.deltaTime;
    //    }
    //    if (attackTimer < 0)
    //    {
    //        attackTimer = 0;
    //    }

    //    //GameObject target = FindClosestEnemy();
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        if (attackTimer == 0)
    //        {
    //            isAttacking = true;
    //            attackTimer = cd;
    //            /*EnemyHealth2 eh = (EnemyHealth2)target.GetComponent("EnemyHealth2");
    //            eh.curhp -= 10;
    //            Debug.Log("You whacked enemy for 10hp");
    //            if (eh.curhp <= 0)
    //            {
    //                Destroy(eh.gameObject);
    //            }*/
    //        }
    //    }
    //    else
    //    {
    //        isAttacking = false;
    //    }
    //}

}
