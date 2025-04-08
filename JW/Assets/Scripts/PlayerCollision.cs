using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public Animator animator; 
    public string kickanim; 
    public string punchanim;
    public AudioSource audioSource;
    public AudioClip beatclip;
    public AudioClip damagedclip;
    int maxHp = 100;
    int currentHp;
    public Slider slider;

    void Start()
    {
        slider.value = 1;
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
    }

    
    private void OnControllerColliderHit(ControllerColliderHit hit)//�Փ˔���
    {
        //Debug.Log("�Փˑ���: " + hit.gameObject.name); // �Փˑ���̖��O���f�o�b�O�\��

        if (hit.gameObject.CompareTag("Enemy"))
        {
            if (IsPlaying(kickanim) || IsPlaying(punchanim))
            {
                Debug.Log("�G�ɏՓˁI");
                audioSource.PlayOneShot(beatclip);
                Destroy(hit.gameObject);
            }
        }

        /*if (hit.gameObject.CompareTag("ball"))
        {
            Debug.Log(3);
            audioSource.PlayOneShot(damagedclip);
            Destroy(hit.gameObject);
            int damage = 10;

            currentHp = currentHp - damage; ;
            slider.value = (float)currentHp / (float)maxHp;
        }*/

    
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("ball"))
        {
            //Debug.Log(3);
            audioSource.PlayOneShot(damagedclip);
            Destroy(hit.gameObject);
            int damage = 10;

            currentHp = currentHp - damage; ;
            slider.value = (float)currentHp / (float)maxHp;
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
