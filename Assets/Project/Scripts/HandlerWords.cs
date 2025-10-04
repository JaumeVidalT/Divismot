using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandlerWords : MonoBehaviour
{
    private Palabra palabraActual= new Palabra();
    [SerializeField]private TMP_Text palabra;
    private int numeroCortesRealizados=0;
    [SerializeField]private float sizeWord=0.15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        palabraActual.Init("HOLA", new List<int> { 1,5});
        palabra.text = palabraActual.GetPalabra();
        setFillWord();



    }

    // Update is called once per frame
    void Update()
    {
        if(numeroCortesRealizados== palabraActual.GetNumeroCortes())
        {
            if (palabraActual.CommpairCortes())
            {
                Debug.Log("win");
            }
            else
            {
                Debug.Log("Loser");
            }
        }
        
    }
    private void setFillWord()
    {
        Image imagenActual= this .GetComponent<Image>();
        imagenActual.fillAmount = 0;
        for (int i = 0; i < palabraActual.GetPalabra().Length; i++)
        {
            imagenActual.fillAmount += sizeWord;
        }
    }
    public void AddCortes(int posicion)
    {
       palabraActual.AddCortes(posicion);
       numeroCortesRealizados++;
    }
}
