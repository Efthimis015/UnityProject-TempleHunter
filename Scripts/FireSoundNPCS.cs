using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSoundNPCS : MonoBehaviour
{

    [SerializeField] private AudioSource FireSoundNPC;

    // Start is called before the first frame update
    void FireSounds()
    {
        
        StartCoroutine(FireSound());
    }

    public IEnumerator FireSound()
    {
        yield return new WaitForSeconds(0.4f);
        FireSoundNPC.Play();



    }





}
