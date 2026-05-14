using Godot;
using System;
using System.Globalization;

namespace Game.Core
{
	public partial class Logger
	{
		public static void Log(Loglevel level, params object[] message)
		{
			var dateTime = DateTime.Now;
			string timeStamp = $"[{dateTime:dd-MM-yyyy HH:mm:ss}]";
			var callingMethod = new System.Diagnostics.StackTrace().GetFrame(2).GetMethod();
			string logMessage = $"{timeStamp} [{level}] [{callingMethod.DeclaringType.Name}] [{callingMethod.Name}]";
			
			string color = "CYAN";

			switch (level)
			{
				case Loglevel.DEBUG:
					color = "WHITE";
					break;
				case Loglevel.INFO:
					color = "CYAN";
					break;
				case Loglevel.WARNING:
					color = "YELLOW";
					break;
				case Loglevel.ERROR:
					color = "MAROON";
					break;
				default:
				break;
			}

			GD.PrintRich([$"[color={color}]{logMessage}[/color]", ..message]);
		}
		public static void Debug(params object[] message)
		{
			Log(Loglevel.DEBUG, message);
		}

		public static void Info(params object[] message)
		{
			Log(Loglevel.INFO, message);
		}

		public static void Warning(params object[] message)
		{
			Log(Loglevel.WARNING, message);   
		}

		public static void Error(params object[] message)
		{
			Log(Loglevel.ERROR, message);
		}
	}
}
