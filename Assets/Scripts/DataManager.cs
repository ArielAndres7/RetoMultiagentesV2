using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    private Carro[] _carros;

    private GameObject[] _carrosGO;

    [SerializeField]
    private GameObject[] _semafs;

    Color color0 = Color.green;

    Color color1 = Color.yellow;

    Color color2 = Color.red;

    private int tam = 0;

    private int carPorCarril = 0;

    // Start is called before the first frame update
    void Start()
    {
        _carrosGO = new GameObject[_carros.Length];

        for (int i = 0; i < _carros.Length; i++)
        {
            _carrosGO[i] = CarPoolManager.Instance.ActivarObjeto(Vector3.zero);
        }

        PosicionarCarros();
    }

    private void PosicionarCarros()
    {
        print (carPorCarril);
        int r1 = carPorCarril - 1;
        int r2 = (carPorCarril * 2) - 1;
        int r3 = (carPorCarril * 3) - 1;
        int r4 = (carPorCarril * 4) - 1;
        for (int i = 0; i < _carros.Length; i++)
        {
            if ((_carros[i].id >= 0) & (_carros[i].id <= r1))
            {
                print("Carril 1");
                _carrosGO[i].transform.position =
                    new Vector3(_carros[i].x, 1.35f, _carros[i].z + 7);
                _carrosGO[i].transform.rotation =
                    Quaternion.Euler(new Vector3(270, 0, 0));
            }
            else if ((_carros[i].id >= r1) & (_carros[i].id <= r2))
            {
                print("Carril 2");
                print(_carros[i].id);
                print (carPorCarril);

                _carrosGO[i].transform.position =
                    new Vector3(_carros[i].x, 1.35f, _carros[i].z - 12);
                _carrosGO[i].transform.rotation =
                    Quaternion.Euler(new Vector3(270, 0, 0));
            }
            else if ((_carros[i].id >= r2) & (_carros[i].id <= r3))
            {
                print("Carril 3");
                print(_carros[i].id);
                print (carPorCarril);
                _carrosGO[i].transform.position =
                    new Vector3(_carros[i].x + 20, 1.35f, _carros[i].z);
                _carrosGO[i].transform.rotation =
                    Quaternion.Euler(new Vector3(270, 0, 0));
            }
            else if ((_carros[i].id >= r3) & (_carros[i].id <= r4))
            {
                print("Carril 4");
                print(_carros[i].id);
                print (carPorCarril);
                _carrosGO[i].transform.position =
                    new Vector3(_carros[i].x - 19, 1.35f, _carros[i].z);
                _carrosGO[i].transform.rotation =
                    Quaternion.Euler(new Vector3(270, 0, 0));
            }

            if (_carros[i].dir == 0)
            {
                _carrosGO[i].transform.rotation =
                    Quaternion.Euler(new Vector3(270, 180, 0));
            } // Este
            else if (_carros[i].dir == 2)
            {
                _carrosGO[i].transform.rotation =
                    Quaternion.Euler(new Vector3(270, 90, 0));
            } // Oeste
            else if (_carros[i].dir == 3)
            {
                _carrosGO[i].transform.rotation =
                    Quaternion.Euler(new Vector3(270, 270, 0));
            }

            //Semaforos 1
            if (_carros[i].semStateColor1 == 0)
            {
                _semafs[2].GetComponent<Light>().color = color0;
                _semafs[3].GetComponent<Light>().color = color0;
            }
            else if (_carros[i].semStateColor1 == 1)
            {
                _semafs[2].GetComponent<Light>().color = color1;
                _semafs[3].GetComponent<Light>().color = color1;
            }
            else if (_carros[i].semStateColor1 == 2)
            {
                _semafs[2].GetComponent<Light>().color = color2;
                _semafs[3].GetComponent<Light>().color = color2;
            }

            //Semaforos 2
            if (_carros[i].semStateColor2 == 0)
            {
                _semafs[0].GetComponent<Light>().color = color0;
                _semafs[1].GetComponent<Light>().color = color0;
            }
            else if (_carros[i].semStateColor2 == 1)
            {
                _semafs[0].GetComponent<Light>().color = color1;
                _semafs[1].GetComponent<Light>().color = color1;
            }
            else if (_carros[i].semStateColor2 == 2)
            {
                _semafs[0].GetComponent<Light>().color = color2;
                _semafs[1].GetComponent<Light>().color = color2;
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
            tam = _carros.Length;
            carPorCarril = tam / 4;
            PosicionarCarros();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
