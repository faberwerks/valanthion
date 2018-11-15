using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaFilling : MonoBehaviour
{

    private Player player;

    [SerializeField] // show image field on inspector
    private Image content;

    [SerializeField] // show fill amount field on inspector
    private float fill;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        fill = player.Stamina * 0.01f;
        FillBar();
    }

    // a method to fill bar
    public void FillBar()
    {
        content.fillAmount = fill;
    }
}
