using UnityEngine;
using System.Collections;

public class ObjetivoPuntos : Objetivo
{
    private int puntosObjetivo;

    public ObjetivoPuntos(int puntosObjetivo)
    {
        this.puntosObjetivo = puntosObjetivo;
        this.cumplido = false;
    }

    public override bool verificarObjetivo(ObjetivoDTO dto)
    {
        calcularObjetivo(dto.getPuntos());

        return this.cumplido;
    }

    private void calcularObjetivo(int puntos)
    {
        if (puntos >= this.puntosObjetivo)
        {
            cumplido = true;
        }
    }

	public override string getNombreClase (){
		return this.name;
	}

	public int getPuntosObjetivo(){
		return puntosObjetivo;
	}
}
