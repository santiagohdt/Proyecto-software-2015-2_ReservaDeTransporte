namespace AdminItinerariosUQ.MenuPrincipal
{
    partial class MenuPrincipal
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonFacultades = new System.Windows.Forms.Button();
            this.buttonVehiculos = new System.Windows.Forms.Button();
            this.buttonUsuarios = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonItinerario = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonFacultades);
            this.groupBox1.Controls.Add(this.buttonVehiculos);
            this.groupBox1.Controls.Add(this.buttonUsuarios);
            this.groupBox1.Location = new System.Drawing.Point(23, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 399);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuración";
            // 
            // buttonFacultades
            // 
            this.buttonFacultades.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFacultades.Location = new System.Drawing.Point(42, 258);
            this.buttonFacultades.Name = "buttonFacultades";
            this.buttonFacultades.Size = new System.Drawing.Size(249, 105);
            this.buttonFacultades.TabIndex = 2;
            this.buttonFacultades.Text = "Facultades";
            this.buttonFacultades.UseVisualStyleBackColor = true;
            this.buttonFacultades.Click += new System.EventHandler(this.buttonFacultades_Click);
            // 
            // buttonVehiculos
            // 
            this.buttonVehiculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVehiculos.Location = new System.Drawing.Point(42, 147);
            this.buttonVehiculos.Name = "buttonVehiculos";
            this.buttonVehiculos.Size = new System.Drawing.Size(249, 105);
            this.buttonVehiculos.TabIndex = 1;
            this.buttonVehiculos.Text = "Vehículos";
            this.buttonVehiculos.UseVisualStyleBackColor = true;
            this.buttonVehiculos.Click += new System.EventHandler(this.buttonVehiculos_Click);
            // 
            // buttonUsuarios
            // 
            this.buttonUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUsuarios.Location = new System.Drawing.Point(42, 35);
            this.buttonUsuarios.Name = "buttonUsuarios";
            this.buttonUsuarios.Size = new System.Drawing.Size(249, 105);
            this.buttonUsuarios.TabIndex = 0;
            this.buttonUsuarios.Text = "Usuarios";
            this.buttonUsuarios.UseVisualStyleBackColor = true;
            this.buttonUsuarios.Click += new System.EventHandler(this.buttonUsuarios_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonItinerario);
            this.groupBox2.Location = new System.Drawing.Point(463, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 399);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestionar itinerario";
            // 
            // buttonItinerario
            // 
            this.buttonItinerario.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonItinerario.Location = new System.Drawing.Point(40, 35);
            this.buttonItinerario.Name = "buttonItinerario";
            this.buttonItinerario.Size = new System.Drawing.Size(249, 105);
            this.buttonItinerario.TabIndex = 0;
            this.buttonItinerario.Text = "Itinerario";
            this.buttonItinerario.UseVisualStyleBackColor = true;
            this.buttonItinerario.Click += new System.EventHandler(this.buttonItinerario_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(913, 440);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonFacultades;
        private System.Windows.Forms.Button buttonVehiculos;
        private System.Windows.Forms.Button buttonUsuarios;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonItinerario;
    }
}