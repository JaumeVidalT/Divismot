using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string playerWord;
    private int wordSize;
    private int wordOrder;
    private int letterPosition;
    [SerializeField] private List<Button> Desorderedbuttons=new List<Button>();
    [SerializeField] private List<Button> OrderedButtons=new List<Button>(); 
     private List<Word> wordManager = new List<Word>();
    void Start()
    {
        wordManager.Add(new Word("grocs", "grosc"));
        wordManager.Add(new Word("tardor", "radtro"));
        wordManager.Add(new Word("menjo", "jomne"));
        wordManager.Add(new Word("marrons", "srramon"));
        wordManager.Add(new Word("arribat", "batrira"));
        wordManager.Add(new Word("carrer", "rerarc"));
        wordManager.Add(new Word("torrem", "retorm"));
        wordManager.Add(new Word("bolets", "tlesob"));
        wordManager.Add(new Word("fulles", "sllfeu"));
        wordManager.Add(new Word("àvia", "viaà"));
        wordManager.Add(new Word("pressa", "sapres"));
        wordManager.Add(new Word("bosc", "csob"));
        wordManager.Add(new Word("tornem", "nemotr"));
        wordManager.Add(new Word("castanyes", "stacnesay"));
        wordManager.Add(new Word("cauen", "neuca"));
        wordManager.Add(new Word("fred", "rdef"));
        wordManager.Add(new Word("cacem", "mcaec"));

        wordOrder = 0;
        letterPosition = 0;
        wordSize = wordManager[wordOrder].GetCorrectWord().Length;
        for(int i = 0; i < wordSize; i++)
        {
            char letter = wordManager[wordOrder].GetDesorderedWord()[i];
            Desorderedbuttons[i].GetComponentInChildren<TextMeshProUGUI>().text = letter.ToString();
            char letterCopy = letter;
            Button btn = Desorderedbuttons[i];
            btn.onClick.AddListener(() => AddLetter(letterCopy));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (wordSize == playerWord.Length)
        {
            if (wordManager[wordOrder].CheckCorrectWord(playerWord))
            {
                Debug.Log("Victory");
            }  
            wordSize= wordManager[++wordOrder].GetCorrectWord().Length;
            SetNewButtons();
        }
    }

    void AddLetter(char letter)
    {
        OrderedButtons[letterPosition].gameObject.SetActive(true);
        OrderedButtons[letterPosition].GetComponent<Text>().text = letter.ToString() ;
        playerWord += letter;
    }
    void SetNewButtons()
    {
        for (int i = 0; i < wordSize; i++)
        {
            char letter = wordManager[wordOrder].GetDesorderedWord()[i];
            Desorderedbuttons[i].GetComponent<Text>().text = letter.ToString();

            Desorderedbuttons[i].GetComponent<UnityEvent>().AddListener(() => AddLetter(letter));
        }
    }
}
