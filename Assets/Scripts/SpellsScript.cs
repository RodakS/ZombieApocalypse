using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsScript : MonoBehaviour
{
    public GameObject SpellObject;
    public GameObject playerObject;
    public UI UIObject;
    private float fireStrikeTimer = 0.4f;
    private float iceBlastTimer = 0.8f;
    private void Update()
    {
        if (fireStrikeTimer > 0)
        {
            fireStrikeTimer -= Time.deltaTime;
            UIObject.textSpell1.text = fireStrikeTimer.ToString("0.0");
        }
        else UIObject.textSpell1.text = " ";
        if (iceBlastTimer > 0)
        {
            iceBlastTimer -= Time.deltaTime;
            UIObject.textSpell2.text = iceBlastTimer.ToString("0.0");
        }
        else UIObject.textSpell2.text = " ";

        if (Input.GetKeyDown(KeyCode.Alpha1)&& fireStrikeTimer <= 0)
        {
            FireStrike();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2 ) && iceBlastTimer <= 0)
        {
            IceBlast();
        }

    }

    public void FireStrike()
    {
        GameObject newFireStrikeObject;
        newFireStrikeObject = Instantiate(SpellObject, playerObject.transform.position, playerObject.transform.rotation);
        newFireStrikeObject.AddComponent<FireBlast>();
        Rigidbody tmpRigidBody;
        tmpRigidBody = newFireStrikeObject.GetComponent<Rigidbody>();
        tmpRigidBody.velocity = transform.forward * 15;

    
        Destroy(newFireStrikeObject, 5);
        fireStrikeTimer = 0.4f;
    }
    public void IceBlast()
    {
        GameObject newIceBlastObject;
        newIceBlastObject = Instantiate(SpellObject, playerObject.transform.position, playerObject.transform.rotation);
        newIceBlastObject.AddComponent<IceBlast>();
        Rigidbody tmpRigidBody;
        tmpRigidBody = newIceBlastObject.GetComponent<Rigidbody>();
        tmpRigidBody.velocity = transform.forward * 10;

        Destroy(newIceBlastObject, 7);
        iceBlastTimer = 0.8f;
    }
}
