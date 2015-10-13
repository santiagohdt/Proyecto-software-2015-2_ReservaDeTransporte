namespace AdminItinerariosUQ.Configuracion
{
    partial class ConfiguracionFacultades
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
            this.textFacultad = new System.Windows.Forms.TextBox();
            this.dataFacultades = new System.Windows.Forms.DataGridView();
            this.buttonAlmacenar = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonNuevo = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataFacultades)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Facultad:";
            // 
            // textFacultad
            // 
            this.textFacultad.Location = new System.Drawing.Point(114, 24);
            this.textFacultad.Name = "textFacultad";
            this.textFacultad.Size = new System.Drawing.Size(497, 20);
            this.textFacultad.TabIndex = 1;
            // 
            // dataFacultades
            // 
            this.dataFacultades.AllowUserToAddRows = false;
            this.dataFacultades.AllowUserToDeleteRows = false;
            this.dataFacultades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFacultades.Location = new System.Drawing.Point(67, 112);
            this.dataFacultades.Name = "dataFacultades";
            this.dataFacultades.ReadOnly = true;
            this.dataFacultades.Size = new System.Drawing.Size(544, 204);
            this.dataFacultades.TabIndex = 6;
            this.dataFacultades.Click += new System.EventHandler(this.dataFacultades_Click);
            // 
            // buttonAlmacenar
            // 
            this.buttonAlmacenar.Location = new System.Drawing.Point(81, 60);
            this.buttonAlmacenar.Name = "buttonAlmacenar";
            this.buttonAlmacenar.Size = new System.Drawing.Size(119, 36);
            this.buttonAlmacenar.TabIndex = 2;
            this.buttonAlmacenar.Text = "ALMACENAR";
            this.buttonAlmacenar.UseVisualStyleBackColor = true;
            this.buttonAlmacenar.Click += new System.EventHandler(this.buttonAlmacenar_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(213, 60);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(119, 36);
            this.buttonModificar.TabIndex = 3;
            this.buttonModificar.Text = "MODIFICAR";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonNuevo
            // 
            this.buttonNuevo.Location = new System.Drawing.Point(345, 60);
            this.buttonNuevo.Name = "buttonNuevo";
            this.buttonNuevo.Size = new System.Drawing.Size(119, 36);
            this.buttonNuevo.TabIndex = 4;
            this.buttonNuevo.Text = "NUEVO";
            this.buttonNuevo.UseVisualStyleBackColor = true;
            this.buttonNuevo.Click += new System.EventHandler(this.buttonNuevo_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(477, 60);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(119, 36);
            this.buttonEliminar.TabIndex = 5;
            this.buttonEliminar.Text = "ELIMINAR";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // ConfiguracionFacultades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(664, 340);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonNuevo);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.buttonAlmacenar);
            this.Controls.Add(this.dataFacultades);
            this.Controls.Add(this.textFacultad);
            this.Controls.Add(this.label1);
            this.Name = "ConfiguracionFacultades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfiguracionFacultades";
            ((System.ComponentModel.ISupportInitialize)(this.dataFacultades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textFacultad;
        private System.Windows.Forms.DataGridView dataFacultades;
        private System.Windows.Forms.Button buttonAlmacenar;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonNuevo;
        private System.Windows.Forms.Button buttonEliminar;
    }
}