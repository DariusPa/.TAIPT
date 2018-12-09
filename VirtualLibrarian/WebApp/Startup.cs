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
            LibraryDataIO.Instance.Init(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True",StringConstants.directoryForWeb,"Faces");
            ConfigureAuth(app);
        }
    }
}
