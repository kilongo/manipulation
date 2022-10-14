using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeplacement : MonoBehaviour
{
    // Start is called before the first frame update
    private Text TextInfos;
    private bool Prend = false;
    private GameObject GoName;
    public int Force = 10;

    //La rotation du joueur
    public float deltaRotation;
    public float deltaTranslation;
    private Rigidbody rb;

    void Start()
    {
        TextInfos = GameObject.Find("TextMessage").GetComponent<Text>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Prend & GoName != null)
        {
            GoName.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            GoName.transform.position = GameObject.Find("LaMain").transform.position;
            GoName.gameObject.transform.parent = GameObject.Find("LaMain").transform;
        }
        //Le deplacement du jouer
        transform.Translate(Vector3.forward * 5f * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
        transform.Translate(Vector3.right * 5f * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));

        deltaRotation += Input.GetAxis("Mouse X");
        rb.MoveRotation(Quaternion.Euler(0, deltaRotation, 0));
        //deltaTranslation -= Input.GetAxis("Mouse Y");
        //rb.MoveRotation(Quaternion.Euler(deltaTranslation, deltaRotation, 0));

        if(Input.GetKeyDown(KeyCode.F) && GoName != null)
        {
            Lance();
        }
    }

    void Lance()
    {
        GoName.gameObject.transform.parent = null;
        GoName.gameObject.GetComponent<Rigidbody>().isKinematic = false;
       // GoName.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward * Force));

    }


    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Projectile")
        {
            TextInfos.text = "E pour ramasser, F pour deposer";
            GoName = Col.gameObject;
            Prend = true;
        }
    }

    void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "Projectile")
        {
            TextInfos.text = "";
            GoName = null;
            Prend = false;
        }
    }
}
