<<<<<<< HEAD
﻿using BlImplementation;
=======
﻿    using BlImplementation;
>>>>>>> ba9648521294c3265027d0de12859a2717a89e80
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public static class Factory
    {
        public static IBl Get() => new Bl();
    }
}