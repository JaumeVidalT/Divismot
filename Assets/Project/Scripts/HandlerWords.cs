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
    private List<Palabra> EnciclopediaDePalabras = new List<Palabra>();
    [SerializeField]private int PalabrasGuardadas =20;
    [SerializeField] List<string> palabrasParaLaLista=new List<string>();
    [SerializeField] List<Corte> ValorCortes = new List<Corte>();
    private int palabraSeleccionada;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
               
        if (palabrasParaLaLista.Count < PalabrasGuardadas || ValorCortes.Count < PalabrasGuardadas)
        {
            Debug.LogError("Listas incompletas!");
            return; 
        }
        for(int i = 0; i < PalabrasGuardadas;i++)
        {
            Palabra newPalabra = new Palabra();
            newPalabra.Init(palabrasParaLaLista[i], ValorCortes[i].valores);
            EnciclopediaDePalabras.Add(newPalabra); 
        }
        palabraSeleccionada =Random.Range(0,PalabrasGuardadas-1);
        palabraActual = EnciclopediaDePalabras[palabraSeleccionada];
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
            NextWord();
        }
        
    }
    private void NextWord()
    {
        palabraSeleccionada++;
        palabraActual = EnciclopediaDePalabras[(palabraSeleccionada) % PalabrasGuardadas];
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
