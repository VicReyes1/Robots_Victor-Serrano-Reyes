using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRandom : MonoBehaviour
{
    public GameObject Cyborg;
    public GameObject Box;
    private int clonesR = 10;
    private int clonesC = 10;
    GameObject[] agents;
    float[,] P = new float[15, 3];
    // Start is called before the first frame update
    void Start()
    {
        int numOfAgents = clonesR + clonesC;
        agents = new GameObject[numOfAgents];
        float posX, posZ;
         for (int i = 0; i < numOfAgents; i++)
        {
            posX = UnityEngine.Random.Range(-3.0f, 3.0f);
            posZ = UnityEngine.Random.Range(-3.0f, 3.0f);
            P[i, 0] = posX;
            P[i, 1] = 0f;
            P[i, 2] = posZ;

            if (i < clonesR)
            {
                agents[i] = Instantiate(Cyborg, new Vector3(posX, 0f, posZ), Quaternion.identity);
            }
            else
            {
                agents[i] = Instantiate(Box, new Vector3(posX, .2f, posZ), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
         for (int s = 0; s < clonesR; s++)
        {
            int opc;
            float px = 0f, pz = 0f, step = 0.2f;
            opc = UnityEngine.Random.Range(1, 8);
            switch (opc)
            {
                case 1: px = -step; pz = -step; break;
                case 2: px = 0f; pz = -step; break;
                case 3: px = step; pz = -step; break;
                case 4: px = -step; pz = 0f; break;
                case 5: px = step; pz = 0f; break;
                case 6: px = -step; pz = step; break;
                case 7: px = 0f; pz = step; break;
                case 8: px = step; pz = step; break;
            }

            P[s, 0] += px;
            P[s, 2] += pz;
            agents[s].transform.localPosition = new Vector3(P[s, 0], P[s, 1], P[s, 2]);

          

        }
        
    }
}
