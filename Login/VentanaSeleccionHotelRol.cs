﻿using FrbaHotel.Menus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class VentanaSeleccionHotelRol : VentanaBase
    {
        Usuario usuario { get; set; }

        public VentanaSeleccionHotelRol(Usuario usuario)
        {
            this.usuario = usuario;    
            InitializeComponent();
            lblErrorRol.Hide();
        }

        public void configurarParaRol()
        {
            lblHotel.Hide();
            cbxHoteles.Hide();
            VentanaBase.comboBoxCargar(cbxRoles, usuario.roles);
        }

        public void configurarParaHotel()
        {
            cbxRoles.Hide();
            lblRol.Hide();
            VentanaBase.comboBoxCargar(cbxHoteles, usuario.hoteles);
        }

        public void configurarParaHotelYRol()
        {
            VentanaBase.comboBoxCargar(cbxHoteles, usuario.hoteles);
            VentanaBase.comboBoxCargar(cbxRoles, usuario.roles); ;
        }

        private void btnIngresarRol_Click(object sender, EventArgs e)
        {
            VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal(usuario);
            ventanaMenuPrincipal.Show();
        }

        private void VentanaSeleccionRol_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }

    }
}