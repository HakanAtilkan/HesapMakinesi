
namespace HesapMakinesi;

public partial class MainPage : ContentPage
{
	string currentOperator = "";
	double firstNumber = 0;
	bool isNewEntry = false;

	public MainPage()
	{
		InitializeComponent();

		KeyboardInput.Text = string.Empty;
		FocusKeyboardInput();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		FocusKeyboardInput();
	}

	private void Number_Click(object sender, EventArgs e)
	{
		var btn = (Button)sender;
		SimulateNumber(btn.Text);
		FocusKeyboardInput();
	}

	private void Operator_Click(object sender, EventArgs e)
	{
		var btn = (Button)sender;
		SimulateOperator(btn.Text);
		FocusKeyboardInput();
	}

	private void Clear_Click(object sender, EventArgs e)
	{
		Screen.Text = "0";
		firstNumber = 0;
		currentOperator = "";
		isNewEntry = false;
		FocusKeyboardInput();
	}

	private void Back_Click(object sender, EventArgs e)
	{
		if (Screen.Text.Length > 1)
		{
			Screen.Text = Screen.Text.Substring(0, Screen.Text.Length - 1);
		}
		else
		{
			Screen.Text = "0";
		}
		FocusKeyboardInput();
	}

	private void Equals_Click(object sender, EventArgs e)
	{
		double secondNumber = double.Parse(Screen.Text);
		double result = 0;

		switch (currentOperator)
		{
			case "+":
				result = firstNumber + secondNumber;
				break;
			case "-":
				result = firstNumber - secondNumber;
				break;
			case "*":
				result = firstNumber * secondNumber;
				break;
			case "/":
				if (secondNumber != 0)
				{
					result = firstNumber / secondNumber;
				}
				else
				{
					Screen.Text = "Error";
					return;
				}
				break;
			default:
				return;
		}

		Screen.Text = result.ToString();
		isNewEntry = true;
		FocusKeyboardInput();
	}

	private void KeyboardInput_TextChanged(object sender, TextChangedEventArgs e)
	{
		var entry = (Entry)sender;

		if (string.IsNullOrEmpty(entry.Text))
		{
			return;
		}

		foreach (var ch in entry.Text)
		{
			HandleKey(ch);
		}

		entry.Text = string.Empty;
		FocusKeyboardInput();
	}

	private void KeyboardInput_Completed(object sender, EventArgs e)
	{
		Equals_Click(sender, e);
		FocusKeyboardInput();
	}

	void HandleKey(char key)
	{
		if (char.IsDigit(key))
		{
			SimulateNumber(key.ToString());
			return;
		}

		switch (key)
		{
			case '+':
			case '-':
			case '*':
			case '/':
			case '%':
				SimulateOperator(key.ToString());
				break;
			case '.':
			case ',':
				SimulateNumber(".");
				break;
			case '=':
				Equals_Click(this, EventArgs.Empty);
				break;
			case 'c':
			case 'C':
				Clear_Click(this, EventArgs.Empty);
				break;
			case '\b':
				Back_Click(this, EventArgs.Empty);
				break;
		}

		FocusKeyboardInput();
	}

	void SimulateNumber(string value)
	{
		if (isNewEntry || Screen.Text == "0")
		{
			Screen.Text = value;
			isNewEntry = false;
		}
		else
		{
			Screen.Text += value;
		}
	}

	void SimulateOperator(string op)
	{
		firstNumber = double.Parse(Screen.Text);
		currentOperator = op;
		isNewEntry = true;
	}

	void FocusKeyboardInput()
	{
		if (KeyboardInput == null)
		{
			return;
		}

		Dispatcher.Dispatch(() =>
		{
			if (!KeyboardInput.IsFocused)
			{
				KeyboardInput.Focus();
			}
		});
	}
}