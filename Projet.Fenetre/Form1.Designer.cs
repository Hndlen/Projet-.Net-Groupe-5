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
            panel1 = new Panel();
            panelMajJSON = new Panel();
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
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { logginToolStripMenuItem, mAJJsonToolStripMenuItem, listeDesMouvementsPDFToolStripMenuItem, recapitulationDesOpérationsXMLToolStripMenuItem });
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
            panelMajJSON.Controls.Add(textBoxRecapMajJSON);
            panelMajJSON.Controls.Add(labelMajJSON);
            panelMajJSON.Controls.Add(buttonMajJSON);
            panelMajJSON.Location = new Point(0, 0);
            panelMajJSON.Name = "panelMajJSON";
            panelMajJSON.Size = new Size(800, 425);
            panelMajJSON.TabIndex = 7;
            panelMajJSON.Visible = false;
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
    }
}
