using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefab������
    public GameObject carPrefab;
    //coinPrefab������
    public GameObject coinPrefab;
    //cornPrefab������
    public GameObject conePrefab;

    public GameObject unitychan;

    float[] spPos = new float[19];
    //�X�^�[�g�n�_
    private int startPos = 80;
    //�S�[���n�_
    private int goalPos = 360;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;

    bool[] sporn = new bool[19];

    // Use this for initialization
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");

        for (int i = 0; i < spPos.Length; i ++)
        {
            spPos[i] = 80 + 15 * i;
            Debug.Log(spPos[i]);
        }
        for (int i = 0; i < sporn.Length; i++)
        {
            Debug.Log(sporn[i]);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
       for( int i= 0; i < spPos.Length; i++)
        {
            if (unitychan.transform.position.z + 45 >= spPos[i] && sporn[i] == false)
            {
                //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //�R�[����x�������Ɉ꒼���ɐ���
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, spPos[i]);
                    }
                }
                else
                {

                    //���[�����ƂɃA�C�e���𐶐�
                    for (int j = -1; j <= 1; j++)
                    {
                        //�A�C�e���̎�ނ����߂�
                        int item = Random.Range(1, 11);
                        //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                        int offsetZ = Random.Range(-5, 6);
                        //60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                        if (1 <= item && item <= 6)
                        {
                            //�R�C���𐶐�
                            GameObject coin = Instantiate(coinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, spPos[i] + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //�Ԃ𐶐�
                            GameObject car = Instantiate(carPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, spPos[i] + offsetZ);
                        }
                    }
                    Debug.Log("sporn at " + spPos[i]);
                }
                sporn[i] = true;
                
            }
        }
    }
}


