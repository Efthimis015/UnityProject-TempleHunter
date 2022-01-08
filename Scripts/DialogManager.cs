using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject DialogBox;
    [SerializeField] Text DialogText;
    [SerializeField] int lettersPerSecond;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    public void ShowDialog(Dialog dialog)
    {
        DialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));


    }

    public IEnumerator TypeDialog(string line)
    {
        DialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            DialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);

        }
    }
}

