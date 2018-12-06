using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gene_Manager : MonoBehaviour {

    public GameObject[] Kyles;

    public class Gene
    {
        public int Hand_start_L;
        public int Hand_start_R;
        public int Hand_end_L;
        public int Hand_end_R;

        public Gene()
        {
            Hand_start_L = Random.Range(1,9);
            Hand_start_R = Random.Range(1, 9);
            Hand_end_L = Random.Range(1, 9);
            Hand_end_R = Random.Range(1, 9);
        }

        public Gene(int _s_L, int _s_R, int _e_L, int _e_R)
        {
            Hand_start_L = _s_L;
            Hand_start_R = _s_R;
            Hand_end_L = _e_L;
            Hand_end_R = _e_R;
        }

        public static Gene operator+(Gene G1, Gene G2)
        {
            int _s_L = getOne(G1.Hand_start_L, G2.Hand_start_L);
            int _s_R = getOne(G1.Hand_start_R, G2.Hand_start_R);
            int _e_L = getOne(G1.Hand_end_L, G2.Hand_end_L);
            int _e_R = getOne(G1.Hand_end_R, G2.Hand_end_R);

            return new Gene(_s_L, _s_R, _e_L, _e_R);
        }
    }

    public List<Gene> LGene = new List<Gene>();
    List<Gene> TGene = new List<Gene>();
    // Use this for initialization
    void Awake () {
        
        for(int i = 0; i < 10; i++)
        {
            LGene.Add(new Gene());
        }
	}

    public int[] Gene_pick = new int[4] {-1,-1,-1,-1};
    public int count = 0;
    void Crossover()
    {
        int seed_A = Random.Range(0, 4);
        int seed_B;
        do
        {
            seed_B = Random.Range(0, 4);

        } while (seed_A == seed_B);

        Gene child = TGene[Gene_pick[seed_A]] + TGene[Gene_pick[seed_B]];

        int mu_percent = Random.Range(0, 5);
        while(mu_percent == 0)
        {
            mutation(child);
            mu_percent = Random.Range(0, 5);
        }

        LGene.Add(child);
    }

    void mutation(Gene child)
    {
        int i = Random.Range(0, 4);
        switch (i)
        {
            case 0:
                child.Hand_start_L = Random.Range(1, 9);
                break;
            case 1:
                child.Hand_start_R = Random.Range(1, 9);
                break;
            case 2:
                child.Hand_end_L = Random.Range(1, 9);
                break;
            case 3:
                child.Hand_end_R = Random.Range(1, 9);
                break;
        }


    }

    public static int getOne(int A, int B)
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
            return A;
        else
            return B;
    }

    public void levelup()
    {
       // TGene = LGene;
        foreach(Gene i in LGene)
        {
            TGene.Add(i);
        }
        LGene.Clear();

        for (int i = 0; i < 10; i++)
            Crossover();

        for(int i=0; i<Gene_pick.Length; i++)
        {
            Gene_pick[i] = -1;
        }

        count = 0;

        foreach(GameObject kyle in Kyles)
        {
           kyle.GetComponent<Mapping>().refresh();
        }        
    }
}
