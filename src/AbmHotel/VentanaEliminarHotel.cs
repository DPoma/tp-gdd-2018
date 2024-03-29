﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using FrbaHotel.Clases;

namespace FrbaHotel.AbmHotel
{
    public partial class VentanaEliminarHotel : VentanaBase
    {

        #region Atributos
        
        VentanaHotel ventanaHotel { get; set; }
        Hotel hotel { get; set; }

        #endregion
        #region Constructores

        public VentanaEliminarHotel(VentanaHotel ventanaHotel, Hotel hotel)
        {
            InitializeComponent();
            this.ventanaHotel = ventanaHotel;
            this.hotel = hotel;
        }

        #endregion

        private void VentanaEliminarHotel_Load(object sender, EventArgs e)
        {
            lblHotel.Text = "Hotel: " + hotel.domicilio.pais + " - " + hotel.domicilio.ciudad + " - " + hotel.domicilio.calle + " - " + hotel.domicilio.numeroCalle;
            calendario.MinDate = DateTime.Parse(ConfigurationManager.AppSettings["fechaSistema"]);
            calendario.Hide();
            btnAceptarFecha.Hide();
        }

        private void btnElminarGuardar_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, controladorError))
            {
                if (DateTime.Parse(tbxFechaFin.Text) <= DateTime.Parse(tbxFechaInicio.Text))
                {
                    ventanaInformarError("La fecha de fin debe ser posterior a la fecha de inicio");
                    return;
                }
                HotelCerrado hotelCerrado = new HotelCerrado(hotel, DateTime.Parse(tbxFechaInicio.Text), DateTime.Parse(tbxFechaFin.Text), tbxMotivo.Text);
                if (Database.hotelCerradoAgregadoConExito(hotelCerrado))
                {
                    this.Hide();
                    ventanaHotel.ventanaActualizar(sender, e);
                    if(hotelCerrado.hotel.id == ventanaHotel.ventanaMenuPrincipal.sesion.hotel.id)
                        ventanaHotel.ventanaMenuPrincipalActualizar();
                }
            }
        }

        private void btnEliminarLimpiar_Click(object sender, EventArgs e)
        {
            tbxFechaInicio.Clear();
            tbxFechaFin.Clear();
            tbxMotivo.Clear();
            calendario.Hide();
            btnAceptarFecha.Hide();
        }

        private void btnAceptarFecha_Click(object sender, EventArgs e)
        {
            if (tbxFechaInicio.TabStop)
                tbxFechaInicio.Text = calendario.SelectionStart.ToShortDateString();
            else
                tbxFechaFin.Text = calendario.SelectionStart.ToShortDateString();
            calendario.Hide();
            btnAceptarFecha.Hide();
        }

        private void btnSeleccionarFechaInicio_Click(object sender, EventArgs e)
        {
            tbxFechaInicio.TabStop = true;
            calendario.Show();
            btnAceptarFecha.Show();
            controladorError.Clear();
        }

        private void btnSeleccionarFechaIFin_Click(object sender, EventArgs e)
        {
            tbxFechaInicio.TabStop = false;
            calendario.Show();
            btnAceptarFecha.Show();
            controladorError.Clear();
        }
    }
}
