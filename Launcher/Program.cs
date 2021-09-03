using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace Launcher
{
    class Program
    {
        private const string    LAUNCHER_VERSION_STRING = "1.1",
     
                                GITHUB_BUILD_URL        = @"https://www.github.com/NucleaTNT/Vigilante/releases/latest/download/Build.zip",
                                GITHUB_LAUNCHER_URL     = @"https://www.github.com/NucleaTNT/Vigilante/releases/latest/download/Launcher.exe",
                                GITHUB_VERSION_URL      = @"https://www.github.com/NucleaTNT/Vigilante/releases/latest/download/version.txt",
                                
                                RELATIVE_PATH_TO_EXE    = @"\Data\App\Vigilante.exe",
                                RELATIVE_PATH_TO_VER    = @"\Data\version.txt";
        
        // Cache response just so we make as few requests as possible
        private static byte[] VerURLResp = null;
        private static string CurrentDir = Directory.GetCurrentDirectory();

        private static void Main(string[] args)
        {
            Console.Title = $"Vigilante Launcher v{LAUNCHER_VERSION_STRING}";

            DeletePreviousLauncher();
            if (CheckForAppUpdate()) UpdateApplication();
            if (CheckForLauncherUpdate()) UpdateLauncher();
            
            Process.Start(CurrentDir + RELATIVE_PATH_TO_EXE);
        }

        /// <summary>
        /// Compares the value returned by GetLocalAppVersionString() with the result of
        /// GetLatestAppVersionString();
        /// </summary>
        /// <returns>Boolean value representing the presence or absence of an update.</returns>
        private static bool CheckForAppUpdate() 
        {
            Version localVersion = new Version(GetLocalAppVersionString());
            if (localVersion.CompareTo(new Version("0.0.0.0")) == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine("Could not access local app version number.");

                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }

            Version latestVersion = new Version(GetLatestAppVersionString());
            if (latestVersion.CompareTo(new Version("0.0.0.0")) == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Could not access latest app version number.");
                
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
                Environment.Exit(1);
            }

            // If this is the case either the local version is greater than or less
            // than the current version, indicating either broken version number or
            // that a new update has been released respectively.
            return (localVersion.CompareTo(latestVersion) != 0);
        }

        /// <summary>
        /// Compares the local LAUNCHER_VERSION_STRING with the latest version
        /// stored online.
        /// </summary>
        /// <returns>Boolean value representing the presence or absence of an update.</returns>
        private static bool CheckForLauncherUpdate() 
        {
            Version latestVersion = new Version(GetLatestLauncherVersionString());
            if (latestVersion.CompareTo(new Version("0.0")) == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine("Could not access latest launcher version number.");
                
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }

            Version localVersion = new Version(LAUNCHER_VERSION_STRING);
            return (localVersion.CompareTo(latestVersion) != 0);
        }

        private static void DeletePreviousLauncher()
        {
            string oldLauncherPath = CurrentDir + @"\OLD_Launcher";
            if (File.Exists(oldLauncherPath)) File.Delete(oldLauncherPath);
        }

        private static byte[] GetFileViaHTTP(string url) 
        {
            using (WebClient webClient = new WebClient()) return webClient.DownloadData(url);
        }

        private static string GetLatestAppVersionString()
        {
            try 
            {
                if (VerURLResp == null) VerURLResp = GetFileViaHTTP(GITHUB_VERSION_URL);
                return Encoding.UTF8.GetString(VerURLResp).Split(new[] { Environment.NewLine }, StringSplitOptions.TrimEntries)[0];
            } catch { return "0.0.0.0"; }
        }

        private static string GetLocalAppVersionString()
        {
            try 
            {
                string content = File.ReadAllText(CurrentDir + RELATIVE_PATH_TO_VER).Trim();
                return (content.Length >= 7) ? content : throw new Exception(); 
            } catch { return "0.0.0.0"; }
        }

        private static string GetLatestLauncherVersionString()
        {
            try 
            {
                if (VerURLResp == null) VerURLResp = GetFileViaHTTP(GITHUB_VERSION_URL);
                return Encoding.UTF8.GetString(VerURLResp).Split(new[] { Environment.NewLine }, StringSplitOptions.TrimEntries)[1];
            } catch { return "0.0"; }
        }

        private static void HandleAppZip()
        {
            string zipPath = CurrentDir + @"\appZipTemp";
            string extractPath = CurrentDir + @"\Data\App\";

            byte[] appZipBytes = GetFileViaHTTP(GITHUB_BUILD_URL);
            File.WriteAllBytes(zipPath, appZipBytes);

            ZipFile.ExtractToDirectory(zipPath, extractPath);
            File.Delete(zipPath);
        }

        private static void UpdateApplication()
        {
            Console.WriteLine($"Updating Application to v{GetLatestAppVersionString()}...");
         
            Directory.CreateDirectory(CurrentDir + @"\Data\App");
            HandleAppZip();
            File.WriteAllText(CurrentDir + @"\Data\version.txt", GetLatestAppVersionString());

            Console.WriteLine("Done!");
        }

        private static void UpdateLauncher()
        {
            Console.WriteLine("Updating Launcher...");

            byte[] newLauncher = GetFileViaHTTP(GITHUB_LAUNCHER_URL);
            File.Move(CurrentDir + @"\Launcher.exe", CurrentDir + @"\OLD_Launcher");
            File.WriteAllBytes(CurrentDir + @"\Launcher.exe", newLauncher);

            Console.WriteLine("Done!");
        }
    }
}
