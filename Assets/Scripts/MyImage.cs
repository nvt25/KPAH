using System;
using UnityEngine;

public class MyImage
{
	public Image me;

	public int x;

	public int y;

	public int w;

	public int h;

	public int sumH;

	public int sumC;

	public SonImage[] arrImg2;

	public SonImage[][] arrImg;

	public int[][] xTex;

	public int[][] yTex;

	public Image[][] imgScr;

	public Image emty;

	public MyImage()
	{
	}

	public MyImage(int w, int h)
	{
	}

	public void setInfo(int w0, int h0)
	{
		w = w0;
		h = h0;
		me = Image.createImage(w, h);
		int num = w / 16;
		int num2 = h / 16;
		xTex = new int[num][];
		yTex = new int[num][];
		for (int i = 0; i < num; i++)
		{
			xTex[i] = new int[num2];
			yTex[i] = new int[num2];
		}
		imgScr = new Image[num][];
		for (int j = 0; j < num; j++)
		{
			imgScr[j] = new Image[num2];
		}
		for (int k = 0; k < num; k++)
		{
			for (int l = 0; l < num2; l++)
			{
				imgScr[k][l] = new Image();
				xTex[k][l] = -1;
				yTex[k][l] = -1;
			}
		}
		emty = Image.createImage(16, 16);
	}

	public void getImg(int x, int y, Image scr, int indexa, int indexb)
	{
		if (scr != null)
		{
			imgScr[indexa][indexb] = scr;
		}
		else
		{
			imgScr[indexa][indexb] = emty;
		}
		xTex[indexa][indexb] = x;
		yTex[indexa][indexb] = y;
	}

	public void getTexture()
	{
		int num = w / 16;
		int num2 = h / 16;
		try
		{
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					me.texture.SetPixels(xTex[i][j], yTex[i][j], 16, 16, imgScr[i][j].texture.GetPixels());
				}
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError(" loi roi" + ex.StackTrace);
		}
		me.texture.Apply();
	}
}
