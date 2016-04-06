using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private float time;
    public float speed;
    //reseta o speed
    public float retornaSpeed;
    public float VarRun;
    private float run;

    //material
    public Material matNovo;

   //vetor de obj
    public GameObject[] muros;

    //força de movimento
    private float forcaLado;
    private float forcaFrente;

    //velocidade de rotação pelo mouse
    public float forcMouse;

	// Use this for initialization
	void Start () {
        //leitura do frameRate
        time = Time.deltaTime;
        run =speed*VarRun;
	}
	
	// Update is called once per frame
	void Update () {
        //joystick mais setas do teclado
        forcaLado = Input.GetAxis("Horizontal") * speed * time;
        
        forcaFrente = 0;
        forcaLado = 0;

        if (Input.GetKey(KeyCode.Space))
            speed = run;
        else
            speed = retornaSpeed;
        //locomoção da posição do obj
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            //transform.position += new Vector3(0, 0, speed) * time;
            
            //desliga o render o obj
           /* if (GetComponent<MeshRenderer>().enabled)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
                GetComponent<MeshRenderer>().enabled = true;*/
            forcaFrente = speed * time;
        }
        if (Input.GetKey("down") || Input.GetKey("s")) { 
            //transform.position += new Vector3(0, 0, -speed) * time;
            forcaFrente = -speed * time;
        }
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            //transform.position += new Vector3(speed, 0, 0) * time;
            forcaLado = speed * time;
        }
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            //transform.position += new Vector3(-speed, 0, 0) * time;
            forcaLado = -speed * time;
        }
        //rotation
        if (Input.GetKey("q"))
        {
            transform.eulerAngles += new Vector3(0, -90, 0) * time;
        }
        //rotation
        if (Input.GetKey("e"))
        {
            transform.eulerAngles += new Vector3(0, 90, 0) * time;
        }
        if (Input.GetKey("h"))
        {
            //altera o material
            GetComponent<MeshRenderer>().material = matNovo;
            //muda uma propriedade de um obj que esta sendo indicado pelo GameObject.Find("xxx")
            GameObject.Find("Chao").GetComponent<MeshRenderer>().material = matNovo;

            muros = GameObject.FindGameObjectsWithTag("Muro");
            //percorre o vetor
            for (int i = 0; i < muros.Length; i++)
            {
                muros[i].GetComponent<MeshRenderer>().material = matNovo;
            }
        }

        //aplica movimento
        //via transfom.translate
        transform.Translate(new Vector3(forcaLado, 0, forcaFrente));

        //rotação com o Mouse X meche na horizontal e Mouse Y meche na vertical
        //transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X")*forcMouse, 0)*time;
        transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y") * forcMouse, Input.GetAxis("Mouse X") * forcMouse, 0) * time;
	}
    
}
