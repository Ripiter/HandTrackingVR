using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MovingPlayer : MonoBehaviour
{
    public GameObject playerObj;
    public OVRHand handLeft;
    public OVRHand handRight;

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    string message;
    // Update is called once per frame
    void Update()
    {
        bool isIndexFingerPinching = handLeft.GetFingerIsPinching(OVRHand.HandFinger.Index);
        bool isThumbFingerPinching = handLeft.GetFingerIsPinching(OVRHand.HandFinger.Thumb);
        //float ringFingerPinchStrength = handLeft.GetFingerPinchStrength(HandFinger.Ring);

        if (isIndexFingerPinching)
            message = "Index finger pinching";

        if (isThumbFingerPinching)
            message += " Thumb finger pinching";


        Saver.instance.textMessage.text = message;

        //playerObj.transform.position += transform.forward * Time.deltaTime * speed;
    }
}
