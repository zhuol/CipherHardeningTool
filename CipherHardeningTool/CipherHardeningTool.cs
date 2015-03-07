using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CipherHardeningTool
{
    public partial class CipherHardeningTool : Form
    {
        public CipherHardeningTool()
        {
            InitializeComponent();
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
            for (int index = 0; index < checkedListProtocolsEnabled.Items.Count; index++)
            {
                if (checkedListProtocolsEnabled.Items[index].ToString() != "SSL 2.0" && checkedListProtocolsEnabled.Items[index].ToString() != "TLS 1.0"
                    && checkedListProtocolsEnabled.Items[index].ToString() != "TLS 1.1" && checkedListProtocolsEnabled.Items[index].ToString() != "TLS 1.2")
                {
                    checkedListProtocolsEnabled.SetItemCheckState(index, CheckState.Indeterminate);
                }
            }
            for (int index = 0; index < checkedListCipherEnabled.Items.Count; index++)
            {
                if (checkedListCipherEnabled.Items[index].ToString() == "Triple DES 168/168" || checkedListCipherEnabled.Items[index].ToString() == "AES 128/128"
                    || checkedListCipherEnabled.Items[index].ToString() == "AES 256/256")                    
                {
                    checkedListCipherEnabled.SetItemCheckState(index, CheckState.Indeterminate);
                }
            }
            for (int index = 0; index < checkedListHashesEnabled.Items.Count; index++)
            {
                if (checkedListHashesEnabled.Items[index].ToString() != "MD5")
                {
                    checkedListHashesEnabled.SetItemCheckState(index, CheckState.Indeterminate);
                }
            }
            for (int index = 0; index < checkedListKeyExchangesEnabled.Items.Count; index++)
            {
                if (checkedListKeyExchangesEnabled.Items[index].ToString() != "SRP" && checkedListKeyExchangesEnabled.Items[index].ToString() != "PSK"
                    && checkedListKeyExchangesEnabled.Items[index].ToString() != "CAMELLIA")
                {
                    checkedListKeyExchangesEnabled.SetItemCheckState(index, CheckState.Indeterminate);
                }
            }

            UpdateSslCipherSuiteCheckedList();
        }

        private void CustomerToolStripMenuItemClick(object sender, EventArgs e)
        {
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
                string url = urlForSSLScan.Text;
                string port = string.IsNullOrWhiteSpace(textBoxPort.Text) ? "443" : textBoxPort.Text;
                var cmd = "/k SSLScan\\SSLScan /b " + url + ":" + port;
                if(!string.IsNullOrWhiteSpace(textBoxFilter.Text))
                {
                    cmd += " | find \"" + textBoxFilter.Text + "\"";
                }
                var p = new Process {StartInfo = new ProcessStartInfo("CMD.exe", cmd)};

                p.Start();
                p.WaitForExit();
            }
        }        

        private void LinkAboutLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var sInfo = new ProcessStartInfo("http://www.air-watch.com/");
            Process.Start(sInfo);
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
            GenerateBatFile();

            var cmd = "/c WeakCipherDisable.bat";
            var p = new Process { StartInfo = new ProcessStartInfo("CMD.exe", cmd) };

            p.Start();
            p.WaitForExit();
        }

        private void HelpDocumentToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open Help Document
            if (!File.Exists(@"CipherHardeningToolRef.pdf"))
            {
                MessageBox.Show("Document is missing, contact "
                    +"zhuozhuozhuol@gmail.com"
                    +" for details.");
            }
            else
            {
                Process.Start(@"CipherHardeningToolRef.pdf");
            }
        }

        #endregion

        private void UpdateSslCipherSuiteCheckedList()
        {
            // Clear all items first
            checkedListSSLCipherSuiteOrder.Items.Clear();

            #region Protocol - Server && Client

            for (int index = 0; index < checkedListProtocolsEnabled.Items.Count; index++)
            {
                if (checkedListProtocolsEnabled.GetItemChecked(index) && !checkedListSSLCipherSuiteOrder.Items.Contains(checkedListProtocolsEnabled.Items[index]))
                {
                    checkedListSSLCipherSuiteOrder.Items.Add(checkedListProtocolsEnabled.Items[index]);
                }
                else if(!checkedListSSLCipherSuiteOrderForDisable.Items.Contains(checkedListProtocolsEnabled.Items[index]))
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
                else if(!checkedListSSLCipherSuiteOrderForDisable.Items.Contains(checkedListCipherEnabled.Items[index]))
                {
                    checkedListSSLCipherSuiteOrderForDisable.Items.Add(checkedListCipherEnabled.Items[index]);
                }
            }

            #endregion

            #region Cipher Suites

            bool sslSelected = false, tlsSelected = false;
            foreach (var pe in checkedListProtocolsEnabled.CheckedItems)
            {
                if(pe.ToString().ToLower().Contains("ssl"))
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
                    if(!checkedListSSLCipherSuiteOrder.Items.Contains(scs) && !checkedListSSLCipherSuiteOrderForDisable.Items.Contains(scs))
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
            if(tlsSelected)     
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
        }

        private void CheckedListSslCipherSuiteOrderSelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // To Generate bat file
        public void GenerateBatFile()
        {
            var file = new StreamWriter(@".\WeakCipherDisable.bat");

            string cmdString = "::Author : Zhuo Li" + Environment.NewLine +
                        "::Date : " + DateTime.Now + Environment.NewLine +
                        "::Description : Improve weak cipher/cipher suites/protocols" + Environment.NewLine +
                        "@echo off" + Environment.NewLine + Environment.NewLine;
            file.WriteLine(cmdString);

            foreach (var scso in checkedListSSLCipherSuiteOrder.CheckedItems)
            {
                if (scso.ToString() == ("SSL 3.0"))
                {
                    cmdString = "::Check whether REGistry path exist. otherwise creating REGistry folder for it" + Environment.NewLine +
                                "REG QUERY \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" + scso + "\\Server\"" + Environment.NewLine +
                                "IF %ERRORLEVEL% EQU 0 goto Protocols" + scso.ToString().Replace(" ", "") + "ServerNotExist" + Environment.NewLine + Environment.NewLine +
                                ":Protocols" + scso.ToString().Replace(" ", "") + "ServerNotExist" + Environment.NewLine +
                                "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" + scso + "\\Server\"" + Environment.NewLine + Environment.NewLine +
                                "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" + scso + "\\Server \" /v \"DisabledByDefault\" /t REG_DWORD /d 0x00000000" + Environment.NewLine +
                                "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" + scso + "\\Server \" /v \"Enabled\" /t REG_DWORD /d 0x00000001" + Environment.NewLine +
                                "echo ..Protocols Server " + scso + " added" + Environment.NewLine + Environment.NewLine;
                    file.WriteLine(cmdString);

                    cmdString = "::Check whether REGistry path exist. otherwise creating REGistry folder for it" + Environment.NewLine +
                                "REG QUERY \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" + scso + "\\Client\"" + Environment.NewLine +
                                "IF %ERRORLEVEL% EQU 0 goto Protocols" + scso.ToString().Replace(" ", "") + "ClientNotExist" + Environment.NewLine + Environment.NewLine +
                                ":Protocols" + scso.ToString().Replace(" ", "") + "ClientNotExist" + Environment.NewLine +
                                "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" + scso + "\\Client\"" + Environment.NewLine + Environment.NewLine +
                                "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Protocols\\" + scso + "\\Client \" /v \"Enabled\" /t REG_DWORD /d 0x00000001" + Environment.NewLine +
                                "echo ..Protocols Client " + scso + " added" + Environment.NewLine + Environment.NewLine;
                    file.WriteLine(cmdString);
                }
                else if (scso.ToString() == "Triple DES 168/168" || scso.ToString() == "AES 128/128" || scso.ToString() == "AES 256/256")
                {
                    cmdString = "::Check whether REGistry path exist. otherwise creating REGistry folder for it" + Environment.NewLine +
                                "REG QUERY \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Ciphers\\" + scso + "\"" + Environment.NewLine +
                                "IF %ERRORLEVEL% EQU 0 goto Ciphers" + scso.ToString().Replace(" ", "") + "NotExist" + Environment.NewLine + Environment.NewLine +
                                ":Ciphers" + scso.ToString().Replace(" ", "") + "NotExist" + Environment.NewLine +
                                "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Ciphers\\" + scso + "\"" + Environment.NewLine + Environment.NewLine +
                                "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Ciphers\\" + scso + "\" /v \"Enabled\" /t REG_DWORD /d 0x00000001" + Environment.NewLine +
                                "echo ..Ciphers " + scso + " added" + Environment.NewLine + Environment.NewLine;
                    file.WriteLine(cmdString);
                }
                else
                {
                    cmdString = "::Check whether REGistry path exist. otherwise creating REGistry folder for it" + Environment.NewLine +
                                "REG QUERY \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" + scso + "\"" + Environment.NewLine +
                                "IF %ERRORLEVEL% EQU 0 goto CipherSuites" + scso.ToString().Replace(" ", "") + "NotExist" + Environment.NewLine + Environment.NewLine +
                                ":CipherSuites" + scso.ToString().Replace(" ", "") + "NotExist" + Environment.NewLine +
                                "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" + scso + "\"" + Environment.NewLine + Environment.NewLine +
                                "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" + scso + "\" /v \"DisabledByDefault\" /t REG_DWORD /d 0x00000000" + Environment.NewLine +
                                "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" + scso + "\" /v \"Enabled\" /t REG_DWORD /d 0x00000001" + Environment.NewLine +
                                "echo ..CipherSuites TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA added" + Environment.NewLine + Environment.NewLine;
                    file.WriteLine(cmdString);

                    // TODO: Update top10 cipher suites as highest priority in group policy                    
                }
            }

            foreach (var scsod in checkedListSSLCipherSuiteOrderForDisable.Items)
            {
                if (scsod.ToString() == ("PCT 1.0") || scsod.ToString() == ("SSL 2.0") || scsod.ToString() == ("TLS 1.0") 
                    || scsod.ToString() == ("TLS 1.1") || scsod.ToString() == ("TLS 1.2"))
                {
                }
                else if (scsod.ToString() == "NULL" || scsod.ToString() == "DES 56/56" || scsod.ToString() == "RC2 40/128" || scsod.ToString() == "RC2 56/128"
                    || scsod.ToString() == "RC2 128/128" || scsod.ToString() == "RC4 40/128" || scsod.ToString() == "RC4 56/128" || scsod.ToString() == "RC4 64/128"
                    || scsod.ToString() == "RC4 128/128")
                {
                    cmdString = "::Check whether REGistry path exist. otherwise creating REGistry folder for it" + Environment.NewLine +
                                "REG QUERY \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Ciphers\\" + scsod + "\"" + Environment.NewLine +
                                "IF %ERRORLEVEL% EQU 0 goto Ciphers" + scsod.ToString().Replace(" ", "") + "NotExist" + Environment.NewLine + Environment.NewLine +
                                ":Ciphers" + scsod.ToString().Replace(" ", "") + "NotExist" + Environment.NewLine +
                                "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Ciphers\\" + scsod + "\"" + Environment.NewLine + Environment.NewLine +
                                "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\Ciphers\\" + scsod + "\" /v \"Enabled\" /t REG_DWORD /d 0x00000000" + Environment.NewLine +
                                "echo ..Ciphers " + scsod + " added" + Environment.NewLine + Environment.NewLine;
                    file.WriteLine(cmdString);
                }
                else
                {
                    cmdString = "::Check whether REGistry path exist. otherwise creating REGistry folder for it" + Environment.NewLine +
                                "REG QUERY \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" + scsod + "\"" + Environment.NewLine +
                                "IF %ERRORLEVEL% EQU 0 goto CipherSuites" + scsod.ToString().Replace(" ", "") + "NotExist" + Environment.NewLine + Environment.NewLine +
                                ":CipherSuites" + scsod.ToString().Replace(" ", "") + "NotExist" + Environment.NewLine +
                                "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" + scsod + "\"" + Environment.NewLine + Environment.NewLine +
                                "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" + scsod + "\" /v \"DisabledByDefault\" /t REG_DWORD /d 0x00000001" + Environment.NewLine +
                                "REG ADD \"HKLM\\System\\CurrentControlSet\\Control\\SecurityProviders\\SCHANNEL\\CipherSuites\\" + scsod + "\" /v \"Enabled\" /t REG_DWORD /d 0x00000000" + Environment.NewLine +
                                "echo ..CipherSuites TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA added" + Environment.NewLine + Environment.NewLine;
                    file.WriteLine(cmdString);

                    // TODO: Update top10 cipher suites as highest priority in group policy                    
                }
            }

            cmdString = "echo done" + Environment.NewLine +
                        "pause";
            file.WriteLine(cmdString);
            file.Close();
        }

        private void linkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.lostscroll.com");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.lostscroll.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "mailto:zhuozhuozhuol@gmail.com?subject=whatever&body=whatever";
            proc.Start();
        }
    }
}
