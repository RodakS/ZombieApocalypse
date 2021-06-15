using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Text textUI;

    public Text textSpell1;

    public Text textSpell2;
    public int enemiesCount;
    public int enemiesKilled ;
    private void Start()
    {
        enemiesCount = 0;
        enemiesKilled = 0;
    }
    void Update()
    {
        textUI.text = "Enemies: " + enemiesCount + "\n" + "Enemies killed:" + enemiesKilled;
        textSpell1.text.ToUpper();
        textSpell2.text.ToUpper();
    }


}
