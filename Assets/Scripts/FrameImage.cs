public class FrameImage
{
	public short frameWidth;

	public short frameHeight;

	public short nFrame;

	public Image imgFrame;

	public FrameImage()
	{
	}

	public FrameImage(Image img, int width, int height)
	{
		imgFrame = img;
		frameWidth = (short)width;
		frameHeight = (short)height;
		nFrame = (short)(img.getHeight() / height);
	}

	public static FrameImage init(string path, int w, int h)
	{
		return new FrameImage(FilePack.getImg(path), w, h);
	}

	public void drawFrame(int idx, int x, int y, int trans, int orthor, MyGraphics g)
	{
		if (imgFrame != null)
		{
			g.drawRegion(imgFrame, 0, idx * frameHeight, frameWidth, frameHeight, trans, x, y, orthor);
		}
	}
}
