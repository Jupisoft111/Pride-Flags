using Pride_Flags.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Pride_Flags.Flags;
using static Pride_Flags.Form_Main;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Pride_Flags
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        /*internal enum Mezclas : int
        {
            Porcentaje_50,
            Diagonal_Abajo_Izquierda_Arriba_Derecha,
            Diagonal_Arriba_Izquierda_Abajo_Derecha,
            Mitad_Horizontal,
            Mitad_Vertical,
        }*/

        internal readonly string Texto_Título = Jupisoft.Texto_Título_Versión + " for " + Jupisoft.Texto_Usuario;
        internal int Variable_Excepciones = 0;
        internal bool Variable_Memoria = false;
        internal static Stopwatch FPS_Cronómetro = Stopwatch.StartNew();
        internal long FPS_Segundo_Anterior = 0L;
        internal long FPS_Temporal = 0L;
        internal long FPS_Real = 0L;
        /// <summary>
        /// Variable that if it's true will always show the main window on top of others.
        /// </summary>
        internal bool Variable_Siempre_Visible = false;
        /// <summary>
        /// Variable that if it's true will always show all the windows and menus with negative colors.
        /// </summary>
        internal static bool Variable_Modo_Oscuro = false;
        internal static readonly string Ruta_Guardado_Global = Application.StartupPath + "\\Saves";
        internal static Dictionary<int, string> Diccionario_Colores_Conocidos = new Dictionary<int, string>();
        internal static readonly Dictionary<string, int> Diccionario_Colores_Sistema = new Dictionary<string, int>
        {
            { "ActiveBorder", SystemColors.ActiveBorder.ToArgb() },
            { "ActiveCaption", SystemColors.ActiveCaption.ToArgb() },
            { "ActiveCaptionText", SystemColors.ActiveCaptionText.ToArgb() },
            { "AppWorkspace", SystemColors.AppWorkspace.ToArgb() },
            { "ButtonFace", SystemColors.ButtonFace.ToArgb() },
            { "ButtonHighlight", SystemColors.ButtonHighlight.ToArgb() },
            { "ButtonShadow", SystemColors.ButtonShadow.ToArgb() },
            { "Control", SystemColors.Control.ToArgb() },
            { "ControlDark", SystemColors.ControlDark.ToArgb() },
            { "ControlDarkDark", SystemColors.ControlDarkDark.ToArgb() },
            { "ControlLight", SystemColors.ControlLight.ToArgb() },
            { "ControlLightLight", SystemColors.ControlLightLight.ToArgb() },
            { "ControlText", SystemColors.ControlText.ToArgb() },
            { "Desktop", SystemColors.Desktop.ToArgb() },
            { "GradientActiveCaption", SystemColors.GradientActiveCaption.ToArgb() },
            { "GradientInactiveCaption", SystemColors.GradientInactiveCaption.ToArgb() },
            { "GrayText", SystemColors.GrayText.ToArgb() },
            { "Highlight", SystemColors.Highlight.ToArgb() },
            { "HighlightText", SystemColors.HighlightText.ToArgb() },
            { "HotTrack", SystemColors.HotTrack.ToArgb() },
            { "InactiveBorder", SystemColors.InactiveBorder.ToArgb() },
            { "InactiveCaption", SystemColors.InactiveCaption.ToArgb() },
            { "InactiveCaptionText", SystemColors.InactiveCaptionText.ToArgb() },
            { "Info", SystemColors.Info.ToArgb() },
            { "InfoText", SystemColors.InfoText.ToArgb() },
            { "Menu", SystemColors.Menu.ToArgb() },
            { "MenuBar", SystemColors.MenuBar.ToArgb() },
            { "MenuHighlight", SystemColors.MenuHighlight.ToArgb() },
            { "MenuText", SystemColors.MenuText.ToArgb() },
            { "ScrollBar", SystemColors.ScrollBar.ToArgb() },
            { "Window", SystemColors.Window.ToArgb() },
            { "WindowFrame", SystemColors.WindowFrame.ToArgb() },
            { "WindowText", SystemColors.WindowText.ToArgb() },
            { "Aqua", Color.Aqua.ToArgb() }, // Cyan.
            { "Magenta", Color.Magenta.ToArgb() }, // Fuchsia.
        };
        internal ImageList Lista_Imágenes_25_15 = null;
        internal ImageList Lista_Imágenes_50_30 = null;
        internal ImageList Lista_Imágenes_100_60 = null;
        internal ImageList Lista_Imágenes_200_120 = null;
        internal string Texto_Hexadecimal_Portapapeles = null;

        private void Form_Main_Load(object sender, EventArgs e)
        {
            try
            {
                if (Jupisoft.Icono_Jupisoft == null)
                {
                    Jupisoft.Icono_Jupisoft = this.Icon.Clone() as Icon;
                }
                //this.Icon = Jupisoft.Icono_Jupisoft.Clone() as Icon;
                this.Text = Texto_Título + " - [Known LGBTQIA+ flags: " + Jupisoft.Traducir_Número(Flags.Diccionario.Count) + ", Selected flags: 0]";
                Barra_Estado_Etiqueta_Color.Image = Jupisoft.Obtener_Imagen_Color(Color.Transparent, true, true);
                Barra_Estado_Etiqueta_Usuario.Text = "Welcome dear " + Jupisoft.Texto_Usuario;
                Menú_Contextual_Acerca.Text = "About " + Jupisoft.Texto_Título + " " + Jupisoft.Texto_Versión + "...";
                this.TopMost = Variable_Siempre_Visible;
                int Índice = 0;
                string[] Matriz_Nombres = Enum.GetNames(typeof(KnownColor));
                if (Matriz_Nombres != null && Matriz_Nombres.Length > 0)
                {
                    //if (Matriz_Nombres.Length > 1) Array.Sort(Matriz_Nombres);
                    foreach (string Nombre in Matriz_Nombres)
                    {
                        try
                        {
                            if (!Diccionario_Colores_Sistema.ContainsKey(Nombre))
                            {
                                if (!Diccionario_Colores_Conocidos.ContainsKey(Color.FromName(Nombre).ToArgb()))
                                {
                                    List<char> Lista_Caracteres = new List<char>();
                                    for (Índice = 0; Índice < Nombre.Length; Índice++)
                                    {
                                        try
                                        {
                                            if (Índice <= 0 || !char.IsUpper(Nombre[Índice]))
                                            {
                                                Lista_Caracteres.Add(Nombre[Índice]);
                                            }
                                            else
                                            {
                                                Lista_Caracteres.Add(' ');
                                                Lista_Caracteres.Add(char.ToLowerInvariant(Nombre[Índice]));
                                            }
                                        }
                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                    }
                                    Diccionario_Colores_Conocidos.Add(Color.FromName(Nombre).ToArgb(), new string(Lista_Caracteres.ToArray()).Trim());
                                    Lista_Caracteres = null;
                                }
                                //else MessageBox.Show(Nombre, Diccionario_Colores_Conocidos[Color.FromName(Nombre).ToArgb()] + ".");
                            }
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                }
                /*Matriz_Nombres = Enum.GetNames(typeof(SystemColors));
                if (Matriz_Nombres != null && Matriz_Nombres.Length > 0)
                {
                    if (Matriz_Nombres.Length > 1) Array.Sort(Matriz_Nombres);
                    foreach (string Nombre in Matriz_Nombres)
                    {
                        try
                        {
                            Diccionario_Colores_Sistema.Add(Color.FromName(Nombre).GetHashCode(), Nombre);
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                }*/
                Matriz_Nombres = null;
                //PictureBox_Bandera.BackColor = Color.Black;
                TextBox_Descripción.Font = new Font(TextBox_Descripción.Font.FontFamily, /*TextBox_Descripción.Font.Size + 3.0f*/12.0f);
                ComboBox_Ondas.SelectedIndex = 0; // 2.
                Índice = 1;
                foreach (KeyValuePair<Flags.Diseños, Flags.Banderas> Entrada in Flags.Diccionario)
                {
                    try
                    {
                        ComboBox_Bandera.Items.Add(/*Entrada.Key.ToString() + " = " + /*Jupisoft.Traducir_Número(Índice) + "/" + Jupisoft.Traducir_Número(Flags.Diccionario.Count) + " " + */Entrada.Value.Nombre + " [" + Jupisoft.Traducir_Número(Índice) + " of " + Jupisoft.Traducir_Número(Flags.Diccionario.Count) + "]");
                    }
                    catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    finally { Índice++; }
                }
                if (ComboBox_Bandera.Items.Count > 0) ComboBox_Bandera.SelectedIndex = 0;
                /*string[] Matriz_Nombres = Enum.GetNames(typeof(Diseños));
                if (Matriz_Nombres != null &&
                    Matriz_Nombres.Length > 0)
                {
                    //if (Matriz_Nombres.Length > 1) Array.Sort(Matriz_Nombres);
                    for (int Índice = 0; Índice < Matriz_Nombres.Length; Índice++)
                    {
                        try
                        {
                            Matriz_Nombres[Índice] = Matriz_Nombres[Índice].Replace("___", " (").Replace("__", ")").Replace("_", " ");
                        }
                        catch (Exception Excepción) { Debugger.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                    ComboBox_Bandera.Items.AddRange(Matriz_Nombres);
                    if (ComboBox_Bandera.Items.Count > 0) ComboBox_Bandera.SelectedIndex = 0;
                }
                Matriz_Nombres = null;*/
                ComboBox_Exportar.SelectedIndex = 2;
                NumericUpDown_Ancho.Value = Screen.PrimaryScreen.Bounds.Width;
                NumericUpDown_Alto.Value = Screen.PrimaryScreen.Bounds.Height;

                ListView_Banderas.BeginUpdate();
                ListView_Banderas.Columns[0].Width = ListView_Banderas.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
                int Banderas_Seleccionadas = 0;
                int Índice_Imagen = 0;
                foreach (KeyValuePair<Flags.Diseños, Flags.Banderas> Entrada in Flags.Diccionario)
                {
                    try
                    {
                        ListViewItem Item = new ListViewItem(Entrada.Value.Nombre, Índice_Imagen, ListView_Banderas.Groups[0]);
                        if (Entrada.Key == Diseños.Abrosexual ||
                            Entrada.Key == Diseños.Aceflux ||
                            Entrada.Key == Diseños.Agender___2014__ ||
                            Entrada.Key == Diseños.Ambiamorous ||
                            Entrada.Key == Diseños.Androgyne ||
                            Entrada.Key == Diseños.Aroace ||
                            Entrada.Key == Diseños.Aroflux ||
                            Entrada.Key == Diseños.Aromantic___2014__ ||
                            Entrada.Key == Diseños.Asexual___2010__ ||
                            Entrada.Key == Diseños.Bigender ||
                            Entrada.Key == Diseños.Bisexual___1998__ ||
                            Entrada.Key == Diseños.Demifluid ||
                            Entrada.Key == Diseños.Demigender ||
                            Entrada.Key == Diseños.Demigirl ||
                            Entrada.Key == Diseños.Demiromantic ||
                            Entrada.Key == Diseños.Demisexual ||
                            Entrada.Key == Diseños.Gay___1979__ ||
                            Entrada.Key == Diseños.Men_loving_men___Mlm__ ||
                            Entrada.Key == Diseños.Vincian ||
                            Entrada.Key == Diseños.Genderfluid___2012__ ||
                            Entrada.Key == Diseños.Genderflux ||
                            Entrada.Key == Diseños.Genderqueer___2011__ ||
                            Entrada.Key == Diseños.Questioning ||
                            Entrada.Key == Diseños.Greysexual ||
                            Entrada.Key == Diseños.Intersex___2013__ ||
                            Entrada.Key == Diseños.Lesbian___2019__ ||
                            Entrada.Key == Diseños.Maverique ||
                            Entrada.Key == Diseños.Neutrois ||
                            Entrada.Key == Diseños.Nonbinary___2014__ ||
                            Entrada.Key == Diseños.Omnisexual ||
                            Entrada.Key == Diseños.Pangender ||
                            Entrada.Key == Diseños.Pansexual___2010__ ||
                            Entrada.Key == Diseños.Polyamory ||
                            Entrada.Key == Diseños.Polysexual___2012__ ||
                            Entrada.Key == Diseños.Transgender___1999__ ||
                            Entrada.Key == Diseños.Trigender ||
                            //Entrada.Key == Diseños.Two_Spirit ||
                            //Entrada.Key == Diseños.Progress ||
                            Entrada.Key == Diseños.Queer ||
                            Entrada.Key == Diseños.Unlabeled)
                        {
                            Item.Checked = true;
                            Banderas_Seleccionadas++;
                        }
                        //else Item.Checked = false;
                        /*if (Entrada.Value.Radial)
                        {
                            Item.Checked = true;
                            Banderas_Seleccionadas++;
                        }*/
                        ListView_Banderas.Items.Add(Item);
                    }
                    catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    finally { Índice_Imagen++; }
                }
                ListView_Banderas.EndUpdate();
                this.Text = Texto_Título + " - [Known LGBTQIA+ flags: " + Jupisoft.Traducir_Número(Flags.Diccionario.Count) + ", Selected flags: " + Jupisoft.Traducir_Número(Banderas_Seleccionadas) + "]";
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Form_Main_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
                Temporizador_Principal_Tick(Temporizador_Principal, EventArgs.Empty);
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Form_Main_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
                ListView_Banderas.Columns[0].Width = ListView_Banderas.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
                Actualizar_Bandera();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Form_Main_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!e.Alt && !e.Control && !e.Shift)
                {
                    if (e.KeyCode == Keys.Escape/* || e.KeyCode == Keys.Delete*/)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void ComboBox_Bandera_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox_Bandera.Refresh();
                Actualizar_Bandera();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void ComboBox_Bandera_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    if (!string.IsNullOrEmpty(ComboBox_Bandera.Text))
                    {
                        Clipboard.SetText(ComboBox_Bandera.Text);
                        SystemSounds.Asterisk.Play();
                    }
                }
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void CheckBox_Rayas_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox_Rayas.Refresh();
                Actualizar_Bandera();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void CheckBox_Figuras_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox_Figuras.Refresh();
                Actualizar_Bandera();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void CheckBox_Iconos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox_Iconos.Refresh();
                Actualizar_Bandera();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void CheckBox_Suavizado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox_Suavizado.Refresh();
                Actualizar_Bandera();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void CheckBox_Rotar_90_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox_Rotar_90.Refresh();
                Actualizar_Bandera();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void CheckBox_Radial_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox_Radial.Refresh();
                Actualizar_Bandera();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void ComboBox_Ondas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox_Ondas.Refresh();
                Actualizar_Bandera();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void NumericUpDown_Cantidad_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown_Cantidad.Refresh();
                Actualizar_Bandera();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void NumericUpDown_Amplitud_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown_Amplitud.Refresh();
                Actualizar_Bandera();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void NumericUpDown_Fase_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown_Fase.Refresh();
                Actualizar_Bandera();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void CheckBox_Invertir_Ondas_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox_Invertir_Ondas.Refresh();
                Actualizar_Bandera();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void ComboBox_Exportar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox_Exportar.Refresh();
                /*if (ComboBox_Exportar.SelectedIndex > -1)
                {
                    CheckBox_Suavizado.Checked = ComboBox_Exportar.SelectedIndex < 2;
                }*/
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void NumericUpDown_Ancho_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown_Ancho.Refresh();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void NumericUpDown_Alto_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown_Alto.Refresh();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Button_Mostrar_Descripción_Lista_Click(object sender, EventArgs e)
        {
            try
            {
                Menú_Contextual_Mostrar_Descripción_Lista.PerformClick();
                /*this.Cursor = Cursors.WaitCursor;
                // Don't draw all the flag thumbnails until they're going to be displayed in the list.
                if (Lista_Imágenes_25_15 == null)
                {
                    Lista_Imágenes_25_15 = new ImageList();
                    Lista_Imágenes_25_15.ColorDepth = ColorDepth.Depth32Bit;
                    Lista_Imágenes_25_15.ImageSize = new Size(25, 15);
                    Lista_Imágenes_25_15.TransparentColor = Color.Empty;

                    Lista_Imágenes_50_30 = new ImageList();
                    Lista_Imágenes_50_30.ColorDepth = ColorDepth.Depth32Bit;
                    Lista_Imágenes_50_30.ImageSize = new Size(50, 30);
                    Lista_Imágenes_50_30.TransparentColor = Color.Empty;

                    Lista_Imágenes_100_60 = new ImageList();
                    Lista_Imágenes_100_60.ColorDepth = ColorDepth.Depth32Bit;
                    Lista_Imágenes_100_60.ImageSize = new Size(100, 60);
                    Lista_Imágenes_100_60.TransparentColor = Color.Empty;

                    Lista_Imágenes_200_120 = new ImageList();
                    Lista_Imágenes_200_120.ColorDepth = ColorDepth.Depth32Bit;
                    Lista_Imágenes_200_120.ImageSize = new Size(200, 120);
                    Lista_Imágenes_200_120.TransparentColor = Color.Empty;

                    ListView_Banderas.BeginUpdate();
                    foreach (KeyValuePair<Flags.Diseños, Flags.Banderas> Entrada in Flags.Diccionario)
                    {
                        try
                        {
                            Lista_Imágenes_25_15.Images.Add(Dibujar_Bandera(Entrada.Key, Lista_Imágenes_25_15.ImageSize.Width, Lista_Imágenes_25_15.ImageSize.Height, true, true, true, false, false, Ondas.Ninguna, 0m, 0m, 0m, false, CheckState.Unchecked, false));
                            Lista_Imágenes_50_30.Images.Add(Dibujar_Bandera(Entrada.Key, Lista_Imágenes_50_30.ImageSize.Width, Lista_Imágenes_50_30.ImageSize.Height, true, true, true, false, false, Ondas.Ninguna, 0m, 0m, 0m, false, CheckState.Unchecked, false));
                            Lista_Imágenes_100_60.Images.Add(Dibujar_Bandera(Entrada.Key, Lista_Imágenes_100_60.ImageSize.Width, Lista_Imágenes_100_60.ImageSize.Height, true, true, true, false, false, Ondas.Ninguna, 0m, 0m, 0m, false, CheckState.Unchecked, false));
                            Lista_Imágenes_200_120.Images.Add(Dibujar_Bandera(Entrada.Key, Lista_Imágenes_200_120.ImageSize.Width, Lista_Imágenes_200_120.ImageSize.Height, true, true, true, false, false, Ondas.Ninguna, 0m, 0m, 0m, false, CheckState.Unchecked, false));
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                    if (Menú_Contextual_Dimensiones_Lista_25_15.Checked)
                    {
                        ListView_Banderas.SmallImageList = Lista_Imágenes_25_15;
                        ListView_Banderas.LargeImageList = Lista_Imágenes_25_15;
                    }
                    else if (Menú_Contextual_Dimensiones_Lista_50_30.Checked)
                    {
                        ListView_Banderas.SmallImageList = Lista_Imágenes_50_30;
                        ListView_Banderas.LargeImageList = Lista_Imágenes_50_30;
                    }
                    else if (Menú_Contextual_Dimensiones_Lista_100_60.Checked)
                    {
                        ListView_Banderas.SmallImageList = Lista_Imágenes_100_60;
                        ListView_Banderas.LargeImageList = Lista_Imágenes_100_60;
                    }
                    else
                    {
                        ListView_Banderas.SmallImageList = Lista_Imágenes_200_120;
                        ListView_Banderas.LargeImageList = Lista_Imágenes_200_120;
                    }
                    ListView_Banderas.EndUpdate();
                }
                if (!ListView_Banderas.Visible)
                {
                    TextBox_Descripción.Visible = false;
                    TextBox_Descripción.Enabled = false;
                    GroupBox_Descripción_Lista.Text = "Flag selection list";
                    ListView_Banderas.Enabled = true;
                    ListView_Banderas.Visible = true;
                    Button_Mostrar_Descripción_Lista.Image = Resources.Controles_TextBox;
                    Button_Mostrar_Descripción_Lista.Text = " Show the description instead of the flag list ";
                }
                else
                {
                    ListView_Banderas.Visible = false;
                    ListView_Banderas.Enabled = false;
                    GroupBox_Descripción_Lista.Text = "Flag description";
                    TextBox_Descripción.Enabled = true;
                    TextBox_Descripción.Visible = true;
                    Button_Mostrar_Descripción_Lista.Image = Resources.Checked;
                    Button_Mostrar_Descripción_Lista.Text = " Show the flag list instead of the description ";
                }*/
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Button_Exportar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (ComboBox_Bandera.SelectedIndex > -1)
                {
                    Flags.Diseños Diseño = (Flags.Diseños)ComboBox_Bandera.SelectedIndex;
                    int Ancho = (int)NumericUpDown_Ancho.Value;
                    int Alto = (int)NumericUpDown_Alto.Value;
                    if (Ancho > 0 && Alto > 0)
                    {
                        if (ComboBox_Exportar.SelectedIndex == 2) // Make sure the aspect ratio is 5:3.
                        {
                            int Ancho_Proporcional = (Alto * 5) / 3;
                            int Alto_Proporcional = (Ancho * 3) / 5;
                            // Always pick the higher resolution.
                            if (Ancho * Alto_Proporcional > Ancho_Proporcional * Alto)
                            {
                                Alto = Alto_Proporcional;
                            }
                            else if (Ancho * Alto_Proporcional > Ancho_Proporcional * Alto)
                            {
                                Ancho = Ancho_Proporcional;
                            }
                        }
                        Bitmap Imagen = Dibujar_Bandera(Diseño, Ancho, Alto, CheckBox_Rayas.Checked, CheckBox_Figuras.Checked, CheckBox_Iconos.Checked, ComboBox_Exportar.SelectedIndex == 2 ? CheckBox_Suavizado.Checked : true, CheckBox_Rotar_90.Checked, (Flags.Ondas)ComboBox_Ondas.SelectedIndex, NumericUpDown_Cantidad.Value, NumericUpDown_Amplitud.Value, NumericUpDown_Fase.Value, CheckBox_Invertir_Ondas.Checked, CheckBox_Radial.CheckState, ComboBox_Exportar.SelectedIndex < 2);
                        if (Imagen != null)
                        {
                            int Índice_Bandera = 0;
                            int Total_Banderas = 0;
                            foreach (KeyValuePair<Flags.Diseños, Flags.Banderas> Entrada in Flags.Diccionario)
                            {
                                try
                                {
                                    if (ListView_Banderas.Items[Índice_Bandera].Checked) Total_Banderas++;
                                }
                                catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                finally { Índice_Bandera++; }
                            }
                            Jupisoft.Crear_Carpetas(Ruta_Guardado_Global);
                            Imagen.Save(Ruta_Guardado_Global + "\\" + Jupisoft.Obtener_Nombre_Temporal() + " " + (ComboBox_Exportar.SelectedIndex < 2 ? Jupisoft.Traducir_Número(Total_Banderas) + " Pride " + (Total_Banderas != 1 ? "Flags" : "Flag") : ComboBox_Bandera.Text) + ".png", ImageFormat.Png);
                            Jupisoft.Ejecutar_Ruta(Ruta_Guardado_Global, ProcessWindowStyle.Maximized);
                            Imagen.Dispose();
                            Imagen = null;
                        }
                        else SystemSounds.Beep.Play();
                    }
                    /*if (ComboBox_Exportar.SelectedIndex == 0)
                    {
                        // In this case just ignore the 5:3 aspect ratio.
                        int Ancho = (int)NumericUpDown_Ancho.Value;
                        int Alto = (int)NumericUpDown_Alto.Value;
                        if (Ancho > 0 && Alto > 0)
                        {
                            Bitmap Imagen = Dibujar_Bandera(Diseño, Ancho, Alto, CheckBox_Rayas.Checked, CheckBox_Figuras.Checked, CheckBox_Iconos.Checked, CheckBox_Suavizado.Checked, CheckBox_Rotar_90.Checked, (Flags.Ondas)ComboBox_Ondas.SelectedIndex, NumericUpDown_Cantidad.Value, NumericUpDown_Amplitud.Value, NumericUpDown_Fase.Value, CheckBox_Invertir_Ondas.Checked, CheckState.Indeterminate, ComboBox_Exportar.SelectedIndex == 0);
                            if (Imagen != null)
                            {
                                Jupisoft.Crear_Carpetas(Ruta_Guardado_Global);
                                Imagen.Save(Ruta_Guardado_Global + "\\" + Jupisoft.Obtener_Nombre_Temporal() + " " + ComboBox_Bandera.Text + ".png", ImageFormat.Png);
                                Jupisoft.Ejecutar_Ruta(Ruta_Guardado_Global, ProcessWindowStyle.Maximized);
                            }
                            Imagen.Dispose();
                            Imagen = null;
                        }
                    }
                    else if (ComboBox_Exportar.SelectedIndex == 1)
                    {
                        int Ancho = (int)NumericUpDown_Ancho.Value;
                        int Alto = (int)NumericUpDown_Alto.Value;
                        if (Ancho > 0 && Alto > 0)
                        {
                            // Make sure the aspect ratio is 5:3.
                            int Ancho_Proporcional = (Alto * 5) / 3;
                            int Alto_Proporcional = (Ancho * 3) / 5;
                            // Always pick the higher resolution.
                            if (Ancho * Alto_Proporcional > Ancho_Proporcional * Alto)
                            {
                                Alto = Alto_Proporcional;
                            }
                            else if (Ancho * Alto_Proporcional > Ancho_Proporcional * Alto)
                            {
                                Ancho = Ancho_Proporcional;
                            }
                            Bitmap Imagen = Dibujar_Bandera(Diseño, Ancho, Alto, CheckBox_Rayas.Checked, CheckBox_Figuras.Checked, CheckBox_Iconos.Checked, CheckBox_Suavizado.Checked, CheckBox_Rotar_90.Checked, (Flags.Ondas)ComboBox_Ondas.SelectedIndex, NumericUpDown_Cantidad.Value, NumericUpDown_Amplitud.Value, NumericUpDown_Fase.Value, CheckBox_Invertir_Ondas.Checked, CheckBox_Radial.CheckState != CheckState.Indeterminate ? CheckBox_Radial.CheckState : CheckState.Checked);
                            if (Imagen != null)
                            {
                                Jupisoft.Crear_Carpetas(Ruta_Guardado_Global);
                                Imagen.Save(Ruta_Guardado_Global + "\\" + Jupisoft.Obtener_Nombre_Temporal() + " " + ComboBox_Bandera.Text + ".png", ImageFormat.Png);
                                Jupisoft.Ejecutar_Ruta(Ruta_Guardado_Global, ProcessWindowStyle.Maximized);
                            }
                            Imagen.Dispose();
                            Imagen = null;
                        }
                    }*/
                }
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void PictureBox_Bandera_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    this.Close();
                }
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void PictureBox_Bandera_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Right)
                {
                    if (PictureBox_Bandera.Image != null)
                    {
                        int Ancho_Cliente = PictureBox_Bandera.ClientSize.Width;
                        int Alto_Cliente = PictureBox_Bandera.ClientSize.Height;
                        int Ancho = PictureBox_Bandera.Image.Width;
                        int Alto = PictureBox_Bandera.Image.Height;
                        Rectangle Rectángulo = new Rectangle((Ancho_Cliente - Ancho) / 2, (Alto_Cliente - Alto) / 2, Ancho, Alto);
                        if (Rectángulo.Contains(e.Location))
                        {
                            Color Color_ARGB = ((Bitmap)PictureBox_Bandera.Image).GetPixel(e.X - Rectángulo.X, e.Y - Rectángulo.Y);
                            int Código_Hash = Color_ARGB.ToArgb();
                            string Texto_Nombre = null;
                            if (Diccionario_Colores_Conocidos.ContainsKey(Código_Hash))
                            {
                                Texto_Nombre = Diccionario_Colores_Conocidos[Código_Hash];
                            }
                            /*string[] Matriz_Nombres = Enum.GetNames(typeof(KnownColor));
                            if (Matriz_Nombres != null && Matriz_Nombres.Length > 0)
                            {
                                if (Matriz_Nombres.Length > 1) Array.Sort(Matriz_Nombres);
                                foreach (string Nombre in Matriz_Nombres)
                                {
                                    try
                                    {
                                        Color Color_Conocido = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), Nombre));
                                        if (Color_Conocido.A == Color_ARGB.A &&
                                            Color_Conocido.R == Color_ARGB.R &&
                                            Color_Conocido.G == Color_ARGB.G &&
                                            Color_Conocido.B == Color_ARGB.B)
                                        {
                                            List<char> Lista_Caracteres = new List<char>();
                                            foreach (char Caracter in Nombre)
                                            {
                                                try
                                                {
                                                    if (!char.IsUpper(Caracter))
                                                    {
                                                        Lista_Caracteres.Add(Caracter);
                                                    }
                                                    else
                                                    {
                                                        Lista_Caracteres.Add(' ');
                                                        Lista_Caracteres.Add(Caracter);
                                                    }
                                                }
                                                catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                            }
                                            Texto_Nombre = new string(Lista_Caracteres.ToArray()).Trim();
                                            Lista_Caracteres = null;
                                            break;
                                        }
                                    }
                                    catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                }
                            }
                            Matriz_Nombres = null;*/
                            string Texto_R = Convert.ToString(Color_ARGB.R, 16);
                            string Texto_G = Convert.ToString(Color_ARGB.G, 16);
                            string Texto_B = Convert.ToString(Color_ARGB.B, 16);
                            while (Texto_R.Length < 2) Texto_R = '0' + Texto_R;
                            while (Texto_G.Length < 2) Texto_G = '0' + Texto_G;
                            while (Texto_B.Length < 2) Texto_B = '0' + Texto_B;
                            string Texto_RGB = Texto_R + Texto_G + Texto_B;
                            Texto_Hexadecimal_Portapapeles = Texto_RGB.ToUpperInvariant();
                            Barra_Estado_Etiqueta_Cursor.Text = "Cursor: " + Jupisoft.Traducir_Número(e.X - Rectángulo.X) + ", " + Jupisoft.Traducir_Número(e.Y - Rectángulo.Y);
                            Barra_Estado_Etiqueta_Color.Image = Jupisoft.Obtener_Imagen_Color(Color_ARGB, true, true);
                            Barra_Estado_Etiqueta_Color.Text = "Color: #" + Texto_RGB.ToUpperInvariant() + (!string.IsNullOrEmpty(Texto_Nombre) ? " (" + Texto_Nombre + ")" : null);
                            Texto_R = null;
                            Texto_G = null;
                            Texto_B = null;
                            Texto_RGB = null;
                            Barra_Estado.Refresh();
                        }
                        else
                        {
                            Barra_Estado_Etiqueta_Cursor.Text = "Cursor: ?, ?";
                            Barra_Estado_Etiqueta_Color.Image = Jupisoft.Obtener_Imagen_Color(Color.Transparent, true, true);
                            Barra_Estado_Etiqueta_Color.Text = "Color: #??????";
                            Barra_Estado.Refresh();
                        }
                    }
                    else
                    {
                        Barra_Estado_Etiqueta_Cursor.Text = "Cursor: ?, ?";
                        Barra_Estado_Etiqueta_Color.Image = Jupisoft.Obtener_Imagen_Color(Color.Transparent, true, true);
                        Barra_Estado_Etiqueta_Color.Text = "Color: #??????";
                        Barra_Estado.Refresh();
                    }
                    /*if (e.X > -1 &&
                        e.Y > -1 &&
                        e.X < PictureBox_Bandera.ClientSize.Width &&
                        e.Y < PictureBox_Bandera.ClientSize.Height &&
                        PictureBox_Bandera.Image != null)
                    {
                        int X = e.X;
                        int Y = e.Y;
                        int Ancho = PictureBox_Bandera.Image.Width;
                        int Alto = PictureBox_Bandera.Image.Height;
                        Barra_Estado_Etiqueta_Cursor.Text = "Cursor: " + Jupisoft.Traducir_Número(X) + ", " + Jupisoft.Traducir_Número(Y);
                    }
                    else
                    {
                        Barra_Estado_Etiqueta_Cursor.Text = "Cursor: ?, ?";
                    }*/
                }
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void PictureBox_Bandera_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Barra_Estado_Etiqueta_Cursor.Text = "Cursor: ?, ?";
                Barra_Estado_Etiqueta_Color.Image = Jupisoft.Obtener_Imagen_Color(Color.Transparent, true, true);
                Barra_Estado_Etiqueta_Color.Text = "Color: #??????";
                Barra_Estado.Refresh();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void ListView_Banderas_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (Menú_Contextual_Seleccionar_Lista.Checked)
                {
                    if (ListView_Banderas.SelectedItems != null && ListView_Banderas.SelectedItems.Count > 0)
                    {
                        foreach (ListViewItem Item in ListView_Banderas.SelectedItems)
                        {
                            try
                            {
                                if (Item != null && Item.Focused)
                                {
                                    ComboBox_Bandera.SelectedIndex = Item.Index;
                                    break;
                                }
                            }
                            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                        }
                    }
                }
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void ListView_Banderas_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                if (ListView_Banderas.Items != null && ListView_Banderas.Items.Count > 0)
                {
                    int Banderas_Seleccionadas = 0;
                    foreach (ListViewItem Item in ListView_Banderas.Items)
                    {
                        try
                        {
                            if (Item != null && Item.Checked)
                            {
                                Banderas_Seleccionadas++;
                            }
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                    this.Text = Texto_Título + " - [Known LGBTQIA+ flags: " + Jupisoft.Traducir_Número(Flags.Diccionario.Count) + ", Selected flags: " + Jupisoft.Traducir_Número(Banderas_Seleccionadas) + "]";
                }
                else this.Text = Texto_Título + " - [Known LGBTQIA+ flags: " + Jupisoft.Traducir_Número(Flags.Diccionario.Count) + ", Selected flags: 0]";
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Barra_Estado_Botón_Excepción_Click(object sender, EventArgs e)
        {
            try
            {
                Variable_Excepciones = 0;
                Barra_Estado_Botón_Excepción.Text = "Exceptions: 0";
                Form_Debugger Ventana = new Form_Debugger();
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                Menú_Contextual_Depurador.Text = "Debugger - [" + Jupisoft.Traducir_Número(Variable_Excepciones) + (Variable_Excepciones != 1 ? " exceptions" : " exception") + "]...";
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Donar_Click(object sender, EventArgs e)
        {
            try
            {
                Jupisoft.Ejecutar_Ruta("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=KSMZ3XNG2R9P6", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Visor_Ayuda_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(this, "The help file is not available yet... sorry.\r\n\r\nPlease note that this version is not finished yet, it works perfectly, but hundreds of already existing LGBTQIA+ flags still need to be added, along with lots of descriptions... so keep an eye for an improved future version coming very soon.\r\n\r\nNote: some flags are also unfinished, like missing a shape, icon or not drawing at all on \"all flags radial mode\". This is already a known \"bug\" and very soon will be finished too :-)", Jupisoft.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Acerca_Click(object sender, EventArgs e)
        {
            try
            {
                Form_About Ventana = new Form_About();
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Depurador_Click(object sender, EventArgs e)
        {
            try
            {
                Variable_Excepciones = 0;
                Barra_Estado_Botón_Excepción.Text = "Exceptions: 0";
                Form_Debugger Ventana = new Form_Debugger();
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Abrir_Carpeta_Guardado_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!string.IsNullOrEmpty(Ruta_Guardado_Global))
                {
                    Jupisoft.Crear_Carpetas(Ruta_Guardado_Global);
                    if (Directory.Exists(Ruta_Guardado_Global))
                    {
                        Jupisoft.Ejecutar_Ruta(Ruta_Guardado_Global, ProcessWindowStyle.Maximized);
                    }
                    else SystemSounds.Beep.Play();
                }
                else SystemSounds.Beep.Play();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_Restablecer_Selección_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!ListView_Banderas.Visible) Menú_Contextual_Mostrar_Descripción_Lista.PerformClick();
                ListView_Banderas.BeginUpdate();
                for (int Índice = 0; Índice < ListView_Banderas.Items.Count; Índice++)
                {
                    try
                    {
                        ListView_Banderas.Items[Índice].Checked = Flags.Diccionario[(Flags.Diseños)Índice].Radial;
                    }
                    catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                }
                ListView_Banderas.EndUpdate();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_Banderas_Aleatorias_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!ListView_Banderas.Visible) Menú_Contextual_Mostrar_Descripción_Lista.PerformClick();
                ListView_Banderas.BeginUpdate();
                for (int Índice = 0; Índice < ListView_Banderas.Items.Count; Índice++)
                {
                    try
                    {
                        ListView_Banderas.Items[Índice].Checked = Jupisoft.Rand.Next(0, 2) == 1;
                    }
                    catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                }
                ListView_Banderas.EndUpdate();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_Seleccionar_Nada_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!ListView_Banderas.Visible) Menú_Contextual_Mostrar_Descripción_Lista.PerformClick();
                ListView_Banderas.BeginUpdate();
                for (int Índice = 0; Índice < ListView_Banderas.Items.Count; Índice++)
                {
                    try
                    {
                        ListView_Banderas.Items[Índice].Checked = false;
                    }
                    catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                }
                ListView_Banderas.EndUpdate();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_Seleccionar_Todo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!ListView_Banderas.Visible) Menú_Contextual_Mostrar_Descripción_Lista.PerformClick();
                ListView_Banderas.BeginUpdate();
                for (int Índice = 0; Índice < ListView_Banderas.Items.Count; Índice++)
                {
                    try
                    {
                        ListView_Banderas.Items[Índice].Checked = true;
                    }
                    catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                }
                ListView_Banderas.EndUpdate();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_Dimensiones_Lista_25_15_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Menú_Contextual_Dimensiones_Lista_50_30.Checked = false;
                Menú_Contextual_Dimensiones_Lista_100_60.Checked = false;
                Menú_Contextual_Dimensiones_Lista_200_120.Checked = false;
                Menú_Contextual_Dimensiones_Lista_25_15.Checked = true;
                ListView_Banderas.BeginUpdate();
                if (Menú_Contextual_Mostrar_Descripción_Lista.Checked && Lista_Imágenes_25_15 == null)
                {
                    Lista_Imágenes_25_15 = new ImageList();
                    Lista_Imágenes_25_15.ColorDepth = ColorDepth.Depth32Bit;
                    Lista_Imágenes_25_15.ImageSize = new Size(25, 15);
                    Lista_Imágenes_25_15.TransparentColor = Color.Empty;
                    foreach (KeyValuePair<Flags.Diseños, Flags.Banderas> Entrada in Flags.Diccionario)
                    {
                        try
                        {
                            Lista_Imágenes_25_15.Images.Add(Dibujar_Bandera(Entrada.Key, Lista_Imágenes_25_15.ImageSize.Width, Lista_Imágenes_25_15.ImageSize.Height, true, true, true, false, false, Ondas.Ninguna, 0m, 0m, 0m, false, CheckState.Unchecked, false));
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                }
                ListView_Banderas.SmallImageList = Lista_Imágenes_25_15;
                ListView_Banderas.LargeImageList = Lista_Imágenes_25_15;
                ListView_Banderas.EndUpdate();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_Dimensiones_Lista_50_30_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Menú_Contextual_Dimensiones_Lista_25_15.Checked = false;
                Menú_Contextual_Dimensiones_Lista_100_60.Checked = false;
                Menú_Contextual_Dimensiones_Lista_200_120.Checked = false;
                Menú_Contextual_Dimensiones_Lista_50_30.Checked = true;
                ListView_Banderas.BeginUpdate();
                if (Menú_Contextual_Mostrar_Descripción_Lista.Checked && Lista_Imágenes_50_30 == null)
                {
                    Lista_Imágenes_50_30 = new ImageList();
                    Lista_Imágenes_50_30.ColorDepth = ColorDepth.Depth32Bit;
                    Lista_Imágenes_50_30.ImageSize = new Size(50, 30);
                    Lista_Imágenes_50_30.TransparentColor = Color.Empty;
                    foreach (KeyValuePair<Flags.Diseños, Flags.Banderas> Entrada in Flags.Diccionario)
                    {
                        try
                        {
                            Lista_Imágenes_50_30.Images.Add(Dibujar_Bandera(Entrada.Key, Lista_Imágenes_50_30.ImageSize.Width, Lista_Imágenes_50_30.ImageSize.Height, true, true, true, false, false, Ondas.Ninguna, 0m, 0m, 0m, false, CheckState.Unchecked, false));
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                }
                ListView_Banderas.SmallImageList = Lista_Imágenes_50_30;
                ListView_Banderas.LargeImageList = Lista_Imágenes_50_30;
                ListView_Banderas.EndUpdate();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_Dimensiones_Lista_100_60_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Menú_Contextual_Dimensiones_Lista_25_15.Checked = false;
                Menú_Contextual_Dimensiones_Lista_50_30.Checked = false;
                Menú_Contextual_Dimensiones_Lista_200_120.Checked = false;
                Menú_Contextual_Dimensiones_Lista_100_60.Checked = true;
                ListView_Banderas.BeginUpdate();
                if (Menú_Contextual_Mostrar_Descripción_Lista.Checked && Lista_Imágenes_100_60 == null)
                {
                    Lista_Imágenes_100_60 = new ImageList();
                    Lista_Imágenes_100_60.ColorDepth = ColorDepth.Depth32Bit;
                    Lista_Imágenes_100_60.ImageSize = new Size(100, 60);
                    Lista_Imágenes_100_60.TransparentColor = Color.Empty;
                    foreach (KeyValuePair<Flags.Diseños, Flags.Banderas> Entrada in Flags.Diccionario)
                    {
                        try
                        {
                            Lista_Imágenes_100_60.Images.Add(Dibujar_Bandera(Entrada.Key, Lista_Imágenes_100_60.ImageSize.Width, Lista_Imágenes_100_60.ImageSize.Height, true, true, true, false, false, Ondas.Ninguna, 0m, 0m, 0m, false, CheckState.Unchecked, false));
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                }
                ListView_Banderas.SmallImageList = Lista_Imágenes_100_60;
                ListView_Banderas.LargeImageList = Lista_Imágenes_100_60;
                ListView_Banderas.EndUpdate();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_Dimensiones_Lista_200_120_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Menú_Contextual_Dimensiones_Lista_25_15.Checked = false;
                Menú_Contextual_Dimensiones_Lista_50_30.Checked = false;
                Menú_Contextual_Dimensiones_Lista_100_60.Checked = false;
                Menú_Contextual_Dimensiones_Lista_200_120.Checked = true;
                ListView_Banderas.BeginUpdate();
                if (Menú_Contextual_Mostrar_Descripción_Lista.Checked && Lista_Imágenes_200_120 == null)
                {
                    Lista_Imágenes_200_120 = new ImageList();
                    Lista_Imágenes_200_120.ColorDepth = ColorDepth.Depth32Bit;
                    Lista_Imágenes_200_120.ImageSize = new Size(200, 120);
                    Lista_Imágenes_200_120.TransparentColor = Color.Empty;
                    foreach (KeyValuePair<Flags.Diseños, Flags.Banderas> Entrada in Flags.Diccionario)
                    {
                        try
                        {
                            Lista_Imágenes_200_120.Images.Add(Dibujar_Bandera(Entrada.Key, Lista_Imágenes_200_120.ImageSize.Width, Lista_Imágenes_200_120.ImageSize.Height, true, true, true, false, false, Ondas.Ninguna, 0m, 0m, 0m, false, CheckState.Unchecked, false));
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                }
                ListView_Banderas.SmallImageList = Lista_Imágenes_200_120;
                ListView_Banderas.LargeImageList = Lista_Imágenes_200_120;
                ListView_Banderas.EndUpdate();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_Mostrar_Descripción_Lista_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // Don't draw all the flag thumbnails until they're going to be displayed in the list.
                ListView_Banderas.BeginUpdate();
                if (Menú_Contextual_Dimensiones_Lista_25_15.Checked)
                {
                    if (Lista_Imágenes_25_15 == null)
                    {
                        Lista_Imágenes_25_15 = new ImageList();
                        Lista_Imágenes_25_15.ColorDepth = ColorDepth.Depth32Bit;
                        Lista_Imágenes_25_15.ImageSize = new Size(25, 15);
                        Lista_Imágenes_25_15.TransparentColor = Color.Empty;
                        foreach (KeyValuePair<Flags.Diseños, Flags.Banderas> Entrada in Flags.Diccionario)
                        {
                            try
                            {
                                Lista_Imágenes_25_15.Images.Add(Dibujar_Bandera(Entrada.Key, Lista_Imágenes_25_15.ImageSize.Width, Lista_Imágenes_25_15.ImageSize.Height, true, true, true, false, false, Ondas.Ninguna, 0m, 0m, 0m, false, CheckState.Unchecked, false));
                            }
                            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                        }
                    }
                    ListView_Banderas.SmallImageList = Lista_Imágenes_25_15;
                    ListView_Banderas.LargeImageList = Lista_Imágenes_25_15;
                }
                else if (Menú_Contextual_Dimensiones_Lista_50_30.Checked)
                {
                    if (Lista_Imágenes_50_30 == null)
                    {
                        Lista_Imágenes_50_30 = new ImageList();
                        Lista_Imágenes_50_30.ColorDepth = ColorDepth.Depth32Bit;
                        Lista_Imágenes_50_30.ImageSize = new Size(50, 30);
                        Lista_Imágenes_50_30.TransparentColor = Color.Empty;
                        foreach (KeyValuePair<Flags.Diseños, Flags.Banderas> Entrada in Flags.Diccionario)
                        {
                            try
                            {
                                Lista_Imágenes_50_30.Images.Add(Dibujar_Bandera(Entrada.Key, Lista_Imágenes_50_30.ImageSize.Width, Lista_Imágenes_50_30.ImageSize.Height, true, true, true, false, false, Ondas.Ninguna, 0m, 0m, 0m, false, CheckState.Unchecked, false));
                            }
                            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                        }
                    }
                    ListView_Banderas.SmallImageList = Lista_Imágenes_50_30;
                    ListView_Banderas.LargeImageList = Lista_Imágenes_50_30;
                }
                else if (Menú_Contextual_Dimensiones_Lista_100_60.Checked)
                {
                    if (Lista_Imágenes_100_60 == null)
                    {
                        Lista_Imágenes_100_60 = new ImageList();
                        Lista_Imágenes_100_60.ColorDepth = ColorDepth.Depth32Bit;
                        Lista_Imágenes_100_60.ImageSize = new Size(100, 60);
                        Lista_Imágenes_100_60.TransparentColor = Color.Empty;
                        foreach (KeyValuePair<Flags.Diseños, Flags.Banderas> Entrada in Flags.Diccionario)
                        {
                            try
                            {
                                Lista_Imágenes_100_60.Images.Add(Dibujar_Bandera(Entrada.Key, Lista_Imágenes_100_60.ImageSize.Width, Lista_Imágenes_100_60.ImageSize.Height, true, true, true, false, false, Ondas.Ninguna, 0m, 0m, 0m, false, CheckState.Unchecked, false));
                            }
                            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                        }
                    }
                    ListView_Banderas.SmallImageList = Lista_Imágenes_100_60;
                    ListView_Banderas.LargeImageList = Lista_Imágenes_100_60;
                }
                else
                {
                    if (Lista_Imágenes_200_120 == null)
                    {
                        Lista_Imágenes_200_120 = new ImageList();
                        Lista_Imágenes_200_120.ColorDepth = ColorDepth.Depth32Bit;
                        Lista_Imágenes_200_120.ImageSize = new Size(200, 120);
                        Lista_Imágenes_200_120.TransparentColor = Color.Empty;
                        foreach (KeyValuePair<Flags.Diseños, Flags.Banderas> Entrada in Flags.Diccionario)
                        {
                            try
                            {
                                Lista_Imágenes_200_120.Images.Add(Dibujar_Bandera(Entrada.Key, Lista_Imágenes_200_120.ImageSize.Width, Lista_Imágenes_200_120.ImageSize.Height, true, true, true, false, false, Ondas.Ninguna, 0m, 0m, 0m, false, CheckState.Unchecked, false));
                            }
                            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                        }
                    }
                    ListView_Banderas.SmallImageList = Lista_Imágenes_200_120;
                    ListView_Banderas.LargeImageList = Lista_Imágenes_200_120;
                }
                ListView_Banderas.EndUpdate();
                if (!Menú_Contextual_Mostrar_Descripción_Lista.Checked)
                {
                    ListView_Banderas.Visible = false;
                    //ListView_Banderas.Enabled = false;
                    GroupBox_Descripción_Lista.Text = "Flag description";
                    //TextBox_Descripción.Enabled = true;
                    TextBox_Descripción.Visible = true;
                    Button_Mostrar_Descripción_Lista.Image = Resources.Checked;
                    Button_Mostrar_Descripción_Lista.Text = " Show the flag list instead of the description ";
                }
                else
                {
                    TextBox_Descripción.Visible = false;
                    //TextBox_Descripción.Enabled = false;
                    GroupBox_Descripción_Lista.Text = "Flag selection list";
                    //ListView_Banderas.Enabled = true;
                    ListView_Banderas.Visible = true;
                    Button_Mostrar_Descripción_Lista.Image = Resources.Controles_TextBox;
                    Button_Mostrar_Descripción_Lista.Text = " Show the description instead of the flag list ";
                }
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_Resolución_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown_Ancho.Value = Screen.PrimaryScreen.Bounds.Width;
                NumericUpDown_Alto.Value = Screen.PrimaryScreen.Bounds.Height;
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Bandera_Aleatoria_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox_Bandera.SelectedIndex = Jupisoft.Rand.Next(0, ComboBox_Bandera.Items.Count);
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Siempre_Visible_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.TopMost = Menú_Contextual_Siempre_Visible.Checked;
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Resolución_Full_HD_Click(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown_Ancho.Value = 1920;
                NumericUpDown_Alto.Value = 1080;
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Resolución_4K_Click(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown_Ancho.Value = 3840;
                NumericUpDown_Alto.Value = 2160;
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Seleccionar_Microsoft_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!ListView_Banderas.Visible) Menú_Contextual_Mostrar_Descripción_Lista.PerformClick();
                ListView_Banderas.BeginUpdate();
                for (int Índice = 0; Índice < ListView_Banderas.Items.Count; Índice++)
                {
                    try
                    {
                        Flags.Diseños Diseño = (Flags.Diseños)Índice;
                        if (Diseño == Diseños.Abrosexual ||
                            Diseño == Diseños.Aceflux ||
                            Diseño == Diseños.Agender___2014__ ||
                            Diseño == Diseños.Ambiamorous ||
                            Diseño == Diseños.Androgyne ||
                            Diseño == Diseños.Aroace ||
                            Diseño == Diseños.Aroflux ||
                            Diseño == Diseños.Aromantic___2014__ ||
                            Diseño == Diseños.Asexual___2010__ ||
                            Diseño == Diseños.Bigender ||
                            Diseño == Diseños.Bisexual___1998__ ||
                            Diseño == Diseños.Demifluid ||
                            Diseño == Diseños.Demigender ||
                            Diseño == Diseños.Demigirl ||
                            Diseño == Diseños.Demiromantic ||
                            Diseño == Diseños.Demisexual ||
                            Diseño == Diseños.Gay___1979__ ||
                            Diseño == Diseños.Men_loving_men___Mlm__ ||
                            Diseño == Diseños.Vincian ||
                            Diseño == Diseños.Genderfluid___2012__ ||
                            Diseño == Diseños.Genderflux ||
                            Diseño == Diseños.Genderqueer___2011__ ||
                            Diseño == Diseños.Questioning ||
                            Diseño == Diseños.Greysexual ||
                            Diseño == Diseños.Intersex___2013__ ||
                            Diseño == Diseños.Lesbian___2019__ ||
                            Diseño == Diseños.Maverique ||
                            Diseño == Diseños.Neutrois ||
                            Diseño == Diseños.Nonbinary___2014__ ||
                            Diseño == Diseños.Omnisexual ||
                            Diseño == Diseños.Pangender ||
                            Diseño == Diseños.Pansexual___2010__ ||
                            Diseño == Diseños.Polyamory ||
                            Diseño == Diseños.Polysexual___2012__ ||
                            Diseño == Diseños.Transgender___1999__ ||
                            Diseño == Diseños.Trigender ||
                            //Diseño == Diseños.Two_Spirit ||
                            //Diseño == Diseños.Progress ||
                            Diseño == Diseños.Queer ||
                            Diseño == Diseños.Unlabeled)
                        {
                            ListView_Banderas.Items[Índice].Checked = true;
                        }
                        else ListView_Banderas.Items[Índice].Checked = false;
                    }
                    catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                }
                ListView_Banderas.EndUpdate();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_LGBTQIA_Microsoft_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Jupisoft.Ejecutar_Ruta("https://unlocked.microsoft.com/pride/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_LGBTQIA_Wiki_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Jupisoft.Ejecutar_Ruta("https://lgbtqia.fandom.com/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_Queerdom_Wiki_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Jupisoft.Ejecutar_Ruta("https://queerdom.fandom.com/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_LGBT_Portal_Wikipedia_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Jupisoft.Ejecutar_Ruta("https://en.wikipedia.org/wiki/Portal:LGBT", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_Copiar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (PictureBox_Bandera.Image != null)
                {
                    Clipboard.SetImage(PictureBox_Bandera.Image);
                }
                else SystemSounds.Beep.Play();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_Copiar_Color_Hexadecimal_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Texto_Hexadecimal_Portapapeles))
                {
                    Clipboard.SetText(Texto_Hexadecimal_Portapapeles);
                    SystemSounds.Asterisk.Play();
                }
                else SystemSounds.Beep.Play();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (PictureBox_Bandera.Image != null)
                {
                    Jupisoft.Crear_Carpetas(Ruta_Guardado_Global);
                    PictureBox_Bandera.Image.Save(Ruta_Guardado_Global + "\\" + Jupisoft.Obtener_Nombre_Temporal() + " Preview of " + ComboBox_Bandera.Text + ".png", ImageFormat.Png);
                    Jupisoft.Ejecutar_Ruta(Ruta_Guardado_Global, ProcessWindowStyle.Maximized);
                }
                else SystemSounds.Beep.Play();
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Temporizador_Principal_Tick(object sender, EventArgs e)
        {
            try
            {
                int Tick = Environment.TickCount; // Used in the next calculations.

                try // FPS calculation in real time.
                {
                    long FPS_Milisegundo = FPS_Cronómetro.ElapsedMilliseconds;
                    long FPS_Segundo = FPS_Milisegundo / 1000L;
                    int Milisegundo_Actual = FPS_Cronómetro.Elapsed.Milliseconds;
                    if (FPS_Segundo != FPS_Segundo_Anterior)
                    {
                        FPS_Segundo_Anterior = FPS_Segundo;
                        FPS_Real = FPS_Temporal;
                        Barra_Estado_Etiqueta_FPS.Text = "FPS: " + FPS_Real.ToString();
                        FPS_Temporal = 0L;
                    }
                    FPS_Temporal++;
                }
                catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }

                try // CPU and RAM use calculations.
                {
                    try
                    {
                        if (Tick % Jupisoft.Rendimiento_Procesador_Intervalo == 0) // Update every second.
                        {
                            if (Jupisoft.Rendimiento_Procesador != null)
                            {
                                double CPU = (double)Jupisoft.Rendimiento_Procesador.NextValue();
                                if (CPU < 0d) CPU = 0d;
                                else if (CPU > 100d) CPU = 100d;
                                Barra_Estado_Etiqueta_CPU.Text = "CPU: " + Jupisoft.Traducir_Número_Decimales_Redondear(CPU, 2) + " %";
                            }
                            Jupisoft.Proceso.Refresh();
                            long Memoria_Bytes = Jupisoft.Proceso.PagedMemorySize64;
                            Barra_Estado_Etiqueta_Memoria.Text = "RAM: " + Jupisoft.Traducir_Tamaño_Bytes_Automático(Memoria_Bytes, 2, true);
                            if (Memoria_Bytes < 4294967296L) // < 4 GB, default black text.
                            {
                                if (Variable_Memoria)
                                {
                                    Variable_Memoria = false;
                                    Barra_Estado_Etiqueta_Memoria.ForeColor = Color.Black;
                                }
                            }
                            else // >= 4 GB, flash in red text every 500 milliseconds.
                            {
                                if ((Tick / 500) % 2 == 0)
                                {
                                    if (!Variable_Memoria)
                                    {
                                        Variable_Memoria = true;
                                        Barra_Estado_Etiqueta_Memoria.ForeColor = Color.Red;
                                    }
                                }
                                else
                                {
                                    if (Variable_Memoria)
                                    {
                                        Variable_Memoria = false;
                                        Barra_Estado_Etiqueta_Memoria.ForeColor = Color.Black;
                                    }
                                }
                            }
                        }
                    }
                    catch { Barra_Estado_Etiqueta_Memoria.Text = "RAM: ? MB (? GB)"; }
                }
                catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        internal void Agregar_Excepción(string Mensaje)
        {
            try
            {
                Debugger.Escribir_Excepción(Mensaje);
                Variable_Excepciones++;
                Barra_Estado_Botón_Excepción.Text = "Exceptions: " + Jupisoft.Traducir_Número(Variable_Excepciones);
            }
            catch { }
        }

        internal Color Color_Hexadecimal(string Texto_Hexadecimal)
        {
            try
            {
                if (!string.IsNullOrEmpty(Texto_Hexadecimal))
                {
                    string Texto = string.Empty;
                    foreach (char Caracter in Texto_Hexadecimal)
                    {
                        try
                        {
                            if (char.IsLetterOrDigit(Caracter))
                            {
                                Texto += Caracter;
                            }
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                    while (Texto.Length < 6) Texto = Texto + '0';
                    while (Texto.Length < 8) Texto = 'F' + Texto;
                    return Color.FromArgb(Convert.ToByte(Texto.Substring(0, 2), 16), Convert.ToByte(Texto.Substring(2, 2), 16), Convert.ToByte(Texto.Substring(4, 2), 16), Convert.ToByte(Texto.Substring(6, 2), 16));
                }
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return Color.Transparent;
        }

        internal Bitmap Dibujar_Bandera(Flags.Diseños Diseño, int Ancho_Cliente, int Alto_Cliente, bool Rayas, bool Figuras, bool Iconos, bool Suavizado, bool Rotar_90, Flags.Ondas Onda, decimal Cantidad_Ondas, decimal Amplitud_Ondas, decimal Fase_Ondas, bool Invertir_Ondas, CheckState Radial, bool Todas)
        {
            try
            {
                if (!Todas)
                {
                    if (Ancho_Cliente > 0 && Alto_Cliente > 0 && Flags.Diccionario.ContainsKey(Diseño))
                    {
                        /*if (Rotar_90)
                        {
                            int Temp = Ancho_Cliente;
                            Ancho_Cliente = Alto_Cliente;
                            Alto_Cliente = Temp;
                        }*/
                        int Ancho = (int)Math.Round((Alto_Cliente * 5m) / 3m, MidpointRounding.AwayFromZero);
                        int Alto = (int)Math.Round((Ancho_Cliente * 3m) / 5m, MidpointRounding.AwayFromZero);
                        if (Ancho <= Ancho_Cliente)
                        {
                            Alto = Alto_Cliente;
                        }
                        else
                        {
                            Ancho = Ancho_Cliente;
                        }

                        // First calculate the length of the waves.
                        int Amplitud = 0;
                        if (Onda != Flags.Ondas.Ninguna && Cantidad_Ondas > 0 && Amplitud_Ondas > 0m)
                        {
                            Amplitud = (int)Math.Round(((((decimal)Ancho_Cliente + (decimal)Alto_Cliente) / 2m) * Amplitud_Ondas) / 100m, MidpointRounding.AwayFromZero);
                        }
                        if (Amplitud > 0)
                        {
                            if (Onda == Flags.Ondas.Horizontal)
                            {
                                Alto -= Amplitud * 2;
                                int Valor = (int)Math.Round((Alto * 5m) / 3m, MidpointRounding.AwayFromZero);
                                if (Valor >= Ancho) Valor = (int)Math.Round((Alto * 3m) / 5m, MidpointRounding.AwayFromZero);
                                Ancho = Valor;
                            }
                            else if (Onda == Flags.Ondas.Vertical)
                            {
                                Ancho -= Amplitud * 2;
                                int Valor = (int)Math.Round((Ancho * 5m) / 3m, MidpointRounding.AwayFromZero);
                                if (Valor >= Alto) Valor = (int)Math.Round((Ancho * 3m) / 5m, MidpointRounding.AwayFromZero);
                                Alto = Valor;
                            }
                        }
                        /*//Ancho_Cliente -= Amplitud * 2;
                        //Alto_Cliente -= Amplitud * 2;
                        int Ancho = Ancho_Cliente; // 150.
                        int Alto = ((Ancho * 3) / 5); // 100.
                        if (Onda == Ondas.Horizontal) Ancho -= Amplitud * 2;
                        else if (Onda == Ondas.Vertical) Alto -= Amplitud * 2;*/

                        if (Ancho > 0 && Alto > 0)
                        {
                            if (Rotar_90)
                            {
                                int Temp = Ancho;
                                Ancho = Alto;
                                Alto = Temp;
                            }
                            Flags.Banderas Bandera = Flags.Diccionario[Diseño];

                            Bitmap Imagen = new Bitmap(Ancho, Alto, PixelFormat.Format32bppArgb);
                            Graphics Pintar = Graphics.FromImage(Imagen);
                            Pintar.CompositingMode = !Suavizado ? CompositingMode.SourceCopy : CompositingMode.SourceOver;
                            Pintar.CompositingQuality = CompositingQuality.HighQuality;
                            Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            Pintar.SmoothingMode = !Suavizado ? SmoothingMode.None : SmoothingMode.HighQuality;
                            Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;

                            if (Radial == CheckState.Unchecked)
                            {
                                // Stripes:
                                if (Bandera.Matriz_Operaciones_Rayas != null && Bandera.Matriz_Operaciones_Rayas.Length > 0)
                                {
                                    foreach (Flags.Operaciones Operación in Bandera.Matriz_Operaciones_Rayas)
                                    {
                                        try
                                        {
                                            if ((Operación.Dibujo == Dibujos.Rayas && Rayas) ||
                                                (Operación.Dibujo == Dibujos.Figuras && Figuras) ||
                                                (Operación.Dibujo == Dibujos.Iconos && Iconos))
                                            {
                                                if (Operación.Función == Flags.Funciones.Rectángulo)
                                                {
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    SolidBrush Pincel = new SolidBrush(Color_ARGB);
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar.FillRectangle(Pincel, (float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3]));
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Círculo)
                                                {
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    SolidBrush Pincel = new SolidBrush(Color_ARGB);
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar.FillEllipse(Pincel, (float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3]));
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Ángulo)
                                                {
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    SolidBrush Pincel = new SolidBrush(Color_ARGB);
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar.FillPie(Pincel, (float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3]), (float)Operación.Matriz_Proporciones[4], (float)Operación.Matriz_Proporciones[5]);
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Polígono)
                                                {
                                                    PointF[] Matriz_Posiciones = new PointF[Operación.Matriz_Proporciones.Length / 2];
                                                    for (int Índice = 0, Índice_Posición = 0; Índice < Operación.Matriz_Proporciones.Length; Índice += 2, Índice_Posición++)
                                                    {
                                                        try
                                                        {
                                                            Matriz_Posiciones[Índice_Posición] = new PointF((float)((decimal)Ancho * Operación.Matriz_Proporciones[Índice]), (float)((decimal)Alto * Operación.Matriz_Proporciones[Índice + 1]));
                                                        }
                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                    }
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    SolidBrush Pincel = new SolidBrush(Color_ARGB);
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar.FillPolygon(Pincel, Matriz_Posiciones);
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                    Matriz_Posiciones = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Rectángulo_Degradado)
                                                {
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    Color Color_ARGB_2 = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Operación.Matriz_Colores_Hexadecimales.Length - 1]);
                                                    LinearGradientBrush Pincel = new LinearGradientBrush(new RectangleF((float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3])), Color_ARGB, Color_ARGB_2, Operación.Degradado);
                                                    ColorBlend Mezcla_Colores = new ColorBlend(Operación.Matriz_Colores_Hexadecimales.Length);
                                                    for (int Índice = 0; Índice < Operación.Matriz_Colores_Hexadecimales.Length; Índice++)
                                                    {
                                                        try
                                                        {
                                                            Mezcla_Colores.Colors[Índice] = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Índice]);
                                                            Mezcla_Colores.Positions[Índice] = (float)((decimal)Índice / ((decimal)Operación.Matriz_Colores_Hexadecimales.Length - 1m));
                                                        }
                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                    }
                                                    Pincel.InterpolationColors = Mezcla_Colores;
                                                    //Pincel.GammaCorrection = true;
                                                    if ((Color_ARGB.A <= 0 || Color_ARGB_2.A <= 0) && Suavizado) Pintar.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar.FillRectangle(Pincel, (float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3]));
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Círculo_Degradado)
                                                {
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    Color Color_ARGB_2 = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Operación.Matriz_Colores_Hexadecimales.Length - 1]);
                                                    LinearGradientBrush Pincel = new LinearGradientBrush(new RectangleF((float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3])), Color_ARGB, Color_ARGB_2, Operación.Degradado);
                                                    ColorBlend Mezcla_Colores = new ColorBlend(Operación.Matriz_Colores_Hexadecimales.Length);
                                                    for (int Índice = 0; Índice < Operación.Matriz_Colores_Hexadecimales.Length; Índice++)
                                                    {
                                                        try
                                                        {
                                                            Mezcla_Colores.Colors[Índice] = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Índice]);
                                                            Mezcla_Colores.Positions[Índice] = (float)((decimal)Índice / ((decimal)Operación.Matriz_Colores_Hexadecimales.Length - 1m));
                                                        }
                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                    }
                                                    Pincel.InterpolationColors = Mezcla_Colores;
                                                    //Pincel.GammaCorrection = true;
                                                    if ((Color_ARGB.A <= 0 || Color_ARGB_2.A <= 0) && Suavizado) Pintar.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar.FillEllipse(Pincel, (float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3]));
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Polígono_Degradado)
                                                {
                                                    PointF[] Matriz_Posiciones = new PointF[Operación.Matriz_Proporciones.Length / 2];
                                                    for (int Índice = 0, Índice_Posición = 0; Índice < Operación.Matriz_Proporciones.Length; Índice += 2, Índice_Posición++)
                                                    {
                                                        try
                                                        {
                                                            Matriz_Posiciones[Índice_Posición] = new PointF((float)((decimal)Ancho * Operación.Matriz_Proporciones[Índice]), (float)((decimal)Alto * Operación.Matriz_Proporciones[Índice + 1]));
                                                        }
                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                    }
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    Color Color_ARGB_2 = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Operación.Matriz_Colores_Hexadecimales.Length - 1]);
                                                    LinearGradientBrush Pincel = new LinearGradientBrush(new RectangleF(0f, 0f, (float)Ancho, (float)Alto), Color_ARGB, Color_ARGB_2, Operación.Degradado);
                                                    ColorBlend Mezcla_Colores = new ColorBlend(Operación.Matriz_Colores_Hexadecimales.Length);
                                                    bool Colores_Transparentes = false;
                                                    for (int Índice = 0; Índice < Operación.Matriz_Colores_Hexadecimales.Length; Índice++)
                                                    {
                                                        try
                                                        {
                                                            Mezcla_Colores.Colors[Índice] = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Índice]);
                                                            Mezcla_Colores.Positions[Índice] = (float)((decimal)Índice / ((decimal)Operación.Matriz_Colores_Hexadecimales.Length - 1m));
                                                            if (Mezcla_Colores.Colors[Índice].A <= 0) Colores_Transparentes = true;
                                                        }
                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                    }
                                                    Pincel.InterpolationColors = Mezcla_Colores;
                                                    //Pincel.GammaCorrection = true;
                                                    if (Colores_Transparentes && Suavizado) Pintar.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar.FillPolygon(Pincel, Matriz_Posiciones);
                                                    if (Colores_Transparentes && Suavizado) Pintar.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                    Matriz_Posiciones = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Polígono_Degradado_Simple)
                                                {
                                                    PointF[] Matriz_Posiciones = new PointF[Operación.Matriz_Proporciones.Length / 2];
                                                    for (int Índice = 0, Índice_Posición = 0; Índice < Operación.Matriz_Proporciones.Length; Índice += 2, Índice_Posición++)
                                                    {
                                                        try
                                                        {
                                                            Matriz_Posiciones[Índice_Posición] = new PointF((float)((decimal)Ancho * Operación.Matriz_Proporciones[Índice]), (float)((decimal)Alto * Operación.Matriz_Proporciones[Índice + 1]));
                                                        }
                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                    }
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    Color Color_ARGB_2 = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Operación.Matriz_Colores_Hexadecimales.Length - 1]);
                                                    LinearGradientBrush Pincel = new LinearGradientBrush(new RectangleF(0f, 0f, (float)Ancho, (float)Alto), Color_ARGB, Color_ARGB_2, Operación.Degradado);
                                                    ColorBlend Mezcla_Colores = new ColorBlend(Operación.Matriz_Colores_Hexadecimales.Length * 2);
                                                    bool Colores_Transparentes = false;
                                                    for (int Índice = 0, Índice_Color = 0; Índice < Operación.Matriz_Colores_Hexadecimales.Length * 2; Índice += 2, Índice_Color++)
                                                    {
                                                        try
                                                        {
                                                            Mezcla_Colores.Colors[Índice] = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Índice_Color]);
                                                            Mezcla_Colores.Positions[Índice] = (float)((decimal)Índice_Color / (decimal)Operación.Matriz_Colores_Hexadecimales.Length);
                                                            if (Mezcla_Colores.Colors[Índice].A <= 0) Colores_Transparentes = true;
                                                            Mezcla_Colores.Colors[Índice + 1] = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Índice_Color]);
                                                            Mezcla_Colores.Positions[Índice + 1] = (float)(((decimal)Índice_Color + 1m) / (decimal)Operación.Matriz_Colores_Hexadecimales.Length);
                                                        }
                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                    }
                                                    Pincel.InterpolationColors = Mezcla_Colores;
                                                    //Pincel.GammaCorrection = true;
                                                    if (Colores_Transparentes && Suavizado) Pintar.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar.FillPolygon(Pincel, Matriz_Posiciones);
                                                    if (Colores_Transparentes && Suavizado) Pintar.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                    Matriz_Posiciones = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Imagen)
                                                {
                                                    string Ruta = Application.StartupPath + "\\Flags\\" + Operación.Ruta;
                                                    if (!string.IsNullOrEmpty(Ruta) && File.Exists(Ruta))
                                                    {
                                                        Bitmap Imagen_Ruta = Jupisoft.Cargar_Imagen_Ruta(Ruta, CheckState.Checked);
                                                        if (Imagen_Ruta != null)
                                                        {
                                                            int Ancho_Ruta = Imagen_Ruta.Width;
                                                            int Alto_Ruta = Imagen_Ruta.Height;
                                                            if (!Suavizado) Pintar.CompositingMode = CompositingMode.SourceOver;
                                                            Pintar.DrawImage(Imagen_Ruta, new RectangleF((float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3])), new RectangleF(0f, 0f, (float)Ancho_Ruta, (float)Alto_Ruta), GraphicsUnit.Pixel);
                                                            if (!Suavizado) Pintar.CompositingMode = CompositingMode.SourceCopy;
                                                            Imagen_Ruta.Dispose();
                                                            Imagen_Ruta = null;
                                                        }
                                                    }
                                                    Ruta = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Imagen_Recorte)
                                                {
                                                    string Ruta = Application.StartupPath + "\\Flags\\" + Operación.Ruta;
                                                    if (!string.IsNullOrEmpty(Ruta) && File.Exists(Ruta))
                                                    {
                                                        Bitmap Imagen_Ruta = Jupisoft.Cargar_Imagen_Ruta(Ruta, CheckState.Checked);
                                                        if (Imagen_Ruta != null)
                                                        {
                                                            Bitmap Imagen_Temporal = new Bitmap(Ancho, Alto, PixelFormat.Format32bppArgb);
                                                            Graphics Pintar_Temporal = Graphics.FromImage(Imagen_Temporal);
                                                            Pintar_Temporal.CompositingMode = !Suavizado ? CompositingMode.SourceCopy : CompositingMode.SourceOver;
                                                            Pintar_Temporal.CompositingQuality = CompositingQuality.HighQuality;
                                                            Pintar_Temporal.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                                            Pintar_Temporal.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                                            Pintar_Temporal.SmoothingMode = !Suavizado ? SmoothingMode.None : SmoothingMode.HighQuality;
                                                            Pintar_Temporal.TextRenderingHint = TextRenderingHint.AntiAlias;
                                                            if (!Suavizado) Pintar_Temporal.CompositingMode = CompositingMode.SourceOver;
                                                            Pintar_Temporal.DrawImage(Imagen_Ruta, new RectangleF((float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3])), new RectangleF(0f, 0f, (float)Imagen_Ruta.Width, (float)Imagen_Ruta.Height), GraphicsUnit.Pixel);
                                                            if (!Suavizado) Pintar_Temporal.CompositingMode = CompositingMode.SourceCopy;
                                                            Pintar_Temporal.Dispose();
                                                            Pintar_Temporal = null;
                                                            Imagen_Ruta = Imagen_Temporal;

                                                            BitmapData Bitmap_Data_Ruta = Imagen_Ruta.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadOnly, Imagen_Ruta.PixelFormat);
                                                            int Ancho_Stride_Ruta = Math.Abs(Bitmap_Data_Ruta.Stride);
                                                            int Bytes_Aumento_Ruta = !Image.IsAlphaPixelFormat(Imagen_Ruta.PixelFormat) ? 3 : 4;
                                                            int Bytes_Diferencia_Ruta = Ancho_Stride_Ruta - ((Ancho * Image.GetPixelFormatSize(Imagen_Ruta.PixelFormat)) / 8);
                                                            byte[] Matriz_Bytes_Ruta = new byte[Ancho_Stride_Ruta * Alto];
                                                            Marshal.Copy(Bitmap_Data_Ruta.Scan0, Matriz_Bytes_Ruta, 0, Matriz_Bytes_Ruta.Length);
                                                            Imagen_Ruta.UnlockBits(Bitmap_Data_Ruta);
                                                            Imagen_Ruta.Dispose();
                                                            Imagen_Ruta = null;

                                                            Pintar.Dispose();
                                                            Pintar = null;

                                                            BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadWrite, Imagen.PixelFormat);
                                                            int Ancho_Stride = Math.Abs(Bitmap_Data.Stride);
                                                            int Bytes_Aumento = !Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 3 : 4;
                                                            int Bytes_Diferencia = Ancho_Stride - ((Ancho * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                                                            byte[] Matriz_Bytes = new byte[Ancho_Stride * Alto];
                                                            Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);

                                                            for (int Y = 0, Índice = 0; Y < Alto; Y++, Índice += Bytes_Diferencia)
                                                            {
                                                                try
                                                                {
                                                                    for (int X = 0; X < Ancho; X++, Índice += Bytes_Aumento)
                                                                    {
                                                                        try
                                                                        {
                                                                            if (Matriz_Bytes_Ruta[Índice + 3] < 128)
                                                                            {
                                                                                Matriz_Bytes[Índice + 3] = 0;
                                                                                Matriz_Bytes[Índice + 2] = 0;
                                                                                Matriz_Bytes[Índice + 1] = 0;
                                                                                Matriz_Bytes[Índice] = 0;
                                                                            }
                                                                        }
                                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                                    }
                                                                }
                                                                catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                            }
                                                            Marshal.Copy(Matriz_Bytes, 0, Bitmap_Data.Scan0, Matriz_Bytes.Length);
                                                            Imagen.UnlockBits(Bitmap_Data);
                                                            Matriz_Bytes = null;
                                                            Matriz_Bytes_Ruta = null;

                                                            Pintar = Graphics.FromImage(Imagen);
                                                            Pintar.CompositingMode = !Suavizado ? CompositingMode.SourceCopy : CompositingMode.SourceOver;
                                                            Pintar.CompositingQuality = CompositingQuality.HighQuality;
                                                            Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                                            Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                                            Pintar.SmoothingMode = !Suavizado ? SmoothingMode.None : SmoothingMode.HighQuality;
                                                            Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;
                                                        }
                                                    }
                                                    Ruta = null;
                                                }
                                            }
                                        }
                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                    }
                                }

                                // Extra parts:
                                if (Bandera.Matriz_Operaciones_Extra != null && Bandera.Matriz_Operaciones_Extra.Length > 0)
                                {
                                    Bitmap Imagen_Extra = new Bitmap(Ancho, Alto, PixelFormat.Format32bppArgb);
                                    Graphics Pintar_Extra = Graphics.FromImage(Imagen_Extra);
                                    Pintar_Extra.CompositingMode = !Suavizado ? CompositingMode.SourceCopy : CompositingMode.SourceOver;
                                    Pintar_Extra.CompositingQuality = CompositingQuality.HighQuality;
                                    Pintar_Extra.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                    Pintar_Extra.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                    Pintar_Extra.SmoothingMode = !Suavizado ? SmoothingMode.None : SmoothingMode.HighQuality;
                                    Pintar_Extra.TextRenderingHint = TextRenderingHint.AntiAlias;
                                    foreach (Flags.Operaciones Operación in Bandera.Matriz_Operaciones_Extra)
                                    {
                                        try
                                        {
                                            if ((Operación.Dibujo == Dibujos.Rayas && Rayas) ||
                                                (Operación.Dibujo == Dibujos.Figuras && Figuras) ||
                                                (Operación.Dibujo == Dibujos.Iconos && Iconos))
                                            {
                                                if (Operación.Función == Flags.Funciones.Rectángulo)
                                                {
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    SolidBrush Pincel = new SolidBrush(Color_ARGB);
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar_Extra.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar_Extra.FillRectangle(Pincel, (float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3]));
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar_Extra.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Círculo)
                                                {
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    SolidBrush Pincel = new SolidBrush(Color_ARGB);
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar_Extra.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar_Extra.FillEllipse(Pincel, (float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3]));
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar_Extra.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Ángulo)
                                                {
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    SolidBrush Pincel = new SolidBrush(Color_ARGB);
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar_Extra.FillPie(Pincel, (float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3]), (float)Operación.Matriz_Proporciones[4], (float)Operación.Matriz_Proporciones[5]);
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Polígono)
                                                {
                                                    PointF[] Matriz_Posiciones = new PointF[Operación.Matriz_Proporciones.Length / 2];
                                                    for (int Índice = 0, Índice_Posición = 0; Índice < Operación.Matriz_Proporciones.Length; Índice += 2, Índice_Posición++)
                                                    {
                                                        try
                                                        {
                                                            Matriz_Posiciones[Índice_Posición] = new PointF((float)((decimal)Ancho * Operación.Matriz_Proporciones[Índice]), (float)((decimal)Alto * Operación.Matriz_Proporciones[Índice + 1]));
                                                        }
                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                    }
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    SolidBrush Pincel = new SolidBrush(Color_ARGB);
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar_Extra.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar_Extra.FillPolygon(Pincel, Matriz_Posiciones);
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar_Extra.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                    Matriz_Posiciones = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Rectángulo_Degradado)
                                                {
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    Color Color_ARGB_2 = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Operación.Matriz_Colores_Hexadecimales.Length - 1]);
                                                    LinearGradientBrush Pincel = new LinearGradientBrush(new RectangleF((float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3])), Color_ARGB, Color_ARGB_2, Operación.Degradado);
                                                    ColorBlend Mezcla_Colores = new ColorBlend(Operación.Matriz_Colores_Hexadecimales.Length);
                                                    for (int Índice = 0; Índice < Operación.Matriz_Colores_Hexadecimales.Length; Índice++)
                                                    {
                                                        try
                                                        {
                                                            Mezcla_Colores.Colors[Índice] = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Índice]);
                                                            Mezcla_Colores.Positions[Índice] = (float)((decimal)Índice / ((decimal)Operación.Matriz_Colores_Hexadecimales.Length - 1m));
                                                        }
                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                    }
                                                    Pincel.InterpolationColors = Mezcla_Colores;
                                                    //Pincel.GammaCorrection = true;
                                                    if ((Color_ARGB.A <= 0 || Color_ARGB_2.A <= 0) && Suavizado) Pintar_Extra.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar_Extra.FillRectangle(Pincel, (float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3]));
                                                    if ((Color_ARGB.A <= 0 || Color_ARGB_2.A <= 0) && Suavizado) Pintar_Extra.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Círculo_Degradado)
                                                {
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    Color Color_ARGB_2 = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Operación.Matriz_Colores_Hexadecimales.Length - 1]);
                                                    LinearGradientBrush Pincel = new LinearGradientBrush(new RectangleF((float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3])), Color_ARGB, Color_ARGB_2, Operación.Degradado);
                                                    ColorBlend Mezcla_Colores = new ColorBlend(Operación.Matriz_Colores_Hexadecimales.Length);
                                                    for (int Índice = 0; Índice < Operación.Matriz_Colores_Hexadecimales.Length; Índice++)
                                                    {
                                                        try
                                                        {
                                                            Mezcla_Colores.Colors[Índice] = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Índice]);
                                                            Mezcla_Colores.Positions[Índice] = (float)((decimal)Índice / ((decimal)Operación.Matriz_Colores_Hexadecimales.Length - 1m));
                                                        }
                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                    }
                                                    Pincel.InterpolationColors = Mezcla_Colores;
                                                    //Pincel.GammaCorrection = true;
                                                    if ((Color_ARGB.A <= 0 || Color_ARGB_2.A <= 0) && Suavizado) Pintar_Extra.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar_Extra.FillEllipse(Pincel, (float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3]));
                                                    if (Color_ARGB.A <= 0 && Suavizado) Pintar_Extra.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Polígono_Degradado)
                                                {
                                                    PointF[] Matriz_Posiciones = new PointF[Operación.Matriz_Proporciones.Length / 2];
                                                    for (int Índice = 0, Índice_Posición = 0; Índice < Operación.Matriz_Proporciones.Length; Índice += 2, Índice_Posición++)
                                                    {
                                                        try
                                                        {
                                                            Matriz_Posiciones[Índice_Posición] = new PointF((float)((decimal)Ancho * Operación.Matriz_Proporciones[Índice]), (float)((decimal)Alto * Operación.Matriz_Proporciones[Índice + 1]));
                                                        }
                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                    }
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    Color Color_ARGB_2 = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Operación.Matriz_Colores_Hexadecimales.Length - 1]);
                                                    LinearGradientBrush Pincel = new LinearGradientBrush(new RectangleF(0f, 0f, (float)Ancho, (float)Alto), Color_ARGB, Color_ARGB_2, Operación.Degradado);
                                                    ColorBlend Mezcla_Colores = new ColorBlend(Operación.Matriz_Colores_Hexadecimales.Length);
                                                    bool Colores_Transparentes = false;
                                                    for (int Índice = 0; Índice < Operación.Matriz_Colores_Hexadecimales.Length; Índice++)
                                                    {
                                                        try
                                                        {
                                                            Mezcla_Colores.Colors[Índice] = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Índice]);
                                                            Mezcla_Colores.Positions[Índice] = (float)((decimal)Índice / ((decimal)Operación.Matriz_Colores_Hexadecimales.Length - 1m));
                                                            if (Mezcla_Colores.Colors[Índice].A <= 0) Colores_Transparentes = true;
                                                        }
                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                    }
                                                    Pincel.InterpolationColors = Mezcla_Colores;
                                                    //Pincel.GammaCorrection = true;
                                                    if (Colores_Transparentes && Suavizado) Pintar.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar_Extra.FillPolygon(Pincel, Matriz_Posiciones);
                                                    if (Colores_Transparentes && Suavizado) Pintar.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                    Matriz_Posiciones = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Polígono_Degradado_Simple)
                                                {
                                                    PointF[] Matriz_Posiciones = new PointF[Operación.Matriz_Proporciones.Length / 2];
                                                    for (int Índice = 0, Índice_Posición = 0; Índice < Operación.Matriz_Proporciones.Length; Índice += 2, Índice_Posición++)
                                                    {
                                                        try
                                                        {
                                                            Matriz_Posiciones[Índice_Posición] = new PointF((float)((decimal)Ancho * Operación.Matriz_Proporciones[Índice]), (float)((decimal)Alto * Operación.Matriz_Proporciones[Índice + 1]));
                                                        }
                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                    }
                                                    Color Color_ARGB = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[0]);
                                                    Color Color_ARGB_2 = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Operación.Matriz_Colores_Hexadecimales.Length - 1]);
                                                    LinearGradientBrush Pincel = new LinearGradientBrush(new RectangleF(0f, 0f, (float)Ancho, (float)Alto), Color_ARGB, Color_ARGB_2, Operación.Degradado);
                                                    ColorBlend Mezcla_Colores = new ColorBlend(Operación.Matriz_Colores_Hexadecimales.Length * 2);
                                                    bool Colores_Transparentes = false;
                                                    for (int Índice = 0, Índice_Color = 0; Índice < Operación.Matriz_Colores_Hexadecimales.Length * 2; Índice += 2, Índice_Color++)
                                                    {
                                                        try
                                                        {
                                                            Mezcla_Colores.Colors[Índice] = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Índice_Color]);
                                                            Mezcla_Colores.Positions[Índice] = (float)((decimal)Índice_Color / (decimal)Operación.Matriz_Colores_Hexadecimales.Length);
                                                            if (Mezcla_Colores.Colors[Índice].A <= 0) Colores_Transparentes = true;
                                                            Mezcla_Colores.Colors[Índice + 1] = Color_Hexadecimal(Operación.Matriz_Colores_Hexadecimales[Índice_Color]);
                                                            Mezcla_Colores.Positions[Índice + 1] = (float)(((decimal)Índice_Color + 1m) / (decimal)Operación.Matriz_Colores_Hexadecimales.Length);
                                                        }
                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                    }
                                                    Pincel.InterpolationColors = Mezcla_Colores;
                                                    //Pincel.GammaCorrection = true;
                                                    if (Colores_Transparentes && Suavizado) Pintar.CompositingMode = CompositingMode.SourceCopy;
                                                    Pintar_Extra.FillPolygon(Pincel, Matriz_Posiciones);
                                                    if (Colores_Transparentes && Suavizado) Pintar.CompositingMode = CompositingMode.SourceOver;
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                    Matriz_Posiciones = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Imagen)
                                                {
                                                    string Ruta = Application.StartupPath + "\\Flags\\" + Operación.Ruta;
                                                    if (!string.IsNullOrEmpty(Ruta) && File.Exists(Ruta))
                                                    {
                                                        Bitmap Imagen_Ruta = Jupisoft.Cargar_Imagen_Ruta(Ruta, CheckState.Checked);
                                                        if (Imagen_Ruta != null)
                                                        {
                                                            int Ancho_Ruta = Imagen_Ruta.Width;
                                                            int Alto_Ruta = Imagen_Ruta.Height;
                                                            if (!Suavizado) Pintar_Extra.CompositingMode = CompositingMode.SourceOver;
                                                            Pintar_Extra.DrawImage(Imagen_Ruta, new RectangleF((float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3])), new RectangleF(0f, 0f, (float)Ancho_Ruta, (float)Alto_Ruta), GraphicsUnit.Pixel);
                                                            if (!Suavizado) Pintar_Extra.CompositingMode = CompositingMode.SourceCopy;
                                                            Imagen_Ruta.Dispose();
                                                            Imagen_Ruta = null;
                                                        }
                                                    }
                                                    Ruta = null;
                                                }
                                                else if (Operación.Función == Flags.Funciones.Imagen_Recorte)
                                                {
                                                    string Ruta = Application.StartupPath + "\\Flags\\" + Operación.Ruta;
                                                    if (!string.IsNullOrEmpty(Ruta) && File.Exists(Ruta))
                                                    {
                                                        Bitmap Imagen_Ruta = Jupisoft.Cargar_Imagen_Ruta(Ruta, CheckState.Checked);
                                                        if (Imagen_Ruta != null)
                                                        {
                                                            Bitmap Imagen_Temporal = new Bitmap(Ancho, Alto, PixelFormat.Format32bppArgb);
                                                            Graphics Pintar_Temporal = Graphics.FromImage(Imagen_Temporal);
                                                            Pintar_Temporal.CompositingMode = !Suavizado ? CompositingMode.SourceCopy : CompositingMode.SourceOver;
                                                            Pintar_Temporal.CompositingQuality = CompositingQuality.HighQuality;
                                                            Pintar_Temporal.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                                            Pintar_Temporal.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                                            Pintar_Temporal.SmoothingMode = !Suavizado ? SmoothingMode.None : SmoothingMode.HighQuality;
                                                            Pintar_Temporal.TextRenderingHint = TextRenderingHint.AntiAlias;
                                                            if (!Suavizado) Pintar_Temporal.CompositingMode = CompositingMode.SourceOver;
                                                            Pintar_Temporal.DrawImage(Imagen_Ruta, new RectangleF((float)(Ancho * Operación.Matriz_Proporciones[0]), (float)(Alto * Operación.Matriz_Proporciones[1]), (float)(Ancho * Operación.Matriz_Proporciones[2]), (float)(Alto * Operación.Matriz_Proporciones[3])), new RectangleF(0f, 0f, (float)Imagen_Ruta.Width, (float)Imagen_Ruta.Height), GraphicsUnit.Pixel);
                                                            if (!Suavizado) Pintar_Temporal.CompositingMode = CompositingMode.SourceCopy;
                                                            Pintar_Temporal.Dispose();
                                                            Pintar_Temporal = null;
                                                            Imagen_Ruta = Imagen_Temporal;

                                                            BitmapData Bitmap_Data_Ruta = Imagen_Ruta.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadOnly, Imagen_Ruta.PixelFormat);
                                                            int Ancho_Stride_Ruta = Math.Abs(Bitmap_Data_Ruta.Stride);
                                                            int Bytes_Aumento_Ruta = !Image.IsAlphaPixelFormat(Imagen_Ruta.PixelFormat) ? 3 : 4;
                                                            int Bytes_Diferencia_Ruta = Ancho_Stride_Ruta - ((Ancho * Image.GetPixelFormatSize(Imagen_Ruta.PixelFormat)) / 8);
                                                            byte[] Matriz_Bytes_Ruta = new byte[Ancho_Stride_Ruta * Alto];
                                                            Marshal.Copy(Bitmap_Data_Ruta.Scan0, Matriz_Bytes_Ruta, 0, Matriz_Bytes_Ruta.Length);
                                                            Imagen_Ruta.UnlockBits(Bitmap_Data_Ruta);
                                                            Imagen_Ruta.Dispose();
                                                            Imagen_Ruta = null;

                                                            Pintar_Extra.Dispose();
                                                            Pintar_Extra = null;

                                                            BitmapData Bitmap_Data = Imagen_Extra.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadWrite, Imagen_Extra.PixelFormat);
                                                            int Ancho_Stride = Math.Abs(Bitmap_Data.Stride);
                                                            int Bytes_Aumento = !Image.IsAlphaPixelFormat(Imagen_Extra.PixelFormat) ? 3 : 4;
                                                            int Bytes_Diferencia = Ancho_Stride - ((Ancho * Image.GetPixelFormatSize(Imagen_Extra.PixelFormat)) / 8);
                                                            byte[] Matriz_Bytes = new byte[Ancho_Stride * Alto];
                                                            Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);

                                                            for (int Y = 0, Índice = 0; Y < Alto; Y++, Índice += Bytes_Diferencia)
                                                            {
                                                                try
                                                                {
                                                                    for (int X = 0; X < Ancho; X++, Índice += Bytes_Aumento)
                                                                    {
                                                                        try
                                                                        {
                                                                            if (Matriz_Bytes_Ruta[Índice + 3] < 128)
                                                                            {
                                                                                Matriz_Bytes[Índice + 3] = 0;
                                                                                Matriz_Bytes[Índice + 2] = 0;
                                                                                Matriz_Bytes[Índice + 1] = 0;
                                                                                Matriz_Bytes[Índice] = 0;
                                                                            }
                                                                        }
                                                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                                    }
                                                                }
                                                                catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                                            }
                                                            Marshal.Copy(Matriz_Bytes, 0, Bitmap_Data.Scan0, Matriz_Bytes.Length);
                                                            Imagen_Extra.UnlockBits(Bitmap_Data);
                                                            Matriz_Bytes = null;
                                                            Matriz_Bytes_Ruta = null;

                                                            Pintar_Extra = Graphics.FromImage(Imagen_Extra);
                                                            Pintar_Extra.CompositingMode = !Suavizado ? CompositingMode.SourceCopy : CompositingMode.SourceOver;
                                                            Pintar_Extra.CompositingQuality = CompositingQuality.HighQuality;
                                                            Pintar_Extra.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                                            Pintar_Extra.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                                            Pintar_Extra.SmoothingMode = !Suavizado ? SmoothingMode.None : SmoothingMode.HighQuality;
                                                            Pintar_Extra.TextRenderingHint = TextRenderingHint.AntiAlias;
                                                        }
                                                    }
                                                    Ruta = null;
                                                }
                                            }
                                        }
                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                    }
                                    Pintar_Extra.Dispose();
                                    Pintar_Extra = null;
                                    if (!Suavizado) Pintar.CompositingMode = CompositingMode.SourceOver;
                                    Pintar.DrawImage(Imagen_Extra, new RectangleF(0f, 0f, (float)Ancho, (float)Alto), new RectangleF(0f, 0f, (float)Ancho, (float)Alto), GraphicsUnit.Pixel);
                                    if (!Suavizado) Pintar.CompositingMode = CompositingMode.SourceCopy;
                                }
                            }
                            else if (Radial == CheckState.Checked)
                            {
                                if (Bandera.Matriz_Radial_Colores_Hexadecimales != null && Bandera.Matriz_Radial_Colores_Hexadecimales.Length > 0 &&
                                    Bandera.Matriz_Radial_Proporciones != null && Bandera.Matriz_Radial_Proporciones.Length > 0)
                                {
                                    Pintar.TranslateTransform((float)((decimal)Ancho / 2m), (float)((decimal)Alto / 2m));
                                    decimal Ángulo = -90m;
                                    for (int Índice = 0; Índice < Bandera.Matriz_Radial_Colores_Hexadecimales.Length; Índice++)
                                    {
                                        try
                                        {
                                            Color Color_ARGB = Color_Hexadecimal(Bandera.Matriz_Radial_Colores_Hexadecimales[Índice]);
                                            SolidBrush Pincel = new SolidBrush(Color_ARGB);
                                            if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceCopy;
                                            Pintar.FillPie(Pincel, (float)-Ancho, (float)-Alto, (float)(Ancho * 2m), (float)(Alto * 2m), (float)Ángulo, (float)(Bandera.Matriz_Radial_Proporciones[Índice] * 360m));
                                            if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceOver;
                                            Pincel.Dispose();
                                            Pincel = null;
                                            Ángulo += Bandera.Matriz_Radial_Proporciones[Índice] * 360m;
                                        }
                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                    }
                                    Pintar.ResetTransform();
                                }
                            }
                            else if (Radial == CheckState.Indeterminate)
                            {
                                if (Bandera.Matriz_Radial_Colores_Hexadecimales != null && Bandera.Matriz_Radial_Colores_Hexadecimales.Length > 0 &&
                                    Bandera.Matriz_Radial_Proporciones != null && Bandera.Matriz_Radial_Proporciones.Length > 0)
                                {
                                    decimal Y = 0m;
                                    for (int Índice = 0; Índice < Bandera.Matriz_Radial_Colores_Hexadecimales.Length; Índice++)
                                    {
                                        try
                                        {
                                            Color Color_ARGB = Color_Hexadecimal(Bandera.Matriz_Radial_Colores_Hexadecimales[Índice]);
                                            SolidBrush Pincel = new SolidBrush(Color_ARGB);
                                            if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceCopy;
                                            Pintar.FillRectangle(Pincel, 0f, (float)(Y * (decimal)Alto), (float)Ancho, (float)(Bandera.Matriz_Radial_Proporciones[Índice] * (decimal)Alto));
                                            if (Color_ARGB.A <= 0 && Suavizado) Pintar.CompositingMode = CompositingMode.SourceOver;
                                            Pincel.Dispose();
                                            Pincel = null;
                                            Y += Bandera.Matriz_Radial_Proporciones[Índice];
                                        }
                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                    }
                                }
                            }

                            Pintar.Dispose();
                            Pintar = null;
                            if (Rotar_90) Imagen.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            if (Onda != Flags.Ondas.Ninguna && Amplitud > 0)
                            {
                                Imagen = Dibujar_Ondas(Imagen, Onda, (int)NumericUpDown_Cantidad.Value, Amplitud, (int)NumericUpDown_Fase.Value);
                            }
                            return Imagen;
                        }
                    }
                }
                else // Draw all selected flags at once.
                {
                    List<Flags.Banderas> Lista_Banderas = new List<Banderas>();
                    int Índice_Bandera = 0;
                    foreach (KeyValuePair<Flags.Diseños, Flags.Banderas> Entrada in Flags.Diccionario)
                    {
                        try
                        {
                            if (ListView_Banderas.Items[Índice_Bandera].Checked)
                            {
                                Lista_Banderas.Add(Entrada.Value);
                            }
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                        finally { Índice_Bandera++; }
                    }
                    if (Lista_Banderas.Count > 0)
                    {
                        if (ComboBox_Exportar.SelectedIndex == 1) // Random order each time.
                        {
                            List<Flags.Banderas> Lista_Banderas_Temporal = new List<Banderas>();
                            for (int Índice = Lista_Banderas.Count - 1; Índice >= 0; Índice--)
                            {
                                try
                                {
                                    int Índice_Aleatorio = Jupisoft.Rand.Next(0, Lista_Banderas.Count);
                                    Lista_Banderas_Temporal.Add(Lista_Banderas[Índice_Aleatorio]);
                                    Lista_Banderas.RemoveAt(Índice_Aleatorio);
                                }
                                catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                            }
                            Lista_Banderas = Lista_Banderas_Temporal.GetRange(0, Lista_Banderas_Temporal.Count);
                            Lista_Banderas_Temporal = null;
                        }
                        decimal Total_Banderas = (decimal)Lista_Banderas.Count;
                        int Ancho = Ancho_Cliente; //1920 * 2; //10667 * 1; //5000;
                        int Alto = Alto_Cliente; //1080 * 2; //6000 * 1; //3000;
                        //int Ancho = 8192; //10667 * 1; //5000;
                        //int Alto = 8192; //6000 * 1; //3000;
                        Bitmap Imagen = new Bitmap(Ancho, Alto, PixelFormat.Format32bppArgb);
                        Graphics Pintar = Graphics.FromImage(Imagen);
                        Pintar.CompositingMode = !Suavizado ? CompositingMode.SourceCopy : CompositingMode.SourceOver;
                        Pintar.CompositingQuality = CompositingQuality.HighQuality;
                        Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Pintar.SmoothingMode = !Suavizado ? SmoothingMode.None : SmoothingMode.HighQuality; // Anti-alias always recommended in this case.
                        Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;
                        Pintar.Clear(Color.Black);

                        Pintar.TranslateTransform((float)((decimal)Ancho / 2m), (float)((decimal)Alto / 2m));

                        /*foreach (KeyValuePair<Flags.Diseños, Flags.Banderas> Entrada in Flags.Diccionario)
                        {
                            try
                            {
                                //if (Entrada.Value.Radial) Total_Banderas++;
                                if (ListView_Banderas.Items[Índice_Bandera].Checked) Total_Banderas++;
                            }
                            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                            finally { Índice_Bandera++; }
                        }*/
                        //Total_Banderas *= 1m;
                        decimal Ángulo_Bandera = 360m / Total_Banderas;
                        //decimal Ángulo_Bandera_Doble = Ángulo_Bandera * 0.25m;
                        //Ángulo_Bandera *= 0.75m;
                        //MessageBox.Show(Total_Banderas.ToString());
                        //decimal Ángulo_Bandera = 360m / (decimal)Diccionario.Count;
                        //decimal Ángulo_Color = 360m / (decimal)Bandera.Matriz_Operaciones_Base.Length;
                        decimal Ángulo = -90m;

                        //Random Rand = new Random();
                        //decimal Índice_Bandera = 1m;
                        decimal Ancho_Alto = Math.Min(Ancho, Alto);
                        //Índice_Bandera = 0;
                        //foreach (KeyValuePair<Flags.Diseños, Flags.Banderas> Entrada in Flags.Diccionario)
                        foreach (Flags.Banderas Bandera in Lista_Banderas)
                        {
                            try
                            {
                                //decimal Ángulo_Zona = 0m;
                                if (Ángulo >= -90m && Ángulo < 90m)
                                {
                                    for (int Índice = 0; Índice < Bandera.Matriz_Radial_Colores_Hexadecimales.Length; Índice++)
                                    {
                                        try
                                        {
                                            decimal Ángulo_Color = Ángulo_Bandera * Bandera.Matriz_Radial_Proporciones[Índice];
                                            //Ángulo_Color = Ángulo_Bandera;
                                            SolidBrush Pincel = new SolidBrush(Color_Hexadecimal(Bandera.Matriz_Radial_Colores_Hexadecimales[Índice]));
                                            //SolidBrush Pincel = new SolidBrush(Jupisoft.Obtener_Color_Puro_1530(Rand.Next(0, 1530)));
                                            Pintar.FillPie(Pincel, (float)(-Ancho / 1m), (float)(-Alto / 1m), (float)(Ancho * 2m), (float)(Alto * 2m), (float)Ángulo, (float)Ángulo_Color);
                                            /*if (Índice_Bandera % 2m == 0m)
                                            {
                                                Pintar.FillPie(Pincel, (float)(-Ancho / 2m), (float)(-Alto / 2m), (float)(Ancho * 1m), (float)(Alto * 1m), (float)Ángulo, (float)Ángulo_Color);
                                            }
                                            else
                                            {
                                                Pintar.FillPie(Pincel, (float)-(((Ancho_Alto / 2m) * Índice_Bandera) / Total_Banderas), (float)-(((Ancho_Alto / 2m) * Índice_Bandera) / Total_Banderas), (float)(((Ancho_Alto * Índice_Bandera) / Total_Banderas) * 1m), (float)(((Ancho_Alto * Índice_Bandera) / Total_Banderas) * 1m), (float)Ángulo, (float)Ángulo_Color);
                                            }*/
                                            //[Caracol OK]Pintar.FillPie(Pincel, (float)-(((Ancho_Alto / 2m) * Índice_Bandera) / Total_Banderas), (float)-(((Ancho_Alto / 2m) * Índice_Bandera) / Total_Banderas), (float)(((Ancho_Alto * Índice_Bandera) / Total_Banderas) * 1m), (float)(((Ancho_Alto * Índice_Bandera) / Total_Banderas) * 1m), (float)Ángulo, (float)Ángulo_Color);
                                            //Pintar.FillPie(Pincel, (float)-((Ancho * Índice_Bandera) / Total_Banderas), (float)-((Alto * Índice_Bandera) / Total_Banderas), (float)(((Ancho * Índice_Bandera) / Total_Banderas) * 2m), (float)(((Alto * Índice_Bandera) / Total_Banderas) * 2m), (float)Ángulo, (float)Ángulo_Color);
                                            //Pintar.FillPie(Pincel, (float)-Ancho, (float)-Alto, (float)(Ancho * 2m), (float)(Alto * 2m), (float)Ángulo, (float)Ángulo_Color);
                                            //Pintar.FillPie(Pincel, (float)(-Ancho / 2m), (float)(-Alto / 2m), (float)(Ancho * 1m), (float)(Alto * 1m), (float)(Ángulo + Ángulo_Zona), (float)Ángulo_Color);
                                            Pincel.Dispose();
                                            Pincel = null;
                                            Ángulo += Ángulo_Color;
                                            //Ángulo_Zona += Ángulo_Color;
                                            //break;
                                            /*for (int Índice = 0; Índice < Bandera.Matriz_Operaciones_Base.Length; Índice++, Ángulo += Ángulo_Color)
                                            {
                                                try
                                                {
                                                    SolidBrush Pincel = new SolidBrush(Color_Hexadecimal(Bandera.Matriz_Operaciones_Base[Índice].Matriz_Colores_Hexadecimales[0]));
                                                    Pintar.FillPie(Pincel, (float)-Ancho, (float)-Alto, (float)(Ancho * 2m), (float)(Alto * 2m), (float)Ángulo, (float)Ángulo_Color);
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                }
                                                catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                            }*/

                                        }
                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); Ángulo += Ángulo_Bandera; continue; }
                                    }
                                }
                                else
                                {
                                    for (int Índice = Bandera.Matriz_Radial_Colores_Hexadecimales.Length - 1; Índice >= 0; Índice--)
                                    {
                                        try
                                        {
                                            decimal Ángulo_Color = Ángulo_Bandera * Bandera.Matriz_Radial_Proporciones[Índice];
                                            //Ángulo_Color = Ángulo_Bandera;
                                            SolidBrush Pincel = new SolidBrush(Color_Hexadecimal(Bandera.Matriz_Radial_Colores_Hexadecimales[Índice]));
                                            //SolidBrush Pincel = new SolidBrush(Jupisoft.Obtener_Color_Puro_1530(Rand.Next(0, 1530)));
                                            Pintar.FillPie(Pincel, (float)(-Ancho / 1m), (float)(-Alto / 1m), (float)(Ancho * 2m), (float)(Alto * 2m), (float)Ángulo, (float)Ángulo_Color);
                                            //Pintar.FillPie(Pincel, (float)(-Ancho / 2m), (float)(-Alto / 2m), (float)(Ancho * 1m), (float)(Alto * 1m), (float)Ángulo, (float)Ángulo_Color);
                                            /*if (Índice_Bandera % 2m == 0m)
                                            {
                                                Pintar.FillPie(Pincel, (float)(-Ancho / 2m), (float)(-Alto / 2m), (float)(Ancho * 1m), (float)(Alto * 1m), (float)Ángulo, (float)Ángulo_Color);
                                            }
                                            else
                                            {
                                                Pintar.FillPie(Pincel, (float)-(((Ancho_Alto / 2m) * Índice_Bandera) / Total_Banderas), (float)-(((Ancho_Alto / 2m) * Índice_Bandera) / Total_Banderas), (float)(((Ancho_Alto * Índice_Bandera) / Total_Banderas) * 1m), (float)(((Ancho_Alto * Índice_Bandera) / Total_Banderas) * 1m), (float)Ángulo, (float)Ángulo_Color);
                                            }*/
                                            //[Caracol OK]Pintar.FillPie(Pincel, (float)-(((Ancho_Alto / 2m) * Índice_Bandera) / Total_Banderas), (float)-(((Ancho_Alto / 2m) * Índice_Bandera) / Total_Banderas), (float)(((Ancho_Alto * Índice_Bandera) / Total_Banderas) * 1m), (float)(((Ancho_Alto * Índice_Bandera) / Total_Banderas) * 1m), (float)Ángulo, (float)Ángulo_Color);
                                            //Pintar.FillPie(Pincel, (float)-(((Ancho / 2m) * Índice_Bandera) / Total_Banderas), (float)-(((Alto / 2m) * Índice_Bandera) / Total_Banderas), (float)(((Ancho * Índice_Bandera) / Total_Banderas) * 1m), (float)(((Alto * Índice_Bandera) / Total_Banderas) * 1m), (float)Ángulo, (float)Ángulo_Color);
                                            //Pintar.FillPie(Pincel, (float)-((Ancho * Índice_Bandera) / Total_Banderas), (float)-((Alto * Índice_Bandera) / Total_Banderas), (float)(((Ancho * Índice_Bandera) / Total_Banderas) * 2m), (float)(((Alto * Índice_Bandera) / Total_Banderas) * 2m), (float)Ángulo, (float)Ángulo_Color);
                                            //Pintar.FillPie(Pincel, (float)-Ancho, (float)-Alto, (float)(Ancho * 2m), (float)(Alto * 2m), (float)Ángulo, (float)Ángulo_Color);
                                            //Pintar.FillPie(Pincel, (float)(-Ancho / 2m), (float)(-Alto / 2m), (float)(Ancho * 1m), (float)(Alto * 1m), (float)(Ángulo + Ángulo_Zona), (float)Ángulo_Color);
                                            Pincel.Dispose();
                                            Pincel = null;
                                            Ángulo += Ángulo_Color;
                                            //Ángulo_Zona += Ángulo_Color;
                                            //break;
                                            /*for (int Índice = 0; Índice < Bandera.Matriz_Operaciones_Base.Length; Índice++, Ángulo += Ángulo_Color)
                                            {
                                                try
                                                {
                                                    SolidBrush Pincel = new SolidBrush(Color_Hexadecimal(Bandera.Matriz_Operaciones_Base[Índice].Matriz_Colores_Hexadecimales[0]));
                                                    Pintar.FillPie(Pincel, (float)-Ancho, (float)-Alto, (float)(Ancho * 2m), (float)(Alto * 2m), (float)Ángulo, (float)Ángulo_Color);
                                                    Pincel.Dispose();
                                                    Pincel = null;
                                                }
                                                catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                            }*/

                                        }
                                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); Ángulo += Ángulo_Bandera; continue; }
                                    }
                                }
                                //Índice_Bandera++;
                                //Ángulo += Ángulo_Bandera;
                                //Ángulo += Ángulo_Bandera_Doble;
                            }
                            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                            //finally { Índice_Bandera++; }
                        }
                        Pintar.ResetTransform();
                        Pintar.Dispose();
                        Pintar = null;
                        //Jupisoft.Guardar_Imagen_Temporal(Imagen);
                        return Imagen;
                    }
                }
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        internal Bitmap Dibujar_Ondas(Bitmap Imagen_Original, Flags.Ondas Onda, int Cantidad, int Amplitud, int Fase)
        {
            try
            {
                //return Imagen_Original;
                int Ancho_Original = Imagen_Original.Width;
                int Alto_Original = Imagen_Original.Height;
                int Ancho = (Ancho_Original * 2) + (Amplitud * 4);
                int Alto = (Alto_Original * 2) + (Amplitud * 4);
                Bitmap Imagen = new Bitmap(Ancho, Alto, PixelFormat.Format32bppArgb);
                /*Graphics Pintar = Graphics.FromImage(Imagen);
                Pintar.CompositingMode = CompositingMode.SourceCopy;
                Pintar.CompositingQuality = CompositingQuality.HighQuality;
                Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Pintar.SmoothingMode = SmoothingMode.None;
                Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;
                LinearGradientBrush Pincel = new LinearGradientBrush(new Rectangle(0, (int)Math.Round(((decimal)Alto * Porción_Inicio) / (decimal)Porciones, MidpointRounding.AwayFromZero), Ancho, (int)Math.Round(((decimal)Alto * Porciones_Degradado) / (decimal)Porciones, MidpointRounding.AwayFromZero)), Color_Hexadecimal(Texto_Hexadecimal), Color_Hexadecimal(Texto_Hexadecimal_2), LinearGradientMode.Vertical);
                //Pincel.GammaCorrection = true;
                Pintar.FillRectangle(Pincel, 0, (int)Math.Round(((decimal)Alto * Porción_Inicio) / (decimal)Porciones), Ancho, (int)Math.Round(((decimal)Alto * Porciones_Degradado) / (decimal)Porciones));
                Pincel.Dispose();
                Pincel = null;*/
                BitmapData Bitmap_Data_Original = Imagen_Original.LockBits(new Rectangle(0, 0, Ancho_Original, Alto_Original), ImageLockMode.ReadOnly, Imagen_Original.PixelFormat);
                int Ancho_Stride_Original = Math.Abs(Bitmap_Data_Original.Stride);
                int Bytes_Aumento_Original = !Image.IsAlphaPixelFormat(Imagen_Original.PixelFormat) ? 3 : 4;
                int Bytes_Diferencia_Original = Ancho_Stride_Original - ((Ancho_Original * Image.GetPixelFormatSize(Imagen_Original.PixelFormat)) / 8);
                byte[] Matriz_Bytes_Original = new byte[Ancho_Stride_Original * Alto_Original];
                Marshal.Copy(Bitmap_Data_Original.Scan0, Matriz_Bytes_Original, 0, Matriz_Bytes_Original.Length);
                Imagen_Original.UnlockBits(Bitmap_Data_Original);

                BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadWrite, Imagen.PixelFormat);
                int Ancho_Stride = Math.Abs(Bitmap_Data.Stride);
                int Bytes_Aumento = !Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 3 : 4;
                int Bytes_Diferencia = Ancho_Stride - ((Ancho * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                byte[] Matriz_Bytes = new byte[Ancho_Stride * Alto];
                Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);

                double Radio = Amplitud;
                if (Onda == Flags.Ondas.Horizontal)
                {
                    /*for (int Y = 0, Índice_Original = 0; Y < Alto_Original; Y++, Índice_Original += Bytes_Diferencia_Original)
                    {
                        try
                        {
                            for (int X = 0; X < Ancho_Original; X++, Índice_Original += Bytes_Aumento_Original)
                            {
                                try
                                {
                                    int Y_Seno = (int)Math.Round(Math.Sin((((((double)X * 360d) / (double)Ancho_Original) * (!CheckBox_Invertir_Ondas.Checked ? 1d : -1d)) * Math.PI) / 180d) * Radio, MidpointRounding.AwayFromZero);
                                    int Índice_X = Ancho_Original + X;
                                    int Índice_Y = Alto_Original + Y + Y_Seno;
                                    if (Índice_Y >= 0 && Índice_Y < Alto)
                                    {
                                        int Índice = (Índice_Y * Ancho_Stride) + (Índice_X * Bytes_Aumento);
                                        Matriz_Bytes[Índice + 3] = Matriz_Bytes_Original[Índice_Original + 3];
                                        Matriz_Bytes[Índice + 2] = Matriz_Bytes_Original[Índice_Original + 2];
                                        Matriz_Bytes[Índice + 1] = Matriz_Bytes_Original[Índice_Original + 1];
                                        Matriz_Bytes[Índice] = Matriz_Bytes_Original[Índice_Original];
                                    }
                                }
                                catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                            }
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }*/
                    for (int X = 0, Índice_Original = 0, Índice = 0; X < Ancho_Original; X++)
                    {
                        try
                        {
                            int Y_Seno = (int)Math.Round(Math.Sin(((((((double)X * (360d * (double)Cantidad)) / (double)Ancho_Original) + (double)Fase) * (!CheckBox_Invertir_Ondas.Checked ? 1d : -1d)) * Math.PI) / 180d) * Radio, MidpointRounding.AwayFromZero);
                            for (int Y = 0; Y < Alto_Original; Y++)
                            {
                                try
                                {
                                    //int Y_Seno = (int)Math.Round(Math.Sin((((((double)X * 360d) / (double)Ancho_Original) * (!CheckBox_Invertir_Ondas.Checked ? 1d : -1d)) * Math.PI) / 180d) * Radio, MidpointRounding.AwayFromZero);
                                    //int Índice_X = Ancho_Original + X;
                                    //int Índice_Y = Alto_Original + Y + Y_Seno;
                                    //if (Índice_Y >= 0 && Índice_Y < Alto)
                                    {
                                        Índice = ((Alto_Original + Amplitud + Y + Y_Seno) * Ancho_Stride) + ((Ancho_Original + X) * Bytes_Aumento);
                                        Índice_Original = (Y * Ancho_Stride_Original) + (X * Bytes_Aumento_Original);
                                        /*if (Índice < 0 ||
                                            Índice_Original < 0 ||
                                            Índice + 3 >= Matriz_Bytes.Length ||
                                            Índice_Original + 3 >= Matriz_Bytes_Original.Length)
                                        {
                                            ;
                                        }*/
                                        Matriz_Bytes[Índice + 3] = Matriz_Bytes_Original[Índice_Original + 3];
                                        Matriz_Bytes[Índice + 2] = Matriz_Bytes_Original[Índice_Original + 2];
                                        Matriz_Bytes[Índice + 1] = Matriz_Bytes_Original[Índice_Original + 1];
                                        Matriz_Bytes[Índice] = Matriz_Bytes_Original[Índice_Original];
                                    }
                                }
                                catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                            }
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                }
                else if (Onda == Flags.Ondas.Vertical)
                {
                    /*for (int Y = 0, Índice_Original = 0; Y < Alto_Original; Y++, Índice_Original += Bytes_Diferencia_Original)
                    {
                        try
                        {
                            for (int X = 0; X < Ancho_Original; X++, Índice_Original += Bytes_Aumento_Original)
                            {
                                try
                                {
                                    int X_Coseno = (int)Math.Round(Math.Cos((((((double)Y * 360d) / (double)Alto_Original) - 90d) * Math.PI) / 180d) * Radio, MidpointRounding.AwayFromZero);
                                    int Índice_X = Ancho_Original + X + X_Coseno;
                                    int Índice_Y = Alto_Original + Y;
                                    if (Índice_X >= 0 && Índice_X < Ancho)
                                    {
                                        int Índice = (Índice_Y * Ancho_Stride) + (Índice_X * Bytes_Aumento);
                                        Matriz_Bytes[Índice + 3] = Matriz_Bytes_Original[Índice_Original + 3];
                                        Matriz_Bytes[Índice + 2] = Matriz_Bytes_Original[Índice_Original + 2];
                                        Matriz_Bytes[Índice + 1] = Matriz_Bytes_Original[Índice_Original + 1];
                                        Matriz_Bytes[Índice] = Matriz_Bytes_Original[Índice_Original];
                                    }
                                }
                                catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                            }
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }*/
                    for (int Y = 0, Índice_Original = 0, Índice = 0; Y < Alto_Original; Y++)
                    {
                        try
                        {
                            int X_Coseno = (int)Math.Round(Math.Sin(((((((double)Y * (360d * (double)Cantidad)) / (double)Alto_Original) + (double)Fase) * (!CheckBox_Invertir_Ondas.Checked ? 1d : -1d)) * Math.PI) / 180d) * Radio, MidpointRounding.AwayFromZero);
                            for (int X = 0; X < Ancho_Original; X++)
                            {
                                try
                                {
                                    Índice = ((Alto_Original + Y) * Ancho_Stride) + ((Ancho_Original + Amplitud + X + X_Coseno) * Bytes_Aumento);
                                    Índice_Original = (Y * Ancho_Stride_Original) + (X * Bytes_Aumento_Original);
                                    Matriz_Bytes[Índice + 3] = Matriz_Bytes_Original[Índice_Original + 3];
                                    Matriz_Bytes[Índice + 2] = Matriz_Bytes_Original[Índice_Original + 2];
                                    Matriz_Bytes[Índice + 1] = Matriz_Bytes_Original[Índice_Original + 1];
                                    Matriz_Bytes[Índice] = Matriz_Bytes_Original[Índice_Original];
                                }
                                catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                            }
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                }
                /*else if (Onda == Flags.Ondas.Ambas)
                {
                    /*for (int Y = 0, Índice_Original = 0; Y < Alto_Original; Y++, Índice_Original += Bytes_Diferencia_Original)
                    {
                        try
                        {
                            for (int X = 0; X < Ancho_Original; X++, Índice_Original += Bytes_Aumento_Original)
                            {
                                try
                                {
                                    int X_Coseno = (int)Math.Round(Math.Sin((((((double)Y * 360d) / (double)Alto_Original) * (!CheckBox_Invertir_Ondas.Checked ? 1d : -1d)) * Math.PI) / 180d) * Radio, MidpointRounding.AwayFromZero);
                                    int Y_Seno = (int)Math.Round(Math.Sin((((((double)X * 360d) / (double)Ancho_Original) * (!CheckBox_Invertir_Ondas.Checked ? 1d : -1d)) * Math.PI) / 180d) * Radio, MidpointRounding.AwayFromZero);
                                    //int X_Coseno = (int)Math.Round(Math.Sin((((((double)Y * 360d) / (double)Alto_Original) - 90d) * Math.PI) / 180d) * Radio, MidpointRounding.AwayFromZero);
                                    //int Y_Seno = (int)Math.Round(Math.Cos((((((double)X * 360d) / (double)Ancho_Original) - 90d) * Math.PI) / 180d) * Radio, MidpointRounding.AwayFromZero);
                                    //int X_Coseno = (int)(Math.Cos((((((double)Y * 270d) / (double)Alto_Original) - 180d) * Math.PI) / 180d) * Radio);
                                    //int Y_Seno = (int)(Math.Sin((((((double)X * 270d) / (double)Ancho_Original) - 180d) * Math.PI) / 180d) * Radio);
                                    int Índice_X = Ancho_Original + X + X_Coseno;
                                    int Índice_Y = Alto_Original + Y + Y_Seno;
                                    if (Índice_X >= 0 && Índice_X < Ancho &&
                                        Índice_Y >= 0 && Índice_Y < Alto)
                                    {
                                        int Índice = (Índice_Y * Ancho_Stride) + (Índice_X * Bytes_Aumento);
                                        Matriz_Bytes[Índice + 3] = Matriz_Bytes_Original[Índice_Original + 3];
                                        Matriz_Bytes[Índice + 2] = Matriz_Bytes_Original[Índice_Original + 2];
                                        Matriz_Bytes[Índice + 1] = Matriz_Bytes_Original[Índice_Original + 1];
                                        Matriz_Bytes[Índice] = Matriz_Bytes_Original[Índice_Original];
                                    }
                                }
                                catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                            }
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }*//*
                    int Altura_X = 16; // 24
                    int Altura_Y = 16;
                    int Amplitud_X = 80; // 128
                    int Amplitud_Y = 80;
                    int[] Matriz_Seno_X = new int[Amplitud_X];
                    //if (Filtro != Filtros.Ondas_Seno_Horizontales)
                    {
                        for (int Índice = 0, Subíndice = 0; Índice < Matriz_Seno_X.Length / 4; Índice++, Subíndice++) Matriz_Seno_X[Índice] = (int)Math.Round(Math.Sin(((90d * (Double)Subíndice) / (Double)((Matriz_Seno_X.Length / 4) - 1)) * (Math.PI / 180d)) * ((Double)Altura_X * 1d), MidpointRounding.AwayFromZero);
                        for (int Índice = Matriz_Seno_X.Length / 4, Subíndice = 0; Índice < Matriz_Seno_X.Length / 2; Índice++, Subíndice++) Matriz_Seno_X[Índice] = (int)Math.Round(Math.Sin((((90d * (Double)Subíndice) / (Double)((Matriz_Seno_X.Length / 4) - 1)) + 90d) * (Math.PI / 180d)) * (Double)Altura_X, MidpointRounding.AwayFromZero);
                        for (int Índice = Matriz_Seno_X.Length / 2, Subíndice = 0; Índice < Matriz_Seno_X.Length; Índice++, Subíndice++) Matriz_Seno_X[Índice] = -Matriz_Seno_X[Índice - (Matriz_Seno_X.Length / 2)];
                    }
                    int[] Matriz_Seno_Y = new int[Amplitud_Y];
                    //if (Filtro != Filtros.Ondas_Seno_Verticales)
                    {
                        for (int Índice = 0, Subíndice = 0; Índice < Matriz_Seno_Y.Length / 4; Índice++, Subíndice++) Matriz_Seno_Y[Índice] = (int)-Math.Round(Math.Sin(((90d * (Double)Subíndice) / (Double)((Matriz_Seno_Y.Length / 4) - 1)) * (Math.PI / 180d)) * ((Double)Altura_Y * 1d), MidpointRounding.AwayFromZero);
                        for (int Índice = Matriz_Seno_Y.Length / 4, Subíndice = 0; Índice < Matriz_Seno_Y.Length / 2; Índice++, Subíndice++) Matriz_Seno_Y[Índice] = (int)-Math.Round(Math.Sin((((90d * (Double)Subíndice) / (Double)((Matriz_Seno_Y.Length / 4) - 1)) + 90d) * (Math.PI / 180d)) * (Double)Altura_Y, MidpointRounding.AwayFromZero);
                        for (int Índice = Matriz_Seno_Y.Length / 2, Subíndice = 0; Índice < Matriz_Seno_Y.Length; Índice++, Subíndice++) Matriz_Seno_Y[Índice] = -Matriz_Seno_Y[Índice - (Matriz_Seno_Y.Length / 2)];
                    }
                    for (int Y = 0, Índice_Original = 0, Índice = 0; Y < Alto_Original; Y++)
                    {
                        try
                        {
                            for (int X = 0; X < Ancho_Original; X++)
                            {
                                try
                                {
                                    int Onda_X = Ancho_Original + X + Matriz_Seno_X[(Alto_Original + Y) % Matriz_Seno_X.Length]; //((Índice_Externo_Onda_X + (Matriz_Seno_X[((Rectángulo.Height + Índice_Y) % Matriz_Seno_X.Length)])) & Ancho) + Índice_X;
                                    int Onda_Y = Alto_Original + Y + Matriz_Seno_Y[(Ancho_Original + X) % Matriz_Seno_Y.Length]; //((Índice_Externo_Onda_Y + (Matriz_Seno_Y[((Rectángulo.Width + Índice_X) % Matriz_Seno_Y.Length)])) & Alto) + Índice_Y;
                                    /*if (Onda_X < 0) Onda_X += Ancho;
                                    else if (Onda_X >= Ancho) Onda_X -= Ancho;
                                    if (Onda_Y < 0) Onda_Y += Alto;
                                    else if (Onda_Y >= Alto) Onda_Y -= Alto;*//*
                                    int Subíndice = (((Ancho) * Onda_Y) + Onda_X) * 4;

                                    //int X_Coseno = (int)Math.Round(Math.Cos((((((double)Y * 360d) / (double)Alto_Original) * (!CheckBox_Invertir_Ondas.Checked ? 1d : -1d)) * Math.PI) / 180d) * Radio, MidpointRounding.AwayFromZero);
                                    //int Y_Seno = (int)Math.Round(Math.Sin((((((double)X * 360d) / (double)Ancho_Original) * (!CheckBox_Invertir_Ondas.Checked ? 1d : -1d)) * Math.PI) / 180d) * Radio, MidpointRounding.AwayFromZero);
                                    Índice_Original = (Y * Ancho_Stride_Original) + (X * Bytes_Aumento_Original);
                                    //Índice = ((Alto_Original + Y + Y_Seno) * Ancho_Stride) + ((Ancho_Original + X + X_Coseno) * Bytes_Aumento);
                                    Matriz_Bytes[Subíndice + 3] = Matriz_Bytes_Original[Índice_Original + 3];
                                    Matriz_Bytes[Subíndice + 2] = Matriz_Bytes_Original[Índice_Original + 2];
                                    Matriz_Bytes[Subíndice + 1] = Matriz_Bytes_Original[Índice_Original + 1];
                                    Matriz_Bytes[Subíndice] = Matriz_Bytes_Original[Índice_Original];
                                }
                                catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                            }
                        }
                        catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                }*/
                Marshal.Copy(Matriz_Bytes, 0, Bitmap_Data.Scan0, Matriz_Bytes.Length);
                Imagen.UnlockBits(Bitmap_Data);
                Matriz_Bytes = null;
                Matriz_Bytes_Original = null;
                Rectangle Rectángulo = Jupisoft.Buscar_Zona_Recorte_Imagen(Imagen, Color.Transparent);
                if (Rectángulo.X > -1 && Rectángulo.Y > -1 && Rectángulo.X < int.MaxValue && Rectángulo.Y < int.MaxValue && Rectángulo.Width > 0 && Rectángulo.Height > 0)
                {
                    return Imagen.Clone(Rectángulo, PixelFormat.Format32bppArgb);
                }
                return Imagen;
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        internal void Actualizar_Bandera()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (ComboBox_Bandera.SelectedIndex > -1)
                {
                    Flags.Diseños Diseño = (Flags.Diseños)ComboBox_Bandera.SelectedIndex;
                    PictureBox_Bandera.Image = Dibujar_Bandera(Diseño, PictureBox_Bandera.ClientSize.Width, PictureBox_Bandera.ClientSize.Height, CheckBox_Rayas.Checked, CheckBox_Figuras.Checked, CheckBox_Iconos.Checked, CheckBox_Suavizado.Checked, CheckBox_Rotar_90.Checked, (Flags.Ondas)ComboBox_Ondas.SelectedIndex, NumericUpDown_Cantidad.Value, NumericUpDown_Amplitud.Value, NumericUpDown_Fase.Value, CheckBox_Invertir_Ondas.Checked, CheckBox_Radial.CheckState, false);
                    TextBox_Descripción.Text = Flags.Diccionario[Diseño].Descripción/* + "\r\n"*/;
                    Barra_Estado_Etiqueta_Divisiones.Text = "Divisions: " + (Flags.Diccionario[Diseño].Divisiones > 0 ? Jupisoft.Traducir_Número(Flags.Diccionario[Diseño].Divisiones) : "?");
                    Barra_Estado_Etiqueta_Barras.Text = "Stripes: " + (Flags.Diccionario[Diseño].Matriz_Radial_Colores_Hexadecimales.Length > 0 ? Jupisoft.Traducir_Número(Flags.Diccionario[Diseño].Matriz_Radial_Colores_Hexadecimales.Length) : "?");
                    Barra_Estado_Etiqueta_Partes.Text = "Parts: " + (Flags.Diccionario[Diseño].Matriz_Operaciones_Rayas.Length + Flags.Diccionario[Diseño].Matriz_Operaciones_Extra.Length > 0 ? Jupisoft.Traducir_Número(Flags.Diccionario[Diseño].Matriz_Operaciones_Rayas.Length + Flags.Diccionario[Diseño].Matriz_Operaciones_Extra.Length) : "?");
                }
                else
                {
                    PictureBox_Bandera.Image = null;
                    TextBox_Descripción.Text = null;
                    Barra_Estado_Etiqueta_Divisiones.Text = "Divisions: ?";
                    Barra_Estado_Etiqueta_Barras.Text = "Stripes: ?";
                    Barra_Estado_Etiqueta_Partes.Text = "Parts: ?";
                }
                PictureBox_Bandera.Refresh();
                TextBox_Descripción.Refresh();
                Barra_Estado.Refresh();
                Point Posición = PictureBox_Bandera.PointToClient(Control.MousePosition);
                PictureBox_Bandera_MouseMove(null, new MouseEventArgs(MouseButtons.None, 0, Posición.X, Posición.Y, 0));
            }
            catch (Exception Excepción) { Agregar_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }
    }
}
