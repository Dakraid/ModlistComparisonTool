// ModlistComparisonTool.Core - WindowPlacement.cs
// Created on 2022.11.07
// Last modified at 2022.11.26 01:31

#region
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
#endregion

namespace ModlistComparisonTool.Core.Common;

// RECT structure required by WINDOWPLACEMENT structure
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public struct RECT
{
	public int Left;
	public int Top;
	public int Right;
	public int Bottom;

	public RECT(int left, int top, int right, int bottom)
	{
		Left = left;
		Top = top;
		Right = right;
		Bottom = bottom;
	}
}

// POINT structure required by WINDOWPLACEMENT structure
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public struct POINT
{
	public int X;
	public int Y;

	public POINT(int x, int y)
	{
		X = x;
		Y = y;
	}
}

// WINDOWPLACEMENT stores the position, size, and state of a window
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public struct WINDOWPLACEMENT
{
	public int length;
	public int flags;
	public int showCmd;
	public POINT minPosition;
	public POINT maxPosition;
	public RECT normalPosition;
}

public static class WindowPlacement
{
	private const int SW_SHOWNORMAL = 1;
	private const int SW_SHOWMINIMIZED = 2;
	private static readonly Encoding encoding = new UTF8Encoding();
	private static readonly XmlSerializer serializer = new(typeof(WINDOWPLACEMENT));

	[DllImport("user32.dll")]
	private static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

	[DllImport("user32.dll")]
	private static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

	public static void SetPlacement(IntPtr windowHandle, string placementXml)
	{
		if (string.IsNullOrEmpty(placementXml))
		{
			return;
		}

		WINDOWPLACEMENT placement;
		var xmlBytes = encoding.GetBytes(placementXml);

		try
		{
			using (var memoryStream = new MemoryStream(xmlBytes))
			{
				placement = (WINDOWPLACEMENT) serializer.Deserialize(memoryStream);
			}

			placement.length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
			placement.flags = 0;
			placement.showCmd = placement.showCmd == SW_SHOWMINIMIZED ? SW_SHOWNORMAL : placement.showCmd;
			SetWindowPlacement(windowHandle, ref placement);
		}
		catch (InvalidOperationException)
		{
			// Parsing placement XML failed. Fail silently.
		}
	}

	public static string GetPlacement(IntPtr windowHandle)
	{
		var placement = new WINDOWPLACEMENT();
		GetWindowPlacement(windowHandle, out placement);

		using (var memoryStream = new MemoryStream())
		{
			using (var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8))
			{
				serializer.Serialize(xmlTextWriter, placement);
				var xmlBytes = memoryStream.ToArray();
				return encoding.GetString(xmlBytes);
			}
		}
	}
}
