using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour {
    float speed = 0.1f;

    Transform player;
    Transform fire;
    Transform lightning;

    Transform activeGO;

    float rotationY = 0f;


    public float inputXFire = 0;

    public float inputYFire = 0;

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    public float mvSpeed = 0.02f;


    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag("Player").transform;
        fire = GameObject.FindWithTag("fireTag").transform;
        lightning = GameObject.FindWithTag("lightningTag").transform;

        activeGO = player;
    }

    // Update is called once per frame
    void Update() {

        if(Input.GetKey(KeyCode.A)) {

            Vector3 v = fire.GetChild(0).GetComponent<UnityEngine.VFX.VisualEffect>().GetVector3("pos") + new Vector3(-mvSpeed, 0, 0);
            fire.GetChild(0).GetComponent<UnityEngine.VFX.VisualEffect>().SetVector3("pos", v);

        }

        if(Input.GetKey(KeyCode.D)) {
            Vector3 v = fire.GetChild(0).GetComponent<UnityEngine.VFX.VisualEffect>().GetVector3("pos") + new Vector3(mvSpeed, 0, 0);
            fire.GetChild(0).GetComponent<UnityEngine.VFX.VisualEffect>().SetVector3("pos", v);
        }

        if(Input.GetKey(KeyCode.Z)) {
            Vector3 v = lightning.GetChild(0).GetComponent<UnityEngine.VFX.VisualEffect>().GetVector3("pos") + new Vector3(-mvSpeed, 0, 0);
            lightning.GetChild(0).GetComponent<UnityEngine.VFX.VisualEffect>().SetVector3("pos", v);
            lightning.GetChild(1).transform.position = v;
        }


        if(Input.GetKey(KeyCode.C)) {
            Vector3 v = lightning.GetChild(0).GetComponent<UnityEngine.VFX.VisualEffect>().GetVector3("pos") + new Vector3(mvSpeed, 0, 0);
            lightning.GetChild(0).GetComponent<UnityEngine.VFX.VisualEffect>().SetVector3("pos", v);
            lightning.GetChild(1).transform.position = v;
        }


        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);


        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        transform.position = transform.position + new Vector3(
            inputX * speed * Mathf.Cos(transform.localEulerAngles.y * Mathf.PI / 180) + inputY * speed * Mathf.Sin(transform.localEulerAngles.y * Mathf.PI / 180),
            0,
            inputY * speed * Mathf.Cos(transform.localEulerAngles.y * Mathf.PI / 180) - inputX * speed * Mathf.Sin(transform.localEulerAngles.y * Mathf.PI / 180));




    }
}
