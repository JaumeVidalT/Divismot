using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Palabra
{
    private string palabra;
    private List<int> cortesCorrectos;
    private List<int> cortesInput;
    public void Init(string _palabra, List<int> _cortesCorrectos)
    {
        palabra = _palabra;
        cortesCorrectos = _cortesCorrectos;
        cortesInput = new List<int>();
    }

    public bool CommpairCortes()
    {
        if (cortesCorrectos.Count > cortesInput.Count) return false;
        for (int i = 0; i < cortesCorrectos.Count; i++)
        {
            if (cortesCorrectos[i] != cortesInput[i])
            {
                return false;
            }
        }
        return true;//Como si no detecta nada mal puede seguir

    }
    public int GetNumeroCortes() {  return cortesCorrectos.Count; }
    public string GetPalabra() { return palabra; }

    public void AddCortes(int value) { cortesInput.Add(value); }
    
       

}

