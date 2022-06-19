using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDriving : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private void LateUpdate() { // Vsync problem fixing
        Vector3 delta = Vector3.zero;

        //this is to check if we are inside the bounds on the X asis
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX) {
            if (transform.position.x < lookAt.position.x)
            { //right or left
                delta.x = deltaX - boundX;
            }
            else{
                delta.x = deltaX + boundX;
            }
        }

        //this is to check if we are inside the bounds on the X asis
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            { //right or left
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
