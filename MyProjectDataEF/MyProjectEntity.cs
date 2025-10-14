using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectDataEF
{
    public abstract class MyProjectEntity
    {

            public virtual int Id { get; set; }  // tüm tablolarda ortak Id


    }
}
