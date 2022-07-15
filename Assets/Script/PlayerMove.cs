using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float mSppeed;
    public Camera m_Camera;
    public float fRotateSensitivity = 1.0f;
    private float fCurrentRotateAngle = 0.0f;
    private Vector3 horizontalVector;
    public Rigidbody m_RB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float fMX = Input.GetAxis("Mouse X");
        float fMY = -Input.GetAxis("Mouse Y");
        transform.Rotate(0, fMX * fRotateSensitivity, 0);
        horizontalVector = transform.forward;
        fCurrentRotateAngle += fMY;
        if (fCurrentRotateAngle > 45.0f)
        {
            fCurrentRotateAngle = 45.0f;
        }
        else if (fCurrentRotateAngle < -45.0f)
        {
            fCurrentRotateAngle = -45.0f;
        }

        Vector3 newFor = Quaternion.AngleAxis(fCurrentRotateAngle, transform.right) * horizontalVector;
        m_Camera.transform.forward = newFor;

        //float fH = Input.GetAxis("Horizontal");
        //float fV = Input.GetAxis("Vertical");


        //float fMoveAmount = mSppeed * Time.deltaTime;
        //Vector3 vMoveH = transform.right * fH;
        //Vector3 vMoveV = transform.forward * fV;
        //transform.position = transform.position + (vMoveH + vMoveV) * fMoveAmount;
        MoveByVelocity();
    }
    void MoveByVelocity() 
    {
        float fH = Input.GetAxis("Horizontal");
        float fV = Input.GetAxis("Vertical");
        Vector3 vMoveH = transform.right * fH;
        Vector3 vMoveV = transform.forward * fV;
        Vector3 vMove=(vMoveH + vMoveV)*mSppeed;
        Vector3 vel = m_RB.velocity;
        vMove.y = vel.y;
        m_RB.velocity =vMove;
    }
 
}
