using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaPlataforma : MonoBehaviour
{
    [SerializeField] private GameObject chao, moeda;
    [SerializeField] private float tamanhoXZ;
    [SerializeField] private Vector3 posUltima;
    [SerializeField] private int limitChao;
    
    public static int chaoNumCena;
    
    // Start is called before the first frame update
    void Start()
    {
        //definir valor para ultima posição 
        posUltima = chao.transform.position;
        tamanhoXZ = chao.transform.localScale.x;
        chaoNumCena = 0;
        StartCoroutine("CriaPlataformaInGame");

        for (int i = 0; i < 10; i ++)
        {
             //CriaX();
            CriaChaoXZ();
             
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CriaX()
    {
        Vector3 tempPos = posUltima;
        tempPos.x += tamanhoXZ;
        posUltima = tempPos;
        Instantiate (chao, tempPos, Quaternion.identity);

        //criar moeda
        int rand = Random.Range(0,5);

        if(rand <=1)
        {
            Instantiate(moeda, new Vector3(tempPos.x,tempPos.y + 0.2f,tempPos.z), moeda.transform.rotation);
        }
    }
    void CriaZ()
    {
        Vector3 tempPos = posUltima;
        tempPos.z += tamanhoXZ;
        posUltima = tempPos;
        Instantiate (chao, tempPos, Quaternion.identity);

         //criar moeda
        int rand = Random.Range(0,5);

        if(rand <=1)
        {
            Instantiate(moeda, new Vector3(tempPos.x,tempPos.y +0.2f,tempPos.z), moeda.transform.rotation);
        }
    }
    //criar cho em x ou z
    void CriaChaoXZ()
    {
        int temp = Random.Range(0, 10);
        
        if(chaoNumCena < limitChao)
        {
            //verificar valores
            if(temp < 5)
            {
                CriaX();
                chaoNumCena++;
            }
            else if(temp >= 5)
            {
                CriaZ();
                chaoNumCena++;
            }
        }
    }
    IEnumerator CriaPlataformaInGame()
    {
        //enqunto nao der game over o chao vai contituar sendo construido
        while(BolaControlador.gameOver != true)
        {
            yield return new WaitForSeconds (0.2f);
            CriaChaoXZ();
        }
    }
}
