using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{
    [Header("Checagem Informações")]
    [SerializeField] private GameObject preencherText;
    [SerializeField] private GameObject invalidText;

    [Header("Informações enviadas")]
    [SerializeField] private GameObject formUI;
    [SerializeField] private GameObject receivedUI;


    private void Update()
    {
        if (SendData.invalido)
        {
            preencherText.SetActive(false);
            invalidText.SetActive(true);           
        }
        if (SendData.validado)
        {
            formUI.SetActive(false);
            receivedUI.SetActive(true);
        }
    }


}
