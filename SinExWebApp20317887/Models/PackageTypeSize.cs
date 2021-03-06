﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinExWebApp20317887.Models
{
    [Table("PackageTypeSize")]
    public class PackageTypeSize
    {
        public virtual int PackageTypeSizeID { get; set; }
        public virtual string info { get; set; }

        public virtual int PackageTypeID { get; set; }
        public virtual PackageType PackageType { get; set; }
    }
}