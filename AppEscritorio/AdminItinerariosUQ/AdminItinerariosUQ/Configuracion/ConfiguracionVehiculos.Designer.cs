namespace AdminItinerariosUQ.Configuracion
{
    partial class ConfiguracionVehiculos
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
            this.dateSOAT = new System.Windows.Forms.DateTimePicker();
            this.textPlaca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textColor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTecnicoMecanica = new System.Windows.Forms.DateTimePicker();
            this.dataVechiculos = new System.Windows.Forms.DataGridView();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonNuevo = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonAlmacenar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataVechiculos)).BeginInit();
            this.SuspendLayout();
            // 
            // dateSOAT
            // 
            this.dateSOAT.Location = new System.Drawing.Point(467, 56);
            this.dateSOAT.Name = "dateSOAT";
            this.dateSOAT.Size = new System.Drawing.Size(232, 20);
            this.dateSOAT.TabIndex = 5;
            // 
            // textPlaca
            // 
            this.textPlaca.Location = new System.Drawing.Point(128, 53);
            this.textPlaca.Name = "textPlaca";
            this.textPlaca.Size = new System.Drawing.Size(232, 20);
            this.textPlaca.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Placa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Color:";
            // 
            // textColor
            // 
            this.textColor.Location = new System.Drawing.Point(128, 82);
            this.textColor.Name = "textColor";
            this.textColor.Size = new System.Drawing.Size(232, 20);
            this.textColor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "SOAT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Técnico Mecanica";
            // 
            // dateTecnicoMecanica
            // 
            this.dateTecnicoMecanica.Location = new System.Drawing.Point(467, 82);
            this.dateTecnicoMecanica.Name = "dateTecnicoMecanica";
            this.dateTecnicoMecanica.Size = new System.Drawing.Size(232, 20);
            this.dateTecnicoMecanica.TabIndex = 7;
            // 
            // dataVechiculos
            // 
            this.dataVechiculos.AllowUserToAddRows = false;
            this.dataVechiculos.AllowUserToDeleteRows = false;
            this.dataVechiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataVechiculos.Location = new System.Drawing.Point(33, 186);
            this.dataVechiculos.Name = "dataVechiculos";
            this.dataVechiculos.ReadOnly = true;
            this.dataVechiculos.Size = new System.Drawing.Size(718, 322);
            this.dataVechiculos.TabIndex = 12;
            this.dataVechiculos.Click += new System.EventHandler(this.dataVechiculos_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(526, 127);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(119, 36);
            this.buttonEliminar.TabIndex = 11;
            this.buttonEliminar.Text = "ELIMINAR";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonNuevo
            // 
            this.buttonNuevo.Location = new System.Drawing.Point(394, 127);
            this.buttonNuevo.Name = "buttonNuevo";
            this.buttonNuevo.Size = new System.Drawing.Size(119, 36);
            this.buttonNuevo.TabIndex = 10;
            this.buttonNuevo.Text = "NUEVO";
            this.buttonNuevo.UseVisualStyleBackColor = true;
            this.buttonNuevo.Click += new System.EventHandler(this.buttonNuevo_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(262, 127);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(119, 36);
            this.buttonModificar.TabIndex = 9;
            this.buttonModificar.Text = "MODIFICAR";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonAlmacenar
            // 
            this.buttonAlmacenar.Location = new System.Drawing.Point(130, 127);
            this.buttonAlmacenar.Name = "buttonAlmacenar";
            this.buttonAlmacenar.Size = new System.Drawing.Size(119, 36);
            this.buttonAlmacenar.TabIndex = 8;
            this.buttonAlmacenar.Text = "ALMACENAR";
            this.buttonAlmacenar.UseVisualStyleBackColor = true;
            this.buttonAlmacenar.Click += new System.EventHandler(this.buttonAlmacenar_Click);
            // 
            // ConfiguracionVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dataVechiculos);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonNuevo);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.buttonAlmacenar);
            this.Controls.Add(this.dateTecnicoMecanica);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateSOAT);
            this.Controls.Add(this.textPlaca);
            this.Name = "ConfiguracionVehiculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfiguracionVehiculos";
            ((System.ComponentModel.ISupportInitialize)(this.dataVechiculos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateSOAT;
        private System.Windows.Forms.TextBox textPlaca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTecnicoMecanica;
        private System.Windows.Forms.DataGridView dataVechiculos;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonNuevo;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonAlmacenar;
    }
}