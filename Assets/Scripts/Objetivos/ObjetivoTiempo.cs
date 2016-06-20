using UnityEngine;
using System.Collections;

public class ObjetivoTiempo : Objetivo {

    private float tiempoObjetivo;
    
    public ObjetivoTiempo(float tiempoObjetivo)
    {
        this.tiempoObjetivo = tiempoObjetivo;
        this.cumplido = false;
    }

    public override bool verificarObjetivo(ObjetivoDTO dto)
    {
        calcularObjetivo(dto.getTiempoTotal());

        return this.cumplido;
    }

    private void calcularObjetivo(float tiempo)
    {
        if (tiempo <= 0)
        {
            cumplido = true;
        }
    }

	public override string getNombreClase (){
		return this.name;
	}

	public float getTiempoObjetivo(){
		return tiempoObjetivo;
	}
}
