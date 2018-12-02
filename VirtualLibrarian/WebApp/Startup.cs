using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;
using WebApp.Models;

[assembly: OwinStartup(typeof(WebApp.Startup))]

namespace WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            LibraryDataIO.Instance.Init(StringConstants.directoryForWeb,@"JSON\books.json", @"JSON\users.json", @"JSON\authors.json", @"JSON\publishers.json","Faces", @"Faces\TrainedLabels.txt");
            LibraryDataIO.Instance.LoadData();
            ConfigureAuth(app);
        }
    }
}
