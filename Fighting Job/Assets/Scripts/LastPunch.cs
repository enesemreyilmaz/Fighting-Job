using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPunch : MonoBehaviour
{
    public Animator enemyAnim;
    public Animator playerAnim;
    public ParticleSystem hitEffect;
    public Transform[] Hand;
    public int handIndex;
    
    public void LastPunchh()
    {
        enemyAnim.SetTrigger("hit");
    }

    public void FastPunchParticleEffectLeft()
    {
        
            Instantiate(hitEffect,Hand[0].transform.position + new Vector3(0.4f,0,0),Quaternion.identity);
            hitEffect.Play();
        
        
    }

    public void FastPunchParticleEffectRight()
    {
        Instantiate(hitEffect,Hand[1].transform.position + new Vector3(0.4f,0,0),Quaternion.identity);
        hitEffect.Play();
    }
}
