using System;
using System.Reflection;

namespace Api.Utils
{
	public class ApiConfigurationProperties
	{
		private const string ValueUnknown = "UNKNOWN";
		public static ApiConfigurationProperties Instance { get; }

		public string AssemblyName { get; }
		public string BuildHash { get; }
		public string BuildDate { get; }
		public string Version { get; }
		public string Host { get; }

		private ApiConfigurationProperties(string assembly, string version, string buildHash, string machineName, string buildDate)
		{
			AssemblyName = assembly;
			BuildHash = buildHash;
			Version = version;
			Host = machineName;
			BuildDate = buildDate;
		}

		private static ApiConfigurationProperties EmptyProperties =>
			new ApiConfigurationProperties(
				assembly: ValueUnknown,
				version: ValueUnknown,
				buildHash: null,
				buildDate: null,
				machineName: null);

		static ApiConfigurationProperties()
		{
			Instance = InitializeAppProps();
		}

		private static ApiConfigurationProperties InitializeAppProps()
		{
			try
			{
				var assembly = Assembly.GetEntryAssembly();
				var assemblyName = assembly.GetName();
				var assemblyDescription = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>();

				var buildHashDate = TryParseBuildHashAndDate(assemblyDescription?.Description);

				return new ApiConfigurationProperties(
					assembly: assemblyName.Name,
					version: assemblyName.Version.ToString(),
					buildHash: buildHashDate.Item1,
					buildDate: buildHashDate.Item2,
					machineName: TryGetMachineName()
				);
			}
			catch
			{
				return EmptyProperties;
			}
		}

		private static Tuple<string, string> TryParseBuildHashAndDate(string description)
		{
			// Format looks like abt4d924|18.01.2018 16:35:01

			if (string.IsNullOrEmpty(description) == false)
			{
				var parts = description.Split('|');
				if (parts.Length > 1)
				{
					return new Tuple<string, string>(parts[0], parts[1]);
				}
			}

			return new Tuple<string, string>(string.Empty, string.Empty);
		}

		private static string TryGetMachineName()
		{
			try
			{
				return Environment.MachineName;
			}
			catch
			{
				return ValueUnknown;
			}
		}
	}
}
