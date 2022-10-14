using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMouvement : MonoBehaviour
{
    // Start is called before the first frame update
    private Text TextInfos;
    private bool Prend = false;
    private GameObject GoName;
    public int Force = 1500;
   

     void Start()
    {
        TextInfos = GameObject.Find("TextMessage").GetComponent<Text>();
        //Pour la visibilite du curseur
       


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

        //Pour la camera

      

    }

    void FixedUpdate()
    {

       transform.Translate(Vector3.forward * 5f * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
        transform.Translate(Vector3.right * 5f * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));

        

    }

   /* void UpdateaMouseLock()
    {
        Vector2.mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.Rotate(Vector3.up * mouseDelta.x);
    }*/
    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Projectile")
        {
            TextInfos.text = "E pour ramasser";
            GoName = Col.gameObject;
            Prend = true;
        }
    }

    void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "Projectile")
        {
            TextInfos.text = "ERRRRR";
            GoName = null;
            Prend = false;
        }
    }
}
