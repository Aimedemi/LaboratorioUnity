using UnityEngine;
using System.Collections;

public class PhysicsController : MonoBehaviour{
    DesktopPhysics desktopMove = new DesktopPhysics();
    MobilePhysics mobileMove = new MobilePhysics();


    public void moverse(Rigidbody rb, float speed)
    {
        //Movimientos en PC
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            desktopMove.moverse(rb, speed);
        }
        // Movimiento en dispositivos mobile
        else
        {
            mobileMove.moverse(rb, speed);
        }
    }
}