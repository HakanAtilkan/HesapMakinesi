using System;
using System.Windows.Forms;

namespace HesapMakinesi;

public partial class Form1 : Form
{
	string mevcutOperator = "";
	double ilkSayi = 0;
	bool yeniGirisMi = false;
	string gecmis = "";
	string mevcutGiris = "";

	public Form1()
	{
		InitializeComponent();
		this.KeyPreview = true;
		this.KeyDown += Form1_KeyDown;
	}

	private void Form1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
		{
			var sayi = (e.KeyCode - Keys.D0).ToString();
			SayiGir(sayi);
			e.Handled = true;
			return;
		}

		if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
		{
			var sayi = (e.KeyCode - Keys.NumPad0).ToString();
			SayiGir(sayi);
			e.Handled = true;
			return;
		}

		switch (e.KeyCode)
		{
			case Keys.Add:
			case Keys.Oemplus:
				OperatorGir("+");
				e.Handled = true;
				break;
			case Keys.Subtract:
			case Keys.OemMinus:
				OperatorGir("-");
				e.Handled = true;
				break;
			case Keys.Multiply:
				OperatorGir("*");
				e.Handled = true;
				break;
			case Keys.Divide:
				OperatorGir("/");
				e.Handled = true;
				break;
			case Keys.Decimal:
			case Keys.OemPeriod:
				SayiGir(".");
				e.Handled = true;
				break;
			case Keys.Enter:
				Equals_Click(this, EventArgs.Empty);
				e.Handled = true;
				break;
			case Keys.Back:
				Back_Click(this, EventArgs.Empty);
				e.Handled = true;
				break;
			case Keys.Delete:
			case Keys.Escape:
				Clear_Click(this, EventArgs.Empty);
				e.Handled = true;
				break;
			case Keys.C:
				if (e.Control)
				{
					return;
				}
				Clear_Click(this, EventArgs.Empty);
				e.Handled = true;
				break;
		}
	}

	private void Number_Click(object sender, EventArgs e)
	{
		var buton = (Button)sender;
		SayiGir(buton.Text);
	}

	private void Operator_Click(object sender, EventArgs e)
	{
		var buton = (Button)sender;
		OperatorGir(buton.Text);
	}

	private void Clear_Click(object sender, EventArgs e)
	{
		Screen.Text = "0";
		HistoryDisplay.Text = "";
		gecmis = "";
		mevcutGiris = "0";
		ilkSayi = 0;
		mevcutOperator = "";
		yeniGirisMi = false;
	}

	private void Back_Click(object sender, EventArgs e)
	{
		if (Screen.Text == "Error")
		{
			Screen.Text = "0";
			mevcutGiris = "0";
			yeniGirisMi = false;
			SonucuGuncelle();
			return;
		}

		if (string.IsNullOrEmpty(mevcutGiris))
		{
			mevcutGiris = Screen.Text;
		}

		if (mevcutGiris.Length > 1)
		{
			mevcutGiris = mevcutGiris.Substring(0, mevcutGiris.Length - 1);
		}
		else
		{
			mevcutGiris = "0";
		}

		Screen.Text = mevcutGiris;
		SonucuGuncelle();
	}

	private void Equals_Click(object sender, EventArgs e)
	{
		if (Screen.Text == "Error" || string.IsNullOrEmpty(mevcutOperator))
		{
			return;
		}

		string kullanilacakGiris = string.IsNullOrEmpty(mevcutGiris) ? Screen.Text : mevcutGiris;

		if (!double.TryParse(kullanilacakGiris, out double ikinciSayi))
		{
			return;
		}

		if (!string.IsNullOrEmpty(gecmis))
		{
			gecmis += kullanilacakGiris;
		}

		double sonuc = GirisIleHesapla(kullanilacakGiris);

		if (sonuc == 0 && mevcutOperator == "/" && ikinciSayi == 0)
		{
			Screen.Text = "Error";
			return;
		}

		Screen.Text = sonuc.ToString();
		mevcutGiris = sonuc.ToString();
		HistoryDisplay.Text = gecmis + "=";
		gecmis = "";
		mevcutOperator = "";
		ilkSayi = sonuc;
		yeniGirisMi = true;
	}

	void SayiGir(string deger)
	{
		if (Screen.Text == "Error")
		{
			Screen.Text = "0";
			mevcutGiris = "0";
			yeniGirisMi = true;
			gecmis = "";
			mevcutOperator = "";
		}

		if (deger == ".")
		{
			if (yeniGirisMi || string.IsNullOrEmpty(mevcutGiris))
			{
				mevcutGiris = "0.";
				yeniGirisMi = false;
			}
			else if (!mevcutGiris.Contains("."))
			{
				mevcutGiris += ".";
			}
			Screen.Text = mevcutGiris;
			SonucuGuncelle();
			return;
		}

		if (yeniGirisMi || mevcutGiris == "0" || string.IsNullOrEmpty(mevcutGiris))
		{
			mevcutGiris = deger;
			yeniGirisMi = false;
		}
		else
		{
			mevcutGiris += deger;
		}

		Screen.Text = mevcutGiris;
		SonucuGuncelle();
	}

	void OperatorGir(string islemOperatoru)
	{
		if (Screen.Text == "Error")
		{
			return;
		}

		string kullanilacakGiris = string.IsNullOrEmpty(mevcutGiris) ? Screen.Text : mevcutGiris;

		if (double.TryParse(kullanilacakGiris, out double sayi))
		{
			if (!string.IsNullOrEmpty(mevcutOperator))
			{
				ilkSayi = GirisIleHesapla(kullanilacakGiris);
				if (Screen.Text == "Error")
				{
					return;
				}
				Screen.Text = ilkSayi.ToString();
				mevcutGiris = ilkSayi.ToString();
			}
			else
			{
				ilkSayi = sayi;
			}

			if (string.IsNullOrEmpty(gecmis))
			{
				gecmis = kullanilacakGiris + OperatorSemboluAl(islemOperatoru);
			}
			else
			{
				gecmis += kullanilacakGiris + OperatorSemboluAl(islemOperatoru);
			}

			HistoryDisplay.Text = gecmis;
			mevcutOperator = islemOperatoru;
			yeniGirisMi = true;
			mevcutGiris = "";
			SonucuGuncelle();
		}
	}

	string OperatorSemboluAl(string islemOperatoru)
	{
		return islemOperatoru switch
		{
			"*" => "×",
			"/" => "÷",
			"+" => "+",
			"-" => "-",
			"%" => "%",
			_ => islemOperatoru
		};
	}

	double SonucuHesapla()
	{
		string kullanilacakGiris = string.IsNullOrEmpty(mevcutGiris) ? Screen.Text : mevcutGiris;
		return GirisIleHesapla(kullanilacakGiris);
	}

	double GirisIleHesapla(string giris)
	{
		if (string.IsNullOrEmpty(mevcutOperator))
		{
			if (double.TryParse(giris, out double sayi))
			{
				return sayi;
			}
			return 0;
		}

		if (!double.TryParse(giris, out double ikinciSayi))
		{
			return 0;
		}

		double sonuc = 0;

		switch (mevcutOperator)
		{
			case "+":
				sonuc = ilkSayi + ikinciSayi;
				break;
			case "-":
				sonuc = ilkSayi - ikinciSayi;
				break;
			case "*":
				sonuc = ilkSayi * ikinciSayi;
				break;
			case "/":
				if (ikinciSayi != 0)
				{
					sonuc = ilkSayi / ikinciSayi;
				}
				else
				{
					return 0;
				}
				break;
			case "%":
				sonuc = ilkSayi % ikinciSayi;
				break;
			default:
				return double.TryParse(giris, out double sayi) ? sayi : 0;
		}

		return sonuc;
	}

	void SonucuGuncelle()
	{
		if (string.IsNullOrEmpty(mevcutOperator))
		{
			return;
		}

		if (!yeniGirisMi && !string.IsNullOrEmpty(mevcutGiris))
		{
			double sonuc = SonucuHesapla();
			if (sonuc != 0 || mevcutGiris != "0")
			{
				Screen.Text = sonuc.ToString();
			}
		}
	}
}
