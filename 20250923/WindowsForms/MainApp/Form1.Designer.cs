namespace MainApp
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
            BtnSubmit = new Button();
            label1 = new Label();
            Input_FullName = new TextBox();
            SuspendLayout();
            // 
            // BtnSubmit
            // 
            BtnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnSubmit.Location = new Point(201, 227);
            BtnSubmit.Name = "BtnSubmit";
            BtnSubmit.Size = new Size(280, 76);
            BtnSubmit.TabIndex = 0;
            BtnSubmit.Text = "Submit";
            BtnSubmit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(152, 91);
            label1.Name = "label1";
            label1.Size = new Size(107, 30);
            label1.TabIndex = 1;
            label1.Text = "Full Name";
            // 
            // Input_FullName
            // 
            Input_FullName.Location = new Point(152, 124);
            Input_FullName.Name = "Input_FullName";
            Input_FullName.Size = new Size(417, 35);
            Input_FullName.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 395);
            Controls.Add(Input_FullName);
            Controls.Add(label1);
            Controls.Add(BtnSubmit);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnSubmit;
        private Label label1;
        private TextBox Input_FullName;
    }
}
