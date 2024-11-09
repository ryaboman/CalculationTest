using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Calculation.bll;

namespace Calculation {
    public partial class FormCalc : Form {
        
        public FormCalc() {
            InitializeComponent();
        }

        private void btnCalculation_Click(object sender, EventArgs e) {
            string expressionString = textBoxOfExpression.Text;
            Expression expression = new Expression(expressionString);
            float result = expression.Calculation();
            textBoxOfResault.Text = result.ToString();
            
        }
    }
}
