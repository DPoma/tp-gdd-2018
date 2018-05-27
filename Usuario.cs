﻿using FrbaHotel.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public List<string> Roles { get; set; }
        public string RolLogueado { get; set; }
        public List<string> Funcionalidades { get; set; }
        public string Hotel { get ;set; }

        public Usuario(LogueoDTO logueo)
        {
            this.NombreUsuario = logueo.User;
            this.Roles = logueo.Roles;
        }

        private List<string> FuncionalidadesDeRol(string rol)
        {
            return Database.FuncionalidadesDeRol(rol);
        }
    }
}