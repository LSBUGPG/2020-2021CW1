using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bandit1 : MonoBehaviour {

    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 7.5f;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;

    public Collider2D SlashCollider;
    public Collider2D bodyCollider;
    public LayerMask enemyLayer;
    public ContactFilter2D contactFilter;
    public GameObject FireBall;
    public GameObject FireBallProjectile;
    bool gotFireBall = false;
    int enemieskilled = 0;
    public GameObject Combo;
    public Timer theTimer;
    int health = 2;
    public Image[] HealthImages;
    bool IamDead = false;
    bool deadAnim = false;
    // Use this for initialization
    void Start () {
        transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        SlashCollider.enabled = false;
        Combo.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (IamDead && deadAnim == false)
        {
            m_animator.SetTrigger("Death");
            deadAnim = true;
            return;
        }
        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State()) {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if(m_grounded && !m_groundSensor.State()) {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (inputX < 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Move
        m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

        // -- Handle Animations --
        //Death
        if (Input.GetKeyDown("e")) {
            if(!m_isDead)
                m_animator.SetTrigger("Death");
            else
                m_animator.SetTrigger("Recover");

            m_isDead = !m_isDead;
        }
            
        //Hurt
        else if (Input.GetKeyDown("q"))
            m_animator.SetTrigger("Hurt");

        //Attack
        else if(Input.GetMouseButtonDown(0)) {
            m_animator.SetTrigger("Attack");
            //AttackingEnemies();
        }

        //Change between idle and combat idle
        else if (Input.GetKeyDown("f"))
            m_combatIdle = !m_combatIdle;

        //Jump
        else if (Input.GetKeyDown("space") && m_grounded) {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 2);

        //Combat Idle
        else if (m_combatIdle)
            m_animator.SetInteger("AnimState", 1);

        //Idle
        else
            m_animator.SetInteger("AnimState", 0);
    }


    public void TurnOnSlashCollider()
    {
        SlashCollider.enabled = true;
        AttackingEnemies();
        if (gotFireBall == true)
        {
            
            FireProjectile();
        }
       
    }

    public void TurnOffSlashCollider()
    {
        SlashCollider.enabled = false;
    }
    void AttackingEnemies()
    {
        Collider2D[] results = new Collider2D[1];
        int enemies = SlashCollider.OverlapCollider(contactFilter, results);
        if (results[0] != null)
        {
            Destroy(results[0].gameObject);
            enemieskilled += 1;
            if (enemieskilled == 3)
            {
                Instantiate(FireBall, new Vector3(transform.position.x+2f, transform.position.y+1f, transform.position.z), Quaternion.identity);
                theTimer.StartTimer = true;

            }
        }
        
    }

    void FireProjectile()
    {
        GameObject Projectile = Instantiate(FireBallProjectile, new Vector3(transform.position.x , transform.position.y + 1f, transform.position.z), Quaternion.identity);
        Rigidbody2D rb = Projectile.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(transform.right * 10f*(transform.localScale.x*-1), ForceMode2D.Impulse);

    }

    public void StopFiring()
    {
        gotFireBall = false;
        Combo.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FireBall"))
        {
            Destroy(collision.gameObject);
            gotFireBall = true;
            Combo.SetActive(true);
        }
    }
    public void ReduceHealth()
    {
        HealthImages[health].enabled = false;
        m_animator.SetTrigger("Hurt");
        health -= 1;
        if (health < 0)
        {
            IamDead = true;
            Invoke("GameOver", 2f);
        }
        
    }
    void GameOver()
    {
        SceneManager.LoadScene("LevelFailed2");
    }


}
