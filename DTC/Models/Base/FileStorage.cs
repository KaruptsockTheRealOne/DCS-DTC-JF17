﻿using DTC.Models.DCS;
using DTC.Models.Presets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DTC.Models.Base
{
	public class FileStorage
	{
		private static string GetCurrentFolder()
		{
			return Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
		}

		private static string GetSettingsFilePath()
		{
			var path = GetCurrentFolder();
			return Path.Combine(path, "dtc-settings.json");
		}

		private static string GetAirbasesFilePath()
		{
			var path = GetCurrentFolder();
			return Path.Combine(path, "dtc-airbases.json");
		}

		private static string GetEmittersFilePath()
		{
			var path = GetCurrentFolder();
			return Path.Combine(path, "dtc-emitters.json");
		}

		public static void PersistSettingsFile(string json)
		{
			File.WriteAllText(GetSettingsFilePath(), json);
		}

		public static void PersistAirbasesFile(Theater[] theaters)
		{
			var json = JsonConvert.SerializeObject(theaters);
			File.WriteAllText(GetAirbasesFilePath(), json);
		}

		private static string GetAircraftPresetsPath(Aircraft ac)
		{
			return Path.Combine(GetCurrentFolder(), "Presets", ac.GetAircraftModelName());
		}

		public static Dictionary<string, IConfiguration> LoadPresets(Aircraft ac)
		{
			var path = GetAircraftPresetsPath(ac);
			var dic = new Dictionary<string, IConfiguration>();
			if (Directory.Exists(path))
			{
				var files = Directory.EnumerateFiles(path, "*.json");
				foreach (var file in files)
				{
					var json = File.ReadAllText(file);
					var type = ac.GetAircraftConfigurationType();
					var cfg = JsonConvert.DeserializeObject(json, type);
					((IConfiguration)cfg).AfterLoadFromJson();
					dic.Add(Path.GetFileNameWithoutExtension(file), (IConfiguration)cfg);
				}
			}
			return dic;
		}

		internal static void DeletePreset(Aircraft ac, Preset preset)
		{
			var path = Path.Combine(GetAircraftPresetsPath(ac), preset.Name + ".json");
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}

		public static void PersistPreset(Aircraft ac, Preset preset)
		{
			var path = GetAircraftPresetsPath(ac);
			Directory.CreateDirectory(path);
			var json = JsonConvert.SerializeObject(preset.Configuration);
			File.WriteAllText(Path.Combine(path, preset.Name + ".json"), json);
		}

		public static void RenamePresetFile(Aircraft aircraft, Preset preset, string oldName)
		{
			var path = GetAircraftPresetsPath(aircraft);
			if (Directory.Exists(path))
			{
				var file = Path.Combine(path, oldName + ".json");
				File.Move(file, Path.Combine(path, preset.Name + ".json"));
			}
		}

		public static string LoadFile(string path)
		{
			if (File.Exists(path))
			{
				return File.ReadAllText(path);
			}
			return null;
		}

		public static string LoadSettingsFile()
		{
			var path = GetSettingsFilePath();
			if (File.Exists(path))
			{
				return File.ReadAllText(path);
			}
			return null;
		}

		public static Theater[] LoadAirbases()
		{
			try
			{
				var path = GetAirbasesFilePath();
				if (File.Exists(path))
				{
					var json = File.ReadAllText(path);
					return JsonConvert.DeserializeObject<Theater[]>(json);
				}
			}
			catch
			{
			}
			return null;
		}

		public static Emitter[] LoadEmitters()
		{
			var path = GetEmittersFilePath();
			var json = File.ReadAllText(path);
			return JsonConvert.DeserializeObject<Emitter[]>(json);
		}

		public static void Save(IConfiguration cfg, string path)
		{
			var json = cfg.ToJson();
			File.WriteAllText(path, json);
		}
	}
}
