using System.Drawing;
using System.Windows.Forms;

namespace HesapMakinesi;

partial class Form1
{
	private System.ComponentModel.IContainer components = null;
	private TextBox Screen;
	private TextBox HistoryDisplay;
	private Button btnClear, btnBack, btnPercent, btnDivide;
	private Button btn7, btn8, btn9, btnMultiply;
	private Button btn4, btn5, btn6, btnSubtract;
	private Button btn1, btn2, btn3, btnAdd;
	private Button btn0, btnDecimal, btnEquals;

	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.Screen = new TextBox();
		this.btnClear = new Button();
		this.btnBack = new Button();
		this.btnPercent = new Button();
		this.btnDivide = new Button();
		this.btn7 = new Button();
		this.btn8 = new Button();
		this.btn9 = new Button();
		this.btnMultiply = new Button();
		this.btn4 = new Button();
		this.btn5 = new Button();
		this.btn6 = new Button();
		this.btnSubtract = new Button();
		this.btn1 = new Button();
		this.btn2 = new Button();
		this.btn3 = new Button();
		this.btnAdd = new Button();
		this.btn0 = new Button();
		this.btnDecimal = new Button();
		this.btnEquals = new Button();
		this.SuspendLayout();

		// Form1
		this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		this.AutoScaleMode = AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(320, 500);
		this.FormBorderStyle = FormBorderStyle.FixedSingle;
		this.MaximizeBox = false;
		this.Name = "Form1";
		this.Text = "Hesap Makinesi";
		this.StartPosition = FormStartPosition.CenterScreen;

		// HistoryDisplay (üstte işlem geçmişi)
		this.HistoryDisplay = new TextBox();
		this.HistoryDisplay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.HistoryDisplay.Location = new System.Drawing.Point(20, 20);
		this.HistoryDisplay.Name = "HistoryDisplay";
		this.HistoryDisplay.ReadOnly = true;
		this.HistoryDisplay.Size = new System.Drawing.Size(280, 30);
		this.HistoryDisplay.TabIndex = 0;
		this.HistoryDisplay.Text = "";
		this.HistoryDisplay.TextAlign = HorizontalAlignment.Right;
		this.HistoryDisplay.TabStop = false;
		this.HistoryDisplay.BackColor = System.Drawing.SystemColors.Control;

		// Screen (altta sonuç)
		this.Screen = new TextBox();
		this.Screen.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.Screen.Location = new System.Drawing.Point(20, 55);
		this.Screen.Name = "Screen";
		this.Screen.ReadOnly = true;
		this.Screen.Size = new System.Drawing.Size(280, 50);
		this.Screen.TabIndex = 0;
		this.Screen.Text = "0";
		this.Screen.TextAlign = HorizontalAlignment.Right;
		this.Screen.TabStop = false;

		// Butonlar - Row 1
		this.btnClear.Location = new System.Drawing.Point(20, 125);
		this.btnClear.Name = "btnClear";
		this.btnClear.Size = new System.Drawing.Size(60, 60);
		this.btnClear.TabIndex = 1;
		this.btnClear.Text = "C";
		this.btnClear.UseVisualStyleBackColor = true;
		this.btnClear.Click += new EventHandler(Clear_Click);

		this.btnBack.Location = new System.Drawing.Point(90, 125);
		this.btnBack.Name = "btnBack";
		this.btnBack.Size = new System.Drawing.Size(60, 60);
		this.btnBack.TabIndex = 2;
		this.btnBack.Text = "←";
		this.btnBack.UseVisualStyleBackColor = true;
		this.btnBack.Click += new EventHandler(Back_Click);

		this.btnPercent.Location = new System.Drawing.Point(160, 125);
		this.btnPercent.Name = "btnPercent";
		this.btnPercent.Size = new System.Drawing.Size(60, 60);
		this.btnPercent.TabIndex = 3;
		this.btnPercent.Text = "%";
		this.btnPercent.UseVisualStyleBackColor = true;
		this.btnPercent.Click += new EventHandler(Operator_Click);

		this.btnDivide.Location = new System.Drawing.Point(230, 125);
		this.btnDivide.Name = "btnDivide";
		this.btnDivide.Size = new System.Drawing.Size(60, 60);
		this.btnDivide.TabIndex = 4;
		this.btnDivide.Text = "/";
		this.btnDivide.UseVisualStyleBackColor = true;
		this.btnDivide.Click += new EventHandler(Operator_Click);

		// Row 2
		this.btn7.Location = new System.Drawing.Point(20, 195);
		this.btn7.Name = "btn7";
		this.btn7.Size = new System.Drawing.Size(60, 60);
		this.btn7.TabIndex = 5;
		this.btn7.Text = "7";
		this.btn7.UseVisualStyleBackColor = true;
		this.btn7.Click += new EventHandler(Number_Click);

		this.btn8.Location = new System.Drawing.Point(90, 195);
		this.btn8.Name = "btn8";
		this.btn8.Size = new System.Drawing.Size(60, 60);
		this.btn8.TabIndex = 6;
		this.btn8.Text = "8";
		this.btn8.UseVisualStyleBackColor = true;
		this.btn8.Click += new EventHandler(Number_Click);

		this.btn9.Location = new System.Drawing.Point(160, 195);
		this.btn9.Name = "btn9";
		this.btn9.Size = new System.Drawing.Size(60, 60);
		this.btn9.TabIndex = 7;
		this.btn9.Text = "9";
		this.btn9.UseVisualStyleBackColor = true;
		this.btn9.Click += new EventHandler(Number_Click);

		this.btnMultiply.Location = new System.Drawing.Point(230, 195);
		this.btnMultiply.Name = "btnMultiply";
		this.btnMultiply.Size = new System.Drawing.Size(60, 60);
		this.btnMultiply.TabIndex = 8;
		this.btnMultiply.Text = "*";
		this.btnMultiply.UseVisualStyleBackColor = true;
		this.btnMultiply.Click += new EventHandler(Operator_Click);

		// Row 3
		this.btn4.Location = new System.Drawing.Point(20, 265);
		this.btn4.Name = "btn4";
		this.btn4.Size = new System.Drawing.Size(60, 60);
		this.btn4.TabIndex = 9;
		this.btn4.Text = "4";
		this.btn4.UseVisualStyleBackColor = true;
		this.btn4.Click += new EventHandler(Number_Click);

		this.btn5.Location = new System.Drawing.Point(90, 265);
		this.btn5.Name = "btn5";
		this.btn5.Size = new System.Drawing.Size(60, 60);
		this.btn5.TabIndex = 10;
		this.btn5.Text = "5";
		this.btn5.UseVisualStyleBackColor = true;
		this.btn5.Click += new EventHandler(Number_Click);

		this.btn6.Location = new System.Drawing.Point(160, 265);
		this.btn6.Name = "btn6";
		this.btn6.Size = new System.Drawing.Size(60, 60);
		this.btn6.TabIndex = 11;
		this.btn6.Text = "6";
		this.btn6.UseVisualStyleBackColor = true;
		this.btn6.Click += new EventHandler(Number_Click);

		this.btnSubtract.Location = new System.Drawing.Point(230, 265);
		this.btnSubtract.Name = "btnSubtract";
		this.btnSubtract.Size = new System.Drawing.Size(60, 60);
		this.btnSubtract.TabIndex = 12;
		this.btnSubtract.Text = "-";
		this.btnSubtract.UseVisualStyleBackColor = true;
		this.btnSubtract.Click += new EventHandler(Operator_Click);

		// Row 4
		this.btn1.Location = new System.Drawing.Point(20, 335);
		this.btn1.Name = "btn1";
		this.btn1.Size = new System.Drawing.Size(60, 60);
		this.btn1.TabIndex = 13;
		this.btn1.Text = "1";
		this.btn1.UseVisualStyleBackColor = true;
		this.btn1.Click += new EventHandler(Number_Click);

		this.btn2.Location = new System.Drawing.Point(90, 335);
		this.btn2.Name = "btn2";
		this.btn2.Size = new System.Drawing.Size(60, 60);
		this.btn2.TabIndex = 14;
		this.btn2.Text = "2";
		this.btn2.UseVisualStyleBackColor = true;
		this.btn2.Click += new EventHandler(Number_Click);

		this.btn3.Location = new System.Drawing.Point(160, 335);
		this.btn3.Name = "btn3";
		this.btn3.Size = new System.Drawing.Size(60, 60);
		this.btn3.TabIndex = 15;
		this.btn3.Text = "3";
		this.btn3.UseVisualStyleBackColor = true;
		this.btn3.Click += new EventHandler(Number_Click);

		this.btnAdd.Location = new System.Drawing.Point(230, 335);
		this.btnAdd.Name = "btnAdd";
		this.btnAdd.Size = new System.Drawing.Size(60, 60);
		this.btnAdd.TabIndex = 16;
		this.btnAdd.Text = "+";
		this.btnAdd.UseVisualStyleBackColor = true;
		this.btnAdd.Click += new EventHandler(Operator_Click);

		// Row 5
		this.btn0.Location = new System.Drawing.Point(20, 405);
		this.btn0.Name = "btn0";
		this.btn0.Size = new System.Drawing.Size(130, 60);
		this.btn0.TabIndex = 17;
		this.btn0.Text = "0";
		this.btn0.UseVisualStyleBackColor = true;
		this.btn0.Click += new EventHandler(Number_Click);

		this.btnDecimal.Location = new System.Drawing.Point(160, 405);
		this.btnDecimal.Name = "btnDecimal";
		this.btnDecimal.Size = new System.Drawing.Size(60, 60);
		this.btnDecimal.TabIndex = 18;
		this.btnDecimal.Text = ".";
		this.btnDecimal.UseVisualStyleBackColor = true;
		this.btnDecimal.Click += new EventHandler(Number_Click);

		this.btnEquals.Location = new System.Drawing.Point(230, 405);
		this.btnEquals.Name = "btnEquals";
		this.btnEquals.Size = new System.Drawing.Size(60, 60);
		this.btnEquals.TabIndex = 19;
		this.btnEquals.Text = "=";
		this.btnEquals.UseVisualStyleBackColor = true;
		this.btnEquals.Click += new EventHandler(Equals_Click);

		// Form1 Controls
		this.Controls.Add(this.HistoryDisplay);
		this.Controls.Add(this.Screen);
		this.Controls.Add(this.btnClear);
		this.Controls.Add(this.btnBack);
		this.Controls.Add(this.btnPercent);
		this.Controls.Add(this.btnDivide);
		this.Controls.Add(this.btn7);
		this.Controls.Add(this.btn8);
		this.Controls.Add(this.btn9);
		this.Controls.Add(this.btnMultiply);
		this.Controls.Add(this.btn4);
		this.Controls.Add(this.btn5);
		this.Controls.Add(this.btn6);
		this.Controls.Add(this.btnSubtract);
		this.Controls.Add(this.btn1);
		this.Controls.Add(this.btn2);
		this.Controls.Add(this.btn3);
		this.Controls.Add(this.btnAdd);
		this.Controls.Add(this.btn0);
		this.Controls.Add(this.btnDecimal);
		this.Controls.Add(this.btnEquals);

		this.ResumeLayout(false);
		this.PerformLayout();
	}
}

