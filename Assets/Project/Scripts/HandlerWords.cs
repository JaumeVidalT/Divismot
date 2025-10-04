using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandlerWords : MonoBehaviour
{
    private Palabra palabraActual= new Palabra();
    [SerializeField]private TMP_Text palabra;
    [SerializeField] private GameObject prefabButton;
    private int numeroCortesRealizados=0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        palabraActual.Init("HOLA", new List<int> { 1,5});
        palabra.text = palabraActual.GetPalabra();
        

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
    public void AddCortes(int posicion)
    {
       palabraActual.AddCortes(posicion);
       numeroCortesRealizados++;
    }
}
