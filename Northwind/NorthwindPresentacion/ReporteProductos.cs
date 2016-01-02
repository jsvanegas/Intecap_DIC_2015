using Microsoft.Reporting.WinForms;
using NorthwindNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindPresentacion
{
    public partial class ReporteProductos : Form
    {
        public ReporteProductos()
        {
            InitializeComponent();
        }

        private void ReporteProductos_Load(object sender, EventArgs e)
        {
            this.rv.RefreshReport();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            ProductosDelegado delegado = new ProductosDelegado();
            var lista = delegado.consultarTopProductos(txtFechaInicio.Value, txtFechaFin.Value);
            ReportDataSource datasource = new ReportDataSource("DataSet1", lista);
            rv.LocalReport.ReportPath = "TopProductos.rdlc";
            rv.LocalReport.DataSources.Clear();
            rv.LocalReport.DataSources.Add(datasource);
            rv.RefreshReport();
        }
    }
}
