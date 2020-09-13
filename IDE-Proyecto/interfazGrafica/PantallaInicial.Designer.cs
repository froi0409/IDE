namespace IDE_Proyecto.interfazGrafica
{
    partial class PantallaInicial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAbrirA = new System.Windows.Forms.Button();
            this.btnCrearA = new System.Windows.Forms.Button();
            this.btnAbrirP = new System.Windows.Forms.Button();
            this.btnCrearP = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione Una Opción";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAbrirA);
            this.panel1.Controls.Add(this.btnCrearA);
            this.panel1.Controls.Add(this.btnAbrirP);
            this.panel1.Controls.Add(this.btnCrearP);
            this.panel1.Location = new System.Drawing.Point(12, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 310);
            this.panel1.TabIndex = 1;
            // 
            // btnAbrirA
            // 
            this.btnAbrirA.BackColor = System.Drawing.SystemColors.Control;
            this.btnAbrirA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirA.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirA.Image = global::IDE_Proyecto.Properties.Resources.notepad_3_opt;
            this.btnAbrirA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbrirA.Location = new System.Drawing.Point(160, 186);
            this.btnAbrirA.Name = "btnAbrirA";
            this.btnAbrirA.Size = new System.Drawing.Size(339, 55);
            this.btnAbrirA.TabIndex = 3;
            this.btnAbrirA.Text = "Abrir Archivo";
            this.btnAbrirA.UseVisualStyleBackColor = false;
            this.btnAbrirA.Click += new System.EventHandler(this.btnAbrirA_Click);
            // 
            // btnCrearA
            // 
            this.btnCrearA.BackColor = System.Drawing.SystemColors.Control;
            this.btnCrearA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearA.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearA.Image = global::IDE_Proyecto.Properties.Resources.notepad_opt;
            this.btnCrearA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearA.Location = new System.Drawing.Point(160, 125);
            this.btnCrearA.Name = "btnCrearA";
            this.btnCrearA.Size = new System.Drawing.Size(339, 55);
            this.btnCrearA.TabIndex = 2;
            this.btnCrearA.Text = "Crear Archivo";
            this.btnCrearA.UseVisualStyleBackColor = false;
            this.btnCrearA.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnAbrirP
            // 
            this.btnAbrirP.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAbrirP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirP.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirP.Image = global::IDE_Proyecto.Properties.Resources.folder_3_opt;
            this.btnAbrirP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbrirP.Location = new System.Drawing.Point(160, 64);
            this.btnAbrirP.Name = "btnAbrirP";
            this.btnAbrirP.Size = new System.Drawing.Size(339, 55);
            this.btnAbrirP.TabIndex = 1;
            this.btnAbrirP.Text = "Abrir Proyecto";
            this.btnAbrirP.UseVisualStyleBackColor = false;
            this.btnAbrirP.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCrearP
            // 
            this.btnCrearP.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCrearP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCrearP.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCrearP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearP.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearP.Image = global::IDE_Proyecto.Properties.Resources.folder_opt;
            this.btnCrearP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearP.Location = new System.Drawing.Point(160, 3);
            this.btnCrearP.Name = "btnCrearP";
            this.btnCrearP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCrearP.Size = new System.Drawing.Size(339, 55);
            this.btnCrearP.TabIndex = 0;
            this.btnCrearP.Text = "Crear Proyecto";
            this.btnCrearP.UseVisualStyleBackColor = false;
            this.btnCrearP.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Archivos de Código Fuente (*.gt)| *.gt";
            // 
            // PantallaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(666, 438);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "PantallaInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PantallaInicial";
            this.Load += new System.EventHandler(this.PantallaInicial_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCrearP;
        private System.Windows.Forms.Button btnAbrirA;
        private System.Windows.Forms.Button btnCrearA;
        private System.Windows.Forms.Button btnAbrirP;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}