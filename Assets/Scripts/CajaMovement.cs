using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 
public class CajaMovement : MonoBehaviour
{
    public float velocidadCaida = 3f;
    public float incrementoVelocidad = 1f;
    public TextMeshProUGUI tiempoTexto;
 
    private float tiempoTranscurrido = 0f;
    private bool juegoActivo = true;
    private Rigidbody rb;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;
    }
 
    void Update()
    {
        if (!juegoActivo) return;
 
        // Caida recta hacia abajo
        transform.position += Vector3.down * velocidadCaida * Time.deltaTime;
 
        // Tiempo en pantalla
        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTexto != null)
            tiempoTexto.text = "Tiempo: " + tiempoTranscurrido.ToString("F2");
    }
 
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Piso"))
        {
            velocidadCaida += incrementoVelocidad;
 
            float x = Random.Range(-8f, 8f);
            transform.position = new Vector3(x, 8f, 0f);
 
            rb.velocity = Vector3.zero;
        }
 
        if (col.gameObject.CompareTag("Player"))
        {
            juegoActivo = false;
            rb.velocity = Vector3.zero;
 
            if (tiempoTexto != null)
                tiempoTexto.text = "¡FIN! Tiempo: " + tiempoTranscurrido.ToString("F2");
 
            Destroy(col.gameObject);
        }
    }
}