﻿using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PKHeX
{
    public partial class SAV_BoxLayout : Form
    {
        public SAV_BoxLayout(Form1 frm1)
        {
            m_parent = frm1;
            InitializeComponent();
            Util.TranslateInterface(this, Form1.curlanguage);
            editing = true;
            Array.Copy(m_parent.savefile, sav, 0x100000);
            savindex = m_parent.savindex;

            // Repopulate Wallpaper names
            CB_BG.Items.Clear();
            foreach (string wallpaper in Form1.wallpapernames)
                CB_BG.Items.Add(wallpaper);

            // Go
            LB_BoxSelect.SelectedIndex = m_parent.CB_BoxSelect.SelectedIndex;
        }
        Form1 m_parent;
        public byte[] sav = new byte[0x100000];
        public int savindex;
        public bool editing;

        private void changeBox(object sender, EventArgs e)
        {
            editing = true;
            int index = LB_BoxSelect.SelectedIndex;
            int offset = 0x9800 + savindex * 0x7F000;
            int bgoff = (0x7F000 * savindex) + 0x9C1E + LB_BoxSelect.SelectedIndex;
            CB_BG.SelectedIndex = sav[bgoff];
            changeBoxBG(null, null);
            TB_BoxName.Text = Encoding.Unicode.GetString(sav, offset + 0x22 * index, 0x22);
            CB_BG.SelectedIndex = sav[0x9C1E + savindex * 0x7F000 + index];

            MT_BG1.Text = sav[0x9C3D + savindex * 0x7F000].ToString();
            MT_BG2.Text = sav[0x9C3F + savindex * 0x7F000].ToString();

            CB_Unlocked.SelectedIndex = sav[0x9C3E + savindex * 0x7F000] - 1;
            editing = false; 
        }
        private void changeBoxDetails(object sender, EventArgs e)
        {
            if (editing) return;

            int index = LB_BoxSelect.SelectedIndex;
            int offset = 0x9800 + savindex * 0x7F000;

            sav[(0x7F000 * savindex) + 0x9C1E + LB_BoxSelect.SelectedIndex] = (byte)CB_BG.SelectedIndex;

            // Get Sender Index

            byte[] boxname = Encoding.Unicode.GetBytes(TB_BoxName.Text);
            Array.Resize(ref boxname, 0x22);
            Array.Copy(boxname, 0, sav, offset + 0x22 * index, boxname.Length);

            sav[0x9C1E + savindex * 0x7F000 + index] = (byte)CB_BG.SelectedIndex;
            sav[0x9C3D + savindex * 0x7F000] = (byte)Util.ToUInt32(MT_BG1.Text);
            sav[0x9C3F + savindex * 0x7F000] = (byte)Util.ToUInt32(MT_BG2.Text);
            sav[0x9C3E + savindex * 0x7F000] = (byte)Util.ToUInt32(CB_Unlocked.Text);
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void B_Save_Click(object sender, EventArgs e)
        {
            Array.Copy(sav, m_parent.savefile, 0x100000);
            m_parent.savedited = true;
            Close();
        }

        private void changeBoxBG(object sender, EventArgs e)
        {
            sav[(0x7F000 * savindex) + 0x9C1E + LB_BoxSelect.SelectedIndex] = (byte)CB_BG.SelectedIndex;

            string imagename = "box_wp" + (CB_BG.SelectedIndex + 1).ToString("00"); if (m_parent.savegame_oras && (CB_BG.SelectedIndex + 1) > 16) imagename += "o";
            PAN_BG.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(imagename);
        }
    }
}