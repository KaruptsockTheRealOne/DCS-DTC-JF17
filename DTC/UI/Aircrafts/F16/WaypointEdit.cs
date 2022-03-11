﻿using DTC.Models;
using DTC.Models.Base;
using DTC.Models.DCS;
using DTC.Models.F16.Waypoints;
using DTC.UI.Base;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.F16
{
	public partial class WaypointEdit : UserControl
	{
		public enum WaypointEditResult
		{
			Add = 1,
			SaveAndClose = 2,
			Close = 3
		}

		public delegate void WaypointEditCallback(WaypointEditResult result, Waypoint wpt);

		private class AirbaseComboBoxItem
		{
			public string Theatre;
			public string Airbase;
			public string Latitude;
			public string Longitude;

			public AirbaseComboBoxItem(string theatre, string airbase, string latitude, string longitude)
			{
				Theatre = theatre;
				Airbase = airbase;
				Latitude = latitude;
				Longitude = longitude;
			}

			public override string ToString()
			{
				return $"{Theatre} - {Airbase}";
			}
		}

		private readonly WaypointEditCallback _callback;
		private WaypointSystem _flightPlan;
		private Waypoint _waypoint = null;
		private WaypointCapture _waypointCapture;

		public WaypointEdit(WaypointSystem flightPlan, WaypointEditCallback callback)
		{
			InitializeComponent();

			foreach (var theater in Theater.Theaters)
			{
				foreach (var ab in theater.Airbases)
				{
					cboAirbases.Items.Add(new AirbaseComboBoxItem(theater.Name, ab.Name, ab.Latitude, ab.Longitude));
				}
			}

			_callback = callback;
			_flightPlan = flightPlan;
		}

		public void ShowDialog(Waypoint wpt = null)
		{
			this.Visible = true;
			this.BringToFront();
			_waypoint = wpt;

			if (wpt != null)
			{
				LoadWaypoint(wpt);
				txtWptName.Focus();
			}
			else
			{
				ResetFields();
			}
		}

		private void LoadWaypoint(Waypoint wpt)
		{
			txtWptName.Text = wpt.Name;
			txtWptLatLong.Text = wpt.Latitude + " " + wpt.Longitude;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (ValidateFields())
			{
				var wpt = Waypoint.FromStrings(txtWptName.Text, txtWptLatLong.Text);

				if (_waypoint == null)
				{
					_flightPlan.Add(wpt);
					_callback(WaypointEditResult.Add, wpt);
					ResetFields();
				} 
				else
				{
					_waypoint.Latitude = wpt.Latitude;
					_waypoint.Longitude = wpt.Longitude;
					_waypoint.Name = wpt.Name;
					_callback(WaypointEditResult.SaveAndClose, _waypoint);
					CloseDialog();
				}
			}
		}

		private void lblClose_Click(object sender, EventArgs e)
		{
			_callback(WaypointEditResult.Close, null);
			CloseDialog();
		}

		private void CloseDialog()
		{
			_waypoint = null;
			DisposeWptCapture();

			Visible = false;
			ResetFields();
		}

		private void DisposeWptCapture()
		{
			if (_waypointCapture != null)
			{
				btnCapture.Text = "Start Capture";
				_waypointCapture.Dispose();
				_waypointCapture = null;
			}
		}

		private bool ValidateFields()
		{
			lblValidation.Text = "";
			if (ValidateLatLong() && ValidateName())
			{
				return true;
			}
			return false;
		}

		private bool ValidateLatLong()
		{
			if (!txtWptLatLong.MaskFull || !Waypoint.IsCoordinateValid(txtWptLatLong.Text))
			{
				lblValidation.Text = "Invalid coordinate";
				txtWptLatLong.Focus();
				return false;
			}

			return true;
		}

		private bool ValidateName()
		{
			if (txtWptName.Text == "")
			{
				lblValidation.Text = "Name required";
				txtWptName.Focus();
				return false;
			}

			return true;
		}

		private void ResetFields()
		{
			cboAirbases.SelectedIndex = -1;
			txtWptName.Text = "WPT " + (_flightPlan.Waypoints.Count + 1).ToString();
			txtWptLatLong.Text = "";
			txtWptLatLong.Focus();
		}

		private void cboAirbases_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboAirbases.SelectedIndex > -1)
			{
				var item = (AirbaseComboBoxItem)cboAirbases.SelectedItem;
				var wpt = new Waypoint(0, item.Airbase, item.Latitude, item.Longitude);
				LoadWaypoint(wpt);
			}
		}

		private void btnCapture_Click(object sender, EventArgs e)
		{
			if (_waypointCapture == null)
			{
				btnCapture.Text = "Stop Capture";
				_waypointCapture = new WaypointCapture((string latitude, string longitude) =>
				{
					this.ParentForm.Invoke(new MethodInvoker(delegate ()
					{
						txtWptLatLong.Text = latitude + " " + longitude;
					}));
				});
			}
			else
			{
				DisposeWptCapture();
			}
		}
	}
}
