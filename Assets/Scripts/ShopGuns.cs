using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGuns : MonoBehaviour
{
    // Start is called before the first frame update
    public int cash;

    public class CurrentGun
    {
        string title;
        string description;
        GameObject panelGun;
        GameObject modelGun;
        int price;
        bool isBought;
    }

    public CurrentGun currentGun;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}