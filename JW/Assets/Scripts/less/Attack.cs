using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip panchClip;
    public AudioClip kickClip;
    AudioClip soundClip;
    AnimatorClipInfo[] BeforeClip;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(animator.name);
            animator.SetTrigger("Attack");
        }

        /*if (clipInfo[0].clip.name == "POSE26" && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.2)
        {
            soundClip = kickClip;
            AttackSoundPlay();
        }

        if(clipInfo[0].clip.name == "POSE30" && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.2)
        {
            soundClip = panchClip;
            AttackSoundPlay();
        }

        BeforeClip = clipInfo;
        
        

    }

    void AttackSoundPlay()
    {
       
        audioSource.clip = soundClip;
        audioSource.Play();
       
    }
        */
    }
}
