using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
   
    public float velocidade;
    public Animator anim;
    public Camera mainCamera;
    public float velocidadeCamera;
    public float velocidadeRotacaoCamera;
    public Vector3 cameraOffSet;

    float InputX; //A,D
    float InputZ; //W,S

    Vector3 direcao;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {   
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");
        direcao = new Vector3(InputX,0,InputZ);

        if(InputX != 0 || InputZ != 0)
        {
            var camrot = mainCamera.transform.rotation;
            camrot.x = 0;
            camrot.z = 0;

            transform.Translate(0,0,velocidade * Time.deltaTime);
            anim.SetBool("walk", true);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direcao) * camrot, 5 * Time.deltaTime);

        }
        if(InputX == 0 && InputZ == 0)
        {
            anim.SetBool("walk",false);
        }
    }
    private void Lateupdate()
    {
        var pos = transform.position - mainCamera.transform.forward * cameraOffSet.z + mainCamera.transform.up * cameraOffSet.y 
        + mainCamera.transform.right * cameraOffSet.x;

        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, pos, velocidadeCamera * Time.deltaTime);
    }
}
