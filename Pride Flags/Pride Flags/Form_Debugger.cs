using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pride_Flags
{
    public partial class Form_Debugger : Form
    {
        public Form_Debugger()
        {
            InitializeComponent();
        }

        internal static bool Invertir_Orden = true;
        internal static int Ordenar = 2;
        internal FileStream Lector_Depurador = null;
        internal BinaryReader Lector_Depurador_Binario = null;
        internal bool Ocupado = false;
        internal bool Variable_Siempre_Visible = false;

        private void Form_Debugger_Load(object sender, EventArgs e)
        {
            this.Icon = Jupisoft.Icono_Jupisoft.Clone() as Icon;
            this.WindowState = FormWindowState.Maximized;
            if (Form_Main.Variable_Modo_Oscuro)
            {
                foreach (Control Menú in this.Controls)
                {
                    try
                    {
                        /*//if (Menú.Image != null) Menú.Image = Jupisoft.Obtener_Imagen_Negativo(Menú.Image as Bitmap);
                        if (Menú is PictureBox)
                        {
                            //((PictureBox)Menú).BorderStyle = BorderStyle.FixedSingle;
                        }
                        if (Menú is TextBox)
                        {
                            //((TextBox)Menú).BorderStyle = BorderStyle.FixedSingle;
                        }
                        if (Menú is Button)
                        {
                            //((Button)Menú).FlatStyle = FlatStyle.Flat; //FlatStyle.Popup;
                        }*/
                        Menú.BackColor = Color.FromArgb(Menú.BackColor.A, 255 - Menú.BackColor.R, 255 - Menú.BackColor.G, 255 - Menú.BackColor.B);
                        Menú.ForeColor = Color.FromArgb(Menú.ForeColor.A, 255 - Menú.ForeColor.R, 255 - Menú.ForeColor.G, 255 - Menú.ForeColor.B);
                    }
                    catch { continue; }
                }

                // Invert the colors of the context menu items.
                Menú_Contextual.BackColor = Color.FromArgb(Menú_Contextual.BackColor.A, 255 - Menú_Contextual.BackColor.R, 255 - Menú_Contextual.BackColor.G, 255 - Menú_Contextual.BackColor.B);
                foreach (ToolStripItem Menú in Menú_Contextual.Items)
                {
                    try
                    {
                        if (!(Menú is ToolStripSeparator))
                        {
                            //if (Menú.Image != null) Menú.Image = Jupisoft.Obtener_Imagen_Negativo(Menú.Image as Bitmap);
                            //Menú.BackColor = Color.FromArgb(Menú.BackColor.A, 255 - Menú.BackColor.R, 255 - Menú.BackColor.G, 255 - Menú.BackColor.B);
                            Menú.ForeColor = Color.FromArgb(Menú.ForeColor.A, 255 - Menú.ForeColor.R, 255 - Menú.ForeColor.G, 255 - Menú.ForeColor.B);
                        }
                    }
                    catch (Exception Excepción) { continue; }
                }

                this.BackColor = Color.FromArgb(this.BackColor.A, 255 - this.BackColor.R, 255 - this.BackColor.G, 255 - this.BackColor.B);
            }
        }

        private void Form_Debugger_Shown(object sender, EventArgs e)
        {
            Ocupado = true;
            Menú_Contextual_Invertir_Orden.Checked = Invertir_Orden;
            Menú_Contextual.Items["Menú_Contextual_Ordenar_" + Ordenar.ToString()].PerformClick();
            Ocupado = false;
            Cargar_Errores();
            this.Activate();
        }

        private void Form_Debugger_FormClosing(object sender, FormClosingEventArgs e)
        {
            Lector_Depurador_Binario.Close();
            Lector_Depurador_Binario.Dispose();
            Lector_Depurador_Binario = null;
            Lector_Depurador.Close();
            Lector_Depurador.Dispose();
            Lector_Depurador = null;
        }

        private void Form_Debugger_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form_Debugger_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Alt && !e.Control && !e.Shift)
            {
                if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    this.Close();
                }
            }
        }

        private void Menú_Contextual_Enviar_Correo_Click(object sender, EventArgs e)
        {
            Jupisoft.Ejecutar_Ruta("mailto:jupitermauro@gmail.com?subject=Bugs " + Jupisoft.Texto_Título + " " + Jupisoft.Texto_Versión_Fecha, ProcessWindowStyle.Normal);
        }

        private void Menú_Contextual_Localizar_Debugger_Click(object sender, EventArgs e)
        {
            Jupisoft.Ejecutar_Ruta(Application.StartupPath, ProcessWindowStyle.Maximized);
        }

        private void Menú_Contextual_Invertir_Orden_CheckedChanged(object sender, EventArgs e)
        {
            Invertir_Orden = Menú_Contextual_Invertir_Orden.Checked;
            Cargar_Errores();
        }

        private void Menú_Contextual_Ordenar_Click(object sender, EventArgs e)
        {
            Ocupado = true;
            for (int Índice = 0; Índice < Menú_Contextual.Items.Count; Índice++) if (Menú_Contextual.Items[Índice].GetType() == typeof(ToolStripMenuItem) && Menú_Contextual.Items[Índice].Name.StartsWith("Menú_Contextual_Ordenar_")) ((ToolStripMenuItem)Menú_Contextual.Items[Índice]).Checked = false;
            ToolStripMenuItem Menú = (ToolStripMenuItem)sender;
            Menú.Checked = true;
            Ordenar = int.Parse(Menú.Name.Replace("Menú_Contextual_Ordenar_", null));
            Ocupado = false;
            Cargar_Errores();
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct Excepciones
        {
            internal uint CRC32;
            internal DateTime Primera_Fecha;
            internal DateTime Última_Fecha;
            internal long Repeticiones;
            internal int Longitud;
            internal string Mensaje;

            internal Excepciones(uint CRC32, DateTime Fecha_Inicial, DateTime Fecha_Final, long Repeticiones, int Longitud, string Mensaje)
            {
                this.CRC32 = CRC32;
                this.Primera_Fecha = Fecha_Inicial;
                this.Última_Fecha = Fecha_Final;
                this.Repeticiones = Repeticiones;
                this.Longitud = Longitud;
                this.Mensaje = Mensaje;
            }
        }

        internal class Comparador_Excepciones : IComparer<Excepciones>
        {
            public int Compare(Excepciones Excepción_1, Excepciones Excepción_2)
            {
                if (Ordenar == 0) // CRC32
                {
                    if (Excepción_1.CRC32 < Excepción_2.CRC32) return -1;
                    else if (Excepción_1.CRC32 > Excepción_2.CRC32) return 1;
                    else return 0;
                }
                else if (Ordenar == 1) // First date.
                {
                    return DateTime.Compare(Excepción_1.Primera_Fecha, Excepción_2.Primera_Fecha);
                }
                else if (Ordenar == 2) // Last date.
                {
                    return DateTime.Compare(Excepción_1.Última_Fecha, Excepción_2.Última_Fecha);
                }
                else if (Ordenar == 3) // Times it has happened.
                {
                    if (Excepción_1.Repeticiones < Excepción_2.Repeticiones) return -1;
                    else if (Excepción_1.Repeticiones > Excepción_2.Repeticiones) return 1;
                    else return 0;
                }
                else if (Ordenar == 4) // Message.
                {
                    return string.Compare(Excepción_1.Mensaje, Excepción_2.Mensaje);
                }
                return 0;
            }
        }

        /// <summary>
        /// Loads in the memory all the possible exceptions stored in the "Debugger" file.
        /// </summary>
        internal void Cargar_Errores()
        {
            try
            {
                if (!Ocupado)
                {
                    long Depurador_Errores = 0L, Depurador_Errores_Únicos = 0L;
                    string Texto = null;
                    Lector_Depurador = new FileStream(Application.StartupPath + "\\Debugger", FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                    Lector_Depurador.Seek(8L, SeekOrigin.Begin);
                    Lector_Depurador_Binario = new BinaryReader(Lector_Depurador, Encoding.ASCII);
                    if (Lector_Depurador != null && Lector_Depurador_Binario != null && Lector_Depurador.Length > 0L && Lector_Depurador.Position < Lector_Depurador.Length)
                    {
                        List<Excepciones> Lista_Excepciones = new List<Excepciones>();
                        for (long Índice = 8L; Índice < Lector_Depurador.Length;)
                        {
                            uint CRC32 = 0;
                            DateTime Primera_Fecha = DateTime.MinValue;
                            DateTime Última_Fecha = DateTime.MinValue;
                            long Repeticiones = 0L;
                            int Longitud = 0;
                            string Mensaje = null;
                            try { CRC32 = Lector_Depurador_Binario.ReadUInt32(); }
                            catch { CRC32 = 0; }
                            try { Primera_Fecha = DateTime.FromBinary(Lector_Depurador_Binario.ReadInt64()); }
                            catch { Primera_Fecha = DateTime.MinValue; }
                            try { Última_Fecha = DateTime.FromBinary(Lector_Depurador_Binario.ReadInt64()); }
                            catch { Última_Fecha = DateTime.MinValue; }
                            try { Repeticiones = Lector_Depurador_Binario.ReadInt64(); }
                            catch { Repeticiones = 0L; }
                            try { Longitud = Lector_Depurador_Binario.ReadInt32(); }
                            catch { Longitud = 0; }
                            try { Mensaje = Encoding.Unicode.GetString(Lector_Depurador_Binario.ReadBytes(Longitud)); }
                            catch { Mensaje = "Unknown error."; }
                            Depurador_Errores += Repeticiones;
                            Depurador_Errores_Únicos++;
                            Lista_Excepciones.Add(new Excepciones(CRC32, Primera_Fecha, Última_Fecha, Repeticiones, Longitud, Mensaje));
                            Índice += 32 + Longitud;
                        }
                        if (Lista_Excepciones.Count > 0)
                        {
                            Lista_Excepciones.Sort(new Comparador_Excepciones());
                            if (Invertir_Orden) Lista_Excepciones.Reverse();
                            for (int Índice = 0; Índice < Lista_Excepciones.Count; Índice++)
                            {
                                Texto += "[" + (Índice + 1).ToString() + "] [x" + Jupisoft.Traducir_Número(Lista_Excepciones[Índice].Repeticiones) + /*"] [CRC-32: " + Program.Traducir_Número(Lista_Excepciones[Índice].CRC32) + */"] [" + Jupisoft.Traducir_Fecha_Hora(Lista_Excepciones[Índice].Primera_Fecha) + "] [" + Jupisoft.Traducir_Fecha_Hora(Lista_Excepciones[Índice].Última_Fecha) + "] " + Lista_Excepciones[Índice].Mensaje + "\r\n\r\n";
                            }
                        }
                    }
                    this.Text = "Debugger by Jupisoft - [Errors: " + Jupisoft.Traducir_Número(Depurador_Errores) + ", Unique Errors: " + Jupisoft.Traducir_Número(Depurador_Errores_Únicos) + "]";
                    if (!string.IsNullOrEmpty(Texto)) Texto = "[Dear " + Jupisoft.Texto_Usuario + " if you want to help with the debugging of these exceptions, please send the \"Debugger\" file to: Jupitermauro@gmail.com]\r\n\r\n" + Texto.TrimEnd("\r\n\r\n".ToCharArray());
                    Editor_RTF.Text = Texto;
                }
            }
            catch (Exception Excepción) { Debugger.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }
    }
}
