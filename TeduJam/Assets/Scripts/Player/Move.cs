using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float maxHealth;
    private float health;
    public float speed = 0f;
    private Vector2 moveVelocity;
    private float move1;
    private float move2;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator anim;
    private float X_pos = 1;
    bool isrun = false;
    bool Alive = true;

    Weapon weaponpos;
    private void Start() {
        health = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        weaponpos = GetComponent<Weapon>();
    }
    void Update()
    {
        if(Alive){
            Run();
        }
    }
    private void Run()
    {
        anim.SetBool("isWalk",false);
        move1 = Input.GetAxisRaw("Horizontal");
        move2 = Input.GetAxisRaw("Vertical");
        Debug.Log("move1"+move1);
        if(move1<0 ||move1>0 ){
            X_pos = move1;
            anim.SetBool("isWalk",true);
            PlayWalkAnimation();
        }
        if(move2<0 || move2>0){
            anim.SetBool("isWalk",true);
            PlayWalkAnimation();
        }
        if(move1 == -1){
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (move1 == 1 ){
            transform.localScale = new Vector3(1, 1, 1);
        }
        moveDirection = new Vector2(move1,move2);
        moveVelocity = moveDirection.normalized * speed;
    }
    public void TakeDamage(float damage){
        if(Alive){
            if(health-damage > 0){
                health -= damage;
                anim.SetTrigger("getHit");
            }
            else{
                health = 0;
                Alive = false;
                Die();
            }
            Debug.Log("Can: "+health);
        }
    }
    void Die(){
        rb.velocity = Vector2.zero;
        anim.SetTrigger("Die");
    }
    private void  FixedUpdate() {
        rb.velocity = moveVelocity;
    }
    public  Character(){
        move1 = 0;
        move2 = 0;
    }
    public float GetX(){return move1;}
    public float GetY(){return move2;}
    public Rigidbody2D getRB(){return rb;}
    public float getSpeed(){return speed;}
    public float getXAxis(){return X_pos;}
    public float getHealth(){return health;}
    void PlayWalkAnimation()
    {
        anim.Play("WalkAnimation", 0, 0f); // Direkt animasyonu başlatır, sıfırdan oynatır
    }
    void destroyobj(){
        Destroy(gameObject);
    }
}