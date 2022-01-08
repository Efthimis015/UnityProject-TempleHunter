using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{
    public int iLevelToLoad;
    public string sLevelToLoad;
    //public Image black;
    //public Animator anim;
    //public int index;

    public bool useIntegerToLoadLevel = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player")
        {
           // StartCoroutine(Fading());
            LoadScene();
        }

        void LoadScene()
        {
            if (useIntegerToLoadLevel)
            {
                SceneManager.LoadScene(iLevelToLoad);
            }
            else
            {
                SceneManager.LoadScene(sLevelToLoad);
            }
        }


    }
    //IEnumerator Fading()
    //{
      //  anim.SetBool("Fade", true);
        //yield return new WaitUntil(() => black.color.a == 1);
        //SceneManager.LoadScene(index);

    //}

}
