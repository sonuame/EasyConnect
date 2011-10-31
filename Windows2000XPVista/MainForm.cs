using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using WeifenLuo.WinFormsUI.Docking;

namespace UltraRDC
{
    public partial class MainForm : Form
    {
        protected FavoritesWindow _favorites = null;
        protected HistoryWindow _history = null;
        protected SecureString _password = null;

        public delegate void ConnectionDelegate(RDCConnection connection);

        public MainForm()
        {
            InitializeComponent();

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\UltraRDC"))
            {
                MessageBox.Show("Since this is the first time that you have run this application,\nyou will be asked to enter an access password.  This password will\nbe used to protect any passwords that you associate with your\nconnections.", "Create password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\UltraRDC");
            }

            while (_favorites == null || _history == null)
            {
                PasswordWindow passwordWindow = new PasswordWindow();
                passwordWindow.ShowDialog();

                _password = passwordWindow.Password;
                _password.MakeReadOnly();

                try
                {
                    _favorites = new FavoritesWindow(new ConnectionDelegate(Connect), _password);
                    _history = new HistoryWindow(new ConnectionDelegate(Connect), _favorites, _password);
                }

                catch (CryptographicException e)
                {
                    DialogResult result = MessageBox.Show("Password is incorrect.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                    if (result != DialogResult.OK)
                    {
                        Closing = true;
                        return;
                    }
                }
            }

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\UltraRDC\\Windows.xml"))
                dockPanel.LoadFromXml(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\UltraRDC\\Windows.xml", new DeserializeDockContent(GetContentFromPersistString));

            else
            {
                _favorites.Show(dockPanel, DockState.DockLeftAutoHide);
                _history.Show(dockPanel, DockState.DockLeftAutoHide);
            }

            _favorites.Password = _password;
            _history.Password = _password;

            dockPanel.ActiveAutoHideContent = null;
        }

        protected IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(HistoryWindow).ToString())
                return _history;

            else if (persistString == typeof(FavoritesWindow).ToString())
                return _favorites;

            else
                return null;
        }

        public bool Closing
        {
            get;
            set;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            dockPanel.Width = ClientSize.Width;
            dockPanel.Height = ClientSize.Height - dockPanel.Location.Y;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            Connect(new RDCConnection(_password) { Host = hostTextBox.Text });
        }

        protected void Connect(RDCConnection connection)
        {
            _history.AddToHistory(connection);
            
            RDCWindow sessionWindow = new RDCWindow();

            _history.DockHandler.GiveUpFocus();
            _favorites.DockHandler.GiveUpFocus();

            sessionWindow.Show(dockPanel, DockState.Document);
            sessionWindow.Connect(connection);
        }

        private void newConnectionButton_Click(object sender, EventArgs e)
        {
            ConnectionWindow connectionWindow = new ConnectionWindow(_favorites, new ConnectionDelegate(Connect), _password);
            connectionWindow.ShowDialog(this);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _favorites.Save();
            dockPanel.SaveAsXml(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\UltraRDC\\Windows.xml");
        }

        private void hostTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                connectButton_Click(null, null);
        }
    }
}
