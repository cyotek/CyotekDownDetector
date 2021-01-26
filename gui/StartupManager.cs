using Microsoft.Win32;
using System;
using System.Windows.Forms;

// Azure Container Echo
// https://github.com/cyotek/Cyotek.AzureContainerEcho

// Copyright © 2013-2021 Cyotek Ltd. All Rights Reserved.

// Licensed under the MIT License.
// See LICENSE.txt for the full text.

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek
{
  /// <summary> Helper class for registering applications to start with Windows </summary>
  internal static class StartupManager
  {
    #region Private Fields

    private const string _runKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

    #endregion Private Fields

    #region Public Methods

    /// <summary> Tests to determine if the current process will start with Windows. </summary>
    /// <returns> <c>true</c> if the current process will start with Windows, otherwise <c>false</c>. </returns>
    public static bool IsRegisteredForStartup()
    {
      return StartupManager.IsRegisteredForStartup(Application.ProductName);
    }

    /// <summary> Tests to determine if the specified application will start with Windows. </summary>
    /// <param name="applicationName">  Name of the application. </param>
    /// <returns>
    /// <c>true</c> if the specified application will start with Windows, otherwise <c>false</c>.
    /// </returns>
    public static bool IsRegisteredForStartup(string applicationName)
    {
      return StartupManager.IsRegisteredForStartup(applicationName, false);
    }

    /// <summary> Tests to determine if the specified application will start with Windows. </summary>
    /// <param name="applicationName">  Name of the application. </param>
    /// <param name="applyToAllUsers">  <c>true</c> to check if enabled for all users, or <c>false</c> for the current. </param>
    /// <returns>
    /// <c>true</c> if the specified application will start with Windows, otherwise <c>false</c>.
    /// </returns>
    public static bool IsRegisteredForStartup(string applicationName, bool applyToAllUsers)
    {
      bool result;

      try
      {
        using (RegistryKey registryKey = StartupManager.GetRunKey(applyToAllUsers, false))
        {
          result = Array.FindIndex(registryKey.GetValueNames(), name => string.Equals(name, applicationName, StringComparison.OrdinalIgnoreCase)) != -1;
        }
      }
      catch
      {
        result = false;
      }

      return result;
    }

    /// <summary> Registers the current process to start with Windows for the current user. </summary>
    public static void RegisterStartupApplication()
    {
      StartupManager.RegisterStartupApplication(Application.ProductName, "\"" + Application.ExecutablePath + "\"", false);
    }

    /// <summary> Registers the specifies application to start with Windows. </summary>
    /// <param name="applicationName">  Name of the application. </param>
    /// <param name="program">  The program. </param>
    /// <param name="applyToAllUsers"> <c>true</c> to register for all users, <c>false</c> to
    ///   register for the current user only. </param>
    public static void RegisterStartupApplication(string applicationName, string program, bool applyToAllUsers)
    {
      StartupManager.RegisterStartupApplicationImpl(applicationName, program, true, applyToAllUsers);
    }

    /// <summary> Unregisters the current process from starting with Windows for the current user. </summary>
    public static void UnregisterStartupApplication()
    {
      StartupManager.UnregisterStartupApplication(Application.ProductName, false);
    }

    /// <summary> Unregisters the current process from starting with Windows. </summary>
    /// <param name="applicationName">  Name of the application. </param>
    /// <param name="applyToAllUsers"> <c>true</c> to unregister for all users, <c>false</c> to
    ///  unregister for the current user only. </param>
    public static void UnregisterStartupApplication(string applicationName, bool applyToAllUsers)
    {
      StartupManager.RegisterStartupApplicationImpl(applicationName, null, false, applyToAllUsers);
    }

    #endregion Public Methods

    #region Private Methods

    private static RegistryKey GetHive(bool applyToAllUsers)
    {
      return applyToAllUsers
                ? Registry.LocalMachine
                : Registry.CurrentUser;
    }

    private static RegistryKey GetRunKey(bool applyToAllUsers, bool writable)
    {
      return StartupManager.GetHive(applyToAllUsers).OpenSubKey(_runKeyPath, writable);
    }

    private static void RegisterStartupApplicationImpl(string applicationName, string program, bool register, bool applyToAllUsers)
    {
      using (RegistryKey registryKey = StartupManager.GetRunKey(applyToAllUsers, true))
      {
        if (register)
        {
          registryKey.SetValue(applicationName, program);
        }
        else
        {
          registryKey.DeleteValue(applicationName, false);
        }
      }
    }

    #endregion Private Methods
  }
}