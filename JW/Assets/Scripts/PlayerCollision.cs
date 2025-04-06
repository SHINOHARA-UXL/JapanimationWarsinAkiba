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
        //Debug.Log("�Փˑ���: " + hit.gameObject.name); // �Փˑ���̖��O���f�o�b�O�\��

        if (hit.gameObject.CompareTag("Enemy"))
        {
            if (IsPlaying(kickanim) || IsPlaying(punchanim))
            {
                //Debug.Log("�G�ɏՓˁI");
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
