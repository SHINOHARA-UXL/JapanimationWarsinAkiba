using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int playerPoints = 0;
    public string attackAnimationState;
    private Animator animator; 
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        isAttacking = animator.GetCurrentAnimatorStateInfo(0).IsName(attackAnimationState);
        /*if (clipInfo[0].clip.name == attackAnimationState) 
        { 
            //Debug.Log(3); 
        }*/
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(1);
        if (collision.gameObject.CompareTag("Enemy") && isAttacking)
        {
            Debug.Log(2);
            Destroy(collision.gameObject);

            // ポイントを加算
            playerPoints += 10;
            Debug.Log("ポイント獲得! 現在のポイント: " + playerPoints);
        }
    }
}
