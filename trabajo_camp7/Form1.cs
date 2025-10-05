using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabajo_camp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            {
                // ------------------ PREPARACIÓN ------------------
                lstResultadoCadena.Items.Clear();
                lstSalarioMensual.Items.Clear();
                lstSalarioAnual.Items.Clear();

                // Obtener valores de los TextBoxes (cadenas)
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string salarioTexto = txtSalarioMensual.Text;

                // 1. Limpieza con Trim() para eliminar espacios innecesarios al inicio y final
                string nombreLimpio = nombre.Trim();
                string nombreCompleto = nombreLimpio + " " + apellido.Trim(); // Concatenación

                lstResultadoCadena.Items.Add("--- MANIPULACIÓN DE CADENAS ---");
                lstResultadoCadena.Items.Add($"Nombre Completo (Concatenado): {nombreCompleto}");
                lstResultadoCadena.Items.Add($"Longitud del Nombre: {nombreLimpio.Length}");

                // 2. Acceso por índice: Primer carácter (VALIDADO)
                if (nombreLimpio.Length > 0)
                {
                    lstResultadoCadena.Items.Add($"Primer Carácter: {nombreLimpio[0]}");
                }
                else
                {
                    lstResultadoCadena.Items.Add($"Primer Carácter: (Nombre vacío)");
                }

                // Conversión a mayúsculas/minúsculas
                lstResultadoCadena.Items.Add($"Nombre Completo en Mayúsculas: {nombreLimpio.ToUpper()}");
                ;
                lstResultadoCadena.Items.Add($"Nombre Completo en Minúsculas: {nombreLimpio.ToLower()}");

                // 3. Substring: Primeros 3 caracteres (VALIDADO)
                string subStringResultado = nombreLimpio.Length >= 3 ?
                                            nombreLimpio.Substring(0, 3) :
                                            "Menos de 3 caracteres";
                lstResultadoCadena.Items.Add($"Substring (Primeros 3): {subStringResultado}");

                // IndexOf: Posición de la primera 'a'
                int indiceA = nombreLimpio.ToLower().IndexOf('a');
                lstResultadoCadena.Items.Add($"Índice de la primera 'a': {indiceA}");

                // Replace: Reemplazar 'a' por '@'
                string replaceResultado = nombreLimpio.Replace('a', '@').Replace('A', '@');
                lstResultadoCadena.Items.Add($"Replace ('a' por '@'): {replaceResultado}");

                // Split y Ordenación de palabras
                lstResultadoCadena.Items.Add("--- Split y Ordenación ---");
                string[] palabras = nombreCompleto.Split(' ');
                List<string> palabrasOrdenadas = new List<string>(palabras);
                palabrasOrdenadas.Sort();
                lstResultadoCadena.Items.Add("Palabras ordenadas:");
                foreach (string p in palabrasOrdenadas)
                {
                    if (!string.IsNullOrWhiteSpace(p)) // 4. Ignora elementos vacíos
                    {
                        lstResultadoCadena.Items.Add($" - {p}");
                    }
                }


                // ------------------ CÁLCULO DE SALARIO ------------------

                lstSalarioMensual.Items.Add("--- CÁLCULO DE SALARIO ---");

                decimal salarioMensual;
                // Uso de TryParse para prevenir errores si el salario no es un número
                if (decimal.TryParse(salarioTexto, out salarioMensual))
                {
                    lstSalarioMensual.Items.Add($"Mensual: {salarioMensual:C}");

                    decimal salarioAnual = salarioMensual * 12;

                    lstSalarioAnual.Items.Add($"Anual: {salarioAnual:C}");
                }
                else
                {
                    // Mensaje de error si la conversión falla
                    lstSalarioMensual.Items.Add("ERROR: Salario Mensual no válido.");
                    lstSalarioAnual.Items.Add("ERROR: Verifique el ingreso.");
                }
            }
        }
        
    }
}
