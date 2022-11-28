using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    private Carro[] _carros;

    private GameObject[] _carrosGO;

    // Start is called before the first frame update
    void Start()
    {
        _carrosGO = new GameObject[_carros.Length];

        for (int i = 0; i < _carros.Length; i++)
        {
            // Vector3 rotacion = new Vector3(0, 0, 0);
            // if (_carros[i].dir == 1)
            // {
            //     Vector3 rotacion = new Vector3(0, 180, 0);
            // }
            _carrosGO[i] = CarPoolManager.Instance.ActivarObjeto(Vector3.zero);
        }

        PosicionarCarros();
    }

    private void PosicionarCarros()
    {
        
        for (int i = 0; i < _carros.Length; i++)
        {
            _carrosGO[i].transform.position =
                new Vector3(_carros[i].x, 1.35f, _carros[i].z);
            _carrosGO[i].transform.rotation = Quaternion.Euler(new Vector3(270,0,0));
            if (_carros[i].dir == 0)
            {
                _carrosGO[i].transform.rotation = Quaternion.Euler(new Vector3(270,180,0));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        PosicionarCarros();
    }

    public void EscucharRequestSinArgumentos()
    {
        print("HUBO UN REQUEST MUY INTERESANTE!");
    }

    public void EscucharRequestConArgumentos(ListaCarros datos)
    {
        print("DATOS: " + datos);

        StartCoroutine(ConsumirSteps(datos));
    }

    private IEnumerator ConsumirSteps(ListaCarros datos)
    {
        for (int i = 0; i < datos.steps.Length; i++)
        {
            _carros = datos.steps[i].carros;
            PosicionarCarros();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
