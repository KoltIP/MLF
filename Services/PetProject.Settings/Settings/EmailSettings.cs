﻿using PetProject.Settings.Interace;
using PetProject.Settings.Sourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Settings.Settings
{
    public class EmailSettings : IEmailSettings
    {
        private readonly ISettingsSource source;

        public EmailSettings(ISettingsSource source)
        {
            this.source = source;
        }

        public string FromName => source.GetAsString("Email:FromName");
        public string FromEmail => source.GetAsString("Email:FromEmail");
        public string Server => source.GetAsString("Email:Server");
        public int Port => source.GetAsInt("Email:Port");
        public string Login => source.GetAsString("Email:Login");
        public string Password => source.GetAsString("Email:Password");
        public bool Ssl => source.GetAsBool("Email:Ssl");
    }
}
