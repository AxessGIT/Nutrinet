using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutrinetSync.ModeloSys
{
    public partial class nutrinetEntities
    {
        //Constructor que recibe un dato booleano cualquiera, que en realidad establece el ProxyCreationEnabled como false
        public nutrinetEntities(bool crear) : base("name=nutrinetEntities")
        {
            Configuration.ProxyCreationEnabled = false;
        }
    }
}