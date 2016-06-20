using UnityEngine;
using System.Collections;

public class ObjetivoDTO : MonoBehaviour {

    private int puntos;

    private float tiempoTotal;

    public ObjetivoDTO()
    {
        this.puntos = 0;
        this.tiempoTotal = 60;
    }

    public ObjetivoDTO( int puntos, float tiempoTotal )
    {
        this.puntos = puntos;
        this.tiempoTotal = tiempoTotal;
    }

    public int getPuntos()
    {
        return puntos;
    }

    public void setPuntos(int puntos)
    {
        this.puntos = puntos;
    }

    public float getTiempoTotal()
    {
        return tiempoTotal;
    }

    public void setTiempoTotal(float tiempoTotal)
    {
        this.tiempoTotal = tiempoTotal;
    }
}
