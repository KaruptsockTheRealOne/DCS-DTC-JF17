using DTC.Models.Presets;

namespace DTC.UI.CommonPages
{
	public partial class MainPage : Page
	{
		public MainPage()
		{
			InitializeComponent();
		}

		public override string PageTitle => "Home";

		private void btnf16_Click(object sender, System.EventArgs e)
		{
			MainForm.AddPage(new PresetsPage(PresetsStore.GetAircraft(AircraftModel.F16C)));
		}

		private void btnWptDatabase_Click(object sender, System.EventArgs e)
		{
			MainForm.AddPage(new WaypointDatabase());
		}

        private void btnJF17_Click(object sender, System.EventArgs e)
        {
			MainForm.AddPage(new PresetsPage(PresetsStore.GetAircraft(AircraftModel.JF17)));
		}
    }
}