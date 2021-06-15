using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int hpPlayer=1;
    public GameObject playerObject;
    public GameObject bulletObject;
    public GameObject goBackToMenuButton;
    public GameObject timeText;
    private float Timer = 0;
    private void Start()
    {
        Color myColor = new Color();
        ColorUtility.TryParseHtmlString("#3600FF", out myColor);

        playerObject.GetComponent<MeshRenderer>().material.color = myColor;

    }


    private void Update()
    {
        var dirrection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dirrection.y, dirrection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.down);

        if (Input.GetKeyDown(KeyCode.Mouse0)&&hpPlayer>0)
        {
            GameObject newbulletObject;
            newbulletObject = Instantiate(bulletObject, playerObject.transform.position, playerObject.transform.rotation);

            Rigidbody tmpRigidBody;
            tmpRigidBody = newbulletObject.GetComponent<Rigidbody>();
            tmpRigidBody.velocity = transform.forward * 40;

            Destroy(newbulletObject, 2);
        }

        Timer += Time.deltaTime;


    }
    public void ChangePlayerHP()
    {
        hpPlayer -= 50;
        if (hpPlayer <= 0)
        {
            Time.timeScale = 0;

            goBackToMenuButton.SetActive(true);
            timeText.SetActive(true);
            timeText.GetComponent<Text>().text = "Time: " + Timer;
        }
    }
}

