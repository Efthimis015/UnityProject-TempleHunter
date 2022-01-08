using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{



    public int index;
    public string levelName;

    public Image black;
    public Animator anim;

    [SerializeField] private AudioSource FireSoundNPC;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //StartCoroutine(Wait());
            StartCoroutine(Fading());
            //SceneManager.LoadScene(index);
            //SceneManager.LoadScene(levelName);
            



        }
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
        FireSoundNPC.Play();






        //void FireSounds()
        //{

        //           StartCoroutine(FireSound());
        //     }

        //   public IEnumerator FireSound()
        //{
        // // /   yield return new WaitForSeconds(0.4f);
        // FireSoundNPC.Play();



        //}

        //private IEnumerator Wait()
        //{
        // yield return new WaitForSeconds(2);
        //}

    }
}