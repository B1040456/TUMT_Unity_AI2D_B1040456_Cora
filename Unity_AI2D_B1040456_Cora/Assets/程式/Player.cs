using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int speed = 15;
    public float jump = 2.5f;
    public bool pass = false;
    public bool isGround = false;
    public float hp = 100;

    private Rigidbody2D r2d;
    private Transform tra;
    public Animator ani;

    public Image hpBar;
    private float hpmax;

    public GameObject finsh;
    public static Player fin;


    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        tra = GetComponent<Transform>();

        hpmax = hp;
        fin = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn(0);
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
    }

    private void FixedUpdate()
    {
        Walk();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "carrot")
        {
            Destroy(collision.gameObject);
            NPC.carrot.countCarrot += 1;
        }
    }

    void Walk()
    {
        ani.SetBool("走路", Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0);
        r2d.AddForce(new Vector2(speed * (Input.GetAxis("Horizontal")), 0));
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
        }
    }

    void Turn(int direction)
    {
        tra.eulerAngles = new Vector3(0, direction, 0);
    }

    public void Damage(float damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp / hpmax;

        if (hp <= 0)
        {
            finsh.SetActive(true);

            Destroy(this);
        }
    }
}
