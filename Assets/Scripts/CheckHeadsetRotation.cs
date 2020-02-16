using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Oculus;
using OculusSampleFramework;

public class CheckHeadsetRotation : MonoBehaviour
{
    public Text debugText;
    public Text debugText2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform head = GetComponent<OVRCameraRig>().centerEyeAnchor;
        //debugText.text = head.rotation.ToString();
        //debugText2.text = head.rotation.eulerAngles.ToString();
    }
}
