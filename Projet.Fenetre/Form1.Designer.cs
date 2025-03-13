using System.Windows.Forms;

namespace Projet.Fenetre
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            logginToolStripMenuItem = new ToolStripMenuItem();
            mAJJsonToolStripMenuItem = new ToolStripMenuItem();
            listeDesMouvementsPDFToolStripMenuItem = new ToolStripMenuItem();
            recapitulationDesOpérationsXMLToolStripMenuItem = new ToolStripMenuItem();
            listeToolStripMenuItemListeCartes = new ToolStripMenuItem();
            panel1 = new Panel();
            panelMajJSON = new Panel();
            panelPDF = new Panel();
            panelCarteListe = new Panel();
            dataGridViewCartes = new DataGridView();
            Compte_Bancaire = new DataGridViewTextBoxColumn();
            Carte_Bancaire = new DataGridViewTextBoxColumn();
            buttonListeCartes = new Button();
            textBoxPDFConsole = new TextBox();
            buttonPDF = new Button();
            textBoxPDFNum = new TextBox();
            labelPDFNum = new Label();
            labelPDFFin = new Label();
            labelPDFDebut = new Label();
            monthCalendarFin = new MonthCalendar();
            monthCalendarDebut = new MonthCalendar();
            textBoxRecapMajJSON = new TextBox();
            labelMajJSON = new Label();
            buttonMajJSON = new Button();
            labelAuthentification = new Label();
            buttonConnexion = new Button();
            labelMotDePasse = new Label();
            textBoxMotDePasse = new TextBox();
            labelIdentifiant = new Label();
            labelBienvenue = new Label();
            textBoxIdentifiant = new TextBox();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panelMajJSON.SuspendLayout();
            panelPDF.SuspendLayout();
            panelCarteListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCartes).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { logginToolStripMenuItem, mAJJsonToolStripMenuItem, listeDesMouvementsPDFToolStripMenuItem, recapitulationDesOpérationsXMLToolStripMenuItem, listeToolStripMenuItemListeCartes });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // logginToolStripMenuItem
            // 
            logginToolStripMenuItem.Name = "logginToolStripMenuItem";
            logginToolStripMenuItem.Size = new Size(56, 20);
            logginToolStripMenuItem.Text = "Loggin";
            logginToolStripMenuItem.Click += logginToolStripMenuItem_Click;
            // 
            // mAJJsonToolStripMenuItem
            // 
            mAJJsonToolStripMenuItem.Enabled = false;
            mAJJsonToolStripMenuItem.Name = "mAJJsonToolStripMenuItem";
            mAJJsonToolStripMenuItem.Size = new Size(69, 20);
            mAJJsonToolStripMenuItem.Text = "MAJ Json";
            mAJJsonToolStripMenuItem.Click += mAJJsonToolStripMenuItem_Click;
            // 
            // listeDesMouvementsPDFToolStripMenuItem
            // 
            listeDesMouvementsPDFToolStripMenuItem.Enabled = false;
            listeDesMouvementsPDFToolStripMenuItem.Name = "listeDesMouvementsPDFToolStripMenuItem";
            listeDesMouvementsPDFToolStripMenuItem.Size = new Size(169, 20);
            listeDesMouvementsPDFToolStripMenuItem.Text = "Liste des mouvements (PDF)";
            listeDesMouvementsPDFToolStripMenuItem.Click += listeDesMouvementsPDFToolStripMenuItem_Click;
            // 
            // recapitulationDesOpérationsXMLToolStripMenuItem
            // 
            recapitulationDesOpérationsXMLToolStripMenuItem.Enabled = false;
            recapitulationDesOpérationsXMLToolStripMenuItem.Name = "recapitulationDesOpérationsXMLToolStripMenuItem";
            recapitulationDesOpérationsXMLToolStripMenuItem.Size = new Size(210, 20);
            recapitulationDesOpérationsXMLToolStripMenuItem.Text = "Recapitulation des opérations (XML)";
            // 
            // listeToolStripMenuItemListeCartes
            // 
            listeToolStripMenuItemListeCartes.Enabled = false;
            listeToolStripMenuItemListeCartes.Name = "listeToolStripMenuItemListeCartes";
            listeToolStripMenuItemListeCartes.Size = new Size(98, 20);
            listeToolStripMenuItemListeCartes.Text = "Liste des cartes";
            listeToolStripMenuItemListeCartes.Click += listeToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panelMajJSON);
            panel1.Controls.Add(labelAuthentification);
            panel1.Controls.Add(buttonConnexion);
            panel1.Controls.Add(labelMotDePasse);
            panel1.Controls.Add(textBoxMotDePasse);
            panel1.Controls.Add(labelIdentifiant);
            panel1.Controls.Add(labelBienvenue);
            panel1.Controls.Add(textBoxIdentifiant);
            panel1.Location = new Point(0, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 425);
            panel1.TabIndex = 1;
            panel1.Visible = false;
            // 
            // panelMajJSON
            // 
            panelMajJSON.Controls.Add(panelPDF);
            panelMajJSON.Controls.Add(textBoxRecapMajJSON);
            panelMajJSON.Controls.Add(labelMajJSON);
            panelMajJSON.Controls.Add(buttonMajJSON);
            panelMajJSON.Location = new Point(0, 0);
            panelMajJSON.Name = "panelMajJSON";
            panelMajJSON.Size = new Size(800, 425);
            panelMajJSON.TabIndex = 7;
            panelMajJSON.Visible = false;
            // 
            // panelPDF
            // 
            panelPDF.Controls.Add(panelCarteListe);
            panelPDF.Controls.Add(textBoxPDFConsole);
            panelPDF.Controls.Add(buttonPDF);
            panelPDF.Controls.Add(textBoxPDFNum);
            panelPDF.Controls.Add(labelPDFNum);
            panelPDF.Controls.Add(labelPDFFin);
            panelPDF.Controls.Add(labelPDFDebut);
            panelPDF.Controls.Add(monthCalendarFin);
            panelPDF.Controls.Add(monthCalendarDebut);
            panelPDF.Location = new Point(0, 0);
            panelPDF.Name = "panelPDF";
            panelPDF.Size = new Size(800, 396);
            panelPDF.TabIndex = 2;
            panelPDF.Visible = false;
            // 
            // panelCarteListe
            // 
            panelCarteListe.Controls.Add(dataGridViewCartes);
            panelCarteListe.Controls.Add(buttonListeCartes);
            panelCarteListe.Location = new Point(0, 0);
            panelCarteListe.Name = "panelCarteListe";
            panelCarteListe.Size = new Size(800, 396);
            panelCarteListe.TabIndex = 8;
            panelCarteListe.Visible = false;
            // 
            // dataGridViewCartes
            // 
            dataGridViewCartes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCartes.Columns.AddRange(new DataGridViewColumn[] { Compte_Bancaire, Carte_Bancaire });
            dataGridViewCartes.Location = new Point(12, 19);
            dataGridViewCartes.Name = "dataGridViewCartes";
            dataGridViewCartes.Size = new Size(508, 374);
            dataGridViewCartes.TabIndex = 0;
            // 
            // Compte_Bancaire
            // 
            Compte_Bancaire.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Compte_Bancaire.FillWeight = 250F;
            Compte_Bancaire.HeaderText = "Compte Bancaire";
            Compte_Bancaire.Name = "Compte_Bancaire";
            Compte_Bancaire.Width = 113;
            // 
            // Carte_Bancaire
            // 
            Carte_Bancaire.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Carte_Bancaire.FillWeight = 250F;
            Carte_Bancaire.HeaderText = "Carte Bancaire";
            Carte_Bancaire.Name = "Carte_Bancaire";
            Carte_Bancaire.Width = 99;
            // 
            // buttonListeCartes
            // 
            buttonListeCartes.Location = new Point(571, 182);
            buttonListeCartes.Name = "buttonListeCartes";
            buttonListeCartes.Size = new Size(186, 23);
            buttonListeCartes.TabIndex = 0;
            buttonListeCartes.Text = "Afficher la liste des cartes";
            buttonListeCartes.UseVisualStyleBackColor = true;
            buttonListeCartes.Click += buttonListeCartes_Click;
            // 
            // textBoxPDFConsole
            // 
            textBoxPDFConsole.Location = new Point(12, 283);
            textBoxPDFConsole.Multiline = true;
            textBoxPDFConsole.Name = "textBoxPDFConsole";
            textBoxPDFConsole.ReadOnly = true;
            textBoxPDFConsole.Size = new Size(776, 95);
            textBoxPDFConsole.TabIndex = 7;
            // 
            // buttonPDF
            // 
            buttonPDF.Location = new Point(526, 246);
            buttonPDF.Name = "buttonPDF";
            buttonPDF.Size = new Size(114, 23);
            buttonPDF.TabIndex = 6;
            buttonPDF.Text = "Générer le PDF";
            buttonPDF.UseVisualStyleBackColor = true;
            buttonPDF.Click += buttonPDF_Click;
            // 
            // textBoxPDFNum
            // 
            textBoxPDFNum.Location = new Point(228, 247);
            textBoxPDFNum.Name = "textBoxPDFNum";
            textBoxPDFNum.Size = new Size(216, 23);
            textBoxPDFNum.TabIndex = 5;
            textBoxPDFNum.TextChanged += textBoxPDFNum_TextChanged;
            // 
            // labelPDFNum
            // 
            labelPDFNum.AutoSize = true;
            labelPDFNum.Location = new Point(71, 247);
            labelPDFNum.Name = "labelPDFNum";
            labelPDFNum.Size = new Size(111, 15);
            labelPDFNum.TabIndex = 4;
            labelPDFNum.Text = "Numero de compte";
            // 
            // labelPDFFin
            // 
            labelPDFFin.AutoSize = true;
            labelPDFFin.Location = new Point(555, 19);
            labelPDFFin.Name = "labelPDFFin";
            labelPDFFin.Size = new Size(50, 15);
            labelPDFFin.TabIndex = 3;
            labelPDFFin.Text = "Date Fin";
            // 
            // labelPDFDebut
            // 
            labelPDFDebut.AutoSize = true;
            labelPDFDebut.Location = new Point(116, 19);
            labelPDFDebut.Name = "labelPDFDebut";
            labelPDFDebut.Size = new Size(66, 15);
            labelPDFDebut.TabIndex = 2;
            labelPDFDebut.Text = "Date Debut";
            labelPDFDebut.Click += label1_Click_2;
            // 
            // monthCalendarFin
            // 
            monthCalendarFin.Location = new Point(463, 43);
            monthCalendarFin.Name = "monthCalendarFin";
            monthCalendarFin.TabIndex = 1;
            // 
            // monthCalendarDebut
            // 
            monthCalendarDebut.Location = new Point(43, 43);
            monthCalendarDebut.Name = "monthCalendarDebut";
            monthCalendarDebut.TabIndex = 0;
            // 
            // textBoxRecapMajJSON
            // 
            textBoxRecapMajJSON.Location = new Point(12, 130);
            textBoxRecapMajJSON.Multiline = true;
            textBoxRecapMajJSON.Name = "textBoxRecapMajJSON";
            textBoxRecapMajJSON.ReadOnly = true;
            textBoxRecapMajJSON.Size = new Size(776, 266);
            textBoxRecapMajJSON.TabIndex = 2;
            // 
            // labelMajJSON
            // 
            labelMajJSON.AutoSize = true;
            labelMajJSON.Location = new Point(320, 52);
            labelMajJSON.Name = "labelMajJSON";
            labelMajJSON.Size = new Size(170, 15);
            labelMajJSON.TabIndex = 1;
            labelMajJSON.Text = "Clickez pour lire le fichier JSON";
            // 
            // buttonMajJSON
            // 
            buttonMajJSON.Location = new Point(359, 88);
            buttonMajJSON.Name = "buttonMajJSON";
            buttonMajJSON.Size = new Size(75, 23);
            buttonMajJSON.TabIndex = 0;
            buttonMajJSON.Text = "MAJ JSON";
            buttonMajJSON.UseVisualStyleBackColor = true;
            buttonMajJSON.Click += buttonMajJSON_Click;
            // 
            // labelAuthentification
            // 
            labelAuthentification.AutoSize = true;
            labelAuthentification.Location = new Point(385, 303);
            labelAuthentification.Name = "labelAuthentification";
            labelAuthentification.Size = new Size(22, 15);
            labelAuthentification.TabIndex = 6;
            labelAuthentification.Text = "Co";
            labelAuthentification.Visible = false;
            // 
            // buttonConnexion
            // 
            buttonConnexion.Location = new Point(398, 247);
            buttonConnexion.Name = "buttonConnexion";
            buttonConnexion.Size = new Size(75, 23);
            buttonConnexion.TabIndex = 5;
            buttonConnexion.Text = "Connexion";
            buttonConnexion.UseVisualStyleBackColor = true;
            buttonConnexion.Click += buttonConnexion_Click;
            // 
            // labelMotDePasse
            // 
            labelMotDePasse.AutoSize = true;
            labelMotDePasse.Location = new Point(228, 145);
            labelMotDePasse.Name = "labelMotDePasse";
            labelMotDePasse.Size = new Size(77, 15);
            labelMotDePasse.TabIndex = 4;
            labelMotDePasse.Text = "Mot de passe";
            labelMotDePasse.Click += label1_Click_1;
            // 
            // textBoxMotDePasse
            // 
            textBoxMotDePasse.Location = new Point(320, 142);
            textBoxMotDePasse.Name = "textBoxMotDePasse";
            textBoxMotDePasse.PasswordChar = '*';
            textBoxMotDePasse.Size = new Size(320, 23);
            textBoxMotDePasse.TabIndex = 3;
            // 
            // labelIdentifiant
            // 
            labelIdentifiant.AutoSize = true;
            labelIdentifiant.Location = new Point(228, 96);
            labelIdentifiant.Name = "labelIdentifiant";
            labelIdentifiant.Size = new Size(61, 15);
            labelIdentifiant.TabIndex = 2;
            labelIdentifiant.Text = "Identifiant";
            // 
            // labelBienvenue
            // 
            labelBienvenue.AutoSize = true;
            labelBienvenue.Location = new Point(411, 52);
            labelBienvenue.Name = "labelBienvenue";
            labelBienvenue.Size = new Size(62, 15);
            labelBienvenue.TabIndex = 1;
            labelBienvenue.Text = "Bienvenue";
            labelBienvenue.Click += label1_Click;
            // 
            // textBoxIdentifiant
            // 
            textBoxIdentifiant.Location = new Point(320, 93);
            textBoxIdentifiant.Name = "textBoxIdentifiant";
            textBoxIdentifiant.Size = new Size(320, 23);
            textBoxIdentifiant.TabIndex = 0;
            textBoxIdentifiant.TextChanged += textBox1_TextChanged_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelMajJSON.ResumeLayout(false);
            panelMajJSON.PerformLayout();
            panelPDF.ResumeLayout(false);
            panelPDF.PerformLayout();
            panelCarteListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewCartes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem logginToolStripMenuItem;
        private ToolStripMenuItem mAJJsonToolStripMenuItem;
        private ToolStripMenuItem listeDesMouvementsPDFToolStripMenuItem;
        private ToolStripMenuItem recapitulationDesOpérationsXMLToolStripMenuItem;
        private Panel panel1;
        private TextBox textBoxIdentifiant;
        private Label labelBienvenue;
        private Label labelIdentifiant;
        private Label labelMotDePasse;
        private TextBox textBoxMotDePasse;
        private Label labelAuthentification;
        private Button buttonConnexion;
        private Panel panelMajJSON;
        private Label labelMajJSON;
        private Button buttonMajJSON;
        private TextBox textBoxRecapMajJSON;
        private Panel panelPDF;
        private Label labelPDFDebut;
        private MonthCalendar monthCalendarFin;
        private MonthCalendar monthCalendarDebut;
        private Label labelPDFNum;
        private Label labelPDFFin;
        private Button buttonPDF;
        private TextBox textBoxPDFNum;
        private TextBox textBoxPDFConsole;
        private ToolStripMenuItem listeToolStripMenuItemListeCartes;
        private Panel panelCarteListe;
        private DataGridView dataGridViewCartes;
        private Button buttonListeCartes;
        private DataGridViewTextBoxColumn Compte_Bancaire;
        private DataGridViewTextBoxColumn Carte_Bancaire;
    }
}
