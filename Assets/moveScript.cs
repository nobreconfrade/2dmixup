using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    Rigidbody2D rigid_body;
    Animator player_animator;
    bool flipped;
    // Start is called before the first frame update
    void Start()
    {
        player_animator = gameObject.GetComponent<Animator>();
        rigid_body = gameObject.GetComponent<Rigidbody2D>();
        flipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        player_animator.SetInteger("AirSpeed", 0);
        player_animator.SetBool("Grounded", true);
        player_animator.SetInteger("AnimState", 0);
        if (Input.GetKey(KeyCode.RightArrow)){
            player_animator.SetInteger("AnimState", 2);            
            rigid_body.velocity = Vector2.right * 3;
            if(flipped == true){
                gameObject.transform.localScale *= new Vector2(-1,1); 
                flipped = false;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            player_animator.SetInteger("AnimState", 2);            
            rigid_body.velocity = Vector2.left * 3;
            if(flipped == false){
                gameObject.transform.localScale *= new Vector2(-1,1); 
                flipped = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            player_animator.SetInteger("AirSpeed", -1);
            player_animator.SetBool("Grounded", false);
            rigid_body.velocity = Vector2.up * 10;
        }
    }
}
