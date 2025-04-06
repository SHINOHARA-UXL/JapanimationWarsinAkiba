using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Animator animator; 
    public string kickanim; 
    public string punchanim;
    public AudioSource audioSource;
    public AudioClip beatclip;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log("衝突相手: " + hit.gameObject.name); // 衝突相手の名前をデバッグ表示

        if (hit.gameObject.CompareTag("Enemy"))
        {
            if (IsPlaying(kickanim) || IsPlaying(punchanim))
            {
                //Debug.Log("敵に衝突！");
                audioSource.PlayOneShot(beatclip);
                Destroy(hit.gameObject);
            }
        }
    }
    bool IsPlaying(string clipName)
    {
        AnimatorClipInfo[] clipInfos = animator.GetCurrentAnimatorClipInfo(0);
        foreach (var clipInfo in clipInfos)
        {
            if (clipInfo.clip.name == clipName)
            {
                return true;
            }
        }
        return false;
    }

}
