using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineMovement : MonoBehaviour
{
    [SerializeField]private Transform pointA, pointB,pointC,pointD,egg;
    private Vector3 lerpResult;
    private float interpolateAmount, timer = 0f;
    [SerializeField]SpriteRenderer sr;
    [SerializeField]Sprite []faces = new Sprite[2];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a,b,t);
        Vector3 bc = Vector3.Lerp(b,c,t);

        return Vector3.Lerp(ab,bc,interpolateAmount);
    }

    private Vector3 CubicLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d,float t)
    {
        Vector3 ab_bc = QuadraticLerp(a,b,c,t);
        Vector3 bc_cd = QuadraticLerp(b,c,d,t);

        return Vector3.Lerp(ab_bc,bc_cd,interpolateAmount);
    }

    // Update is called once per frame
    void Update()
    {
        /**
        interpolateAmount = (interpolateAmount + Time.deltaTime) % 1f;
        egg.position = CubicLerp(pointA.position, pointB.position, pointC.position, pointD.position, interpolateAmount)*2f;
        egg.eulerAngles = new Vector3(egg.eulerAngles.x, egg.eulerAngles.y-(5f * Time.deltaTime), egg.eulerAngles.z);
        if (egg.eulerAngles.y >= 360f)
            egg.eulerAngles = new Vector3(egg.eulerAngles.x, 0f, egg.eulerAngles.z);
        **/
        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            timer = 0f;
            sr.sprite = faces[Random.Range(0,2)];
        }
    }
}
