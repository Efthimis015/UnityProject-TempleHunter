using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class NewStart : MonoBehaviour
{


    

    // Start is called before the first frame update
    public void Nstart()
    {
        StartCoroutine(DeathCal());

    }

    public void Quitt()
    {
        Application.Quit();
        Debug.Log("Quiting Game");


    }

    public IEnumerator DeathCal()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);



    }












}
