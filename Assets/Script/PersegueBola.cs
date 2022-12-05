using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersegueBola : MonoBehaviour
{
    //ter acesso a variavel, dentro do inspector
    [SerializeField] private Transform bolinha;
    [SerializeField] private Vector3 dist;
    [SerializeField] private float lerpVal;
    [SerializeField] private Vector3 pos, alvoPos;


    // Start is called before the first frame update
    void Start()
    {
        dist = bolinha.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //(LateUpdate depois que tudo foi carregado 
    void LateUpdate()
    {
        if(!BolaControlador.gameOver)
        {
            PersegueFunc();
        }
    }
    void PersegueFunc()
    {
        //posição da camera
        pos = transform.position;
        //posição do alvo
        alvoPos =  bolinha.position - dist;
        //novo valor da pos
        pos = Vector3.Lerp(pos, alvoPos, lerpVal);
        transform.position = pos;
    }

}
