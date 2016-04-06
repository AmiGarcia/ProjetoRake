using UnityEngine;
using System.Collections;

public class MoviFisic : MonoBehaviour {
    float forca_frente;
    float forca_lado;
    float forca_basica = 800;

    public int pontos = 0;
    public int energia = 100;

    GameObject[] muros;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Input via GetAxis
        forca_lado = Input.GetAxis("Horizontal") * forca_basica * Time.deltaTime;
        forca_frente = Input.GetAxis("Vertical") * forca_basica * Time.deltaTime;

        //APLICAR MOVIMENTO - via Rigidbody
        //AddForce = forcas pelo eixo do mundo
        GetComponent<Rigidbody>().AddForce(new Vector3(forca_lado, 0, forca_frente));

	}

    //rigidbody entrou em colisao
    void OnCollisionEnter(Collision colisao)
    {
        string name;
        name = colisao.gameObject.tag;
        
        if (name == "Moeda")
        {
            pontos += 2;
            Destroy(colisao.gameObject);
            Debug.Log("pontos em: " + pontos);
        }
                 

        if (name == "Enemi")
        {
            energia -= 10;
            Destroy(colisao.gameObject);
            Debug.Log("energia : " + energia);
        }
    }
    //Colisão com Trigger
    void OnTriggerEnter(Collider colisao)
    {
        string nome = colisao.gameObject.name;
        if (nome == "Portal")
        {
            Debug.Log("Colide trigger");
            //recebe position do obj de saida
            transform.position = GameObject.Find("SaidaPortal").transform.position;
            //recebe rotacion do obj de saida
            transform.rotation = GameObject.Find("SaidaPortal").transform.rotation;

            //zerar a velocidade
            GetComponent<Rigidbody>().velocity=Vector3.zero;

        }
    }
}
