using System.Drawing.Text;

namespace ColorModels {
	public partial class Form1 : Form {
		bool buttonPlusActive = false;
		bool buttonMinusActive = false;

		string tempR = "0";
		string tempG = "0";
		string tempB = "0";

		string tempH = "0";
		string tempS = "0";
		string tempV = "0";

		public Form1() {
			InitializeComponent();
		}

		private void button_HSV_to_RGB(object sender, EventArgs e) {
			int H = textBoxH.Text != "" && textBoxH.Text != "-" && textBoxH.Text != " " ? int.Parse(textBoxH.Text) : 0;
			int S = textBoxS.Text != "" && textBoxS.Text != "-" && textBoxS.Text != " " ? int.Parse(textBoxS.Text) : 0;
			int V = textBoxV.Text != "" && textBoxV.Text != "-" && textBoxV.Text != " " ? int.Parse(textBoxV.Text) : 0;

			int R = textBoxR.Text != "" && textBoxR.Text != "-" && textBoxR.Text != " " ? int.Parse(textBoxR.Text) : 0;
			int G = textBoxG.Text != "" && textBoxG.Text != "-" && textBoxG.Text != " " ? int.Parse(textBoxG.Text) : 0;
			int B = textBoxB.Text != "" && textBoxB.Text != "-" && textBoxB.Text != " " ? int.Parse(textBoxB.Text) : 0;

			HSV colorHSV = new HSV(H, (float)S / 100, (float)V / 100);
			RGB colorRGB = new RGB(0, 0, 0);

			if (button2.Visible) {
				colorRGB = colorHSV.ConvertToRGB();

				textBoxR.Text = colorRGB.GetR().ToString();
				textBoxG.Text = colorRGB.GetG().ToString();
				textBoxB.Text = colorRGB.GetB().ToString();
			} else if (buttonPlusActive) {
				colorHSV += new R(R);
				colorHSV += new G(G);
				colorHSV += new B(B);

				colorRGB = colorHSV.ConvertToRGB();
			} else if (buttonMinusActive) {
				colorHSV -= new R(R);
				colorHSV -= new G(G);
				colorHSV -= new B(B);

				colorRGB = colorHSV.ConvertToRGB();
			}

			tempR = colorRGB.GetR().ToString();
			tempG = colorRGB.GetG().ToString();
			tempB = colorRGB.GetB().ToString();

			tempH = colorHSV.GetH().ToString();
			tempS = ((int)(colorHSV.GetS() * 100)).ToString();
			tempV = ((int)(colorHSV.GetV() * 100)).ToString();

			panel_Color.BackColor = Color.FromArgb(colorRGB.GetR(), colorRGB.GetG(), colorRGB.GetB());
		}

		private void button_RGB_to_HSV(object sender, EventArgs e) {
			try
            {
				int R = textBoxR.Text != "" && textBoxR.Text != "-" && textBoxR.Text != " " ? int.Parse(textBoxR.Text) : 0;
				int G = textBoxG.Text != "" && textBoxG.Text != "-" && textBoxG.Text != " " ? int.Parse(textBoxG.Text) : 0;
				int B = textBoxB.Text != "" && textBoxB.Text != "-" && textBoxB.Text != " " ? int.Parse(textBoxB.Text) : 0;

				RGB colorRGB = new RGB(R, G, B);
				HSV colorHSV = colorRGB.ConvertToHSV();

				textBoxH.Text = colorHSV.GetH().ToString();
				textBoxS.Text = ((int)(colorHSV.GetS() * 100)).ToString();
				textBoxV.Text = ((int)(colorHSV.GetV() * 100)).ToString();

				panel_Color.BackColor = Color.FromArgb(colorRGB.GetR(), colorRGB.GetG(), colorRGB.GetB());
			} catch (FormatException)
            {
				return;
            }
		}

		private new void TextChanged(object sender, EventArgs e) {
			try
            {
				int S = textBoxS.Text != "" && textBoxS.Text != "-" && textBoxS.Text != " " ? int.Parse(textBoxS.Text) : 0;
				int V = textBoxV.Text != "" && textBoxV.Text != "-" && textBoxV.Text != " " ? int.Parse(textBoxV.Text) : 0;
				int R = textBoxR.Text != "" && textBoxR.Text != "-" && textBoxR.Text != " " ? int.Parse(textBoxR.Text) : 0;
				int G = textBoxG.Text != "" && textBoxG.Text != "-" && textBoxG.Text != " " ? int.Parse(textBoxG.Text) : 0;
				int B = textBoxB.Text != "" && textBoxB.Text != "-" && textBoxB.Text != " " ? int.Parse(textBoxB.Text) : 0;

				if (S > 100)
				{
					textBoxS.Text = "100";
				}
				else if (S < 0)
				{
					textBoxS.Text = "0";
				}

				if (V > 100)
				{
					textBoxV.Text = "100";
				}
				else if (V < 0)
				{
					textBoxV.Text = "0";
				}

				if (R > 255)
				{
					textBoxR.Text = "255";
				}
				else if (R < 0)
				{
					textBoxR.Text = "0";
				}

				if (G > 255)
				{
					textBoxG.Text = "255";
				}
				else if (G < 0)
				{
					textBoxG.Text = "0";
				}

				if (B > 255)
				{
					textBoxB.Text = "255";
				}
				else if (B < 0)
				{
					textBoxB.Text = "0";
				}
			} catch (FormatException)
            {
				return;
            }
		}

		private void ButtonSwitchOn(Button b) {
			button1.Location = new Point(150, 268);

			tempR = textBoxR.Text;
			tempG = textBoxG.Text;
			tempB = textBoxB.Text;

			textBoxR.Text = "0";
			textBoxG.Text = "0";
			textBoxB.Text = "0";

			if (b == button_switch_plus) {
				buttonPlusActive = true;
				label15.Text = "Режим добавления цветов";
				button1.Text = "HSV + RGB";
				label12.Text = "+";
				label13.Text = "+";
				label14.Text = "+";
			} else if (b == button_switch_minus) {
				buttonMinusActive = true;
				label15.Text = "Режим вычитания цветов";
				button1.Text = "HSV - RGB";
				label12.Text = "-";
				label13.Text = "-";
				label14.Text = "-";
			}

			label15.Location = new Point(140, 242);

			b.BackColor = Color.FromArgb(255, 215, 109);
			b.ForeColor = Color.FromArgb(38, 47, 52);

			panel_Color.Location = new Point(155, 21);
			panel_Color.Size = new Size(102, 58);
		}

		private void ButtonSwitchOff(Button b) {
			button1.Location = new Point(35, 268);

			label15.Text = "Режим конвертирования цветов";

			label15.Location = new Point(122, 242);

			textBoxR.Text = tempR;
			textBoxG.Text = tempG;
			textBoxB.Text = tempB;

			textBoxH.Text = tempH;
			textBoxS.Text = tempS;
			textBoxV.Text = tempV;

			if (b == button_switch_plus) {
				buttonPlusActive = false;
			} else if (b == button_switch_minus) {
				buttonMinusActive = false;
			}

			button1.Text = "HSV в RGB";

			b.BackColor = Color.FromArgb(38, 47, 52);
			b.ForeColor = Color.FromArgb(255, 215, 109);

			panel_Color.Location = new Point(180, 21);
			panel_Color.Size = new Size(53, 223);
		}

		private void LogicInterface(Button b) {
			button2.Visible = !button2.Visible;

			label12.Visible = !label12.Visible;
			label13.Visible = !label13.Visible;
			label14.Visible = !label14.Visible;

			if (!button2.Visible) {
				ButtonSwitchOn(b);
			} else {
				if (b == button_switch_plus) {
					ButtonSwitchOff(button_switch_minus);
				} else if (b == button_switch_minus) {
					ButtonSwitchOff(button_switch_plus);
				}
				ButtonSwitchOff(b);
			}
		}

		private void button_switch_plus_Click(object sender, EventArgs e) {
			LogicInterface(button_switch_plus);
		}

		private void button_switch_minus_Click(object sender, EventArgs e) {
			LogicInterface(button_switch_minus);
		}

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }

    public class R {
		public int value;
		public R(int value) {
			this.value = value % 256;
		}
	}
	public class G {
		public int value;
		public G(int value) {
			this.value = value % 256;
		}
	}
	public class B {
		public int value;
		public B(int value) {
			this.value = value % 256;
		}
	}

	public class RGB {
		private readonly int R;
		private readonly int G;
		private readonly int B;

		public RGB(int R, int G, int B) {
			this.R = (R < 0) ? 0 :
					 (R > 255) ? 255 : R;
			this.G = (G < 0) ? 0 :
					 (G > 255) ? 255 : G;
			this.B = (B < 0) ? 0 :
					 (B > 255) ? 255 : B;
		}

		public HSV ConvertToHSV() {
			float H = 0, S = 0, V = 0;
			float r = (float)R / 255, g = (float)G / 255, b = (float)B / 255;
			float max = Math.Max(r, g);
			max = Math.Max(max, b);
			float min = Math.Min(r, g);
			min = Math.Min(min, b);

			if (max == min) {
				H = 0;
			} else if (max == r && g >= b) {
				H = 60 * ((g - b) / (max - min)) + 0;
			} else if (max == r && g < b) {
				H = 60 * ((g - b) / (max - min)) + 360;
			} else if (max == g) {
				H = 60 * ((b - r) / (max - min)) + 120;
			} else if (max == b) {
				H = 60 * ((r - g) / (max - min)) + 240;
			}

			if (max != 0) {
				S = 1 - (min / max);
			}

			V = max;

			return new HSV((int)H, S, V);
		}

		public static RGB operator +(RGB colorRGB, R red) {
			return new RGB(colorRGB.R + red.value, colorRGB.G, colorRGB.B);
		}

		public static RGB operator +(RGB colorRGB, G green) {
			return new RGB(colorRGB.R, colorRGB.G + green.value, colorRGB.B);
		}

		public static RGB operator +(RGB colorRGB, B blue) {
			return new RGB(colorRGB.R, colorRGB.G, colorRGB.B + blue.value);
		}

		public static RGB operator -(RGB colorRGB, R red) {
			return new RGB(colorRGB.R - red.value, colorRGB.G, colorRGB.B);
		}

		public static RGB operator -(RGB colorRGB, G green) {
			return new RGB(colorRGB.R, colorRGB.G - green.value, colorRGB.B);
		}

		public static RGB operator -(RGB colorRGB, B blue) {
			return new RGB(colorRGB.R, colorRGB.G, colorRGB.B - blue.value);
		}

		public int GetR() {
			return R;
		}

		public int GetG() {
			return G;
		}

		public int GetB() {
			return B;
		}

		public void PrintColor() {
			Console.WriteLine($"RGB({R}, {G}, {B})");
		}
	}

	public class HSV {
		private readonly int H;
		private readonly float S;
		private readonly float V;

		public HSV(int H, float S, float V) {
			this.H = H % 360;
			this.S = (S < 0) ? 0 :
					 (S > 1) ? 1 : S;
			this.V = (V < 0) ? 0 :
					 (V > 1) ? 1 : V;
		}

		public RGB ConvertToRGB() {
			float C = V * S;
			float X = C * (1 - Math.Abs(((float)H / 60) % 2 - 1));
			float m = V - C;
			float R = 0, G = 0, B = 0;

			if (0 <= H && H < 60) {
				R = C;
				G = X;
			} else if (60 <= H && H < 120) {
				R = X;
				G = C;
			} else if (120 <= H && H < 180) {
				G = C;
				B = X;
			} else if (180 <= H && H < 240) {
				G = X;
				B = C;
			} else if (240 <= H && H < 300) {
				R = X;
				B = C;
			} else if (300 <= H && H < 360) {
				R = C;
				B = X;
			}

			return new RGB((int)((R + m) * 255), (int)((G + m) * 255), (int)((B + m) * 255));
		}

		public static HSV operator +(HSV colorHSV, R red) {
			RGB newColorRGB = colorHSV.ConvertToRGB() + red;

			return newColorRGB.ConvertToHSV();
		}

		public static HSV operator +(HSV colorHSV, G green) {
			RGB newColorRGB = colorHSV.ConvertToRGB() + green;

			return newColorRGB.ConvertToHSV();
		}

		public static HSV operator +(HSV colorHSV, B blue) {
			RGB newColorRGB = colorHSV.ConvertToRGB() + blue;

			return newColorRGB.ConvertToHSV();
		}

		public static HSV operator -(HSV colorHSV, R red) {
			RGB newColorRGB = colorHSV.ConvertToRGB() - red;

			return newColorRGB.ConvertToHSV();
		}

		public static HSV operator -(HSV colorHSV, G green) {
			RGB newColorRGB = colorHSV.ConvertToRGB() - green;

			return newColorRGB.ConvertToHSV();
		}

		public static HSV operator -(HSV colorHSV, B blue) {
			RGB newColorRGB = colorHSV.ConvertToRGB() - blue;

			return newColorRGB.ConvertToHSV();
		}

		public int GetH() {
			return H;
		}

		public float GetS() {
			return S;
		}

		public float GetV() {
			return V;
		}

		public void PrintColor() {
			Console.WriteLine($"HSV({H}, {(int)(S*100)}%, {(int)(V*100)}%)");
		}
	}
}