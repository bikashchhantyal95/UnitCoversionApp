namespace UnitConversionApp;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
		fromUnit.SelectedIndex = 0;
	}

	private void startIndexChanged(object sender, EventArgs e)
	{
		string from_unit = fromUnit.SelectedItem?.ToString();
		if(from_unit != null)
		{
			toUnit.Items.Clear();
			switch (from_unit)
			{
				case "MPH":
					toUnit.Items.Add("KPH");
					break;
                case "KPH":
                    toUnit.Items.Add("MPH");
                    break;
				default:
					break;
				
            }
            toUnit.SelectedIndex = 0;
        }
	}

	private void onButtonClicked(object sender, EventArgs e)
	{
		double result = 0;
		string from_unit_selected = fromUnit.SelectedItem?.ToString();
		string to_unit_selected = toUnit.SelectedItem?.ToString();
		if(from_unit_selected == null || to_unit_selected == null)
		{
			OutputLabel.Text = "Please select unit";
			return;
		}
		if(!double.TryParse(userInput.Text, out double value))
		{
			OutputLabel.Text = "Please enter valid number";
			return;
		}

		if(from_unit_selected == "MPH" & to_unit_selected == "KPH")
		{
			result = ConvertToMPHFromKPH(value);
			OutputLabel.Text = result.ToString();
		}
        if (from_unit_selected == "KPH" & to_unit_selected == "MPH")
        {
            result = ConvertToKPHFromMPH(value);
            OutputLabel.Text = result.ToString();
        }
    }

    //converts to KPHF
    private double ConvertToKPHFromMPH(double value)
    {
        return value / 1.60934;
    }

    //converts to MPHF
    private double ConvertToMPHFromKPH(double value)
    {
        return value * 1.60934;
    }
}


