using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public Text tiempoTexto;
    private float tiempo;

    void Update()
    {
        tiempo += Time.deltaTime;
        tiempoTexto.text = "Tiempo: " + tiempo.ToString("F2");

    }
}
