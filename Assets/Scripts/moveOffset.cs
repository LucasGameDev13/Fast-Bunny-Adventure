using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffset : MonoBehaviour
{
    //Variáveis para controle background
    private Renderer _meshRender;
    private Material currentMaterial;
    private float offSet;
    public float incrementoOffset;
    public float vel;
    public string sortingLayer;
    public int orderLayer;

    // Start is called before the first frame update
    void Start()
    {
       
        //Acessando os componentes do Renderer
        //Acessando os materiais do mesh Renderer
        _meshRender = GetComponent<Renderer>();
        currentMaterial = _meshRender.material;

        //Acessando as ordens das layer e seus tipos
        _meshRender.sortingLayerName = sortingLayer;
        _meshRender.sortingOrder = orderLayer;
    }

    // Update is called once per frame
    void Update()
    {
        //Incrementando o Offset
        offSet += incrementoOffset;

        //Aplicando a variável offset no offset do material
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(vel * offSet, 0));
    }
}
