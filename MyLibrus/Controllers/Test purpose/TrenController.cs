using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrenController : ControllerBase

    {
        private readonly TrainingClass _tren;

        public TrenController(TrainingClass trainingClass)
        {
            _tren = trainingClass;
        }

    }
}
