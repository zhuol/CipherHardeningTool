using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace CipherHardeningTool
{
    public partial class CipherHardeningTool : Form
    {
        private const string RegistryCiphersString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Ciphers";
        private const string RegistryCipherSuitesString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites";
        private const string RegistryHashesString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Hashes";
        private const string RegistryKeyExchangeAlgorithmsString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\KeyExchangeAlgorithms";
        private const string RegistryProtocolsString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols";

        private const string BackUpCiphers = @"Resource\BackUpCiphers";
        private const string BackUpCipherSuites = @"Resource\BackUpCipherSuites";
        private const string BackUpHashes = @"Resource\BackUpHashes";
        private const string BackUpKeyExchangesAlgorithms = @"Resource\BackUpKeyExchangesAlgorithms";
        private const string BackUpKeyProtocols = @"Resource\BackUpKeyProtocols";

        private const string DisabledByDefaultKey = "DisabledByDefault";
        private const string EnabledKey = "Enabled";
        private const string DisabledValue = "0";
        private const string EnabledValue = "1";

        private bool _useRecommendSetting;

        public CipherHardeningTool()
        {
            InitializeComponent();

            CipherSuitesPreLoad();
        }

        private void WeakCipherToolLoad(object sender, EventArgs e)
        {

        }

        #region Combination of cipher suites

        // Protocols Enabled
        private void CheckedListProtocolsEnabledSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSslCipherSuiteCheckedList();
        }

        // Cipher Enabled
        private void CheckedListCipherEnabledSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSslCipherSuiteCheckedList();
        }

        // Hashes Enabled
        private void CheckedListHashesEnabledSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSslCipherSuiteCheckedList();
        }

        // Key Exchanges Enabled
        private void CheckedListKeyExchangesEnabledSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSslCipherSuiteCheckedList();
        }

        #endregion

        #region Template

        private void BestPracticesToolStripMenuItemClick(object sender, EventArgs e)
        {
            _useRecommendSetting = true;

            try
            {
                Log.LogMessageToFile("Start to apply cipher settings using AirWacth recommend settings");

                for (int index = 0; index < checkedListProtocolsEnabled.Items.Count; index++)
                {
                    if (checkedListProtocolsEnabled.Items[index].ToString() != "SSL 2.0" && checkedListProtocolsEnabled.Items[index].ToString() != "TLS 1.0"
                        && checkedListProtocolsEnabled.Items[index].ToString() != "TLS 1.1" && checkedListProtocolsEnabled.Items[index].ToString() != "TLS 1.2")
                    {
                        checkedListProtocolsEnabled.SetItemCheckState(index, CheckState.Indeterminate);
                    }
                    else
                    {
                        checkedListProtocolsEnabled.SetItemCheckState(index, CheckState.Unchecked);
                    }
                }

                for (int index = 0; index < checkedListCipherEnabled.Items.Count; index++)
                {
                    if (checkedListCipherEnabled.Items[index].ToString() == "Triple DES 168/168" || checkedListCipherEnabled.Items[index].ToString() == "AES 128/128"
                        || checkedListCipherEnabled.Items[index].ToString() == "AES 256/256")
                    {
                        checkedListCipherEnabled.SetItemCheckState(index, CheckState.Indeterminate);
                    }
                    else
                    {
                        checkedListCipherEnabled.SetItemCheckState(index, CheckState.Unchecked);
                    }
                }
                for (int index = 0; index < checkedListHashesEnabled.Items.Count; index++)
                {
                    if (checkedListHashesEnabled.Items[index].ToString() != "MD5")
                    {
                        checkedListHashesEnabled.SetItemCheckState(index, CheckState.Indeterminate);
                    }
                    else
                    {
                        checkedListHashesEnabled.SetItemCheckState(index, CheckState.Unchecked);
                    }
                }
                for (int index = 0; index < checkedListKeyExchangesEnabled.Items.Count; index++)
                {
                    if (checkedListKeyExchangesEnabled.Items[index].ToString() != "SRP" && checkedListKeyExchangesEnabled.Items[index].ToString() != "PSK"
                        && checkedListKeyExchangesEnabled.Items[index].ToString() != "CAMELLIA")
                    {
                        checkedListKeyExchangesEnabled.SetItemCheckState(index, CheckState.Indeterminate);
                    }
                    else
                    {
                        checkedListKeyExchangesEnabled.SetItemCheckState(index, CheckState.Unchecked);
                    }
                }

                UpdateSslCipherSuiteCheckedList();

                //for (int index = 0; index < checkedListSSLCipherSuiteOrder.Items.Count; index++)
                //{
                //    checkedListSSLCipherSuiteOrder.SetItemCheckState(index, CheckState.Checked);
                //}
                Log.LogMessageToFile("Applying cipher settings using AirWacth recommend settings successfully");
            }
            catch (Exception ex)
            {
                Log.LogErrorToFile("Applying cipher settings using AirWacth recommend settings failed", ex);
            }
        }

        private void CustomerToolStripMenuItemClick(object sender, EventArgs e)
        {
            _useRecommendSetting = false;

            for (int index = 0; index < checkedListProtocolsEnabled.Items.Count; index++)
            {
                checkedListProtocolsEnabled.SetItemCheckState(index, CheckState.Unchecked);
            }
            for (int index = 0; index < checkedListCipherEnabled.Items.Count; index++)
            {
                checkedListCipherEnabled.SetItemCheckState(index, CheckState.Unchecked);
            }
            for (int index = 0; index < checkedListHashesEnabled.Items.Count; index++)
            {
                checkedListHashesEnabled.SetItemCheckState(index, CheckState.Unchecked);
            }
            for (int index = 0; index < checkedListKeyExchangesEnabled.Items.Count; index++)
            {
                checkedListKeyExchangesEnabled.SetItemCheckState(index, CheckState.Unchecked);
            }

            UpdateSslCipherSuiteCheckedList();
        }

        private void ButtonSelectAllClick(object sender, EventArgs e)
        {
            for (int index = 0; index < checkedListSSLCipherSuiteOrder.Items.Count; index++)
            {
                checkedListSSLCipherSuiteOrder.SetItemChecked(index, true);
            }
        }

        private void ButtonClearAllClick(object sender, EventArgs e)
        {
            foreach (int index in checkedListSSLCipherSuiteOrder.CheckedIndices)
            {
                checkedListSSLCipherSuiteOrder.SetItemChecked(index, false);
            }
        }

        #endregion

        #region Click Functions

        private void SslScanClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(urlForSSLScan.Text))
            {
                if (File.Exists(@"SSLScan\SSLScan.exe"))
                {
                    string url = urlForSSLScan.Text;
                    string port = string.IsNullOrWhiteSpace(textBoxPort.Text) ? "443" : textBoxPort.Text;
                    var cmd = "/k SSLScan\\SSLScan /b " + url + ":" + port;
                    if (!string.IsNullOrWhiteSpace(textBoxFilter.Text))
                    {
                        cmd += " | find \"" + textBoxFilter.Text + "\"";
                    }
                    var p = new Process { StartInfo = new ProcessStartInfo("CMD.exe", cmd) };

                    p.Start();
                    p.WaitForExit();
                }
                else
                {
                    MessageBox.Show(String.Format("SSL Scan doesn't exist."), string.Format("Error Message"));
                }
            }
        }

        private void MoveItemUpClick(object sender, EventArgs e)
        {
            int selectedIndex = checkedListSSLCipherSuiteOrder.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= checkedListSSLCipherSuiteOrder.Items.Count) return;

            object selectedItem = checkedListSSLCipherSuiteOrder.SelectedItem;

            checkedListSSLCipherSuiteOrder.Items.RemoveAt(selectedIndex);
            if (selectedIndex > 0)
            {
                selectedIndex -= 1;
            }
            checkedListSSLCipherSuiteOrder.Items.Insert(selectedIndex, selectedItem); // Move Up
            checkedListSSLCipherSuiteOrder.SetItemChecked(selectedIndex, true); // Still Set as Checked
            checkedListSSLCipherSuiteOrder.SelectedIndex = selectedIndex;
        }

        private void MoveItemDownClick(object sender, EventArgs e)
        {
            int selectedIndex = checkedListSSLCipherSuiteOrder.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= checkedListSSLCipherSuiteOrder.Items.Count) return;

            object selectedItem = checkedListSSLCipherSuiteOrder.SelectedItem;

            checkedListSSLCipherSuiteOrder.Items.RemoveAt(selectedIndex);
            if (selectedIndex < checkedListSSLCipherSuiteOrder.Items.Count)
            {
                selectedIndex += 1;
            }
            checkedListSSLCipherSuiteOrder.Items.Insert(selectedIndex, selectedItem); // Move Down
            checkedListSSLCipherSuiteOrder.SetItemChecked(selectedIndex, true); // Still Set as Checked
            checkedListSSLCipherSuiteOrder.SelectedIndex = selectedIndex;
        }

        private void AboutToolStripMenuItem1Click(object sender, EventArgs e)
        {
            Form formAbout = new About();
            formAbout.StartPosition = FormStartPosition.CenterParent;
            //CenterToParent();
            formAbout.Show();
        }

        private void RunClick(object sender, EventArgs e)
        {
            #region  Update Registry

            UpdateRegistry(sender, e);

            #endregion

            #region  Ask if wanna restart machine after updating

            if (MessageBox.Show(string.Format("Do you want to restart machine to make changes taking effect? (If yes, machine will restart in 5 seconds)"),
                string.Format("Restart Waring"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var proc = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd",
                    Arguments = "/c shutdown -r -t 5"
                };
                /* /r = restart /t = timed shutdown /s = shutdown /f = Force close applications */
                Process.Start(proc);
            }

            #endregion

            //GenerateBatFile();

            //if (File.Exists(@"Resource\WeakCipherDisable.bat"))
            //{
            //    var cmd = "/c " + @"Resource\WeakCipherDisable.bat";
            //    var p = new Process {StartInfo = new ProcessStartInfo("CMD.exe", cmd)};

            //    p.Start();               
            //    p.WaitForExit();

            //    // Ask if wanna restart machine after updating
            //    if(MessageBox.Show(string.Format("Do you want to restart machine to make changes taking effect? (If yes, machine will restart in 5 seconds)"), 
            //        string.Format("Restart Waring"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        ProcessStartInfo proc = new ProcessStartInfo();
            //        proc.WindowStyle = ProcessWindowStyle.Hidden;
            //        proc.FileName = "cmd";
            //        proc.Arguments = "/c shutdown -r -t 5"; /* /r = restart /t = timed shutdown /s = shutdown /f = Force close applications */
            //        Process.Start(proc);
            //        p.WaitForExit();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(string.Format("Bat file to disable weak cipher doesn't exist."), string.Format("Error Message"));
            //}
        }

        private void HelpDocumentToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open Help Document
            if (File.Exists(@"CipherHardeningToolReference.pdf"))
            {
                Process.Start(@"CipherHardeningToolReference.pdf");
            }
            else
            {
                MessageBox.Show(string.Format("Cipher Hardening Tool Reference doesn't Exist. Please Email me at zhuozhuozhuol@gmail.com For Details."), string.Format("Error Message"));
            }
        }

        private void ClearCipherClick(object sender, EventArgs e)
        {
            try
            {
                Log.LogMessageToFile("Start to clear current cipher settings");

                //Clear process bar.
                progressBar.Value = 1;
                progressBar.Step = 1;

                #region Clear ciphers

                var registryKey = Registry.LocalMachine.OpenSubKey(RegistryCiphersString, true);
                if (registryKey != null)
                {
                    var ciphersList = registryKey.GetSubKeyNames();
                    foreach (var cl in ciphersList)
                    {
                        registryKey.DeleteSubKey(cl);
                    }
                }

                #endregion

                #region Clear cipher suites

                registryKey = Registry.LocalMachine.OpenSubKey(RegistryCipherSuitesString, true);
                if (registryKey != null)
                {
                    var cipherSuitesList = registryKey.GetSubKeyNames();
                    foreach (var csl in cipherSuitesList)
                    {
                        registryKey.DeleteSubKey(csl);
                    }
                }

                #endregion

                #region Clear hashes

                registryKey = Registry.LocalMachine.OpenSubKey(RegistryHashesString, true);
                if (registryKey != null)
                {
                    var hashesList = registryKey.GetSubKeyNames();
                    foreach (var hl in hashesList)
                    {
                        registryKey.DeleteSubKey(hl);
                    }
                }

                #endregion

                #region Clear key exchange algorithms

                registryKey = Registry.LocalMachine.OpenSubKey(RegistryKeyExchangeAlgorithmsString, true);
                if (registryKey != null)
                {
                    var keyExchangeAlgorithmsList = registryKey.GetSubKeyNames();
                    foreach (var keal in keyExchangeAlgorithmsList)
                    {
                        registryKey.DeleteSubKey(keal);
                    }
                }

                #endregion

                #region Clear protocols

                registryKey = Registry.LocalMachine.OpenSubKey(RegistryProtocolsString, true);
                if (registryKey != null)
                {
                    var protocolsList = registryKey.GetSubKeyNames();
                    foreach (var pl in protocolsList)
                    {
                        // Clear subKey first
                        var subRegistryKey = Registry.LocalMachine.OpenSubKey(RegistryProtocolsString + "\\" + pl, true);
                        if (subRegistryKey != null)
                        {
                            var subRegistryKeyList = subRegistryKey.GetSubKeyNames();
                            foreach (var srkl in subRegistryKeyList)
                            {
                                subRegistryKey.DeleteSubKey(srkl);
                            }
                        }
                        registryKey.DeleteSubKey(pl);
                    }
                }

                #endregion

                CustomerToolStripMenuItemClick(sender, e);

                Log.LogMessageToFile("Clearing current cipher settings succeed");
            }
            catch (Exception ex)
            {
                Log.LogErrorToFile("Clearing current cipher settings failed", ex);
            }
        }

        private void JavaHardeningClick(object sender, EventArgs e)
        {
            #region Load JAVA_HOME path

            string javaHomePath = LoadJavaHome();

            #endregion

            #region Update java.Security under %JAVA_HOME%\jre7\lib\security with jdk.tls.disabledAlgorithms=MD5,RC4

            if (!string.IsNullOrEmpty(javaHomePath))
            {
                string javaSecurityPath;
                string tempJavaSecurityPath;
                string backupJavaSecurityPath;
                if (javaHomePath.Contains("jre"))
                {
                    javaSecurityPath = javaHomePath + @"\lib\security\java.security";
                    tempJavaSecurityPath = javaHomePath + @"\lib\security\java.security_Temp";
                    backupJavaSecurityPath = javaHomePath + @"\lib\security\java.security_Backup";
                }
                else
                {
                    javaSecurityPath = javaHomePath + @"\jre\lib\security\java.security";
                    tempJavaSecurityPath = javaHomePath + @"\jre\lib\security\java.security_Temp";
                    backupJavaSecurityPath = javaHomePath + @"\jre\lib\security\java.security_Backup";
                }

                try
                {
                    // Back Up
                    if (!File.Exists(backupJavaSecurityPath))
                        File.Copy(javaSecurityPath, backupJavaSecurityPath);

                    // Create new security file
                    if (File.Exists(tempJavaSecurityPath))
                        File.Delete(tempJavaSecurityPath);

                    bool firstDisabledAlgorithms = true;
                    using (var sw = File.AppendText(tempJavaSecurityPath))
                    {
                        using (var sr = new StreamReader(javaSecurityPath))
                        {
                            string text;
                            while ((text = sr.ReadLine()) != null)
                            {
                                if (text.Contains("jdk.tls.disabledAlgorithms"))
                                {
                                    if (firstDisabledAlgorithms)
                                    {
                                        sw.WriteLine("    jdk.tls.disabledAlgorithms=MD5,RC4");
                                        firstDisabledAlgorithms = false;
                                    }
                                }
                                else
                                {
                                    sw.WriteLine(text);
                                }
                            }
                        }
                    }
                    if (File.Exists(javaSecurityPath))
                        File.Delete(javaSecurityPath);
                    File.Move(tempJavaSecurityPath, javaSecurityPath);
                    File.Delete(tempJavaSecurityPath);

                    string javaUpdate = "Update file : " + javaSecurityPath + " succeed.";
                    Log.LogMessageToFile(javaUpdate);
                    MessageBox.Show(javaUpdate);
                }
                catch (Exception ex)
                {
                    Log.LogErrorToFile("Unable to read java.security:", ex);
                }
            }
            else
            {
                MessageBox.Show("Can not find Java Home, please set it up(recommend using latest java like java7).");

                Log.LogMessageToFile("Can not find Java Home, please set it up(recommend using latest java like java7).");
            }

            #endregion
        }

        private void JavaCipherRollBackClick(object sender, EventArgs e)
        {
            #region Load JAVA_HOME path

            string javaHomePath = LoadJavaHome();

            #endregion

            #region Roll java.Security back with java.security_backup

            if (!string.IsNullOrEmpty(javaHomePath))
            {
                string javaSecurityPath = javaHomePath + @"\jre\lib\security\java.security";
                string backupJavaSecurityPath = javaHomePath + @"\jre\lib\security\java.security_Backup";

                if (File.Exists(backupJavaSecurityPath))
                {
                    try
                    {
                        new FileInfo(backupJavaSecurityPath).MoveTo(javaSecurityPath);
                    }
                    catch (Exception ex)
                    {
                        Log.LogErrorToFile("Roll back failed : ", ex);
                    }
                }
                else
                {
                    Log.LogMessageToFile("Cannot find backup file.");
                }
            }
            else
            {
                Log.LogMessageToFile("Cannot find JAVA_HOME, please set it up.");
            }

            #endregion
        }

        private void BackUpClick(object sender, EventArgs e)
        {
            if (!Directory.Exists(@"Resource"))
            {
                Directory.CreateDirectory(@"Resource");
            }

            try
            {
                Log.LogMessageToFile("Start to back up current cipher settings on IIS");

                #region Backup ciphers

                var backupSw = new StreamWriter(BackUpCiphers);
                var backupText = RegistryCiphersString;
                var registryKey = Registry.LocalMachine.OpenSubKey(RegistryCiphersString, true);
                if (registryKey != null)
                {
                    var ciphersList = registryKey.GetSubKeyNames();
                    foreach (var cl in ciphersList)
                    {
                        var tempRegistryKey = Registry.LocalMachine.OpenSubKey(RegistryCiphersString + "\\" + cl);
                        if (tempRegistryKey != null && tempRegistryKey.GetValue("Enabled").ToString() == "1")
                        {
                            backupText += "*" + cl;
                        }
                    }
                    backupText += "*END";
                    backupSw.WriteLine(backupText);
                    backupSw.Close();
                }

                #endregion

                #region Backup hashes

                backupSw = new StreamWriter(BackUpHashes);
                backupText = RegistryHashesString;
                registryKey = Registry.LocalMachine.OpenSubKey(RegistryHashesString, true);
                if (registryKey != null)
                {
                    var hashesList = registryKey.GetSubKeyNames();
                    foreach (var hl in hashesList)
                    {
                        var tempRegistryKey = Registry.LocalMachine.OpenSubKey(RegistryHashesString + "\\" + hl);
                        if (tempRegistryKey != null && tempRegistryKey.GetValue("Enabled").ToString() == "1")
                        {
                            backupText += "*" + hl;
                        }
                    }
                    backupText += "*END";
                    backupSw.WriteLine(backupText);
                    backupSw.Close();
                }

                #endregion

                #region Backup key exchange algorithms

                backupSw = new StreamWriter(BackUpKeyExchangesAlgorithms);
                backupText = RegistryKeyExchangeAlgorithmsString;
                registryKey = Registry.LocalMachine.OpenSubKey(RegistryKeyExchangeAlgorithmsString, true);
                if (registryKey != null)
                {
                    var keyExchangeAlgorithmsList = registryKey.GetSubKeyNames();
                    foreach (var keal in keyExchangeAlgorithmsList)
                    {
                        var tempRegistryKey =
                            Registry.LocalMachine.OpenSubKey(RegistryKeyExchangeAlgorithmsString + "\\" + keal);
                        if (tempRegistryKey != null && tempRegistryKey.GetValue("Enabled").ToString() == "1")
                        {
                            backupText += "*" + keal;
                        }
                    }
                    backupText += "*END";
                    backupSw.WriteLine(backupText);
                    backupSw.Close();
                }

                #endregion

                #region Backup protocols

                backupSw = new StreamWriter(BackUpKeyProtocols);
                backupText = RegistryProtocolsString;
                registryKey = Registry.LocalMachine.OpenSubKey(RegistryProtocolsString, true);
                if (registryKey != null)
                {
                    var protocolsList = registryKey.GetSubKeyNames();
                    foreach (var pl in protocolsList)
                    {
                        // Clear subKey first
                        var subRegistryKey = Registry.LocalMachine.OpenSubKey(RegistryProtocolsString + "\\" + pl, true);
                        var subRegistryKeyClient = Registry.LocalMachine.OpenSubKey(RegistryProtocolsString + "\\" + pl + "\\Client", true);
                        var subRegistryKeyServer = Registry.LocalMachine.OpenSubKey(RegistryProtocolsString + "\\" + pl + "\\Server", true);
                        if (subRegistryKey != null)
                        {
                            if ((subRegistryKeyClient != null && subRegistryKeyClient.GetValue(EnabledKey).ToString() == "1") &&
                                (subRegistryKeyServer != null && subRegistryKeyServer.GetValue(EnabledKey).ToString() == "1"))
                            {
                                backupText += "*" + pl;
                            }
                        }
                    }
                    backupText += "*END";
                    backupSw.WriteLine(backupText);
                    backupSw.Close();
                }

                #endregion

                #region Backup cipher suites

                backupSw = new StreamWriter(BackUpCipherSuites);
                backupText = RegistryCipherSuitesString;
                registryKey = Registry.LocalMachine.OpenSubKey(RegistryCipherSuitesString, true);
                if (registryKey != null)
                {
                    var cipherSuitesList = registryKey.GetSubKeyNames();
                    foreach (var csl in cipherSuitesList)
                    {
                        var tempRegistryKey = Registry.LocalMachine.OpenSubKey(RegistryCipherSuitesString + "\\" + csl);
                        if (tempRegistryKey != null && tempRegistryKey.GetValue("Enabled").ToString() == "1")
                        {
                            backupText += "*" + csl;
                        }
                    }
                    backupText += "*END";
                    backupSw.WriteLine(backupText);
                    backupSw.Close();
                }

                #endregion

                Log.LogMessageToFile("Back up for current cipher settings on IIS succeed");
            }
            catch (Exception ex)
            {
                Log.LogErrorToFile("Back up for current cipher settings on IIS failed", ex);
            }
        }

        private void RollbackCipherClick(object sender, EventArgs e)
        {
            try
            {
                Log.LogMessageToFile("Start to roll back cipher settings on IIS");

                // Clear before rolling back
                checkedListSSLCipherSuiteOrder.Items.Clear();
                checkedListSSLCipherSuiteOrderForDisable.Items.Clear();

                #region Cipher Recovery

                string backupCipherString = File.ReadAllText(BackUpCiphers);
                var backupCipherArray = backupCipherString.Split('*');
                for (int index = 1; index < backupCipherArray.Length - 1; index++)
                {
                    for (int jndex = 0; jndex < checkedListCipherEnabled.Items.Count; jndex++)
                    {
                        if (checkedListCipherEnabled.Items[jndex].ToString() == backupCipherArray[index])
                        {
                            checkedListSSLCipherSuiteOrder.Items.Add(backupCipherArray[index]);
                            checkedListCipherEnabled.SetItemCheckState(jndex, CheckState.Checked);
                        }
                    }
                }

                #endregion

                #region Hashes Recovery

                string backupHashString = File.ReadAllText(BackUpHashes);
                var backupHashArray = backupHashString.Split('*');
                for (int index = 1; index < backupHashArray.Length - 1; index++)
                {
                    for (int jndex = 0; jndex < checkedListHashesEnabled.Items.Count; jndex++)
                    {
                        if (checkedListHashesEnabled.Items[jndex].ToString() == backupHashArray[index])
                        {
                            checkedListSSLCipherSuiteOrder.Items.Add(backupHashArray[index]);
                            checkedListHashesEnabled.SetItemCheckState(jndex, CheckState.Checked);
                        }
                    }
                }

                #endregion

                #region Key exchange algorithms Recovery

                string backupKeyExchangeAlgorithmString = File.ReadAllText(BackUpKeyExchangesAlgorithms);
                var backupKeyExchangeAlgorithmArray = backupKeyExchangeAlgorithmString.Split('*');
                for (int index = 1; index < backupKeyExchangeAlgorithmArray.Length - 1; index++)
                {
                    for (int jndex = 0; jndex < checkedListKeyExchangesEnabled.Items.Count; jndex++)
                    {
                        if (checkedListKeyExchangesEnabled.Items[jndex].ToString() == backupKeyExchangeAlgorithmArray[index])
                        {
                            checkedListSSLCipherSuiteOrder.Items.Add(backupKeyExchangeAlgorithmArray[index]);
                            checkedListKeyExchangesEnabled.SetItemCheckState(jndex, CheckState.Checked);
                        }
                    }
                }

                #endregion

                #region Protocols Recovery

                string backupProtocolString = File.ReadAllText(BackUpKeyProtocols);
                var backupProtocolArray = backupProtocolString.Split('*');
                for (int index = 1; index < backupProtocolArray.Length - 1; index++)
                {
                    for (int jndex = 0; jndex < checkedListProtocolsEnabled.Items.Count; jndex++)
                    {
                        if (checkedListProtocolsEnabled.Items[jndex].ToString() == backupProtocolArray[index])
                        {
                            checkedListSSLCipherSuiteOrder.Items.Add(backupProtocolArray[index]);
                            checkedListProtocolsEnabled.SetItemCheckState(jndex, CheckState.Checked);
                        }
                    }
                }

                #endregion

                #region Cipher suites Recovery

                string backupCipherSuiteString = File.ReadAllText(BackUpCipherSuites);
                var backupCipherSuiteArray = backupCipherSuiteString.Split('*');
                for (int index = 1; index < backupCipherSuiteArray.Length - 1; index++)
                {
                    checkedListSSLCipherSuiteOrder.Items.Add(backupCipherSuiteArray[index]);
                }

                for (int index = 0; index < checkedListSSLCipherSuiteOrder.Items.Count; index++)
                {
                    checkedListSSLCipherSuiteOrder.SetItemCheckState(index, CheckState.Checked);
                }

                #endregion

                // Update registry
                UpdateRegistry(sender, e);

                Log.LogMessageToFile("Roll back cipher settings on IIS succeed");
            }
            catch (Exception ex)
            {
                Log.LogErrorToFile("Roll back cipher settings on IIS failed", ex);
            }
        }

        #endregion

        private void UpdateSslCipherSuiteCheckedList()
        {
            // Clear all items first
            checkedListSSLCipherSuiteOrder.Items.Clear();
            checkedListSSLCipherSuiteOrderForDisable.Items.Clear();

            #region Protocol - Server && Client

            for (int index = 0; index < checkedListProtocolsEnabled.Items.Count; index++)
            {
                if (checkedListProtocolsEnabled.GetItemChecked(index) && !checkedListSSLCipherSuiteOrder.Items.Contains(checkedListProtocolsEnabled.Items[index]))
                {
                    checkedListSSLCipherSuiteOrder.Items.Add(checkedListProtocolsEnabled.Items[index]);
                }
                else if (!checkedListSSLCipherSuiteOrderForDisable.Items.Contains(checkedListProtocolsEnabled.Items[index]))
                {
                    checkedListSSLCipherSuiteOrderForDisable.Items.Add(checkedListProtocolsEnabled.Items[index]);
                }
            }

            #endregion

            #region Ciphers

            for (int index = 0; index < checkedListCipherEnabled.Items.Count; index++)
            {
                if (checkedListCipherEnabled.GetItemChecked(index) && !checkedListSSLCipherSuiteOrder.Items.Contains(checkedListCipherEnabled.Items[index]))
                {
                    checkedListSSLCipherSuiteOrder.Items.Add(checkedListCipherEnabled.Items[index]);
                }
                else if (!checkedListSSLCipherSuiteOrderForDisable.Items.Contains(checkedListCipherEnabled.Items[index]))
                {
                    checkedListSSLCipherSuiteOrderForDisable.Items.Add(checkedListCipherEnabled.Items[index]);
                }
            }

            #endregion

            #region Hashed

            for (int index = 0; index < checkedListHashesEnabled.Items.Count; index++)
            {
                if (checkedListHashesEnabled.GetItemChecked(index) && !checkedListSSLCipherSuiteOrder.Items.Contains(checkedListHashesEnabled.Items[index]))
                {
                    checkedListSSLCipherSuiteOrder.Items.Add(checkedListHashesEnabled.Items[index]);
                }
                else
                {
                    checkedListSSLCipherSuiteOrderForDisable.Items.Add(checkedListHashesEnabled.Items[index]);
                }
            }

            #endregion

            #region Key Exchanges

            for (int index = 0; index < checkedListKeyExchangesEnabled.Items.Count; index++)
            {
                if (checkedListKeyExchangesEnabled.GetItemChecked(index) && !checkedListSSLCipherSuiteOrder.Items.Contains(checkedListKeyExchangesEnabled.Items[index]))
                {
                    checkedListSSLCipherSuiteOrder.Items.Add(checkedListKeyExchangesEnabled.Items[index]);
                }
                else
                {
                    checkedListSSLCipherSuiteOrderForDisable.Items.Add(checkedListKeyExchangesEnabled.Items[index]);
                }
            }

            #endregion

            #region Cipher Suites

            bool sslSelected = false, tlsSelected = false;
            foreach (var pe in checkedListProtocolsEnabled.CheckedItems)
            {
                if (pe.ToString().ToLower().Contains("ssl"))
                    sslSelected = true;
                if (pe.ToString().ToLower().Contains("tls"))
                    tlsSelected = true;
            }

            // SSL
            if (sslSelected)
            {
                foreach (var scs in SSLCipherSuite)
                {
                    // Hash
                    foreach (int index in checkedListHashesEnabled.CheckedIndices)
                    {
                        if (checkedListHashesEnabled.GetItemChecked(index) && scs.Contains(checkedListHashesEnabled.Items[index].ToString())
                            && !checkedListSSLCipherSuiteOrder.Items.Contains(scs))
                        {
                            checkedListSSLCipherSuiteOrder.Items.Add(scs);
                            break;
                        }
                    }
                    if (!checkedListSSLCipherSuiteOrder.Items.Contains(scs) && !checkedListSSLCipherSuiteOrderForDisable.Items.Contains(scs))
                    {
                        checkedListSSLCipherSuiteOrderForDisable.Items.Add(scs);
                    }

                    // Key Exchange
                    foreach (int index in checkedListKeyExchangesEnabled.CheckedIndices)
                    {
                        if (checkedListKeyExchangesEnabled.GetItemChecked(index) && scs.Contains(checkedListKeyExchangesEnabled.Items[index].ToString())
                            && !checkedListSSLCipherSuiteOrder.Items.Contains(scs))
                        {
                            checkedListSSLCipherSuiteOrder.Items.Add(scs);
                            break;
                        }
                    }
                    if (!checkedListSSLCipherSuiteOrder.Items.Contains(scs) && !checkedListSSLCipherSuiteOrderForDisable.Items.Contains(scs))
                    {
                        checkedListSSLCipherSuiteOrderForDisable.Items.Add(scs);
                    }
                }
            }

            // TLS
            if (tlsSelected)
            {
                foreach (var tcs in TLSCipherSuite)
                {
                    // Hash
                    foreach (int index in checkedListHashesEnabled.CheckedIndices)
                    {
                        if (checkedListHashesEnabled.GetItemChecked(index) && tcs.Contains(checkedListHashesEnabled.Items[index].ToString())
                            && !checkedListSSLCipherSuiteOrder.Items.Contains(tcs))
                        {
                            checkedListSSLCipherSuiteOrder.Items.Add(tcs);
                            break;
                        }
                    }
                    if (!checkedListSSLCipherSuiteOrder.Items.Contains(tcs) && !checkedListSSLCipherSuiteOrderForDisable.Items.Contains(tcs))
                    {
                        checkedListSSLCipherSuiteOrderForDisable.Items.Add(tcs);
                    }

                    // Key Exchange
                    foreach (int index in checkedListKeyExchangesEnabled.CheckedIndices)
                    {
                        if (checkedListKeyExchangesEnabled.GetItemChecked(index) && tcs.Contains(checkedListKeyExchangesEnabled.Items[index].ToString())
                            && !checkedListSSLCipherSuiteOrder.Items.Contains(tcs))
                        {
                            checkedListSSLCipherSuiteOrder.Items.Add(tcs);
                            break;
                        }
                    }
                    if (!checkedListSSLCipherSuiteOrder.Items.Contains(tcs) && !checkedListSSLCipherSuiteOrderForDisable.Items.Contains(tcs))
                    {
                        checkedListSSLCipherSuiteOrderForDisable.Items.Add(tcs);
                    }
                }
            }

            #endregion

            #region Disable all the rest cipher suites from SSLCipherSuites and TLSCipherSuites that are not in checkedListSSLCipherSuiteOrder and checkedListSSLCipherSuiteOrderForDisable

            foreach (string scs in SSLCipherSuite)
            {
                if (!checkedListSSLCipherSuiteOrder.Items.Contains(scs) && !checkedListSSLCipherSuiteOrderForDisable.Items.Contains(scs))
                    checkedListSSLCipherSuiteOrderForDisable.Items.Add(scs);
            }
            foreach (var tcs in TLSCipherSuite)
            {
                if (!checkedListSSLCipherSuiteOrder.Items.Contains(tcs) && !checkedListSSLCipherSuiteOrderForDisable.Items.Contains(tcs))
                    checkedListSSLCipherSuiteOrderForDisable.Items.Add(tcs);
            }

            #endregion

            // Check all the items from checkedListSSLCipherSuiteOrder
            for (int index = 0; index < checkedListSSLCipherSuiteOrder.Items.Count; index++)
            {
                checkedListSSLCipherSuiteOrder.SetItemCheckState(index, CheckState.Checked);
            }
        }

        private void CheckedListSslCipherSuiteOrderItemCheck(Object sender, ItemCheckEventArgs ie)
        {
            if (_useRecommendSetting && ie.NewValue == CheckState.Unchecked)
            {
                var item = checkedListSSLCipherSuiteOrder.Items[ie.Index];
                MessageBox.Show(string.Format(item + " is going to be unchecked, recommend to keep it selected."), string.Format("Unchecked Waring"));
            }
        }

        // To update ciphers by registry.
        public void UpdateRegistry(Object sender, EventArgs e)
        {
            try
            {
                //#region Clear current settings before apply new settings

                //ClearCipherClick(sender, e);

                //#endregion

                RegistryKey registryKey;
                string registryString;

                #region Progress Bar

                // Display the ProgressBar control.
                progressBar.Visible = true;
                // Set Minimum to 1 to represent the first file being copied.
                progressBar.Minimum = 1;
                // Set Maximum to the total number of files to copy.
                progressBar.Maximum = checkedListSSLCipherSuiteOrder.CheckedItems.Count + checkedListSSLCipherSuiteOrderForDisable.Items.Count;
                // Set the initial value of the ProgressBar.
                progressBar.Value = 1;
                // Set the Step property to a value of 1 to represent each file being copied.
                progressBar.Step = 1;

                #endregion

                #region Enabled Cipher Suite List

                for (int index = 0; index < checkedListSSLCipherSuiteOrder.Items.Count; index++)
                {
                    var scso = checkedListSSLCipherSuiteOrder.Items[index];
                    if (!checkedListSSLCipherSuiteOrder.GetItemChecked(index))
                    {
                        if (!checkedListSSLCipherSuiteOrderForDisable.Items.Contains(scso))
                            checkedListSSLCipherSuiteOrderForDisable.Items.Add(scso);
                    }
                    else
                    {
                        if (scso.ToString() == ("SSL 3.0") || scso.ToString() == ("PCT 1.0") || scso.ToString() == ("SSL 2.0") ||
                            scso.ToString() == ("TLS 1.0") || scso.ToString() == ("TLS 1.1") || scso.ToString() == ("TLS 1.2"))
                        {
                            registryString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" + scso + "\\Server";
                            registryKey = Registry.LocalMachine.OpenSubKey(registryString, true) ??
                                          Registry.LocalMachine.CreateSubKey(registryString);
                            if (registryKey != null)
                            {
                                registryKey.SetValue(DisabledByDefaultKey, DisabledValue, RegistryValueKind.DWord);
                                registryKey.SetValue(EnabledKey, EnabledValue, RegistryValueKind.DWord);
                            }

                            registryString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" + scso + "\\Client";
                            registryKey = Registry.LocalMachine.OpenSubKey(registryString, true) ??
                                          Registry.LocalMachine.CreateSubKey(registryString);
                            if (registryKey != null)
                                registryKey.SetValue(EnabledKey, EnabledValue, RegistryValueKind.DWord);
                        }
                        else if (scso.ToString() == "Triple DES 168/168" || scso.ToString() == "AES 128/128" || scso.ToString() == "AES 256/256")
                        {
                            registryString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Ciphers\\" + scso;
                            registryKey = Registry.LocalMachine.OpenSubKey(registryString, true) ??
                                          Registry.LocalMachine.CreateSubKey(registryString);
                            if (registryKey != null)
                                registryKey.SetValue(EnabledKey, EnabledValue, RegistryValueKind.DWord);
                        }
                        else if (scso.ToString() == "SHA")
                        {
                            registryString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Hashes\\" + scso;
                            registryKey = Registry.LocalMachine.OpenSubKey(registryString, true) ??
                                          Registry.LocalMachine.CreateSubKey(registryString);
                            if (registryKey != null)
                                registryKey.SetValue(EnabledKey, EnabledValue, RegistryValueKind.DWord);
                        }
                        else if (scso.ToString() == "Diffle-Hellman" || scso.ToString() == "PKCS")
                        {
                            registryString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\KeyExchangeAlgorithms\\" + scso;
                            registryKey = Registry.LocalMachine.OpenSubKey(registryString, true) ??
                                          Registry.LocalMachine.CreateSubKey(registryString);
                            if (registryKey != null)
                                registryKey.SetValue(EnabledKey, EnabledValue, RegistryValueKind.DWord);
                        }
                        else
                        {
                            registryString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" + scso;
                            registryKey = Registry.LocalMachine.OpenSubKey(registryString, true) ??
                                          Registry.LocalMachine.CreateSubKey(registryString);
                            if (registryKey != null)
                            {
                                registryKey.SetValue(DisabledByDefaultKey, DisabledValue, RegistryValueKind.DWord);
                                registryKey.SetValue(EnabledKey, EnabledValue, RegistryValueKind.DWord);
                            }

                            // TODO: Update top10 cipher suites as highest priority in group policy                    
                        }
                    }
                    progressBar.PerformStep();
                }

                #endregion

                #region Disabled Cipher Suite List

                foreach (var scsod in checkedListSSLCipherSuiteOrderForDisable.Items)
                {
                    if (scsod.ToString() == ("SSL 3.0") || scsod.ToString() == ("PCT 1.0") || scsod.ToString() == ("SSL 2.0") ||
                        scsod.ToString() == ("TLS 1.0") || scsod.ToString() == ("TLS 1.1") || scsod.ToString() == ("TLS 1.2"))
                    {
                        registryString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" + scsod + "\\Server";
                        registryKey = Registry.LocalMachine.OpenSubKey(registryString, true) ??
                                      Registry.LocalMachine.CreateSubKey(registryString);
                        if (registryKey != null)
                        {
                            registryKey.SetValue(DisabledByDefaultKey, DisabledValue, RegistryValueKind.DWord);
                            registryKey.SetValue(EnabledKey, DisabledValue, RegistryValueKind.DWord);
                        }

                        registryString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" + scsod + "\\Client";
                        registryKey = Registry.LocalMachine.OpenSubKey(registryString, true) ??
                                      Registry.LocalMachine.CreateSubKey(registryString);
                        if (registryKey != null)
                            registryKey.SetValue(EnabledKey, DisabledValue, RegistryValueKind.DWord);
                    }
                    else if (scsod.ToString() == "NULL" || scsod.ToString() == "DES 56/56" || scsod.ToString() == "RC2 40/128" || scsod.ToString() == "RC2 56/128"
                        || scsod.ToString() == "RC2 128/128" || scsod.ToString() == "RC4 40/128" || scsod.ToString() == "RC4 56/128" || scsod.ToString() == "RC4 64/128"
                        || scsod.ToString() == "RC4 128/128")
                    {
                        registryString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Ciphers\\" + scsod;
                        registryKey = Registry.LocalMachine.OpenSubKey(registryString, true) ??
                                      Registry.LocalMachine.CreateSubKey(registryString);
                        if (registryKey != null)
                            registryKey.SetValue(EnabledKey, DisabledValue, RegistryValueKind.DWord);
                    }
                    else if (scsod.ToString() == "MD5")
                    {
                        registryString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Hashes\\" + scsod;
                        registryKey = Registry.LocalMachine.OpenSubKey(registryString, true) ??
                                      Registry.LocalMachine.CreateSubKey(registryString);
                        if (registryKey != null)
                            registryKey.SetValue(EnabledKey, DisabledValue, RegistryValueKind.DWord);
                    }
                    else if (scsod.ToString() == "SRP" || scsod.ToString() == "PSK" || scsod.ToString() == "CAMELLIA")
                    {
                        registryString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\KeyExchangeAlgorithms\\" + scsod;
                        registryKey = Registry.LocalMachine.OpenSubKey(registryString, true) ??
                                      Registry.LocalMachine.CreateSubKey(registryString);
                        if (registryKey != null)
                            registryKey.SetValue(EnabledKey, DisabledValue, RegistryValueKind.DWord);
                    }
                    else
                    {
                        registryString = "System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" + scsod;
                        registryKey = Registry.LocalMachine.OpenSubKey(registryString, true) ??
                                      Registry.LocalMachine.CreateSubKey(registryString);
                        if (registryKey != null)
                        {
                            registryKey.SetValue(DisabledByDefaultKey, EnabledValue, RegistryValueKind.DWord);
                            registryKey.SetValue(EnabledKey, DisabledValue, RegistryValueKind.DWord);
                        }

                        // TODO: Update top10 cipher suites as highest priority in group policy                    
                    }
                    progressBar.PerformStep();
                }

                #endregion
            }
            catch (Exception ex)
            {
                Log.LogErrorToFile("Update registry failed", ex);
            }
        }

        // To Generate bat file
        public void GenerateBatFile()
        {
            try
            {
                Log.LogMessageToFile("Start to generate batch file");

                if (!Directory.Exists(@"Resource"))
                {
                    Directory.CreateDirectory(@"Resource");
                }
                var file = new StreamWriter(@"Resource\WeakCipherDisable.bat");

                string cmdString = "::Author : Zhuo Li" + Environment.NewLine +
                                   "::Date : " + DateTime.Now + Environment.NewLine +
                                   "::Description : Improve weak cipher/cipher suites/protocols" + Environment.NewLine +
                                   "@echo off" + Environment.NewLine + Environment.NewLine;
                file.WriteLine(cmdString);

                #region Enabled Cipher Suites List

                foreach (var scso in checkedListSSLCipherSuiteOrder.CheckedItems)
                {
                    if (scso.ToString() == ("SSL 3.0"))
                    {
                        cmdString = "::Check whether REGistry path exist. otherwise creating REGistry folder for it" +
                                    Environment.NewLine +
                                    "REG QUERY \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" +
                                    scso + "\\Server\"" + Environment.NewLine +
                                    "IF %ERRORLEVEL% EQU 0 goto Protocols" + scso.ToString().Replace(" ", "") +
                                    "ServerNotExist" + Environment.NewLine + Environment.NewLine +
                                    ":Protocols" + scso.ToString().Replace(" ", "") + "ServerNotExist" +
                                    Environment.NewLine +
                                    "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" +
                                    scso + "\\Server\"" + Environment.NewLine + Environment.NewLine +
                                    "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" +
                                    scso + "\\Server \" /v \"DisabledByDefault\" /t REG_DWORD /d 0x00000000" +
                                    Environment.NewLine +
                                    "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" +
                                    scso + "\\Server \" /v \"Enabled\" /t REG_DWORD /d 0x00000001" + Environment.NewLine +
                                    "echo ..Protocols Server " + scso + " added" + Environment.NewLine +
                                    Environment.NewLine;
                        file.WriteLine(cmdString);

                        cmdString = "::Check whether REGistry path exist. otherwise creating REGistry folder for it" +
                                    Environment.NewLine +
                                    "REG QUERY \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" +
                                    scso + "\\Client\"" + Environment.NewLine +
                                    "IF %ERRORLEVEL% EQU 0 goto Protocols" + scso.ToString().Replace(" ", "") +
                                    "ClientNotExist" + Environment.NewLine + Environment.NewLine +
                                    ":Protocols" + scso.ToString().Replace(" ", "") + "ClientNotExist" +
                                    Environment.NewLine +
                                    "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" +
                                    scso + "\\Client\"" + Environment.NewLine + Environment.NewLine +
                                    "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" +
                                    scso + "\\Client \" /v \"Enabled\" /t REG_DWORD /d 0x00000001" + Environment.NewLine +
                                    "echo ..Protocols Client " + scso + " added" + Environment.NewLine +
                                    Environment.NewLine;
                        file.WriteLine(cmdString);
                    }
                    else if (scso.ToString() == "Triple DES 168/168" || scso.ToString() == "AES 128/128" ||
                             scso.ToString() == "AES 256/256")
                    {
                        cmdString =
                            "::Check whether REGistry path exist. otherwise creating REGistry folder for it" +
                            Environment.NewLine +
                            "REG QUERY \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Ciphers\\" +
                            scso + "\"" + Environment.NewLine +
                            "IF %ERRORLEVEL% EQU 0 goto Ciphers" + scso.ToString().Replace(" ", "") + "NotExist" +
                            Environment.NewLine + Environment.NewLine +
                            ":Ciphers" + scso.ToString().Replace(" ", "") + "NotExist" + Environment.NewLine +
                            "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Ciphers\\" +
                            scso + "\"" + Environment.NewLine + Environment.NewLine +
                            "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Ciphers\\" +
                            scso + "\" /v \"Enabled\" /t REG_DWORD /d 0x00000001" + Environment.NewLine +
                            "echo ..Ciphers " + scso + " added" + Environment.NewLine + Environment.NewLine;
                        file.WriteLine(cmdString);
                    }
                    else
                    {
                        cmdString =
                            "::Check whether REGistry path exist. otherwise creating REGistry folder for it" +
                            Environment.NewLine +
                            "REG QUERY \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" +
                            scso + "\"" + Environment.NewLine +
                            "IF %ERRORLEVEL% EQU 0 goto CipherSuites" + scso.ToString().Replace(" ", "") +
                            "NotExist" + Environment.NewLine + Environment.NewLine +
                            ":CipherSuites" + scso.ToString().Replace(" ", "") + "NotExist" + Environment.NewLine +
                            "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" +
                            scso + "\"" + Environment.NewLine + Environment.NewLine +
                            "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" +
                            scso + "\" /v \"DisabledByDefault\" /t REG_DWORD /d 0x00000000" + Environment.NewLine +
                            "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" +
                            scso + "\" /v \"Enabled\" /t REG_DWORD /d 0x00000001" + Environment.NewLine +
                            "echo ..CipherSuites TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA added" + Environment.NewLine +
                            Environment.NewLine;
                        file.WriteLine(cmdString);

                        // TODO: Update top10 cipher suites as highest priority in group policy                    
                    }
                }

                #endregion

                #region Disabled Cipher Suites List

                foreach (var scsod in checkedListSSLCipherSuiteOrderForDisable.Items)
                {
                    if (scsod.ToString() == ("PCT 1.0") || scsod.ToString() == ("SSL 2.0") ||
                        scsod.ToString() == ("TLS 1.0")
                        || scsod.ToString() == ("TLS 1.1") || scsod.ToString() == ("TLS 1.2"))
                    {
                    }
                    else if (scsod.ToString() == "NULL" || scsod.ToString() == "DES 56/56" ||
                             scsod.ToString() == "RC2 40/128" || scsod.ToString() == "RC2 56/128"
                             || scsod.ToString() == "RC2 128/128" || scsod.ToString() == "RC4 40/128" ||
                             scsod.ToString() == "RC4 56/128" || scsod.ToString() == "RC4 64/128"
                             || scsod.ToString() == "RC4 128/128")
                    {
                        cmdString =
                            "::Check whether REGistry path exist. otherwise creating REGistry folder for it" +
                            Environment.NewLine +
                            "REG QUERY \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Ciphers\\" +
                            scsod + "\"" + Environment.NewLine +
                            "IF %ERRORLEVEL% EQU 0 goto Ciphers" + scsod.ToString().Replace(" ", "") + "NotExist" +
                            Environment.NewLine + Environment.NewLine +
                            ":Ciphers" + scsod.ToString().Replace(" ", "") + "NotExist" + Environment.NewLine +
                            "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Ciphers\\" +
                            scsod + "\"" + Environment.NewLine + Environment.NewLine +
                            "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Ciphers\\" +
                            scsod + "\" /v \"Enabled\" /t REG_DWORD /d 0x00000000" + Environment.NewLine +
                            "echo ..Ciphers " + scsod + " added" + Environment.NewLine + Environment.NewLine;
                        file.WriteLine(cmdString);
                    }
                    else
                    {
                        cmdString =
                            "::Check whether REGistry path exist. otherwise creating REGistry folder for it" +
                            Environment.NewLine +
                            "REG QUERY \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" +
                            scsod + "\"" + Environment.NewLine +
                            "IF %ERRORLEVEL% EQU 0 goto CipherSuites" + scsod.ToString().Replace(" ", "") +
                            "NotExist" + Environment.NewLine + Environment.NewLine +
                            ":CipherSuites" + scsod.ToString().Replace(" ", "") + "NotExist" + Environment.NewLine +
                            "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" +
                            scsod + "\"" + Environment.NewLine + Environment.NewLine +
                            "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" +
                            scsod + "\" /v \"DisabledByDefault\" /t REG_DWORD /d 0x00000001" + Environment.NewLine +
                            "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" +
                            scsod + "\" /v \"Enabled\" /t REG_DWORD /d 0x00000000" + Environment.NewLine +
                            "echo ..CipherSuites TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA added" + Environment.NewLine +
                            Environment.NewLine;
                        file.WriteLine(cmdString);

                        // TODO: Update top10 cipher suites as highest priority in group policy                    
                    }
                }

                #endregion

                cmdString = "echo done" + Environment.NewLine;
                cmdString += "pause";
                file.WriteLine(cmdString);
                file.Close();

                Log.LogMessageToFile("Generating batch file succeed");
            }
            catch (Exception ex)
            {
                Log.LogErrorToFile("Generating batch file failed", ex);
            }
        }

        public void CipherSuitesPreLoad()
        {
            #region Load ciphers

            var registryKey = Registry.LocalMachine.OpenSubKey(RegistryCiphersString, true);
            if (registryKey != null)
            {
                var ciphersList = registryKey.GetSubKeyNames();
                foreach (var cl in ciphersList)
                {
                    var tempRegistryKey = Registry.LocalMachine.OpenSubKey(RegistryCiphersString + "\\" + cl);
                    if (tempRegistryKey != null && tempRegistryKey.GetValue(EnabledKey).ToString() == "1")
                    {
                        checkedListSSLCipherSuiteOrder.Items.Add(cl);

                        int index = checkedListCipherEnabled.Items.IndexOf(cl);
                        checkedListCipherEnabled.SetItemCheckState(index, CheckState.Checked);
                    }
                }
            }

            #endregion

            #region Load cipher suites

            registryKey = Registry.LocalMachine.OpenSubKey(RegistryCipherSuitesString, true);
            if (registryKey != null)
            {
                var cipherSuitesList = registryKey.GetSubKeyNames();
                foreach (var csl in cipherSuitesList)
                {
                    var tempRegistryKey = Registry.LocalMachine.OpenSubKey(RegistryCipherSuitesString + "\\" + csl);
                    if (tempRegistryKey != null && tempRegistryKey.GetValue(EnabledKey).ToString() == "0")
                    {
                        checkedListSSLCipherSuiteOrderForDisable.Items.Add(csl);
                    }
                }
            }

            #endregion

            #region Load hashes

            registryKey = Registry.LocalMachine.OpenSubKey(RegistryHashesString, true);
            if (registryKey != null)
            {
                var hashesList = registryKey.GetSubKeyNames();
                foreach (var hl in hashesList)
                {
                    var tempRegistryKey = Registry.LocalMachine.OpenSubKey(RegistryHashesString + "\\" + hl);
                    if (tempRegistryKey != null && tempRegistryKey.GetValue(EnabledKey).ToString() == "1")
                    {
                        checkedListSSLCipherSuiteOrder.Items.Add(hl);

                        int index = checkedListHashesEnabled.Items.IndexOf(hl);
                        checkedListHashesEnabled.SetItemCheckState(index, CheckState.Checked);
                    }
                }
            }

            #endregion

            #region Load key exchange algorithms

            registryKey = Registry.LocalMachine.OpenSubKey(RegistryKeyExchangeAlgorithmsString, true);
            if (registryKey != null)
            {
                var keyExchangeAlgorithmsList = registryKey.GetSubKeyNames();
                foreach (var keal in keyExchangeAlgorithmsList)
                {
                    var tempRegistryKey = Registry.LocalMachine.OpenSubKey(RegistryKeyExchangeAlgorithmsString + "\\" + keal);
                    if (tempRegistryKey != null && tempRegistryKey.GetValue(EnabledKey).ToString() == "1")
                    {
                        checkedListSSLCipherSuiteOrder.Items.Add(keal);

                        int index = checkedListKeyExchangesEnabled.Items.IndexOf(keal);
                        checkedListKeyExchangesEnabled.SetItemCheckState(index, CheckState.Checked);
                    }
                }
            }

            #endregion

            #region Load protocols

            registryKey = Registry.LocalMachine.OpenSubKey(RegistryProtocolsString, true);
            if (registryKey != null)
            {
                var protocolsList = registryKey.GetSubKeyNames();
                foreach (var pl in protocolsList)
                {
                    // Clear subKey first
                    var subRegistryKey = Registry.LocalMachine.OpenSubKey(RegistryProtocolsString + "\\" + pl, true);
                    var subRegistryKeyClient = Registry.LocalMachine.OpenSubKey(RegistryProtocolsString + "\\" + pl + "\\Client", true);
                    var subRegistryKeyServer = Registry.LocalMachine.OpenSubKey(RegistryProtocolsString + "\\" + pl + "\\Server", true);
                    if (subRegistryKey != null)
                    {
                        if ((subRegistryKeyClient != null && subRegistryKeyClient.GetValue(EnabledKey).ToString() == "1") &&
                            (subRegistryKeyServer != null && subRegistryKeyServer.GetValue(EnabledKey).ToString() == "1"))
                        {
                            checkedListSSLCipherSuiteOrder.Items.Add(pl);

                            int index = checkedListProtocolsEnabled.Items.IndexOf(pl);
                            checkedListProtocolsEnabled.SetItemCheckState(index, CheckState.Checked);
                        }
                        else
                        {
                            checkedListSSLCipherSuiteOrderForDisable.Items.Add(pl);
                        }
                    }
                }
            }

            #endregion

            #region Proload enabled cipher suites based on disabled ones getting from registry

            foreach (string scs in SSLCipherSuite)
            {
                if (!checkedListSSLCipherSuiteOrderForDisable.Items.Contains(scs))
                    checkedListSSLCipherSuiteOrder.Items.Add(scs);
            }
            foreach (var tcs in TLSCipherSuite)
            {
                if (!checkedListSSLCipherSuiteOrderForDisable.Items.Contains(tcs))
                    checkedListSSLCipherSuiteOrder.Items.Add(tcs);
            }

            for (int index = 0; index < checkedListSSLCipherSuiteOrder.Items.Count; index++)
            {
                checkedListSSLCipherSuiteOrder.SetItemCheckState(index, CheckState.Checked);
            }

            #endregion
        }

        public string LoadJavaHome()
        {
            try
            {
                Log.LogMessageToFile("Start to load JAVA HOME");
                string javaHomePath = Environment.GetEnvironmentVariable("JAVA_HOME");
                if (string.IsNullOrEmpty(javaHomePath))
                {
                    const string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";
                    using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(javaKey))
                    {
                        if (rk != null)
                        {
                            string currentVersion = rk.GetValue("CurrentVersion").ToString();
                            using (RegistryKey key = rk.OpenSubKey(currentVersion))
                            {
                                if (key != null)
                                    javaHomePath = key.GetValue("JavaHome").ToString();
                            }
                        }
                    }
                }
                Log.LogMessageToFile("Loading JAVA HOME succeed, JAVA HOME is: " + javaHomePath);
                return javaHomePath;
            }
            catch (Exception ex)
            {
                Log.LogErrorToFile("Loading JAVA HOME failed", ex);
                return string.Empty;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "mailto:zhuozhuozhuol@gmail.com?subject=whatever&body=whatever";
            proc.Start();
        }

        private void linkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.lostscroll.com");
        }
    }
}
