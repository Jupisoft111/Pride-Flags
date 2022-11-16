using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Pride_Flags.Flags;
using static Pride_Flags.Form_Main;

namespace Pride_Flags
{
    internal static class Flags
    {
        internal enum Diseños : int
        {
            A_spec,
            A_spec_aloe_vera,
            Abinary,
            Abinary_2,
            Abinary_3,
            Abinary_4,
            Abinary_5,
            Abnosexual,
            Abromantic,
            Abromantic_2,
            Abroromantic,
            Abrosexual,
            Acefluid,
            Acefluid_2,
            Acefluid_3,
            Aceflux,
            Achillean,
            Aegoromantic,
            Aegoromantic_2,
            Aegoromantic_3,
            Aegoromantic_4,
            Aegoromantic_5,
            Aegoromantic_6,
            Aegosexual,
            Aemotional,
            Aflux,
            Aflux_2,
            Agender___2014__,
            Agender_2,
            Agender_3,
            Agenderflux,
            Aingender,
            Aliusaromantic,
            Aliusdemiromantic,
            Allosexual,
            Altersex,
            Ambiamorous,
            Androgyne,
            Androgyne_2,
            Androgyne_3,
            Androgyne_4,
            Androgyne_5,
            Androgyne_6,
            Androgyne_7,
            Androromantic,
            Androsexual,
            Anovelaean,
            Antiromantic,
            Aplaroace,
            Aporagender,
            Aporine,
            Aporine_2,
            Apothiromantic,
            Apothiromantic_2,
            Apothisexual,
            Apresromantic,
            Aroace,
            Aroace_2,
            Aroaceflux,
            Aroaceflux_2,
            Aroaceflux_3,
            Aroaceflux_4,
            Aroaceflux_5,
            Aroflux,
            Aromantic___2014__,
            Aromantic_2,
            Aromantic_3,
            Aromantic_spectrum,
            Asexual___2010__,
            Asexual_2,
            Asexual_spectrum,
            Assigned_intersex_at_birth,
            Assigned_male_at_birth,
            Assigned_male_at_birth_2,
            Assigned_male_at_birth_3,
            Assigned_male_at_birth_4,
            Assigned_male_at_birth_5,
            Assigned_male_at_birth_6,
            Assigned_male_at_birth_7,
            Assigned_x_at_birth,
            Assigned_x_at_birth_2,
            Assigned_x_at_birth_3,
            Autoromantic,
            Autosexual,
            Avansexuality,
            Bambi_lesbian,
            Bambi_lesbian_2,
            BDSM_rights,
            Bear_brotherhood,
            Bicurious,
            Bigender,
            Bigender_2,
            Binary_to_non_binary,
            Bisexual___1998__,
            Black_trans,
            Boreasexual,
            Boyflux,
            Carnelian,
            Ceteroromantic,
            Ceterosexual,
            Cinthean,
            Cisgender,
            Cisgender_2,
            Cisgender_3,
            Cisgender_4,
            Cisgender_5,
            Cisgender_6,
            Cis_men,
            Cis_women,
            Cupioromantic,
            Demiboy,
            Demidiamoric,
            Demifluid,
            Demiflux,
            Demigender,
            Demigirl,
            Demiromantic,
            Demisexual,
            Desinoromantic,
            Diamoric,
            Disability,
            Disability_2,
            //Drapeau_cochin,
            Egogender,
            Enbitor,
            Enbitor_2,
            Enbitor_3,
            Fa_afafine,
            Female,
            Feminine,
            Femme,
            Femsexual,
            Femsexual_2,
            Femsexual_3,
            Fingender,
            Finsexual,
            Floric,
            Fluidflux,
            Frayromantic,
            Fraysexual,
            G0y,
            Gardenia,
            Gardeniaro,
            Gardeniasexual,
            Gardeniaaroace,
            Gay___1979__,
            Gay_7_stripes,
            Gay_8_stripes,
            //Gay_Gilbert_Baker___1978__,
            Gay_8_stripes_Philadelphia,
            //Gay_Philadelphia___2017__,
            Gay_9_stripes___2017__,
            Gay_9_stripes_diversity,
            Gay_Israel,
            Gay_man,
            Gay_man_2,
            Gay_man_3,
            Gay_man_4,
            Gay_man_5,
            Gayan,
            Gender_neutral,
            Gender_non_conforming,
            Genderfae,
            Genderfaun,
            Genderflor,
            Genderfluff,
            Genderfluid___2012__,
            Genderfluid_2,
            Genderflux,
            Genderfuck,
            Genderless,
            Genderless_2,
            Genderpunk,
            Genderqueer___2011__,
            Girlflux,
            Gray_aromantic,
            Greygender,
            Greysexual,
            Gyneromantic,
            Gyneromantic_2,
            Gynesexual,
            Hermaphrodite,
            Heteroflexible,
            Heteroqueer,
            Heterosexual,
            Heterosexual_2,
            Heterosexual_3,
            Hijra,
            Homoflexible,
            Iculasexual,
            Intergender,
            Intergender_2,
            Intergender_3,
            Intersex___2013__,
            Intersex_2,
            Ipsogender,
            Juvelic_orientations,
            Kathoey,
            Khanith,
            Lapisian,
            Leather_latex_and_BDSM,
            Leather_latex_and_BDSM___light__,
            Lesbian___2018__,
            Lesbian___2019__,
            Lesbian_Lydia_Maya_Kern,
            Lesbian_Lydia_original,
            Lesbian_butch,
            Lesbian_butch_2,
            Lesbian_labrys___1999__,
            Lesbian_lipstick___2010__,
            Lesbian_pink___2010__,
            Lesbian_Pride_double_venus_canton_rainbow,
            Lingender,
            Lithromantic,
            Mahu,
            Maverique,
            Men_loving_men___Mlm__,
            Men_loving_men___Mlm2__,
            Men_loving_men___Mlm3__,
            Men_loving_men_5_stripes___Mlm__,
            Mingender,
            MOGAI,
            Monosexual,
            Multigender,
            Multigender_2,
            Multisexual,
            Mutosexual,
            Muxe,
            Neptunic,
            Neurogender,
            Neutrois,
            Niaspec,
            Noetiromantic,
            Noetiromantic_2,
            Non_monogamy,
            Nonbinary___2014__,
            Nonbinary_2,
            Nonbinary_3,
            Nonbinary_4,
            Nonbinary_5,
            Nonbinary_6,
            Nonbinary_7,
            Nonbinary_8,
            Nonbinary_9,
            Nonbinary_10,
            Nonbinary_11,
            Nonbinary_12,
            Nonbinary_13,
            Nonbinary_boy,
            Nonbinary_girl,
            Nudism,
            Omniromantic,
            Omnisexual,
            Pangender,
            Panromantic,
            Panromantic_Demisexual,
            Pansexual___2010__,
            Pink_Union_Jack___2009__,
            Polyamory,
            Polyamory_infinity_heart,
            Polygender,
            Polygender_2,
            Polygender_3,
            Polygender_4,
            Polygender_5,
            Polyromantic,
            Polyromantic_2,
            Polysexual___2012__,
            Pomosexual,
            Queer,
            Queer_chevron,
            Queerhet,
            Questioning,
            Quoiromantic,
            Recipromantic,
            Rubber_fetish,
            Sapphic,
            Saturnic,
            Saturnic_2,
            Saturnic_3,
            Saturnic_4,
            Saturnic_5,
            Saturnic_6,
            Saturnic_7,
            Saturnic_8,
            Saturnic_9,
            Saturnic_10,
            Semibisexual,
            Semibisexual_2,
            Straight_ally,
            Super_straight,
            Torensexual,
            Torensexual_2,
            Torensexual_3,
            Toric,
            Trans_loving_trans,
            Trans_loving_trans_2,
            Trans_loving_trans_3,
            Trans_loving_trans_4,
            Trans_loving_trans_5,
            Trans_loving_trans_6,
            Transfeminism_MTF,
            Transfeminism_MTF_2,
            Transfeminism_MTF_3,
            Transfeminism_MTF_4,
            Transfeminism_MTF_5,
            Transgender___1999__,
            Transgender_Israeli,
            Transgender_Jennifer_Pellinen,
            Transgender_Johnathan_Andrew___1999__,
            Transgender_Michelle_Lindsay___2010__,
            Transneutral,
            Transmasculine_FTM,
            Travesti,
            Travesti_2,
            Travesti_3,
            Trigender,
            Trisexual,
            Trisexual_2,
            Trixic,
            Tumtum,
            Turian,
            Twink,
            Two_Spirit,
            Unlabeled,
            Uranic,
            Vincian,
            Virescin,
            Waria,
            Woman,
            Woman_related,
            X_gender,
            Xenic,
            Xenic_2,
            Xenogender,
            Xenogender_2,
            Xyric,
            Zygosexual


            /*Abrosexual,
            Aceflux,
            Ambiamorous,
            Androgynous,
            Aroace,
            //Aroflux,
            Demifluid,
            Demiromantic,
            Demisexual,
            //Gay/MLM/Vinician,
            Vinician,
            //Genderflux,
            Graysexual,
            Polyamorous,
            Progress_Pride,
            Queer,
            Unlabeled,
            //LGBTQIA+,*/

            /*Z1,
            Z2,
            Z3,
            Z4,
            Z5,
            Z6,
            Z7,
            Z8,
            Z9,
            Z10,
            Z11,
            Z12,
            Z13,
            Z14,
            Z15*/
        }

        internal enum Funciones : int
        {
            Rectángulo,
            Círculo,
            Ángulo,
            Polígono,
            Rectángulo_Degradado,
            Círculo_Degradado,
            Polígono_Degradado,
            Polígono_Degradado_Simple,
            Imagen,
            Imagen_Recorte
        }

        internal enum Dibujos : int
        {
            Rayas,
            Figuras,
            Iconos
        }

        /// <summary>
        /// Structure that holds up all the information about a part of a flag, like the color and position of a stripe.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Operaciones
        {
            internal Dibujos Dibujo;
            internal Funciones Función;
            internal string[] Matriz_Colores_Hexadecimales;
            internal decimal[] Matriz_Proporciones;
            internal LinearGradientMode Degradado;
            internal string Ruta;

            internal Operaciones(Dibujos Dibujo, Funciones Función, string[] Matriz_Colores_Hexadecimales, decimal[] Matriz_Proporciones)
            {
                this.Dibujo = Dibujo;
                this.Función = Función;
                this.Matriz_Colores_Hexadecimales = Matriz_Colores_Hexadecimales;
                this.Matriz_Proporciones = Matriz_Proporciones;
                this.Degradado = LinearGradientMode.Vertical;
                this.Ruta = null;
            }

            internal Operaciones(Dibujos Dibujo, Funciones Función, string[] Matriz_Colores_Hexadecimales, decimal[] Matriz_Proporciones, LinearGradientMode Degradado)
            {
                this.Dibujo = Dibujo;
                this.Función = Función;
                this.Matriz_Colores_Hexadecimales = Matriz_Colores_Hexadecimales;
                this.Matriz_Proporciones = Matriz_Proporciones;
                this.Degradado = Degradado;
                this.Ruta = null;
            }

            internal Operaciones(Dibujos Dibujo, Funciones Función, string[] Matriz_Colores_Hexadecimales, decimal[] Matriz_Proporciones, string Ruta)
            {
                this.Dibujo = Dibujo;
                this.Función = Función;
                this.Matriz_Colores_Hexadecimales = Matriz_Colores_Hexadecimales;
                this.Matriz_Proporciones = Matriz_Proporciones;
                this.Degradado = LinearGradientMode.Vertical;
                this.Ruta = Ruta;
            }

            internal static Operaciones[] Empty()
            {
                return new Operaciones[] { };
            }

            internal static Operaciones[] Rectángulos_Horizontales(string[] Matriz_Colores_Hexadecimales)
            {
                try
                {
                    if (Matriz_Colores_Hexadecimales != null && Matriz_Colores_Hexadecimales.Length > 0)
                    {
                        Operaciones[] Matriz_Operaciones = new Operaciones[Matriz_Colores_Hexadecimales.Length];
                        for (int Índice = 0; Índice < Matriz_Colores_Hexadecimales.Length; Índice++)
                        {
                            try
                            {
                                Matriz_Operaciones[Índice] = new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { Matriz_Colores_Hexadecimales[Índice] }, new decimal[] { 0m, (decimal)Índice / (decimal)Matriz_Colores_Hexadecimales.Length, 1m, ((decimal)Índice + 1m) / (decimal)Matriz_Colores_Hexadecimales.Length });
                            }
                            catch (Exception Excepción) { Debugger.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                        }
                        return Matriz_Operaciones;
                    }
                }
                catch (Exception Excepción) { Debugger.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
                return new Operaciones[] { };
            }

            internal static Operaciones[] Rectángulos_Verticales(string[] Matriz_Colores_Hexadecimales)
            {
                try
                {
                    if (Matriz_Colores_Hexadecimales != null && Matriz_Colores_Hexadecimales.Length > 0)
                    {
                        Operaciones[] Matriz_Operaciones = new Operaciones[Matriz_Colores_Hexadecimales.Length];
                        for (int Índice = 0; Índice < Matriz_Colores_Hexadecimales.Length; Índice++)
                        {
                            try
                            {
                                Matriz_Operaciones[Índice] = new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { Matriz_Colores_Hexadecimales[Índice] }, new decimal[] { (decimal)Índice / (decimal)Matriz_Colores_Hexadecimales.Length, 0m, ((decimal)Índice + 1m) / (decimal)Matriz_Colores_Hexadecimales.Length, 1m });
                            }
                            catch (Exception Excepción) { Debugger.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                        }
                        return Matriz_Operaciones;
                    }
                }
                catch (Exception Excepción) { Debugger.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
                return new Operaciones[] { };
            }
        }

        /// <summary>
        /// Structure that holds up all the information about a pride flag and the needed information to draw it.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Banderas
        {
            /// <summary>
            /// The design of a flag.
            /// </summary>
            internal Diseños Diseño;
            /// <summary>
            /// The detailed name of a flag.
            /// </summary>
            internal string Nombre;
            /// <summary>
            /// The stripes division of a flag.
            /// </summary>
            internal int Divisiones;
            /// <summary>
            /// The full description and history of a flag.
            /// </summary>
            internal string Descripción;
            /// <summary>
            /// Array with all the operations needed to generate the basic stripes of a flag.
            /// </summary>
            internal Operaciones[] Matriz_Operaciones_Rayas;
            /// <summary>
            /// Array with all the operations needed to generate the extra shapes of a flag, found over the base stripes.
            /// </summary>
            internal Operaciones[] Matriz_Operaciones_Extra;
            /// <summary>
            /// Variable to determine if a flag is valid for a radial rendering. Mostly used to ignore duplicated or a few very complex flags. TODO: Calculate in real time using a list.
            /// </summary>
            internal bool Radial;
            internal string[] Matriz_Radial_Colores_Hexadecimales;
            internal decimal[] Matriz_Radial_Proporciones;

            /*internal Banderas(string Nombre, string Descripción, Operaciones[] Matriz_Operaciones_Rayas, Operaciones[] Matriz_Operaciones_Extra)
            {
                this.Nombre = Nombre;
                this.Descripción = Descripción;
                this.Matriz_Operaciones_Rayas = Matriz_Operaciones_Rayas;
                this.Matriz_Operaciones_Extra = Matriz_Operaciones_Extra;
                this.Radial = false;
                this.Matriz_Radial_Colores_Hexadecimales = new string[0];
                this.Matriz_Radial_Proporciones = new decimal[0];
            }*/

            internal Banderas(Diseños Diseño, string Nombre, int Divisiones, Operaciones[] Matriz_Operaciones_Rayas, Operaciones[] Matriz_Operaciones_Extra, bool Radial, string[] Matriz_Radial_Colores_Hexadecimales, decimal[] Matriz_Radial_Proporciones)
            {
                this.Diseño = Diseño;
                this.Nombre = Nombre;
                this.Divisiones = Divisiones;
                this.Descripción = Flag_Descriptions.Obtener_Descripción_Bandera(Diseño);
                this.Matriz_Operaciones_Rayas = Matriz_Operaciones_Rayas;
                this.Matriz_Operaciones_Extra = Matriz_Operaciones_Extra;
                if (Radial)
                {
                    if (Matriz_Radial_Colores_Hexadecimales != null && Matriz_Radial_Colores_Hexadecimales.Length > 0)
                    {
                        if (Matriz_Radial_Proporciones == null || Matriz_Radial_Proporciones.Length <= 0)
                        {
                            Matriz_Radial_Proporciones = new decimal[Matriz_Radial_Colores_Hexadecimales.Length];
                            decimal Valor = 1m / (decimal)Matriz_Radial_Colores_Hexadecimales.Length;
                            for (int Índice = 0; Índice < Matriz_Radial_Colores_Hexadecimales.Length; Índice++)
                            {
                                try
                                {
                                    Matriz_Radial_Proporciones[Índice] = Valor;
                                }
                                catch (Exception Excepción) { Debugger.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                            }
                        }
                        else if (Jupisoft.Usuario_Jupisoft) // Try to find possible mistakes in the flag generation code.
                        {
                            decimal Total = 0m;
                            foreach (decimal Valor in Matriz_Radial_Proporciones)
                            {
                                Total += Valor;
                            }
                            if (Total < 0.99m || Total > 1.01m)
                            {
                                Radial = false; // Disable the flag in radial mode.
                                Matriz_Radial_Colores_Hexadecimales = new string[0];
                                Matriz_Radial_Proporciones = new decimal[0];
                                MessageBox.Show(Nombre, Total.ToString());
                            }
                        }
                    }
                    else // Disable the flag in radial mode.
                    {
                        Radial = false;
                        Matriz_Radial_Colores_Hexadecimales = new string[0];
                        Matriz_Radial_Proporciones = new decimal[0];
                    }
                }
                else // Disable the flag in radial mode.
                {
                    Matriz_Radial_Colores_Hexadecimales = new string[0];
                    Matriz_Radial_Proporciones = new decimal[0];
                }
                this.Radial = Radial;
                this.Matriz_Radial_Colores_Hexadecimales = Matriz_Radial_Colores_Hexadecimales;
                this.Matriz_Radial_Proporciones = Matriz_Radial_Proporciones;
            }
        }

        /// <summary>
        /// Dictionary with all the known pride flags.
        /// </summary>
        internal static readonly SortedDictionary<Diseños, Banderas> Diccionario = new SortedDictionary<Diseños, Banderas>
        {
            {
                Diseños.A_spec, new Banderas(Diseños.A_spec, "A-spec (aromantic and asexual spectrum)", 4,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 0m, 1m / 2m, 1m / 2m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "3CA542" }, new decimal[4] { 0.5m, 0m, 1m / 2m, 1m / 2m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "820080" }, new decimal[4] { 0m, 0.5m, 1m / 2m, 1m / 2m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "999999" }, new decimal[4] { 0.5m, 0.5m, 1m / 2m, 1m / 2m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "FFFFFF" }, new decimal[] // White star.
                    {
                        1m / 4m, 0.5m, // Left.
                        0.5m - 0.05m, 0.5m - (0.05m * (5m / 3m)),
                        0.5m, 0.5m - ((1m / 4m) * (5m / 3m)), // Top.
                        0.5m + 0.05m, 0.5m - (0.05m * (5m / 3m)),
                        3m / 4m, 0.5m, // Right.
                        0.5m + 0.05m, 0.5m + (0.05m * (5m / 3m)),
                        0.5m, 0.5m + ((1m / 4m) * (5m / 3m)), // Bottom.
                        0.5m - 0.05m, 0.5m + (0.05m * (5m / 3m)),
                        1m / 4m, 0.5m, // Left.
                    }),
                },
                Operaciones.Empty(), true,
                new string[] { "000000", "3CA542", "FFFFFF", "820080", "999999" }, null)
            },
            {
                Diseños.A_spec_aloe_vera, new Banderas(Diseños.A_spec_aloe_vera, "A-spec aloe vera (aromantic and asexual spectrum)", 3,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "329932" }, new decimal[4] { 0m, 0m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F5F5F5" }, new decimal[4] { 0m, 1m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "7F007F" }, new decimal[4] { 0m, 2m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "6B954C" }, new decimal[4] { 277m / 833m, 171m / 500m, 265m / 833m, 156m / 500m }, "A_spec_aloe_vera.png"),
                },
                //Operaciones.Rectángulos_Horizontales(new string[] { "329932", "F5F5F5", "7F007F" }),
                Operaciones.Empty(), true,
                new string[] { "329932", "F5F5F5", "7F007F" }, null)
            },
            {
                Diseños.Abinary, new Banderas(Diseños.Abinary, "Abinary", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FEDF0A", "FDF9A2", "FFFFFF", "FDF9A2", "FEDF0A" }), Operaciones.Empty(), true,
                new string[] { "FEDF0A", "FDF9A2", "FFFFFF", "FDF9A2", "FEDF0A" }, null)
            },
            {
                Diseños.Abinary_2, new Banderas(Diseños.Abinary_2, "Abinary #2", 11,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFC700", "FFCF47", "FFDF4A", "FFF280", "F4F6AF", "FFFFFF", "F4F6AF", "FFF280", "FFDF4A", "FFCF47", "FFC700" }), Operaciones.Empty(), true,
                new string[] { "FFC700", "FFCF47", "FFDF4A", "FFF280", "F4F6AF", "FFFFFF", "F4F6AF", "FFF280", "FFDF4A", "FFCF47", "FFC700" }, null)
            },
            {
                Diseños.Abinary_3, new Banderas(Diseños.Abinary_3, "Abinary #3", 9,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "BDBDBD", "FFFFFF", "FFFD8E", "F8FF0E", "FFFD8E", "FFFFFF", "BDBDBD", "000000" }), Operaciones.Empty(), true,
                new string[] { "000000", "BDBDBD", "FFFFFF", "FFFD8E", "F8FF0E", "FFFD8E", "FFFFFF", "BDBDBD", "000000" }, null)
            },
            {
                Diseños.Abinary_4, new Banderas(Diseños.Abinary_4, "Abinary #4", 5,
                Operaciones.Rectángulos_Verticales(new string[] { "733434", "C78D6E", "FFF8F8", "C4C0C7", "392F48" }), Operaciones.Empty(), true,
                new string[] { "733434", "C78D6E", "FFF8F8", "C4C0C7", "392F48" }, null)
            },
            {
                Diseños.Abinary_5, new Banderas(Diseños.Abinary_5, "Abinary #5", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "BF4A21", "C7663A", "E09C61", "B28342", "89592F" }), Operaciones.Empty(), true,
                new string[] { "BF4A21", "C7663A", "E09C61", "B28342", "89592F" }, null)
            },
            {
                Diseños.Abnosexual, new Banderas(Diseños.Abnosexual, "Abnosexual", 6,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 0m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "62DFBC" }, new decimal[4] { 0m, 1m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "7A73D9" }, new decimal[4] { 0m, 2m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "9E9E9E" }, new decimal[4] { 0m, 3m / 6m, 1m, 2m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 5m / 6m, 1m, 1m / 6m }),
                },
                Operaciones.Empty(), true,
                new string[] { "FFFFFF", "62DFBC", "7A73D9", "9E9E9E", "FFFFFF" },
                new decimal[]{ 1m / 6m, 1m / 6m, 1m / 6m, 2m / 6m, 1m / 6m })
            },
            {
                Diseños.Abromantic, new Banderas(Diseños.Abromantic, "Abromantic", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "75CA91", "B4E4CA", "D4F9CD", "E695B6", "DB426E" }), Operaciones.Empty(), true,
                new string[] { "75CA91", "B4E4CA", "D4F9CD", "E695B6", "DB426E" }, null)
            },
            {
                Diseños.Abromantic_2, new Banderas(Diseños.Abromantic_2, "Abromantic #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "01301F", "03492F", "FFFFFF", "F29FAA", "E23236" }), Operaciones.Empty(), false,
                new string[] { "01301F", "03492F", "FFFFFF", "F29FAA", "E23236" }, null)
            },
            {
                Diseños.Abroromantic, new Banderas(Diseños.Abroromantic, "Abroromantic", 5,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "BAE5C9" }, new decimal[4] { 0m, 0m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "DBF1E5" }, new decimal[4] { 0m, 1m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FCFBFC" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F4CADD" }, new decimal[4] { 0m, 3m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "ECA2B6" }, new decimal[4] { 0m, 4m / 5m, 1m, 1m / 5m }),
                },
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "75CA92" }, new decimal[4] { 0m, 0m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "B4E4C9" }, new decimal[4] { 0m, 1m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "F7F7F7" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "E795B5" }, new decimal[4] { 0m, 3m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "DA446E" }, new decimal[4] { 0m, 4m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen_Recorte, new string[] { "FFFFFF" }, new decimal[] { 861m / 5000m, 0m / 3000m, 3277m / 5000m, 3000m / 3000m }, "Heart.png"),
                },
                true,
                new string[] { "BAE5C9", "DBF1E5", "FCFBFC", "F4CADD", "ECA2B6" }, null)
            },
            {
                Diseños.Abrosexual, new Banderas(Diseños.Abrosexual, "Abrosexual", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "65C286", "B4E4CC", "FFFFFF", "E796B7", "D9446E" }), Operaciones.Empty(), true,
                new string[] { "65C286", "B4E4CC", "FFFFFF", "E796B7", "D9446E" }, null)
            },
            {
                Diseños.Acefluid, new Banderas(Diseños.Acefluid, "Acefluid", 9,
                Operaciones.Rectángulos_Horizontales(new string[] { "3DA642", "A8D379", "FFFFFF", "A9A9A9", "000000", "A9A9A9", "FFFFFF", "D07FFF", "81007F" }), Operaciones.Empty(), true,
                new string[] { "3DA642", "A8D379", "FFFFFF", "A9A9A9", "000000", "A9A9A9", "FFFFFF", "D07FFF", "81007F" }, null)
            },
            {
                Diseños.Acefluid_2, new Banderas(Diseños.Acefluid_2, "Acefluid #2", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "154715", "3CA542", "A8D377", "FFFFFF", "DA92B4", "7657AE", "151847" }), Operaciones.Empty(), false,
                new string[] { "154715", "3CA542", "A8D377", "FFFFFF", "DA92B4", "7657AE", "151847" }, null)
            },
            {
                Diseños.Acefluid_3, new Banderas(Diseños.Acefluid_3, "Acefluid #3", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "A980D0", "8252A2", "333333", "DA92B4", "FFECED" }), Operaciones.Empty(), false,
                new string[] { "A980D0", "8252A2", "333333", "DA92B4", "FFECED" }, null)
            },
            {
                Diseños.Aceflux, new Banderas(Diseños.Aceflux, "Aceflux", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "C82067", "EC6D87", "F9D1E1", "91479B", "800080" }), Operaciones.Empty(), true,
                new string[] { "C82067", "EC6D87", "F9D1E1", "91479B", "800080" }, null)
            },
            {
                Diseños.Achillean, new Banderas(Diseños.Achillean, "Achillean", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "99C6EA", "F9FDEA", "99C6EA" }), Operaciones.Empty(), true,
                new string[] { "99C6EA", "F9FDEA", "99C6EA" }, null)
            },
            {
                Diseños.Aegoromantic, new Banderas(Diseños.Aegoromantic, "Aegoromantic", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "087D16", "FFFFFF", "959595", "000000" }),
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 0m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "959595" }, new decimal[4] { 0m, 1m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 2m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "087D16" }, new decimal[4] { 0m, 3m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "00000000" }, new decimal[] { 0m, 0m, 0.5m, 1m, 1m, 0m, 0m, 0m }),
                },
                true,
                new string[] { "000000", "959595", "FFFFFF", "087D16" }, null)
            },
            {
                Diseños.Aegoromantic_2, new Banderas(Diseños.Aegoromantic_2, "Aegoromantic #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "A9A9A9", "DFE150", "A8D242", "3DA542" }),
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "3DA542" }, new decimal[4] { 0m, 0m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A8D242" }, new decimal[4] { 0m, 1m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFC77" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A9A9A9" }, new decimal[4] { 0m, 3m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 4m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "00000000" }, new decimal[] { 0m, 0m, 0.5m, 1m, 1m, 0m, 0m, 0m }),
                },
                false,
                new string[] { "3DA542", "A8D242", "FFFC77", "A9A9A9", "000000" }, null)
            },
            {
                Diseños.Aegoromantic_3, new Banderas(Diseños.Aegoromantic_3, "Aegoromantic #3", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "7CBD00", "FFF300", "FF7000", "000000" }),
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 0m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FF7000" }, new decimal[4] { 0m, 1m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFF300" }, new decimal[4] { 0m, 2m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "7CBD00" }, new decimal[4] { 0m, 3m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "00000000" }, new decimal[] { 0m, 0m, 0.5m, 1m, 1m, 0m, 0m, 0m }),
                },
                false,
                new string[] { "000000", "FF7000", "FFF300", "7CBD00" }, null)
            },
            {
                Diseños.Aegoromantic_4, new Banderas(Diseños.Aegoromantic_4, "Aegoromantic #4", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "00B159", "F5F99A", "B8CDBA", "000000" }),
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 0m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "B8CDBA" }, new decimal[4] { 0m, 1m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F5F99A" }, new decimal[4] { 0m, 2m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "00B159" }, new decimal[4] { 0m, 3m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "00000000" }, new decimal[] { 0m, 0m, 0.5m, 1m, 1m, 0m, 0m, 0m }),
                },
                false,
                new string[] { "000000", "B8CDBA", "F5F99A", "00B159" }, null)
            },
            {
                Diseños.Aegoromantic_5, new Banderas(Diseños.Aegoromantic_5, "Aegoromantic #5", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "A9A9A9", "FFFFFF", "A7D479", "3DA542" }),
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "3DA542" }, new decimal[4] { 0m, 0m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A7D479" }, new decimal[4] { 0m, 1m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A9A9A9" }, new decimal[4] { 0m, 3m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 4m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "00000000" }, new decimal[] { 0m, 0m, 0.5m, 1m, 1m, 0m, 0m, 0m }),
                },
                false,
                new string[] { "3DA542", "A7D479", "FFFFFF", "A9A9A9", "000000" }, null)
            },
            {
                Diseños.Aegoromantic_6, new Banderas(Diseños.Aegoromantic_6, "Aegoromantic #6", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "A8B1B1", "B9C0C2", "FFFFFF", "FFB8B3", "FFA19B" }),
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFA19B" }, new decimal[4] { 0m, 0m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFB8B3" }, new decimal[4] { 0m, 1m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "B9C0C2" }, new decimal[4] { 0m, 3m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A8B1B1" }, new decimal[4] { 0m, 4m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "00000000" }, new decimal[] { 0m, 0m, 0.5m, 1m, 1m, 0m, 0m, 0m }),
                },
                false,
                new string[] { "FFA19B", "FFB8B3", "FFFFFF", "B9C0C2", "A8B1B1" }, null)
            },
            {
                Diseños.Aegosexual, new Banderas(Diseños.Aegosexual, "Aegosexual", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "7F007F", "FFFFFF", "A3A3A3", "000000" }),
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 0m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A3A3A3" }, new decimal[4] { 0m, 1m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 2m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "7F007F" }, new decimal[4] { 0m, 3m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "00000000" }, new decimal[] { 0m, 0m, 0.5m, 1m, 1m, 0m, 0m, 0m }),
                },
                true,
                new string[] { "000000", "A3A3A3", "FFFFFF", "7F007F" }, null)
            },
            {
                Diseños.Aemotional, new Banderas(Diseños.Aemotional, "Aemotional", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF81AB", "FF3B81", "F40076", "0588B8", "000000" }), Operaciones.Empty(), true,
                new string[] { "FF81AB", "FF3B81", "F40076", "0588B8", "000000" }, null)
            },
            {
                Diseños.Aflux, new Banderas(Diseños.Aflux, "Aflux", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFA298", "C398FF", "50FFDF", "88FF50", "FCFF50" }), Operaciones.Empty(), true,
                new string[] { "FFA298", "C398FF", "50FFDF", "88FF50", "FCFF50" }, null)
            },
            {
                Diseños.Aflux_2, new Banderas(Diseños.Aflux_2, "Aflux #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "8C00D4", "539F93", "FFC89B", "FFF5B2", "000000" }), Operaciones.Empty(), false,
                new string[] { "8C00D4", "539F93", "FFC89B", "FFF5B2", "000000" }, null)
            },
            { Diseños.Agender___2014__, new Banderas(Diseños.Agender___2014__, "Agender [2014]", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "B9B9B9", "FFFFFF", "B8F483", "FFFFFF", "B9B9B9", "000000" }), Operaciones.Empty(), true,
                new string[] { "000000", "B9B9B9", "FFFFFF", "B8F483", "FFFFFF", "B9B9B9", "000000" }, null/*,
                new decimal[] { (1m / 7m), (1m / 7m), (1m / 7m), (1m / 7m), (1m / 7m), (1m / 7m), (1m / 7m) }*/)
            },
            {
                Diseños.Agender_2, new Banderas(Diseños.Agender_2, "Agender #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "ffffff", "b5f680", "ffffff", "000000" }), Operaciones.Empty(), false,
                new string[] { "000000", "ffffff", "b5f680", "ffffff", "000000" }, null)
            },
            {
                Diseños.Agender_3, new Banderas(Diseños.Agender_3, "Agender #3", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "858585", "FFFFFF", "00FF01" }), Operaciones.Empty(), false,
                new string[] { "000000", "858585", "FFFFFF", "00FF01" }, null)
            },
            {
                Diseños.Agenderflux, new Banderas(Diseños.Agenderflux, "Agenderflux", 7,
                //Operaciones.Rectángulos_Horizontales(new string[] { "000000", "000000", "000000", "000000", "000000", "000000", "000000", "000000", "000000", "000000", "000000", "000000", "000000", "000000" }),
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 0m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A3A3A3" }, new decimal[4] { 0m, 1m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 2m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo_Degradado, new string[] { "58C5C4", "C6568E" }, new decimal[4] { 0m, 3m / 7m, 1m, 1m / 7m }, LinearGradientMode.Horizontal),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 4m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A3A3A3" }, new decimal[4] { 0m, 5m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 6m / 7m, 1m, 1m / 7m }),
                },
                Operaciones.Empty(), true,
                new string[] { "000000", "A3A3A3", "FFFFFF", "58C5C4", "C6568E", "FFFFFF", "A3A3A3", "000000" },
                new decimal[]{ 1m / 7m, 1m / 7m, 1m / 7m, 0.5m / 7m, 0.5m / 7m, 1m / 7m, 1m / 7m, 1m / 7m })
            },
            {
                Diseños.Aingender, new Banderas(Diseños.Aingender, "Aingender (AIN)", 8,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "EC8080" }, new decimal[4] { 0m, 0m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FCAC72" }, new decimal[4] { 0m, 1m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FDC579" }, new decimal[4] { 0m, 2m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F5DB89" }, new decimal[4] { 0m, 3m / 8m, 1m, 2m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "EFF576" }, new decimal[4] { 0m, 5m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "C0EC80" }, new decimal[4] { 0m, 6m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "88DBA0" }, new decimal[4] { 0m, 7m / 8m, 1m, 1m / 8m }),
                },
                Operaciones.Empty(), true,
                new string[] { "EC8080", "FCAC72", "FDC579", "F5DB89", "EFF576", "C0EC80", "88DBA0" },
                new decimal[]{ 1m / 8m, 1m / 8m, 1m / 8m, 2m / 8m, 1m / 8m, 1m / 8m, 1m / 8m })
            },
            {
                Diseños.Aliusaromantic, new Banderas(Diseños.Aliusaromantic, "Aliusaromantic", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "969696", "FFFFFF", "39A53F", "000000" }), Operaciones.Empty(), true,
                new string[] { "969696", "FFFFFF", "39A53F", "000000" }, null)
            },
            {
                Diseños.Aliusdemiromantic, new Banderas(Diseños.Aliusdemiromantic, "Aliusdemiromantic", 6,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 0m / 6m, 1m, 2.5m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D4D4D4" }, new decimal[4] { 0m, 2.5m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 3.5m / 6m, 1m, 2.5m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "39A53F" }, new decimal[]
                    {
                        1m, 0m,
                        1m - (1930m / 5000m), 0.5m,
                        1m, 1m,
                        1m, 0m
                    }),
                },
                Operaciones.Empty(), true,
                new string[] { "FFFFFF", "D4D4D4", "000000" },
                new decimal[]{ 2.5m / 6m, 1m / 6m, 2.5m / 6m })
            },
            {
                Diseños.Allosexual, new Banderas(Diseños.Allosexual, "Allosexual", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFFFFF", "A9A9A9", "000000", "FFFFFF", "000000", "A9A9A9", "FFFFFF" }), Operaciones.Empty(), true,
                new string[] { "FFFFFF", "A9A9A9", "000000", "FFFFFF", "000000", "A9A9A9", "FFFFFF" }, null)
            },
            {
                Diseños.Altersex, new Banderas(Diseños.Altersex, "Altersex", 5,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "93FFB9" }, new decimal[4] { 0m, 0m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "93DCFF" }, new decimal[4] { 0m, 1m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "CC93FF" }, new decimal[4] { 0m, 3m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFA8BE" }, new decimal[4] { 0m, 4m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "FFFFFF" }, new decimal[] { 1m / 3m, 2m / 5m, 0.5m, 0m, 2m / 3m, 2m / 5m }),
                    //new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "FFFFFF" }, new decimal[] { 0m, 2m / 5m, 1m / 3m, 2m / 5m, 0.5m, 0m, 2m / 3m, 2m / 5m, 1m, 2m / 5m, 1m, 3m / 5m, 0m, 3m / 5m, 0m, 2m / 5m }),
                },
                Operaciones.Empty(), true,
                new string[] { "93FFB9", "93DCFF", "FFFFFF", "CC93FF", "FFA8BE" }, null)
            },
            {
                Diseños.Ambiamorous, new Banderas(Diseños.Ambiamorous, "Ambiamorous", 10,
                //Operaciones.Rectángulos_Horizontales(new string[] { "4848C2", "404082", "b5f680", "ffffff", "000000", "ffffff", "000000" }), Operaciones.Empty(), true,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "4848C2" }, new decimal[4] { 0m, 0m / 10m, 1m, 2m / 10m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "404082" }, new decimal[4] { 0m, 2m / 10m, 1m, 1m / 10m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "313146" }, new decimal[4] { 0m, 3m / 10m, 1m, 1m / 10m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "1E1E1E" }, new decimal[4] { 0m, 4m / 10m, 1m, 2m / 10m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "453232" }, new decimal[4] { 0m, 6m / 10m, 1m, 1m / 10m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "7E4443" }, new decimal[4] { 0m, 7m / 10m, 1m, 1m / 10m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "C14A4A" }, new decimal[4] { 0m, 8m / 10m, 1m, 2m / 10m }),
                },
                Operaciones.Empty(), true,
                new string[] { "4848C2", "404082", "313146", "1E1E1E", "453232", "7E4443", "C14A4A" },
                new decimal[]{ 2m / 10m, 1m / 10m, 1m / 10m, 2m / 10m, 1m / 10m, 1m / 10m, 2m / 10m })
            },
            {
                Diseños.Androgyne, new Banderas(Diseños.Androgyne, "Androgyne", 3,
                Operaciones.Rectángulos_Verticales(new string[] { "FE007F", "9832FF", "00B8E7" }), Operaciones.Empty(), true,
                new string[] { "FE007F", "9832FF", "00B8E7" }, null)
            },
            {
                Diseños.Androgyne_2, new Banderas(Diseños.Androgyne_2, "Androgyne #2", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "BBE5F5", "FFFFFF", "A793E7", "FFFFFF", "F8BBE5", "000000" }), Operaciones.Empty(), false,
                new string[] { "000000", "BBE5F5", "FFFFFF", "A793E7", "FFFFFF", "F8BBE5", "000000" }, null)
            },
            {
                Diseños.Androgyne_3, new Banderas(Diseños.Androgyne_3, "Androgyne #3", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "db4e62", "c080d8", "e9cc54", "696969", "5381d8" }), Operaciones.Empty(), false,
                new string[] { "db4e62", "c080d8", "e9cc54", "696969", "5381d8" }, null)
            },
            {
                Diseños.Androgyne_4, new Banderas(Diseños.Androgyne_4, "Androgyne #4", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF006C", "800080", "400080", "07015A", "004047" }), Operaciones.Empty(), false,
                new string[] { "FF006C", "800080", "400080", "07015A", "004047" }, null)
            },
            {
                Diseños.Androgyne_5, new Banderas(Diseños.Androgyne_5, "Androgyne #5", 3,
                Operaciones.Rectángulos_Verticales(new string[] { "F1297E", "5420A9", "09C4ED" }), Operaciones.Empty(), false,
                new string[] { "F1297E", "5420A9", "09C4ED" }, null)
            },
            {
                Diseños.Androgyne_6, new Banderas(Diseños.Androgyne_6, "Androgyne #6", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "9832FF", "FF017E", "01B7E7" }), Operaciones.Empty(), false,
                new string[] { "9832FF", "FF017E", "01B7E7" }, null)
            },
            {
                Diseños.Androgyne_7, new Banderas(Diseños.Androgyne_7, "Androgyne #7", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "6D80A8", "8D9FC7", "865AB1", "C95DAB", "B0398E" }), Operaciones.Empty(), false,
                new string[] { "6D80A8", "8D9FC7", "865AB1", "C95DAB", "B0398E" }, null)
            },
            {
                Diseños.Androromantic, new Banderas(Diseños.Androromantic, "Androromantic", 3,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "73E3FF" }, new decimal[4] { 0m, 0m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A89086" }, new decimal[4] { 0m, 1m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D8C7ED" }, new decimal[4] { 0m, 2m / 3m, 1m, 1m / 3m }),
                },
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "01CCFF" }, new decimal[4] { 0m, 0m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "603524" }, new decimal[4] { 0m, 1m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "B799DE" }, new decimal[4] { 0m, 2m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen_Recorte, new string[] { "FFFFFF" }, new decimal[] { 861m / 5000m, 0m / 3000m, 3277m / 5000m, 3000m / 3000m }, "Heart.png"),
                },
                true,
                new string[] { "73E3FF", "A89086", "D8C7ED" }, null)
            },
            {
                Diseños.Androsexual, new Banderas(Diseños.Androsexual, "Androsexual", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "00CCFF", "603524", "B899DF" }), Operaciones.Empty(), true,
                new string[] { "00CCFF", "603524", "B899DF" }, null)
            },
            {
                Diseños.Anovelaean, new Banderas(Diseños.Anovelaean, "Anovelaean", 9,
                Operaciones.Rectángulos_Horizontales(new string[] { "0207F9", "5B5DFF", "65DCB6", "7FFF86", "ADF9B1", "7FFF84", "65DCB6", "5B5DFF", "0207F9" }), Operaciones.Empty(), true,
                new string[] { "0207F9", "5B5DFF", "65DCB6", "7FFF86", "ADF9B1", "7FFF84", "65DCB6", "5B5DFF", "0207F9" }, null)
            },
            {
                Diseños.Antiromantic, new Banderas(Diseños.Antiromantic, "Antiromantic", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "64D164", "185519", "082008", "49CA49", "59CE59", "84DA83" }),
                new Operaciones[]
                {
                    //new Operaciones(Funciones.Rectángulo, new string[] { "00000000" }, new decimal[4] { 0m, 0m, 1m, 1m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "FFFFFF" }, new decimal[4] { 364m / 1154m, 161m / 692m, 426m / 1154m, 372m / 692m }, "Heart.png"),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 447m / 1154m, 304m / 692m, 260m / 1154m, 58m / 692m }),
                },
                //Operaciones.Empty(),
                true,
                new string[] { "64D164", "185519", "082008", "49CA49", "59CE59", "84DA83" }, null)
            },
            {
                Diseños.Aplaroace, new Banderas(Diseños.Aplaroace, "Aplaroace", 9,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "999999", "F3F6F4", "83579C", "3D85C6", "6AA84F", "FFFFFF", "8C8B8B", "000000" }), Operaciones.Empty(), true,
                new string[] { "000000", "999999", "F3F6F4", "83579C", "3D85C6", "6AA84F", "FFFFFF", "8C8B8B", "000000" }, null)
            },
            {
                Diseños.Aporagender, new Banderas(Diseños.Aporagender, "Aporagender", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "F37CCA", "E1BDF0", "FFF982", "E1BDF0", "7BBBDD" }), Operaciones.Empty(), true,
                new string[] { "F37CCA", "E1BDF0", "FFF982", "E1BDF0", "7BBBDD" }, null)
            },
            {
                Diseños.Aporine, new Banderas(Diseños.Aporine, "Aporine", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "EA8C8C", "F8BE94", "F5DB9C", "FAF489", "DAEE66" }), Operaciones.Empty(), true,
                new string[] { "EA8C8C", "F8BE94", "F5DB9C", "FAF489", "DAEE66" }, null)
            },
            {
                Diseños.Aporine_2, new Banderas(Diseños.Aporine_2, "Aporine #2", 13,
                Operaciones.Rectángulos_Horizontales(new string[] { "E98C8B", "EE9D8E", "F4AD91", "F9BE94", "F8C897", "F7D19B", "F6DB9E", "F7E497", "F9EC90", "FAF589", "EFF37D", "E5F072", "DAEE66" }), Operaciones.Empty(), true,
                new string[] { "E98C8B", "EE9D8E", "F4AD91", "F9BE94", "F8C897", "F7D19B", "F6DB9E", "F7E497", "F9EC90", "FAF589", "EFF37D", "E5F072", "DAEE66" }, null)
            },
            {
                Diseños.Apothiromantic, new Banderas(Diseños.Apothiromantic, "Apothiromantic", 0,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "008100" }, new decimal[4] { 0m, 0m / 3000m, 1m, 720m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 720m / 3000m, 1m, 520m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 1240m / 3000m, 1m, 520m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 1760m / 3000m, 1m, 520m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "9C2524" }, new decimal[4] { 0m, 2280m / 3000m, 1m, 720m / 3000m }),
                },
                Operaciones.Empty(), true,
                new string[] { "008100", "FFFFFF", "000000", "FFFFFF", "9C2524" },
                new decimal[]{ 720m / 3000m, 520m / 3000m, 520m / 3000m, 520m / 3000m, 720m / 3000m })
            },
            {
                Diseños.Apothiromantic_2, new Banderas(Diseños.Apothiromantic_2, "Apothiromantic #2", 6,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "003768" }, new decimal[4] { 0m, 0m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "59C5A8" }, new decimal[4] { 0m, 1m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFF9DA" }, new decimal[4] { 0m, 2m / 6m, 1m, 2m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "59C5A8" }, new decimal[4] { 0m, 4m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "003768" }, new decimal[4] { 0m, 5m / 6m, 1m, 1m / 6m }),
                },
                Operaciones.Empty(), false,
                new string[] { "003768", "59C5A8", "FFF9DA", "59C5A8", "003768" },
                new decimal[]{ 1m / 6m, 1m / 6m, 2m / 6m, 1m / 6m, 1m / 6m })
            },
            {
                Diseños.Apothisexual, new Banderas(Diseños.Apothisexual, "Apothisexual", 0,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "670066" }, new decimal[4] { 0m, 0m / 3000m, 1m, 720m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 720m / 3000m, 1m, 520m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 1240m / 3000m, 1m, 520m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 1760m / 3000m, 1m, 520m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "9D2424" }, new decimal[4] { 0m, 2280m / 3000m, 1m, 720m / 3000m }),
                    //new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "9D2424" }, new decimal[] { 1095m / 5000m, 192m / 3000m, 1557m / 5000m, 0m / 3000m, 2498m / 5000m, 1086m / 3000m, 3439m / 5000m, 0m / 3000m, 3901m / 5000m, 192m / 3000m, 2948m / 5000m, 1237m / 3000m, m / 5000m, m / 3000m, m / 5000m, m / 3000m, m / 5000m, m / 3000m, m / 5000m, m / 3000m, m / 5000m, m / 3000m, m / 5000m, m / 3000m, m / 5000m, m / 3000m }),
                },
                Operaciones.Empty(), true,
                new string[] { "670066", "FFFFFF", "000000", "FFFFFF", "9D2424" },
                new decimal[]{ 720m / 3000m, 520m / 3000m, 520m / 3000m, 520m / 3000m, 720m / 3000m })
            },
            {
                Diseños.Apresromantic, new Banderas(Diseños.Apresromantic, "Apresromantic", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF75A2", "A6F4AA", "E4F7AE", "000000", "7F7F7F" }), Operaciones.Empty(), true,
                new string[] { "FF75A2", "A6F4AA", "E4F7AE", "000000", "7F7F7F" }, null)
            },
            {
                Diseños.Aroace, new Banderas(Diseños.Aroace, "Aroace (aromantic asexual)", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "E28C00", "ECCD00", "FFFFFF", "62AEDC", "203856" }), Operaciones.Empty(), true,
                //Operaciones.Rectángulos_Horizontales(new string[] { "e38d00", "edce00", "ffffff", "62b0dd", "1a3555" }), Operaciones.Empty(), true,
                new string[] { "E28C00", "ECCD00", "FFFFFF", "62AEDC", "203856" }, null)
            },
            {
                Diseños.Aroace_2, new Banderas(Diseños.Aroace_2, "Aroace (aromantic asexual) #2", 8,
                Operaciones.Rectángulos_Horizontales(new string[] { "3CA542", "A9D37A", "FFFFFF", "A9A9A9", "010101", "A9A9A9", "FFFFFF", "670066" }), Operaciones.Empty(), false,
                new string[] { "3CA542", "A9D37A", "FFFFFF", "A9A9A9", "010101", "A9A9A9", "FFFFFF", "670066" }, null)
            },
            {
                Diseños.Aroaceflux, new Banderas(Diseños.Aroaceflux, "Aroaceflux", 9,
                Operaciones.Rectángulos_Horizontales(new string[] { "4B0082", "551A8B", "483D8B", "6E7B8B", "838B83", "8FBC8F", "698B69", "3CB371", "00FF7F" }), Operaciones.Empty(), true,
                new string[] { "4B0082", "551A8B", "483D8B", "6E7B8B", "838B83", "8FBC8F", "698B69", "3CB371", "00FF7F" }, null)
            },
            {
                Diseños.Aroaceflux_2, new Banderas(Diseños.Aroaceflux_2, "Aroaceflux #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FE6881", "CD6D89", "9F7394", "6B789A", "37759B" }), Operaciones.Empty(), false,
                new string[] { "FE6881", "CD6D89", "9F7394", "6B789A", "37759B" }, null)
            },
            {
                Diseños.Aroaceflux_3, new Banderas(Diseños.Aroaceflux_3, "Aroaceflux #3", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "C8207D", "EC6CA3", "DFD1FA", "46679B", "00297F" }), Operaciones.Empty(), false,
                new string[] { "C8207D", "EC6CA3", "DFD1FA", "46679B", "00297F" }, null)
            },
            {
                Diseños.Aroaceflux_4, new Banderas(Diseños.Aroaceflux_4, "Aroaceflux #4", 9,
                Operaciones.Rectángulos_Horizontales(new string[] { "3EA64A", "AAD275", "F0E6B1", "E97370", "CC2063", "EC6D88", "FBD1E2", "90479B", "820080" }), Operaciones.Empty(), false,
                new string[] { "3EA64A", "AAD275", "F0E6B1", "E97370", "CC2063", "EC6D88", "FBD1E2", "90479B", "820080" }, null)
            },
            {
                Diseños.Aroaceflux_5, new Banderas(Diseños.Aroaceflux_5, "Aroaceflux #5", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "F8575D", "FE7C85", "FFCDE5", "6B8FD5", "3B3F94" }), Operaciones.Empty(), false,
                new string[] { "F8575D", "FE7C85", "FFCDE5", "6B8FD5", "3B3F94" }, null)
            },
            {
                Diseños.Aroflux, new Banderas(Diseños.Aroflux, "Aroflux", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "E7516A", "D86D65", "B7A55D", "A3C95A", "92E454" }), Operaciones.Empty(), true,
                new string[] { "E7516A", "D86D65", "B7A55D", "A3C95A", "92E454" }, null)
            },
            {
                Diseños.Aromantic___2014__, new Banderas(Diseños.Aromantic___2014__, "Aromantic [2014]", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "3DA542", "A7D379", "FFFFFF", "A9A9A9", "000000" }), Operaciones.Empty(), true,
                new string[] { "3DA542", "A7D379", "FFFFFF", "A9A9A9", "000000" }, null)
            },
            {
                Diseños.Aromantic_2, new Banderas(Diseños.Aromantic_2, "Aromantic #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "3da542", "a9d27a", "ffff66", "a9a9a9", "000000" }), Operaciones.Empty(), false,
                new string[] { "3da542", "a9d27a", "ffff66", "a9a9a9", "000000" }, null)
            },
            {
                Diseños.Aromantic_3, new Banderas(Diseños.Aromantic_3, "Aromantic #3", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "7dbe00", "fff300", "ff7000", "000000" }), Operaciones.Empty(), false,
                new string[] { "7dbe00", "fff300", "ff7000", "000000" }, null)
            },
            {
                Diseños.Aromantic_spectrum, new Banderas(Diseños.Aromantic_spectrum, "Aromantic spectrum", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "3F9F52", "97CF7C", "F2FCCF", "186264", "052127" }), Operaciones.Empty(), true,
                new string[] { "3F9F52", "97CF7C", "F2FCCF", "186264", "052127" }, null)
            },
            {
                Diseños.Asexual___2010__, new Banderas(Diseños.Asexual___2010__, "Asexual [2010]", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "A3A3A3", "FFFFFF", "800080" }), Operaciones.Empty(), true,
                new string[] { "000000", "A3A3A3", "FFFFFF", "800080" }, null)
            },
            {
                Diseños.Asexual_2, new Banderas(Diseños.Asexual_2, "Asexual #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "a3a3a3", "ffffff", "800080", "000000" }), Operaciones.Empty(), false,
                new string[] { "000000", "a3a3a3", "ffffff", "800080", "000000" }, null)
            },
            {
                Diseños.Asexual_spectrum, new Banderas(Diseños.Asexual_spectrum, "Asexual spectrum", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "151847", "7657AE", "DA92B4", "FFECED" }), Operaciones.Empty(), true,
                new string[] { "151847", "7657AE", "DA92B4", "FFECED" }, null)
            },
            {
                Diseños.Assigned_intersex_at_birth, new Banderas(Diseños.Assigned_intersex_at_birth, "Assigned Intersex at Birth (AIAB)", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "3B2989", "7C40A9", "F9D183", "FF8120", "F55203" }), Operaciones.Empty(), true,
                new string[] { "3B2989", "7C40A9", "F9D183", "FF8120", "F55203" }, null)
            },
            {
                Diseños.Assigned_male_at_birth, new Banderas(Diseños.Assigned_male_at_birth, "Assigned Male At Birth (AMAB)", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "6174C2", "DDEA39", "A9AAA8", "D84B76" }), Operaciones.Empty(), true,
                new string[] { "6174C2", "DDEA39", "A9AAA8", "D84B76" }, null)
            },
            {
                Diseños.Assigned_male_at_birth_2, new Banderas(Diseños.Assigned_male_at_birth_2, "Assigned Male At Birth (AMAB) #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "B23B3A", "FA9261", "FFEAC9", "572B6E", "111C27" }), Operaciones.Empty(), false,
                new string[] { "B23B3A", "FA9261", "FFEAC9", "572B6E", "111C27" }, null)
            },
            {
                Diseños.Assigned_male_at_birth_3, new Banderas(Diseños.Assigned_male_at_birth_3, "Assigned Male At Birth (AMAB) #3", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF0000", "FF8080", "FFFFFF", "CD85CD", "8080FF" }), Operaciones.Empty(), false,
                new string[] { "FF0000", "FF8080", "FFFFFF", "CD85CD", "8080FF" }, null)
            },
            {
                Diseños.Assigned_male_at_birth_4, new Banderas(Diseños.Assigned_male_at_birth_4, "Assigned Male At Birth (AMAB) #4", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "F92601", "FF9318", "FFF7CA", "551692", "08092A" }), Operaciones.Empty(), false,
                new string[] { "F92601", "FF9318", "FFF7CA", "551692", "08092A" }, null)
            },
            {
                Diseños.Assigned_male_at_birth_5, new Banderas(Diseños.Assigned_male_at_birth_5, "Assigned Male At Birth (AMAB) #5", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "74198D", "A148D4", "BA33E2", "6A45CB", "1000AA" }), Operaciones.Empty(), false,
                new string[] { "74198D", "A148D4", "BA33E2", "6A45CB", "1000AA" }, null)
            },
            {
                Diseños.Assigned_male_at_birth_6, new Banderas(Diseños.Assigned_male_at_birth_6, "Assigned Male At Birth (AMAB) #6", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "920201", "B83B00", "FFE6BE", "C28DDD", "717E8C" }), Operaciones.Empty(), false,
                new string[] { "920201", "B83B00", "FFE6BE", "C28DDD", "717E8C" }, null)
            },
            {
                Diseños.Assigned_male_at_birth_7, new Banderas(Diseños.Assigned_male_at_birth_7, "Assigned Male At Birth (AMAB) #7", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "810093", "E678F1", "E200FF", "CE6CFF", "620093" }), Operaciones.Empty(), false,
                new string[] { "810093", "E678F1", "E200FF", "CE6CFF", "620093" }, null)
            },
            {
                Diseños.Assigned_x_at_birth, new Banderas(Diseños.Assigned_x_at_birth, "Assigned X at Birth (AXAB)", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "DA00F2", "FFFFFF", "F088FF" }), Operaciones.Empty(), true,
                new string[] { "DA00F2", "FFFFFF", "F088FF" }, null)
            },
            {
                Diseños.Assigned_x_at_birth_2, new Banderas(Diseños.Assigned_x_at_birth_2, "Assigned X at Birth (AXAB) #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "A75151", "F2B788", "FBE4D2", "8FBC8F", "008153" }), Operaciones.Empty(), false,
                new string[] { "A75151", "F2B788", "FBE4D2", "8FBC8F", "008153" }, null)
            },
            {
                Diseños.Assigned_x_at_birth_3, new Banderas(Diseños.Assigned_x_at_birth_3, "Assigned X at Birth (AXAB) #3", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "DA00F2", "F088FF", "FFFFFF", "CD85CD", "FF8080" }), Operaciones.Empty(), false,
                new string[] { "DA00F2", "F088FF", "FFFFFF", "CD85CD", "FF8080" }, null)
            },
            {
                Diseños.Autoromantic, new Banderas(Diseños.Autoromantic, "Autoromantic", 5,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "93D2E4" }, new decimal[4] { 0m, 0m / 5m, 1m, 2m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "3EA442" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "7B7B7B" }, new decimal[4] { 0m, 3m / 5m, 1m, 2m / 5m }),
                },
                Operaciones.Empty(), true,
                new string[] { "93D2E4", "3EA442", "7B7B7B" },
                new decimal[]{ 2m / 5m, 1m / 5m, 2m / 5m })
            },
            {
                Diseños.Autosexual, new Banderas(Diseños.Autosexual, "Autosexual", 2,
                Operaciones.Rectángulos_Horizontales(new string[] { "9ADBED", "7B7D7A" }), Operaciones.Empty(), true,
                new string[] { "9ADBED", "7B7D7A" }, null)
            },
            {
                Diseños.Avansexuality, new Banderas(Diseños.Avansexuality, "Avansexuality", 10,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF0179", "1B3593", "60FE53", "FE0700", "040202", "FFFFFF", "FEF301", "834324", "82807E", "AA01FE" }), Operaciones.Empty(), true,
                new string[] { "FF0179", "1B3593", "60FE53", "FE0700", "040202", "FFFFFF", "FEF301", "834324", "82807E", "AA01FE" }, null)
            },
            {
                Diseños.Bambi_lesbian, new Banderas(Diseños.Bambi_lesbian, "Bambi Lesbian", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "B3486E", "CD8290", "DBB3AC", "F2F2F2", "E9D2C3", "C28E62", "7D4C38" }), Operaciones.Empty(), true,
                new string[] { "B3486E", "CD8290", "DBB3AC", "F2F2F2", "E9D2C3", "C28E62", "7D4C38" }, null)
            },
            {
                Diseños.Bambi_lesbian_2, new Banderas(Diseños.Bambi_lesbian_2, "Bambi Lesbian #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "B3486E", "CD8290", "F2F2F2", "E9D2C3", "7D4C38" }), Operaciones.Empty(), true,
                new string[] { "B3486E", "CD8290", "F2F2F2", "E9D2C3", "7D4C38" }, null)
            },
            {
                Diseños.BDSM_rights, new Banderas(Diseños.BDSM_rights, "BDSM rights", 9,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "0000FF", "000000", "0000FF", "FFFFFF", "0000FF", "000000", "0000FF", "000000" }), Operaciones.Empty(), true,
                new string[] { "000000", "0000FF", "000000", "0000FF", "FFFFFF", "0000FF", "000000", "0000FF", "000000" }, null)
            },
            /*{
                Diseños.Bellusromantic, new Banderas("Bellusromantic",
                "Bellusromantic involves having an interest in conventionally romantic things without desiring a relationship.",
                Operaciones.Rectángulos_Horizontales(new string[] { "" }), Operaciones.Empty(), true,
                new string[] { "" }, null)
            },*/
            {
                Diseños.Bear_brotherhood, new Banderas(Diseños.Bear_brotherhood, "Bear brotherhood", 7,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "623804" }, new decimal[4] { 0m, 0m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D56300" }, new decimal[4] { 0m, 1m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FEDD63" }, new decimal[4] { 0m, 2m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FEE6B8" }, new decimal[4] { 0m, 3m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 4m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "555555" }, new decimal[4] { 0m, 5m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 6m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "FFFFFF" }, new decimal[4] { 137m / 1920m, 78m / 1152m, 560m / 1920m, 507m / 1152m }, "Bear.png"),
                },
                //Operaciones.Rectángulos_Horizontales(new string[] { "623804", "D56300", "FEDD63", "FEE6B8", "FFFFFF", "555555", "000000" }),
                Operaciones.Empty(), true,
                new string[] { "623804", "D56300", "FEDD63", "FEE6B8", "FFFFFF", "555555", "000000" }, null)
            },
            {
                Diseños.Bicurious, new Banderas(Diseños.Bicurious, "Bicurious", 10,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F347F8" }, new decimal[4] { 0m, 0m / 10m, 1m, 2m / 10m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F787FA" }, new decimal[4] { 0m, 2m / 10m, 1m, 1m / 10m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FDC6FD" }, new decimal[4] { 0m, 3m / 10m, 1m, 1m / 10m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 4m / 10m, 1m, 2m / 10m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "C6E0FD" }, new decimal[4] { 0m, 6m / 10m, 1m, 1m / 10m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "76B5FA" }, new decimal[4] { 0m, 7m / 10m, 1m, 1m / 10m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "2D8CF7" }, new decimal[4] { 0m, 8m / 10m, 1m, 2m / 10m }),
                },
                Operaciones.Empty(), true,
                new string[] { "F347F8", "F787FA", "FDC6FD", "FFFFFF", "C6E0FD", "76B5FA", "2D8CF7" },
                new decimal[]{ 2m / 10m, 1m / 10m, 1m / 10m, 2m / 10m, 1m / 10m, 1m / 10m, 2m / 10m })
            },
            {
                Diseños.Bigender, new Banderas(Diseños.Bigender, "Bigender", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "C479A2", "EDA5CD", "D5C7E8", "FFFFFF", "D5C7E8", "9AC7E8", "6D82D1" }), Operaciones.Empty(), true,
                new string[] { "C479A2", "EDA5CD", "D5C7E8", "FFFFFF", "D5C7E8", "9AC7E8", "6D82D1" }, null)
            },
            {
                Diseños.Bigender_2, new Banderas(Diseños.Bigender_2, "Bigender #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "ED78AA", "FDF44D", "FFFFFF", "AE6DBE", "719EE3" }), Operaciones.Empty(), false,
                new string[] { "ED78AA", "FDF44D", "FFFFFF", "AE6DBE", "719EE3" }, null)
            },
            {
                Diseños.Binary_to_non_binary, new Banderas(Diseños.Binary_to_non_binary, "Binary to non binary (BTX, BTNB)", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "74DFFF", "FFFEB3", "FFFC74", "FFF301", "FFFC74", "FFFEB3", "FE8DBF" }), Operaciones.Empty(), true,
                new string[] { "74DFFF", "FFFEB3", "FFFC74", "FFF301", "FFFC74", "FFFEB3", "FE8DBF" }, null)
            },
            {
                Diseños.Bisexual___1998__, new Banderas(Diseños.Bisexual___1998__, "Bisexual [1998]", 5,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D60270" }, new decimal[4] { 0m, 0m / 5m, 1m, 2m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "9B4F96" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "0038A8" }, new decimal[4] { 0m, 3m / 5m, 1m, 2m / 5m }),
                },
                //Operaciones.Rectángulos_Horizontales(new string[] { "D60270", "D60270", "9B4F96", "0038A8", "0038A8" }),
                Operaciones.Empty(), true,
                new string[] { "D60270", "9B4F96", "0038A8" },
                new decimal[] { 2m / 5m, 1m / 5m, 2m / 5m })
            },
            {
                Diseños.Black_trans, new Banderas(Diseños.Black_trans, "Black transgender (POC)", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "5BCEFA", "F5A9B8", "000000", "F5A9B8", "5BCEFA" }), Operaciones.Empty(), true,
                new string[] { "5BCEFA", "F5A9B8", "000000", "F5A9B8", "5BCEFA" }, null)
            },
            {
                Diseños.Boreasexual, new Banderas(Diseños.Boreasexual, "Boreasexual", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "6D6A6D", "866C72", "FF0140", "000000", "262626" }), Operaciones.Empty(), true,
                new string[] { "6D6A6D", "866C72", "FF0140", "000000", "262626" }, null)
            },
            {
                Diseños.Boyflux, new Banderas(Diseños.Boyflux, "Boyflux", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "D7E9FA", "6FACF5", "023670", "A0EDAA", "023670", "6FACF5", "D7E9FA" }), Operaciones.Empty(), true,
                new string[] { "D7E9FA", "6FACF5", "023670", "A0EDAA", "023670", "6FACF5", "D7E9FA" }, null)
            },
            {
                Diseños.Carnelian, new Banderas(Diseños.Carnelian, "Carnelian", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "771111", "FFCC99", "DD2211", "FFAA44", "DD4411" }), Operaciones.Empty(), true,
                new string[] { "771111", "FFCC99", "DD2211", "FFAA44", "DD4411" }, null)
            },
            {
                Diseños.Ceteroromantic, new Banderas(Diseños.Ceteroromantic, "Ceteroromantic", 5,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FEFE7F" }, new decimal[4] { 0m, 0m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "90C782" }, new decimal[4] { 0m, 1m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F9ABF3" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 3m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "808080" }, new decimal[4] { 0m, 4m / 5m, 1m, 1m / 5m }),
                    //new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "F757EA" }, new decimal[] { 861m / 5000m, 0m / 3000m, 3277m / 5000m, 3000m / 3000m }, "Heart.png"),
                },
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "FFFD01" }, new decimal[4] { 0m, 0m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "218E02" }, new decimal[4] { 0m, 1m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "F456E9" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 3m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 4m / 5m, 1m, 1m / 5m }),
                    //new Operaciones(Dibujos.Iconos, Funciones.Imagen_Recorte, new string[] { "FFFFFF" }, new decimal[] { 902m / 5000m, 40m / 3000m, 3195m / 5000m, 2909m / 3000m }, "Heart.png"),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen_Recorte, new string[] { "F757EA" }, new decimal[] { 861m / 5000m, 0m / 3000m, 3277m / 5000m, 3000m / 3000m }, "Heart.png"),
                },
                true,
                new string[] { "FEFE7F", "90C782", "F9ABF3", "FFFFFF", "808080" }, null)
            },
            {
                Diseños.Ceterosexual, new Banderas(Diseños.Ceterosexual, "Ceterosexual", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "FCF97F", "159C46", "FFFFFF", "000000" }), Operaciones.Empty(), true,
                new string[] { "FCF97F", "159C46", "FFFFFF", "000000" }, null)
            },
            {
                Diseños.Cinthean, new Banderas(Diseños.Cinthean, "Cinthean", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "0D2D68", "671DA6", "E7074C", "EC6286", "F99E89", "FFFFFF" }), Operaciones.Empty(), false,
                new string[] { "0D2D68", "671DA6", "E7074C", "EC6286", "F99E89", "FFFFFF" }, null)
            },
            {
                Diseños.Cisgender, new Banderas(Diseños.Cisgender, "Cisgender", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "BFBFBF", "E0DCDD", "BFBFBF" }), Operaciones.Empty(), true,
                new string[] { "BFBFBF", "E0DCDD", "BFBFBF" }, null)
            },
            {
                Diseños.Cisgender_2, new Banderas(Diseños.Cisgender_2, "Cisgender #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "A6A6A6", "BCBCBC", "E0DCDD", "BCBCBC", "A6A6A6" }), Operaciones.Empty(), false,
                new string[] { "A6A6A6", "BCBCBC", "E0DCDD", "BCBCBC", "A6A6A6" }, null)
            },
            {
                Diseños.Cisgender_3, new Banderas(Diseños.Cisgender_3, "Cisgender #3", 2,
                Operaciones.Rectángulos_Horizontales(new string[] { "D70170", "0038A7" }), Operaciones.Empty(), false,
                new string[] { "D70170", "0038A7" }, null)
            },
            {
                Diseños.Cisgender_4, new Banderas(Diseños.Cisgender_4, "Cisgender #4", 2,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "0073C5" }, new decimal[4] { 0m / 2m, 0m, 1m / 2m, 1m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "EF5682" }, new decimal[4] { 1m / 2m, 0m, 1m / 2m, 1m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "FFFFFF" }, new decimal[] { 277m / 1154m, 82m / 692m, 602m / 1154m, 532m / 692m }, "Heart.png"),
                },
                Operaciones.Empty(), false,
                new string[] { "0073C5", "EF5682" }, null)
            },
            {
                Diseños.Cisgender_5, new Banderas(Diseños.Cisgender_5, "Cisgender #5", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "121212", "3F3F3F", "DADADA", "3F3F3F", "121212" }), Operaciones.Empty(), false,
                new string[] { "121212", "3F3F3F", "DADADA", "3F3F3F", "121212" }, null)
            },
            {
                Diseños.Cisgender_6, new Banderas(Diseños.Cisgender_6, "Cisgender #6", 5,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F5627E" }, new decimal[4] { 0m, 0m / 5m, 0.5m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "9C9C9C" }, new decimal[4] { 0.5m, 0m / 5m, 0.5m, 1m / 5m }),

                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "DFBAC1" }, new decimal[4] { 0m, 1m / 5m, 0.5m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "C9C9C9" }, new decimal[4] { 0.5m, 1m / 5m, 0.5m, 1m / 5m }),

                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),

                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "B7B7B7" }, new decimal[4] { 0m, 3m / 5m, 0.5m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "89C3D8" }, new decimal[4] { 0.5m, 3m / 5m, 0.5m, 1m / 5m }),

                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "9B9B9B" }, new decimal[4] { 0m, 4m / 5m, 0.5m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "47B2D8" }, new decimal[4] { 0.5m, 4m / 5m, 0.5m, 1m / 5m }),
                },
                Operaciones.Empty(), false,
                new string[] { "F5627E", "9C9C9C", "DFBAC1", "C9C9C9", "FFFFFF", "B7B7B7", "89C3D8", "9B9B9B", "47B2D8" },
                new decimal[]{ 1m / 10m, 1m / 10m, 1m / 10m, 1m / 10m, 2m / 10m, 1m / 10m, 1m / 10m, 1m / 10m, 1m / 10m })
            },
            {
                Diseños.Cis_men, new Banderas(Diseños.Cis_men, "Cis-men", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "5271FF", "BCBCBC", "E0DCDD", "BCBCBC", "5271FF" }), Operaciones.Empty(), true,
                new string[] { "5271FF", "BCBCBC", "E0DCDD", "BCBCBC", "5271FF" }, null)
            },
            {
                Diseños.Cis_women, new Banderas(Diseños.Cis_women, "Cis-women", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF5757", "BCBCBC", "E0DCDD", "BCBCBC", "FF5757" }), Operaciones.Empty(), true,
                new string[] { "FF5757", "BCBCBC", "E0DCDD", "BCBCBC", "FF5757" }, null)
            },
            {
                Diseños.Cupioromantic, new Banderas(Diseños.Cupioromantic, "Cupioromantic", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FCA9A3", "FDC5C0", "FFFFFF", "C8BFE6", "A0A0A0" }), Operaciones.Empty(), true,
                new string[] { "FCA9A3", "FDC5C0", "FFFFFF", "C8BFE6", "A0A0A0" }, null)
            },
            {
                Diseños.Demiboy, new Banderas(Diseños.Demiboy, "Demiboy", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "7f7f7f", "c3c3c3", "9ad9ea", "ffffff", "9ad9ea", "c3c3c3", "7f7f7f" }), Operaciones.Empty(), true,
                new string[] { "7f7f7f", "c3c3c3", "9ad9ea", "ffffff", "9ad9ea", "c3c3c3", "7f7f7f" }, null)
            },
            {
                Diseños.Demidiamoric, new Banderas(Diseños.Demidiamoric, "Demidiamoric", 6,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "91F291" }, new decimal[4] { 0m, 0m / 6m, 1m, 2.5m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "303030" }, new decimal[4] { 0m, 2.5m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "91F291" }, new decimal[4] { 0m, 3.5m / 6m, 1m, 2.5m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "FFFFFF" }, new decimal[]
                    {
                        0m, 0m,
                        1930m / 5000m, 0.5m,
                        0m, 1m
                    }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "000000" }, new decimal[4] { 44m / 1000m, 200m / 600m, 205m / 1000m, 200m / 600m }, "Diamoric.png"),
                },
                Operaciones.Empty(), true,
                new string[] { "91F291", "303030", "91F291" },
                new decimal[]{ 2.5m / 6m, 1m / 6m, 2.5m / 6m })
            },
            {
                Diseños.Demifluid, new Banderas(Diseños.Demifluid, "Demifluid", 7,
                 new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "7F7F7F" }, new decimal[4] { 0m, 0m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "C4C4C4" }, new decimal[4] { 0m, 1m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo_Degradado, new string[] { "FFB0CA", "FBFF75", "9BDAEC" }, new decimal[4] { 0m, 2m / 7m, 1m, 1m / 7m }, LinearGradientMode.Horizontal),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 3m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo_Degradado, new string[] { "FFB0CA", "FBFF75", "9BDAEC" }, new decimal[4] { 0m, 4m / 7m, 1m, 1m / 7m }, LinearGradientMode.Horizontal),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "C4C4C4" }, new decimal[4] { 0m, 5m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "7F7F7F" }, new decimal[4] { 0m, 6m / 7m, 1m, 1m / 7m }),
                },
                Operaciones.Empty(), true,
                new string[] { "7F7F7F", "C4C4C4", "FFB0CA", "FBFF75", "9BDAEC", "FFFFFF", "FFB0CA", "FBFF75", "9BDAEC", "C4C4C4", "7F7F7F" },
                new decimal[]{ 1m / 7m, 1m / 7m, 1m / 21m, 1m / 21m, 1m / 21m, 1m / 7m, 1m / 21m, 1m / 21m, 1m / 21m, 1m / 7m, 1m / 7m })
            },
            {
                Diseños.Demiflux, new Banderas(Diseños.Demiflux, "Demiflux", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "7F7F7F", "DADADA", "FFB3B8", "F5F691", "9DDAEC", "DADADA", "7F7F7F" }), Operaciones.Empty(), true,
                new string[] { "7F7F7F", "DADADA", "FFB3B8", "F5F691", "9DDAEC", "DADADA", "7F7F7F" }, null)
            },
            {
                Diseños.Demigender, new Banderas(Diseños.Demigender, "Demigender", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "7f7f7f", "c3c3c3", "fbff74", "ffffff", "fbff74", "c3c3c3", "7f7f7f" }), Operaciones.Empty(), true,
                new string[] { "7f7f7f", "c3c3c3", "fbff74", "ffffff", "fbff74", "c3c3c3", "7f7f7f" }, null)
            },
            {
                Diseños.Demigirl, new Banderas(Diseños.Demigirl, "Demigirl", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "7f7f7f", "c3c3c3", "feaec9", "ffffff", "feaec9", "c3c3c3", "7f7f7f" }), Operaciones.Empty(), true,
                new string[] { "7f7f7f", "c3c3c3", "feaec9", "ffffff", "feaec9", "c3c3c3", "7f7f7f" }, null)
            },
            /*{
                Diseños.Demiromantic, new Banderas("Demiromantic",
                "Demiromantic describes people who do not experience romantic attraction until they have formed a deep emotional connection with someone, according to the most common definition. Other definitions of this romantic orientation are only experiencing limited romantic attraction, or falling somewhere on a spectrum between aromantic and romantic; the latter definition overlaps with one for grayromantic.",
                Operaciones.Rectángulos_Horizontales(new string[] { "" }), Operaciones.Empty(), true,
                new string[] { "" }, null)
            },*/
            {
                Diseños.Demiromantic, new Banderas(Diseños.Demiromantic, "Demiromantic", 6,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 0m / 6m, 1m, 2.5m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "3DA542" }, new decimal[4] { 0m, 2.5m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D2D2D2" }, new decimal[4] { 0m, 3.5m / 6m, 1m, 2.5m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "000000" }, new decimal[]
                    {
                        0m, 0m,
                        1930m / 5000m, 0.5m,
                        0m, 1m
                    }),
                },
                Operaciones.Empty(), true,
                new string[] { "FFFFFF", "3DA542", "D2D2D2" },
                new decimal[]{ 2.5m / 6m, 1m / 6m, 2.5m / 6m })
            },
            {
                Diseños.Demisexual, new Banderas(Diseños.Demisexual, "Demisexual", 6,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 0m / 6m, 1m, 2.5m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "6E0070" }, new decimal[4] { 0m, 2.5m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D2D2D2" }, new decimal[4] { 0m, 3.5m / 6m, 1m, 2.5m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "000000" }, new decimal[]
                    {
                        0m, 0m,
                        1930m / 5000m, 0.5m,
                        0m, 1m
                    }),
                },
                Operaciones.Empty(), true,
                new string[] { "FFFFFF", "6E0070", "D2D2D2" },
                new decimal[]{ 2.5m / 6m, 1m / 6m, 2.5m / 6m })
            },
            {
                Diseños.Desinoromantic, new Banderas(Diseños.Desinoromantic, "Desinoromantic", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF93FF", "4B4B4B", "94FEA1" }), Operaciones.Empty(), true,
                new string[] { "FF93FF", "4B4B4B", "94FEA1" }, null)
            },
            {
                Diseños.Diamoric, new Banderas(Diseños.Diamoric, "Diamoric", 3,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "91F291" }, new decimal[4] { 0m, 0m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 1m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "91F291" }, new decimal[4] { 0m, 2m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "66023C" }, new decimal[4] { 766m / 1920m, 386m / 1152m, 389m / 1920m, 380m / 1152m }, "Diamoric.png"),
                },
                Operaciones.Empty(), true,
                new string[] { "91F291", "FFFFFF", "91F291" }, null)
            },
            {
                Diseños.Disability, new Banderas(Diseños.Disability, "Disability", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "EABF3F", "CFD1D0", "D3984A" }), Operaciones.Empty(), true,
                new string[] { "EABF3F", "CFD1D0", "D3984A" }, null)
            },
            {
                Diseños.Disability_2, new Banderas(Diseños.Disability_2, "Disability #2", 1,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "595959" }, new decimal[4] { 0m, 0m, 1m, 1m }),

                    /*new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "CF7280" }, new decimal[] {  }),
                    new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "EEDE77" }, new decimal[] {  }),
                    new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "E8E8E8" }, new decimal[] { 0m, 0m, -0.0625m, -0.0625m, 0.125m, 0m,  }),
                    new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "7BC2E0" }, new decimal[] {  }),
                    new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "3BB07D" }, new decimal[] {  }),*/
                },
                Operaciones.Empty(), false,
                new string[] { "595959" }, null)
            },
            /*{
                Diseños.Drapeau_cochin, new Banderas("Drapeau cochin",
                "",
                Operaciones.Rectángulos_Horizontales(new string[] { "FF0000", "FFFF00", "00FFFF" }), Operaciones.Empty(), true,
                new string[] { "FF0000", "FFFF00", "00FFFF" }, null)
            },*/
            {
                Diseños.Egogender, new Banderas(Diseños.Egogender, "Egogender", 9,
                Operaciones.Rectángulos_Horizontales(new string[] { "8200C1", "5B00D1", "007DD0", "00CBFE", "FEE300", "00CBFE", "007DD0", "5B00D1", "8200C1" }), Operaciones.Empty(), true,
                new string[] { "8200C1", "5B00D1", "007DD0", "00CBFE", "FEE300", "00CBFE", "007DD0", "5B00D1", "8200C1" }, null)
            },
            {
                Diseños.Enbitor, new Banderas(Diseños.Enbitor, "Enbitor", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FADD41", "FFEFA4", "5AB4F3", "FFEFA4", "FADD41" }), Operaciones.Empty(), true,
                new string[] { "FADD41", "FFEFA4", "5AB4F3", "FFEFA4", "FADD41" }, null)
            },
            {
                Diseños.Enbitor_2, new Banderas(Diseños.Enbitor_2, "Enbitor #2", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "7B2AB0", "873CB7", "944FC4", "FFE080", "7FADFF", "6697E8", "4C81D3" }), Operaciones.Empty(), false,
                new string[] { "7B2AB0", "873CB7", "944FC4", "FFE080", "7FADFF", "6697E8", "4C81D3" }, null)
            },
            {
                Diseños.Enbitor_3, new Banderas(Diseños.Enbitor_3, "Enbitor #3", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFFFFF", "D2E5FF", "B1CFFF", "FFF57D", "C6AAFF", "E0D4FF", "FFFFFF" }), Operaciones.Empty(), false,
                new string[] { "FFFFFF", "D2E5FF", "B1CFFF", "FFF57D", "C6AAFF", "E0D4FF", "FFFFFF" }, null)
            },
            {
                Diseños.Fa_afafine, new Banderas(Diseños.Fa_afafine, "Faʻafafine (Samoa)", 3,
                Operaciones.Rectángulos_Verticales(new string[] { "8E2018", "FFD65B", "8E2018" }), Operaciones.Empty(), true,
                new string[] { "8E2018", "FFD65B", "8E2018" }, null)
            },
            {
                Diseños.Female, new Banderas(Diseños.Female, "Female", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "F9359C", "FB7DBF", "FEDAED", "FECFE8", "FB7DBF", "F9359C" }), Operaciones.Empty(), false,
                new string[] { "F9359C", "FB7DBF", "FEDAED", "FECFE8", "FB7DBF", "F9359C" }, null)
            },
            {
                Diseños.Feminine, new Banderas(Diseños.Feminine, "Feminine", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "E31D99", "EA618D", "F19B9A", "ED7A63", "E5632B" }), Operaciones.Empty(), false,
                new string[] { "E31D99", "EA618D", "F19B9A", "ED7A63", "E5632B" }, null)
            },
            {
                Diseños.Femme, new Banderas(Diseños.Femme, "Femme", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "8D25AC", "A359BB", "C384D7", "FFFFFF", "E7BFE8", "CF72C2", "A12B96" }), Operaciones.Empty(), true,
                new string[] { "8D25AC", "A359BB", "C384D7", "FFFFFF", "E7BFE8", "CF72C2", "A12B96" }, null)
            },
            {
                Diseños.Femsexual, new Banderas(Diseños.Femsexual, "Femsexual [by dreamcast-official] [January 21, 2019]", 13,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF73CA", "FEA0DC", "FCBEE5", "FDCFEC", "FFE2F4", "FFEFFA", "FFFFFF", "FCDCE7", "FFCFDF", "FEB8D2", "FFA6C4", "FF89B1", "FF679A" }), Operaciones.Empty(), true,
                new string[] { "FF73CA", "FEA0DC", "FCBEE5", "FDCFEC", "FFE2F4", "FFEFFA", "FFFFFF", "FCDCE7", "FFCFDF", "FEB8D2", "FFA6C4", "FF89B1", "FF679A" }, null)
            },
            {
                Diseños.Femsexual_2, new Banderas(Diseños.Femsexual_2, "Femsexual #2 [by lithigender] [February 25, 2020]", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "94A1F0", "CF94F0", "F094A4" }), Operaciones.Empty(), false,
                new string[] { "94A1F0", "CF94F0", "F094A4" }, null)
            },
            {
                Diseños.Femsexual_3, new Banderas(Diseños.Femsexual_3, "Femsexual #3 [by HakuoTan] [June 15, 2020]", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "E2318F", "F0547D", "F67D7F", "E4946F", "EEC379", "FFF2A3", "F7FFD2" }), Operaciones.Empty(), false,
                new string[] { "E2318F", "F0547D", "F67D7F", "E4946F", "EEC379", "FFF2A3", "F7FFD2" }, null)
            },
            {
                Diseños.Fingender, new Banderas(Diseños.Fingender, "Fingender (FIN)", 8,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F9E4A6" }, new decimal[4] { 0m, 0m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F9BBA6" }, new decimal[4] { 0m, 1m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F29DBB" }, new decimal[4] { 0m, 2m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F051AC" }, new decimal[4] { 0m, 3m / 8m, 1m, 2m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D17EE2" }, new decimal[4] { 0m, 5m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "AE82DF" }, new decimal[4] { 0m, 6m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "8385DE" }, new decimal[4] { 0m, 7m / 8m, 1m, 1m / 8m }),
                },
                Operaciones.Empty(), true,
                new string[] { "F9E4A6", "F9BBA6", "F29DBB", "F051AC", "D17EE2", "AE82DF", "8385DE" },
                new decimal[]{ 1m / 8m, 1m / 8m, 1m / 8m, 2m / 8m, 1m / 8m, 1m / 8m, 1m / 8m })
            },
            {
                Diseños.Finsexual, new Banderas(Diseños.Finsexual, "Finsexual", 7,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FE5BA9" }, new decimal[4] { 0m, 0m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FEAFC9" }, new decimal[4] { 0m, 1m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFCFB9" }, new decimal[4] { 0m, 2m / 7m, 1m, 3m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FEAFC9" }, new decimal[4] { 0m, 5m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FE5BA9" }, new decimal[4] { 0m, 6m / 7m, 1m, 1m / 7m }),
                },
                Operaciones.Empty(), true,
                new string[] { "FE5BA9", "FEAFC9", "FFCFB9", "FEAFC9", "FE5BA9" },
                new decimal[]{ 1m / 7m, 1m / 7m, 3m / 7m, 1m / 7m, 1m / 7m })
            },
            {
                Diseños.Floric, new Banderas(Diseños.Floric, "Floric", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "00D697", "24E9A3", "56FFB7", "FFFFFF", "62B4D1", "389ABD", "0075A4" }), Operaciones.Empty(), false,
                new string[] { "00D697", "24E9A3", "56FFB7", "FFFFFF", "62B4D1", "389ABD", "0075A4" }, null)
            },
            {
                Diseños.Fluidflux, new Banderas(Diseños.Fluidflux, "Fluidflux", 14,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FF115F" }, new decimal[4] { 0m / 4m, 0m, 1m / 4m, 1m / 2m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A945A2" }, new decimal[4] { 1m / 4m, 0m, 1m / 4m, 1m / 2m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "00A1E8" }, new decimal[4] { 2m / 4m, 0m, 1m / 4m, 1m / 2m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFDF00" }, new decimal[4] { 3m / 4m, 0m, 1m / 4m, 1m / 2m }),

                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FF8CB0" }, new decimal[4] { 0m / 4m, 1m / 2m, 1m / 4m, 1m / 2m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "DBADDA" }, new decimal[4] { 1m / 4m, 1m / 2m, 1m / 4m, 1m / 2m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "83DBFF" }, new decimal[4] { 2m / 4m, 1m / 2m, 1m / 4m, 1m / 2m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFED71" }, new decimal[4] { 3m / 4m, 1m / 2m, 1m / 4m, 1m / 2m }),

                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0.0m, 5.5m / 13m, 1m, 2m / 14m }),
                },
                Operaciones.Empty(), true,
                new string[] { "FF115F", "A945A2", "00A1E8", "FFDF00", "000000", "FF8CB0", "DBADDA", "83DBFF", "FFED71" },
                new decimal[]{ 1.5m / 14m, 1.5m / 14m, 1.5m / 14m, 1.5m / 14m, 2m / 14m, 1.5m / 14m, 1.5m / 14m, 1.5m / 14m, 1.5m / 14m })
            },
            {
                Diseños.Frayromantic, new Banderas(Diseños.Frayromantic, "Frayromantic", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "636363", "BABABA", "FFFFFF", "94E7D2", "226C90" }), Operaciones.Empty(), true,
                new string[] { "636363", "BABABA", "FFFFFF", "94E7D2", "226C90" }, null)
            },
            {
                Diseños.Fraysexual, new Banderas(Diseños.Fraysexual, "Fraysexual", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "216CB4", "94E7DC", "FFFFFF", "636363" }), Operaciones.Empty(), true,
                new string[] { "216CB4", "94E7DC", "FFFFFF", "636363" }, null)
            },
            {
                Diseños.G0y, new Banderas(Diseños.G0y, "G0y (Brazilian)", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "010080", "444FA1", "FFFFFF", "017CC2" }), Operaciones.Empty(), true,
                new string[] { "010080", "444FA1", "FFFFFF", "017CC2" }, null)
            },
            {
                Diseños.Gardenia, new Banderas(Diseños.Gardenia, "Gardenia", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "E394EF", "5A5A5A", "FFE374" }), Operaciones.Empty(), true,
                new string[] { "E394EF", "5A5A5A", "FFE374" }, null)
            },
            {
                Diseños.Gardeniaro, new Banderas(Diseños.Gardeniaro, "Gardeniaro", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "E394EF", "9AFF92", "FFE374" }), Operaciones.Empty(), true,
                new string[] { "E394EF", "9AFF92", "FFE374" }, null)
            },
            {
                Diseños.Gardeniasexual, new Banderas(Diseños.Gardeniasexual, "Gardeniasexual (ace)", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "E394EF", "FF6BC4", "FFE374" }), Operaciones.Empty(), true,
                new string[] { "E394EF", "FF6BC4", "FFE374" }, null)
            },
            {
                Diseños.Gardeniaaroace, new Banderas(Diseños.Gardeniaaroace, "Gardenia aroace", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "E394EF", "6BD8FF", "FFE374" }), Operaciones.Empty(), true,
                new string[] { "E394EF", "6BD8FF", "FFE374" }, null)
            },
            {
                Diseños.Gay___1979__, new Banderas(Diseños.Gay___1979__, "Gay [1979]", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "E40303", "FF8C00", "FFED00", "008026", "004DFF", "750787" }), Operaciones.Empty(), true,
                new string[] { "E40303", "FF8C00", "FFED00", "008026", "004DFF", "750787" }, null)
            },
            {
                Diseños.Gay_7_stripes, new Banderas(Diseños.Gay_7_stripes, "Gay (7 stripes)", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF0000", "FF8E00", "FFFF00", "008E00", "00C0C0", "400098", "8E008E" }), Operaciones.Empty(), false,
                new string[] { "FF0000", "FF8E00", "FFFF00", "008E00", "00C0C0", "400098", "8E008E" }, null)
            },
            {
                Diseños.Gay_8_stripes, new Banderas(Diseños.Gay_8_stripes, "Gay (8 stripes)", 8,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF69B4", "FF0000", "FF8E00", "FFFF00", "008E00", "00C0C0", "400098", "8E008E" }), Operaciones.Empty(), false,
                new string[] { "FF69B4", "FF0000", "FF8E00", "FFFF00", "008E00", "00C0C0", "400098", "8E008E" }, null)
            },
            /*{
                Diseños.Gay_Gilbert_Baker___1978__, new Banderas("Gay (Gilbert Baker) [1978]", 8,
                "",
                Operaciones.Rectángulos_Horizontales(new string[] { "ff69b5", "ff0000", "ff8f00", "ffff00", "008f00", "00c1c1", "3e0099", "8f008f" }), Operaciones.Empty(), false,
                new string[] { "ff69b5", "ff0000", "ff8f00", "ffff00", "008f00", "00c1c1", "3e0099", "8f008f" }, null)
            },*/
            {
                Diseños.Gay_8_stripes_Philadelphia, new Banderas(Diseños.Gay_8_stripes_Philadelphia, "Gay (8 stripes, Philadelphia)", 8,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "784F17", "E40303", "FF8C00", "FFED00", "008026", "004DFF", "750787" }), Operaciones.Empty(), true,
                new string[] { "000000", "784F17", "E40303", "FF8C00", "FFED00", "008026", "004DFF", "750787" }, null)
            },
            /*{
                Diseños.Gay_Philadelphia___2017__, new Banderas("Gay (Philadelphia) [2017]", 8,
                "",
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "794e10", "e40303", "ff8c00", "ffed00", "008026", "004dff", "750787" }), Operaciones.Empty(), false,
                new string[] { "000000", "794e10", "e40303", "ff8c00", "ffed00", "008026", "004dff", "750787" }, null)
            },*/
            {
                Diseños.Gay_9_stripes___2017__, new Banderas(Diseños.Gay_9_stripes___2017__, "Gay (9 stripes) [2017]", 9,
                Operaciones.Rectángulos_Horizontales(new string[] { "CD66FF", "FF6599", "FF0000", "FF9900", "FFFF01", "009A00", "0099CB", "340099", "990099" }), Operaciones.Empty(), false,
                new string[] { "CD66FF", "FF6599", "FF0000", "FF9900", "FFFF01", "009A00", "0099CB", "340099", "990099" }, null)
            },
            {
                Diseños.Gay_9_stripes_diversity, new Banderas(Diseños.Gay_9_stripes_diversity, "Gay (9 stripes, diversity)", 9,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF69B4", "FF0000", "FF8E00", "FFFF00", "FFFFFF", "008E00", "00C0C0", "400098", "8E008E" }), Operaciones.Empty(), false,
                new string[] { "FF69B4", "FF0000", "FF8E00", "FFFF00", "FFFFFF", "008E00", "00C0C0", "400098", "8E008E" }, null)
            },
            {
                Diseños.Gay_Israel, new Banderas(Diseños.Gay_Israel, "Gay (Israel)", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "E40303", "FF8C00", "FFFF00", "008026", "004DFF", "750787" }), Operaciones.Empty(), false,
                new string[] { "E40303", "FF8C00", "FFFF00", "008026", "004DFF", "750787" }, null)
            },
            {
                Diseños.Gay_man, new Banderas(Diseños.Gay_man, "Gay Man", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "7BBDFF", "9DCEFF", "C6E4FF", "FFFFFF", "7BADE3", "1483CB", "093372" }), Operaciones.Empty(), true,
                new string[] { "7BBDFF", "9DCEFF", "C6E4FF", "FFFFFF", "7BADE3", "1483CB", "093372" }, null)
            },
            {
                Diseños.Gay_man_2, new Banderas(Diseños.Gay_man_2, "Gay Man #2", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "078D70", "26CEAA", "98E8C1", "FFFFFF", "7BADE2", "5049CC", "3D1A78" }), Operaciones.Empty(), false,
                new string[] { "078D70", "26CEAA", "98E8C1", "FFFFFF", "7BADE2", "5049CC", "3D1A78" }, null)
            },
            {
                Diseños.Gay_man_3, new Banderas(Diseños.Gay_man_3, "Gay Man #3", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "078D70", "99E8C2", "FFFFFF", "7BADE3", "3E1A78" }), Operaciones.Empty(), false,
                new string[] { "078D70", "99E8C2", "FFFFFF", "7BADE3", "3E1A78" }, null)
            },
            {
                Diseños.Gay_man_4, new Banderas(Diseños.Gay_man_4, "Gay Man #4", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "0C7C6B", "42A4A5", "5CC8D1", "F1EEFF", "7BADE3", "1483CB", "06336F" }), Operaciones.Empty(), false,
                new string[] { "0C7C6B", "42A4A5", "5CC8D1", "F1EEFF", "7BADE3", "1483CB", "06336F" }, null)
            },
            {
                Diseños.Gay_man_5, new Banderas(Diseños.Gay_man_5, "Gay Man #5", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "FEFEFE", "36C970", "217944" }), Operaciones.Empty(), false,
                new string[] { "FEFEFE", "36C970", "217944" }, null)
            },
            {
                Diseños.Gayan, new Banderas(Diseños.Gayan, "Gayan", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "7346A4", "5E83C1", "68BBA0", "EDCF76", "E3895E", "C1336C" }), Operaciones.Empty(), false,
                new string[] { "7346A4", "5E83C1", "68BBA0", "EDCF76", "E3895E", "C1336C" }, null)
            },
            {
                Diseños.Gender_neutral, new Banderas(Diseños.Gender_neutral, "Gender neutral", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFF433", "FFFFFF", "C0F78E", "23B14E" }), Operaciones.Empty(), true,
                new string[] { "FFF433", "FFFFFF", "C0F78E", "23B14E" }, null)
            },
            {
                Diseños.Gender_non_conforming, new Banderas(Diseños.Gender_non_conforming, "Gender non conforming", 13,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "50284D" }, new decimal[4] { 0m, 0m / 13m, 1m, 4m / 13m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "96467B" }, new decimal[4] { 0m, 4m / 13m, 1m, 1m / 13m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "5C96F7" }, new decimal[4] { 0m, 5m / 13m, 1m, 1m / 13m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFE6F7" }, new decimal[4] { 0m, 6m / 13m, 1m, 1m / 13m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "5C96F7" }, new decimal[4] { 0m, 7m / 13m, 1m, 1m / 13m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "96467B" }, new decimal[4] { 0m, 8m / 13m, 1m, 1m / 13m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "50284D" }, new decimal[4] { 0m, 9m / 13m, 1m, 4m / 13m }),
                },
                //Operaciones.Rectángulos_Horizontales(new string[] { "50284D", "50284D", "50284D", "50284D", "96467B", "5C96F7", "FFE6F7", "5C96F7", "96467B", "50284D", "50284D", "50284D", "50284D" }),
                Operaciones.Empty(), true,
                new string[] { "50284D", "96467B", "5C96F7", "FFE6F7", "5C96F7", "96467B", "50284D" },
                new decimal[]{ 4m / 13m, 1m / 13m, 1m / 13m, 1m / 13m, 1m / 13m, 1m / 13m, 4m / 13m })
            },
            {
                Diseños.Genderfae, new Banderas(Diseños.Genderfae, "Genderfae", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "97C3A4", "C4DEAE", "F9FACC", "FFFFFF", "FCA2C5", "DB8AE5", "A97EDF" }), Operaciones.Empty(), true,
                new string[] { "97C3A4", "C4DEAE", "F9FACC", "FFFFFF", "FCA2C5", "DB8AE5", "A97EDF" }, null)
            },
            {
                Diseños.Genderfaun, new Banderas(Diseños.Genderfaun, "Genderfaun", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "FCC689", "FFF09D", "FBF9CC", "FFFFFF", "8EDEDA", "8BACDE", "9781EB" }), Operaciones.Empty(), true,
                new string[] { "FCC689", "FFF09D", "FBF9CC", "FFFFFF", "8EDEDA", "8BACDE", "9781EB" }, null)
            },
            {
                Diseños.Genderflor, new Banderas(Diseños.Genderflor, "Genderflor", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "95C4A4", "C2DEAE", "F9FACE", "FFFFFF", "FBF9CC", "FFF09D", "FCC689" }), Operaciones.Empty(), true,
                new string[] { "95C4A4", "C2DEAE", "F9FACE", "FFFFFF", "FBF9CC", "FFF09D", "FCC689" }, null)
            },
            {
                Diseños.Genderfluff, new Banderas(Diseños.Genderfluff, "Genderfluff", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "DEE9FC", "FBE9ED", "FCFFD5", "FFFFFF", "FCFFD5", "FBE9ED", "DEE9FC" }), Operaciones.Empty(), true,
                new string[] { "DEE9FC", "FBE9ED", "FCFFD5", "FFFFFF", "FCFFD5", "FBE9ED", "DEE9FC" }, null)
            },
            {
                Diseños.Genderfluid___2012__, new Banderas(Diseños.Genderfluid___2012__, "Genderfluid [2012]", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF75A2", "FFFFFF", "BE18D6", "000000", "333EBD" }), Operaciones.Empty(), true,
                new string[] { "FF75A2", "FFFFFF", "BE18D6", "000000", "333EBD" }, null)
            },
            {
                Diseños.Genderfluid_2, new Banderas(Diseños.Genderfluid_2, "Genderfluid #2", 9,
                Operaciones.Rectángulos_Horizontales(new string[] { "FE7FB5", "FFBFD9", "FFFFFF", "D6A5FE", "AE4CFF", "D6A5FE", "FFFFFF", "9BC9FF", "3992FF" }), Operaciones.Empty(), false,
                new string[] { "FE7FB5", "FFBFD9", "FFFFFF", "D6A5FE", "AE4CFF", "D6A5FE", "FFFFFF", "9BC9FF", "3992FF" }, null)
            },
            {
                Diseños.Genderflux, new Banderas(Diseños.Genderflux, "Genderflux", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "F47695", "F1A3B9", "CECECE", "7BE0F7", "3ECDFA", "FDF58C" }), Operaciones.Empty(), true,
                new string[] { "F47695", "F1A3B9", "CECECE", "7BE0F7", "3ECDFA", "FDF58C" }, null)
            },
            {
                Diseños.Genderfuck, new Banderas(Diseños.Genderfuck, "Genderfuck", 0,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFF8C6" }, new decimal[4] { 0m, 0m, 1m, 1m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "9D69A1" }, new decimal[4] { 229m / 5000m, 229m / 3000m, 4542m / 5000m, 2542m / 3000m }),
                },
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Círculo, new string[] { "FFF8C6" }, new decimal[4] { 1472m / 5000m, 472m / 3000m, 2056m / 5000m, 2056m / 3000m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Círculo, new string[] { "9D69A1" }, new decimal[4] { 1403m / 5000m, 614m / 3000m, 900m / 5000m, 900m / 3000m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Círculo, new string[] { "9D69A1" }, new decimal[4] { 2699m / 5000m, 614m / 3000m, 900m / 5000m, 900m / 3000m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Círculo, new string[] { "9D69A1" }, new decimal[4] { 2159m / 5000m, 2307m / 3000m, 100m / 5000m, 400m / 3000m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Círculo, new string[] { "9D69A1" }, new decimal[4] { 2451m / 5000m, 2307m / 3000m, 100m / 5000m, 400m / 3000m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Círculo, new string[] { "9D69A1" }, new decimal[4] { 2742m / 5000m, 2307m / 3000m, 100m / 5000m, 400m / 3000m }),
                },
                true,
                new string[] { "FFF8C6", "9D69A1", "FFF8C6" },
                new decimal[]{ 229m / 3000m, 2542m / 3000m, 229m / 3000m })
            },
            {
                Diseños.Genderless, new Banderas(Diseños.Genderless, "Genderless", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "2A2A2A", "C49CE3", "FFFFFF", "FFEE8C", "FFFFFF", "A9DC9D", "2A2A2A" }), Operaciones.Empty(), true,
                new string[] { "2A2A2A", "C49CE3", "FFFFFF", "FFEE8C", "FFFFFF", "A9DC9D", "2A2A2A" }, null)
            },
            {
                Diseños.Genderless_2, new Banderas(Diseños.Genderless_2, "Genderless #2", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "2D2D2D", "8B65A5", "FFFFFF", "FFE987", "FFFFFF", "8B65A5", "2D2D2D" }), Operaciones.Empty(), true,
                new string[] { "2D2D2D", "8B65A5", "FFFFFF", "FFE987", "FFFFFF", "8B65A5", "2D2D2D" }, null)
            },
            {
                Diseños.Genderpunk, new Banderas(Diseños.Genderpunk, "Genderpunk", 0,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "050409" }, new decimal[4] { 0m, 0m, 1m, 334m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "2D122B" }, new decimal[4] { 0m, 334m / 3000m, 1m, 499m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 833m / 3000m, 1m, 168m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "8B1B1A" }, new decimal[4] { 0m, 1001m / 3000m, 1m, 333m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "050409" }, new decimal[4] { 0m, 1334m / 3000m, 1m, 333m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "0A2438" }, new decimal[4] { 0m, 1667m / 3000m, 1m, 333m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 2000m / 3000m, 1m, 167m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "2D122B" }, new decimal[4] { 0m, 2167m / 3000m, 1m, 499m / 3000m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "050409" }, new decimal[4] { 0m, 2666m / 3000m, 1m, 334m / 3000m }),
                },
                Operaciones.Empty(), true,
                new string[] { "050409", "2D122B", "FFFFFF", "8B1B1A", "050409", "0A2438", "FFFFFF", "2D122B", "050409" },
                new decimal[]{ 334m / 3000m, 499m / 3000m, 168m / 3000m, 333m / 3000m, 333m / 3000m, 333m / 3000m, 167m / 3000m, 499m / 3000m, 334m / 3000m })
            },
            {
                Diseños.Genderqueer___2011__, new Banderas(Diseños.Genderqueer___2011__, "Genderqueer [2011]", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "B57EDC", "FFFFFF", "4A8123" }), Operaciones.Empty(), true,
                new string[] { "B57EDC", "FFFFFF", "4A8123" }, null)
            },
            {
                Diseños.Girlflux, new Banderas(Diseños.Girlflux, "Girlflux", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "F8E7D6", "F3526B", "BF0310", "E8C586", "BF0310", "F3526B", "F8E7D6" }), Operaciones.Empty(), true,
                new string[] { "F8E7D6", "F3526B", "BF0310", "E8C586", "BF0310", "F3526B", "F8E7D6" }, null)
            },
            {
                Diseños.Gray_aromantic, new Banderas(Diseños.Gray_aromantic, "Gray-aromantic", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "087D16", "B0B2AF", "FFFFFF", "B0B2AF", "087D16" }), Operaciones.Empty(), true,
                new string[] { "087D16", "B0B2AF", "FFFFFF", "B0B2AF", "087D16" }, null)
            },
            {
                Diseños.Greygender, new Banderas(Diseños.Greygender, "Greygender", 14,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "C1BEBF" }, new decimal[4] { 0m, 0m, 1m, 4m / 14m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 4m / 14m, 1m, 1m / 14m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "082385" }, new decimal[4] { 0m, 5m / 14m, 1m, 4m / 14m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 9m / 14m, 1m, 1m / 14m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "525152" }, new decimal[4] { 0m, 10m / 14m, 1m, 4m / 14m }),
                },
                Operaciones.Empty(), true,
                new string[] { "C1BEBF", "FFFFFF", "082385", "FFFFFF", "525152" },
                new decimal[]{ 4m / 14m, 1m / 14m, 4m / 14m, 1m / 14m, 4m / 14m })
            },
            {
                Diseños.Greysexual, new Banderas(Diseños.Greysexual, "Greysexual", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "740194", "AEB1AA", "FFFFFF", "AEB1AA", "740194" }), Operaciones.Empty(), true,
                new string[] { "740194", "AEB1AA", "FFFFFF", "AEB1AA", "740194" }, null)
            },
            {
                Diseños.Gyneromantic, new Banderas(Diseños.Gyneromantic, "Gyneromantic", 3,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FAD0D7" }, new decimal[4] { 0m, 0m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "C2968C" }, new decimal[4] { 0m, 1m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A6C493" }, new decimal[4] { 0m, 2m / 3m, 1m, 1m / 3m }),
                },
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "F4AAB5" }, new decimal[4] { 0m, 0m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "903F2B" }, new decimal[4] { 0m, 1m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "5B953B" }, new decimal[4] { 0m, 2m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen_Recorte, new string[] { "FFFFFF" }, new decimal[] { 861m / 5000m, 0m / 3000m, 3277m / 5000m, 3000m / 3000m }, "Heart.png"),
                },
                true,
                new string[] { "FAD0D7", "C2968C", "A6C493" }, null)
            },
            {
                Diseños.Gyneromantic_2, new Banderas(Diseños.Gyneromantic_2, "Gyneromantic #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFFFFF", "DD80E1", "E180A7", "E18080", "DE9F4E" }), Operaciones.Empty(), false,
                new string[] { "FFFFFF", "DD80E1", "E180A7", "E18080", "DE9F4E" }, null)
            },
            {
                Diseños.Gynesexual, new Banderas(Diseños.Gynesexual, "Gynesexual", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "F5A9B8", "8F3F2B", "5B943A" }), Operaciones.Empty(), true,
                new string[] { "F5A9B8", "8F3F2B", "5B943A" }, null)
            },
            {
                Diseños.Hermaphrodite, new Banderas(Diseños.Hermaphrodite, "Hermaphrodite", 6,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FF8000" }, new decimal[4] { 0m, 0m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFC100" }, new decimal[4] { 0m, 1m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F7DE15" }, new decimal[4] { 0m, 2m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F7F619" }, new decimal[4] { 0m, 3m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "C0DE10" }, new decimal[4] { 0m, 4m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "7DBA21" }, new decimal[4] { 0m, 5m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "A000C0" }, new decimal[4] { 488m / 1154m, 177m / 696m, 178m / 1154m, 338m / 696m }, "Hermaphrodite.png"),
                    //new Operaciones(Dibujos.Rayas, Funciones.Imagen, new string[] { "A000C0" }, new decimal[4] { 487m / 1154m, 176m / 696m, 180m / 1154m, 340m / 696m }, "Hermaphrodite.png"),
                },
                //Operaciones.Rectángulos_Horizontales(new string[] { "FF8000", "FFC100", "F7DE15", "F7F619", "C0DE10", "7DBA21" }),
                //Operaciones.Rectángulos_Horizontales(new string[] { "B05801", "F5B702", "F9DE15", "F6F618", "BED910", "5C861A" }), Operaciones.Empty(), true,
                Operaciones.Empty(), true,
                new string[] { "FF8000", "FFC100", "F7DE15", "F7F619", "C0DE10", "7DBA21" }, null)
            },
            {
                Diseños.Heteroflexible, new Banderas(Diseños.Heteroflexible, "Heteroflexible", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "EE3124", "F57F29", "FFF000", "58B947", "0054A6", "9F248F" }),
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 0m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "333333" }, new decimal[4] { 0m, 1m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "666666" }, new decimal[4] { 0m, 2m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "999999" }, new decimal[4] { 0m, 3m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "BBBBBB" }, new decimal[4] { 0m, 4m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 5m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "00000000" }, new decimal[4] { 0.5m - 0.07125m, 0m, 0.1425m, 1m }),
                },
                true,
                new string[] { "000000", "333333", "666666", "999999", "BBBBBB", "FFFFFF" }, null)
            },
            {
                Diseños.Heteroqueer, new Banderas(Diseños.Heteroqueer, "Heteroqueer", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "90488C", "F978E6", "FBC4FD", "FFFFFF", "CFCFCF", "6C6C6C", "010101" }), Operaciones.Empty(), true,
                new string[] { "90488C", "F978E6", "FBC4FD", "FFFFFF", "CFCFCF", "6C6C6C", "010101" }, null)
            },
            {
                Diseños.Heterosexual, new Banderas(Diseños.Heterosexual, "Heterosexual", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "FFFFFF", "000000", "FFFFFF", "000000", "FFFFFF" }), Operaciones.Empty(), true,
                new string[] { "000000", "FFFFFF", "000000", "FFFFFF", "000000", "FFFFFF" }, null)
            },
            {
                Diseños.Heterosexual_2, new Banderas(Diseños.Heterosexual_2, "Heterosexual #2", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "333333", "666666", "999999", "BBBBBB", "FFFFFF" }), Operaciones.Empty(), false,
                new string[] { "000000", "333333", "666666", "999999", "BBBBBB", "FFFFFF" }, null)
            },
            {
                Diseños.Heterosexual_3, new Banderas(Diseños.Heterosexual_3, "Heterosexual #3", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "4687E5", "FFFFFF", "EF649F" }), Operaciones.Empty(), false,
                new string[] { "4687E5", "FFFFFF", "EF649F" }, null)
            },
            {
                Diseños.Hijra, new Banderas(Diseños.Hijra, "Hijra (India)", 9,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFCCE6" }, new decimal[4] { 0m, 0m / 9m, 1m, 3m / 9m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 3m / 9m, 1m, 1m / 9m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "C10000" }, new decimal[4] { 0m, 4m / 9m, 1m, 1m / 9m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 5m / 9m, 1m, 1m / 9m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "B9E0FB" }, new decimal[4] { 0m, 6m / 9m, 1m, 3m / 9m }),
                },
                //Operaciones.Rectángulos_Horizontales(new string[] { "FFCCE6", "FFCCE6", "FFCCE6", "FFFFFF", "C10000", "FFFFFF", "B9E0FB", "B9E0FB", "B9E0FB" }), 
                Operaciones.Empty(), true,
                new string[] { "FFCCE6", "FFFFFF", "C10000", "FFFFFF", "B9E0FB" },
                new decimal[]{ 3m / 9m, 1m / 9m, 1m / 9m, 1m / 9m, 3m / 9m})
            },
            {
                Diseños.Homoflexible, new Banderas(Diseños.Homoflexible, "Homoflexible", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "333333", "666666", "999999", "BBBBBB", "FFFFFF" }),
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "EE3124" }, new decimal[4] { 0m, 0m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "F57F29" }, new decimal[4] { 0m, 1m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "FFF000" }, new decimal[4] { 0m, 2m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "58B947" }, new decimal[4] { 0m, 3m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "0054A6" }, new decimal[4] { 0m, 4m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "9F248F" }, new decimal[4] { 0m, 5m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "00000000" }, new decimal[4] { 0.5m - 0.07125m, 0m, 0.1425m, 1m }),
                },
                true,
                new string[] { "EE3124", "F57F29", "FFF000", "58B947", "0054A6", "9F248F" }, null)
            },
            {
                Diseños.Iculasexual, new Banderas(Diseños.Iculasexual, "Iculasexual", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "C39EE4", "EFE3AF", "9AD9EA", "EFE3AF", "C39EE4" }), Operaciones.Empty(), true,
                new string[] { "C39EE4", "EFE3AF", "9AD9EA", "EFE3AF", "C39EE4" }, null)
            },
            {
                Diseños.Intergender, new Banderas(Diseños.Intergender, "Intergender [2020]", 4,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "910DC2" }, new decimal[4] { 0m, 0m, 1m, 0.375m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFE64F" }, new decimal[4] { 0m, 0.375m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "910DC2" }, new decimal[4] { 0m, 0.625m, 1m, 0.375m }),
                },
                //Operaciones.Empty(),
                new Operaciones[]
                {
                    //new Operaciones(Dibujos.Rayas, Funciones.Círculo, new string[] { "FFFFFF" }, new decimal[4] { 0.125m * (3m / 2m)/*((5m / 3m) / 2m) - 0.375m*/, 0.125m, 0.75m / (5m / 3m), 0.75m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Círculo, new string[] { "FFFFFF" }, new decimal[4] { 398m / 1422m, 106m / 853m, 653m / 1422m, 641m / 853m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Círculo, new string[] { "00000000" }, new decimal[4] { 476m / 1422m, 184m / 853m, 497m / 1422m, 485m / 853m }),
                    //new Operaciones(Dibujos.Rayas, Funciones.Círculo, new string[] { "FFFFFF" }, new decimal[4] { 398m / 1422m, 0.125m, 653m / 1422m, 0.75m }),
                    //new Operaciones(Dibujos.Rayas, Funciones.Círculo, new string[] { "FFFFFF" }, new decimal[4] { (0.25m * (5m / 3m)) / (3m / 2m), 0.125m, (0.5m * (5m / 3m)) / (3m / 2m), 0.75m }),
                    //new Operaciones(Dibujos.Rayas, Funciones.Círculo, new string[] { "FFFFFF" }, new decimal[4] { 0.25m * ((5m / 3m) - (3m / 2m)), 0.125m, 0.5m * ((5m / 3m) - (3m / 2m)), 0.75m }),
                    //new Operaciones(Dibujos.Rayas, Funciones.Círculo, new string[] { "FFD800" }, new decimal[4] { 0.37719298245614035087719298245614m, 0.29678362573099415204678362573099m, 0.24473684210526315789473684210526m, 0.40789473684210526315789473684211m }),
                }, true,
                new string[] { "910DC2", "FFE64F", "910DC2" }, new decimal[]{ 0.375m, 1m / 4m, 0.375m })
            },
            {
                Diseños.Intergender_2, new Banderas(Diseños.Intergender_2, "Intergender #2", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "78C4F8", "FFFFFF", "D592D4", "B3B3B3", "D592D4", "FFFFFF", "FFB4C2" }), Operaciones.Empty(), false,
                new string[] { "78C4F8", "FFFFFF", "D592D4", "B3B3B3", "D592D4", "FFFFFF", "FFB4C2" }, null)
            },
            {
                Diseños.Intergender_3, new Banderas(Diseños.Intergender_3, "Intergender #3", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF66AE", "7F7F7F", "FFDE21", "7F7F7F", "FFDE21", "7F7F7F", "37B8FF" }), Operaciones.Empty(), false,
                new string[] { "FF66AE", "7F7F7F", "FFDE21", "7F7F7F", "FFDE21", "7F7F7F", "37B8FF" }, null)
            },
            {
                Diseños.Intersex___2013__, new Banderas(Diseños.Intersex___2013__, "Intersex [2013]", 1,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFD800" }),
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Círculo, new string[] { "7902AA" }, new decimal[4] { 0.3280701754385964912280701754386m, 0.21491228070175438596491228070175m, 0.34298245614035087719298245614035m, 0.57163742690058479532163742690058m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Círculo, new string[] { "FFD800" }, new decimal[4] { 0.37719298245614035087719298245614m, 0.29678362573099415204678362573099m, 0.24473684210526315789473684210526m, 0.40789473684210526315789473684211m }),
                }, true,
                new string[] { "FFD800" }, null)
            },
            {
                Diseños.Intersex_2, new Banderas(Diseños.Intersex_2, "Intersex #2", 6,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "d7abcf" }, new decimal[4] { 0m, 0m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "ffffff" }, new decimal[4] { 0m, 1m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "9fcdef" }, new decimal[4] { 0m, 2m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "f0b8d5" }, new decimal[4] { 0m, 3m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo_Degradado, new string[] { "9fcdef", "f0b8d5" }, new decimal[4] { 0m, 2.5m / 6m, 1m, 1m / 6m }, LinearGradientMode.Vertical),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "ffffff" }, new decimal[4] { 0m, 4m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "d7abcf" }, new decimal[4] { 0m, 5m / 6m, 1m, 1m / 6m }),
                },
                Operaciones.Empty(), false,
                new string[] { "d7abcf", "ffffff", "9fcdef", "f0b8d5", "ffffff", "d7abcf" }, null)
            },
            {
                Diseños.Ipsogender, new Banderas(Diseños.Ipsogender, "Ipsogender [June 30, 2015]", 1,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "7902AA" }, new decimal[4] { 0m, 0m, 1m, 1m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Círculo, new string[] { "FFD800" }, new decimal[4] { 1796m / 5000, 796m / 3000m, 1408m / 5000m, 1408m / 3000m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Círculo, new string[] { "7902AA" }, new decimal[4] { 1956m / 5000, 956m / 3000m, 1088m / 5000m, 1088m / 3000m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "FFD800" }, new decimal[] { 2579m / 5000m, 876m / 3000m, 2579m / 5000m, 1417m / 3000m, 3124m / 5000m, 1417m / 3000m, 3124m / 5000m, 1576m / 3000m, 2579m / 5000m, 1576m / 3000m, 2579m / 5000m, 2124m / 3000m, 2420m / 5000m, 2124m / 3000m, 2420m / 5000m, 1576m / 3000m, 1876m / 5000m, 1576m / 3000m, 1876m / 5000m, 1417m / 3000m, 2420m / 5000m, 1417m / 3000m, 2420m / 5000m, 876m / 3000m, 2579m / 5000m, 876m / 3000m, }),
                },
                Operaciones.Empty(), false,
                new string[] { "7902AA" }, null)
            },
            {
                Diseños.Juvelic_orientations, new Banderas(Diseños.Juvelic_orientations, "Juvelic Orientations", 10,
                Operaciones.Rectángulos_Horizontales(new string[] { "3D85C6", "FF6969", "F6B26B", "FFD966", "FFFFFF", "763B9B", "262626", "717171", "FFFFFF", "FF7B8F" }), Operaciones.Empty(), true,
                new string[] { "3D85C6", "FF6969", "F6B26B", "FFD966", "FFFFFF", "763B9B", "262626", "717171", "FFFFFF", "FF7B8F" }, null)
            },
            {
                Diseños.Kathoey, new Banderas(Diseños.Kathoey, "Kathoey", 6,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "ED1C24" }, new decimal[4] { 0m, 0m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 1m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "241D4F" }, new decimal[4] { 0m, 2m / 6m, 1m, 2m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 4m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "ED1C24" }, new decimal[4] { 0m, 5m / 6m, 1m, 1m / 6m }),
                },
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "5BCEFA" }, new decimal[4] { 0m, 0m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "F5A9B8" }, new decimal[4] { 0m, 1m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 2m / 6m, 1m, 2m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "F5A9B8" }, new decimal[4] { 0m, 4m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "5BCEFA" }, new decimal[4] { 0m, 5m / 6m, 1m, 1m / 6m }),

                    new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "00000000" }, new decimal[] { 0m, 0m, 1m, 0m, 0m, 1m, 0m, 0m }),
                }, true,
                new string[] { "ED1C24", "FFFFFF", "241D4F", "FFFFFF", "ED1C24" },
                new decimal[] { 1m / 6m, 1m / 6m, 2m / 6m, 1m / 6m, 1m / 6m })
            },
            {
                Diseños.Khanith, new Banderas(Diseños.Khanith, "Khanith", 2,
                Operaciones.Rectángulos_Horizontales(new string[] { "F6A7BA", "63CAF3" }),
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Círculo, new string[] { "000000" }, new decimal[4] { 25m / 120m, 0m / 72m, 70m / 120m, 70m / 72m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Círculo, new string[] { "00000000" }, new decimal[4] { 31m / 120m, -7m / 72m, 58m / 120m, 58m / 72m }),
                },
                true,
                new string[] { "F6A7BA", "63CAF3" }, null)
            },
            {
                Diseños.Lapisian, new Banderas(Diseños.Lapisian, "Lapisian", 5,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "0A0F43" }, new decimal[4] { 0m, 0m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "1E269D" }, new decimal[4] { 0m, 1m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "5C6BDA" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "869FDE" }, new decimal[4] { 0m, 3m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D7E0F5" }, new decimal[4] { 0m, 4m / 5m, 1m, 1m / 5m }),
                    
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "F5C378" }, new decimal[] { 0.5m, 0m, 0.5m + (0.5m / (5m / 3m)), 0.5m, 0.5m, 1m, 0.5m - (0.5m / (5m / 3m)), 0.5m, 0.5m, 0m/*, 1m / (5m / 3m), 1m*/ }),
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "FFF0C6" }, new decimal[] { 0.5m, 0.09765625m, (0.5m + ((0.5m - 0.09765625m) / (5m / 3m))), 0.5m, 0.5m, 1m - 0.09765625m, (0.5m - ((0.5m - 0.09765625m) / (5m / 3m))), 0.5m, 0.5m, 0.09765625m }),
                },
                Operaciones.Empty(), true,
                new string[] { "0A0F43", "1E269D", "5C6BDA", "869FDE", "D7E0F5" }, null)
            },
            {
                Diseños.Leather_latex_and_BDSM, new Banderas(Diseños.Leather_latex_and_BDSM, "Leather latex and BDSM", 9,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "18186B", "000000", "18186B", "FFFFFF", "18186B", "000000", "18186B", "000000" }), Operaciones.Empty(), true,
                new string[] { "000000", "18186B", "000000", "18186B", "FFFFFF", "18186B", "000000", "18186B", "000000" }, null)
            },
            {
                Diseños.Leather_latex_and_BDSM___light__, new Banderas(Diseños.Leather_latex_and_BDSM___light__, "Leather latex and BDSM (light)", 9,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "2A2A7F", "000000", "2A2A7F", "FFFFFF", "2A2A7F", "000000", "2A2A7F", "000000" }), Operaciones.Empty(), false,
                new string[] { "000000", "2A2A7F", "000000", "2A2A7F", "FFFFFF", "2A2A7F", "000000", "2A2A7F", "000000" }, null)
            },
            {
                Diseños.Lesbian___2018__, new Banderas(Diseños.Lesbian___2018__, "Lesbian [2018]", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "D52D00", "EF7627", "FF9A56", "FFFFFF", "D162A4", "B55690", "A30262" }), Operaciones.Empty(), false,
                new string[] { "D52D00", "EF7627", "FF9A56", "FFFFFF", "D162A4", "B55690", "A30262" }, null)
            },
            {
                Diseños.Lesbian___2019__, new Banderas(Diseños.Lesbian___2019__, "Lesbian [2019]", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "D52D00", "FF9A56", "FFFFFF", "D162A4", "A30262" }), Operaciones.Empty(), true,
                new string[] { "D52D00", "FF9A56", "FFFFFF", "D162A4", "A30262" }, null)
            },
            {
                Diseños.Lesbian_Lydia_Maya_Kern, new Banderas(Diseños.Lesbian_Lydia_Maya_Kern, "Lesbian Lydia (Maya Kern's order)", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "663399", "FF6699", "FFCC33", "66CC33" }), Operaciones.Empty(), true,
                new string[] { "663399", "FF6699", "FFCC33", "66CC33" }, null)
            },
            {
                Diseños.Lesbian_Lydia_original, new Banderas(Diseños.Lesbian_Lydia_original, "Lesbian Lydia (original order)", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "663399", "FFCC33", "66CC33", "FF6699" }), Operaciones.Empty(), false,
                new string[] { "663399", "FFCC33", "66CC33", "FF6699" }, null)
            },
            {
                Diseños.Lesbian_butch, new Banderas(Diseños.Lesbian_butch, "Lesbian butch", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "D52C00", "F07528", "FF9A57", "FFFCEE", "FFCD88", "FFAD09", "A06E00" }), Operaciones.Empty(), true,
                new string[] { "D52C00", "F07528", "FF9A57", "FFFCEE", "FFCD88", "FFAD09", "A06E00" }, null)
            },
            {
                Diseños.Lesbian_butch_2, new Banderas(Diseños.Lesbian_butch_2, "Lesbian butch 2", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "324070", "6A7AA4", "8A92A9", "EDECEB", "C0B4DB", "764EC5", "51048A" }), Operaciones.Empty(), false,
                new string[] { "324070", "6A7AA4", "8A92A9", "EDECEB", "C0B4DB", "764EC5", "51048A" }, null)
            },
            {
                Diseños.Lesbian_labrys___1999__, new Banderas(Diseños.Lesbian_labrys___1999__, "Lesbian labrys [1999]", 1,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "993399" }, new decimal[4] { 0m, 0m, 1m, 1m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "000000" }, new decimal[] { 235m / 1000m, 70m / 600, 764m / 1000m, 70m / 600m, 0.5m, 528m / 600m, 235m / 1000m, 70m / 600 }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "FFFFFF" }, new decimal[4] { 388m / 1000m, 87m / 600m, 224m / 1000m, 379m / 600m }, "Lesbian_Labrys.png"),
                    //new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "000000" }, new decimal[] { 0.2119140625m, 0.08455284552845528455284552845528m, 0.7890625m, 0.08455284552845528455284552845528m, 0.5m, 0.91707317073170731707317073170732m, 0.2119140625m, 0.08455284552845528455284552845528m }),
                    //new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "d7abcf" }, new decimal[4] { 0m, 5m / 6m, 1m, 1m / 6m }),
                    //new Operaciones(Dibujos.Rayas, Funciones.Imagen, new string[] { "FFFFFF" }, new decimal[4] { 389m / 1000m, 88m / 600m, 222m / 1000m, 377m / 600m }, "Lesbian_Labrys.png"),
                },
                Operaciones.Empty(), false,
                new string[] { "993399", "000000", "993399" },
                new decimal[]{ 1.5m / 5m, 2m / 5m, 1.5m / 5m })
                //new decimal[]{ 0.08373983739837398373983739837398m, 0.83252032520325203252032520325204m, 0.08373983739837398373983739837398m })
            },
            {
                Diseños.Lesbian_lipstick___2010__, new Banderas(Diseños.Lesbian_lipstick___2010__, "Lesbian lipstick [2010]", 7,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A40061" }, new decimal[4] { 0m, 0m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "B75592" }, new decimal[4] { 0m, 1m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D063A6" }, new decimal[4] { 0m, 2m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "EDEDEB" }, new decimal[4] { 0m, 3m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "E4ACCF" }, new decimal[4] { 0m, 4m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "C54E54" }, new decimal[4] { 0m, 5m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "8A1E04" }, new decimal[4] { 0m, 6m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "000000" }, new decimal[4] { 0.041015625m, 0.04552845528455284552845528455285m, 0.2919921875m, 0.43252032520325203252032520325203m }, "Lipstick_lesbian.png"),
                },
                //Operaciones.Rectángulos_Horizontales(new string[] { "A40061", "B75592", "D063A6", "EDEDEB", "E4ACCF", "C54E54", "8A1E04" }),
                Operaciones.Empty(), false,
                new string[] { "A40061", "B75592", "D063A6", "EDEDEB", "E4ACCF", "C54E54", "8A1E04" }, null)
            },
            {
                Diseños.Lesbian_pink___2010__, new Banderas(Diseños.Lesbian_pink___2010__, "Lesbian pink [2010]", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "A40061", "B75592", "D063A6", "EDEDEB", "E4ACCF", "C54E54", "8A1E04" }), Operaciones.Empty(), true,
                new string[] { "A40061", "B75592", "D063A6", "EDEDEB", "E4ACCF", "C54E54", "8A1E04" }, null)
            },
            {
                Diseños.Lesbian_Pride_double_venus_canton_rainbow, new Banderas(Diseños.Lesbian_Pride_double_venus_canton_rainbow, "Lesbian pride double venus canton rainbow", 6,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "E40303" }, new decimal[4] { 0m, 0m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FF8C00" }, new decimal[4] { 0m, 1m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFED00" }, new decimal[4] { 0m, 2m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "008026" }, new decimal[4] { 0m, 3m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "2F93DA" }, new decimal[4] { 0m, 4m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "750787" }, new decimal[4] { 0m, 5m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "291C6C" }, new decimal[4] { 0m, 0m / 6m, 320m / 800m, 3m / 6m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "FFFFFF" }, new decimal[4] { 147m / 1920m, 83m / 1152m, 476m / 1920m, 427m / 1152m }, "Double_Venus.png"),
                },
                Operaciones.Empty(), false,
                new string[] { "E40303", "FF8C00", "FFED00", "008026", "2F93DA", "750787" }, null)
            },
            {
                Diseños.Lingender, new Banderas(Diseños.Lingender, "Lingender (LIN)", 8,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F051AD" }, new decimal[4] { 0m, 0m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F759F7" }, new decimal[4] { 0m, 1m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D23FF8" }, new decimal[4] { 0m, 2m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A748E6" }, new decimal[4] { 0m, 3m / 8m, 1m, 2m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "773FEB" }, new decimal[4] { 0m, 5m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "5A74EB" }, new decimal[4] { 0m, 6m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "40ADEE" }, new decimal[4] { 0m, 7m / 8m, 1m, 1m / 8m }),
                },
                Operaciones.Empty(), true,
                new string[] { "F051AD", "F759F7", "D23FF8", "A748E6", "773FEB", "5A74EB", "40ADEE" },
                new decimal[]{ 1m / 8m, 1m / 8m, 1m / 8m, 2m / 8m, 1m / 8m, 1m / 8m, 1m / 8m })
            },
            {
                Diseños.Lithromantic, new Banderas(Diseños.Lithromantic, "Lithromantic", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "F14952", "FF9E5E", "FFF546", "FFFFFF", "2A2A2A" }), Operaciones.Empty(), true,
                new string[] { "F14952", "FF9E5E", "FFF546", "FFFFFF", "2A2A2A" }, null)
            },
            {
                Diseños.Mahu, new Banderas(Diseños.Mahu, "Mahu", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "568E5A", "DA2526", "F4E66C" }), Operaciones.Empty(), true,
                new string[] { "568E5A", "DA2526", "F4E66C" }, null)
            },
            {
                Diseños.Maverique, new Banderas(Diseños.Maverique, "Maverique", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFF344", "FFFFFF", "F49622" }), Operaciones.Empty(), true,
                new string[] { "FFF344", "FFFFFF", "F49622" }, null)
            },
            {
                Diseños.Men_loving_men___Mlm__, new Banderas(Diseños.Men_loving_men___Mlm__, "Men loving men [Mlm]", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "078D70", "26CEAA", "99E8C2", "FFFFFF", "7BADE3", "5049CB", "3E1A78" }), Operaciones.Empty(), true,
                new string[] { "078D70", "26CEAA", "99E8C2", "FFFFFF", "7BADE3", "5049CB", "3E1A78" }, null)
            },
            {
                Diseños.Men_loving_men___Mlm2__, new Banderas(Diseños.Men_loving_men___Mlm2__, "Men loving men 2 [Mlm]", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "039070", "01c9bc", "86eeed", "ffffff", "7dcaf8", "049cf0", "022a8a" }), Operaciones.Empty(), false,
                new string[] { "039070", "01c9bc", "86eeed", "ffffff", "7dcaf8", "049cf0", "022a8a" }, null)
            },
            {
                Diseños.Men_loving_men___Mlm3__, new Banderas(Diseños.Men_loving_men___Mlm3__, "Men loving men 3 [Mlm]", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "ffdb52", "ffbe00", "ff8a20", "ffffff", "7a41a9", "69379a", "502887" }), Operaciones.Empty(), false,
                new string[] { "ffdb52", "ffbe00", "ff8a20", "ffffff", "7a41a9", "69379a", "502887" }, null)
            },
            {
                Diseños.Men_loving_men_5_stripes___Mlm__, new Banderas(Diseños.Men_loving_men_5_stripes___Mlm__, "Men loving men (5 stripes) [Mlm]", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "078D70", "98E8C1", "FFFFFF", "7BADE2", "3D1A78" }), Operaciones.Empty(), false,
                new string[] { "078D70", "98E8C1", "FFFFFF", "7BADE2", "3D1A78" }, null)
            },
            {
                Diseños.Mingender, new Banderas(Diseños.Mingender, "Mingender (MIN)", 8,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "C0F2A2" }, new decimal[4] { 0m, 0m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A3F1BE" }, new decimal[4] { 0m, 1m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "7DE7EC" }, new decimal[4] { 0m, 2m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "31A7EE" }, new decimal[4] { 0m, 3m / 8m, 1m, 2m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "8385DE" }, new decimal[4] { 0m, 5m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "AE82DF" }, new decimal[4] { 0m, 6m / 8m, 1m, 1m / 8m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D17EE2" }, new decimal[4] { 0m, 7m / 8m, 1m, 1m / 8m }),
                },
                Operaciones.Empty(), true,
                new string[] { "C0F2A2", "A3F1BE", "7DE7EC", "31A7EE", "8385DE", "AE82DF", "D17EE2" },
                new decimal[]{ 1m / 8m, 1m / 8m, 1m / 8m, 2m / 8m, 1m / 8m, 1m / 8m, 1m / 8m })
            },
            {
                Diseños.MOGAI, new Banderas(Diseños.MOGAI, "MOGAI", 1,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 0m, 1m, 1m }),

                    new Operaciones(Dibujos.Rayas, Funciones.Ángulo, new string[] { "BD57B5" }, new decimal[6] { 1289m / 5000m, 289m / 3000m, 2423m / 5000m, 2423m / 3000m, -90m + ((360m * 0m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Ángulo, new string[] { "754EFB" }, new decimal[6] { 1289m / 5000m, 289m / 3000m, 2423m / 5000m, 2423m / 3000m, -90m + ((360m * 1m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Ángulo, new string[] { "5580E6" }, new decimal[6] { 1289m / 5000m, 289m / 3000m, 2423m / 5000m, 2423m / 3000m, -90m + ((360m * 2m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Ángulo, new string[] { "30DDEE" }, new decimal[6] { 1289m / 5000m, 289m / 3000m, 2423m / 5000m, 2423m / 3000m, -90m + ((360m * 3m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Ángulo, new string[] { "58D9B9" }, new decimal[6] { 1289m / 5000m, 289m / 3000m, 2423m / 5000m, 2423m / 3000m, -90m + ((360m * 4m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Ángulo, new string[] { "3CFE56" }, new decimal[6] { 1289m / 5000m, 289m / 3000m, 2423m / 5000m, 2423m / 3000m, -90m + ((360m * 5m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Ángulo, new string[] { "9FED43" }, new decimal[6] { 1289m / 5000m, 289m / 3000m, 2423m / 5000m, 2423m / 3000m, -90m + ((360m * 6m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Ángulo, new string[] { "FFF728" }, new decimal[6] { 1289m / 5000m, 289m / 3000m, 2423m / 5000m, 2423m / 3000m, -90m + ((360m * 7m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Ángulo, new string[] { "FECE33" }, new decimal[6] { 1289m / 5000m, 289m / 3000m, 2423m / 5000m, 2423m / 3000m, -90m + ((360m * 8m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Ángulo, new string[] { "FAA23E" }, new decimal[6] { 1289m / 5000m, 289m / 3000m, 2423m / 5000m, 2423m / 3000m, -90m + ((360m * 9m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Ángulo, new string[] { "F97B4A" }, new decimal[6] { 1289m / 5000m, 289m / 3000m, 2423m / 5000m, 2423m / 3000m, -90m + ((360m * 10m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Ángulo, new string[] { "F55056" }, new decimal[6] { 1289m / 5000m, 289m / 3000m, 2423m / 5000m, 2423m / 3000m, -90m + ((360m * 11m) / 12m), 360m / 12m }),

                    new Operaciones(Dibujos.Figuras, Funciones.Ángulo, new string[] { "242424" }, new decimal[6] { 1591m / 5000m, 591m / 3000m, 1819m / 5000m, 1819m / 3000m, -90m + ((360m * 0m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Ángulo, new string[] { "494A47" }, new decimal[6] { 1591m / 5000m, 591m / 3000m, 1819m / 5000m, 1819m / 3000m, -90m + ((360m * 1m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Ángulo, new string[] { "6F6F6F" }, new decimal[6] { 1591m / 5000m, 591m / 3000m, 1819m / 5000m, 1819m / 3000m, -90m + ((360m * 2m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Ángulo, new string[] { "929292" }, new decimal[6] { 1591m / 5000m, 591m / 3000m, 1819m / 5000m, 1819m / 3000m, -90m + ((360m * 3m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Ángulo, new string[] { "B6B6B6" }, new decimal[6] { 1591m / 5000m, 591m / 3000m, 1819m / 5000m, 1819m / 3000m, -90m + ((360m * 4m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Ángulo, new string[] { "DBDBDB" }, new decimal[6] { 1591m / 5000m, 591m / 3000m, 1819m / 5000m, 1819m / 3000m, -90m + ((360m * 5m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Ángulo, new string[] { "B6B6B6" }, new decimal[6] { 1591m / 5000m, 591m / 3000m, 1819m / 5000m, 1819m / 3000m, -90m + ((360m * 6m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Ángulo, new string[] { "929292" }, new decimal[6] { 1591m / 5000m, 591m / 3000m, 1819m / 5000m, 1819m / 3000m, -90m + ((360m * 7m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Ángulo, new string[] { "6F6F6F" }, new decimal[6] { 1591m / 5000m, 591m / 3000m, 1819m / 5000m, 1819m / 3000m, -90m + ((360m * 8m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Ángulo, new string[] { "494949" }, new decimal[6] { 1591m / 5000m, 591m / 3000m, 1819m / 5000m, 1819m / 3000m, -90m + ((360m * 9m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Ángulo, new string[] { "242424" }, new decimal[6] { 1591m / 5000m, 591m / 3000m, 1819m / 5000m, 1819m / 3000m, -90m + ((360m * 10m) / 12m), 360m / 12m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Ángulo, new string[] { "000000" }, new decimal[6] { 1591m / 5000m, 591m / 3000m, 1819m / 5000m, 1819m / 3000m, -90m + ((360m * 11m) / 12m), 360m / 12m }),

                    new Operaciones(Dibujos.Iconos, Funciones.Círculo, new string[] { "FFFFFF" }, new decimal[4] { 1894m / 5000m, 894m / 3000m, 1213m / 5000m, 1213m / 3000m }),
                },
                Operaciones.Empty(), true,
                new string[] { "B65AB6", "CA88CA", "D6A3D6", "FFFFFF", "FFD509", "646464", "444444", "000000" },
                new decimal[]{ 2m / 14m, 2m / 14m, 2m / 14m, 1m / 14m, 1m / 14m, 2m / 14m, 2m / 14m, 2m / 14m })
            },
            {
                Diseños.Monosexual, new Banderas(Diseños.Monosexual, "Monosexual", 14,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "B65AB6" }, new decimal[4] { 0m, 0m / 14m, 1m, 2m / 14m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "CA88CA" }, new decimal[4] { 0m, 2m / 14m, 1m, 2m / 14m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D6A3D6" }, new decimal[4] { 0m, 4m / 14m, 1m, 2m / 14m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 6m / 14m, 1m, 1m / 14m }),

                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFD509" }, new decimal[4] { 0m, 7m / 14m, 1m, 1m / 14m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "646464" }, new decimal[4] { 0m, 8m / 14m, 1m, 2m / 14m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "444444" }, new decimal[4] { 0m, 10m / 14m, 1m, 2m / 14m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 12m / 14m, 1m, 2m / 14m }),
                },
                //Operaciones.Rectángulos_Horizontales(new string[] { "B65AB6", "B65AB6", "CA88CA", "CA88CA", "D6A3D6", "D6A3D6", "FFFFFF", "FFD509", "646464", "646464", "444444", "444444", "000000", "000000" }),
                Operaciones.Empty(), true,
                new string[] { "B65AB6", "CA88CA", "D6A3D6", "FFFFFF", "FFD509", "646464", "444444", "000000" },
                new decimal[]{ 2m / 14m, 2m / 14m, 2m / 14m, 1m / 14m, 1m / 14m, 2m / 14m, 2m / 14m, 2m / 14m })
            },
            {
                Diseños.Multigender, new Banderas(Diseños.Multigender, "Multigender", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "3F47CD", "00A4E7", "F97F27", "00A4E7", "3F47CD" }), Operaciones.Empty(), true,
                new string[] { "3F47CD", "00A4E7", "F97F27", "00A4E7", "3F47CD" }, null)
            },
            {
                Diseños.Multigender_2, new Banderas(Diseños.Multigender_2, "Multigender #2", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFFFFF", "F8E224", "E80C88", "399EDF", "9A59CF", "282828" }), Operaciones.Empty(), true,
                new string[] { "FFFFFF", "F8E224", "E80C88", "399EDF", "9A59CF", "282828" }, null)
            },
            {
                Diseños.Multisexual, new Banderas(Diseños.Multisexual, "Multisexual", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "724EC9", "FFFFFF", "73E7FF", "F24899" }), Operaciones.Empty(), true,
                new string[] { "724EC9", "FFFFFF", "73E7FF", "F24899" }, null)
            },
            {
                Diseños.Mutosexual, new Banderas(Diseños.Mutosexual, "Mutosexual", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFB447", "F2F2F2", "F9DAC6", "89CFF0", "2A2A2A", "C8A2C8" }), Operaciones.Empty(), true,
                new string[] { "FFB447", "F2F2F2", "F9DAC6", "89CFF0", "2A2A2A", "C8A2C8" }, null)
            },
            {
                Diseños.Muxe, new Banderas(Diseños.Muxe, "Muxe", 1,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 0m, 1m, 1m }),

                    new Operaciones(Dibujos.Iconos, Funciones.Círculo, new string[] { "267F00" }, new decimal[4] { 39m / 120m, 10m / 72m, 42m / 120m, 42m / 72m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Círculo, new string[] { "000000" }, new decimal[4] { 40m / 120m, 11m / 72m, 40m / 120m, 40m / 72m }),

                    new Operaciones(Dibujos.Iconos, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 48m / 120m, 0m / 72m, 24m / 120m, 36m / 72m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 54m / 120m, 36m / 72m, 12m / 120m, 36m / 72m }),

                    new Operaciones(Dibujos.Figuras, Funciones.Círculo, new string[] { "FFFFFF" }, new decimal[4] { 45m / 120m, 16m / 72m, 30m / 120m, 30m / 72m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Círculo, new string[] { "00AF11" }, new decimal[4] { 21m / 120m, 43m / 72m, 18m / 120m, 18m / 72m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Círculo, new string[] { "B50000" }, new decimal[4] { 81m / 120m, 43m / 72m, 18m / 120m, 18m / 72m }),

                    new Operaciones(Dibujos.Iconos, Funciones.Círculo, new string[] { "FFD800" }, new decimal[4] { 57m / 120m, 28m / 72m, 6m / 120m, 6m / 72m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Círculo, new string[] { "FFD800" }, new decimal[4] { 28m / 120m, 50m / 72m, 4m / 120m, 4m / 72m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Círculo, new string[] { "FFD800" }, new decimal[4] { 88m / 120m, 50m / 72m, 4m / 120m, 4m / 72m })
                },
                Operaciones.Empty(), true,
                new string[] { "000000" }, null)
            },
            {
                Diseños.Neptunic, new Banderas(Diseños.Neptunic, "Neptunic", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "0399B8", "39D6C8", "74E9D4", "A0E5EE", "99B0EA", "9799EE" }), Operaciones.Empty(), true,
                new string[] { "0399B8", "39D6C8", "74E9D4", "A0E5EE", "99B0EA", "9799EE" }, null)
            },
            {
                Diseños.Neurogender, new Banderas(Diseños.Neurogender, "Neurogender", 4,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "DE2D48" }, new decimal[4] { 0m / 4m, 0m, 1m / 4m, 1m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "BEDA57" }, new decimal[4] { 1m / 4m, 0m, 1m / 4m, 1m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "B1F3DE" }, new decimal[4] { 2m / 4m, 0m, 1m / 4m, 1m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "942D98" }, new decimal[4] { 3m / 4m, 0m, 1m / 4m, 1m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "FFFFFF" }, new decimal[4] { 0m / 1920m, 167m / 1152m, 1920m / 1920m, 818m / 1152m }, "Neurogender.png"),
                },
                //Operaciones.Rectángulos_Horizontales(new string[] { "DE2D48", "BEDA57", "B1F3DE", "942D98" }),
                Operaciones.Empty(), true,
                new string[] { "DE2D48", "BEDA57", "B1F3DE", "942D98" }, null)
            },
            {
                Diseños.Neutrois, new Banderas(Diseños.Neutrois, "Neutrois", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFFFFF", "1F9F00", "000000" }), Operaciones.Empty(), true,
                new string[] { "FFFFFF", "1F9F00", "000000" }, null)
            },
            {
                Diseños.Niaspec, new Banderas(Diseños.Niaspec, "Niaspec", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "102014", "388D51", "43D06A", "F5F5F5", "9A9899" }), Operaciones.Empty(), true,
                new string[] { "102014", "388D51", "43D06A", "F5F5F5", "9A9899" }, null)
            },
            {
                Diseños.Noetiromantic, new Banderas(Diseños.Noetiromantic, "Noetiromantic", 0,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000" }), Operaciones.Empty(), true,
                new string[] {  }, null)
            },
            {
                Diseños.Noetiromantic_2, new Banderas(Diseños.Noetiromantic_2, "Noetiromantic #2", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "358C4F", "75E697", "FFFFFF", "75E697", "358C4F", "000000" }), Operaciones.Empty(), false,
                new string[] { "000000", "358C4F", "75E697", "FFFFFF", "75E697", "358C4F", "000000" }, null)
            },
            {
                Diseños.Non_monogamy, new Banderas(Diseños.Non_monogamy, "Non monogamy", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "62ACFF", "FF98B9", "FFFFFF" }), Operaciones.Empty(), true,
                new string[] { "62ACFF", "FF98B9", "FFFFFF" }, null)
            },
            {
                Diseños.Nonbinary___2014__, new Banderas(Diseños.Nonbinary___2014__, "Nonbinary [2014]", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "FCF434", "FFFFFF", "9C59D1", "2D2D2D" }), Operaciones.Empty(), true,
                new string[] { "FCF434", "FFFFFF", "9C59D1", "2D2D2D" }, null)
            },
            {
                Diseños.Nonbinary_2, new Banderas(Diseños.Nonbinary_2, "Nonbinary #2", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "ffffff", "ff7f26", "b5e51d" }), Operaciones.Empty(), false,
                new string[] { "000000", "ffffff", "ff7f26", "b5e51d" }, null)
            },
            {
                Diseños.Nonbinary_3, new Banderas(Diseños.Nonbinary_3, "Nonbinary #3", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "a349a3", "ffffff", "ff7f26", "b5e51d" }), Operaciones.Empty(), false,
                new string[] { "a349a3", "ffffff", "ff7f26", "b5e51d" }, null)
            },
            {
                Diseños.Nonbinary_4, new Banderas(Diseños.Nonbinary_4, "Nonbinary #4", 5,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFF93E" }, new decimal[4] { 0m, 0m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 1m / 5m, 1m, 1m / 5m }),
                    //new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 3m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A921FF" }, new decimal[4] { 0m, 4m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Círculo, new string[] { "31B413" }, new decimal[4] { 0.5m - (((1m / 5m) * 3m) / 5m), 1m / 5m, (((2m / 5m) * 3m) / 5m), 2m / 5m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Círculo, new string[] { "31B413" }, new decimal[4] { 0.5m - (((1m / 5m) * 3m) / 5m), 2m / 5m, (((2m / 5m) * 3m) / 5m), 2m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                },
                Operaciones.Empty(), false,
                new string[] { "FFF93E", "FFFFFF", "000000", "FFFFFF", "A921FF" }, null)
            },
            {
                Diseños.Nonbinary_5, new Banderas(Diseños.Nonbinary_5, "Nonbinary #5", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "611D80", "FFFFFF", "FFA800", "010101" }), Operaciones.Empty(), false,
                new string[] { "611D80", "FFFFFF", "FFA800", "010101" }, null)
            },
            {
                Diseños.Nonbinary_6, new Banderas(Diseños.Nonbinary_6, "Nonbinary #6", 8,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFD966", "FFE79D", "F3F6F4", "FFFFFF", "F3F6F4", "444444", "000000", "800080" }), Operaciones.Empty(), false,
                new string[] { "FFD966", "FFE79D", "F3F6F4", "FFFFFF", "F3F6F4", "444444", "000000", "800080" }, null)
            },
            {
                Diseños.Nonbinary_7, new Banderas(Diseños.Nonbinary_7, "Nonbinary #7", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "A662CD", "F59E86", "FFFFFF", "EAED10", "08BDB5" }), Operaciones.Empty(), false,
                new string[] { "A662CD", "F59E86", "FFFFFF", "EAED10", "08BDB5" }, null)
            },
            {
                Diseños.Nonbinary_8, new Banderas(Diseños.Nonbinary_8, "Nonbinary #8", 9,
                Operaciones.Rectángulos_Verticales(new string[] { "6195CA", "92D1E2", "C0E288", "F9F9F9", "D778F9", "F9F9F9", "F9AC50", "F655AD", "D13B3D" }), Operaciones.Empty(), false,
                new string[] { "6195CA", "92D1E2", "C0E288", "F9F9F9", "D778F9", "F9F9F9", "F9AC50", "F655AD", "D13B3D" }, null)
            },
            {
                Diseños.Nonbinary_9, new Banderas(Diseños.Nonbinary_9, "Nonbinary #9", 8,
                Operaciones.Rectángulos_Horizontales(new string[] { "191919", "B2B2B2", "FFFFFF", "FFFA7C", "98FF68", "1E9AFF", "D23FFF", "FB6BBA" }), Operaciones.Empty(), false,
                new string[] { "191919", "B2B2B2", "FFFFFF", "FFFA7C", "98FF68", "1E9AFF", "D23FFF", "FB6BBA" }, null)
            },
            {
                Diseños.Nonbinary_10, new Banderas(Diseños.Nonbinary_10, "Nonbinary #10", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "D0C60F", "EDE53C", "FEF433", "FFFFFF", "9C58CF", "481572", "1D1425" }), Operaciones.Empty(), false,
                new string[] { "D0C60F", "EDE53C", "FEF433", "FFFFFF", "9C58CF", "481572", "1D1425" }, null)
            },
            {
                Diseños.Nonbinary_11, new Banderas(Diseños.Nonbinary_11, "Nonbinary #11", 8,
                Operaciones.Rectángulos_Horizontales(new string[] { "F2FF85", "F6FFAE", "FFFFFF", "E8E8E8", "DDB4FF", "BB9AC8", "7F7F7F", "414141" }), Operaciones.Empty(), false,
                new string[] { "F2FF85", "F6FFAE", "FFFFFF", "E8E8E8", "DDB4FF", "BB9AC8", "7F7F7F", "414141" }, null)
            },
            {
                Diseños.Nonbinary_12, new Banderas(Diseños.Nonbinary_12, "Nonbinary #12", 8,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFF3A2", "FFFFFF", "E6CFCF", "282828" }), Operaciones.Empty(), false,
                new string[] { "FFF3A2", "FFFFFF", "E6CFCF", "282828" }, null)
            },
            {
                Diseños.Nonbinary_13, new Banderas(Diseños.Nonbinary_13, "Nonbinary #13", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FEB360", "FFD5A7", "FFEEDC", "A690FF", "7F60FE" }), Operaciones.Empty(), false,
                new string[] { "FEB360", "FFD5A7", "FFEEDC", "A690FF", "7F60FE" }, null)
            },
            {
                Diseños.Nonbinary_boy, new Banderas(Diseños.Nonbinary_boy, "Nonbinary boy", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "0076A2", "01A980", "F8E167", "FFFFFF", "F8E167", "01A980", "0076A2" }), Operaciones.Empty(), true,
                new string[] { "0076A2", "01A980", "F8E167", "FFFFFF", "F8E167", "01A980", "0076A2" }, null)
            },
            {
                Diseños.Nonbinary_girl, new Banderas(Diseños.Nonbinary_girl, "Nonbinary girl", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "E64967", "F57E59", "F3DA5C", "FFFFFF", "F3DA5C", "F57E59", "E64967" }), Operaciones.Empty(), true,
                new string[] { "E64967", "F57E59", "F3DA5C", "FFFFFF", "F3DA5C", "F57E59", "E64967" }, null)
            },
            {
                Diseños.Nudism, new Banderas(Diseños.Nudism, "Nudism", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "7E7E7E", "FFFFFF", "008700" }), Operaciones.Empty(), true,
                new string[] { "7E7E7E", "FFFFFF", "008700" }, null)
            },
            {
                Diseños.Omniromantic, new Banderas(Diseños.Omniromantic, "Omniromantic", 5,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFC9E4" }, new decimal[4] { 0m, 0m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFA1DC" }, new decimal[4] { 0m, 1m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "89739A" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "AAA7FF" }, new decimal[4] { 0m, 3m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "BFCEFF" }, new decimal[4] { 0m, 4m / 5m, 1m, 1m / 5m }),
                },
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "FF9CCD" }, new decimal[4] { 0m, 0m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "FF53BD" }, new decimal[4] { 0m, 1m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "270046" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "675FFE" }, new decimal[4] { 0m, 3m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "8CA7FF" }, new decimal[4] { 0m, 4m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen_Recorte, new string[] { "FFFFFF" }, new decimal[] { 861m / 5000m, 0m / 3000m, 3277m / 5000m, 3000m / 3000m }, "Heart.png"),
                },
                true,
                new string[] { "FFC9E4", "FFA1DC", "89739A", "AAA7FF", "BFCEFF" }, null)
            },
            {
                Diseños.Omnisexual, new Banderas(Diseños.Omnisexual, "Omnisexual", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF9BCD", "FF53BE", "250046", "675FFF", "8CA5FF" }), Operaciones.Empty(), true,
                new string[] { "FF9BCD", "FF53BE", "250046", "675FFF", "8CA5FF" }, null)
            },
            {
                Diseños.Pangender, new Banderas(Diseños.Pangender, "Pangender", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFF798", "FEDDCC", "FFEBFC", "FFFFFF", "FFEBFC", "FEDDCC", "FFF798" }), Operaciones.Empty(), true,
                new string[] { "FFF798", "FEDDCC", "FFEBFC", "FFFFFF", "FFEBFC", "FEDDCC", "FFF798" }, null)
            },
            {
                Diseños.Panromantic, new Banderas(Diseños.Panromantic, "Panromantic", 3,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FF8FC5" }, new decimal[4] { 0m, 0m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFEC81" }, new decimal[4] { 0m, 1m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "8FD9FF" }, new decimal[4] { 0m, 2m / 3m, 1m, 1m / 3m }),
                },
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "FF218E" }, new decimal[4] { 0m, 0m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "FED800" }, new decimal[4] { 0m, 1m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "21B2FE" }, new decimal[4] { 0m, 2m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen_Recorte, new string[] { "FFFFFF" }, new decimal[] { 861m / 5000m, 0m / 3000m, 3277m / 5000m, 3000m / 3000m }, "Heart.png"),
                },
                true,
                new string[] { "FF8FC5", "FFEC81", "8FD9FF" }, null)
            },
            {
                Diseños.Panromantic_Demisexual, new Banderas(Diseños.Panromantic_Demisexual, "Panromantic demisexual", 7,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FF218C" }, new decimal[4] { 0m, 0m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 1m / 7m, 1m, 2m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "572B87" }, new decimal[4] { 0m, 3m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D2D2D2" }, new decimal[4] { 0m, 4m / 7m, 1m, 2m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "21B1FF" }, new decimal[4] { 0m, 6m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "000000" }, new decimal[]
                    {
                        0m, 0m,
                        1930m / 5000m, 0.5m,
                        0m, 1m
                    }),
                },
                Operaciones.Empty(), true,
                new string[] { "FF218C", "FFFFFF", "572B87", "D2D2D2", "21B1FF" },
                new decimal[]{ 1m / 7m, 2m / 7m, 1m / 7m, 2m / 7m, 1m / 7m })
            },
            {
                Diseños.Pansexual___2010__, new Banderas(Diseños.Pansexual___2010__, "Pansexual [2010]", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF218C", "FFD800", "21B1FF" }), Operaciones.Empty(), true,
                new string[] { "FF218C", "FFD800", "21B1FF" }, null)
            },
            {
                Diseños.Pink_Union_Jack___2009__, new Banderas(Diseños.Pink_Union_Jack___2009__, "Pink Union Jack [2009]", 1,
                Operaciones.Rectángulos_Horizontales(new string[] { "FA87D2" }), Operaciones.Empty(), true,
                new string[] { "FA87D2" }, null)
            },
            {
                Diseños.Polyamory, new Banderas(Diseños.Polyamory, "Polyamory (pi)", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "0000FF", "FF0000", "000000" }), Operaciones.Empty(), true,
                new string[] { "0000FF", "FF0000", "000000" }, null)
            },
            {
                Diseños.Polyamory_infinity_heart, new Banderas(Diseños.Polyamory_infinity_heart, "Diseños.Polyamory_infinity_heart, Polyamory (infinity heart)", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "0000FF", "FF0000", "000000" }), Operaciones.Empty(), false,
                new string[] { "0000FF", "FF0000", "000000" }, null)
            },
            {
                Diseños.Polygender, new Banderas(Diseños.Polygender, "Polygender", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "939393", "ED94C5", "F5ED81", "64BBE6" }), Operaciones.Empty(), true,
                new string[] { "000000", "939393", "ED94C5", "F5ED81", "64BBE6" }, null)
            },
            {
                Diseños.Polygender_2, new Banderas(Diseños.Polygender_2, "Polygender #2", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "040404", "949494", "EA94C2", "F4EC84", "64BCE4", "949494", "040404" }), Operaciones.Empty(), true,
                new string[] { "040404", "949494", "EA94C2", "F4EC84", "64BCE4", "949494", "040404" }, null)
            },
            {
                Diseños.Polygender_3, new Banderas(Diseños.Polygender_3, "Polygender #3", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "EA94C2", "040404", "949494", "F4EC84", "949494", "040404", "64BCE4" }), Operaciones.Empty(), true,
                new string[] { "EA94C2", "040404", "949494", "F4EC84", "949494", "040404", "64BCE4" }, null)
            },
            {
                Diseños.Polygender_4, new Banderas(Diseños.Polygender_4, "Polygender #4", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "DBA3FE", "FFA4C2", "FFBFA3", "DBDBDB", "FFFBA4", "A9FFAC", "A3BDFF" }), Operaciones.Empty(), true,
                new string[] { "DBA3FE", "FFA4C2", "FFBFA3", "DBDBDB", "FFFBA4", "A9FFAC", "A3BDFF" }, null)
            },
            {
                Diseños.Polygender_5, new Banderas(Diseños.Polygender_5, "Polygender #5", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "8349BB", "8691EC", "B7E9F2", "6EC5CB", "5CBB96" }), Operaciones.Empty(), true,
                new string[] { "8349BB", "8691EC", "B7E9F2", "6EC5CB", "5CBB96" }, null)
            },
            {
                Diseños.Polyromantic, new Banderas(Diseños.Polyromantic, "Polyromantic", 3,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F982DA" }, new decimal[4] { 0m, 0m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "78E8AE" }, new decimal[4] { 0m, 1m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "81C3FA" }, new decimal[4] { 0m, 2m / 3m, 1m, 1m / 3m }),
                },
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "F61BB9" }, new decimal[4] { 0m, 0m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "07D669" }, new decimal[4] { 0m, 1m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "1C92F5" }, new decimal[4] { 0m, 2m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen_Recorte, new string[] { "FFFFFF" }, new decimal[] { 861m / 5000m, 0m / 3000m, 3277m / 5000m, 3000m / 3000m }, "Heart.png"),
                },
                true,
                new string[] { "F982DA", "78E8AE", "81C3FA" }, null)
            },
            {
                Diseños.Polyromantic_2, new Banderas(Diseños.Polyromantic_2, "Polyromantic #2", 21,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FF8CF5" }, new decimal[4] { 0m, 0m / 21m, 1m, 4m / 21m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFE169" }, new decimal[4] { 0m, 4m / 21m, 1m, 1m / 21m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "3AA657" }, new decimal[4] { 0m, 5m / 21m, 1m, 11m / 21m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFE169" }, new decimal[4] { 0m, 16m / 21m, 1m, 1m / 21m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "558FF2" }, new decimal[4] { 0m, 17m / 21m, 1m, 4m / 21m }),
                },
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "FFE169" }, new decimal[4] { 0m, 0m, 1m, 1m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen_Recorte, new string[] { "FFFFFF" }, new decimal[4] { 273m / 700m, 144m / 420m, 154m / 700m, 132m / 420m }, "Heart.png"),
                },
                false,
                new string[] { "FF8CF5", "FFE169", "3AA657", "FFE169", "558FF2" },
                new decimal[]{ 4m / 21m, 1m / 21m, 11m / 21m, 1m / 21m, 4m / 21m })
            },
            {
                Diseños.Polysexual___2012__, new Banderas(Diseños.Polysexual___2012__, "Polysexual [2012]", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "F61CB9", "07D569", "1C92F6" }), Operaciones.Empty(), true,
                new string[] { "F61CB9", "07D569", "1C92F6" }, null)
            },
            {
                Diseños.Pomosexual, new Banderas(Diseños.Pomosexual, "Pomosexual", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFAEC9", "FFC6DE", "FFFFFF", "E8CDFF", "FFFFFF", "FFC6DE", "FFAEC9" }), Operaciones.Empty(), true,
                new string[] { "FFAEC9", "FFC6DE", "FFFFFF", "E8CDFF", "FFFFFF", "FFC6DE", "FFAEC9" }, null)
                //Operaciones.Rectángulos_Horizontales(new string[] { "000000", "939393", "ED94C5", "F5ED81", "64BBE6" }), Operaciones.Empty())
            },
            {
                Diseños.Queer, new Banderas(Diseños.Queer, "Queer", 9,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "99D9EA", "00A2E8", "B5E61D", "FFFFFF", "FFC90E", "FD6666", "FFAEC9", "000000" }), Operaciones.Empty(), true,
                new string[] { "000000", "99D9EA", "00A2E8", "B5E61D", "FFFFFF", "FFC90E", "FD6666", "FFAEC9", "000000" }, null)
            },
            {
                Diseños.Queer_chevron, new Banderas(Diseños.Queer_chevron, "Queer (chevron)", 1,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FCF5EB" }, new decimal[4] { 0m, 0m, 1m, 1m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "BA7EC6" }, new decimal[] { 0m, 105m / 522m, 0.5m, 254m / 522m, 1m, 105m / 522m, 1m, 186m / 522m, 0.5m, 336m / 522m, 0m, 182m / 522, 0m, 105m / 522m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "744D77" }, new decimal[] { 0m, 235m / 522m, 0.5m, 384m / 522m, 1m, 235m / 522m, 1m, 316m / 522m, 0.5m, 466m / 522m, 0m, 312m / 522m, 0m, 235m / 522m }),
                },
                Operaciones.Empty(), false,
                new string[] { "FCF5EB" }, null)
            },
            {
                Diseños.Queerhet, new Banderas(Diseños.Queerhet, "Queerhet (heteroqueer)", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "4E8492", "6CCB99", "727D6E", "DAC686", "B86962" }), Operaciones.Empty(), true,
                new string[] { "4E8492", "6CCB99", "727D6E", "DAC686", "B86962" }, null)
            },
            {
                Diseños.Questioning, new Banderas(Diseños.Questioning, "Questioning", 4,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "EC732E" }, new decimal[4] { 0m, 0m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F4EB24" }, new decimal[4] { 0m, 1m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "55B047" }, new decimal[4] { 0m, 2m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "4B63AD" }, new decimal[4] { 0m, 3m / 4m, 1m, 1m / 4m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "FFFFFF" }, new decimal[4] { 669m / 1920m, 54m / 1152m, 583m / 1920m, 1044m / 1152m }, "Questioning.png"),
                },
                //Operaciones.Rectángulos_Horizontales(new string[] { "EC732E", "F4EB24", "55B047", "4B63AD" }),
                Operaciones.Empty(), true,
                new string[] { "EC732E", "F4EB24", "55B047", "4B63AD" }, null)
            },
            {
                Diseños.Quoiromantic, new Banderas(Diseños.Quoiromantic, "Quoiromantic", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000", "FFFFFF", "98DC31", "24D0E4" }), Operaciones.Empty(), true,
                new string[] { "000000", "FFFFFF", "98DC31", "24D0E4" }, null)
            },
            {
                Diseños.Recipromantic, new Banderas(Diseños.Recipromantic, "Recipromantic", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "E84671", "F0B2DC", "ADF6B2", "FFFFFF", "000000" }), Operaciones.Empty(), true,
                new string[] { "E84671", "F0B2DC", "ADF6B2", "FFFFFF", "000000" }, null)
            },
            {
                Diseños.Rubber_fetish, new Banderas(Diseños.Rubber_fetish, "Rubber fetish", 1,
                Operaciones.Rectángulos_Horizontales(new string[] { "000000" }), Operaciones.Empty(), true,
                new string[] { "000000" }, null)
            },
            {
                Diseños.Sapphic, new Banderas(Diseños.Sapphic, "Sapphic", 3,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FD8BA8" }, new decimal[4] { 0m, 0m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FBF2FF" }, new decimal[4] { 0m, 1m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FD8BA8" }, new decimal[4] { 0m, 2m / 3m, 1m, 1m / 3m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "FFFFFF" }, new decimal[4] { 787m / 1920m, 396m / 1152m, 346m / 1920m, 360m / 1152m }, "Sapphic.png"),
                },
                //Operaciones.Rectángulos_Horizontales(new string[] { "ff89ab", "ffffff", "ff89ab" }),
                Operaciones.Empty(), true,
                new string[] { "FD8BA8", "FBF2FF", "FD8BA8" }, null)
            },
            {
                Diseños.Saturnic, new Banderas(Diseños.Saturnic, "Saturnic", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "FAFB00", "FFFF51", "FFFF8D", "FFFEC5", "FFFFFF", "FFF4BC" }), Operaciones.Empty(), true,
                new string[] { "FAFB00", "FFFF51", "FFFF8D", "FFFEC5", "FFFFFF", "FFF4BC" }, null)
            },
            /*{
                Diseños.Saturnic_2, new Banderas("Saturnic #2", 6,
                "",
                Operaciones.Rectángulos_Horizontales(new string[] { "FCE85A", "FFF392", "FFF7B8", "FFFADA", "FFFFFF", "FFF0CD" }), Operaciones.Empty(), false,
                new string[] { "FCE85A", "FFF392", "FFF7B8", "FFFADA", "FFFFFF", "FFF0CD" }, null)
            },*/
            {
                Diseños.Saturnic_2, new Banderas(Diseños.Saturnic_2, "Saturnic #2", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "FDE85B", "FEF392", "FFF7B8", "FEFBDA", "FFFFFF", "FFF1CD" }), Operaciones.Empty(), false,
                new string[] { "FDE85B", "FEF392", "FFF7B8", "FEFBDA", "FFFFFF", "FFF1CD" }, null)
            },
            {
                Diseños.Saturnic_3, new Banderas(Diseños.Saturnic_3, "Saturnic #3", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "B18C49", "D3A655", "EBC371", "F8E996", "FFFFFF", "BFAF85" }), Operaciones.Empty(), false,
                new string[] { "B18C49", "D3A655", "EBC371", "F8E996", "FFFFFF", "BFAF85" }, null)
            },
            {
                Diseños.Saturnic_4, new Banderas(Diseños.Saturnic_4, "Saturnic #4", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "B18C49", "D2A655", "EBC471", "F9E996", "FFFDEB", "FFF1CD" }), Operaciones.Empty(), false,
                new string[] { "B18C49", "D2A655", "EBC471", "F9E996", "FFFDEB", "FFF1CD" }, null)
            },
            {
                Diseños.Saturnic_5, new Banderas(Diseños.Saturnic_5, "Saturnic #5", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "DCA600", "F1C232", "FFD966", "FFE599", "FEFBE3", "FFF4BC" }), Operaciones.Empty(), false,
                new string[] { "DCA600", "F1C232", "FFD966", "FFE599", "FEFBE3", "FFF4BC" }, null)
            },
            {
                Diseños.Saturnic_6, new Banderas(Diseños.Saturnic_6, "Saturnic #6", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "DD904A", "F3B177", "FCDA93", "FFE9B7", "FFFAE6", "FBF1D6" }), Operaciones.Empty(), false,
                new string[] { "DD904A", "F3B177", "FCDA93", "FFE9B7", "FFFAE6", "FBF1D6" }, null)
            },
            {
                Diseños.Saturnic_7, new Banderas(Diseños.Saturnic_7, "Saturnic #7", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "C16634", "E29958", "FFD57D", "FFEDC6", "FFFCF3", "EFE6CE" }), Operaciones.Empty(), false,
                new string[] { "C16634", "E29958", "FFD57D", "FFEDC6", "FFFCF3", "EFE6CE" }, null)
            },
            {
                Diseños.Saturnic_8, new Banderas(Diseños.Saturnic_8, "Saturnic #8", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "D17F45", "FFE0A0", "FFFCF3", "EFE6CE" }), Operaciones.Empty(), false,
                new string[] { "D17F45", "FFE0A0", "FFFCF3", "EFE6CE" }, null)
            },
            {
                Diseños.Saturnic_9, new Banderas(Diseños.Saturnic_9, "Saturnic #9", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "FDE85B", "FEF392", "FFF7B8", "FFFFFF" }), Operaciones.Empty(), false,
                new string[] { "FDE85B", "FEF392", "FFF7B8", "FFFFFF" }, null)
            },
            {
                Diseños.Saturnic_10, new Banderas(Diseños.Saturnic_10, "Saturnic #10", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "FDE85B", "FEF392", "FFFFFF", "FFF1CD" }), Operaciones.Empty(), false,
                new string[] { "FDE85B", "FEF392", "FFFFFF", "FFF1CD" }, null)
            },
            {
                Diseños.Semibisexual, new Banderas(Diseños.Semibisexual, "Semibisexual", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF0080", "FF00FF", "A349A4", "783678" }), Operaciones.Empty(), true,
                new string[] { "FF0080", "FF00FF", "A349A4", "783678" }, null)
            },
            {
                Diseños.Semibisexual_2, new Banderas(Diseños.Semibisexual_2, "Semibisexual #2", 5,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FD0073" }, new decimal[4] { 0m, 0m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A90089" }, new decimal[4] { 0m, 1m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 2m / 5m, 1m, 3m / 5m }),
                },
                Operaciones.Empty(), false,
                new string[] { "FD0073", "A90089", "FFFFFF" },
                new decimal[]{ 1m / 5m, 1m / 5m, 3m / 5m })
            },
            {
                Diseños.Straight_ally, new Banderas(Diseños.Straight_ally, "Straight ally", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "E40303", "FF8C00", "FFED00", "008026", "004DFF", "750787" }),
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 0m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 1m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 2m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 3m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "000000" }, new decimal[4] { 0m, 4m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 5m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "00000000" }, new decimal[] { 0m, 1m, 0.5m, 0m, 1m, 1m, 2m / 3m, 1m, 0.5m, 2m / 3m, 1m / 3m, 1m, 0m, 1m }),
                    //new Operaciones(Dibujos.Rayas, Funciones.Polígono_Degradado_Simple, new string[] { "E40303", "FF8C00", "FFED00", "008026", "004DFF", "750787" }, new decimal[] { 0m, 1m, 0.5m, 0m, 1m, 1m, 2m / 3m, 1m, 0.5m, 2m / 3m, 1m / 3m, 1m, 0m, 1m }, LinearGradientMode.Vertical),
                },
                /*new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "E40303" }, new decimal[4] { 0m, 0m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FF8C00" }, new decimal[4] { 0m, 1m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFED00" }, new decimal[4] { 0m, 2m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "008026" }, new decimal[4] { 0m, 3m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "004DFF" }, new decimal[4] { 0m, 4m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "750787" }, new decimal[4] { 0m, 5m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Polígono, new string[] { "00000000" }, new decimal[] { 0m, 1m, 0.5m, 0m, 1m, 1m, 2m / 3m, 1m, 0.5m, 2m / 3m, 1m / 3m, 1m, 0m, 1m }),
                },*/
                //Operaciones.Rectángulos_Horizontales(new string[] { "000000", "FFFFFF", "000000", "FFFFFF", "000000", "FFFFFF" }),
                //Operaciones.Empty(),
                true,
                new string[] { "000000", "FFFFFF", "000000", "FFFFFF", "000000", "FFFFFF" }, null)
            },
            {
                Diseños.Super_straight, new Banderas(Diseños.Super_straight, "Super straight", 2,
                Operaciones.Rectángulos_Verticales(new string[] { "000000", "F7961C" }), Operaciones.Empty(), true,
                new string[] { "000000", "F7961C" }, null)
            },
            {
                Diseños.Torensexual, new Banderas(Diseños.Torensexual, "Torensexual", 5,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "81FAC3" }, new decimal[4] { 0m, 0m / 5m, 1m, 2m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D7A8FF" }, new decimal[4] { 0m, 3m / 5m, 1m, 2m / 5m }),
                },
                Operaciones.Empty(), true,
                new string[] { "81FAC3", "FFFFFF", "D7A8FF" },
                new decimal[]{ 2m / 5m, 1m / 5m, 2m / 5m })
            },
            {
                Diseños.Torensexual_2, new Banderas(Diseños.Torensexual_2, "Torensexual #2", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "75E2FF", "BBF4FE", "D8F7FF", "FFFFFF", "F2DAFF", "E1A7FF", "CB76F9" }), Operaciones.Empty(), false,
                new string[] { "75E2FF", "BBF4FE", "D8F7FF", "FFFFFF", "F2DAFF", "E1A7FF", "CB76F9" }, null)
            },
            {
                Diseños.Torensexual_3, new Banderas(Diseños.Torensexual_3, "Torensexual #3", 5,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "BD6CFF" }, new decimal[4] { 0m, 0m / 5m, 1m, 2m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "0039A7" }, new decimal[4] { 0m, 2m / 5m, 1m, 1m / 5m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "57F9B0" }, new decimal[4] { 0m, 3m / 5m, 1m, 2m / 5m }),
                },
                Operaciones.Empty(), false,
                new string[] { "BD6CFF", "0039A7", "57F9B0" },
                new decimal[]{ 2m / 5m, 1m / 5m, 2m / 5m })
            },
            {
                Diseños.Toric, new Banderas(Diseños.Toric, "Toric", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "B453CC", "DCA0DD", "AEEEED", "99FB98", "7BCD7B" }), Operaciones.Empty(), true,
                new string[] { "B453CC", "DCA0DD", "AEEEED", "99FB98", "7BCD7B" }, null)
            },
            {
                Diseños.Trans_loving_trans, new Banderas(Diseños.Trans_loving_trans, "Trans Loving Trans (TLT)", 7,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A428F1" }, new decimal[4] { 0m, 0m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "8B9AE7" }, new decimal[4] { 0m, 1m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "B6E5EC" }, new decimal[4] { 0m, 2m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 3m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F4AFCD" }, new decimal[4] { 0m, 4m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "E376E4" }, new decimal[4] { 0m, 5m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A544D9" }, new decimal[4] { 0m, 6m / 7m, 1m, 1m / 7m }),
                },
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "B151FE" }, new decimal[4] { 0m, 0m, 1m, 1m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen_Recorte, new string[] { "B151FE" }, new decimal[4] { 1845m / 5000m, 922m / 3000m, 1314m / 5000m, 1127m / 3000m }, "Heart.png"),
                },
                true,
                new string[] { "A428F1", "8B9AE7", "B6E5EC", "FFFFFF", "F4AFCD", "E376E4", "A544D9" }, null)
            }, 
            {
                Diseños.Trans_loving_trans_2, new Banderas(Diseños.Trans_loving_trans_2, "Trans Loving Trans (TLT) #2", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "CDA9E9", "CBDEFC", "DFFCF8", "FFFFFF", "DFFCF8", "CBDEFC", "CDA9E9" }), Operaciones.Empty(), false,
                new string[] { "CDA9E9", "CBDEFC", "DFFCF8", "FFFFFF", "DFFCF8", "CBDEFC", "CDA9E9" }, null)
            },
            {
                Diseños.Trans_loving_trans_3, new Banderas(Diseños.Trans_loving_trans_3, "Trans Loving Trans (TLT) #3", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "AF74AC", "F49CAC", "FAFFC4", "7FD9F9", "7E81E5" }), Operaciones.Empty(), false,
                new string[] { "AF74AC", "F49CAC", "FAFFC4", "7FD9F9", "7E81E5" }, null)
            },
            {
                Diseños.Trans_loving_trans_4, new Banderas(Diseños.Trans_loving_trans_4, "Trans Loving Trans (TLT) #4", 7,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "C05DEC" }, new decimal[4] { 0m, 0m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "EE94F4" }, new decimal[4] { 0m, 1m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FDC6E6" }, new decimal[4] { 0m, 2m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 3m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FECC8F" }, new decimal[4] { 0m, 4m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FE895D" }, new decimal[4] { 0m, 5m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F63645" }, new decimal[4] { 0m, 6m / 7m, 1m, 1m / 7m }),
                },
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "B250FF" }, new decimal[4] { 0m, 0m, 1m, 1m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen_Recorte, new string[] { "B250FF" }, new decimal[4] { 1845m / 5000m, 922m / 3000m, 1314m / 5000m, 1127m / 3000m }, "Heart.png"),
                },
                false,
                new string[] { "C05DEC", "EE94F4", "FDC6E6", "FFFFFF", "FECC8F", "FE895D", "F63645" }, null)
            },
            {
                Diseños.Trans_loving_trans_5, new Banderas(Diseños.Trans_loving_trans_5, "Trans Loving Trans (TLT) #5", 7,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "9237F6" }, new decimal[4] { 0m, 0m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "9096E0" }, new decimal[4] { 0m, 1m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "B9DFF2" }, new decimal[4] { 0m, 2m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 3m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D2EEB3" }, new decimal[4] { 0m, 4m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "99E487" }, new decimal[4] { 0m, 5m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "55B073" }, new decimal[4] { 0m, 6m / 7m, 1m, 1m / 7m }),
                },
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "A456F7" }, new decimal[4] { 0m, 0m, 1m, 1m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen_Recorte, new string[] { "A456F7" }, new decimal[4] { 1845m / 5000m, 922m / 3000m, 1314m / 5000m, 1127m / 3000m }, "Heart.png"),
                },
                false,
                new string[] { "9237F6", "9096E0", "B9DFF2", "FFFFFF", "D2EEB3", "99E487", "55B073" }, null)
            },
            {
                Diseños.Trans_loving_trans_6, new Banderas(Diseños.Trans_loving_trans_6, "Trans Loving Trans (TLT) #6", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF5174", "FFCC9A", "FEFFD7", "2CDDD7", "516BFE" }), Operaciones.Empty(), false,
                new string[] { "FF5174", "FFCC9A", "FEFFD7", "2CDDD7", "516BFE" }, null)
            },
            {
                Diseños.Transfeminism_MTF, new Banderas(Diseños.Transfeminism_MTF, "Transfeminism (MTF)", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "5BCEFA", "F7DAE6", "F7AFCF", "F688B9", "F7AFCF", "F7DAE6", "5BCEFA" }), Operaciones.Empty(), true,
                new string[] { "5BCEFA", "F7DAE6", "F7AFCF", "F688B9", "F7AFCF", "F7DAE6", "5BCEFA" }, null)
            },
            {
                Diseños.Transfeminism_MTF_2, new Banderas(Diseños.Transfeminism_MTF_2, "Transfeminism (MTF) #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FC81C8", "BD0D61", "FBC6FF", "BD0D61", "FC81C8" }), Operaciones.Empty(), true,
                new string[] { "FC81C8", "BD0D61", "FBC6FF", "BD0D61", "FC81C8" }, null)
            },
            {
                Diseños.Transfeminism_MTF_3, new Banderas(Diseños.Transfeminism_MTF_3, "Transfeminism (MTF) #3", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFFFFF", "F7ABB8", "D94585", "2B2D2D" }), Operaciones.Empty(), true,
                new string[] { "FFFFFF", "F7ABB8", "D94585", "2B2D2D" }, null)
            },
            {
                Diseños.Transfeminism_MTF_4, new Banderas(Diseños.Transfeminism_MTF_4, "Transfeminism (MTF) #4", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "B22234", "F5A9B8", "FFFFFF", "F5A9B8", "B22234" }), Operaciones.Empty(), true,
                new string[] { "B22234", "F5A9B8", "FFFFFF", "F5A9B8", "B22234" }, null)
            },
            {
                Diseños.Transfeminism_MTF_5, new Banderas(Diseños.Transfeminism_MTF_5, "Transfeminism (MTF) #5", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "073763", "FF89CD", "FFAEDC", "FFD1EB", "FFAEDC", "FF89CD", "073763" }), Operaciones.Empty(), true,
                new string[] { "073763", "FF89CD", "FFAEDC", "FFD1EB", "FFAEDC", "FF89CD", "073763" }, null)
            },
            {
                Diseños.Transgender___1999__, new Banderas(Diseños.Transgender___1999__, "Transgender [1999]", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "5BCEFA", "F5A9B8", "FFFFFF", "F5A9B8", "5BCEFA" }), Operaciones.Empty(), true,
                new string[] { "5BCEFA", "F5A9B8", "FFFFFF", "F5A9B8", "5BCEFA" }, null)
            },
            {
                Diseños.Transgender_Israeli, new Banderas(Diseños.Transgender_Israeli, "Transgender (Israeli)", 1,
                Operaciones.Rectángulos_Horizontales(new string[] { "69F369" }), Operaciones.Empty(), false,
                new string[] { "69F369" }, null)
            },
            {
                Diseños.Transgender_Jennifer_Pellinen, new Banderas(Diseños.Transgender_Jennifer_Pellinen, "Transgender (Jennifer Pellinen)", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF00FF", "BB2BFC", "9600E2", "6F00A4", "0200FE" }), Operaciones.Empty(), false,
                new string[] { "FF00FF", "BB2BFC", "9600E2", "6F00A4", "0200FE" }, null)
            },
            {
                Diseños.Transgender_Johnathan_Andrew___1999__, new Banderas(Diseños.Transgender_Johnathan_Andrew___1999__, "Transgender (Johnathan Andrew) [1999]", 0,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F88BC1" }, new decimal[4] { 0m, 0m / 365m, 1m, 50m / 365m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 50m / 365m, 1m, 5m / 365m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "47A9FA" }, new decimal[4] { 0m, 55m / 365m, 1m, 46m / 365m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 101m / 365m, 1m, 5m / 365m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F88BC1" }, new decimal[4] { 0m, 106m / 365m, 1m, 48m / 365m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 154m / 365m, 1m, 5m / 365m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "47A9FA" }, new decimal[4] { 0m, 159m / 365m, 1m, 47m / 365m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 206m / 365m, 1m, 5m / 365m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F88BC1" }, new decimal[4] { 0m, 211m / 365m, 1m, 46m / 365m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 257m / 365m, 1m, 5m / 365m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "47A9FA" }, new decimal[4] { 0m, 262m / 365m, 1m, 49m / 365m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 311m / 365m, 1m, 5m / 365m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "F88BC1" }, new decimal[4] { 0m, 316m / 365m, 1m, 49m / 365m }),
                },
                Operaciones.Empty(), false,
                new string[] {  }, null)
            },
            {
                Diseños.Transgender_Michelle_Lindsay___2010__, new Banderas(Diseños.Transgender_Michelle_Lindsay___2010__, "Transgender (Michelle Lindsay) [2010]", 2,
                Operaciones.Rectángulos_Horizontales(new string[] { "ED058D", "0091D4" }), Operaciones.Empty(), false,
                new string[] { "ED058D", "0091D4" }, null)
            },
            {
                Diseños.Transneutral, new Banderas(Diseños.Transneutral, "Transneutral [2010]", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFFBA6", "FFF344", "FFFDCC", "FFF344", "FFFBA6" }), Operaciones.Empty(), true,
                new string[] { "FFFBA6", "FFF344", "FFFDCC", "FFF344", "FFFBA6" }, null)
            },
            {
                Diseños.Transmasculine_FTM, new Banderas(Diseños.Transmasculine_FTM, "Transmasculine (FTM)", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF8ABE", "CCF5FF", "99ECFF", "75DFFF", "99ECFF", "CCF5FF", "FF8ABE" }), Operaciones.Empty(), true,
                new string[] { "FF8ABE", "CCF5FF", "99ECFF", "75DFFF", "99ECFF", "CCF5FF", "FF8ABE" }, null)
            },
            {
                Diseños.Travesti, new Banderas(Diseños.Travesti, "Travesti (Latin America)", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "D887DC", "FFC6DE", "FFFFFF", "FFC6DE", "D887DC" }), Operaciones.Empty(), true,
                new string[] { "D887DC", "FFC6DE", "FFFFFF", "FFC6DE", "D887DC" }, null)
            },
            {
                Diseños.Travesti_2, new Banderas(Diseños.Travesti_2, "Travesti (Latin America) #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF6766", "FFB3B3", "FFFFFF", "FFB3B3", "FF6766" }), Operaciones.Empty(), false,
                new string[] { "FF6766", "FFB3B3", "FFFFFF", "FFB3B3", "FF6766" }, null)
            },
            {
                Diseños.Travesti_3, new Banderas(Diseños.Travesti_3, "Travesti (Latin America) #3", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "73DEFF", "FFDCD7", "FFB5D6", "D887DC", "FFB5D6", "FFDCD7", "73DEFF" }), Operaciones.Empty(), false,
                new string[] { "73DEFF", "FFDCD7", "FFB5D6", "D887DC", "FFB5D6", "FFDCD7", "73DEFF" }, null)
            },
            {
                Diseños.Trigender, new Banderas(Diseños.Trigender, "Trigender", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FF95C5", "9580FF", "67D967", "9580FF", "FF95C5" }), Operaciones.Empty(), true,
                new string[] { "FF95C5", "9580FF", "67D967", "9580FF", "FF95C5" }, null)
            },
            {
                Diseños.Trisexual, new Banderas(Diseños.Trisexual, "Trisexual", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "CD4499", "4875E7", "FFFFFF", "982FD9" }), Operaciones.Empty(), true,
                new string[] { "CD4499", "4875E7", "FFFFFF", "982FD9" }, null)
            },
            {
                Diseños.Trisexual_2, new Banderas(Diseños.Trisexual_2, "Trisexual #2", 7,
                Operaciones.Rectángulos_Horizontales(new string[] { "57BFD9", "9BD9E9", "FFFAB4", "FEF035", "FFFAB4", "FDAFC9", "F16E76" }), Operaciones.Empty(), true,
                new string[] { "57BFD9", "9BD9E9", "FFFAB4", "FEF035", "FFFAB4", "FDAFC9", "F16E76" }, null)
            },
            {
                Diseños.Trixic, new Banderas(Diseños.Trixic, "Trixic", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "B452CD", "EEAEEE", "FFC0CB", "FFE7BA", "FFB90F" }), Operaciones.Empty(), true,
                new string[] { "B452CD", "EEAEEE", "FFC0CB", "FFE7BA", "FFB90F" }, null)
            },
            {
                Diseños.Tumtum, new Banderas(Diseños.Tumtum, "Tumtum", 0,
                new Operaciones[]
                {
                    // 448, 548, 448, 2112, 448, 548, 448.
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "1C16BC" }, new decimal[4] { 0m / 5000m, 0m, 448m / 3000m, 1m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 448m / 5000m, 0m, 548m / 3000m, 1m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "1C16BC" }, new decimal[4] { 996m / 5000m, 0m, 448m / 3000m, 1m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "808080" }, new decimal[4] { 1444m / 5000m, 0m, 2112m / 3000m, 1m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "1C16BC" }, new decimal[4] { 3556m / 5000m, 0m, 448m / 3000m, 1m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 4004m / 5000m, 0m, 548m / 3000m, 1m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "1C16BC" }, new decimal[4] { 4552m / 5000m, 0m, 448m / 3000m, 1m }),
                },
                Operaciones.Empty(), true,
                new string[] { "1C16BC", "FFFFFF", "1C16BC", "808080", "1C16BC", "FFFFFF", "1C16BC" },
                new decimal[]{ 448m / 5000m, 548m / 5000m, 448m / 5000m, 2112m / 5000m, 448m / 5000m, 548m / 5000m, 448m / 5000m })
            },
            {
                Diseños.Turian, new Banderas(Diseños.Turian, "Turian", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "D182A8", "F9F6E0", "68ACBE", "5D448E", "3B113F" }), Operaciones.Empty(), true,
                new string[] { "D182A8", "F9F6E0", "68ACBE", "5D448E", "3B113F" }, null)
            },
            {
                Diseños.Twink, new Banderas(Diseños.Twink, "Twink", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "FFB0FF", "FFFFFF", "FFFF80" }), Operaciones.Empty(), true,
                new string[] { "FFB0FF", "FFFFFF", "FFFF80" }, null)
            },
            {
                Diseños.Two_Spirit, new Banderas(Diseños.Two_Spirit, "Two Spirit", 6,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "E30303" }, new decimal[4] { 0m, 0m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FF8B00" }, new decimal[4] { 0m, 1m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FEED00" }, new decimal[4] { 0m, 2m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "008026" }, new decimal[4] { 0m, 3m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "004DFF" }, new decimal[4] { 0m, 4m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "750686" }, new decimal[4] { 0m, 5m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "FFFFFF" }, new decimal[4] { 1765m / 5000m, 429m / 3000m, 1470m / 5000m, 2142m / 3000m }, "Two_Spirit.png"),
                },
                Operaciones.Empty(), true,
                new string[] { "E30303", "FF8B00", "FEED00", "008026", "004DFF", "750686" }, null)
            },
            /*{
                Diseños.Uab, new Banderas("",
                "",
                Operaciones.Rectángulos_Horizontales(new string[] { "70848F", "B6C6C9", "FFFFFF", "CD85CD", "B4BACB" }), Operaciones.Empty(), true,
                new string[] { "70848F", "B6C6C9", "FFFFFF", "CD85CD", "B4BACB" }, null)
            },*/
            {
                Diseños.Unlabeled, new Banderas(Diseños.Unlabeled, "Unlabeled", 4,
                Operaciones.Rectángulos_Horizontales(new string[] { "E6F9E3", "FDFDFB", "DCF0F7", "FAE1C2" }), Operaciones.Empty(), true,
                new string[] { "E6F9E3", "FDFDFB", "DCF0F7", "FAE1C2" }, null)
            },
            /*{
                Diseños.Uranic, new Banderas("Uranic",
                "Uranic is defined as a person who is attracted to men, masculine and androgynous non-binary people, and basically anyone who is not a woman nor feminine non-binary person. It is most often used by non-binary people, but it is not exclusive to them and can be used by anyone who feels it best describes their orientation. Uranic is sometimes seen as a \"masculine equivalent\" to neptunic.",
                Operaciones.Rectángulos_Horizontales(new string[] { "" }), Operaciones.Empty(), true,
                new string[] { "" }, null)
            },*/
            {
                Diseños.Uranic, new Banderas(Diseños.Uranic, "Uranic", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "3B7BD6", "4FA1F0", "69C9FB", "9AEBFC", "FFFBDE", "FFF2C6" }), Operaciones.Empty(), true,
                new string[] { "3B7BD6", "4FA1F0", "69C9FB", "9AEBFC", "FFFBDE", "FFF2C6" }, null)
            },
            {
                Diseños.Vincian, new Banderas(Diseños.Vincian, "Vincian", 6,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "440D63" }, new decimal[4] { 0m, 0m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "8F69E1" }, new decimal[4] { 0m, 1m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 2m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "70E9D8" }, new decimal[4] { 0m, 3m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "3E4BB6" }, new decimal[4] { 0m, 4m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "440D63" }, new decimal[4] { 0m, 5m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "FFFFFF" }, new decimal[4] { 455m / 1280m, 203m / 768m, 370m / 1280m, 362m / 768m }, "Vincian.png"),
                },
                Operaciones.Empty(), true,
                new string[] { "440D63", "8F69E1", "FFFFFF", "70E9D8", "3E4BB6", "440D63" }, null)
            },
            {
                Diseños.Virescin, new Banderas(Diseños.Virescin, "Virescin", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "579475", "45B177", "B0C963", "CACD80", "9D77A8" }), Operaciones.Empty(), false,
                new string[] { "579475", "45B177", "B0C963", "CACD80", "9D77A8" }, null)
            },
            {
                Diseños.Waria, new Banderas(Diseños.Waria, "Waria", 6,
                Operaciones.Rectángulos_Horizontales(new string[] { "CD1127", "000000", "FEAFC5", "FBC12E", "623814", "FFFFFF" }), Operaciones.Empty(), true,
                new string[] { "CD1127", "000000", "FEAFC5", "FBC12E", "623814", "FFFFFF" }, null)
            },
            {
                Diseños.Woman, new Banderas(Diseños.Woman, "Woman", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "FE8CBF", "FFC6DE", "FFFFFF", "FFC6DE", "FE8CBF" }), Operaciones.Empty(), true,
                new string[] { "FE8CBF", "FFC6DE", "FFFFFF", "FFC6DE", "FE8CBF" }, null)
            },
            {
                Diseños.Woman_related, new Banderas(Diseños.Woman_related, "Woman-related", 6,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FF6567" }, new decimal[4] { 0m, 0m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFBDB0" }, new decimal[4] { 0m, 1m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFF0DA" }, new decimal[4] { 0m, 2m / 6m, 1m, 2m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFBDB0" }, new decimal[4] { 0m, 4m / 6m, 1m, 1m / 6m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FF6567" }, new decimal[4] { 0m, 5m / 6m, 1m, 1m / 6m }),
                },
                Operaciones.Empty(), true,
                new string[] { "FF6567", "FFBDB0", "FFF0DA", "FFBDB0", "FF6567" }, null)
            },
            {
                Diseños.X_gender, new Banderas(Diseños.X_gender, "X-gender (Japan)", 1,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFFFFF" }, new decimal[4] { 0m, 0m, 1m, 1m }),

                    // 0.0974m;
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "5B5B5B" }, new decimal[] { 0m, 0m, 0.0974m, 0m, 0.5m, 0.5m - 0.0974m, 0.5m, 0.5m, 0.5m - 0.0974m, 0.5m, 0m, 0.0974m, 0m, 0m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "8B1FE2" }, new decimal[] { 1m, 0m, 1m, 0.0974m, 0.5m + 0.0974m, 0.5m, 0.5m, 0.5m, 0.5m, 0.5m - 0.0974m, 1m - 0.0974m, 0m, 1m, 0m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "000000" }, new decimal[] { 1m, 1m, 1m - 0.0974m, 1m, 0.5m, 0.5m + 0.0974m, 0.5m, 0.5m, 0.5m + 0.0974m, 0.5m, 1m, 1m - 0.0974m, 1m, 1m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Polígono, new string[] { "FFD800" }, new decimal[] { 0m, 1m, 0m, 1m - 0.0974m, 0.5m - 0.0974m, 0.5m, 0.5m, 0.5m, 0.5m, 0.5m + 0.0974m, 0.0974m, 1m, 0m, 1m }),
                },
                //Operaciones.Rectángulos_Horizontales(new string[] { "FFFFFF", "5B5B5B" }),
                Operaciones.Empty(), true,
                new string[] { "FFFFFF" }, null)
            },
            {
                Diseños.Xenic, new Banderas(Diseños.Xenic, "Xenic", 12,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "373A5E" }, new decimal[4] { 0m / 12m, 0m / 12m, 12m / 12m, 12m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "419462" }, new decimal[4] { 1m / 12m, 1m / 12m, 10m / 12m, 10m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "84C9D0" }, new decimal[4] { 2m / 12m, 2m / 12m, 8m / 12m, 8m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "D183B4" }, new decimal[4] { 3m / 12m, 3m / 12m, 6m / 12m, 6m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FEFAD8" }, new decimal[4] { 4m / 12m, 4m / 12m, 4m / 12m, 4m / 12m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "AE0046" }, new decimal[4] { 5m / 12m, 5m / 12m, 2m / 12m, 2m / 12m }),

                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "84C9D0" }, new decimal[4] { 4m / 12m, 7m / 12m, 4m / 12m, 1m / 12m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "419462" }, new decimal[4] { 3m / 12m, 8m / 12m, 6m / 12m, 1m / 12m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "373A5E" }, new decimal[4] { 2m / 12m, 9m / 12m, 8m / 12m, 1m / 12m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "2C502C" }, new decimal[4] { 1m / 12m, 10m / 12m, 10m / 12m, 1m / 12m }),
                    new Operaciones(Dibujos.Figuras, Funciones.Rectángulo, new string[] { "502C50" }, new decimal[4] { 0m / 12m, 11m / 12m, 12m / 12m, 1m / 12m }),
                },
                Operaciones.Empty(), true,
                new string[] { "373A5E", "419462", "84C9D0", "D183B4", "FEFAD8", "AE0046", "84C9D0", "419462", "373A5E", "2C502C", "502C50" },
                new decimal[]{ 1m / 12m, 1m / 12m, 1m / 12m, 1m / 12m, 1m / 12m, 2m / 12m, 1m / 12m, 1m / 12m, 1m / 12m, 1m / 12m, 1m / 12m })
            },
            {
                Diseños.Xenic_2, new Banderas(Diseños.Xenic_2, "Xenic #2", 5,
                Operaciones.Rectángulos_Horizontales(new string[] { "D185C5", "30132A", "B8ECD1", "000000", "CCCCCC" }), Operaciones.Empty(), false,
                new string[] { "E30303", "30132A", "B8ECD1", "000000", "CCCCCC" }, null)
            },
            {
                Diseños.Xenogender, new Banderas(Diseños.Xenogender, "Xenogender", 7,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FF6691" }, new decimal[4] { 0m, 0m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FF9997" }, new decimal[4] { 0m, 1m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FFB782" }, new decimal[4] { 0m, 2m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "FBFFA6" }, new decimal[4] { 0m, 3m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "84BBFF" }, new decimal[4] { 0m, 4m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "9C84FF" }, new decimal[4] { 0m, 5m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A317FF" }, new decimal[4] { 0m, 6m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "FFFFFF" }, new decimal[4] { 434m / 1920m, 342m / 1152m, 1054m / 1920m, 469m / 1152m }, "Xenogender.png"),
                },
                //Operaciones.Rectángulos_Horizontales(new string[] { "FF6691", "FF9997", "FFB782", "FBFFA6", "84BBFF", "9C84FF", "A317FF" }),
                Operaciones.Empty(), true,
                new string[] { "FF6691", "FF9997", "FFB782", "FBFFA6", "84BBFF", "9C84FF", "A317FF" }, null)
            },
            {
                Diseños.Xenogender_2, new Banderas(Diseños.Xenogender_2, "Xenogender #2", 7,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "BFC9E1" }, new decimal[4] { 0m, 0m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A09EF0" }, new decimal[4] { 0m, 1m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "5E44B2" }, new decimal[4] { 0m, 2m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "390738" }, new decimal[4] { 0m, 3m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "5E44B2" }, new decimal[4] { 0m, 4m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A09EF0" }, new decimal[4] { 0m, 5m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "BFC9E1" }, new decimal[4] { 0m, 6m / 7m, 1m, 1m / 7m }),
                    new Operaciones(Dibujos.Iconos, Funciones.Imagen, new string[] { "F9CC04" }, new decimal[4] { 580m / 1920m, 235m / 1152m, 760m / 1920m, 663m / 1152m }, "Xenogender_2.png"),
                },
                Operaciones.Empty(), false,
                new string[] { "BFC9E1", "A09EF0", "5E44B2", "390738", "5E44B2", "A09EF0", "BFC9E1" }, null)
            },
            {
                Diseños.Xyric, new Banderas(Diseños.Xyric, "Xyric", 3,
                Operaciones.Rectángulos_Horizontales(new string[] { "EEEE00", "FFFFFF", "EEEE00" }), Operaciones.Empty(), true,
                new string[] { "EEEE00", "FFFFFF", "EEEE00" }, null)
            },
            {
                Diseños.Zygosexual, new Banderas(Diseños.Zygosexual, "Zygosexual", 29,
                new Operaciones[]
                {
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "2F2F2F" }, new decimal[4] { 0m, 0m / 29m, 1m, 3m / 29m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "444444" }, new decimal[4] { 0m, 3m / 29m, 1m, 1m / 29m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "7B7B7B" }, new decimal[4] { 0m, 4m / 29m, 1m, 3m / 29m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A9A9A9" }, new decimal[4] { 0m, 7m / 29m, 1m, 1m / 29m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "C6C6C6" }, new decimal[4] { 0m, 8m / 29m, 1m, 3m / 29m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "550001" }, new decimal[4] { 0m, 11m / 29m, 1m, 1m / 29m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "700100" }, new decimal[4] { 0m, 12m / 29m, 1m, 5m / 29m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "550001" }, new decimal[4] { 0m, 17m / 29m, 1m, 1m / 29m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "C6C6C6" }, new decimal[4] { 0m, 18m / 29m, 1m, 3m / 29m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "A9A9A9" }, new decimal[4] { 0m, 21m / 29m, 1m, 1m / 29m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "7B7B7B" }, new decimal[4] { 0m, 22m / 29m, 1m, 3m / 29m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "444444" }, new decimal[4] { 0m, 25m / 29m, 1m, 1m / 29m }),
                    new Operaciones(Dibujos.Rayas, Funciones.Rectángulo, new string[] { "2F2F2F" }, new decimal[4] { 0m, 26m / 29m, 1m, 3m / 29m }),
                },
                Operaciones.Empty(), true,
                new string[] { "2F2F2F", "444444", "7B7B7B", "A9A9A9", "C6C6C6", "550001", "700100", "550001", "C6C6C6", "A9A9A9", "7B7B7B", "444444", "2F2F2F" },
                new decimal[]{ 3m / 29m, 1m / 29m, 3m / 29m, 1m / 29m, 3m / 29m, 1m / 29m, 5m / 29m, 1m / 29m, 3m / 29m, 1m / 29m, 3m / 29m, 1m / 29m, 3m / 29m })
            },
        };

        internal enum Ondas : int
        {
            Ninguna = 0,
            Horizontal,
            Vertical/*,
            Ambas*/
        }
    }
}
