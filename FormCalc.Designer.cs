
namespace Calculation {
    partial class FormCalc {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.btnCalculation = new System.Windows.Forms.Button();
            this.textBoxOfExpression = new System.Windows.Forms.TextBox();
            this.textBoxOfResault = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StatusOfCalculation = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCalculation
            // 
            this.btnCalculation.Location = new System.Drawing.Point(28, 100);
            this.btnCalculation.Name = "btnCalculation";
            this.btnCalculation.Size = new System.Drawing.Size(188, 43);
            this.btnCalculation.TabIndex = 0;
            this.btnCalculation.Text = "Вычислить";
            this.btnCalculation.UseVisualStyleBackColor = true;
            this.btnCalculation.Click += new System.EventHandler(this.btnCalculation_Click);
            // 
            // textBoxOfExpression
            // 
            this.textBoxOfExpression.Location = new System.Drawing.Point(28, 25);
            this.textBoxOfExpression.Multiline = true;
            this.textBoxOfExpression.Name = "textBoxOfExpression";
            this.textBoxOfExpression.Size = new System.Drawing.Size(188, 67);
            this.textBoxOfExpression.TabIndex = 1;
            this.textBoxOfExpression.Text = "(17+35)*3,4/sin(15)";
            // 
            // textBoxOfResault
            // 
            this.textBoxOfResault.Location = new System.Drawing.Point(28, 173);
            this.textBoxOfResault.Name = "textBoxOfResault";
            this.textBoxOfResault.Size = new System.Drawing.Size(188, 20);
            this.textBoxOfResault.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Результат";
            // 
            // StatusOfCalculation
            // 
            this.StatusOfCalculation.AutoSize = true;
            this.StatusOfCalculation.Location = new System.Drawing.Point(27, 205);
            this.StatusOfCalculation.Name = "StatusOfCalculation";
            this.StatusOfCalculation.Size = new System.Drawing.Size(114, 13);
            this.StatusOfCalculation.TabIndex = 3;
            this.StatusOfCalculation.Text = "К вычислению готов!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Выражение";
            // 
            // FormCalc
            // 
            this.AcceptButton = this.btnCalculation;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 226);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StatusOfCalculation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOfResault);
            this.Controls.Add(this.textBoxOfExpression);
            this.Controls.Add(this.btnCalculation);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(260, 265);
            this.MinimumSize = new System.Drawing.Size(260, 265);
            this.Name = "FormCalc";
            this.Text = "Калькулятор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculation;
        private System.Windows.Forms.TextBox textBoxOfExpression;
        private System.Windows.Forms.TextBox textBoxOfResault;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label StatusOfCalculation;
        private System.Windows.Forms.Label label3;
    }
}

