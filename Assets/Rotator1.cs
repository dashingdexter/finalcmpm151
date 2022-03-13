using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator1 : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		// this rotates each cube.
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);



		// animate the cube size based on sample data.
		int numPartitions = 50;
		float[] aveMag = new float[numPartitions];
		float partitionIndx = 0;
		int numDisplayedBins = 512 / 2; //NOTE: we only display half the spectral data because the max displayable frequency is Nyquist (at half the num of bins)

		for (int i = 0; i < numDisplayedBins; i++)
		{
			if (i < numDisplayedBins * (partitionIndx + 1) / numPartitions)
			{
				aveMag[(int)partitionIndx] += AudioPeer.spectrumData[i] / (512 / numPartitions);
			}
			else
			{
				partitionIndx++;
				i--;
			}
		}

		//scale and bound the average magnitude.
		for (int i = 0; i < numPartitions; i++)
		{
			aveMag[i] = (float)0.2 + aveMag[i] * 5000;
			if (aveMag[i] > 100)
			{
				aveMag[i] = 100;
			}
		}

		// Map the magnitude to the cubes based on the cube name.
		if (gameObject.name == "ball1")
		{
			transform.localScale = new Vector3(aveMag[0], aveMag[0], aveMag[0]);
		}
		for (int i = 0; i < 7; i++)
		{
			int index = i + 100;
			if (gameObject.name == "ball1 (" + index + ")")
			{
				transform.localScale = new Vector3(aveMag[1], aveMag[1], aveMag[1]);
			}
		}



	}


}

